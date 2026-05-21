using DesktopDiplomProject.Client.Features.Authentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Managers.Sessions
{
    public class UserChangedArgs : EventArgs
    {
        public UserModel? OldUser { get; }
        public UserModel? NewUser { get; }

        public UserChangedArgs(UserModel? oldUser, UserModel? newUser)
        {
            OldUser = oldUser;
            NewUser = newUser;
        }
    }
}
