using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using Microsoft.EntityFrameworkCore;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double
{
    public class NativeComponentDoubleParameterService<TEntity> : IComponentDoubleParameterService<TEntity> where TEntity : DoubleValueScoredEntity
    {
        private UpgradePCApplicationContext _context;
        private DbSet<TEntity> _set;
        private IFuzzyService<double> _fuzzyService;

        public async Task<TEntity> Add(TEntity value)
        {
            var score = new ScoredEntity();
            value.SetScore(score);
            _set.Add(value);
            await _context.SaveChangesAsync();
            await Reassessment(value);
            return value;
        }

        public async Task<double?> GetMax()
        {
            return await _set.Select(c => c.Value).DefaultIfEmpty().MaxAsync();
        }

        public async Task<double?> GetMin()
        {
            return await _set.Select(c => c.Value).DefaultIfEmpty().MinAsync();
        }

        public async Task<TEntity> GetOrAdd(TEntity value)
        {
            var founded = await _set.FirstOrDefaultAsync(item => item.Value.Equals(value.Value));
            if (founded != null) return founded;
            return await Add(value);
        }

        public async Task Reassessment(TEntity value)
        {
            if (value == null) return;
            double max = await GetMax() ?? value.Value;
            double min = await GetMin() ?? value.Value;
            _fuzzyService.SetMaxMin(max, min);
            foreach (var item in _set)
            {
                item.SetScore(_fuzzyService.Fuzzify(item.Value));
            }
            await _context.SaveChangesAsync();
        }

        public NativeComponentDoubleParameterService(UpgradePCApplicationContext context, IFuzzyService<double> fuzzyService)
        {
            _context = context;
            _set = context.Set<TEntity>();
            _fuzzyService = fuzzyService;
        }
    }
}
