using DiplomDataLibrary.Authentification.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.Permissions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RequirePermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _domain;
        private readonly IEnumerable<PermissionAction> _permissions;

        public RequirePermissionAttribute(string domain, params PermissionAction[] permissions)
        {
            _domain = domain;
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!(user?.Identity?.IsAuthenticated ?? false))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            string permissionsStr = user.Claims.FirstOrDefault(item => item.Type.Equals("Permissions"))?.Value ?? "";
            if (string.IsNullOrEmpty(permissionsStr))
            {
                context.Result = new ForbidResult();
                return;
            }
            List<PermissionDTO> permissionsDTO = 
                JsonSerializer.Deserialize<IList<PermissionDTO>>(permissionsStr)?.ToList() ?? new List<PermissionDTO>();
            Permission? permission = permissionsDTO.Where(item => item.Domain.Equals(_domain))
                .Select(item => new Permission(item.Domain, item.Permissions)).First();
            if (permission == null)
            {
                context.Result = new ForbidResult();
                return;
            }
            IList<PermissionAction> actions = permission.GetPermissions().ToList();
            var hasPermission = _permissions.Any(perm => actions.Any(act => act.Equals(perm)));
            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
