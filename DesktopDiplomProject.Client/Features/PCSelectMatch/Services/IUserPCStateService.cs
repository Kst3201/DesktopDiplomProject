using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public interface IUserPCStateService
    {
        IPCModel? UserPC { get; set; }
        event EventHandler<IPCModel?>? UserPCChanged;
        void UpdatePCIE(string pcie);
    }
}
