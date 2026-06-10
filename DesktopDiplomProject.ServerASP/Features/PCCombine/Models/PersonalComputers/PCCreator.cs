using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DiplomDataLibrary.PCBuild;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.PersonalComputers
{
    public class PCCreator
    {
        private IDefuzzifyFunction _function;

        public PCCreator(IDefuzzifyFunction function)
        {
            _function = function;
        }

        public PCDTO CreateDTO(IPCModel model)
        {
            var cpu = CreateCPUDTO(model.CPU);
            var drive = CreateDriveDTO(model.Drive);
            var mother = CreateMotherboardDTO(model.Motherboard);
            var ram = CreateRAM(model.RAM);
            var video = CreateVideoCard(model.VideoCard);
            return new PCDTO(cpu, drive, mother, ram, video, model.Price, _function.Defuzzify(model.TotalScore));
        }

        private CPUDTO CreateCPUDTO(CPUModel model)
        {
            return new CPUDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.Socket, model.RAMType)
            {
                CountCores = model.CountCores,
                CountThreads = model.CountThreads,
                BaseFrequency = model.BaseFrequency
            };
        }

        private DriveDTO CreateDriveDTO(DriveModel model)
        {
            return new DriveDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.ConnectorInterface)
            {
                Capacity = model.Capacity,
                SpeedDataTransfer = model.SpeedDataTransfer
            };
        }

        private MotherboardDTO CreateMotherboardDTO(MotherboardModel model)
        {
            return new MotherboardDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.Size, model.Socket, model.RAMType, model.PCIEInterface)
            {
                RAMCountSlots = model.RAMCountSlots,
                MaxRAMValue = model.MaxRAMValue,
                MaxRAMFrequency = model.MaxRAMFrequency,
                CountPCIEX16Slots = model.CountPCIEX16Slots,
                CountM2Slots = model.CountM2Slots,
                CountSATASlots = model.CountSATASlots
            };
        }

        private RAMDTO CreateRAM(RAMModel model)
        {
            return new RAMDTO(model.Name, model.Manufacturer, model.Model, model.Price
                , _function.Defuzzify(model.TotalScore), model.RAMType)
            {
                SingleModuleCapacity = model.SingleModuleCapacity,
                CountModules = model.CountModules,
                Frequency = model.Frequency
            };
        }

        private VideoCardDTO CreateVideoCard(VideoCardModel model)
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
    }
}
