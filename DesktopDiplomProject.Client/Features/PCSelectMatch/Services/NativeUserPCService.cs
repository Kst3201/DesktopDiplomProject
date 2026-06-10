using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators;
using DesktopDiplomProject.Client.Features.PCSelectMatch.Models;
using DesktopDiplomProject.Client.Features.PCSelectMatch.ViewModels.PersonalComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCSelectMatch.Services
{
    public class NativeUserPCService : IUserPCService
    {
        private ICPUCreator _cpuCreator;
        private IDriveCreator _driveCreator;
        private IMotherboardCreator _motherboardCreator;
        private IRAMCreator _ramCreator;
        private IVideoCardCreator _videoCardCreator;

        public NativeUserPCService(ICPUCreator cpuCreator, IDriveCreator driveCreator
            , IMotherboardCreator motherboardCreator, IRAMCreator ramCreator, IVideoCardCreator videoCardCreator)
        {
            _cpuCreator = cpuCreator;
            _driveCreator = driveCreator;
            _motherboardCreator = motherboardCreator;
            _ramCreator = ramCreator;
            _videoCardCreator = videoCardCreator;
        }

        public async Task<IPCModel> GetUserPC()
        {
            var cpuTask = InitializeCPUAsync();
            var driveTask = InitializeDriveAsync();
            var motherboardTask = InitializeMotherboardAsync();
            var ramTask = InitializeRAMAsync();
            var videoCardTask = InitializeVideoCardAsync();
            await Task.WhenAll(cpuTask, driveTask, motherboardTask, ramTask, videoCardTask);
            var ram = ramTask.Result.FirstOrDefault();
            if (ram != null)
            {
                UpdateCPU(cpuTask.Result, ram);
            }
            var cpu = cpuTask.Result.FirstOrDefault();
            UpdateMotherboards(motherboardTask.Result, cpu, ram, driveTask.Result);
            var cpuModel = cpuTask?.Result?.FirstOrDefault() ?? new CPUModel();
            var driveModel = driveTask.Result.FirstOrDefault() ??  new DriveModel();
            var motherboardModel = motherboardTask.Result.FirstOrDefault() ??  new MotherboardModel();
            var ramModel = ramTask?.Result?.FirstOrDefault() ?? new RAMModel();
            var videoCardModel = videoCardTask.Result.FirstOrDefault() ??  new VideoCardModel();
            return new NativePCModel(cpuModel, driveModel, motherboardModel
                , ramModel, videoCardModel);
        }

        private List<CPUModel> InitializeCPU()
        {
            var list = new List<CPUModel>();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    TryGetWmiProperty(item, "Name", out string name, "Неизвестно");
                    TryGetWmiProperty(item, "Manufacturer", out string manufacturer, "Неизвестно");
                    TryGetWmiProperty(item, "SocketDesignation", out string socket, "Неизвестно");
                    TryGetWmiProperty<UInt32>(item, "NumberOfCores", out UInt32 countCores, 0);
                    TryGetWmiProperty<UInt32>(item, "MaxClockSpeed", out UInt32 speed, 0);
                    TryGetWmiProperty<UInt32>(item, "ThreadCount", out UInt32 threads, 0);
                    var model = new CPUModel()
                    {
                        Name = name,
                        Manufacturer = manufacturer,
                        Socket = socket,
                        CountCores = Convert.ToInt32(countCores),
                        CountThreads = Convert.ToInt32(threads),
                        BaseFrequency = Convert.ToInt32(speed)
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        private async Task<List<CPUModel>> InitializeCPUAsync()
        {
            return await Task.Run(() => InitializeCPU());
        }

        private List<DriveModel> InitializeDrive()
        {
            var list = new List<DriveModel>();
            using (var searcher = new ManagementObjectSearcher(@"root\Microsoft\Windows\Storage", "SELECT * FROM MSFT_PhysicalDisk"))
            {
                foreach (ManagementObject disk in searcher.Get())
                {
                    // BusType как раз покажет SATA (11) или NVMe (17)[citation:1]
                    TryGetWmiProperty(disk, "FriendlyName", out string name, "Неизвестно");
                    Console.WriteLine($"Системное имя (Name): {name}");
                    TryGetWmiProperty<ushort>(disk, "BusType", out ushort busType, 0);
                    Console.WriteLine($"Интерфейс: {GetNameBusType(busType)}");
                    TryGetWmiProperty<UInt64>(disk, "Size", out UInt64 size, 0);
                    size = size / 1000 / 1000 / 1000;
                    var model = new DriveModel()
                    {
                        Name = name,
                        ConnectorInterface = GetNameBusType(busType),
                        Capacity = Convert.ToInt32(size)
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        private async Task<List<DriveModel>> InitializeDriveAsync()
        {
            return await Task.Run(() => InitializeDrive());
        }

        private List<MotherboardModel> InitializeMotherboard()
        {
            var list = new List<MotherboardModel>();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard"))
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    TryGetWmiProperty(item, "Manufacturer", out string manufacturer, "Неизвестно");
                    TryGetWmiProperty(item, "Product", out string systemName, "Неизвестно");
                    var model = new MotherboardModel()
                    {
                        Name = $"{manufacturer} {systemName}",
                        Manufacturer = manufacturer,
                        Model = systemName
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        private async Task<List<MotherboardModel>> InitializeMotherboardAsync()
        {
            return await Task.Run(() => InitializeMotherboard());
        }

        private List<RAMModel> InitializeRAM()
        {
            var list = new List<RAMModel>();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory"))
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    TryGetWmiProperty<UInt64>(item, "Capacity", out UInt64 capacity, 0);
                    capacity = capacity / 1024 / 1024 / 1024;
                    TryGetWmiProperty<UInt32>(item, "Speed", out UInt32 speed, 0);
                    TryGetWmiProperty<UInt32>(item, "SMBIOSMemoryType", out UInt32 type, 0);
                    Console.WriteLine($"SMBIOSMemoryType: {GetMemoryType(type)}");
                    var model = new RAMModel()
                    {
                        RAMType = GetMemoryType(type),
                        SingleModuleCapacity = Convert.ToInt32(capacity),
                        CountModules = 1,
                        Frequency = Convert.ToInt32(speed)
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        private async Task<List<RAMModel>> InitializeRAMAsync()
        {
            return await Task.Run(() => InitializeRAM());
        }

        private List<VideoCardModel> InitializeVideoCard()
        {
            var list = new List<VideoCardModel>();
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController WHERE CurrentRefreshRate IS NOT NULL"))
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    TryGetWmiProperty(item, "VideoProcessor", out string processor, "Неизвестно");
                    var model = new VideoCardModel()
                    {
                        GPU = processor
                    };
                    list.Add(model);
                }
            }
            return list;
        }

        private async Task<List<VideoCardModel>> InitializeVideoCardAsync()
        {
            return await Task.Run(() => InitializeVideoCard());
        }

        private void UpdateCPU(List<CPUModel> cpus, RAMModel ram)
        {
            foreach (var model in cpus)
            {
                model.RAMType = ram.RAMType;
            }
        }

        private void UpdateMotherboards(List<MotherboardModel> motherboards,
            CPUModel? cpu, RAMModel? ram, IList<DriveModel>? driveModels)
        {
            int countM2 = 0;
            int countSATA = 0;
            if (driveModels != null)
            {
                foreach (var model in driveModels)
                {
                    if (model.ConnectorInterface.Equals("NVMe", StringComparison.OrdinalIgnoreCase))
                    {
                        countM2++;
                    }
                    else if (model.ConnectorInterface.Equals("SATA", StringComparison.OrdinalIgnoreCase))
                    {
                        countSATA++;
                    }
                }
            }
            foreach (var model in motherboards)
            {
                if (cpu != null)
                    model.Socket = cpu.Socket;
                if (ram != null)
                    model.RAMType = ram.RAMType;
                model.CountM2Slots = countM2;
                model.CountSATASlots = countSATA;
            }
        }


        private bool TryGetWmiProperty<T>(ManagementObject wmiObject, string propertyName, out T value, T defaultValue = default)
            where T : notnull
        {
            value = defaultValue;

            try
            {
                // Проверяем существование свойства
                if (wmiObject.Properties[propertyName] == null)
                    return false;

                object rawValue = wmiObject[propertyName];

                // Проверяем на null и DBNull
                if (rawValue == null || rawValue == DBNull.Value)
                    return false;
                // Преобразуем значение
                value = (T)Convert.ChangeType(rawValue, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetMemoryType(UInt32 type)
        {
            switch (type)
            {
                case 24: return "DDR3";
                case 26: return "DDR4";
                case 28: return "DDR5";
                default: return "Неизвестно";
            }
        }

        private string GetNameBusType(ushort busType)
        {
            switch (busType)
            {
                case 11: return "SATA";
                case 17: return "NVMe";
                case 7: return "USB";
                default: return "Неизвестно";
            }
        }

    }
}
