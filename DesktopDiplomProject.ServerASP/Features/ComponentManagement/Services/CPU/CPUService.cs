using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU
{
    public class CPUService : ICPUService
    {
        private CPUCreator _creator;
        private UpgradePCApplicationContext _context;
        private IComponentIntParameterService<CPUBaseFrequencyEntity> _frequencyService;
        private IComponentIntParameterService<CPUCoreCountEntity> _coreCountiesService;
        private IComponentIntParameterService<CPUThreadsCountEntity> _threadsCountiesService;
        private IComponentDoubleParameterService<CPUPriceEntity> _priceService;
        private NativeComponentNamedUnitService<CPUSocketEntity> _socketService;

        public async Task<CPUDTO> AddItem(CPUDTO dto)
        {
            try
            {
                var foundedItem = await _context.CPUs
                    .FirstOrDefaultAsync(item =>
                    item.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));
                if (foundedItem != null) throw new ArgumentException($"Процессор с названием {dto.Name} уже существует");
                var socket = await _socketService.GetOrAddByName(dto.Socket);
                var countCores = await _coreCountiesService.GetOrAdd(dto.CountCores);
                var countThreads = await _threadsCountiesService.GetOrAdd(dto.CountThreads);
                var baseFrequency = await _frequencyService.GetOrAdd(dto.BaseFrequency);
                var price = await _priceService.GetOrAdd(dto.Price);
                var ramType = await _context.RAMTypes.FirstOrDefaultAsync(ramType => ramType.Name.Equals(dto.RAMType));
                if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                CPUEntity newValue = new CPUEntity()
                {
                    Name = dto.Name,
                    Manufacturer = dto.Manufacturer,
                    Model = dto.Model,
                    SocketID = socket.ID,
                    CountCoresID = countCores.ID,
                    CountThreadsID = countThreads.ID,
                    BaseFrequencyID = baseFrequency.ID,
                    PriceID = price.ID,
                    RAMTypeID = ramType.ID
                };
                await _context.CPUs.AddAsync(newValue);
                await _context.SaveChangesAsync();
                return await GetItem(newValue.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CPUDTO> GetItem(string name)
        {
            try
            {
                var result = await _context.CPUs
                    .Include(item => item.Socket)
                    .Include(item => item.CountCores)
                    .Include(item => item.CountThreads)
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.RAMType)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item =>
                    item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (result == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CPUDTO> GetItem(int id)
        {
            try
            {
                var item = await _context.CPUs
                    .Include(item => item.Socket)
                    .Include(item => item.CountCores)
                    .Include(item => item.CountThreads)
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.RAMType)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(c => c.ID == id);
                if (item == null)
                    throw new Exception($"Процессор не был найден");
                return _creator.CreateDTO(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<CPUDTO>> GetItems()
        {
            try
            {
                var list = await _context.CPUs
                    .Include(item => item.Socket)
                    .Include(item => item.CountCores)
                    .Include(item => item.CountThreads)
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.RAMType)
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
                var result = await _context.CPUs
                    .FirstOrDefaultAsync(cpu => cpu.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (result != null)
                {
                    _context.CPUs.Remove(result);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CPUDTO> UpdateItem(CPUDTO item)
        {
            try
            {
                var dbItem = await _context.CPUs
                    .FirstOrDefaultAsync(cpu => cpu.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase));
                if (dbItem == null)
                    return await AddItem(item);
                else
                {
                    var ramType = await _context.RAMTypes.FirstOrDefaultAsync(ramType => ramType.Name.Equals(item.RAMType));
                    if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                    dbItem.Manufacturer = item.Manufacturer;
                    dbItem.Model = item.Model;
                    dbItem.SocketID = (await _socketService.GetOrAddByName(item.Socket)).ID;
                    dbItem.CountCoresID = (await _coreCountiesService.GetOrAdd(item.CountCores)).ID;
                    dbItem.CountThreadsID =
                        (await _threadsCountiesService.GetOrAdd(item.CountThreads)).ID;
                    dbItem.BaseFrequencyID =
                        (await _frequencyService.GetOrAdd(item.BaseFrequency)).ID;
                    dbItem.RAMTypeID = ramType.ID;
                    dbItem.PriceID =
                        (await _priceService.GetOrAdd(item.Price)).ID;
                    await _context.SaveChangesAsync();
                }
                return await GetItem(dbItem.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<CPUModel>> GetAll()
        {
            try
            {
                var list = await _context.CPUs
                    .Include(item => item.Socket)
                    .Include(item => item.CountCores)
                    .Include(item => item.CountThreads)
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.RAMType)
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

        public CPUService(UpgradePCApplicationContext context, IFuzzyService<int> fuzzyIntService, IFuzzyService<double> fuzzyDoubleService, IDefuzzifyFunction defFunction)
        {
            _creator = new CPUCreator(defFunction);
            _context = context;
            _socketService = new NativeComponentNamedUnitService<CPUSocketEntity>(_context);
            _frequencyService = new NativeComponentIntParameterService<CPUBaseFrequencyEntity>(_context, fuzzyIntService);
            _coreCountiesService = new NativeComponentIntParameterService<CPUCoreCountEntity>(_context, fuzzyIntService);
            _threadsCountiesService = new NativeComponentIntParameterService<CPUThreadsCountEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<CPUPriceEntity>(_context, fuzzyDoubleService);
        }
    }
}
