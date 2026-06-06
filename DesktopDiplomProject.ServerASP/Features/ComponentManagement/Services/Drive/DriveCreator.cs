using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive
{
    public class DriveCreator
    {
        private const double CAPACITYSCORECOEFF = 0.8;
        private const double SPEEDDATATRANSFERCOEFF = 0.5;
        private const double PRICECOEFF = 0.5;
        private IDefuzzifyFunction _function;

        public DriveCreator(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public DriveDTO CreateDTO(DriveEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new DriveDTO(entity.Name, entity.Manufacturer, entity.Model, entity.Price.Value
                , _function.Defuzzify(totalScore), entity.ConnectorInterface.Name)
            {
                Capacity = entity.Capacity.Value,
                SpeedDataTransfer = entity.SpeedDataTransfer.Value
            };
        }

        public DriveDTO CreateDTO(DriveModel model)
        {
            return new DriveDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.ConnectorInterface)
            {
                Capacity = model.Capacity,
                SpeedDataTransfer = model.SpeedDataTransfer
            };
        }

        public DriveModel CreateModel(DriveEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new DriveModel()
            {
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Model = entity.Model,
                Capacity = entity.Capacity.Value,
                SpeedDataTransfer = entity.SpeedDataTransfer.Value,
                ConnectorInterface = entity.ConnectorInterface.Name,
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

        private IScore GetTotalScore(DriveEntity entity)
        {
            ScoreCoefficiented capacityScore = new ScoreCoefficiented(GetScore(entity.Capacity), CAPACITYSCORECOEFF);
            ScoreCoefficiented speedScore = new ScoreCoefficiented(GetScore(entity.SpeedDataTransfer), SPEEDDATATRANSFERCOEFF);
            return ReassessmentService.Commulate(capacityScore, speedScore);
        }
    }
}
