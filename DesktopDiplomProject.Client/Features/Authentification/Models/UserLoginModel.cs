using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    internal class UserLoginModel
    {
        private string _username;
        private string _password;

        public string UserName
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public UserLoginModel(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
