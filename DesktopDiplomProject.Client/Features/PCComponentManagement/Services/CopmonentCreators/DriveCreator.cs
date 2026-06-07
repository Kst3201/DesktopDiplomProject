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
    public class DriveCreator : IDriveCreator
    {
        public DriveCreator() { }

        public DriveDTO CreateDTO(DriveModel model)
        {
            return new DriveDTO(model.Name, model.Manufacturer, model.Model, model.Price, model.TotalScore
                , model.ConnectorInterface)
            {
                Capacity = model.Capacity,
                SpeedDataTransfer = model.SpeedDataTransfer
            };
        }

        public DriveModel CreateEmptyModel()
        {
            return new DriveModel();
        }

        public DriveViewModel CreateEmptyViewModel()
        {
            return new DriveViewModel();
        }

        public DriveModel CreateModel(DriveDTO dto)
        {
            return new DriveModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Price = dto.Price,
                TotalScore = dto.TotalScore,
                ConnectorInterface = dto.ConnectorInterface,
                Capacity = dto.Capacity,
                SpeedDataTransfer = dto.SpeedDataTransfer
            };
        }

        public DriveModel CreateModel(DriveViewModel viewModel)
        {
            return new DriveModel()
            {
                Name = viewModel.Name,
                Manufacturer = viewModel.Manufacturer,
                Model = viewModel.Model,
                Price = viewModel.Price,
                TotalScore = viewModel.TotalScore,
                ConnectorInterface = viewModel.ConnectionInterface,
                Capacity = viewModel.Capacity,
                SpeedDataTransfer = viewModel.SpeedDataTransfer
            };
        }

        public DriveViewModel CreateViewModel(DriveModel model)
        {
            return new DriveViewModel()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Model = model.Model,
                Price = model.Price,
                TotalScore = model.TotalScore,
                ConnectionInterface = model.ConnectorInterface,
                Capacity = model.Capacity,
                SpeedDataTransfer = model.SpeedDataTransfer
            };
        }
    }
}
