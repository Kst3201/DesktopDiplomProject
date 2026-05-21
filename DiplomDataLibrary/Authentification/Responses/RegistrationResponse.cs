using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.Authentification.Responses
{
    public enum RegistrationStatus
    {
        OK = 0,
        UsernameIsUsed,
        EmailIsUsed,
        AnotherError
    }

    public class RegistrationResponse
    {
        public string Username { get; set; }
        public RegistrationStatus Status { get; set; }

        public RegistrationResponse(string username, RegistrationStatus status)
        {
            Username = username;
            Status = status;
        }
    }
}
