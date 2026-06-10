namespace DesktopDiplomProject.ServerASP.Features.PCCombine.Models.Compatibilities
{
    public class DriveCompatibility
    {
        public string? Interface { get; set; }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is DriveCompatibility other &&
                Interface == other.Interface;
        }

        public override int GetHashCode()
        {
            return Interface?.GetHashCode() ?? 0;
        }
    }
}
