using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDashboardTutorial.Commands
{
    /// <summary>
    /// RelayCommand allows you to inject the command´s logic via delegates 
    /// passed into its constructor. This method enables ViewModel classes to implement
    /// commands in a concise manner.
    /// </summary>

    public class RelayCommand : ICommand
    {
        #region Constructor
        public RelayCommand(Action<object>execute, Func<object, bool> canExecute = null) 
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region fields

        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        #endregion


        /// <summary>
        /// CanExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        /// This ensures that the WPF commanding infrastructure asks all RelayCommand objects if they can execute whenever
        /// it asks the built-in commands.
        /// </summary>
        #region event
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Methods
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}
