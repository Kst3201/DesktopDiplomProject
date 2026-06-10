using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Models
{
    public interface IPCModel
    {
        CPUModel CPU { get; }
        DriveModel Drive { get; }
        MotherboardModel Motherboard { get; }
        RAMModel RAM { get; }
        VideoCardModel VideoCard { get; }
        double Price { get; }
        double TotalScore { get; }


    }
}
