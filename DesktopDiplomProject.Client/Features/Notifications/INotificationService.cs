using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Notifications
{
    public interface INotificationService
    {
        void SendMessage(string message);
        void SendWarning(string message);
        void SendError(string message);
    }
}
