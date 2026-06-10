using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.PersonalComputers
{
    public class NativePCModel : IPCModel
    {
        public CPUModel CPU { get; init;}
        public DriveModel Drive { get; init; }
        public MotherboardModel Motherboard { get; init; }
        public RAMModel RAM { get; init; }
        public VideoCardModel VideoCard { get; init; }
        public double Price { get; init; }
        public IScore TotalScore { get; init; }

        public NativePCModel()
        {
            CPU = new CPUModel();
            Drive = new DriveModel();
            Motherboard = new MotherboardModel();
            RAM = new RAMModel();
            VideoCard = new VideoCardModel();
            Price = 0;
            TotalScore = new Score();
        }
    }
}
