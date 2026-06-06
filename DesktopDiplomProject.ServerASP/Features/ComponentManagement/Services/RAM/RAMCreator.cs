using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM
{
    public class RAMCreator
    {
        private const double RAMTYPECOEFF = 0.6;
        private const double SINGLEMODULECAPACITYCOEFF = 0.8;
        private const double COUNTMODULESCOEFF = 0.3;
        private const double FREQUENCYSCOEFF = 0.7;
        private const double PRICECOEFF = 0.5;
        private IDefuzzifyFunction _function;

        public RAMCreator(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public RAMDTO CreateDTO(RAMEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new RAMDTO(entity.Name, entity.Manufacturer, entity.Model, entity.Price.Value
                , _function.Defuzzify(totalScore), entity.RAMType.Name)
            {
                SingleModuleCapacity = entity.SingleModuleCapacity.Value,
                CountModules = entity.CountModules.Value,
                Frequency = entity.Frequency.Value
            };
        }

        public RAMDTO CreateDTO(RAMModel model)
        {
            return new RAMDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.RAMType)
            {
                SingleModuleCapacity = model.SingleModuleCapacity,
                CountModules = model.CountModules,
                Frequency = model.Frequency
            };
        }

        public RAMModel CreateModel(RAMEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new RAMModel()
            {
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Model = entity.Model,
                RAMType = entity.RAMType.Name,
                SingleModuleCapacity = entity.SingleModuleCapacity.Value,
                CountModules = entity.CountModules.Value,
                Frequency = entity.Frequency.Value,
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

        private IScore GetTotalScore(RAMEntity entity)
        {
            ScoreCoefficiented ramTypeScore = new ScoreCoefficiented(GetScore(entity.RAMType), RAMTYPECOEFF);
            ScoreCoefficiented capacityScore = new ScoreCoefficiented(GetScore(entity.SingleModuleCapacity), SINGLEMODULECAPACITYCOEFF);
            ScoreCoefficiented countScore = new ScoreCoefficiented(GetScore(entity.CountModules), COUNTMODULESCOEFF);
            ScoreCoefficiented frequencyScore = new ScoreCoefficiented(GetScore(entity.Frequency), FREQUENCYSCOEFF);
            return ReassessmentService.Commulate(ramTypeScore, capacityScore, countScore, frequencyScore);
        }
    }
}
