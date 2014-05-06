using System;
using System.Diagnostics;
using System.Windows.Input;

namespace mvvm.ViewModel
{
    /// <summary>
    ///     A simple ICommand implementation
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> action;
        private readonly Predicate<object> canExecute;

        #endregion // Fields

        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="action">The action to execute</param>
        public RelayCommand(Action<object> action)
            : this(action, null)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="action">The action to execute</param>
        /// <param name="canExecute">Delegate to check whether the action can be executed or not</param>
        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            this.action = action;
            this.canExecute = canExecute;
        }

        /// <summary>
        ///     Triggers a re-execution of the CanExecute method
        /// </summary>
        /// <remarks>
        ///     NOTE: This method must not be called from any other thread bur the main UI thread in order
        ///     to work as expected
        /// </remarks>
        public void RaiseExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        #endregion // ICommand Members
    }
}