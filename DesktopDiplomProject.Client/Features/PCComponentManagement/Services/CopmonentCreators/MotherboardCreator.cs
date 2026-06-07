using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators
{
    public class MotherboardCreator : IMotherboardCreator
    {
        public MotherboardCreator() { }

        public MotherboardDTO CreateDTO(MotherboardModel model)
        {
            return new MotherboardDTO(model.Name, model.Manufacturer, model.Model, model.Price, model.TotalScore
                , model.Size, model.Socket, model.RAMType, model.PCIEInterface)
            {
                RAMCountSlots = model.RAMCountSlots,
                MaxRAMValue = model.MaxRAMValue,
                MaxRAMFrequency = model.MaxRAMFrequency,
                CountPCIEX16Slots = model.CountPCIEX16Slots,
                CountM2Slots = model.CountM2Slots,
                CountSATASlots = model.CountSATASlots
            };
        }

        public MotherboardModel CreateEmptyModel()
        {
            return new MotherboardModel();
        }

        public MotherboardViewModel CreateEmptyViewModel()
        {
            return new MotherboardViewModel();
        }

        public MotherboardModel CreateModel(MotherboardDTO dto)
        {
            return new MotherboardModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Price = dto.Price,
                TotalScore = dto.TotalScore,
                Size = dto.Size,
                Socket = dto.Socket,
                RAMType = dto.RAMType,
                PCIEInterface = dto.PCIEInterface,
                RAMCountSlots = dto.RAMCountSlots,
                MaxRAMValue = dto.MaxRAMValue,
                MaxRAMFrequency = dto.MaxRAMFrequency,
                CountPCIEX16Slots = dto.CountPCIEX16Slots,
                CountM2Slots = dto.CountM2Slots,
                CountSATASlots = dto.CountSATASlots
            };
        }

        public MotherboardModel CreateModel(MotherboardViewModel viewModel)
        {
            return new MotherboardModel()
            {
                Name = viewModel.Name,
                Manufacturer = viewModel.Manufacturer,
                Model = viewModel.Model,
                Price = viewModel.Price,
                TotalScore = viewModel.TotalScore,
                Size = viewModel.Size,
                Socket = viewModel.Socket,
                RAMType = viewModel.RAMType,
                PCIEInterface = viewModel.PCIEInterface,
                RAMCountSlots = viewModel.RAMCountSlots,
                MaxRAMValue = viewModel.MaxRAMValue,
                MaxRAMFrequency = viewModel.MaxRAMFrequency,
                CountPCIEX16Slots = viewModel.CountPCIEX16Slots,
                CountM2Slots = viewModel.CountM2Slots,
                CountSATASlots = viewModel.CountSATASlots
            };
        }

        public MotherboardViewModel CreateViewModel(MotherboardModel model)
        {
            return new MotherboardViewModel()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Price = model.Price,
                TotalScore = model.TotalScore,
                Size = model.Size,
                Socket = model.Socket,
                RAMType = model.RAMType,
                PCIEInterface = model.PCIEInterface,
                RAMCountSlots = model.RAMCountSlots,
                MaxRAMValue = model.MaxRAMValue,
                MaxRAMFrequency = model.MaxRAMFrequency,
                CountPCIEX16Slots = model.CountPCIEX16Slots,
                CountM2Slots = model.CountM2Slots,
                CountSATASlots = model.CountSATASlots
            };
        }
    }
}
