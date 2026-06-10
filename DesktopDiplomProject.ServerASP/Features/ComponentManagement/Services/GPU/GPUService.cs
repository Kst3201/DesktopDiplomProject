using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU
{
    public class GPUService : IGPUService
    {
        private GPUCreator _creator;
        private UpgradePCApplicationContext _context;
        private IComponentIntParameterService<GPUFrequencyEntity> _frequencyService;
        private IComponentIntParameterService<GPUCountRasterizationBlocksEntity> _rasterService;
        private IComponentIntParameterService<GPUCountRTCoresEntity> _rtCoresService;
        private IComponentIntParameterService<GPUCountTensorCoresEntity> _tensorService;
        private IComponentIntParameterService<GPUCountTexturerBlocksEntity> _texturerService;
        private IComponentIntParameterService<GPUCountUniversalProcessorsEntity> _universalService;

        public GPUService(UpgradePCApplicationContext context, IDefuzzifyFunction function)
        {
            _creator = new GPUCreator(function);
            _context = context;
            var fuzzCreator = new FuzzyServiceCreator();
            _frequencyService = new NativeComponentIntParameterService<GPUFrequencyEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _rasterService = new NativeComponentIntParameterService<GPUCountRasterizationBlocksEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _rtCoresService = new NativeComponentIntParameterService<GPUCountRTCoresEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _tensorService = new NativeComponentIntParameterService<GPUCountTensorCoresEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _texturerService = new NativeComponentIntParameterService<GPUCountTexturerBlocksEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _universalService = new NativeComponentIntParameterService<GPUCountUniversalProcessorsEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
        }

        public async Task<GPUDTO> AddItem(GPUDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                if (foundedItem != null) throw new ArgumentException(nameof(dto));
                var frequency = await _frequencyService.GetOrAdd(dto.BaseFrequency);
                var universal = await _universalService.GetOrAdd(dto.CountUniversalProcessors);
                var texturer = await _texturerService.GetOrAdd(dto.CountTexturerBlocks);
                var raster = await _rasterService.GetOrAdd(dto.CountRasterizationBlocks);
                var rt = await _rtCoresService.GetOrAdd(dto.CountRTCores);
                var tensor = await _tensorService.GetOrAdd(dto.CountTensorCores);
                var newItem = new GPUEntity()
                {
                    Name = dto.Name,
                    Manufacturer = dto.Manufacturer,
                    Model = dto.Model,
                    BaseFrequencyID = frequency.ID,
                    CountUniversalProcessorsID = universal.ID,
                    CountTexturerBlocksID = texturer.ID,
                    CountRasterizationBlocksID = raster.ID,
                    CountRTCoresID = rt.ID,
                    CountTensorCoresID = tensor.ID
                };
                await _context.GPUs.AddAsync(newItem);
                await _context.SaveChangesAsync();
                return await GetItem(dto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<GPUDTO> GetItem(string name)
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

        public async Task<GPUDTO> GetItemByFullName(string name)
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

        public async Task<GPUDTO> GetItem(int id)
        {
            try
            {
                var foundedItem = await _context.GPUs
                .Include(item => item.BaseFrequency)
                .Include(item => item.CountUniversalProcessors)
                .Include(item => item.CountTexturerBlocks)
                .Include(item => item.CountRasterizationBlocks)
                .Include(item => item.CountRTCores)
                .Include(item => item.CountTensorCores)
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

        public async Task<IEnumerable<GPUDTO>> GetItems()
        {
            try
            {
                var list = await _context.GPUs
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.CountUniversalProcessors)
                    .Include(item => item.CountTexturerBlocks)
                    .Include(item => item.CountRasterizationBlocks)
                    .Include(item => item.CountRTCores)
                    .Include(item => item.CountTensorCores)
                    .ToListAsync();
                return list.Select(item => _creator.CreateDTO(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<GPUDTO>> GetItems(ICompatibilitySet set)
        {
            return await GetItems();
        }

        public async Task RemoveItem(string name)
        {
            try
            {
                var foundedItem = await GetByName(name);
                if (foundedItem != null)
                {
                    _context.GPUs.Remove(foundedItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<GPUDTO> UpdateItem(string name, GPUDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(name);
                GPUDTO? result = null;
                if (foundedItem == null)
                    result = await AddItem(dto);
                else
                {
                    var frequency = await _frequencyService.GetOrAdd(dto.BaseFrequency);
                    var universal = await _universalService.GetOrAdd(dto.CountUniversalProcessors);
                    var texturer = await _texturerService.GetOrAdd(dto.CountTexturerBlocks);
                    var raster = await _rasterService.GetOrAdd(dto.CountRasterizationBlocks);
                    var rt = await _rtCoresService.GetOrAdd(dto.CountRTCores);
                    var tensor = await _tensorService.GetOrAdd(dto.CountTensorCores);
                    foundedItem.Name = dto.Name;
                    foundedItem.Manufacturer = dto.Manufacturer;
                    foundedItem.Model = dto.Model;
                    foundedItem.BaseFrequencyID = frequency.ID;
                    foundedItem.CountUniversalProcessorsID = universal.ID;
                    foundedItem.CountTexturerBlocksID = texturer.ID;
                    foundedItem.CountRasterizationBlocksID = raster.ID;
                    foundedItem.CountRTCoresID = rt.ID;
                    foundedItem.CountTensorCoresID = tensor.ID;
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

        public async Task<IEnumerable<GPUModel>> GetAll()
        {
            try
            {
                var list = await _context.GPUs
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.CountUniversalProcessors)
                    .Include(item => item.CountTexturerBlocks)
                    .Include(item => item.CountRasterizationBlocks)
                    .Include(item => item.CountRTCores)
                    .Include(item => item.CountTensorCores)
                    .ToListAsync();
                return list.Select(item => _creator.CreateModel(item));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private async Task<GPUEntity?> GetByNameAllIncluded(string name)
        {
            return await _context.GPUs
                .Include(item => item.BaseFrequency)
                .Include(item => item.CountUniversalProcessors)
                .Include(item => item.CountTexturerBlocks)
                .Include(item => item.CountRasterizationBlocks)
                .Include(item => item.CountRTCores)
                .Include(item => item.CountTensorCores)
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        private async Task<GPUEntity?> GetByName(string name)
        {
            return await _context.GPUs
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        private async Task<GPUEntity?> GetByFullNameAllIncluded(string name)
        {
            var foundedItem = await _context.GPUs
                .Include(item => item.BaseFrequency)
                .Include(item => item.CountUniversalProcessors)
                .Include(item => item.CountTexturerBlocks)
                .Include(item => item.CountRasterizationBlocks)
                .Include(item => item.CountRTCores)
                .Include(item => item.CountTensorCores)
                .FirstOrDefaultAsync(item => item.Name.Equals(name)
                || (EF.Functions.ILike(name, "%" + item.Manufacturer + "%")
                    && EF.Functions.ILike(name, "%" + item.Model + "%")));
            return foundedItem;
        }

        private IQueryable<GPUEntity> SetCompatibilityQuery(IQueryable<GPUEntity> listQuery, ICompatibilitySet set)
        {
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
