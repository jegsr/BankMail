using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database.MVVM
{
    /// <summary>
    /// Classe responsavél pela execução de um comando do tipo RelayCommand
    /// </summary>
    class RelayCommand : ICommand
    {
        private Action _action;
        private Predicate<Object> _canExecute;

        public RelayCommand(Action _action, Predicate<Object> _canExecute)
        {
            this._action = _action;
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
            _action();
        }
    }
}
