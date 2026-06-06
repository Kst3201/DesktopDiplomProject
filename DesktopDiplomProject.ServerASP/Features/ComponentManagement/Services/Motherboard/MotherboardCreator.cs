using DesktopDiplomProject.Server.Models.Entities;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard
{
    public class MotherboardCreator
    {
        private const double RAMTYPECOEFF = 0.5;
        private const double RAMCOUNTSLOTSCOEFF = 0.7;
        private const double RAMMAXVALUECOEFF = 0.6;
        private const double RAMMAXFREQUENCYCOEFF = 0.6;
        private const double COUNTPCIEX16SLOTSCOEFF = 0.3;
        private const double COUNTM2SLOTSCOEFF = 0.3;
        private const double COUNTSATASLOTSCOEFF = 0.2;
        private const double PRICECOEFF = 0.5;
        private IDefuzzifyFunction _function;

        public MotherboardCreator(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public MotherboardDTO CreateDTO(MotherboardEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new MotherboardDTO(entity.Name, entity.Manufacturer, entity.Model
                , entity.Price.Value, _function.Defuzzify(totalScore), entity.Size.Name
                , entity.Socket.Name, entity.RAMType.Name, entity.PCIEInterface.Name)
            {
                RAMCountSlots = entity.RAMCountSlots.Value,
                MaxRAMValue = entity.MaxRAMValue.Value,
                MaxRAMFrequency = entity.MaxRAMFrequency.Value,
                CountPCIEX16Slots = entity.CountPCIEX16Slots.Value,
                CountM2Slots = entity.CountM2Slots.Value,
                CountSATASlots = entity.CountSATASlots.Value
            };
        }

        public MotherboardDTO CreateDTO(MotherboardModel model)
        {
            return new MotherboardDTO(model.Name, model.Manufacturer, model.Model
                , model.Price, _function.Defuzzify(model.TotalScore), model.Size
                , model.Socket, model.RAMType, model.PCIEInterface)
            {
                RAMCountSlots = model.RAMCountSlots,
                MaxRAMValue = model.MaxRAMValue,
                MaxRAMFrequency = model.MaxRAMFrequency,
                CountPCIEX16Slots = model.CountPCIEX16Slots,
                CountM2Slots = model.CountM2Slots,
                CountSATASlots = model.CountSATASlots
            };
        }

        public MotherboardModel CreateModel(MotherboardEntity entity)
        {
            IScore totalScore = GetTotalScore(entity);
            return new MotherboardModel()
            {
                Name = entity.Name,
                Manufacturer = entity.Manufacturer,
                Model = entity.Model,
                Size = entity.Size.Name,
                Socket = entity.Socket.Name,
                RAMType = entity.RAMType.Name,
                PCIEInterface = entity.PCIEInterface.Name,
                RAMCountSlots = entity.RAMCountSlots.Value,
                MaxRAMValue = entity.MaxRAMValue.Value,
                MaxRAMFrequency = entity.MaxRAMFrequency.Value,
                CountPCIEX16Slots = entity.CountPCIEX16Slots.Value,
                CountM2Slots = entity.CountM2Slots.Value,
                CountSATASlots = entity.CountSATASlots.Value,
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

        private IScore GetTotalScore(MotherboardEntity entity)
        {
            ScoreCoefficiented ramTypeScore = new ScoreCoefficiented(GetScore(entity.RAMType), RAMTYPECOEFF);
            ScoreCoefficiented ramSlotsScore = new ScoreCoefficiented(GetScore(entity.RAMCountSlots), RAMCOUNTSLOTSCOEFF);
            ScoreCoefficiented ramValueScore = new ScoreCoefficiented(GetScore(entity.MaxRAMValue), RAMMAXVALUECOEFF);
            ScoreCoefficiented ramFrequencyScore = new ScoreCoefficiented(GetScore(entity.MaxRAMFrequency), RAMMAXFREQUENCYCOEFF);
            ScoreCoefficiented countPCIEX16Score = new ScoreCoefficiented(GetScore(entity.CountPCIEX16Slots), COUNTPCIEX16SLOTSCOEFF);
            ScoreCoefficiented countM2Score = new ScoreCoefficiented(GetScore(entity.CountM2Slots), COUNTM2SLOTSCOEFF);
            ScoreCoefficiented countSATAScore = new ScoreCoefficiented(GetScore(entity.CountSATASlots), COUNTSATASLOTSCOEFF);
            return ReassessmentService.Commulate(ramTypeScore, ramSlotsScore, ramValueScore, ramFrequencyScore
                , countPCIEX16Score, countM2Score, countSATAScore);
        }
    }
}
