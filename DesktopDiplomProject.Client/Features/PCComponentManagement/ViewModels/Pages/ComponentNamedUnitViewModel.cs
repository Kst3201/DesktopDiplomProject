using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Services;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages
{
    public class ComponentNamedUnitViewModel : ObservableViewModel
    {
        private NativeComponentNamedUnitViewModel _redactedItem;
        private List<NativeComponentNamedUnitViewModel> _items;

        public NativeComponentNamedUnitViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<NativeComponentNamedUnitViewModel> Items => _items;

        public ComponentNamedUnitViewModel()
        {
            _redactedItem = new NativeComponentNamedUnitViewModel(string.Empty);
            _items = new List<NativeComponentNamedUnitViewModel>();
        }
    }
}
