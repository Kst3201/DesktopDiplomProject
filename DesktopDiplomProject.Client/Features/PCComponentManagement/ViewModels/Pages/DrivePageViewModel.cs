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
    public class DrivePageViewModel : ObservableViewModel
    {
        private DriveViewModel _redactedItem;
        private List<DriveViewModel> _items;
        private List<string> _connectionInterfaceItems;

        public string ComponentType => $"Накопитель";

        public DriveViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<DriveViewModel> Items => _items;

        public IReadOnlyList<string> ConnectionInterfaceItems => _connectionInterfaceItems;

        public DrivePageViewModel() : base()
        {
            _redactedItem = new DriveViewModel();
            _items = new List<DriveViewModel>();
            _connectionInterfaceItems = new List<string>();
        }
    }
}
