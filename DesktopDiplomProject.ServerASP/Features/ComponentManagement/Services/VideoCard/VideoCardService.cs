using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
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
        private NativeComponentNamedUnitService<PCIEInterfaceEntity> _pcieService;
        private IComponentIntParameterService<VCCapacityVideoMemoryEntity> _videoMemoryService;
        private IComponentIntParameterService<VCCountMonitorsEntity> _monitorsService;
        private IComponentIntParameterService<VCThroughputCapacityEntity> _throughputService;
        private IComponentIntParameterService<VCMemoryFrequencyEntity> _frequencyService;
        private IComponentDoubleParameterService<VCPriceEntity> _priceService;

        public async Task<VideoCardDTO> AddItem(VideoCardDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                if (foundedItem != null) throw new ArgumentException(nameof(dto.Name));
                var gpu = await _context.GPUs
                    .FirstOrDefaultAsync(item => item.Name.Equals(dto.GPU, StringComparison.OrdinalIgnoreCase));
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

        public async Task<VideoCardDTO> UpdateItem(VideoCardDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                VideoCardDTO? result = null;
                if (foundedItem == null)
                    result = await AddItem(dto);
                else
                {
                    var gpu = await _context.GPUs
                        .FirstOrDefaultAsync(item => item.Name.Equals(dto.GPU, StringComparison.OrdinalIgnoreCase));
                    var pcie = await _pcieService.GetOrAddByName(dto.PCIEInterface);
                    var capacityVM = await _videoMemoryService.GetOrAdd(dto.CapacityVideoMemory);
                    var monitors = await _monitorsService.GetOrAdd(dto.CountMonitors);
                    var capacityT = await _throughputService.GetOrAdd(dto.MaxThroughputCapacity);
                    var frequency = await _frequencyService.GetOrAdd(dto.MemoryFrequency);
                    var price = await _priceService.GetOrAdd(dto.Price);
                    if (gpu == null) throw new ArgumentException($"Видеочип не был найден");
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
                .FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<VideoCardEntity?> GetByName(string name)
        {
            return await _context.VideoCards
                .FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public VideoCardService(UpgradePCApplicationContext context, IFuzzyService<int> fuzzyIntService
            , IFuzzyService<double> fuzzyDoubleService, IDefuzzifyFunction function)
        {
            _creator = new VideoCardCreator(function);
            _context = context;
            _pcieService = new NativeComponentNamedUnitService<PCIEInterfaceEntity>(_context);
            _videoMemoryService = new NativeComponentIntParameterService<VCCapacityVideoMemoryEntity>(_context, fuzzyIntService);
            _monitorsService = new NativeComponentIntParameterService<VCCountMonitorsEntity>(_context, fuzzyIntService);
            _throughputService = new NativeComponentIntParameterService<VCThroughputCapacityEntity>(_context, fuzzyIntService);
            _frequencyService = new NativeComponentIntParameterService<VCMemoryFrequencyEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<VCPriceEntity>(_context, fuzzyDoubleService);
        }
    }
}
