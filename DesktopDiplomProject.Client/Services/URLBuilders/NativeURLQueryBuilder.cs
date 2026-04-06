using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Services.URLBuilders
{
    internal class NativeURLQueryBuilder : IURLQueryBuilder
    {
        public string Build(string url, object? queryParams)
        {
            if (queryParams == null) return url;

            var properties = queryParams.GetType().GetProperties();
            var query = string.Join("&", properties
                .Where(p => p.GetValue(queryParams) != null)
                .Select(p => $"{p.Name}={Uri.EscapeDataString(p.GetValue(queryParams)?.ToString() ?? string.Empty)}"));

            return string.IsNullOrWhiteSpace(query) ? url : $"{url}?{query}";
        }
    }
}
