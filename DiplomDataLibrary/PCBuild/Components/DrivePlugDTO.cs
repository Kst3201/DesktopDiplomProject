using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild.Components
{
    public class DrivePlugDTO : IComponentPlugDTO<DriveDTO>
    {
        public DriveDTO? Item { get; set; }
        public double? MaxPrice { get; set; }
        public FuzzyAssessments? MinAssessment { get; set; }

        public DrivePlugDTO() { }
    }
}
