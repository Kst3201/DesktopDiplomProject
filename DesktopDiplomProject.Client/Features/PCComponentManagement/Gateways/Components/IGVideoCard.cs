using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Gateways.Components
{
    public interface IGVideoCard : IGComponent<VideoCardDTO>
    {
        Task<VideoCardDTO> GetItemByGPU(string name);
    }
}
