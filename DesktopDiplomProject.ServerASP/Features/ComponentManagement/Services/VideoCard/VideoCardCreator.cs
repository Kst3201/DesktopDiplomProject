using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard
{
    public class VideoCardCreator
    {
        private const double GPUCOEFF = 0.95;
        private const double CAPACITYVIDEOMEMORYCOEFF = 0.85;
        private const double MAXTHROUGHPUTCAPACITYCOEFF = 0.8;
        private const double MEMORYFREQUENCYCOEFF = 0.7;
        private const double COUNTMONITORSCOEFF = 0.3;
        private const double PRICECOEFF = 0.5;
        private IDefuzzifyFunction _function;
        private GPUCreator _gpuCreator;

        public VideoCardCreator(IDefuzzifyFunction function)
        {
            _function = function;
            _gpuCreator = new GPUCreator(_function);
        }

        public VideoCardDTO CreateDTO(VideoCardEntity entity)
        {
            IScore score = GetTotalScore(entity);
            return new VideoCardDTO(entity.Name, entity.Manufacturer, entity.Model
                , entity.Price.Value, _function.Defuzzify(score), entity.GPU.Name, entity.PCIEInterface.Name)
            {
                CountPCIELines = entity.CountPCIELines,
                RecommendedBlockPower = entity.RecommendedBlockPower,
                CountPinsAdditionalPower = entity.CountPinsAdditionalPower,
                CapacityVideoMemory = entity.CapacityVideoMemory.Value,
                MaxThroughputCapacity = entity.MaxThroughputCapacity.Value,
                MemoryFrequency = entity.MemoryFrequency.Value,
                CountMonitors = entity.CountMonitors.Value
            };
        }

        public VideoCardDTO CreateDTO(VideoCardModel model)
        {
            return new VideoCardDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.GPU, model.PCIEInterface)
            {
                CountPCIELines = model.CountPCIELines,
                RecommendedBlockPower = model.RecommendedBlockPower,
                CountPinsAdditionalPower = model.CountPinsAdditionalPower,
                CapacityVideoMemory = model.CapacityVideoMemory,
                MaxThroughputCapacity = model.MaxThroughputCapacity,
                MemoryFrequency = model.MemoryFrequency,
                CountMonitors = model.CountMonitors
            };
        }

        public VideoCardModel CreateModel(VideoCardEntity entity)
        {
            IScore score = GetTotalScore(entity);
            return new VideoCardModel()
            {
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Model = entity.Model,
                GPU = entity.GPU.Name,
                PCIEInterface = entity.PCIEInterface.Name,
                CountPCIELines = entity.CountPCIELines,
                RecommendedBlockPower = entity.RecommendedBlockPower,
                CountPinsAdditionalPower = entity.CountPinsAdditionalPower,
                CapacityVideoMemory = entity.CapacityVideoMemory.Value,
                MaxThroughputCapacity = entity.MaxThroughputCapacity.Value,
                MemoryFrequency = entity.MemoryFrequency.Value,
                CountMonitors = entity.CountMonitors.Value,
                Price = entity.Price.Value,
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

        private IScore GetTotalScore(VideoCardEntity entity)
        {
            GPUModel gpu = _gpuCreator.CreateModel(entity.GPU);
            ScoreCoefficiented gpuScore = new ScoreCoefficiented(gpu.TotalScore, GPUCOEFF);
            ScoreCoefficiented capacityVMScore = new ScoreCoefficiented(GetScore(entity.CapacityVideoMemory), CAPACITYVIDEOMEMORYCOEFF);
            ScoreCoefficiented capacityTScore = new ScoreCoefficiented(GetScore(entity.MaxThroughputCapacity), MAXTHROUGHPUTCAPACITYCOEFF);
            ScoreCoefficiented frequencyScore = new ScoreCoefficiented(GetScore(entity.MemoryFrequency), MEMORYFREQUENCYCOEFF);
            ScoreCoefficiented monitorsScore = new ScoreCoefficiented(GetScore(entity.CountMonitors), COUNTMONITORSCOEFF);
            return ReassessmentService.Commulate(gpuScore, capacityVMScore, capacityTScore
                , frequencyScore, monitorsScore);
        }
    }
}
