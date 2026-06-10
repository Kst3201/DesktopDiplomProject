using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public class NativePCSelectConfigurationStateService : IPCSelectConfigurateStateService
    {
        private PCSelectConfigurationSet? _set;

        public NativePCSelectConfigurationStateService() { }

        public void Clear()
        {
            _set = null;
        }

        public PCSelectConfigurationSet? GetConfiguration()
        {
            return _set;
        }

        public void SetConfiguration(PCSelectConfigurationSet set)
        {
            _set = set;
        }
    }
}
