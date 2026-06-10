using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCBuild.Components;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild
{
    public class PCUpgradeRequest : PCBuildRequest
    {
        public CPUPlugDTO? CPU { get; set; }
        public DrivePlugDTO? Drive { get; set; }
        public MotherboardPlugDTO? Motherboard { get; set; }
        public RAMPlugDTO? RAM { get; set; }
        public VideoCardPlugDTO? VideoCard { get; set; }

        public PCUpgradeRequest() : base()
        {

        }

        public PCUpgradeRequest(NativePCPresetDTO preset, double? maxPrice, FuzzyAssessments? minAssessment) : base(preset, maxPrice, minAssessment)
        {
            MaxPrice = maxPrice; 
            MinAssessment = minAssessment;
            CPU = null;
            Drive = null;
            Motherboard = null;
            RAM = null;
            VideoCard = null;
        }
    }
}
