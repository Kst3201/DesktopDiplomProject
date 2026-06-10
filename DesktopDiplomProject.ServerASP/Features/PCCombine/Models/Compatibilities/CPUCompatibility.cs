namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public class CPUCompatibility
    {
        public string? Socket { get; set; }
        public string RAMType { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CPUCompatibility other &&
                other.Socket == this.Socket && other.RAMType == this.RAMType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Socket, RAMType);
        }
    }
}
