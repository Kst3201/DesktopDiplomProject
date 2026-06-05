using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM
{
    public class RAMService : IComponentService<RAMDTO>
    {
        private DbContext _context;
        private IComponentIntParameterService<RAMCountModulesEntity> _ramCountService;
        private IComponentIntParameterService<RAMFrequencyEntity> _ramFrequencyService;
        private IComponentIntParameterService<RAMSingleModuleCapacityEntity> _ramCapacityService;
        private IComponentDoubleParameterService<RAMPriceEntity> _priceService;

        public async Task<bool> AddItem(RAMDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<RAMDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<RAMDTO> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RAMDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(RAMDTO item)
        {
            throw new NotImplementedException();
        }

        public RAMService(DbContext context, IFuzzyService<int> fuzzyIntService, IFuzzyService<double> fuzzyDoubleService)
        {
            _context = context;
            _ramCountService = new NativeComponentIntParameterService<RAMCountModulesEntity>(_context, fuzzyIntService);
            _ramFrequencyService = new NativeComponentIntParameterService<RAMFrequencyEntity>(_context, fuzzyIntService);
            _ramCapacityService = new NativeComponentIntParameterService<RAMSingleModuleCapacityEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<RAMPriceEntity>(_context, fuzzyDoubleService);
        }
    }
}
