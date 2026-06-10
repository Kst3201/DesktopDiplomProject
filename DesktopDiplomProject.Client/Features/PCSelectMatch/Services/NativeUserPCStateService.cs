using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public class NativeUserPCStateService : IUserPCStateService
    {
        private IPCModel? _userPC;

        public IPCModel? UserPC 
        { 
            get => _userPC;
            set
            {
                _userPC = value;
                OnUserPCChanged(_userPC);
            }
        }

        public event EventHandler<IPCModel?>? UserPCChanged;

        public void UpdatePCIE(string pcie)
        {
            if (UserPC != null)
            {
                UserPC.Motherboard.PCIEInterface = pcie;
                UserPC.VideoCard.PCIEInterface = pcie;
            }
        }

        private void OnUserPCChanged(IPCModel? model)
        {
            UserPCChanged?.Invoke(this, model);
        }
    }
}
