using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer
{
    public class NativePCViewModel : ObservableViewModel, IPCViewModel
    {
        private CPUViewModel _cpu;
        private DriveViewModel _drive;
        private MotherboardViewModel _motherboard;
        private RAMViewModel _ram;
        private VideoCardViewModel _videoCard;
        private double _price;
        private double _totalScore;

        public CPUViewModel CPU => _cpu;
        public DriveViewModel Drive => _drive;
        public MotherboardViewModel Motherboard => _motherboard;
        public RAMViewModel RAM => _ram;
        public VideoCardViewModel VideoCard => _videoCard;
        public double Price { get => _price; init => _price = value; }
        public double TotalScore { get => _totalScore; init => _totalScore = value; }


        public NativePCViewModel(CPUViewModel cpu, DriveViewModel drive, MotherboardViewModel motherboard
            , RAMViewModel ram, VideoCardViewModel videoCard)
        {
            _cpu = cpu;
            _drive = drive;
            _motherboard = motherboard;
            _ram = ram;
            _videoCard = videoCard;
            _price = 0;
            _totalScore = 0;
        }
    }
}
