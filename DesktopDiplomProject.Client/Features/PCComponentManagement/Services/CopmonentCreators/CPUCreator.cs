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
    public class CPUCreator : ICPUCreator
    {
        public CPUCreator() { }

        public CPUDTO CreateDTO(CPUModel model)
        {
            return new CPUDTO(model.Name, model.Manufacturer, model.Model, model.Price, model.TotalScore
                , model.Socket, model.RAMType)
            {
                BaseFrequency = model.BaseFrequency,
                CountCores = model.CountCores,
                CountThreads = model.CountThreads,
            };
        }

        public CPUModel CreateEmptyModel()
        {
            return new CPUModel();
        }

        public CPUViewModel CreateEmptyViewModel()
        {
            return new CPUViewModel();
        }

        public CPUModel CreateModel(CPUDTO dto)
        {
            return new CPUModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Price = dto.Price,
                TotalScore = dto.TotalScore,
                Socket = dto.Socket,
                RAMType = dto.RAMType,
                BaseFrequency = dto.BaseFrequency,
                CountCores = dto.CountCores,
                CountThreads = dto.CountThreads
            };
        }

        public CPUModel CreateModel(CPUViewModel viewModel)
        {
            return new CPUModel()
            {
                Name = viewModel.Name,
                Manufacturer = viewModel.Manufacturer,
                Model = viewModel.Model,
                Price = viewModel.Price,
                TotalScore = viewModel.TotalScore,
                Socket = viewModel.Socket,
                RAMType = viewModel.RAMType,
                BaseFrequency = viewModel.BaseFrequency,
                CountCores = viewModel.CountCores,
                CountThreads = viewModel.CountThreads
            };
        }

        public CPUViewModel CreateViewModel(CPUModel model)
        {
            return new CPUViewModel()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Price = model.Price,
                TotalScore = model.TotalScore,
                Socket = model.Socket,
                RAMType = model.RAMType,
                BaseFrequency = model.BaseFrequency,
                CountCores = model.CountCores,
                CountThreads = model.CountThreads
            };
        }
    }
}
