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
    public class VideoCardPageViewModel : ObservableViewModel
    {
        private VideoCardViewModel _redactedItem;
        private List<VideoCardViewModel> _items;
        private List<string> _gpuItems;
        private List<string> _pcieInterfaceItems;

        public string ComponentType => $"Видеокарта";
        public VideoCardViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }
        public IReadOnlyList<VideoCardViewModel> Items => _items;
        public IReadOnlyList<string> GPUItems => _gpuItems;
        public IReadOnlyList<string> PCIEInterfaceItems => _pcieInterfaceItems;

        public VideoCardPageViewModel() : base()
        {
            _redactedItem = new VideoCardViewModel();
            _items = new List<VideoCardViewModel>();
            _gpuItems = new List<string>();
            _pcieInterfaceItems = new List<string>();
        }
    }
}
