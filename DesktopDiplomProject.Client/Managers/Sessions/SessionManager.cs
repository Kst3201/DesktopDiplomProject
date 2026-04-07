using DesktopDiplomProject.Client.Features.Authentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Managers.Sessions;

public class SessionManager : ISessionManager
{
    private UserModel? _user;

    public UserModel? User => _user;

    public bool IsLogged => _user != null;

    public SessionManager()
    {
    }

    public void Login(UserModel user)
    {
        _user = user;
    }

    public void Logout() => _user = null;
}