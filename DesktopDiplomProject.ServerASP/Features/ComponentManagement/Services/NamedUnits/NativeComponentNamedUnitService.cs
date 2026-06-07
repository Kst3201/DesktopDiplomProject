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
    public class NativeComponentNamedUnitService<TEntity> : IComponentNamedUnitService<TEntity>
        where TEntity : class, IEntityWithName, new()
    {

        private UpgradePCApplicationContext _context;
        private DbSet<TEntity> _set;

        public async Task<ComponentNamedUnitDTO> GetItem(string name)
        {
            try
            {
                var value = await _set.FirstOrDefaultAsync(item => item.Name.Equals(name));
                if (value == null) throw new ArgumentOutOfRangeException(nameof(name));
                return new ComponentNamedUnitDTO(value.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<ComponentNamedUnitDTO>> GetItems()
        {
            try
            {
                return await _set.Select(item => new ComponentNamedUnitDTO(item.Name)).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<TEntity> GetOrAddByName(string name)
        {
            try
            {
                var value = await _set.FirstOrDefaultAsync(item => item.Name.Equals(name));
                if (value == null)
                {
                    value = new TEntity() { Name = name };
                    await _set.AddAsync(value);
                    await _context.SaveChangesAsync();
                    value = await GetOrAddByName(name);
                }
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<ComponentNamedUnitDTO> Update(string name, ComponentNamedUnitDTO value)
        {
            try
            {
                var foundedItem = await GetOrAddByName(name);
                foundedItem.Name = value.Name;
                await _context.SaveChangesAsync();
                return await GetItem(value.Name);
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
                var value = await _set.FirstOrDefaultAsync(item => item.Name.Equals(name));
                if (value != null)
                {
                    _set.Remove(value);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public NativeComponentNamedUnitService(UpgradePCApplicationContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }
    }
}
