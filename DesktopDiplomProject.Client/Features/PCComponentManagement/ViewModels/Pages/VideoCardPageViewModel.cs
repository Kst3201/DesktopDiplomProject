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
    public class VideoCardPageViewModel : ObservableViewModel
    {
        private IGComponent<VideoCardDTO> _gateway;
        private IGComponent<GPUDTO> _gatewayGPU;
        private GComponentNamedUnit _gatewayUnits;
        private IVideoCardCreator _creator;
        private INamedUnitCreator _creatorUnits;
        private VideoCardViewModel _redactedItem;
        private string? _redactOldItem;
        private List<VideoCardViewModel> _items;
        private List<string> _gpuItems;
        private List<string> _pcieInterfaceItems;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        private RelayParamCommand? _removeCommand;
        private RelayParamCommand? _redactCommand;

        public string ComponentType => $"Видеокарта";
        public VideoCardViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }
        public IReadOnlyList<VideoCardViewModel> Items => _items;
        public IReadOnlyList<string> GPUItems => _gpuItems;
        public IReadOnlyList<string> PCIEInterfaceItems => _pcieInterfaceItems;

        public ICommand? SaveCommand => _saveCommand;
        public ICommand? CancelCommand => _cancelCommand;
        public ICommand? RemoveCommand => _removeCommand;
        public ICommand? RedactCommand => _redactCommand;

        public VideoCardPageViewModel(IGComponent<VideoCardDTO> gateway, IGComponent<GPUDTO> gatewayGPU
            , GComponentNamedUnit gatewayUnits
            , IVideoCardCreator creator, INamedUnitCreator creatorUnits) : base()
        {
            _gateway = gateway;
            _gatewayGPU = gatewayGPU;
            _gatewayUnits = gatewayUnits;
            _creator = creator;
            _creatorUnits = creatorUnits;
            _redactedItem = new VideoCardViewModel();
            _items = new List<VideoCardViewModel>();
            _gpuItems = new List<string>();
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
            var gpus = (await _gatewayGPU.GetItems()).ToList();
            _gpuItems = gpus.Select(item => item.Name).ToList();
            _pcieInterfaceItems = (await GetNamedUnitsList(ComponentUnitTypes.PCIEInterface)).ToList();
            OnPropertyChanged(nameof(GPUItems));
            OnPropertyChanged(nameof(PCIEInterfaceItems));
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
                RedactedItem = new VideoCardViewModel();
                _redactOldItem = null;
                CommandManager.InvalidateRequerySuggested();
            }, (_) =>
            {
                return _redactedItem != null && !string.IsNullOrEmpty(_redactedItem.Name);
            });
            _removeCommand = new RelayParamCommand(async (obj) =>
            {
                if (obj is VideoCardViewModel model)
                {
                    await _gateway.RemoveItem(model.Name);
                }
                _redactOldItem = null;
                await UpdateItems();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is VideoCardViewModel;
            });
            _redactCommand = new RelayParamCommand((obj) =>
            {
                if (obj is VideoCardViewModel model)
                {
                    _redactOldItem = model.Name;
                    RedactedItem = model;
                }
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is VideoCardViewModel;
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
