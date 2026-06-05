using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive
{
    public class DriveService : IComponentService<DriveDTO>
    {
        private DbContext _context;
        private IComponentIntParameterService<DriveCapacityEntity> _capacityService;
        private IComponentIntParameterService<DriveSpeedDataTransferEntity> _sdtService;
        private IComponentDoubleParameterService<DrivePriceEntity> _priceService;

        public async Task<bool> AddItem(DriveDTO item)
        {
            throw new NotImplementedException();
        }

        public async Task<DriveDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<DriveDTO> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DriveDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItem(DriveDTO item)
        {
            throw new NotImplementedException();
        }

        public DriveService(DbContext context, IFuzzyService<int> fuzzyIntService, IFuzzyService<double> fuzzyDoubleService)
        {
            _context = context;
            _capacityService = new NativeComponentIntParameterService<DriveCapacityEntity>(_context, fuzzyIntService);
            _sdtService = new NativeComponentIntParameterService<DriveSpeedDataTransferEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<DrivePriceEntity>(_context, fuzzyDoubleService);
        }
    }
}
