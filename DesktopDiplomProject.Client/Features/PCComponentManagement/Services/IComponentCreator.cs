using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Services
{
    public interface IComponentCreator<TDTO, TModel, TViewModel>
    {
        TModel CreateModel(TDTO dto);
        TViewModel CreateViewModel(TModel model);
        TModel CreateModel(TViewModel viewModel);
        TDTO CreateDTO(TModel model);
        TModel CreateEmptyModel();
        TViewModel CreateEmptyViewModel();
    }
}
