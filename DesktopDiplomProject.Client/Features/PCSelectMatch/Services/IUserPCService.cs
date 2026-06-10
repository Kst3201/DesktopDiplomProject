using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public interface IUserPCService
    {
        Task<IPCModel> GetUserPC();
    }
}
