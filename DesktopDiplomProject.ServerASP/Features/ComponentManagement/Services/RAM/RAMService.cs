using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM
{
    public class RAMService : IRAMService
    {
        private RAMCreator _creator;
        private UpgradePCApplicationContext _context;
        private IComponentIntParameterService<RAMCountModulesEntity> _ramCountService;
        private IComponentIntParameterService<RAMFrequencyEntity> _ramFrequencyService;
        private IComponentIntParameterService<RAMSingleModuleCapacityEntity> _ramCapacityService;
        private IComponentDoubleParameterService<RAMPriceEntity> _priceService;

        public RAMService(UpgradePCApplicationContext context, IFuzzyService<int> fuzzyIntService
            , IFuzzyService<double> fuzzyDoubleService, IDefuzzifyFunction function)
        {
            _creator = new RAMCreator(function);
            _context = context;
            _ramCountService = new NativeComponentIntParameterService<RAMCountModulesEntity>(_context, fuzzyIntService);
            _ramFrequencyService = new NativeComponentIntParameterService<RAMFrequencyEntity>(_context, fuzzyIntService);
            _ramCapacityService = new NativeComponentIntParameterService<RAMSingleModuleCapacityEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<RAMPriceEntity>(_context, fuzzyDoubleService);
        }

        public async Task<RAMDTO> AddItem(RAMDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                if (foundedItem != null) throw new ArgumentException(nameof(dto));
                var ramType = await _context.RAMTypes
                    .FirstOrDefaultAsync(item => item.Name.Equals(dto.Name));
                var capacity = await _ramCapacityService.GetOrAdd(dto.SingleModuleCapacity);
                var count = await _ramCountService.GetOrAdd(dto.CountModules);
                var frequency = await _ramFrequencyService.GetOrAdd(dto.Frequency);
                var price = await _priceService.GetOrAdd(dto.Price);
                if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                var newItem = new RAMEntity()
                {
                    Name = dto.Name,
                    Manufacturer = dto.Manufacturer,
                    Model = dto.Model,
                    RAMTypeID = ramType.ID,
                    SingleModuleCapacityID = capacity.ID,
                    CountModulesID = count.ID,
                    FrequencyID = frequency.ID,
                    PriceID = price.ID
                };
                await _context.RAMs.AddAsync(newItem);
                await _context.SaveChangesAsync();
                return await GetItem(dto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RAMDTO> GetItem(string name)
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

        public async Task<RAMDTO> GetItem(int id)
        {
            try
            {
                var foundedItem = await _context.RAMs
                    .Include(item => item.RAMType)
                    .Include(item => item.SingleModuleCapacity)
                    .Include(item => item.CountModules)
                    .Include(item => item.Frequency)
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

        public async Task<IEnumerable<RAMDTO>> GetItems()
        {
            try
            {
                var list = await _context.RAMs
                    .Include(item => item.RAMType)
                    .Include(item => item.SingleModuleCapacity)
                    .Include(item => item.CountModules)
                    .Include(item => item.Frequency)
                    .Include(item => item.Price)
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
                    _context.RAMs.Remove(foundedItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RAMDTO> UpdateItem(string name,RAMDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(name);
                RAMDTO? result = null;
                if (foundedItem == null)
                    result = await AddItem(dto);
                else
                {
                    var ramType = await _context.RAMTypes
                        .FirstOrDefaultAsync(item => item.Name.Equals(dto.Name));
                    var capacity = await _ramCapacityService.GetOrAdd(dto.SingleModuleCapacity);
                    var count = await _ramCountService.GetOrAdd(dto.CountModules);
                    var frequency = await _ramFrequencyService.GetOrAdd(dto.Frequency);
                    var price = await _priceService.GetOrAdd(dto.Price);
                    if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                    foundedItem.Name = dto.Name;
                    foundedItem.Manufacturer = dto.Manufacturer;
                    foundedItem.Model = dto.Model;
                    foundedItem.RAMTypeID = ramType.ID;
                    foundedItem.CountModulesID = count.ID;
                    foundedItem.SingleModuleCapacityID = capacity.ID;
                    foundedItem.FrequencyID = frequency.ID;
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

        private async Task<RAMEntity?> GetByNameAllIncluded(string name)
        {
            return await _context.RAMs
                .Include(item => item.RAMType)
                .Include(item => item.SingleModuleCapacity)
                .Include(item => item.CountModules)
                .Include(item => item.Frequency)
                .Include(item => item.Price)
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        private async Task<RAMEntity?> GetByName(string name)
        {
            return await _context.RAMs
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        public async Task<IEnumerable<RAMModel>> GetAll()
        {
            try
            {
                var list = await _context.RAMs
                    .Include(item => item.RAMType)
                    .Include(item => item.SingleModuleCapacity)
                    .Include(item => item.CountModules)
                    .Include(item => item.Frequency)
                    .Include(item => item.Price)
                    .ToListAsync();
                return list.Select(item => _creator.CreateModel(item));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
