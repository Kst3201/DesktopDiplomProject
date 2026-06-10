using DiplomDataLibrary.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild
{
    public class PCBuildRequest
    {
        public NativePCPresetDTO Preset { get; set; }
        public double? MaxPrice { get; set; }
        public FuzzyAssessments? MinAssessment { get; set; }

        public PCBuildRequest()
        {
            Preset = new NativePCPresetDTO();
            MaxPrice = null;
            MinAssessment = null;
        }
        
        public PCBuildRequest(NativePCPresetDTO preset, double? maxPrice, FuzzyAssessments? minAssessment)
        {
            Preset = preset;
            MaxPrice = maxPrice;
            MinAssessment = minAssessment;
        }
    }
}
