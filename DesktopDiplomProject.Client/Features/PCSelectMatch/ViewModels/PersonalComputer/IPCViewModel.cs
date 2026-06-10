using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer
{
    public interface IPCViewModel : INotifyPropertyChanged
    {
        CPUViewModel CPU { get; }
        DriveViewModel Drive { get; }
        MotherboardViewModel Motherboard { get; }
        RAMViewModel RAM { get; }
        VideoCardViewModel VideoCard { get; }
        double Price { get; }
        double TotalScore { get; }
    }
}
