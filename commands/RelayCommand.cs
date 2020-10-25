using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace memory.commands
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _CanExecute;
        private readonly Action<object> _Execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _CanExecute = canExecute;
            _Execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            
            return _CanExecute==null || (bool)(_CanExecute.Invoke(parameter));
        }

        public void Execute(object parameter)
        {
            _Execute?.Invoke(parameter);
        }
    }
}
