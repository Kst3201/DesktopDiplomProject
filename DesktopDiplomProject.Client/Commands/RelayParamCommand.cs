using System.Windows.Input;

namespace DesktopDiplomProject.Client.Commands
{
    public class RelayParamCommand<T> : ICommand
    {
        private Action<T> _action;
        private Func<T?, bool>? _predicate;

        public RelayParamCommand(Action<T> action, Func<T?, bool>? predicate = null)
        {
            _action = action;
            _predicate = predicate;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (_predicate == null || _action == null) return true;
            return parameter is T value && _predicate.Invoke(value);
        }

        public void Execute(object? parameter)
        {
            if (parameter is T value)
            {
                _action?.Invoke(value);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
