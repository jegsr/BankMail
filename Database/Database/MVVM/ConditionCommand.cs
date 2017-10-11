using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database.MVVM
{
    class ConditionCommand: ICommand
    {

        private Predicate<Object> _canExecute;

        public ConditionCommand(Predicate<Object> _canExecute)
        {
            this._canExecute = _canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
