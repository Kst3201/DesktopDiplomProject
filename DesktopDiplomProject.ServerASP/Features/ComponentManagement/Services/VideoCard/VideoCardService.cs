using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard
{
    public class VideoCardService : IVideoCardService
    {
        private VideoCardCreator _creator;
        private UpgradePCApplicationContext _context;
        private IComponentNamedUnitService<PCIEInterfaceEntity> _pcieService;
        private IComponentIntParameterService<VCCapacityVideoMemoryEntity> _videoMemoryService;
        private IComponentIntParameterService<VCCountMonitorsEntity> _monitorsService;
        private IComponentIntParameterService<VCThroughputCapacityEntity> _throughputService;
        private IComponentIntParameterService<VCMemoryFrequencyEntity> _frequencyService;
        private IComponentDoubleParameterService<VCPriceEntity> _priceService;

        public VideoCardService(UpgradePCApplicationContext context, IDefuzzifyFunction function
            , IComponentNamedUnitService<PCIEInterfaceEntity> pcieService)
        {
            _creator = new VideoCardCreator(function);
            _context = context;
            _pcieService = pcieService;
            var fuzzCreator = new FuzzyServiceCreator();
            _videoMemoryService = new NativeComponentIntParameterService<VCCapacityVideoMemoryEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _monitorsService = new NativeComponentIntParameterService<VCCountMonitorsEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _throughputService = new NativeComponentIntParameterService<VCThroughputCapacityEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _frequencyService = new NativeComponentIntParameterService<VCMemoryFrequencyEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _priceService = new NativeComponentDoubleParameterService<VCPriceEntity>(_context, fuzzCreator.CreateDouble(FuzzyServiceType.Native));
        }

        public async Task<VideoCardDTO> AddItem(VideoCardDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                if (foundedItem != null) throw new ArgumentException(nameof(dto.Name));
                var gpu = await _context.GPUs
                    .FirstOrDefaultAsync(item => item.Name.Equals(dto.GPU));
                var pcie = await _pcieService.GetOrAddByName(dto.PCIEInterface);
                var capacityVM = await _videoMemoryService.GetOrAdd(dto.CapacityVideoMemory);
                var monitors = await _monitorsService.GetOrAdd(dto.CountMonitors);
                var capacityT = await _throughputService.GetOrAdd(dto.MaxThroughputCapacity);
                var frequency = await _frequencyService.GetOrAdd(dto.MemoryFrequency);
                var price = await _priceService.GetOrAdd(dto.Price);
                if (gpu == null) throw new ArgumentException($"Видеочип не был найден");
                var newValue = new VideoCardEntity()
                {
                    Name = dto.Name,
                    Manufacturer = dto.Manufacturer,
                    Model = dto.Model,
                    PCIEInterfaceID = pcie.ID,
                    CountPCIELines = dto.CountPCIELines,
                    RecommendedBlockPower = dto.RecommendedBlockPower,
                    CountPinsAdditionalPower = dto.CountPinsAdditionalPower,
                    CapacityVideoMemoryID = capacityVM.ID,
                    CountMonitorsID = monitors.ID,
                    MaxThroughputCapacityID = capacityT.ID,
                    MemoryFrequencyID = frequency.ID,
                    PriceID = price.ID,
                    GPUID = gpu.ID
                };
                await _context.VideoCards.AddAsync(newValue);
                await _context.SaveChangesAsync();
                return await GetItem(dto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<VideoCardDTO> GetItem(string name)
        {
            try
            {
                var foundedItem = await GetByNameAllIncluded(name);
                if (foundedItem == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(foundedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<VideoCardDTO> GetItemByFullName(string name)
        {
            try
            {
                var foundedItem = await GetByFullNameAllIncluded(name);
                if (foundedItem == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(foundedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<VideoCardDTO> GetFirstItemByGPU(string gpu)
        {
            try
            {
                var foundedGPU = await GetGPUByFullNameAllIncluded(gpu);
                if (foundedGPU == null) throw new ArgumentOutOfRangeException(nameof(gpu));
                var foundedItem = await _context.VideoCards
                    .Include(item => item.GPU)
                    .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                    .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.CapacityVideoMemory)
                    .Include(item => item.CountMonitors)
                    .Include(item => item.MaxThroughputCapacity)
                    .Include(item => item.MemoryFrequency)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.GPUID.Equals(foundedGPU.ID)); ;
                if (foundedItem == null) throw new ArgumentOutOfRangeException(nameof(gpu));
                return _creator.CreateDTO(foundedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<VideoCardDTO> GetItem(int id)
        {
            try
            {
                var foundedItem = await _context.VideoCards
                    .Include(item => item.GPU)
                    .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                    .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.CapacityVideoMemory)
                    .Include(item => item.CountMonitors)
                    .Include(item => item.MaxThroughputCapacity)
                    .Include(item => item.MemoryFrequency)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.ID.Equals(id));
                if (foundedItem == null) throw new ArgumentOutOfRangeException(nameof(id));
                return _creator.CreateDTO(foundedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<VideoCardDTO>> GetItems()
        {
            try
            {
                var list = await _context.VideoCards
                    .Include(item => item.GPU)
                    .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                    .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.CapacityVideoMemory)
                    .Include(item => item.CountMonitors)
                    .Include(item => item.MaxThroughputCapacity)
                    .Include(item => item.MemoryFrequency)
                    .Include(item => item.Price)
                    .ToListAsync();
                return list.Select(item => _creator.CreateDTO(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<VideoCardDTO>> GetItems(ICompatibilitySet set)
        {
            try
            {
                var listQ = _context.VideoCards
                    .Include(item => item.GPU)
                    .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                    .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.CapacityVideoMemory)
                    .Include(item => item.CountMonitors)
                    .Include(item => item.MaxThroughputCapacity)
                    .Include(item => item.MemoryFrequency)
                    .Include(item => item.Price)
                    .AsQueryable();
                var list = await SetCompatibilityQuery(listQ, set).ToListAsync();
                return list.Select(item => _creator.CreateDTO(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task RemoveItem(string name)
        {
            try
            {
                var foundedItem = await GetByName(name);
                if (foundedItem != null)
                {
                    _context.VideoCards.Remove(foundedItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<VideoCardDTO> UpdateItem(string name, VideoCardDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(name);
                VideoCardDTO? result = null;
                if (foundedItem == null)
                    result = await AddItem(dto);
                else
                {
                    var gpu = await _context.GPUs
                        .FirstOrDefaultAsync(item => item.Name.Equals(dto.GPU));
                    var pcie = await _pcieService.GetOrAddByName(dto.PCIEInterface);
                    var capacityVM = await _videoMemoryService.GetOrAdd(dto.CapacityVideoMemory);
                    var monitors = await _monitorsService.GetOrAdd(dto.CountMonitors);
                    var capacityT = await _throughputService.GetOrAdd(dto.MaxThroughputCapacity);
                    var frequency = await _frequencyService.GetOrAdd(dto.MemoryFrequency);
                    var price = await _priceService.GetOrAdd(dto.Price);
                    if (gpu == null) throw new ArgumentException($"Видеочип не был найден");
                    foundedItem.Name = dto.Name;
                    foundedItem.Manufacturer = dto.Manufacturer;
                    foundedItem.Model = dto.Model;
                    foundedItem.GPUID = gpu.ID;
                    foundedItem.PCIEInterfaceID = pcie.ID;
                    foundedItem.CountPCIELines = dto.CountPCIELines;
                    foundedItem.RecommendedBlockPower = dto.RecommendedBlockPower;
                    foundedItem.CountPinsAdditionalPower = dto.CountPinsAdditionalPower;
                    foundedItem.CapacityVideoMemoryID = capacityVM.ID;
                    foundedItem.CountMonitorsID = monitors.ID;
                    foundedItem.MaxThroughputCapacityID = capacityT.ID;
                    foundedItem.MemoryFrequencyID = frequency.ID;
                    foundedItem.PriceID = price.ID;
                    await _context.SaveChangesAsync();
                    result = await GetItem(foundedItem.ID);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<VideoCardModel>> GetAll()
        {
            try
            {
                var list = await _context.VideoCards
                    .Include(item => item.GPU)
                    .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                    .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.CapacityVideoMemory)
                    .Include(item => item.CountMonitors)
                    .Include(item => item.MaxThroughputCapacity)
                    .Include(item => item.MemoryFrequency)
                    .Include(item => item.Price)
                    .ToListAsync();
                return list.Select(item => _creator.CreateModel(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<VideoCardModel>> GetAll(ICompatibilitySet set)
        {
            try
            {
                var listQ = _context.VideoCards
                    .Include(item => item.GPU)
                    .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                    .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                    .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                    .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.CapacityVideoMemory)
                    .Include(item => item.CountMonitors)
                    .Include(item => item.MaxThroughputCapacity)
                    .Include(item => item.MemoryFrequency)
                    .Include(item => item.Price)
                    .AsQueryable();
                var list = await SetCompatibilityQuery(listQ, set).ToListAsync();
                return list.Select(item => _creator.CreateModel(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private async Task<VideoCardEntity?> GetByNameAllIncluded(string name)
        {
            return await _context.VideoCards
                .Include(item => item.GPU)
                .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                .Include(item => item.PCIEInterface)
                .Include(item => item.CapacityVideoMemory)
                .Include(item => item.CountMonitors)
                .Include(item => item.MaxThroughputCapacity)
                .Include(item => item.MemoryFrequency)
                .Include(item => item.Price)
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        private async Task<VideoCardEntity?> GetByName(string name)
        {
            return await _context.VideoCards
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        private async Task<VideoCardEntity?> GetByFullNameAllIncluded(string name)
        {
            var foundedItem = await _context.VideoCards
                .Include(item => item.GPU)
                .Include(item => item.GPU).ThenInclude(item => item.BaseFrequency)
                .Include(item => item.GPU).ThenInclude(item => item.CountUniversalProcessors)
                .Include(item => item.GPU).ThenInclude(item => item.CountTexturerBlocks)
                .Include(item => item.GPU).ThenInclude(item => item.CountRasterizationBlocks)
                .Include(item => item.GPU).ThenInclude(item => item.CountRTCores)
                .Include(item => item.GPU).ThenInclude(item => item.CountTensorCores)
                .Include(item => item.PCIEInterface)
                .Include(item => item.CapacityVideoMemory)
                .Include(item => item.CountMonitors)
                .Include(item => item.MaxThroughputCapacity)
                .Include(item => item.MemoryFrequency)
                .Include(item => item.Price)
                .FirstOrDefaultAsync(item => item.Name.Equals(name)
                || (EF.Functions.ILike(name, "%" + item.Manufacturer + "%")
                    && EF.Functions.ILike(name, "%" + item.Model + "%")));
            return foundedItem;
        }

        private async Task<GPUEntity?> GetGPUByFullNameAllIncluded(string name)
        {
            var foundedItem = await _context.GPUs
                .FirstOrDefaultAsync(item => item.Name.Equals(name)
                || (EF.Functions.ILike(name, "%" + item.Manufacturer + "%")
                    && EF.Functions.ILike(name, "%" + item.Model + "%")));
            return foundedItem;
        }


        private IQueryable<VideoCardEntity> SetCompatibilityQuery(IQueryable<VideoCardEntity> listQuery, ICompatibilitySet set)
        {
            if (set != null)
            {
                if (!string.IsNullOrWhiteSpace(set.PCIEInterface))
                {
                    listQuery = listQuery.Where(item => EF.Functions.ILike(item.PCIEInterface.Name, set.PCIEInterface));
                }
                if (set.MaxPrice != null && set.MaxPrice > 0)
                {
                    listQuery = listQuery.Where(item => item.Price.Value < set.MaxPrice.Value);
                }
            }
            return listQuery;
        }

        private bool CheckOnEqualByFullName(IComponentEntity entity, string name)
        {
            return entity.Name.Equals(name)
                || (EF.Functions.ILike(name, entity.Manufacturer)
                    && EF.Functions.ILike(name, entity.Model));
        }
    }
}
