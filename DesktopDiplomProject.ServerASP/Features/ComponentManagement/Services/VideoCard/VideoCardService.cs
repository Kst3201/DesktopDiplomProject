using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard
{
    public class VideoCardService : IComponentService<VideoCardDTO>
    {
        private DbContext _context;
        private IComponentIntParameterService<VCCapacityVideoMemoryEntity> _videoMemoryService;
        private IComponentIntParameterService<VCCountMonitorsEntity> _monitorsService;
        private IComponentIntParameterService<VCThroughputCapacityEntity> _throughputService;
        private IComponentIntParameterService<VCMemoryFrequencyEntity> _frequencyService;
        private IComponentDoubleParameterService<VCPriceEntity> _priceService;

        public async Task<bool> AddItem(VideoCardDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<VideoCardDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<VideoCardDTO> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VideoCardDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(VideoCardDTO item)
        {
            throw new NotImplementedException();
        }

        public VideoCardService(DbContext context, IFuzzyService<int> fuzzyIntService, IFuzzyService<double> fuzzyDoubleService)
        {
            _context = context;
            _videoMemoryService = new NativeComponentIntParameterService<VCCapacityVideoMemoryEntity>(_context, fuzzyIntService);
            _monitorsService = new NativeComponentIntParameterService<VCCountMonitorsEntity>(_context, fuzzyIntService);
            _throughputService = new NativeComponentIntParameterService<VCThroughputCapacityEntity>(_context, fuzzyIntService);
            _frequencyService = new NativeComponentIntParameterService<VCMemoryFrequencyEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<VCPriceEntity>(_context, fuzzyDoubleService);
        }
    }
}
