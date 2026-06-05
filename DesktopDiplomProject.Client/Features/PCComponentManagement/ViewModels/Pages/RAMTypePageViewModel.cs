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
    public class RAMTypePageViewModel : ObservableViewModel
    {
        private RAMTypeViewModel _redactedItem;
        private List<RAMTypeViewModel> _items;

        public string ComponentType => $"Тип оперативной памяти";

        public RAMTypeViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<RAMTypeViewModel> Items => _items;

        public RAMTypePageViewModel()
        {
            _redactedItem = new RAMTypeViewModel();
            _items = new List<RAMTypeViewModel>();
        }
    }
}
