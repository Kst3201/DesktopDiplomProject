using DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard
{
    public class MotherboardService : IComponentService<MotherboardDTO>
    {
        private DbContext _context;
        private IComponentIntParameterService<MBCountM2SlotsEntity> _m2Service;
        private IComponentIntParameterService<MBCountPCIEX16SlotsEntity> _countPCIEX16Service;
        private IComponentIntParameterService<MBCountSATASlotsEntity> _sataService;
        private IComponentIntParameterService<MBRAMValueEntity> _ramValueService;
        private IComponentIntParameterService<MBRAMCountSlotsEntity> _ramSlotsService;
        private IComponentIntParameterService<MBRAMFrequencyEntity> _ramFrequencyService;
        private IComponentDoubleParameterService<MBPriceEntity> _priceService;

        public async Task<bool> AddItem(MotherboardDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<MotherboardDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MotherboardDTO> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MotherboardDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(MotherboardDTO item)
        {
            throw new NotImplementedException();
        }

        public MotherboardService(DbContext context, IFuzzyService<int> fuzzyIntService, IFuzzyService<double> fuzzyDoubleService)
        {
            _context = context;
            _m2Service = new NativeComponentIntParameterService<MBCountM2SlotsEntity>(_context, fuzzyIntService);
            _countPCIEX16Service = new NativeComponentIntParameterService<MBCountPCIEX16SlotsEntity>(_context, fuzzyIntService);
            _sataService = new NativeComponentIntParameterService<MBCountSATASlotsEntity>(_context, fuzzyIntService);
            _ramValueService = new NativeComponentIntParameterService<MBRAMValueEntity>(_context, fuzzyIntService);
            _ramSlotsService = new NativeComponentIntParameterService<MBRAMCountSlotsEntity>(_context, fuzzyIntService);
            _ramFrequencyService = new NativeComponentIntParameterService<MBRAMFrequencyEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<MBPriceEntity>(_context, fuzzyDoubleService);
        }
    }
}
