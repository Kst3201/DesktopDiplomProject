using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU
{
    public class GPUService : IComponentService<GPUDTO>
    {
        private DbContext _context;
        private IComponentIntParameterService<GPUFrequencyEntity> _frequencyService;
        private IComponentIntParameterService<GPUCountRasterizationBlocksEntity> _rasterService;
        private IComponentIntParameterService<GPUCountRTCoresEntity> _rtCoresService;
        private IComponentIntParameterService<GPUCountTensorCoresEntity> _tensorService;
        private IComponentIntParameterService<GPUCountTexturerBlocksEntity> _texturerService;
        private IComponentIntParameterService<GPUCountUniversalProcessorsEntity> _universalService;

        public async Task<bool> AddItem(GPUDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<GPUDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<GPUDTO> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GPUDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(GPUDTO item)
        {
            throw new NotImplementedException();
        }

        public GPUService(DbContext context, IFuzzyService<int> fuzzyIntService)
        {
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
