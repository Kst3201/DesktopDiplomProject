using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
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
                return list.Select(item => _creator.CreateDTO(item));
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

        public async Task<GPUDTO> UpdateItem(GPUDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
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
                .FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<GPUEntity?> GetByName(string name)
        {
            return await _context.GPUs
                .FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public GPUService(UpgradePCApplicationContext context
            , IFuzzyService<int> fuzzyIntService, IDefuzzifyFunction function)
        {
            _creator = new GPUCreator(function);
            _context = context;
            _frequencyService = new NativeComponentIntParameterService<GPUFrequencyEntity>(_context, fuzzyIntService);
            _rasterService = new NativeComponentIntParameterService<GPUCountRasterizationBlocksEntity>(_context, fuzzyIntService);
            _rtCoresService = new NativeComponentIntParameterService<GPUCountRTCoresEntity>(_context, fuzzyIntService);
            _tensorService = new NativeComponentIntParameterService<GPUCountTensorCoresEntity>(_context, fuzzyIntService);
            _texturerService = new NativeComponentIntParameterService<GPUCountTexturerBlocksEntity>(_context, fuzzyIntService);
            _universalService = new NativeComponentIntParameterService<GPUCountUniversalProcessorsEntity>(_context, fuzzyIntService);
        }
    }
}
