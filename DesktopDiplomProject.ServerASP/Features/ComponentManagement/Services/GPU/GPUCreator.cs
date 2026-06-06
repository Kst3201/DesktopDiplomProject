using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU
{
    public class GPUCreator
    {
        private const double BASEFREQUENCYCOEFF = 0.65;
        private const double COUNTUNIVERSALPROCESSORSCOEFF = 0.95;
        private const double COUNTTEXTURERBLOCKSCOEFF = 0.7;
        private const double COUNTRASTERIZATIONCOEFF = 0.75;
        private const double COUNTRTCORESCOEFF = 0.55;
        private const double COUNTTENSORCORESCOEFF = 0.45;
        private IDefuzzifyFunction _function;

        public GPUCreator(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public GPUDTO CreateDTO(GPUEntity entity)
        {
            IScore score = GetTotalScore(entity);
            return new GPUDTO(entity.Name, entity.Manufacturer, entity.Model, _function.Defuzzify(score))
            {
                BaseFrequency = entity.BaseFrequency.Value,
                CountUniversalProcessors = entity.CountUniversalProcessors.Value,
                CountTexturerBlocks = entity.CountTexturerBlocks.Value,
                CountRasterizationBlocks = entity.CountRasterizationBlocks.Value,
                CountRTCores = entity.CountRTCores.Value,
                CountTensorCores = entity.CountTensorCores.Value
            };
        }

        public GPUDTO CreateDTO(GPUModel model)
        {
            return new GPUDTO(model.Name, model.Manufacturer, model.Model, _function.Defuzzify(model.TotalScore))
            {
                BaseFrequency = model.BaseFrequency,
                CountUniversalProcessors = model.CountUniversalProcessors,
                CountTexturerBlocks = model.CountTexturerBlocks,
                CountRasterizationBlocks = model.CountRasterizationBlocks,
                CountRTCores = model.CountRTCores,
                CountTensorCores = model.CountTensorCores
            };
        }

        public GPUModel CreateModel(GPUEntity entity)
        {
            IScore score = GetTotalScore(entity);
            return new GPUModel()
            {
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Model = entity.Model,
                BaseFrequency = entity.BaseFrequency.Value,
                CountUniversalProcessors = entity.CountUniversalProcessors.Value,
                CountTexturerBlocks = entity.CountTexturerBlocks.Value,
                CountRasterizationBlocks = entity.CountRasterizationBlocks.Value,
                CountRTCores = entity.CountRTCores.Value,
                CountTensorCores = entity.CountTensorCores.Value,
                TotalScore = score
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

        private IScore GetTotalScore(GPUEntity entity)
        {
            ScoreCoefficiented frequencyScore = new ScoreCoefficiented(GetScore(entity.BaseFrequency), BASEFREQUENCYCOEFF);
            ScoreCoefficiented countUScore = new ScoreCoefficiented(GetScore(entity.CountUniversalProcessors), COUNTUNIVERSALPROCESSORSCOEFF);
            ScoreCoefficiented countTBScore = new ScoreCoefficiented(GetScore(entity.CountTexturerBlocks), COUNTTEXTURERBLOCKSCOEFF);
            ScoreCoefficiented countRBScore = new ScoreCoefficiented(GetScore(entity.CountRasterizationBlocks), COUNTRASTERIZATIONCOEFF);
            ScoreCoefficiented countRTScore = new ScoreCoefficiented(GetScore(entity.CountRTCores), COUNTRTCORESCOEFF);
            ScoreCoefficiented countTCScore = new ScoreCoefficiented(GetScore(entity.CountTensorCores), COUNTTENSORCORESCOEFF);
            return ReassessmentService.Commulate(frequencyScore, countUScore
                , countTBScore, countRBScore, countRTScore, countTCScore);
        }
    }
}
