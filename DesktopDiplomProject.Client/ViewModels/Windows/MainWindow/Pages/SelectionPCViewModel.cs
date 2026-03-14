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
        public List<TestPCModel> Items { get; set; }
        public TestPCModel SelectedItem { get; set; }

        public SelectionPCViewModel()
        {
            Items = new List<TestPCModel>()
            {
                new TestPCModel()
                {
                    Components = new List<Components.Units.TestComponentViewModel>()
                    {
                        new Components.Units.TestComponentViewModel("Процессор", "Intel Core i3", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Материнская плата", "Gigabyte A520M K V2", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Видеокарта", "GIGABYTE GeForce RTX 5060 GAMING OC 8G", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Оперативная память", "Kingston DDR4 8Gb 3200", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Долговременная память", "ADATA LEGEND 710 512 Гб", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Блок питания", "Deepcool PF750", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                    },
                    Score = 1
                },
                new TestPCModel()
                {
                    Components = new List<Components.Units.TestComponentViewModel>()
                    {
                        new Components.Units.TestComponentViewModel("Процессор", "Intel Core i3", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Материнская плата", "Gigabyte A520M K V2", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Видеокарта", "GIGABYTE GeForce RTX 5060 GAMING OC 8G", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Оперативная память", "Kingston DDR4 8Gb 3200", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Долговременная память", "ADATA LEGEND 710 512 Гб", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Блок питания", "Deepcool PF750", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                    },
                    Score = 2
                },
                new TestPCModel()
                {
                    Components = new List<Components.Units.TestComponentViewModel>()
                    {
                        new Components.Units.TestComponentViewModel("Процессор", "Intel Core i3", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Материнская плата", "Gigabyte A520M K V2", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Видеокарта", "GIGABYTE GeForce RTX 5060 GAMING OC 8G", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Оперативная память", "Kingston DDR4 8Gb 3200", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Долговременная память", "ADATA LEGEND 710 512 Гб", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Блок питания", "Deepcool PF750", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                    },
                    Score = 3
                },
                new TestPCModel()
                {
                    Components = new List<Components.Units.TestComponentViewModel>()
                    {
                        new Components.Units.TestComponentViewModel("Процессор", "Intel Core i3", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Материнская плата", "Gigabyte A520M K V2", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Видеокарта", "GIGABYTE GeForce RTX 5060 GAMING OC 8G", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Оперативная память", "Kingston DDR4 8Gb 3200", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Долговременная память", "ADATA LEGEND 710 512 Гб", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Блок питания", "Deepcool PF750", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                    },
                    Score = 4
                },
                new TestPCModel()
                {
                    Components = new List<Components.Units.TestComponentViewModel>()
                    {
                        new Components.Units.TestComponentViewModel("Процессор", "Intel Core i3", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Материнская плата", "Gigabyte A520M K V2", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Видеокарта", "GIGABYTE GeForce RTX 5060 GAMING OC 8G", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Оперативная память", "Kingston DDR4 8Gb 3200", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Долговременная память", "ADATA LEGEND 710 512 Гб", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                        new Components.Units.TestComponentViewModel("Блок питания", "Deepcool PF750", "ОПИСАНИЕ", new List<TestParameterModel>()
                        {
                            new TestParameterModel("Тестовый параметр1", 1),
                            new TestParameterModel("Тестовый параметр2", 1),
                            new TestParameterModel("Тестовый параметр3", 1),
                            new TestParameterModel("Тестовый параметр4", 1),
                            new TestParameterModel("Тестовый параметр5", 1),
                            new TestParameterModel("Тестовый параметр6", 1),
                            new TestParameterModel("Тестовый параметр7", 1),
                            new TestParameterModel("Тестовый параметр8", 1)
                        }),
                    },
                    Score = 5
                },
            };
            SelectedItem = Items.First();
        }
    }
}
