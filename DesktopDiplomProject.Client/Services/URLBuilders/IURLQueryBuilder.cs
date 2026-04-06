using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Services.URLBuilders
{
    internal interface IURLQueryBuilder
    {
        string Build(string url, object? queryParams);
    }
}
