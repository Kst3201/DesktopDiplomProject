using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double
{
    public class NativeComponentDoubleParameterService<TEntity> 
        : IComponentDoubleParameterService<TEntity> 
        where TEntity : DoubleValueScoredEntity, new()
    {
        private UpgradePCApplicationContext _context;
        private DbSet<TEntity> _set;
        private IFuzzyService<double> _fuzzyService;

        public async Task<TEntity> Add(double value)
        {
            var score = new ScoredEntity();
            var nwValue = new TEntity()
            {
                Value = value
            };
            nwValue.SetScore(score);
            _set.Add(nwValue);
            await _context.SaveChangesAsync();
            _set = _context.Set<TEntity>();
            await Reassessment(value);
            return nwValue;
        }

        public async Task<double?> GetMax()
        {
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM public.get_quantile(@table, @column, @percentile)";
            cmd.Parameters.Add(new NpgsqlParameter("table", "CPUPrices"));
            cmd.Parameters.Add(new NpgsqlParameter("column", "Value"));
            cmd.Parameters.Add(new NpgsqlParameter<double>("percentile", 0.75));
            var result = await cmd.ExecuteScalarAsync();
            await conn.CloseAsync();
            return Convert.ToDouble(result);
        }

        public async Task<double?> GetMin()
        {
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM public.get_quantile(@table, @column, @percentile)";
            cmd.Parameters.Add(new NpgsqlParameter("table", "CPUPrices"));
            cmd.Parameters.Add(new NpgsqlParameter("column", "Value"));
            cmd.Parameters.Add(new NpgsqlParameter<double>("percentile", 0.25));
            var result = await cmd.ExecuteScalarAsync();
            await conn.CloseAsync();
            return Convert.ToDouble(result);
        }

        public async Task<TEntity> GetOrAdd(double value)
        {
            var founded = await _set.FirstOrDefaultAsync(item => item.Value.Equals(value));
            if (founded != null) return founded;
            return await Add(value);
        }

        public async Task Reassessment(double value)
        {
            double max = await GetMax() ?? value;
            double min = await GetMin() ?? value;
            _fuzzyService.SetMaxMin(max, min);
            foreach (var item in _set)
            {
                item.SetScore(_fuzzyService.Fuzzify(item.Value, CriterialDirection.Descending));
            }
            await _context.SaveChangesAsync();
            _set = _context.Set<TEntity>();
        }

        public NativeComponentDoubleParameterService(UpgradePCApplicationContext context, IFuzzyService<double> fuzzyService)
        {
            _context = context;
            _set = context.Set<TEntity>();
            _fuzzyService = fuzzyService;
        }
    }
}
