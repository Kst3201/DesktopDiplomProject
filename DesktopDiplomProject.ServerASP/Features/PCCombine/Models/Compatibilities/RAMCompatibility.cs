namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public class RAMCompatibility
    {
        public string? RAMType { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is RAMCompatibility other &&
                RAMType == other.RAMType;
        }

        public override int GetHashCode()
        {
            return RAMType?.GetHashCode() ?? 0;
        }
    }
}
