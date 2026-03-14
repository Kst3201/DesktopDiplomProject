using DesktopDiplomProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.Components.Units
{
    class TestComponentViewModel
    {
        public string ComponentName { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public List<TestParameterModel> Parameters { get; set; }
        public double Score { get; set; }
        
        public TestComponentViewModel(string componentName, string modelName, string description, IList<TestParameterModel> parameters)
        {
            ComponentName = componentName;
            ModelName = modelName;
            Description = description;
            Parameters = parameters.ToList();
            Random random = new Random();
            Score = random.Next(0, 5) + random.NextDouble();
        }
    }
}
