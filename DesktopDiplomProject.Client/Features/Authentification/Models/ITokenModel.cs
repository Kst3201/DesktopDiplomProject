using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.Authentification.Models
{
    public interface ITokenModel
    {
        string Token { get; }
        DateTime ExpiresAt { get; }
    }
}
