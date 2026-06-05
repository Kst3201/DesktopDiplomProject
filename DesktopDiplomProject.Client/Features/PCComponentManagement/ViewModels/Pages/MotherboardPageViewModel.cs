using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages
{
    public class MotherboardViewModel : ObservableViewModel
    {
        private MotherboardViewModel _redactedItem;
        private List<MotherboardViewModel> _items;
        private List<string> _sizeItems;
        private List<string> _socketItems;
        private List<string> _ramTypeItems;
        private List<string> _pcieInterfaceItems;

        public string ComponentType => $"Материнская плата";

        public MotherboardViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }
        public IReadOnlyList<MotherboardViewModel> Items => _items;
        public IReadOnlyList<string> SizeItems => _sizeItems;
        public IReadOnlyList<string> SocketItems => _socketItems;
        public IReadOnlyList<string> RAMTypeItems => _ramTypeItems;
        public IReadOnlyList<string> PCIEInterfaceItems => _pcieInterfaceItems;

        public MotherboardViewModel() : base()
        {
            _redactedItem = new MotherboardViewModel();
            _items = new List<MotherboardViewModel>();
            _sizeItems = new List<string>();
            _socketItems = new List<string>();
            _ramTypeItems = new List<string>();
            _pcieInterfaceItems = new List<string>();
        }
    }
}
