using DesktopDiplomProject.Client.Models;
using DesktopDiplomProject.Client.ViewModels.Windows.MainWindow.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.ViewModels.Windows.MainWindow.Pages
{
    class SelectionPCViewModel
    {
        public List<TestPCViewModel> Items { get; set; }
        public TestPCViewModel SelectedItem { get; set; }

        public SelectionPCViewModel()
        {
            Items = new List<TestPCViewModel>()
            {
                new TestPCViewModel()
                {
                    Score = 1
                },
                new TestPCViewModel()
                {
                    Score = 2
                },
                new TestPCViewModel()
                {
                    Score = 3
                },
                new TestPCViewModel()
                {
                    Score = 4
                },
                new TestPCViewModel()
                {
                    Score = 5
                },
            };
            SelectedItem = Items.First();
        }
    }
}
