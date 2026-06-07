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
    public class GPUCreator : IGPUCreator
    {
        public GPUCreator() { }

        public GPUDTO CreateDTO(GPUModel model)
        {
            return new GPUDTO(model.Name, model.Manufacturer, model.Model, model.TotalScore)
            {
                BaseFrequency = model.BaseFrequency,
                CountUniversalProcessors = model.CountUniversalProcessors,
                CountTexturerBlocks = model.CountTexturerBlocks,
                CountRasterizationBlocks = model.CountRasterizationBlocks,
                CountRTCores = model.CountRTCores,
                CountTensorCores = model.CountTensorCores
            };
        }

        public GPUModel CreateEmptyModel()
        {
            return new GPUModel();
        }

        public GPUViewModel CreateEmptyViewModel()
        {
            return new GPUViewModel();
        }

        public GPUModel CreateModel(GPUDTO dto)
        {
            return new GPUModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                TotalScore = dto.TotalScore,
                BaseFrequency = dto.BaseFrequency,
                CountUniversalProcessors = dto.CountUniversalProcessors,
                CountTexturerBlocks = dto.CountTexturerBlocks,
                CountRasterizationBlocks = dto.CountRasterizationBlocks,
                CountRTCores = dto.CountRTCores,
                CountTensorCores = dto.CountTensorCores
            };
        }

        public GPUModel CreateModel(GPUViewModel viewModel)
        {
            return new GPUModel()
            {
                Name = viewModel.Name,
                Manufacturer = viewModel.Manufacturer,
                Model = viewModel.Model,
                TotalScore = viewModel.TotalScore,
                BaseFrequency = viewModel.BaseFrequency,
                CountUniversalProcessors = viewModel.CountUniversalProcessors,
                CountTexturerBlocks = viewModel.CountTexturerBlocks,
                CountRasterizationBlocks = viewModel.CountRasterizationBlocks,
                CountRTCores = viewModel.CountRTCores,
                CountTensorCores = viewModel.CountTensorCores
            };
        }

        public GPUViewModel CreateViewModel(GPUModel model)
        {
            return new GPUViewModel()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                TotalScore = model.TotalScore,
                BaseFrequency = model.BaseFrequency,
                CountUniversalProcessors = model.CountUniversalProcessors,
                CountTexturerBlocks = model.CountTexturerBlocks,
                CountRasterizationBlocks = model.CountRasterizationBlocks,
                CountRTCores = model.CountRTCores,
                CountTensorCores = model.CountTensorCores
            };
        }
    }
}
