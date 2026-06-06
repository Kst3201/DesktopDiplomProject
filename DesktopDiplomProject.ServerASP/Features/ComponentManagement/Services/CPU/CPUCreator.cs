using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU
{
    public class CPUCreator
    {
        private IDefuzzifyFunction _function;
        private const double COEFFFREQUENCY = 0.8;
        private const double COEFFCOUNTCORES = 0.7;
        private const double COEFFTHREADSCOUNT = 0.6;
        private const double COEFFRAMTYPE = 0.5;
        private const double COEFFPRICE = 0.5;

        public CPUCreator(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public CPUDTO CreateDTO(CPUEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new CPUDTO(entity.Name, entity.Manufacturer, entity.Model, entity.Price.Value,
                _function.Defuzzify(totalScore), entity.Socket.Name, entity.RAMType.Name)
            {
                CountCores = entity.CountCores.Value,
                CountThreads = entity.CountThreads.Value,
                BaseFrequency = entity.BaseFrequency.Value
            };
        }

        public CPUDTO CreateDTO(CPUModel model)
        {
            return new CPUDTO(model.Name, model.Manufacturer, model.Model, model.Price,
                _function.Defuzzify(model.TotalScore), model.Socket, model.RAMType)
            {
                CountCores = model.CountCores,
                CountThreads = model.CountThreads, 
                BaseFrequency = model.BaseFrequency
            };
        }

        public CPUModel CreateModel(CPUEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new CPUModel()
            {
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Model = entity.Model,
                Socket = entity.Socket.Name,
                CountCores = entity.CountCores.Value,
                CountThreads = entity.CountThreads.Value,
                BaseFrequency = entity.BaseFrequency.Value,
                RAMType = entity.RAMType.Name,
                Price = entity.Price.Value,
                TotalScore = totalScore
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

        private IScore GetTotalScore(CPUEntity entity)
        {
            ScoreCoefficiented countCoresScore = new ScoreCoefficiented(GetScore(entity.CountCores), COEFFCOUNTCORES);
            ScoreCoefficiented countThreadsScore = new ScoreCoefficiented(GetScore(entity.CountThreads), COEFFTHREADSCOUNT);
            ScoreCoefficiented frequencyScore = new ScoreCoefficiented(GetScore(entity.BaseFrequency), COEFFFREQUENCY);
            ScoreCoefficiented ramTypeScore = new ScoreCoefficiented(GetScore(entity.RAMType), COEFFRAMTYPE);
            return ReassessmentService.Commulate(countCoresScore, countThreadsScore
                , frequencyScore, ramTypeScore);
        }
    }
}
