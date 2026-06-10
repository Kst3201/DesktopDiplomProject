namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public class MotherboardCompatibility
    {
        public string? Socket { get; set; }
        public string? Size { get; set; }
        public string? RAMType { get; set; }
        public string? PCIEInterface { get; set; }
        public bool HasM2Slots { get; set; }
        public bool HasSATASlots { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is MotherboardCompatibility other &&
                Socket == other.Socket &&
                Size == other.Size &&
                RAMType == other.RAMType &&
                PCIEInterface == other. PCIEInterface &&
                HasM2Slots == other.HasM2Slots &&
                HasSATASlots == other.HasSATASlots;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Socket, Size, RAMType, PCIEInterface, HasM2Slots, HasSATASlots);
        }
    }
}
