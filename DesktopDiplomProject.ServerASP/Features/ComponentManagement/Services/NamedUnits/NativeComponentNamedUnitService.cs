using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits
{
    public class NativeComponentNamedUnitService<TEntity> : IComponentNamedUnitService<TEntity, ComponentNamedUnitDTO>
        where TEntity : class, IEntityWithName, new()
    {
        private readonly static Dictionary<Type, ComponentUnitTypes> _unitTypeDicitonary = new Dictionary<Type, ComponentUnitTypes>()
        {
            [typeof(CPUSocketEntity)] = ComponentUnitTypes.Socket,
            [typeof(MBSizeEntity)] = ComponentUnitTypes.MotherboardSize,
            [typeof(PCIEInterfaceEntity)] = ComponentUnitTypes.PCIEInterface,
            [typeof(DriveConnectionInterfaceEntity)] = ComponentUnitTypes.DriveConnectionInterface
        };

        private UpgradePCApplicationContext _context;
        private DbSet<TEntity> _set;
        private readonly ComponentUnitTypes _unitType;

        public async Task<ComponentNamedUnitDTO?> GetItem(string name)
        {
            var value = await _set.FirstOrDefaultAsync(item => item.Name.Equals(name));
            ComponentNamedUnitDTO? result = null;
            if (value != null)
                result = new ComponentNamedUnitDTO(value.Name, _unitType);
            return result;
        }

        public async Task<IEnumerable<ComponentNamedUnitDTO>> GetItems()
        {
            return await _set.Select(item => new ComponentNamedUnitDTO(item.Name, _unitType)).ToListAsync();
        }

        public async Task<TEntity> GetOrAddByName(string name)
        {
            var value = await _set.FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (value == null)
            {
                value = new TEntity() { Name = name };
                await _set.AddAsync(value);
                await _context.SaveChangesAsync();
                value = await GetOrAddByName(name);
            }
            return value;
        }

        public async Task RemoveItem(string name)
        {
            var value = await _set.FirstOrDefaultAsync(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (value != null)
            {
                _set.Remove(value);
                await _context.SaveChangesAsync();
            }
        }

        public NativeComponentNamedUnitService(UpgradePCApplicationContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
            _unitType = GetType(typeof(TEntity));
        }

        private static ComponentUnitTypes GetType(Type type)
        {
            ComponentUnitTypes result = ComponentUnitTypes.None;
            if (type != null)
            {
                if (_unitTypeDicitonary.TryGetValue(type, out var resultValue))
                {
                    result = resultValue;
                }
                else
                {
                    result = ComponentUnitTypes.None;
                }
            }
            return result;
        }
    }
}
