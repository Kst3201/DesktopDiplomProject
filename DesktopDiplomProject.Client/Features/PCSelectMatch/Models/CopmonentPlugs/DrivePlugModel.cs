using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DiplomDataLibrary.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Models.CopmonentPlugs
{
    public class DrivePlugModel : IComponentPlug<DriveModel>
    {
        public DriveModel? Item { get; set; }
        public double? MaxPrice { get; set; }
        public FuzzyAssessments? Assessment { get; set; }

        public DrivePlugModel() { }
    }
}
