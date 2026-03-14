using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Models
{
    internal class TestModel
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        
        public TestModel()
        {
            IsChecked = false;
            Name = string.Empty;
            Price = 0;
            MinPrice = 0;
            MaxPrice = 1000000;
        }
    }
}
