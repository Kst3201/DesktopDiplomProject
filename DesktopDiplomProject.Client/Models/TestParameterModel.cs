using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Models
{
    internal class TestParameterModel
    {
        public string Name { get; set; }
        public double Score { get; set; }

        public TestParameterModel(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }
}
