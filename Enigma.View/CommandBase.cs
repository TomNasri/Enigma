using System;
using System.Windows.Input;

namespace Enigma.View
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _action;
        private Action<object> _actionWithParameter;

        public CommandBase(Action action)
        {
            _action = action;
        }

        public CommandBase(Action<object> actionWithParameter)
        {
            _actionWithParameter = actionWithParameter;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
                _action();

            if (_actionWithParameter != null)
                _actionWithParameter(parameter);
        }
    }
}
