using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components
{
    public interface IComponentNamedUnitViewModel : INotifyPropertyChanged
    {
        string Name { get; }
    }
}
