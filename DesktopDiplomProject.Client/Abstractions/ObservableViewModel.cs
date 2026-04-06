using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Abstractions
{
    internal class ObservableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetProperty<T>(ref T target, T value, Action? action = null, [CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null) throw new ArgumentNullException(nameof(PropertyChanged));
            if (target?.Equals(value) ?? false) return;
            target = value;
            action?.Invoke();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
