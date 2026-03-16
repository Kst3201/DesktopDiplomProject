using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.ViewModels.Windows.Components.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.MainWindow.Units
{
    class TestPCViewModel
    {
        public static int id = 0;

        public int ID { get; }
        public TestCPUViewModel CPU { get; set; }
        public TestMotherboardViewModel Motherboard { get; set; }
        public TestGPUViewModel GPU { get; set; }
        public TestRAMViewModel RAM { get; set; }
        public TestSSDViewModel SSD { get; set; }
        public double Score { get; set; }

        public TestPCViewModel()
        {
            ID = ++id;
            CPU = new TestCPUViewModel();
            Motherboard = new TestMotherboardViewModel();
            GPU = new TestGPUViewModel();
            RAM = new TestRAMViewModel();
            SSD = new TestSSDViewModel();
            Random random = new Random();
            Score = random.Next(0, 5) + random.NextDouble();
        }
    }
}
