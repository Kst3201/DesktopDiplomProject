using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Gateway
{
    public class GPCPreset
    {
        private const string CONTROLLERADDRESS = "api/PCPreset";
        private ICommController _controller;

        public GPCPreset(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<IEnumerable<NativePCPresetDTO>> GetPresets()
        {
            var result = await _controller.GetAsync<IEnumerable<NativePCPresetDTO>>(CONTROLLERADDRESS, false);
            return result?.ToList() ?? new List<NativePCPresetDTO>();
        }
    }
}
