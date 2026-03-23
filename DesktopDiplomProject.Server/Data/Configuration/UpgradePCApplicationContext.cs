using DesktopDiplomProject.Server.Data.Configuration.Authentification;
using DesktopDiplomProject.Server.Data.Configuration.Components.CPU;
using DesktopDiplomProject.Server.Data.Configuration.Components.Drive;
using DesktopDiplomProject.Server.Data.Configuration.Components.Motherboard;
using DesktopDiplomProject.Server.Data.Configuration.Components.RAM;
using DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard;
using DesktopDiplomProject.Server.Data.Configuration.Components.VideoCard.GPU;
using DesktopDiplomProject.Server.Data.Configuration.PersonalComputers;
using DesktopDiplomProject.Server.Models.Entities.Authentification;
using DesktopDiplomProject.Server.Models.Entities.Components.CPUs;
using DesktopDiplomProject.Server.Models.Entities.Components.Drives;
using DesktopDiplomProject.Server.Models.Entities.Components.Motherboards;
using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards;
using DesktopDiplomProject.Server.Models.Entities.Components.VideoCards.GPUs;
using DesktopDiplomProject.Server.Models.Entities.PersonalComputers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Server.Data.Configuration
{
    public class UpgradePCApplicationContext : DbContext
    {
        public DbSet<CPUEntity> CPUs { get; set; }
        public DbSet<CPUSocketEntity> Sockets { get; set; }
        public DbSet<CPUThreadsCountEntity> CPUThreadsCounties { get; set; }
        public DbSet<CPUCoreCountEntity> CPUCoreCounties { get; set; }
        public DbSet<CPUBaseFrequencyEntity> CPUBaseFrequencies { get; set; }
        public DbSet<CPUPriceEntity> CPUPrices { get; set; }
        public DbSet<DriveCapacityEntity> DriveCapacities { get; set; }
        public DbSet<DriveConnectionInterfaceEntity> DriveConnectionInterfaces { get; set; }
        public DbSet<DriveEntity> Drives { get; set; }
        public DbSet<DriveSpeedDataTransferEntity> DriveDataTransferSpeeds { get; set; }
        public DbSet<DrivePriceEntity> DrivePrices { get; set; }
        public DbSet<MBCountM2SlotsEntity> MBCountM2Slots { get; set; }
        public DbSet<MBCountPCIEX16SlotsEntity> MBCountPCIEX16Slots { get; set; }
        public DbSet<MBCountSATASlotsEntity> MBCountSATASlots { get; set; }
        public DbSet<MBRAMFrequencyEntity> MBRAMFrequecies { get; set; }
        public DbSet<MBRAMCountSlotsEntity> MBRAMSlotsCounties { get; set; }
        public DbSet<MBRAMValueEntity> MBRAMValues { get; set; }
        public DbSet<MBSizeEntity> MBSizes { get; set; }
        public DbSet<MBPriceEntity> MBPrices { get; set; }
        public DbSet<MotherboardEntity> Motherboards { get; set; }
        public DbSet<PCEntity> PCs { get; set; }
        public DbSet<RAMCountModulesEntity> RAMModulesCounties { get; set; }
        public DbSet<RAMEntity> RAMs { get; set; }
        public DbSet<RAMPriceEntity> RAMPrices { get; set; }
        public DbSet<RAMFrequencyEntity> RAMFrequencies { get; set; }
        public DbSet<RAMSingleModuleCapacityEntity> RAMSingleModuleCapacities { get; set; }
        public DbSet<RAMTypeEntity> RAMTypes { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GPUCountRasterizationBlocksEntity> GPURasterizationBlocksCounties { get; set; }
        public DbSet<GPUCountRTCoresEntity> GPURTCoresCounties { get; set; }
        public DbSet<GPUCountTensorCoresEntity> GPUTensorCoresCounties { get; set; }
        public DbSet<GPUCountTexturerBlocksEntity> GPUTexturesBlocksCounties { get; set; }
        public DbSet<GPUCountUniversalProcessorsEntity> GPUUniversalProcessorsCounties { get; set; }
        public DbSet<GPUEntity> GPUs { get; set; }
        public DbSet<GPUFrequencyEntity> GPUFrequencies { get; set; }
        public DbSet<PCIEInterfaceEntity> PCIEInterfaces { get; set; }
        public DbSet<VCCapacityVideoMemoryEntity> VCVideoMemoryCapacities { get; set; }
        public DbSet<VCCountMonitorsEntity> VCMonitorsCounties { get; set; }
        public DbSet<VCMemoryFrequencyEntity> VCMemoryFrequencies { get; set; }
        public DbSet<VCThroughputCapacityEntity> VCThroughputCapacities { get; set; }
        public DbSet<VCPriceEntity> VCPrices { get; set; }
        public DbSet<VideoCardEntity> VideoCards { get; set; }

        public UpgradePCApplicationContext(DbContextOptions<UpgradePCApplicationContext> options) : base(options)
        {
        }

        protected UpgradePCApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CPUBaseFrequencyConfiguration());
            modelBuilder.ApplyConfiguration(new CPUConfiguration());
            modelBuilder.ApplyConfiguration(new CPUCoreCountConfiguration());
            modelBuilder.ApplyConfiguration(new CPUSocketConfiguration());
            modelBuilder.ApplyConfiguration(new CPUThreadsCountConfiguration());
            modelBuilder.ApplyConfiguration(new CPUPriceConfiguration());
            modelBuilder.ApplyConfiguration(new DriveCapacityConfiguration());
            modelBuilder.ApplyConfiguration(new DriveConfiguration());
            modelBuilder.ApplyConfiguration(new DriveConnectionInterfaceConfiguration());
            modelBuilder.ApplyConfiguration(new DriveSpeedDataTransferConfiguration());
            modelBuilder.ApplyConfiguration(new DrivePriceConfiguration());
            modelBuilder.ApplyConfiguration(new MBCountM2SlotsConfiguration());
            modelBuilder.ApplyConfiguration(new MBCountPCIEX16SlotsConfiguration());
            modelBuilder.ApplyConfiguration(new MBCountSATASlotsConfiguration());
            modelBuilder.ApplyConfiguration(new MBRAMFrequencyConfiguration());
            modelBuilder.ApplyConfiguration(new MBRAMCountSlotsConfiguration());
            modelBuilder.ApplyConfiguration(new MBRAMValueConfiguration());
            modelBuilder.ApplyConfiguration(new MBSizeConfiguration());
            modelBuilder.ApplyConfiguration(new MBPriceConfiguration());
            modelBuilder.ApplyConfiguration(new MotherboardConfiguration());
            modelBuilder.ApplyConfiguration(new PCConfiguration());
            modelBuilder.ApplyConfiguration(new RAMConfiguration());
            modelBuilder.ApplyConfiguration(new RAMCountModulesConfiguration());
            modelBuilder.ApplyConfiguration(new RAMFrequencyConfiguration());
            modelBuilder.ApplyConfiguration(new RAMSingleModuleCapacityConfiguration());
            modelBuilder.ApplyConfiguration(new RAMTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RAMPriceConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GPUConfiguration());
            modelBuilder.ApplyConfiguration(new GPUCountRasterizationBlocksConfiguration());
            modelBuilder.ApplyConfiguration(new GPUCountRTCoresConfiguration());
            modelBuilder.ApplyConfiguration(new GPUCountTensorCoresConfiguration());
            modelBuilder.ApplyConfiguration(new GPUCountTexturerBlocksConfiguration());
            modelBuilder.ApplyConfiguration(new GPUCountUniversalProcessorsConfiguration());
            modelBuilder.ApplyConfiguration(new PCIEInterfaceConfiguration());
            modelBuilder.ApplyConfiguration(new VCCapacityVideoMemoryConfiguration());
            modelBuilder.ApplyConfiguration(new VCCountMonitorsConfiguration());
            modelBuilder.ApplyConfiguration(new VCMemoryFrequencyConfiguration());
            modelBuilder.ApplyConfiguration(new VCThroughputCapacityConfiguration());
            modelBuilder.ApplyConfiguration(new VCPriceConfiguration());
            modelBuilder.ApplyConfiguration(new VideoCardConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
