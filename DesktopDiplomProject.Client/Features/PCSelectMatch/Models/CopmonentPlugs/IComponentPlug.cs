using DiplomDataLibrary.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Models.CopmonentPlugs
{
    public interface IComponentPlug<T>
    {
        T? Item { get; set; }
        double? MaxPrice { get; set; }
        FuzzyAssessments? Assessment { get; set; }
    }
}
