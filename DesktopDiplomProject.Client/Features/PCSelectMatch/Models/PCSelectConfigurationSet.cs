using DesktopDiplomProject.Client.Features.PCSelectMatch.Models.CopmonentPlugs;
using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCBuild;
using DiplomDataLibrary.PCBuild.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Models
{
    public class PCSelectConfigurationSet
    {
        public CPUPlugModel? CPU { get; set; }
        public DrivePlugModel? Drive { get; set; }
        public MotherboardPlugModel? Motherboard { get; set; }
        public RAMPlugModel? RAM { get; set; }
        public VideoCardPlugModel? VideoCard { get; set; }
        public bool IsUpgrade
        {
            get
            {
                return !((CPU?.Item) != null && (Drive?.Item) != null && (Motherboard?.Item) != null && (RAM?.Item) != null && (VideoCard?.Item) != null);
            }
        }
        public IPCPresetDTO Preset { get; set; }
        public double? MaxPrice { get; set; }
        public FuzzyAssessments? TargetAssessment { get; set; }

        public PCSelectConfigurationSet(IPCPresetDTO preset, double? maxPrice, FuzzyAssessments? targetAssessment)
        {
            Preset = preset;
            MaxPrice = maxPrice;
            TargetAssessment = targetAssessment;
        }
    }
}
