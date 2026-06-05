using DesktopDiplomProject.Client.Abstractions;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public class NativeComponentNamedUnitViewModel : ObservableViewModel, IComponentNamedUnitViewModel
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public NativeComponentNamedUnitViewModel(string name)
        {
            _name = name;
        }
    }
}
