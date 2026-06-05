using DesktopDiplomProject.Server.Data.Configuration;
using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.NamedUnits;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Double;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Parameters.Int;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU
{
    public class CPUService : IComponentService<CPUDTO>
    {
        private const double COEFFFREQUENCY = 0.8;
        private const double COEFFCOUNTCORES = 0.7;
        private const double COEFFTHREADSCOUNT = 0.6;
        private const double COEFFRAMTYPE = 0.5;
        private const double COEFFPRICE = 0.5;

        private UpgradePCApplicationContext _context;
        private IComponentIntParameterService<CPUBaseFrequencyEntity> _frequencyService;
        private IComponentIntParameterService<CPUCoreCountEntity> _coreCountiesService;
        private IComponentIntParameterService<CPUThreadsCountEntity> _threadsCountiesService;
        private IComponentDoubleParameterService<CPUPriceEntity> _priceService;
        private NativeComponentNamedUnitService<CPUSocketEntity> _socketService;
        private IDefuzzifyFunction _defuzzifyFunction;

        public async Task<CPUDTO> AddItem(CPUDTO item)
        {
            try
            {
                var foundedItem = await _context.CPUs
                    .Include(item => item.Socket)
                    .Include(item => item.CountCores)
                    .Include(item => item.CountThreads)
                    .Include(item => item.BaseFrequency)
                    .Include(item => item.RAMType)
                    .Include(item => item.Price)
                    .FirstOrDefaultAsync(item =>
                    item.Name == item.Name &&
                    item.Manufacturer == item.Manufacturer &&
                    item.Model == item.Model);
                if (foundedItem != null) throw new ArgumentException($"Процессор с названием {item.Name} уже существует");
                var socket = await _socketService.GetOrAddByName(item.Socket);
                var countCores = await _coreCountiesService.GetOrAdd(GetCoreCount(item.CountCores));
                var countThreads = await _threadsCountiesService.GetOrAdd(GetThreadsCount(item.CountThreads));
                var baseFrequency = await _frequencyService.GetOrAdd(GetFrequency(item.BaseFrequency));
                var price = await _priceService.GetOrAdd(GetPrice(item.Price));
                var ramType = await _context.RAMTypes.FirstOrDefaultAsync(ramType => ramType.Name.Equals(item.RAMType));
                if (ramType == null) throw new ArgumentException($"Тип оперативной памяти не был найден");
                CPUEntity newValue = new CPUEntity()
                {
                    Name = item.Name,
                    Manufacturer = item.Manufacturer,
                    Model = item.Model,
                    SocketID = socket.ID,
                    CountCoresID = countCores.ID,
                    CountThreadsID = countThreads.ID,
                    BaseFrequencyID = baseFrequency.ID,
                    PriceID = price.ID,
                    RAMTypeID = ramType.ID
                };
                await _context.CPUs.AddAsync(newValue);
                await _context.SaveChangesAsync();
                return await GetItem(newValue.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public async Task<CPUDTO> GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CPUDTO> GetItem(int id)
        {
            var item = await _context.CPUs
                .Include(item => item.Socket)
                .Include(item => item.CountCores)
                .Include(item => item.CountThreads)
                .Include(item => item.BaseFrequency)
                .Include(item => item.RAMType)
                .Include(item => item.Price)
                .FirstOrDefaultAsync(c => c.ID == id);
            if (item == null)
                throw new Exception($"Процессор не был найден");
            ScoreCoefficiented countCoresScore = new ScoreCoefficiented(GetScore(item.CountCores), COEFFCOUNTCORES);
            ScoreCoefficiented countThreadsScore = new ScoreCoefficiented(GetScore(item.CountThreads), COEFFTHREADSCOUNT);
            ScoreCoefficiented frequencyScore = new ScoreCoefficiented(GetScore(item.BaseFrequency), COEFFFREQUENCY);
            ScoreCoefficiented ramTypeScore = new ScoreCoefficiented(GetScore(item.RAMType), COEFFRAMTYPE);
            Score totalScore = ReassessmentService.Commulate(countCoresScore, countThreadsScore, frequencyScore, ramTypeScore);
            return new CPUDTO(item.Name, item.Manufacturer, item.Model, item.Price.Value,
                _defuzzifyFunction.Defuzzify(totalScore), item.Socket.Name, item.RAMType.Name);
        }

        public async Task<IEnumerable<CPUDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveItem(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CPUDTO> UpdateItem(CPUDTO item)
        {
            throw new NotImplementedException();
        }

        private CPUBaseFrequencyEntity GetFrequency(int value)
        {
            return new CPUBaseFrequencyEntity()
            {
                Value = value
            };
        }

        private CPUCoreCountEntity GetCoreCount(int value)
        {
            return new CPUCoreCountEntity()
            {
                Value = value
            };
        }

        private CPUThreadsCountEntity GetThreadsCount(int value)
        {
            return new CPUThreadsCountEntity()
            {
                Value = value
            };
        }

        private CPUPriceEntity GetPrice(double value)
        {
            return new CPUPriceEntity()
            {
                Value = value
            };
        }

        private Score GetScore<T>(T entity) where T : ScoredEntity
        {
            return new Score()
            {
                ScoreOne = entity.ScoreOne,
                ScoreTwo = entity.ScoreTwo,
                ScoreThree = entity.ScoreThree,
                ScoreFour = entity.ScoreFour,
                ScoreFive = entity.ScoreFive
            };
        }

        public CPUService(UpgradePCApplicationContext context, IFuzzyService<int> fuzzyIntService, IFuzzyService<double> fuzzyDoubleService, IDefuzzifyFunction defFunction)
        {
            _context = context;
            _frequencyService = new NativeComponentIntParameterService<CPUBaseFrequencyEntity>(_context, fuzzyIntService);
            _coreCountiesService = new NativeComponentIntParameterService<CPUCoreCountEntity>(_context, fuzzyIntService);
            _threadsCountiesService = new NativeComponentIntParameterService<CPUThreadsCountEntity>(_context, fuzzyIntService);
            _priceService = new NativeComponentDoubleParameterService<CPUPriceEntity>(_context, fuzzyDoubleService);
            _defuzzifyFunction = defFunction;
        }
    }
}
