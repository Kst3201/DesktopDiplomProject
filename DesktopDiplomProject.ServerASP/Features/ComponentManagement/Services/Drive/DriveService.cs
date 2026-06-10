using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive
{
    public class DriveService : IDriveService
    {
        private DriveCreator _creator;
        private UpgradePCApplicationContext _context;
        private IComponentNamedUnitService<DriveConnectionInterfaceEntity> _connectorService;
        private IComponentIntParameterService<DriveCapacityEntity> _capacityService;
        private IComponentIntParameterService<DriveSpeedDataTransferEntity> _sdtService;
        private IComponentDoubleParameterService<DrivePriceEntity> _priceService;

        public DriveService(UpgradePCApplicationContext context, IDefuzzifyFunction function
            , IComponentNamedUnitService<DriveConnectionInterfaceEntity> connectorService)
        {
            _creator = new DriveCreator(function);
            _context = context;
            _connectorService = connectorService;
            var fuzzCreator = new FuzzyServiceCreator();
            _capacityService = new NativeComponentIntParameterService<DriveCapacityEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _sdtService = new NativeComponentIntParameterService<DriveSpeedDataTransferEntity>(_context, fuzzCreator.CreateInt(FuzzyServiceType.Native));
            _priceService = new NativeComponentDoubleParameterService<DrivePriceEntity>(_context, fuzzCreator.CreateDouble(FuzzyServiceType.Native));
        }

        public async Task<DriveDTO> AddItem(DriveDTO dto)
        {
            try
            {
                var foundedItem = await _context.Drives
                    .FirstOrDefaultAsync(item => item.Name.Equals(dto.Name));
                var capacity = await _capacityService.GetOrAdd(dto.Capacity);
                var speed = await _sdtService.GetOrAdd(dto.SpeedDataTransfer);
                var price = await _priceService.GetOrAdd(dto.Price);
                var connector = await _connectorService.GetOrAddByName(dto.ConnectorInterface.Trim());
                DriveEntity newEntity = new DriveEntity()
                {
                    Name = dto.Name,
                    Manufacturer = dto.Manufacturer,
                    Model = dto.Model,
                    CapacityID = capacity.ID,
                    SpeedDataTransferID = speed.ID,
                    ConnectorInterfaceID = connector.ID,
                    PriceID = price.ID
                };
                await _context.Drives.AddAsync(newEntity);
                await _context.SaveChangesAsync();
                return await GetItem(dto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<DriveDTO> GetItem(string name)
        {
            try
            {
                var result = await _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.Name.Equals(name));
                if (result == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<DriveDTO> GetItemByFullName(string name)
        {
            try
            {
                var result = await GetByFullNameAllIncluded(name);
                if (result == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<DriveDTO> GetItem(int id)
        {
            try
            {
                var result = await _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.ID.Equals(id));
                if (result == null) throw new ArgumentOutOfRangeException(nameof(id));
                return _creator.CreateDTO(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<DriveDTO>> GetItems()
        {
            try
            {
                var list = await _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
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

        public async Task<IEnumerable<DriveDTO>> GetItems(ICompatibilitySet set)
        {
            try
            {
                var listQuery = _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
                    .Include(item => item.Price)
                    .AsQueryable();
                var list = await SetCompatibilityQuery(listQuery, set).ToListAsync();
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
                var foundedItem = await _context.Drives
                    .FirstOrDefaultAsync(item => item.Name.Equals(name));
                if (foundedItem != null)
                {
                    _context.Drives.Remove(foundedItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<DriveDTO> UpdateItem(string name, DriveDTO item)
        {
            try
            {
                var foundedItem = await _context.Drives
                    .FirstOrDefaultAsync(item => item.Name.Equals(name));
                DriveDTO? result = null;
                if (foundedItem == null)
                    result = await AddItem(item);
                else
                {
                    var capacity = await _capacityService.GetOrAdd(item.Capacity);
                    var speed = await _sdtService.GetOrAdd(item.SpeedDataTransfer);
                    var price = await _priceService.GetOrAdd(item.Price);
                    var connector = await _connectorService.GetOrAddByName(item.ConnectorInterface.Trim());
                    foundedItem.Name = item.Name;
                    foundedItem.Manufacturer = item.Manufacturer;
                    foundedItem.Model = item.Model;
                    foundedItem.CapacityID = capacity.ID;
                    foundedItem.SpeedDataTransferID = speed.ID;
                    foundedItem.ConnectorInterfaceID = connector.ID;
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

        public async Task<IEnumerable<DriveModel>> GetAll()
        {
            try
            {
                var list = await _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
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

        public async Task<IEnumerable<DriveModel>> GetAll(ICompatibilitySet set)
        {
            try
            {
                var listQuery = _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
                    .Include(item => item.Price)
                    .AsQueryable();
                var list = await SetCompatibilityQuery(listQuery, set).ToListAsync();
                return list.Select(item => _creator.CreateModel(item));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private async Task<DriveEntity?> GetByFullNameAllIncluded(string name)
        {
            var foundedItem = await _context.Drives
                    .Include(item => item.Capacity)
                    .Include(item => item.SpeedDataTransfer)
                    .Include(item => item.ConnectorInterface)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item => item.Name.Equals(name)
                    || (EF.Functions.ILike(name, "%" + item.Manufacturer + "%")
                        && EF.Functions.ILike(name, "%" + item.Model + "%")));
            return foundedItem;
        }

        private IQueryable<DriveEntity> SetCompatibilityQuery(IQueryable<DriveEntity> listQuery, ICompatibilitySet set)
        {
            if (set != null)
            {
                if (set.DriveConnectionInterfaces != null)
                {
                    var lowerInterfaces = set.DriveConnectionInterfaces.Select(item => item.ToLower()).ToList();
                    listQuery = listQuery.Where(item => lowerInterfaces.Contains(item.ConnectorInterface.Name.ToLower()));
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
