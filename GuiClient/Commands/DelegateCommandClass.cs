using System;
using System.Windows.Input;

namespace GuiClient.Commands
{
    public class DelegateCommandClass : ICommand
    {
        private readonly Action<object> _executeMethodAddress;
        private readonly Func<object, bool> _canExecuteMethodAddress;

        public DelegateCommandClass(Action<object> executeMethodAddress,Func<object,bool> canExecuteMethodAddress)
        {
            this._executeMethodAddress = executeMethodAddress;
            this._canExecuteMethodAddress = canExecuteMethodAddress;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._canExecuteMethodAddress.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            this._executeMethodAddress.Invoke(parameter);
        }
    }
}
