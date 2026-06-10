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
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Services.PCBuild
{
    public class PCBuildService : IPCBuildService
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
        private CPUCreator _cpuCreator;
        private DriveCreator _driveCreator;
        private MotherboardCreator _motherCreator;
        private RAMCreator _ramCreator;
        private VideoCardCreator _videoCreator;
        private PCCreator _creator;

        public PCBuildService(ICPUService cpuServce, IDriveService driveService, IGPUService gpuService, IMotherboardService motherService
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
        
        public async Task<IEnumerable<PCDTO>> BuildComputers(PCBuildRequest buildDTO)
        {
            IPCPresetDTO preset = buildDTO.Preset;
            double price = buildDTO.MaxPrice ?? double.MaxValue;
            FuzzyAssessments? assessment = buildDTO.MinAssessment;
            List<CPUModel> cpus = await GetCPUs();
            cpus.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<MotherboardModel> motherboards = await GetMotherboards();
            motherboards.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<DriveModel> drives = await GetDrives();
            drives.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<RAMModel> rams = await GetRAMs();
            rams.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            List<VideoCardModel> videoCards = await GetVideoCard();
            videoCards.Sort((x, y) => _comparer.Compare(x.TotalScore, y.TotalScore));
            PriorityQueue<IPCModel, IScore> result = new PriorityQueue<IPCModel, IScore>(PCBUFFERSIZE, _comparer);
            foreach (var cpu in cpus)
            {
                foreach (var motherboard in motherboards.Where(item => item.Socket.Equals(cpu.Socket) 
                && item.RAMType.Equals(cpu.RAMType)))
                {
                    //if (motherboard.Socket.ToLower().Trim() != cpu.Socket.ToLower().Trim() ||
                    //    motherboard.RAMType != cpu.RAMType) continue;
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

        private async Task<List<CPUModel>> GetCPUs()
        {
            List<CPUModel> cpus = (await _cpuService.GetAll()).ToList();
            var result = _optimizer.GetOptimizePerGroup<CPUCompatibility, CPUModel>(
                cpus, item => new CPUCompatibility()
                {
                    Socket = item.Socket,
                    RAMType = item.RAMType
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<CPUModel>();
        }

        private async Task<List<MotherboardModel>> GetMotherboards()
        {
            List<MotherboardModel> motherboards = (await _motherService.GetAll()).ToList();
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

        private async Task<List<DriveModel>> GetDrives()
        {
            List<DriveModel> drives = (await _driveService.GetAll()).ToList();
            var result = await _optimizer.GetOptimizePerGroupAsync(
                drives, item => new DriveCompatibility()
                {
                    Interface = item.ConnectorInterface
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<DriveModel>();
        }

        private async Task<List<RAMModel>> GetRAMs()
        {
            List<RAMModel> rams = (await _ramService.GetAll()).ToList();
            var result = await _optimizer.GetOptimizePerGroupAsync(
                rams, item => new RAMCompatibility()
                {
                    RAMType = item.RAMType
                }, item => item.Price, item => item.TotalScore);
            return result?.ToList() ?? new List<RAMModel>();
        }

        private async Task<List<VideoCardModel>> GetVideoCard()
        {
            List<VideoCardModel> videoCards = (await _vcService.GetAll()).ToList();
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
            IScore result = ReassessmentService.Commulate(cpuScore, driveScore, motherScore, ramScore, vcScore);
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
