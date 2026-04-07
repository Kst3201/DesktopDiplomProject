using DesktopDiplomProject.Client.Features.Authentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Managers.Sessions
{
    public interface ISessionManager
    {
        UserModel? User { get; }

        bool IsLogged { get; }

        void Login(UserModel user);
        void Logout();
    }
}
