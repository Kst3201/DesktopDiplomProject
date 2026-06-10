using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int
{
    public class NativeComponentIntParameterService<TEntity> : IComponentIntParameterService<TEntity>
        where TEntity : IntValueScoredEntity, new()
    {
        private UpgradePCApplicationContext _context;
        private DbSet<TEntity> _set;
        private IFuzzyService<int> _fuzzyService;

        public async Task<TEntity> Add(int value)
        {
            var score = new ScoredEntity();
            var nwValue = new TEntity()
            {
                Value = value,
            };
            nwValue.SetScore(score);
            _set.Add(nwValue);
            await _context.SaveChangesAsync();
            _set = _context.Set<TEntity>();
            await Reassessment(value);
            return nwValue;
        }

        public async Task<int?> GetMax()
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
            return Convert.ToInt32(result);
            //return await _set.Select(c => c.Value).DefaultIfEmpty().MaxAsync();
        }

        public async Task<int?> GetMin()
        {
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM public.get_quantile(@table, @column, @percentile)";
            cmd.Parameters.Add(new NpgsqlParameter("table", "CPUPrices"));
            cmd.Parameters.Add(new NpgsqlParameter("column", "Value"));
            cmd.Parameters.Add(new NpgsqlParameter<double>("percentile", 0.15));
            var result = await cmd.ExecuteScalarAsync();
            await conn.CloseAsync();
            return Convert.ToInt32(result);
            //return await _set.Select(c => c.Value).DefaultIfEmpty().MinAsync();
        }

        public async Task<TEntity> GetOrAdd(int value)
        {
            var founded = await _set.FirstOrDefaultAsync(item => item.Value.Equals(value));
            if (founded != null) return founded;
            return await Add(value);
        }

        public async Task Reassessment(int value)
        {
            int max = await GetMax() ?? value;
            int min = await GetMin() ?? value;
            _fuzzyService.SetMaxMin(max, min);
            foreach (var item in _set)
            {
                item.SetScore(_fuzzyService.Fuzzify(item.Value));
            }
            await _context.SaveChangesAsync();
            _set = _context.Set<TEntity>();
        }

        public NativeComponentIntParameterService(UpgradePCApplicationContext context, IFuzzyService<int> fuzzyService)
        {
            _context = context;
            _set = context.Set<TEntity>();
            _fuzzyService = fuzzyService;
        }
    }
}
