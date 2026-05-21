using DesktopDiplomProject.Client.Features.Authentification.Models.Roles;
using DesktopDiplomProject.Client.Features.Authentification.Models.Roles.Competitions;
using DiplomDataLibrary.Authentification.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    public class UserModel
    {
        private const string UNKNOWNROLE = "НЕИЗВЕСТНАЯ РОЛЬ";
        private string _username;
        private IRoleModel _role;
        private ITokenModel _accessToken;
        private ITokenModel _refreshToken;

        public string UserName => _username;
        public IRoleModel Role => _role;
        public ITokenModel AccessToken
        {
            get => _accessToken;
            set => _accessToken = value;
        }

        public ITokenModel RefreshToken
        {
            get => _refreshToken;
            set => _refreshToken = value;
        }

        public UserModel(string username, ITokenModel accessToken, ITokenModel refreshToken)
        {
            _username = username;
            _role = InitPermissions(accessToken.Token);
            _accessToken = accessToken;
            _refreshToken = refreshToken;
        }

        private IRoleModel InitPermissions(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            if (token == null) throw new ArgumentNullException(nameof(token));
            var roleName = token.Claims.FirstOrDefault(item => item.Type.Equals(ClaimTypes.Role))?.Value ?? UNKNOWNROLE;
            var permissionsSerial = token.Claims.FirstOrDefault(item => item.Type.Equals("Permissions"))?.Value;
            List<PermissionDTO> permissionsDTO = permissionsSerial == null ? new List<PermissionDTO>() :
                JsonSerializer.Deserialize<IList<PermissionDTO>>(permissionsSerial)?.ToList() ?? new List<PermissionDTO>();
            List<IPermissionModel> permissions = new List<IPermissionModel>();
            foreach (var item in permissionsDTO)
            {
                permissions.Add(new PermissionModel(item.Domain, item.Permissions));
            }
            return new RoleModel(roleName, permissions);

        }
    }
}
