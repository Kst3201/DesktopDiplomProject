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
    public class RAMTypePageViewModel : ObservableViewModel
    {
        private IGComponent<RAMTypeDTO> _gateway;
        private IRAMTypeCreator _creator;
        private RAMTypeViewModel _redactedItem;
        private string? _redactOldItem;
        private List<RAMTypeViewModel> _items;
        private RelayCommand? _saveCommand;
        private RelayCommand? _cancelCommand;
        private RelayParamCommand? _removeCommand;
        private RelayParamCommand? _redactCommand;

        public string ComponentType => $"Тип оперативной памяти";

        public RAMTypeViewModel RedactedItem
        {
            get => _redactedItem;
            set => SetProperty(ref _redactedItem, value);
        }

        public IReadOnlyList<RAMTypeViewModel> Items => _items;

        public ICommand? SaveCommand => _saveCommand;
        public ICommand? CancelCommand => _cancelCommand;
        public ICommand? RemoveCommand => _removeCommand;
        public ICommand? RedactCommand => _redactCommand;

        public RAMTypePageViewModel(IGComponent<RAMTypeDTO> gateway, IRAMTypeCreator creator)
        {
            _gateway = gateway;
            _creator = creator;
            _redactedItem = new RAMTypeViewModel();
            _items = new List<RAMTypeViewModel>();
            InitializeCommands();
        }

        public async Task Initialize()
        {
            await UpdateItems();
        }

        private async Task UpdateItems()
        {
            var list = await _gateway.GetItems();
            var models = list.Select(item => _creator.CreateModel(item)).ToList();
            _items = models.Select(item => _creator.CreateViewModel(item)).ToList();
            OnPropertyChanged(nameof(Items));
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
                RedactedItem = new RAMTypeViewModel();
                _redactOldItem = null;
                CommandManager.InvalidateRequerySuggested();
            }, (_) =>
            {
                return _redactedItem != null && !string.IsNullOrEmpty(_redactedItem.Name);
            });
            _removeCommand = new RelayParamCommand(async (obj) =>
            {
                if (obj is RAMTypeViewModel model)
                {
                    await _gateway.RemoveItem(model.Name);
                }
                _redactOldItem = null;
                await Initialize();
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is RAMTypeViewModel;
            });
            _redactCommand = new RelayParamCommand((obj) =>
            {
                if (obj is RAMTypeViewModel model)
                {
                    _redactOldItem = model.Name;
                    RedactedItem = model;
                }
                CommandManager.InvalidateRequerySuggested();
            }, (obj) =>
            {
                return obj != null && obj is RAMTypeViewModel;
            });
        }
    }
}
