using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCComponents.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCBuild.Components
{
    public interface IComponentPlugDTO<T>
        where T : BaseComponentNamedUnitDTO
    {
        T? Item { get; set; }
        double? MaxPrice { get; set; }
        FuzzyAssessments? MinAssessment { get; set; }

    }
}
