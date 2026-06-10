using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer;
using DiplomDataLibrary.PCBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public interface IPCCreator
    {
        IPCModel? Create(PCDTO? dto);
        IPCModel? Create(IPCViewModel? viewModel);
        IPCViewModel? Create(IPCModel? model);
    }
}
