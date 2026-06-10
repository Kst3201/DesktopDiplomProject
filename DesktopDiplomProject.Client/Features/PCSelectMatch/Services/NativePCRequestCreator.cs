using DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models.CopmonentPlugs;
using DiplomDataLibrary.PCBuild;
using DiplomDataLibrary.PCBuild.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public class NativePCRequestCreator : IPCRequestCreator
    {
        private ICPUCreator _cpuCreator;
        private IDriveCreator _driveCreator;
        private IMotherboardCreator _motherboardCreator;
        private IRAMCreator _ramCreator;
        private IVideoCardCreator _videoCreator;

        public NativePCRequestCreator()
        {
            _cpuCreator = new CPUCreator();
            _driveCreator = new DriveCreator();
            _motherboardCreator = new MotherboardCreator();
            _ramCreator = new RAMCreator();
            _videoCreator = new VideoCardCreator();
        }

        public PCBuildRequest CreateBuildRequest(PCSelectConfigurationSet set)
        {
            var preset = new NativePCPresetDTO();
            if (set.Preset is NativePCPresetDTO pres)
            {
                preset = pres;
            }
            else
            {
                preset.Name = set.Preset.Name;
                preset.CPUCoeff = set.Preset.CPUCoeff;
                preset.DriveCoeff = set.Preset.DriveCoeff;
                preset.MotherboardCoeff = set.Preset.MotherboardCoeff;
                preset.RAMCoeff = set.Preset.RAMCoeff;
                preset.VideoCardCoeff = set.Preset.VideoCardCoeff;
            }
                return new PCBuildRequest(preset, set.MaxPrice, set.TargetAssessment);
        }

        public PCUpgradeRequest CreateUpgradeRequest(PCSelectConfigurationSet set)
        {
            var cpuPlug = CreateCPUPlugDTO(set.CPU);
            var drivePlug = CreateDrivePlugDTO(set.Drive);
            var motherPlug = CreateMotherboardPlugDTO(set.Motherboard);
            var ramPlug = CreateRAMPlugDTO(set.RAM);
            var videoPlug = CreateVideoCardPlugDTO(set.VideoCard);
            var preset = new NativePCPresetDTO();
            if (set.Preset is NativePCPresetDTO pres)
            {
                preset = pres;
            }
            else
            {
                preset.Name = set.Preset.Name;
                preset.CPUCoeff = set.Preset.CPUCoeff;
                preset.DriveCoeff = set.Preset.DriveCoeff;
                preset.MotherboardCoeff = set.Preset.MotherboardCoeff;
                preset.RAMCoeff = set.Preset.RAMCoeff;
                preset.VideoCardCoeff = set.Preset.VideoCardCoeff;
            }
            return new PCUpgradeRequest(preset, set.MaxPrice, set.TargetAssessment)
            {
                CPU = cpuPlug,
                Drive = drivePlug,
                Motherboard = motherPlug,
                RAM = ramPlug,
                VideoCard = videoPlug
            };
        }

        private CPUPlugDTO? CreateCPUPlugDTO(CPUPlugModel? model)
        {
            if (model == null) return null;
            return new CPUPlugDTO()
            {
                Item = model.Item == null ? null : _cpuCreator.CreateDTO(model.Item),
                MaxPrice = model.MaxPrice,
                MinAssessment = model.Assessment
            };
        }

        private DrivePlugDTO? CreateDrivePlugDTO(DrivePlugModel? model)
        {
            if (model == null) return null;
            return new DrivePlugDTO()
            {
                Item = model.Item == null ? null : _driveCreator.CreateDTO(model.Item),
                MaxPrice = model.MaxPrice,
                MinAssessment = model.Assessment
            };
        }

        private MotherboardPlugDTO? CreateMotherboardPlugDTO(MotherboardPlugModel? model)
        {
            if (model == null) return null;
            return new MotherboardPlugDTO()
            {
                Item = model.Item == null ? null : _motherboardCreator.CreateDTO(model.Item),
                MaxPrice = model.MaxPrice,
                MinAssessment = model.Assessment
            };
        }

        private RAMPlugDTO? CreateRAMPlugDTO(RAMPlugModel? model)
        {
            if (model == null) return null;
            return new RAMPlugDTO()
            {
                Item = model.Item == null ? null : _ramCreator.CreateDTO(model.Item),
                MaxPrice = model.MaxPrice,
                MinAssessment = model.Assessment
            };
        }

        private VideoCardPlugDTO? CreateVideoCardPlugDTO(VideoCardPlugModel? model)
        {
            if (model == null) return null;
            return new VideoCardPlugDTO()
            {
                Item = model.Item == null ? null : _videoCreator.CreateDTO(model.Item),
                MaxPrice = model.MaxPrice,
                MinAssessment = model.Assessment
            };
        }
    }
}
