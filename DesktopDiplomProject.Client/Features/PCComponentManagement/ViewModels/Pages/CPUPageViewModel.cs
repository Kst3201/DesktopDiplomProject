using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages
{
    public class CPUPageViewModel : ObservableViewModel
    {
        private CPUViewModel _redactedItem;
        private List<CPUViewModel> _items;
        private List<string> _socketItems;
        private List<string> _ramTypeItems;

        public string ComponentType => $"Центральный процессор";

        public CPUViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<CPUViewModel> Items => _items;

        public IReadOnlyList<string> SocketItems => _socketItems;

        public IReadOnlyList<string> RAMTypeItems => _ramTypeItems;

        public CPUPageViewModel() : base()
        {
            _redactedItem = new CPUViewModel();
            _items = new List<CPUViewModel>();
            _socketItems = new List<string>();
            _ramTypeItems = new List<string>();
        }
    }
}
