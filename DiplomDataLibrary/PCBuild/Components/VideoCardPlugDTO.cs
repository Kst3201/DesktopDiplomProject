using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild.Components
{
    public class VideoCardPlugDTO : IComponentPlugDTO<VideoCardDTO>
    {
        public VideoCardDTO? Item { get; set; }
        public double? MaxPrice { get; set; }
        public FuzzyAssessments? MinAssessment { get; set; }

        public VideoCardPlugDTO() { }
    }
}
