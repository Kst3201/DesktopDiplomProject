using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators
{
    public class NamedUnitCreator : INamedUnitCreator
    {
        public NamedUnitCreator() { }

        public ComponentNamedUnitDTO CreateDTO(NativeComponentNamedUnitModel model)
        {
            return new ComponentNamedUnitDTO(model.Name);
        }

        public NativeComponentNamedUnitModel CreateEmptyModel()
        {
            return new NativeComponentNamedUnitModel();
        }

        public NativeComponentNamedUnitViewModel CreateEmptyViewModel()
        {
            return new NativeComponentNamedUnitViewModel(string.Empty);
        }

        public NativeComponentNamedUnitModel CreateModel(ComponentNamedUnitDTO dto)
        {
            return new NativeComponentNamedUnitModel()
            {
                Name = dto.Name
            };
        }

        public NativeComponentNamedUnitModel CreateModel(NativeComponentNamedUnitViewModel viewModel)
        {
            return new NativeComponentNamedUnitModel()
            {
                Name = viewModel.Name
            };
        }

        public NativeComponentNamedUnitViewModel CreateViewModel(NativeComponentNamedUnitModel model)
        {
            return new NativeComponentNamedUnitViewModel(model.Name);
        }
    }
}
