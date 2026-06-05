using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages
{
    public class RAMPageViewModel : ObservableViewModel
    {
        private RAMViewModel _redactedItem;
        private List<RAMViewModel> _items;
        private List<string> _ramTypeItems;

        private string ComponentType => $"Оперативня память";

        public RAMViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }
        public IReadOnlyList<RAMViewModel> Items => _items;
        public IReadOnlyList<string> RAMTypeItems => _ramTypeItems;

        public RAMPageViewModel()
        {
            _redactedItem = new RAMViewModel();
            _items = new List<RAMViewModel>();
            _ramTypeItems = new List<string>();
        }
    }
}
