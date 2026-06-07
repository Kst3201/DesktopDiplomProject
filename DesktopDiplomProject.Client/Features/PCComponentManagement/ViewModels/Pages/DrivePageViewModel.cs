using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Pages
{
    public class DrivePageViewModel : ObservableViewModel
    {
        private IGComponent<DriveDTO> _gateway;
        private GComponentNamedUnit _gatewayUnits;
        private IDriveCreator _creator;
        private INamedUnitCreator _creatorUnits;
        private DriveViewModel _redactedItem;
        private string? _redactOldItem;
        private List<DriveViewModel> _items;
        private List<string> _connectionInterfaceItems;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        private RelayParamCommand? _removeCommand;
        private RelayParamCommand? _redactCommand;

        public string ComponentType => $"Накопитель";

        public DriveViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<DriveViewModel> Items => _items;

        public IReadOnlyList<string> ConnectionInterfaceItems => _connectionInterfaceItems;

        public ICommand? SaveCommand => _saveCommand;
        public ICommand? CancelCommand => _cancelCommand;
        public ICommand? RemoveCommand => _removeCommand;
        public ICommand? RedactCommand => _redactCommand;

        public DrivePageViewModel(IGComponent<DriveDTO> gateway, GComponentNamedUnit gatewayUnits
            , IDriveCreator creator, INamedUnitCreator creatorUnits) : base()
        {
            _gateway = gateway;
            _gatewayUnits = gatewayUnits;
            _creator = creator;
            _creatorUnits = creatorUnits;
            _redactedItem = new DriveViewModel();
            _items = new List<DriveViewModel>();
            _connectionInterfaceItems = new List<string>();
            InitializeCommands();
        }

        public async Task Initialize()
        {
            await Task.WhenAll(UpdateItems(), InitializeUnitItems());
        }

        private async Task UpdateItems()
        {
            var list = await _gateway.GetItems();
            var models = list.Select(item => _creator.CreateModel(item)).ToList();
            _items = models.Select(item => _creator.CreateViewModel(item)).ToList();
            OnPropertyChanged(nameof(Items));
        }

        private async Task InitializeUnitItems()
        {
            _connectionInterfaceItems = (await GetNamedUnitsList(ComponentUnitTypes.DriveConnectionInterface)).ToList();
            OnPropertyChanged(nameof(ConnectionInterfaceItems));
        }

        private void InitializeCommands()
        {
            _saveCommand = new RelayCommand(async () =>
            {
                var newModel = _creator.CreateModel(RedactedItem);
                var newDTO = _creator.CreateDTO(newModel);
                if (string.IsNullOrEmpty(_redactOldItem))
                    await _gateway.AddItem(newDTO);
                else
                    await _gateway.UpdateItem(_redactOldItem, newDTO);
                _redactOldItem = null;
                await Initialize();
                CommandManager.InvalidateRequerySuggested();
            }, (_) =>
            {
                return _redactedItem != null && !string.IsNullOrEmpty(_redactedItem.Name);
            });
            _cancelCommand = new RelayCommand(() =>
            {
                RedactedItem = new DriveViewModel();
                _redactOldItem = null;
                CommandManager.InvalidateRequerySuggested();
            }, (_) =>
            {
                return _redactedItem != null && !string.IsNullOrEmpty(_redactedItem.Name);
            });
            _removeCommand = new RelayParamCommand(async (obj) =>
            {
                if (obj is DriveViewModel model)
                {
                    await _gateway.RemoveItem(model.Name);
                }
                _redactOldItem = null;
                await UpdateItems();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is DriveViewModel;
            });
            _redactCommand = new RelayParamCommand((obj) =>
            {
                if (obj is DriveViewModel model)
                {
                    _redactOldItem = model.Name;
                    RedactedItem = model;
                }
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is DriveViewModel;
            });
        }

        private async Task<IEnumerable<string>> GetNamedUnitsList(ComponentUnitTypes unitType)
        {
            _gatewayUnits.SetUnit(unitType);
            var result = await _gatewayUnits.GetItems();
            return result.Select(item => item.Name);
        }
    }
}
