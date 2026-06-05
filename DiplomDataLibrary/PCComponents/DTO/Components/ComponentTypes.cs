namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public enum ComponentTypes
    {
        CPU = 0,
        Drive,
        GPU,
        Motherboard,
        RAM,
        VideoCard,
        Socket,
        DriveConnectionInterface,
        MotherboardSize,
        PCIEInterface,
        RAMType
    }


    public enum ComponentUnitTypes
    {
        None = 0,
        Socket,
        DriveConnectionInterface,
        MotherboardSize,
        PCIEInterface
    }

    public enum ComponentScoredUnitTypes
    {
        RAMType = 0
    }
}
