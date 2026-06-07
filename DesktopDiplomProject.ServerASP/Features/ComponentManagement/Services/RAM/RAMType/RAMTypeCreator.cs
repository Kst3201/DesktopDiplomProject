using DesktopDiplomProject.Server.Models.Entities.Components.RAMs;
using DiplomDataLibrary.PCComponents.DTO.Components;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM.RAMType
{
    public class RAMTypeCreator
    {
        public RAMTypeCreator() { }

        public RAMTypeDTO CreateDTO(RAMTypeEntity entity)
        {
            return new RAMTypeDTO(entity.Name, entity.ScoreOne, entity.ScoreTwo, entity.ScoreThree
                , entity.ScoreFour, entity.ScoreFive);
        }
    }
}
