using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard
{
    public class MotherboardService : IMotherboardService
    {
        private MotherboardCreator _creator;
        private UpgradePCApplicationContext _context;
        private IComponentNamedUnitService<MBSizeEntity> _sizeService;
        private IComponentNamedUnitService<CPUSocketEntity> _socketService;
        private IComponentNamedUnitService<PCIEInterfaceEntity> _pcieService;
        private IComponentIntParameterService<MBCountM2SlotsEntity> _m2Service;
        private IComponentIntParameterService<MBCountPCIEX16SlotsEntity> _countPCIEX16Service;
        private IComponentIntParameterService<MBCountSATASlotsEntity> _sataService;
        private IComponentIntParameterService<MBRAMValueEntity> _ramValueService;
        private IComponentIntParameterService<MBRAMCountSlotsEntity> _ramSlotsService;
        private IComponentIntParameterService<MBRAMFrequencyEntity> _ramFrequencyService;
        private IComponentDoubleParameterService<MBPriceEntity> _priceService;

        public MotherboardService(UpgradePCApplicationContext context, IFuzzyService<int> fuzzyIntService
            , IFuzzyService<double> fuzzyDoubleService, IDefuzzifyFunction function
            , IComponentNamedUnitService<MBSizeEntity> sizeService
            , IComponentNamedUnitService<CPUSocketEntity> socketService
            , IComponentNamedUnitService<PCIEInterfaceEntity> pcieService)
        {
            _creator = new MotherboardCreator(function);
            _context = context;
            _sizeService = sizeService;
            _socketService = socketService;
            _pcieService = pcieService;
            _m2Service = new NativeComponentIntParameterService<MBCountM2SlotsEntity>(_context, fuzzyIntService);
            _countPCIEX16Service = new NativeComponentIntParameterService<MBCountPCIEX16SlotsEntity>(_context, fuzzyIntService);
            _sataService = new NativeComponentIntParameterService<MBCountSATASlotsEntity>(_context, fuzzyIntService);
            _ramValueService = new NativeComponentIntParameterService<MBRAMValueEntity>(_context, fuzzyIntService);
            _ramSlotsService = new NativeComponentIntParameterService<MBRAMCountSlotsEntity>(_context, fuzzyIntService);
            _ramFrequencyService = new NativeComponentIntParameterService<MBRAMFrequencyEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<MBPriceEntity>(_context, fuzzyDoubleService);
        }

        public async Task<MotherboardDTO> AddItem(MotherboardDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                if (foundedItem != null) throw new ArgumentException(nameof(dto));
                var size = await _sizeService.GetOrAddByName(dto.Name);
                var socket = await _socketService.GetOrAddByName(dto.Name);
                var pcie = await _pcieService.GetOrAddByName(dto.Name);
                var ramType = await _context.RAMTypes
                    .FirstOrDefaultAsync(item => item.Name.Equals(dto.Name));
                var countM2 = await _m2Service.GetOrAdd(dto.CountM2Slots);
                var countX16 = await _countPCIEX16Service.GetOrAdd(dto.CountPCIEX16Slots);
                var countSATA = await _sataService.GetOrAdd(dto.CountSATASlots);
                var ramValue = await _ramValueService.GetOrAdd(dto.MaxRAMValue);
                var ramSlots = await _ramSlotsService.GetOrAdd(dto.RAMCountSlots);
                var ramFrequency = await _ramFrequencyService.GetOrAdd(dto.MaxRAMFrequency);
                var price = await _priceService.GetOrAdd(dto.Price);
                if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                MotherboardEntity newItem = new MotherboardEntity()
                {
                    Name = dto.Name,
                    Manufacturer = dto.Manufacturer,
                    Model = dto.Model,
                    SizeID = size.ID,
                    SocketID = socket.ID,
                    RAMTypeID = ramType.ID,
                    CountM2SlotsID = countM2.ID,
                    CountPCIEX16SlotsID = countX16.ID,
                    CountSATASlotsID = countSATA.ID,
                    MaxRAMValueID = ramValue.ID,
                    RAMCountSlotsID = ramSlots.ID,
                    MaxRAMFrequencyID = ramFrequency.ID,
                    PriceID = price.ID,
                };
                await _context.Motherboards.AddAsync(newItem);
                await _context.SaveChangesAsync();
                return await GetItem(dto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MotherboardDTO> GetItem(string name)
        {
            try
            {
                var result = await GetByNameAllIncluded(name);
                if (result == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MotherboardDTO> GetItem(int id)
        {
            try
            {
                var result = await _context.Motherboards
                    .Include(item => item.Size)
                    .Include(item => item.Socket)
                    .Include(item => item.RAMType)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.RAMCountSlots)
                    .Include(item => item.MaxRAMValue)
                    .Include(item => item.MaxRAMFrequency)
                    .Include(item => item.CountPCIEX16Slots)
                    .Include(item => item.CountM2Slots)
                    .Include(item => item.CountSATASlots)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.ID.Equals(id));
                if (result == null) throw new ArgumentOutOfRangeException(nameof(id));
                return _creator.CreateDTO(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<MotherboardDTO>> GetItems()
        {
            try
            {
                var list = await _context.Motherboards
                    .Include(item => item.Size)
                    .Include(item => item.Socket)
                    .Include(item => item.RAMType)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.RAMCountSlots)
                    .Include(item => item.MaxRAMValue)
                    .Include(item => item.MaxRAMFrequency)
                    .Include(item => item.CountPCIEX16Slots)
                    .Include(item => item.CountM2Slots)
                    .Include(item => item.CountSATASlots)
                    .Include(item => item.Price)
                    .ToListAsync();
                return list.Select(item => _creator.CreateDTO(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
                    _context.Motherboards.Remove(foundedItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MotherboardDTO> UpdateItem(string name,MotherboardDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(name);
                MotherboardDTO? result = null;
                if (foundedItem == null)
                {
                    result = await AddItem(dto);
                }
                else
                {
                    var size = await _sizeService.GetOrAddByName(dto.Name);
                    var socket = await _socketService.GetOrAddByName(dto.Name);
                    var pcie = await _pcieService.GetOrAddByName(dto.Name);
                    var ramType = await _context.RAMTypes
                        .FirstOrDefaultAsync(item => item.Name.Equals(dto.Name));
                    var countM2 = await _m2Service.GetOrAdd(dto.CountM2Slots);
                    var countX16 = await _countPCIEX16Service.GetOrAdd(dto.CountPCIEX16Slots);
                    var countSATA = await _sataService.GetOrAdd(dto.CountSATASlots);
                    var ramValue = await _ramValueService.GetOrAdd(dto.MaxRAMValue);
                    var ramSlots = await _ramSlotsService.GetOrAdd(dto.RAMCountSlots);
                    var ramFrequency = await _ramFrequencyService.GetOrAdd(dto.MaxRAMFrequency);
                    var price = await _priceService.GetOrAdd(dto.Price);
                    if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                    foundedItem.Name = dto.Name;
                    foundedItem.Manufacturer = dto.Manufacturer;
                    foundedItem.Model = dto.Model;
                    foundedItem.SizeID = size.ID;
                    foundedItem.SocketID = socket.ID;
                    foundedItem.PCIEInterfaceID = pcie.ID;
                    foundedItem.RAMTypeID = ramType.ID;
                    foundedItem.CountM2SlotsID = countM2.ID;
                    foundedItem.CountPCIEX16SlotsID = countX16.ID;
                    foundedItem.CountSATASlotsID = countSATA.ID;
                    foundedItem.MaxRAMValueID = ramValue.ID;
                    foundedItem.MaxRAMFrequencyID = ramFrequency.ID;
                    foundedItem.RAMCountSlotsID = ramSlots.ID;
                    foundedItem.PriceID = price.ID;
                    await _context.SaveChangesAsync();
                    result = await GetItem(foundedItem.ID);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<MotherboardModel>> GetAll()
        {
            try
            {
                var list = await _context.Motherboards
                    .Include(item => item.Size)
                    .Include(item => item.Socket)
                    .Include(item => item.RAMType)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.RAMCountSlots)
                    .Include(item => item.MaxRAMValue)
                    .Include(item => item.MaxRAMFrequency)
                    .Include(item => item.CountPCIEX16Slots)
                    .Include(item => item.CountM2Slots)
                    .Include(item => item.CountSATASlots)
                    .Include(item => item.Price)
                    .ToListAsync();
                return list.Select(item => _creator.CreateModel(item)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<MotherboardEntity?> GetByNameAllIncluded(string name)
        {
            return await _context.Motherboards
                    .Include(item => item.Size)
                    .Include(item => item.Socket)
                    .Include(item => item.RAMType)
                    .Include(item => item.PCIEInterface)
                    .Include(item => item.RAMCountSlots)
                    .Include(item => item.MaxRAMValue)
                    .Include(item => item.MaxRAMFrequency)
                    .Include(item => item.CountPCIEX16Slots)
                    .Include(item => item.CountM2Slots)
                    .Include(item => item.CountSATASlots)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }

        private async Task<MotherboardEntity?> GetByName(string name)
        {
            return await _context.Motherboards
                    .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }
    }
}
