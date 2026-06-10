using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer;
using DiplomDataLibrary.PCBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public class NativePCCreator : IPCCreator
    {
        private CPUCreator _cpuCreator;
        private DriveCreator _driveCreator;
        private MotherboardCreator _motherboardCreator;
        private RAMCreator _ramCreator;
        private VideoCardCreator _videoCardCreator;

        public NativePCCreator()
        {
            _cpuCreator = new CPUCreator();
            _driveCreator = new DriveCreator();
            _motherboardCreator = new MotherboardCreator();
            _ramCreator = new RAMCreator();
            _videoCardCreator = new VideoCardCreator();
        }

        public IPCModel? Create(PCDTO? dto)
        {
            if (dto == null) return null;
            var cpu = _cpuCreator.CreateModel(dto.CPU);
            var drive = _driveCreator.CreateModel(dto.Drive);
            var mother = _motherboardCreator.CreateModel(dto.Motherboard);
            var ram = _ramCreator.CreateModel(dto.RAM);
            var video = _videoCardCreator.CreateModel(dto.VideoCard);
            return new NativePCModel(cpu, drive, mother, ram, video)
            {
                Price = dto.Price,
                TotalScore = dto.TotalScore
            };
        }

        public IPCModel? Create(IPCViewModel? viewModel)
        {
            if (viewModel == null) return null;
            var cpu = _cpuCreator.CreateModel(viewModel.CPU);
            var drive = _driveCreator.CreateModel(viewModel.Drive);
            var motherboard = _motherboardCreator.CreateModel(viewModel.Motherboard);
            var ram = _ramCreator.CreateModel(viewModel.RAM);
            var videoCard = _videoCardCreator.CreateModel(viewModel.VideoCard);
            return new NativePCModel(cpu, drive, motherboard, ram, videoCard)
            {
                Price = viewModel.Price,
                TotalScore = viewModel.TotalScore
            };
        }

        public IPCViewModel? Create(IPCModel? model)
        {
            if (model == null) return null;
            var cpu = _cpuCreator.CreateViewModel(model.CPU);
            var drive = _driveCreator.CreateViewModel(model.Drive);
            var motherboard = _motherboardCreator.CreateViewModel(model.Motherboard);
            var ram = _ramCreator.CreateViewModel(model.RAM);
            var videoCard = _videoCardCreator.CreateViewModel(model.VideoCard);
            return new NativePCViewModel(cpu, drive, motherboard, ram, videoCard)
            {
                Price = model.Price,
                TotalScore = model.TotalScore
            };
        }
        
    }
}
