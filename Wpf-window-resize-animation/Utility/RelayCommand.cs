using System;
using System.Windows.Input;

namespace Wpf_window_resize_animation.Utility
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _command;
        private readonly Predicate<object> _isValid;

        public RelayCommand(Action<object> command, Predicate<object> isValid = null)
        {
            if (command == null)
            {
                throw new NullReferenceException("Command method is not defined");
            }

            _command = command;
            _isValid = isValid;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;  }
        }

        public bool CanExecute(object parameter)
        {
            return _isValid == null || _isValid(parameter);
        }

        public void Execute(object parameter)
        {
            _command?.Invoke(parameter);
        }
    }
}
