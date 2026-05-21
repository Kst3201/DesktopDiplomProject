using DesktopDiplomProject.Client.Controllers;
using DesktopDiplomProject.Client.Features.Authentification.Gateways;
using DesktopDiplomProject.Client.Features.Authentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesktopDiplomProject.Client.Managers.Sessions.ISessionManager;

namespace DesktopDiplomProject.Client.Managers.Sessions;

public class SessionManager : ISessionManager, IDisposable
{
    private UserModel? _user;

    public event EventHandler<UserChangedArgs> UserChanged;

    public UserModel? User => _user;

    public bool IsLogged => _user != null;

    public SessionManager()
    {
        UserChanged = EmptyHandler;
    }

    public void Login(UserModel user)
    {
        UserModel? oldUser = _user;
        _user = user;
        UserChanged?.Invoke(this, new UserChangedArgs(oldUser, _user));
    }

    public async void Logout()
    {
        if (_user == null) throw new ArgumentNullException(nameof(_user));
        if (_user.AccessToken == null) throw new ArgumentNullException(nameof(_user.AccessToken));
        if (_user.RefreshToken == null) throw new ArgumentNullException(nameof(_user.RefreshToken));
        UserModel? oldUser = _user;
        _user = null;
        UserChanged?.Invoke(this, new UserChangedArgs(oldUser, _user));
        return;
    }

    public void Dispose()
    {
        UserChanged -= EmptyHandler;
    }

    private void EmptyHandler(object? sender, UserChangedArgs e) { }
}