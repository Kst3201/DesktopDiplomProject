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
    public class RAMPageViewModel : ObservableViewModel
    {
        private IGComponent<RAMDTO> _gateway;
        private IGComponent<RAMTypeDTO> _gatewayRAMType;
        private GComponentNamedUnit _gatewayUnits;
        private IRAMCreator _creator;
        private INamedUnitCreator _creatorUnits;
        private RAMViewModel _redactedItem;
        private string? _redactOldItem;
        private List<RAMViewModel> _items;
        private List<string> _ramTypeItems;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        private RelayParamCommand? _removeCommand;
        private RelayParamCommand? _redactCommand;

        public string ComponentType => $"Оперативня память";

        public RAMViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }
        public IReadOnlyList<RAMViewModel> Items => _items;
        public IReadOnlyList<string> RAMTypeItems => _ramTypeItems;

        public ICommand? SaveCommand => _saveCommand;
        public ICommand? CancelCommand => _cancelCommand;
        public ICommand? RemoveCommand => _removeCommand;
        public ICommand? RedactCommand => _redactCommand;

        public RAMPageViewModel(IGComponent<RAMDTO> gateway, IGComponent<RAMTypeDTO> gatewayRAMType
            , GComponentNamedUnit gatewayUnits
            , IRAMCreator creator, INamedUnitCreator creatorUnits)
        {
            _gateway = gateway;
            _gatewayRAMType = gatewayRAMType;
            _gatewayUnits = gatewayUnits;
            _creator = creator;
            _creatorUnits = creatorUnits;
            _redactedItem = new RAMViewModel();
            _items = new List<RAMViewModel>();
            _ramTypeItems = new List<string>();
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
            var ramTypes = await _gatewayRAMType.GetItems();
            _ramTypeItems = ramTypes.Where(item => item != null).Select(item => item.Name).ToList();
            OnPropertyChanged(nameof(RAMTypeItems));
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
                RedactedItem = new RAMViewModel();
                _redactOldItem = null;
                CommandManager.InvalidateRequerySuggested();
            }, (_) =>
            {
                return _redactedItem != null && !string.IsNullOrEmpty(_redactedItem.Name);
            });
            _removeCommand = new RelayParamCommand(async (obj) =>
            {
                if (obj is RAMViewModel model)
                {
                    await _gateway.RemoveItem(model.Name);
                }
                _redactOldItem = null;
                await UpdateItems();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is RAMViewModel;
            });
            _redactCommand = new RelayParamCommand((obj) =>
            {
                if (obj is RAMViewModel model)
                {
                    _redactOldItem = model.Name;
                    RedactedItem = model;
                }
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is RAMViewModel;
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
