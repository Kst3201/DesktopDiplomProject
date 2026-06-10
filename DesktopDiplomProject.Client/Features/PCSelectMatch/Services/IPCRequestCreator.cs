using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DiplomDataLibrary.PCBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public interface IPCRequestCreator
    {
        PCBuildRequest CreateBuildRequest(PCSelectConfigurationSet set);
        PCUpgradeRequest CreateUpgradeRequest(PCSelectConfigurationSet set);
    }
}
