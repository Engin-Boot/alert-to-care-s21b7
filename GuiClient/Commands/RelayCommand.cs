using System;
using System.Windows.Input;

namespace GuiClient.Commands
{
    public class RelayCommand :ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}