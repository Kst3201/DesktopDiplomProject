using DesktopDiplomProject.Client.Abstractions;
using DesktopDiplomProject.Client.Commands;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Services;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer;
using DesktopDiplomProject.Client.Services.Navigation.Page;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.Pages
{
    public class UserPCViewModel : ObservableViewModel
    {
        private IGComponent<CPUDTO> _gatewayCPU;
        private IGComponent<DriveDTO> _gatewayDrive;
        private IGComponent<MotherboardDTO> _gatewayMotherboard;
        private IGComponent<RAMDTO> _gatewayRAM;
        private IGVideoCard _gatewayVideoCard;
        private IGComponent<RAMTypeDTO> _gatewayRAMType;
        private IGComponent<GPUDTO> _gatewayGPU;
        private GComponentNamedUnit _gatewayUnits;
        private IPCCreator _pcCreator;
        private IUserPCService _userPCService;
        private IUserPCStateService _userPCState;
        private IPCViewModel? _sourcePC;
        private IPCViewModel? _suspectedPC;
        private List<string> _socketItems;
        private List<string> _driveConnectionInterfaceItems;
        private List<string> _pcieItems;
        private List<string> _sizeItems;
        private List<string> _ramTypeItems;
        private List<string> _gpuItems;
        private bool _isSourcePC;

        public IPCViewModel? SourcePC
        {
            get => _sourcePC;
            set => SetProperty(ref _sourcePC, value);
        }

        public IPCViewModel? SuspectedPC
        {
            get => _suspectedPC;
            set => SetProperty(ref _suspectedPC, value);
        }

        public IReadOnlyList<string> SocketItems => _socketItems;
        public IReadOnlyList<string> DriveConnectionInterfaceItems => _driveConnectionInterfaceItems;
        public IReadOnlyList<string> PCIEInterfaceItems => _pcieItems;
        public IReadOnlyList<string> SizeItems => _sizeItems;
        public IReadOnlyList<string> RAMTypeItems => _ramTypeItems;
        public IReadOnlyList<string> GPUItems => _gpuItems;

        public bool IsSourcePC
        {
            get => _isSourcePC;
            set => SetProperty(ref _isSourcePC, value);
        }

        public UserPCViewModel(IGComponent<CPUDTO> gCPU, IGComponent<DriveDTO> gDrive
            , IGComponent<MotherboardDTO> gMotherboard, IGComponent<RAMDTO> gRAM, IGVideoCard gVideoCard
            , IGComponent<RAMTypeDTO> gRAMType, IGComponent<GPUDTO> gGPU, GComponentNamedUnit gUnit
            , IUserPCService userPCService, IUserPCStateService userPCState)
        {
            _isSourcePC = true;
            _gatewayCPU = gCPU;
            _gatewayDrive = gDrive;
            _gatewayMotherboard = gMotherboard;
            _gatewayRAM = gRAM;
            _gatewayVideoCard = gVideoCard;
            _gatewayRAMType = gRAMType;
            _gatewayGPU = gGPU;
            _gatewayUnits = gUnit;
            _pcCreator = new NativePCCreator();
            _userPCService = userPCService;
            _userPCState = userPCState;
            _socketItems = new List<string>();
            _driveConnectionInterfaceItems = new List<string>();
            _sizeItems = new List<string>();
            _pcieItems = new List<string>();
            _ramTypeItems = new List<string>();
            _gpuItems = new List<string>();
        }

        public async Task Initialize()
        {
            await InitializeItems();

        }

        public async Task InitializeItems()
        {
            var socketTask = GetNamedUnitsList(ComponentUnitTypes.Socket);
            var driveTask = GetNamedUnitsList(ComponentUnitTypes.DriveConnectionInterface);
            var sizeTask = GetNamedUnitsList(ComponentUnitTypes.MotherboardSize);
            var pcieTask = GetNamedUnitsList(ComponentUnitTypes.PCIEInterface);
            var ramTypeTask = _gatewayRAMType.GetItems();
            var gpuTask = _gatewayGPU.GetItems();
            await Task.WhenAll(socketTask, driveTask, sizeTask, pcieTask, ramTypeTask, gpuTask);
            _socketItems = socketTask.Result.ToList();
            _driveConnectionInterfaceItems = driveTask.Result.ToList();
            _sizeItems = sizeTask.Result.ToList();
            _pcieItems = pcieTask.Result.ToList();
            _ramTypeItems = ramTypeTask.Result.Where(item => item != null).Select(item => item.Name).ToList();
            _ramTypeItems.Add(string.Empty);
            _gpuItems = gpuTask.Result.Select(item => item.Name).ToList();
            _gpuItems.Add(string.Empty);
            OnPropertyChanged(nameof(SocketItems));
            OnPropertyChanged(nameof(DriveConnectionInterfaceItems));
            OnPropertyChanged(nameof(SizeItems));
            OnPropertyChanged(nameof(PCIEInterfaceItems));
            OnPropertyChanged(nameof(RAMTypeItems));
            OnPropertyChanged(nameof(GPUItems));
        }

        public async Task InitializeUserPC()
        {
            var model = await _userPCService.GetUserPC();
            SourcePC =  _pcCreator.Create(model);
            SuspectedPC = _pcCreator.Create(model);
            var cpu = _gatewayCPU.GetItemByFullname(SuspectedPC.CPU.Name);
            var drive = _gatewayDrive.GetItemByFullname(SuspectedPC.Drive.Name);
            var motherboard = _gatewayMotherboard.GetItemByFullname(SuspectedPC.Motherboard.Name);
            var ram = _gatewayRAM.GetItemByFullname(SuspectedPC.RAM.Name);
            var gpu = _gatewayVideoCard.GetItemByGPU(SuspectedPC.VideoCard.GPU);
            await Task.WhenAll(cpu, drive, motherboard, ram, gpu);
            AcceptCPU(cpu.Result);
            AcceptDrive(drive.Result);
            AcceptMotherboard(motherboard.Result);
            AcceptRAM(ram.Result);
            AcceptVideoCard(gpu.Result);
        }

        public async Task Unload()
        {
            await Task.Run(() =>
            {
                var viewModel = _isSourcePC ? _sourcePC : _suspectedPC;
                var model = _pcCreator.Create(viewModel);
                _userPCState.UserPC = model;
            });
        }

        private void AcceptCPU(CPUDTO cpu)
        {
            if (SuspectedPC == null || cpu == null || string.IsNullOrEmpty(cpu.Name)) return;
            var viewModel = SuspectedPC.CPU;
            viewModel.Name = cpu.Name;
            viewModel.Manufacturer = cpu.Manufacturer;
            viewModel.Model = cpu.Model;
            viewModel.Socket = cpu.Socket;
            viewModel.RAMType = cpu.RAMType;
            viewModel.BaseFrequency = cpu.BaseFrequency;
            viewModel.CountCores = cpu.CountCores;
            viewModel.CountThreads = cpu.CountThreads;
            viewModel.TotalScore = cpu.TotalScore;
        }

        private void AcceptDrive(DriveDTO drive)
        {
            if (SuspectedPC == null || drive == null || string.IsNullOrEmpty(drive.Name)) return;
            var viewModel = SuspectedPC.Drive;
            viewModel.Name = drive.Name;
            viewModel.Manufacturer = drive.Manufacturer;
            viewModel.Model = drive.Model;
            viewModel.Capacity = drive.Capacity;
            viewModel.SpeedDataTransfer = drive.SpeedDataTransfer;
            viewModel.ConnectionInterface = drive.ConnectorInterface;
            viewModel.TotalScore = drive.TotalScore;
        }

        private void AcceptMotherboard(MotherboardDTO board)
        {
            if (SuspectedPC == null || board == null || string.IsNullOrEmpty(board.Name)) return;
            var viewModel = SuspectedPC.Motherboard;
            viewModel.Name = board.Name;
            viewModel.Manufacturer = board.Manufacturer;
            viewModel.Model = board.Model;
            viewModel.Size = board.Size;
            viewModel.Socket = board.Socket;
            viewModel.RAMType = board.RAMType;
            viewModel.PCIEInterface = board.PCIEInterface;
            viewModel.RAMCountSlots = board.RAMCountSlots;
            viewModel.MaxRAMValue = board.MaxRAMValue;
            viewModel.MaxRAMFrequency = board.MaxRAMFrequency;
            viewModel.CountPCIEX16Slots = board.CountPCIEX16Slots;
            viewModel.CountM2Slots = board.CountM2Slots;
            viewModel.CountSATASlots = board.CountSATASlots;
            viewModel.TotalScore = board.TotalScore;
        }

        private void AcceptRAM(RAMDTO ram)
        {
            if (SuspectedPC == null || ram == null || string.IsNullOrEmpty(ram.Name)) return;
            var viewModel = SuspectedPC.RAM;
            viewModel.Name = ram.Name;
            viewModel.Manufacturer = ram.Manufacturer;
            viewModel.Model = ram.Model;
            viewModel.RAMType = ram.RAMType;
            viewModel.SingleModuleCapacity = ram.SingleModuleCapacity;
            viewModel.CountModules = ram.CountModules;
            viewModel.Frequency = ram.Frequency;
            viewModel.TotalScore = ram.TotalScore;
        }

        private void AcceptVideoCard(VideoCardDTO video)
        {
            if (SuspectedPC == null || video == null || string.IsNullOrEmpty(video.Name)) return;
            var viewModel = SuspectedPC.VideoCard;
            viewModel.Name = video.Name;
            viewModel.Manufacturer = video.Manufacturer;
            viewModel.Model = video.Model;
            viewModel.GPU = video.GPU;
            viewModel.PCIEInterface = video.PCIEInterface;
            viewModel.CountPCIELines = video.CountPCIELines;
            viewModel.RecommendedBlockPower = video.RecommendedBlockPower;
            viewModel.CountPinsAdditionalPower = video.CountPinsAdditionalPower;
            viewModel.CapacityVideoMemory = video.CapacityVideoMemory;
            viewModel.MaxThroughputCapacity = video.MaxThroughputCapacity;
            viewModel.MemoryFrequency = video.MemoryFrequency;
            viewModel.CountMonitors = video.CountMonitors;
            viewModel.TotalScore = video.TotalScore;
            if (string.IsNullOrEmpty(SuspectedPC.Motherboard.PCIEInterface))
            {
                SuspectedPC.Motherboard.PCIEInterface = video.PCIEInterface;
            }
        }

        private async Task<IEnumerable<string>> GetNamedUnitsList(ComponentUnitTypes unitType)
        {
            _gatewayUnits.SetUnit(unitType);
            var dtos = await _gatewayUnits.GetItems();
            var result = dtos.Select(item => item.Name).ToList();
            result.Insert(0, string.Empty);
            return result;
        }


    }
}
