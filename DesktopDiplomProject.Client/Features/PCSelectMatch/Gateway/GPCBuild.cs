using DesktopDiplomProject.Client.Controllers;
using DiplomDataLibrary.PCBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Gateway
{
    public class GPCBuild
    {
        private const string CONTROLLERBUILDADDRESS = "api/PCBuild/build";
        private const string CONTROLLERUPGRADEADDRESS = "api/PCBuild/upgrade";
        private ICommController _controller;

        public GPCBuild(ICommController controller)
        {
            _controller = controller;
        }

        public async Task<IEnumerable<PCDTO>> BuildPCs(PCBuildRequest request)
        {
            var result = await _controller.PostAsync<PCBuildRequest, IEnumerable<PCDTO>>(CONTROLLERBUILDADDRESS, request);
            return result?.ToList() ?? new List<PCDTO>();
        }

        public async Task<IEnumerable<PCDTO>> UpgradePCs(PCUpgradeRequest request)
        {
            var result = await _controller.PostAsync<PCUpgradeRequest, IEnumerable<PCDTO>>(CONTROLLERUPGRADEADDRESS, request);
            return result?.ToList() ?? new List<PCDTO>();
        }
    }
}
