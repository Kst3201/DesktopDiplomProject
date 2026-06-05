using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components
{
    public class RAMTypeModel
    {
        public string Name { get; set; }
        public double ScoreOne { get; set; }
        public double ScoreTwo { get; set; }
        public double ScoreThree { get; set; }
        public double ScoreFour { get; set; }
        public double ScoreFive { get; set; }

        public RAMTypeModel() 
        { 
            Name = string.Empty;
            ScoreOne = 0;
            ScoreTwo = 0;
            ScoreThree = 0;
            ScoreFour = 0;
            ScoreFive = 0;
        }

    }
}
