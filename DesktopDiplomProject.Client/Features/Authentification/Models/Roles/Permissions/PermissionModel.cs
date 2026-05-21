using DiplomDataLibrary.Authentification.DTO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models.Roles.Competitions
{
    public class PermissionModel : IPermissionModel
    {
        private BitVector32 _vector;

        public string Domain { get; }

        public bool CanRead => _vector[(int)PermissionAction.Read];
        public bool CanAdd => _vector[(int)PermissionAction.Add];
        public bool CanUpdate => _vector[(int)PermissionAction.Update];
        public bool CanRemove => _vector[(int)PermissionAction.Delete];

        public PermissionModel(string domain, int permissions)
        {
            Domain = domain;
            _vector = new BitVector32(permissions);
        }
    }
}
