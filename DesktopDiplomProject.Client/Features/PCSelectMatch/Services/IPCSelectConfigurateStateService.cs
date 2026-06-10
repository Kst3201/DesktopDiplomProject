using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public interface IPCSelectConfigurateStateService
    {
        void Clear();
        void SetConfiguration(PCSelectConfigurationSet set);
        PCSelectConfigurationSet? GetConfiguration();
    }
}
