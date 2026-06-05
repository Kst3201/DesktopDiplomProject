using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO
{
    public class BaseComponentScoredUnitDTO : BaseComponentNamedUnitDTO
    {
        public double ScoreOne { get; set; }
        public double ScoreTwo { get; set; }
        public double ScoreThree { get; set; }
        public double ScoreFour { get; set; }
        public double ScoreFive { get; set; }

        public BaseComponentScoredUnitDTO(string name, double scoreOne
            , double scoreTwo, double scoreThree, double scoreFour, double scoreFive) : base(name)
        {
            ScoreOne = scoreOne;
            ScoreTwo = scoreTwo;
            ScoreThree = scoreThree;
            ScoreFour = scoreFour;
            ScoreFive = scoreFive;
        }
    }
}
