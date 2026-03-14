using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Models
{
    internal class TestComponentModel
    {
        public string ComponentName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TestParameterModel> Parameters { get; set; }

        public TestComponentModel(string componentName, string name, string description, List<TestParameterModel> parameters)
        {
            ComponentName = componentName;
            Name = name;
            Description = description;
            Parameters = parameters;
        }
    }
}
