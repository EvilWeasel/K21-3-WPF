using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_GettingStarted.Helper
{
    internal class DelegateCommand : ICommand
    {
        readonly Action<object>? execute;
        readonly Predicate<object>? canExecute;
        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        /// <summary>
        /// ?? => Null-Coalescing-Operator
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            // if (canExecute != null)
            // {
            //     canExecute(parameter);
            // }
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter) => execute?.Invoke(parameter);

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
