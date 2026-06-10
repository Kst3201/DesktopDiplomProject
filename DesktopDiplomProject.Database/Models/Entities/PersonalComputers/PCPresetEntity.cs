namespace DesktopDiplomProject.Server.Models.Entities.PersonalComputers
{
    public class PCPresetEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double CPUCoeff { get; set; } = 0;
        public double DriveCoeff { get; set; } = 0;
        public double MotherboardCoeff { get; set; } = 0;
        public double RAMCoeff { get; set; } = 0;
        public double VideoCardCoeff { get; set;} = 0;

    }
}
