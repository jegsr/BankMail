using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Database.MVVM
{
    /// <summary>
    /// Classe responsavel pela execução de um comando do tipo NormalCommand
    /// </summary>
    class NormalCommand : ICommand
    {
        private Action _action;
        private bool _canExecute;

        public NormalCommand(Action _action, bool _canExecute)
        {
            this._action = _action;
            this._canExecute = _canExecute;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
