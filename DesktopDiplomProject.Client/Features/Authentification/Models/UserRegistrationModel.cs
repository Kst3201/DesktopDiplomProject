using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    public class UserRegistrationModel : UserLoginModel
    {
        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public UserRegistrationModel(string username, string password, string email) : base(username, password)
        {
            _email = email;
        }
    }
}
