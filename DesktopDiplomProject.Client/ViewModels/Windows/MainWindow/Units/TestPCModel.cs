using DesktopDiplomProject.Client.ViewModels.Windows.Components.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.MainWindow.Units
{
    class TestPCModel
    {
        public static int id = 0;

        public int ID { get; }
        public List<TestComponentViewModel> Components { get; set; }
        public double Score { get; set; }

        public TestPCModel()
        {
            ID = ++id;
            Components = new List<TestComponentViewModel>();
            Score = 0;
        }
    }
}
