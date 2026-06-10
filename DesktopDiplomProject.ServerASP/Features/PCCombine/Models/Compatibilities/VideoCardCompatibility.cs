namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public class VideoCardCompatibility
    {
        public string? PCIEInterface { get; set; }
        public int PCIELines { get; set; }
        public int AdditionalPowerPins { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is VideoCardCompatibility other &&
                PCIELines == other.PCIELines &&
                PCIEInterface == other. PCIEInterface &&
                AdditionalPowerPins == other.AdditionalPowerPins;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PCIEInterface, PCIELines, AdditionalPowerPins);
        }
    }
}
