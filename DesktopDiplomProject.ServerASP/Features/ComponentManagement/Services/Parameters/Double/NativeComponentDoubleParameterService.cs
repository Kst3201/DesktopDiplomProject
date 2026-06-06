using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using Microsoft.EntityFrameworkCore;

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
            await Reassessment(value);
            return nwValue;
        }

        public async Task<double?> GetMax()
        {
            return await _set.Select(c => c.Value).DefaultIfEmpty().MaxAsync();
        }

        public async Task<double?> GetMin()
        {
            return await _set.Select(c => c.Value).DefaultIfEmpty().MinAsync();
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
