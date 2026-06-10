using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Models
{
    public class NativePCModel : IPCModel
    {
        public CPUModel CPU { get; } 
        public DriveModel Drive { get; }
        public MotherboardModel Motherboard { get; }
        public RAMModel RAM { get; }
        public VideoCardModel VideoCard { get; }
        public double Price { get; init; }
        public double TotalScore { get; init; }

        public NativePCModel(CPUModel cpu, DriveModel drive, MotherboardModel motherboard
            , RAMModel ram, VideoCardModel videoCard)
        {
            CPU = cpu;
            Drive = drive;
            Motherboard = motherboard;
            RAM = ram;
            VideoCard = videoCard;
        }
    }
}
