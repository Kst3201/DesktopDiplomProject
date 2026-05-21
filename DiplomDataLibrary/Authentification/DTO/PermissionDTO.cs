using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.Authentification.DTO
{
    public enum PermissionAction
    {
        Read = 1,
        Add = 2,
        Update = 4,
        Delete = 8,
    }

    public class PermissionDTO
    {
        public string Domain { get; set; }
        public int Permissions { get; set; }

        public PermissionDTO(string domain, int permissions)
        {
            Domain = domain;
            Permissions = permissions;
        }
    }
}
