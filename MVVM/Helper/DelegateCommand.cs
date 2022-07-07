using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Helper
{
    /// <summary>
    /// RelayCommand / DelegateCommand Implementation
    /// </summary>
    public class DelegateCommand : ICommand
    {
        readonly Action<object>? execute;
        readonly Predicate<object>? canExecute;

        public event EventHandler? CanExecuteChanged;
        /// <summary>
        /// This is a modern C# solution (C# 7.0 or newer)
        /// It creates a tuple with the values of the 2 constructor parameters and
        /// assigns it to a tuple with the 2 properties of the class.
        /// 
        /// Read more about this type of assignment
        /// </summary>
        /// <param name="canExecute"></param>
        /// <param name="execute"></param>
        public DelegateCommand(Predicate<object> canExecute, Action<object> execute) =>
            (this.canExecute, this.execute) = (canExecute, execute);
        public DelegateCommand(Action<object> execute) : this(null, execute) { }
        /// <summary>
        /// The C# double question mark operator ?? is called the null-coalescing operator.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => execute?.Invoke(parameter);

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
