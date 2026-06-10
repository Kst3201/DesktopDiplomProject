using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM.RAMType
{
    public class RAMTypeService : IComponentService<RAMTypeDTO>
    {
        private RAMTypeCreator _creator;
        private UpgradePCApplicationContext _context;

        public RAMTypeService(UpgradePCApplicationContext context)
        {
            _creator = new RAMTypeCreator();
            _context = context;
        }

        public async Task<RAMTypeDTO> AddItem(RAMTypeDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(dto.Name);
                if (foundedItem != null) throw new ArgumentException(nameof(dto.Name));
                var newItem = new RAMTypeEntity()
                {
                    Name = dto.Name,
                    ScoreOne = dto.ScoreOne,
                    ScoreTwo = dto.ScoreTwo,
                    ScoreThree = dto.ScoreThree,
                    ScoreFour = dto.ScoreFour,
                    ScoreFive = dto.ScoreFive
                };
                await _context.RAMTypes.AddAsync(newItem);
                await _context.SaveChangesAsync();
                return await GetItem(dto.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RAMTypeDTO> GetItem(string name)
        {
            try
            {
                var foundedItem = await GetByName(name);
                if (foundedItem == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(foundedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RAMTypeDTO> GetItem(int id)
        {
            try
            {
                var foundedItem = await _context.RAMTypes
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

        public async Task<RAMTypeDTO> GetItemByFullName(string name)
        {
            try
            {
                var foundedItem = await GetByName(name);
                if (foundedItem == null) throw new ArgumentOutOfRangeException(nameof(name));
                return _creator.CreateDTO(foundedItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<RAMTypeDTO>> GetItems()
        {
            try
            {
                var list = await _context.RAMTypes.ToListAsync();
                return list?.Select(item => _creator.CreateDTO(item)).ToList() ?? new List<RAMTypeDTO>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<RAMTypeDTO>> GetItems(ICompatibilitySet set)
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
                    _context.RAMTypes.Remove(foundedItem);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RAMTypeDTO> UpdateItem(string name, RAMTypeDTO dto)
        {
            try
            {
                var foundedItem = await GetByName(name);
                RAMTypeDTO? result = null;
                if (foundedItem == null)
                    result = await AddItem(dto);
                else
                {
                    foundedItem.Name = dto.Name;
                    foundedItem.ScoreOne = dto.ScoreOne;
                    foundedItem.ScoreTwo = dto.ScoreTwo;
                    foundedItem.ScoreThree = dto.ScoreThree;
                    foundedItem.ScoreFour = dto.ScoreFour;
                    foundedItem.ScoreFive = dto.ScoreFive;
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

        private async Task<RAMTypeEntity?> GetByName(string name)
        {
            return await _context.RAMTypes
                .FirstOrDefaultAsync(item => item.Name.Equals(name));
        }
    }
}
