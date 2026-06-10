using DesktopDiplomProject.Server.Data.Configuration;
using DiplomDataLibrary.PCBuild;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Services
{
    public class PCPresetService
    {
        private UpgradePCApplicationContext _context;

        public PCPresetService(UpgradePCApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NativePCPresetDTO>> GetItems()
        {
            try
            {
                var list = await _context.PCPresets.ToListAsync();
                return list.Select(item => new NativePCPresetDTO()
                {
                    Name = item.Name,
                    CPUCoeff = item.CPUCoeff,
                    DriveCoeff = item.DriveCoeff,
                    MotherboardCoeff = item.MotherboardCoeff,
                    RAMCoeff = item.RAMCoeff,
                    VideoCardCoeff = item.VideoCardCoeff
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
