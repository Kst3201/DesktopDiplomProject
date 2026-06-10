using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Gateway;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models.CopmonentPlugs;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Services;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.ComponentConfiguration;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Views.Pages;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCBuild;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages
{
    public class ComponentsSelectionViewModel : ObservableViewModel
    {
        private GPCPreset _gatewayPreset;
        private INavigationPageService _navigationPageService;
        private IUserPCStateService _userPCStateService;
        private IPCSelectConfigurateStateService _configService;
        private RelayCommand? _nextPageCommand;
        private Dictionary<Type, IPlugViewModel> _plugModules;
        private Dictionary<string, IPCPresetDTO?> _selectionMods;
        private Dictionary<FuzzyAssessments, string> _assessmentItems;
        private FuzzyAssessments _selectedAssessment;
        private IPCPresetDTO? _selectedPCPreset;
        private double _totalBudget;
        private double _minBudget;
        private double _maxBudget;
        private bool _isChecked;

        public ICommand? NextPageCommand => _nextPageCommand;

        public IReadOnlyList<IPlugViewModel> PlugModules => _plugModules.Values.ToList();

        public IReadOnlyDictionary<string, IPCPresetDTO?> SelectionMods
        {
            get => _selectionMods ?? new Dictionary<string, IPCPresetDTO?>();
        }

        public IReadOnlyDictionary<FuzzyAssessments, string> AssessmentItems
        {
            get => _assessmentItems;
        }

        public IPCPresetDTO? SelectedMod
        {
            get => _selectedPCPreset;
            set => SetProperty(ref _selectedPCPreset, value);
        }

        public FuzzyAssessments SelectedAssessment
        {
            get => _selectedAssessment;
            set => SetProperty(ref _selectedAssessment, value);
        }

        public double Budget
        {
            get => _totalBudget;
            set => SetProperty(ref _totalBudget, value);
        }

        public double MinBudget
        {
            get => _minBudget;
        }

        public double MaxBudget
        {
            get => _maxBudget;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value, action: () =>
            {
                foreach (var model in PlugModules)
                {
                    model.IsUpgrading = value;
                }
            });
        }

        public ComponentsSelectionViewModel(INavigationPageService navigationPageService
            , IUserPCStateService userPCStateService
            , IPCSelectConfigurateStateService configService, GPCPreset gPreset)
        {
            _navigationPageService = navigationPageService;
            _userPCStateService = userPCStateService;
            _configService = configService;
            _gatewayPreset = gPreset;
            InitializeCommands();
            _selectionMods = new Dictionary<string, IPCPresetDTO?>();
            _selectedPCPreset = null;
            _plugModules = new Dictionary<Type, IPlugViewModel>()
            {
                [typeof(CPUModel)] = new NativePlugViewModel("Центральный процессор"),
                [typeof(DriveModel)] = new NativePlugViewModel("Накопитель"),
                [typeof(MotherboardModel)] = new NativePlugViewModel("Материнская плата"),
                [typeof(RAMModel)] = new NativePlugViewModel("Оперативная память"),
                [typeof(VideoCardModel)] = new NativePlugViewModel("Видеокарта")
            };
            _assessmentItems = new Dictionary<FuzzyAssessments, string>()
            {
                [FuzzyAssessments.Worst] = "Худшее",
                [FuzzyAssessments.Bad] = "Плохое",
                [FuzzyAssessments.Usual] = "Обычное",
                [FuzzyAssessments.Good] = "Хорошее",
                [FuzzyAssessments.Excellent] = "Лучшее"
            };
            _selectedAssessment = _assessmentItems.LastOrDefault().Key;
            _totalBudget = 10000;
            _minBudget = 0;
            _maxBudget = 10000000;
        }

        public async void InitializeSelectionMods()
        {
            var list = (await _gatewayPreset.GetPresets()).Cast<IPCPresetDTO>()
                .ToList();
            _selectionMods = new Dictionary<string, IPCPresetDTO?>();
            foreach (var item in list)
            {
                _selectionMods[item.Name] = item;
            }
            _selectedPCPreset = (_selectionMods?.FirstOrDefault())?.Value;
            OnPropertyChanged(nameof(SelectionMods));
        }

        public void InitializeCommands()
        {
            _nextPageCommand = new RelayCommand(() => _navigationPageService?.ShowScopedPage<SelectionPCPage>());
        }

        public async void Unload()
        {
            var cpu = GetCPUPlug();
            var drive = GetDrivePlug();
            var mother = GetMotherboardPlug();
            var ram = GetRAMPlug();
            var video = GetVideoCardPlug();
            var preset = SelectedMod ?? new NativePCPresetDTO();
            var config = new PCSelectConfigurationSet(preset, Budget, SelectedAssessment)
            {
                CPU = cpu,
                Drive = drive,
                Motherboard = mother,
                RAM = ram,
                VideoCard = video
            };
            _configService.SetConfiguration(config);
        }

        private CPUPlugModel? GetCPUPlug()
        {
            CPUPlugModel? result = null;
            if (_plugModules.TryGetValue(typeof(CPUModel), out var plug))
            {
                if (plug != null)
                {
                    if (plug.IsUpgrading)
                    {
                        result = new CPUPlugModel()
                        {
                            Item = null,
                            MaxPrice = plug.Price,
                            Assessment = plug.Assessment
                        };
                    }
                    else
                    {
                        CPUModel? model = _userPCStateService?.UserPC?.CPU;
                        result = new CPUPlugModel()
                        {
                            Item = model,
                            MaxPrice = null,
                            Assessment = null
                        };
                    }
                }
            }
            return result;
        }

        private DrivePlugModel? GetDrivePlug()
        {
            DrivePlugModel? result = null;
            if (_plugModules.TryGetValue(typeof(DriveModel), out var plug))
            {
                if (plug != null)
                {
                    if (plug.IsUpgrading)
                    {
                        result = new DrivePlugModel()
                        {
                            Item = null,
                            MaxPrice = plug.Price,
                            Assessment = plug.Assessment
                        };
                    }
                    else
                    {
                        DriveModel? model = _userPCStateService?.UserPC?.Drive;
                        result = new DrivePlugModel()
                        {
                            Item = model,
                            MaxPrice = null,
                            Assessment = null
                        };
                    }
                }
            }
            return result;
        }

        private MotherboardPlugModel? GetMotherboardPlug()
        {
            MotherboardPlugModel? result = null;
            if (_plugModules.TryGetValue(typeof(MotherboardModel), out var plug))
            {
                if (plug != null)
                {
                    if (plug.IsUpgrading)
                    {
                        result = new MotherboardPlugModel()
                        {
                            Item = null,
                            MaxPrice = plug.Price,
                            Assessment = plug.Assessment
                        };
                    }
                    else
                    {
                        MotherboardModel? model = _userPCStateService?.UserPC?.Motherboard;
                        result = new MotherboardPlugModel()
                        {
                            Item = model,
                            MaxPrice = null,
                            Assessment = null
                        };
                    }
                }
            }
            return result;
        }

        private RAMPlugModel? GetRAMPlug()
        {
            RAMPlugModel? result = null;
            if (_plugModules.TryGetValue(typeof(RAMModel), out var plug))
            {
                if (plug != null)
                {
                    if (plug.IsUpgrading)
                    {
                        result = new RAMPlugModel()
                        {
                            Item = null,
                            MaxPrice = plug.Price,
                            Assessment = plug.Assessment
                        };
                    }
                    else
                    {
                        RAMModel? model = _userPCStateService?.UserPC?.RAM;
                        result = new RAMPlugModel()
                        {
                            Item = model,
                            MaxPrice = null,
                            Assessment = null
                        };
                    }
                }
            }
            return result;
        }

        private VideoCardPlugModel? GetVideoCardPlug()
        {
            VideoCardPlugModel? result = null;
            if (_plugModules.TryGetValue(typeof(VideoCardModel), out var plug))
            {
                if (plug != null)
                {
                    if (plug.IsUpgrading)
                    {
                        result = new VideoCardPlugModel()
                        {
                            Item = null,
                            MaxPrice = plug.Price,
                            Assessment = plug.Assessment
                        };
                    }
                    else
                    {
                        VideoCardModel? model = _userPCStateService?.UserPC?.VideoCard;
                        result = new VideoCardPlugModel()
                        {
                            Item = model,
                            MaxPrice = null,
                            Assessment = null
                        };
                    }
                }
            }
            return result;
        }
    }
}
