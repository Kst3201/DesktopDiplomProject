using System.Windows.Input;

namespace DesktopDiplomProject.Client.Commands
{
    public class RelayParamCommand : ICommand
    {
        private Action<object?> _action;
        private Func<object?, bool>? _predicate;

        public RelayParamCommand(Action<object?> action, Func<object?, bool>? predicate = null)
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
            return _predicate.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
