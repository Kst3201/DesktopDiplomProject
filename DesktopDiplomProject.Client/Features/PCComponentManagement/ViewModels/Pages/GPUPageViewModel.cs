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
    public class GPUPageViewModel : ObservableViewModel
    {
        private GPUViewModel _redactedItem;
        private List<GPUViewModel> _items;

        public string ComponentType => $"Графический процессор";

        public GPUViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<GPUViewModel> Items => _items;

        public GPUPageViewModel() : base()
        {
            _redactedItem = new GPUViewModel();
            _items = new List<GPUViewModel>();
        }
    }
}
