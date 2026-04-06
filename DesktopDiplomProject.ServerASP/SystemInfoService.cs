namespace DesktopDiplomProject.ServerASP
{
    public class SystemInfoService
    {//public class SystemInfoProvider
     //{
     //    public class SystemInfo
     //    {
     //        public string CPUName { get; set; }
     //        public string GPUName { get; set; }
     //        public string Motherboard { get; set; }
     //        public string RAMInfo { get; set; }
     //        public string StorageInfo { get; set; }
     //        public long TotalRAM { get; set; }
     //    }

        //    public static SystemInfo GetSystemInfo()
        //    {
        //        var info = new SystemInfo();

        //        try
        //        {
        //            // CPU
        //            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
        //            {
        //                foreach (ManagementObject obj in searcher.Get())
        //                {
        //                    info.CPUName = obj["Name"]?.ToString()?.Trim();
        //                    break;
        //                }
        //            }

        //            // GPU
        //            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
        //            {
        //                foreach (ManagementObject obj in searcher.Get())
        //                {
        //                    string name = obj["Name"]?.ToString();
        //                    if (!string.IsNullOrEmpty(name) && !name.Contains("Remote") && !name.Contains("Mirror"))
        //                    {
        //                        info.GPUName = name;
        //                        break;
        //                    }
        //                }
        //            }

        //            // Motherboard
        //            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard"))
        //            {
        //                foreach (ManagementObject obj in searcher.Get())
        //                {
        //                    string manufacturer = obj["Manufacturer"]?.ToString();
        //                    string product = obj["Product"]?.ToString();
        //                    info.Motherboard = $"{manufacturer} {product}".Trim();
        //                    break;
        //                }
        //            }

        //            // RAM
        //            long totalRAM = 0;
        //            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory"))
        //            {
        //                int slot = 1;
        //                foreach (ManagementObject obj in searcher.Get())
        //                {
        //                    string capacity = obj["Capacity"]?.ToString();
        //                    string speed = obj["Speed"]?.ToString();
        //                    string manufacturer = obj["Manufacturer"]?.ToString();

        //                    if (!string.IsNullOrEmpty(capacity) && long.TryParse(capacity, out long bytes))
        //                    {
        //                        totalRAM += bytes;
        //                        info.RAMInfo += $"Slot {slot++}: {manufacturer} {bytes / (1024 * 1024 * 1024)}GB {speed}MHz\n";
        //                    }
        //                }
        //                info.TotalRAM = totalRAM / (1024 * 1024 * 1024); // Convert to GB
        //            }

        //            // Storage
        //            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
        //            {
        //                foreach (ManagementObject obj in searcher.Get())
        //                {
        //                    string model = obj["Model"]?.ToString();
        //                    string size = obj["Size"]?.ToString();
        //                    string mediaType = obj["MediaType"]?.ToString();

        //                    if (!string.IsNullOrEmpty(model) && !model.Contains("Virtual") && !model.Contains("VMware"))
        //                    {
        //                        if (!string.IsNullOrEmpty(size) && long.TryParse(size, out long bytes))
        //                        {
        //                            double gb = bytes / (1024.0 * 1024.0 * 1024.0);
        //                            info.StorageInfo += $"{model} - {gb:F1}GB ({GetDriveType(mediaType)})\n";
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error: {ex.Message}");
        //        }

        //        return info;
        //    }

        //    private static string GetDriveType(string mediaType)
        //    {
        //        if (string.IsNullOrEmpty(mediaType)) return "Unknown";

        //        if (mediaType.Contains("SSD") || mediaType.Contains("Solid State"))
        //            return "SSD";
        //        else if (mediaType.Contains("HDD") || mediaType.Contains("Fixed hard disk"))
        //            return "HDD";
        //        else
        //            return mediaType;
        //    }
        //}
    }
}
