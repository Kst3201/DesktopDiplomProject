using DesktopDiplomProject.ServerASP.Features.Assessment.Comparers;
using DesktopDiplomProject.ServerASP.Features.Assessment.Models;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services;
using DesktopDiplomProject.ServerASP.Features.Assessment.Services.DefuzzifyFunctions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.CPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.GPU;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Motherboard;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Models.PersonalComputers;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Services.OptimizerComponents;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Services.ParetoOptimizers;
using DiplomDataLibrary.Assessments;
using DiplomDataLibrary.PCBuild;
using DiplomDataLibrary.PCBuild.Components;
using DiplomDataLibrary.PCComponents.DTO;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Services.PCBuild
{
    public class PCUpgradeService : IPCUpgradeService
    {
        private const int PCBUFFERSIZE = 10;
        private ICPUService _cpuService;
        private IDriveService _driveService;
        private IGPUService _gpuService;
        private IMotherboardService _motherService;
        private IRAMService _ramService;
        private IVideoCardService _vcService;
        private IDefuzzifyFunction _defuzzFunction;
        private IOptimizerComponents _optimizer;
        private IScoreComparer _comparer;
        private PCCreator _creator;
        public PCUpgradeService(ICPUService cpuServce, IDriveService driveService, IGPUService gpuService, IMotherboardService motherService
            , IRAMService ramService, IVideoCardService vcService, IDefuzzifyFunction defuzzifyFunction)
        {
            _creator = new PCCreator(defuzzifyFunction);
            _cpuService = cpuServce;
            _driveService = driveService;
            _gpuService = gpuService;
            _motherService = motherService;
            _ramService = ramService;
            _vcService = vcService;
            _defuzzFunction = defuzzifyFunction;
            _comparer = new NativeScoreComparer();
            _optimizer = new ParetoOptimizerComponents();
        }


        public async Task<IEnumerable<PCDTO>> UpgradeComputer(PCUpgradeRequest upgradeDTO)
        {
            IPCPresetDTO preset = upgradeDTO.Preset;
            double price = upgradeDTO.MaxPrice ?? double.MaxValue;
            FuzzyAssessments? assessment = upgradeDTO.MinAssessment;
            ICompatibilitySet baseSet = GetSet(upgradeDTO);
            List<CPUModel> cpus = upgradeDTO.CPU?.Item == null 
                ? await GetCPUs(GetPlugCompatibilitySet(baseSet, upgradeDTO.CPU)) : GetListWithLock(upgradeDTO.CPU);
            cpus.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore)) ;
            List<MotherboardModel> motherboards = upgradeDTO.Motherboard?.Item == null
                ? await GetMotherboards(GetPlugCompatibilitySet(baseSet, upgradeDTO.Motherboard))
                : GetListWithLock(upgradeDTO.Motherboard);
            motherboards.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<DriveModel> drives = upgradeDTO.Drive?.Item == null
                ? await GetDrives(GetPlugCompatibilitySet(baseSet, upgradeDTO.Drive)) : GetListWithLock(upgradeDTO.Drive);
            drives.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<RAMModel> rams = upgradeDTO.RAM?.Item == null
                ? await GetRAMs(GetPlugCompatibilitySet(baseSet, upgradeDTO.RAM)) : GetListWithLock(upgradeDTO.RAM);
            rams.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<VideoCardModel> videoCards = upgradeDTO.VideoCard?.Item == null
                ? await GetVideoCard(GetPlugCompatibilitySet(baseSet, upgradeDTO.VideoCard))
                : GetListWithLock(upgradeDTO.VideoCard);
            videoCards.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            PriorityQueue<IPCModel, IScore> result = new PriorityQueue<IPCModel, IScore>(PCBUFFERSIZE, _comparer);
            foreach (var cpu in cpus)
            {
                foreach (var motherboard in motherboards.Where(item => item.Socket.Equals(cpu.Socket)
                            && item.RAMType.Equals(cpu.RAMType)))
                {
                    foreach (var drive in drives)
                    {
                        string intrf = drive.ConnectorInterface.ToLower().Trim();
                        if (intrf == "sata" && motherboard.CountSATASlots <= 0) continue;
                        if (intrf == "m2" && motherboard.CountM2Slots <= 0) continue;
                        foreach (var ram in rams.Where(item => item.RAMType.Equals(cpu.RAMType)))
                        {
                            foreach (var videoCard in videoCards.Where(item => item.PCIEInterface.Equals(motherboard.PCIEInterface)))
                            {
                                double sum = cpu.Price + motherboard.Price + drive.Price + ram.Price + videoCard.Price;
                                if (sum > price * 1.05) continue;
                                IPCModel pc = CreatePCModel(cpu, drive, motherboard, ram, videoCard, sum, preset);
                                if (result.Count < PCBUFFERSIZE)
                                {
                                    result.Enqueue(pc, pc.TotalScore);
                                }
                                else
                                {
                                    result.TryPeek(out IPCModel? worstPC, out IScore? worstScore);
                                    if (worstScore == null || _comparer.Compare(pc.TotalScore, worstScore) > 0)
                                    {
                                        result.Dequeue();
                                        result.Enqueue(pc, pc.TotalScore);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            List<IPCModel> resultList = result.UnorderedItems.Select(x => x.Element).ToList();
            resultList.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            return resultList.Select(item => _creator.CreateDTO(item)).ToList();
        }

        private List<CPUModel> GetListWithLock(CPUPlugDTO cpu)
        {
            if (cpu == null || cpu.Item == null) return new List<CPUModel>();
            var dto = cpu.Item;
            var model = new CPUModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Socket = dto.Socket,
                RAMType = dto.RAMType,
                CountCores = dto.CountCores,
                CountThreads = dto.CountThreads,
                BaseFrequency = dto.BaseFrequency,
                Price = dto.Price,
                TotalScore = new Score()
            };
            return new List<CPUModel> { model };
        }

        private List<DriveModel> GetListWithLock(DrivePlugDTO plug)
        {
            if (plug == null || plug.Item == null) return new List<DriveModel>();
            var dto = plug.Item;
            var model = new DriveModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                ConnectorInterface = dto.ConnectorInterface,
                Capacity = dto.Capacity,
                SpeedDataTransfer = dto.SpeedDataTransfer,
                Price = dto.Price,
                TotalScore = new Score()
            };
            return new List<DriveModel> { model };
        }

        private List<MotherboardModel> GetListWithLock(MotherboardPlugDTO plug)
        {
            if (plug == null || plug.Item == null) return new List<MotherboardModel>();
            var dto = plug.Item;
            var model = new MotherboardModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Size = dto.Size,
                Socket = dto.Socket,
                RAMType = dto.RAMType,
                PCIEInterface = dto.PCIEInterface,
                RAMCountSlots = dto.RAMCountSlots,
                MaxRAMValue = dto.MaxRAMValue,
                MaxRAMFrequency = dto.MaxRAMFrequency,
                CountPCIEX16Slots = dto.CountPCIEX16Slots,
                CountM2Slots = dto.CountM2Slots,
                CountSATASlots = dto.CountSATASlots,
                Price = dto.Price,
                TotalScore = new Score()
            };
            return new List<MotherboardModel> { model };
        }

        private List<RAMModel> GetListWithLock(RAMPlugDTO plug)
        {
            if (plug == null || plug.Item == null) return new List<RAMModel>();
            var dto = plug.Item;
            var model = new RAMModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                RAMType = dto.RAMType,
                SingleModuleCapacity = dto.SingleModuleCapacity,
                CountModules = dto.CountModules,
                Frequency = dto.Frequency,
                Price = dto.Price,
                TotalScore = new Score()
            };
            return new List<RAMModel> { model };
        }

        private List<VideoCardModel> GetListWithLock(VideoCardPlugDTO plug)
        {
            if (plug == null || plug.Item == null) return new List<VideoCardModel>();
            var dto = plug.Item;
            var model = new VideoCardModel()
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                GPU = dto.GPU,
                PCIEInterface = dto.PCIEInterface,
                CountPCIELines = dto.CountPCIELines,
                RecommendedBlockPower = dto.RecommendedBlockPower,
                CountPinsAdditionalPower = dto.CountPinsAdditionalPower,
                CapacityVideoMemory = dto.CapacityVideoMemory,
                MaxThroughputCapacity = dto.MaxThroughputCapacity,
                MemoryFrequency = dto.MemoryFrequency,
                CountMonitors = dto.CountMonitors,
                Price = dto.Price,
                TotalScore = new Score()
            };
            return new List<VideoCardModel> { model };
        }

        private ICompatibilitySet GetSet(PCUpgradeRequest request)
        {
            if (request == null) return new NativeCompatibilitySet();
            var cpuP = request.CPU?.Item;
            var driveP = request.Drive?.Item;
            var motherP = request.Motherboard?.Item;
            var ramP = request.RAM?.Item;
            var videoP = request.VideoCard?.Item;
            string? socket = null, ramType = null, pcie = null;
            List<string> driveInterfaces = new List<string>();
            if (cpuP != null)
            {
                socket = cpuP.Socket;
                ramType = cpuP.RAMType;
            }
            if (driveP != null)
            {
                driveInterfaces.Add(driveP.ConnectorInterface.ToLower());
            }
            if (motherP != null)
            {
                socket = string.IsNullOrWhiteSpace(socket) ? motherP.Socket : motherP.Socket;
                ramType = string.IsNullOrWhiteSpace(ramType) ? motherP.RAMType : ramType;
                pcie = string.IsNullOrWhiteSpace(pcie) ? motherP.PCIEInterface : pcie;
                if (motherP.CountM2Slots > 0 && !driveInterfaces.Contains("m2", StringComparer.OrdinalIgnoreCase))
                    driveInterfaces.Add("m2");
                if (motherP.CountSATASlots > 0 && !driveInterfaces.Contains("sata", StringComparer.OrdinalIgnoreCase))
                    driveInterfaces.Add("sata");
            }
            if (ramP != null)
            {
                ramType = string.IsNullOrWhiteSpace(ramType) ? ramP.RAMType : ramType;
            }
            if (videoP != null)
            {
                pcie = string.IsNullOrWhiteSpace(pcie) ? videoP.PCIEInterface : pcie;
            }
            var result = new NativeCompatibilitySet()
            {
                Socket = socket,
                RAMType = ramType,
                PCIEInterface = pcie,
                DriveConnectionInterfaces = driveInterfaces
            };
            return result;
        }

        private ICompatibilitySet GetPlugCompatibilitySet<T>(ICompatibilitySet set, IComponentPlugDTO<T>? dto)
            where T : BaseComponentNamedUnitDTO
        {
            if (dto == null) return set;
            return new NativeCompatibilitySet()
            {
                Socket = set.Socket,
                RAMType = set.RAMType,
                PCIEInterface = set.PCIEInterface,
                DriveConnectionInterfaces =set.DriveConnectionInterfaces,
                MaxPrice = dto.MaxPrice,
                MinAssessment = dto.MinAssessment
            };
        }

        private async Task<List<CPUModel>> GetCPUs(ICompatibilitySet set)
        {
            List<CPUModel> cpus = (await _cpuService.GetAll(set)).ToList();
            var result = _optimizer.GetOptimizePerGroup<CPUCompatibility, CPUModel>(
                cpus, item => new CPUCompatibility()
                {
                    Socket = item.Socket,
                    RAMType = item.RAMType
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<CPUModel>();
        }

        private async Task<List<MotherboardModel>> GetMotherboards(ICompatibilitySet set)
        {
            List<MotherboardModel> motherboards = (await _motherService.GetAll(set)).ToList();
            var result = await _optimizer.GetOptimizePerGroupAsync(
                motherboards, item => new MotherboardCompatibility()
                {
                    Socket = item.Socket,
                    RAMType = item.RAMType,
                    Size = item.Size,
                    PCIEInterface = item.PCIEInterface,
                    HasM2Slots = item.CountM2Slots > 0,
                    HasSATASlots = item.CountSATASlots > 0
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<MotherboardModel>();
        }

        private async Task<List<DriveModel>> GetDrives(ICompatibilitySet set)
        {
            List<DriveModel> drives = (await _driveService.GetAll(set)).ToList();
            var result = await _optimizer.GetOptimizePerGroupAsync(
                drives, item => new DriveCompatibility()
                {
                    Interface = item.ConnectorInterface
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<DriveModel>();
        }

        private async Task<List<RAMModel>> GetRAMs(ICompatibilitySet set)
        {
            List<RAMModel> rams = (await _ramService.GetAll(set)).ToList();
            var result = await _optimizer.GetOptimizePerGroupAsync(
                rams, item => new RAMCompatibility()
                {
                    RAMType = item.RAMType
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<RAMModel>();
        }

        private async Task<List<VideoCardModel>> GetVideoCard(ICompatibilitySet set)
        {
            List<VideoCardModel> videoCards = (await _vcService.GetAll(set)).ToList();
            var result = await _optimizer.GetOptimizePerGroupAsync(
                videoCards, item => new VideoCardCompatibility()
                {
                    PCIEInterface = item.PCIEInterface,
                    PCIELines = item.CountPCIELines,
                    AdditionalPowerPins = item.CountPinsAdditionalPower
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<VideoCardModel>();
        }

        private IScore GetTotalScore(CPUModel cpu, DriveModel drive, MotherboardModel mother
            , RAMModel ram, VideoCardModel videoCard, IPCPresetDTO preset)
        {
            ScoreCoefficiented cpuScore = new ScoreCoefficiented(cpu.TotalScore, preset.CPUCoeff);
            ScoreCoefficiented driveScore = new ScoreCoefficiented(drive.TotalScore, preset.DriveCoeff);
            ScoreCoefficiented motherScore = new ScoreCoefficiented(mother.TotalScore, preset.MotherboardCoeff);
            ScoreCoefficiented ramScore = new ScoreCoefficiented(ram.TotalScore, preset.RAMCoeff);
            ScoreCoefficiented vcScore = new ScoreCoefficiented(videoCard.TotalScore, preset.VideoCardCoeff);
            List<ScoreCoefficiented> baseList = new List<ScoreCoefficiented>()
            {
                cpuScore,
                driveScore,
                motherScore,
                ramScore,
                vcScore
            };
            IScore result = ReassessmentService.Commulate(baseList.Where(item => item.ScoreOne > 0).ToArray());
            return result;
        }

        private IPCModel CreatePCModel(CPUModel cpu, DriveModel drive, MotherboardModel mother
            , RAMModel ram, VideoCardModel videoCard, double price, IPCPresetDTO preset)
        {
            var nwCPU = cpu.Clone() as CPUModel ?? new CPUModel();
            var nwDrive = drive.Clone() as DriveModel ?? new DriveModel();
            var nwMother = mother.Clone() as MotherboardModel ?? new MotherboardModel();
            var nwRAM = ram.Clone() as RAMModel ?? new RAMModel();
            var nwVideoCard = videoCard.Clone() as VideoCardModel ?? new VideoCardModel();
            IScore nwScore = GetTotalScore(nwCPU, nwDrive, nwMother, nwRAM, nwVideoCard, preset);
            return new NativePCModel()
            {
                CPU = nwCPU,
                Drive = nwDrive,
                Motherboard = nwMother,
                RAM = nwRAM,
                VideoCard = nwVideoCard,
                Price = price,
                TotalScore = nwScore
            };
        }
    }
}
