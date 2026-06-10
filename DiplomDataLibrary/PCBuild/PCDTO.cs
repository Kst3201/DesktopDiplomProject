using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild
{
    public class PCDTO
    {
        public CPUDTO CPU { get; set; }
        public DriveDTO Drive { get; set; }
        public MotherboardDTO Motherboard { get; set; }
        public RAMDTO RAM { get; set; }
        public VideoCardDTO VideoCard { get; set; }
        public double Price { get ; set; }
        public double TotalScore { get; set; }

        public PCDTO(CPUDTO cPU, DriveDTO drive, MotherboardDTO motherboard, RAMDTO rAM, VideoCardDTO videoCard
            , double price, double totalScore)
        {
            CPU = cPU;
            Drive = drive;
            Motherboard = motherboard;
            RAM = rAM;
            VideoCard = videoCard;
            Price = price;
            TotalScore = totalScore;
        }
    }
}
