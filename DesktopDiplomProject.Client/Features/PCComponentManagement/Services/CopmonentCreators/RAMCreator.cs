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
    public class RAMCreator : IRAMCreator
    {
        public RAMCreator() { }

        public RAMDTO CreateDTO(RAMModel model)
        {
            return new RAMDTO(model.Name, model.Manufacturer, model.Model, model.Price, model.TotalScore, model.RAMType)
            {
                SingleModuleCapacity = model.SingleModuleCapacity,
                CountModules = model.CountModules,
                Frequency = model.Frequency
            };
        }

        public RAMModel CreateEmptyModel()
        {
            return new RAMModel();
        }

        public RAMViewModel CreateEmptyViewModel()
        {
            return new RAMViewModel();
        }

        public RAMModel CreateModel(RAMDTO dto)
        {
            return new RAMModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Price = dto.Price,
                TotalScore = dto.TotalScore,
                RAMType = dto.RAMType,
                SingleModuleCapacity = dto.SingleModuleCapacity,
                CountModules = dto.CountModules,
                Frequency = dto.Frequency
            };
        }

        public RAMModel CreateModel(RAMViewModel viewModel)
        {
            return new RAMModel()
            {
                Name = viewModel.Name,
                Manufacturer = viewModel.Manufacturer,
                Model = viewModel.Model,
                Price = viewModel.Price,
                TotalScore = viewModel.TotalScore,
                RAMType = viewModel.RAMType,
                SingleModuleCapacity = viewModel.SingleModuleCapacity,
                CountModules = viewModel.CountModules,
                Frequency = viewModel.Frequency
            };
        }

        public RAMViewModel CreateViewModel(RAMModel model)
        {
            return new RAMViewModel()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Price = model.Price,
                TotalScore = model.TotalScore,
                RAMType = model.RAMType,
                SingleModuleCapacity = model.SingleModuleCapacity,
                CountModules = model.CountModules,
                Frequency = model.Frequency
            };
        }
    }
}
