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
    public class VideoCardCreator : IVideoCardCreator
    {
        public VideoCardCreator() { }

        public VideoCardDTO CreateDTO(VideoCardModel model)
        {
            return new VideoCardDTO(model.Name, model.Manufacturer, model.Model, model.Price, model.TotalScore
                , model.GPU, model.PCIEInterface)
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

        public VideoCardModel CreateEmptyModel()
        {
            return new VideoCardModel();
        }

        public VideoCardViewModel CreateEmptyViewModel()
        {
            return new VideoCardViewModel();
        }

        public VideoCardModel CreateModel(VideoCardDTO dto)
        {
            return new VideoCardModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Price = dto.Price,
                TotalScore = dto.TotalScore,
                GPU = dto.GPU,
                PCIEInterface = dto.PCIEInterface,
                CountPCIELines = dto.CountPCIELines,
                RecommendedBlockPower = dto.RecommendedBlockPower,
                CountPinsAdditionalPower = dto.CountPinsAdditionalPower,
                CapacityVideoMemory = dto.CapacityVideoMemory,
                MaxThroughputCapacity = dto.MaxThroughputCapacity,
                MemoryFrequency = dto.MemoryFrequency,
                CountMonitors = dto.CountMonitors
            };
        }

        public VideoCardModel CreateModel(VideoCardViewModel viewModel)
        {
            return new VideoCardModel()
            {
                Name = viewModel.Name,
                Manufacturer = viewModel.Manufacturer,
                Model = viewModel.Model,
                Price = viewModel.Price,
                TotalScore = viewModel.TotalScore,
                GPU = viewModel.GPU,
                PCIEInterface = viewModel.PCIEInterface,
                CountPCIELines = viewModel.CountPCIELines,
                RecommendedBlockPower = viewModel.RecommendedBlockPower,
                CountPinsAdditionalPower = viewModel.CountPinsAdditionalPower,
                CapacityVideoMemory = viewModel.CapacityVideoMemory,
                MaxThroughputCapacity = viewModel.MaxThroughputCapacity,
                MemoryFrequency = viewModel.MemoryFrequency,
                CountMonitors = viewModel.CountMonitors
            };
        }

        public VideoCardViewModel CreateViewModel(VideoCardModel model)
        {
            return new VideoCardViewModel()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Price = model.Price,
                TotalScore = model.TotalScore,
                GPU = model.GPU,
                PCIEInterface = model.PCIEInterface,
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
