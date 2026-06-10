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
    public class MotherboardPageViewModel : ObservableViewModel
    {
        private IGComponent<MotherboardDTO> _gateway;
        private IGComponent<RAMTypeDTO> _gatewayRAMType;
        private GComponentNamedUnit _gatewayUnits;
        private IMotherboardCreator _creator;
        private INamedUnitCreator _creatorUnits;
        private MotherboardViewModel _redactedItem;
        private string? _redactOldItem;
        private List<MotherboardViewModel> _items;
        private List<string> _sizeItems;
        private List<string> _socketItems;
        private List<string> _ramTypeItems;
        private List<string> _pcieInterfaceItems;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        private RelayParamCommand? _removeCommand;
        private RelayParamCommand? _redactCommand;

        public string ComponentType => $"Материнская плата";

        public MotherboardViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }
        public IReadOnlyList<MotherboardViewModel> Items => _items;
        public IReadOnlyList<string> SizeItems => _sizeItems;
        public IReadOnlyList<string> SocketItems => _socketItems;
        public IReadOnlyList<string> RAMTypeItems => _ramTypeItems;
        public IReadOnlyList<string> PCIEInterfaceItems => _pcieInterfaceItems;

        public ICommand? SaveCommand => _saveCommand;
        public ICommand? CancelCommand => _cancelCommand;
        public ICommand? RemoveCommand => _removeCommand;
        public ICommand? RedactCommand => _redactCommand;

        public MotherboardPageViewModel(IGComponent<MotherboardDTO> gateway, IGComponent<RAMTypeDTO> gatewayRAMType
            , GComponentNamedUnit gatewayUnits, IMotherboardCreator creator, INamedUnitCreator creatorUnits) : base()
        {
            _gateway = gateway;
            _gatewayRAMType = gatewayRAMType;
            _gatewayUnits = gatewayUnits;
            _creator = creator;
            _creatorUnits = creatorUnits;
            _redactedItem = new MotherboardViewModel();
            _items = new List<MotherboardViewModel>();
            _sizeItems = new List<string>();
            _socketItems = new List<string>();
            _ramTypeItems = new List<string>();
            _pcieInterfaceItems = new List<string>();
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
            _socketItems = (await GetNamedUnitsList(ComponentUnitTypes.Socket)).ToList();
            _sizeItems = (await GetNamedUnitsList(ComponentUnitTypes.MotherboardSize)).ToList();
            _pcieInterfaceItems = (await GetNamedUnitsList(ComponentUnitTypes.PCIEInterface)).ToList();
            var ramTypes = await _gatewayRAMType.GetItems();
            _ramTypeItems = ramTypes.Where(item => item != null).Select(item => item.Name).ToList();
            _ramTypeItems.Add(string.Empty);
            OnPropertyChanged(nameof(SocketItems));
            OnPropertyChanged(nameof(RAMTypeItems));
            OnPropertyChanged(nameof(PCIEInterfaceItems));
            OnPropertyChanged(nameof(SizeItems));
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
                RedactedItem = new MotherboardViewModel();
                _redactOldItem = null;
                CommandManager.InvalidateRequerySuggested();
            }, (_) =>
            {
                return _redactedItem != null && !string.IsNullOrEmpty(_redactedItem.Name);
            });
            _removeCommand = new RelayParamCommand(async (obj) =>
            {
                if (obj is MotherboardViewModel model)
                {
                    await _gateway.RemoveItem(model.Name);
                }
                _redactOldItem = null;
                await UpdateItems();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is MotherboardViewModel;
            });
            _redactCommand = new RelayParamCommand((obj) =>
            {
                if (obj is MotherboardViewModel model)
                {
                    _redactOldItem = model.Name;
                    RedactedItem = model;
                }
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is MotherboardViewModel;
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
