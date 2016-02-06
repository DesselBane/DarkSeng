using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.Commands
{
    public class RelayCommand : cmd_base
    {
        #region Vars
        Action<object> _execute;
        Func<object, bool> _canExecute;
        #endregion Vars

        #region Constructors
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="CanExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action<object> ExecuteDelegate, Func<object, bool> CanExecuteDelegate)
        {
            if (ExecuteDelegate == null)
                throw new ArgumentNullException("ExecutionDelegate must not be null.");

            _execute = ExecuteDelegate;
            _canExecute = CanExecuteDelegate;
        }

        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="CanExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action ExecuteDelegate, Func<bool> CanExecuteDelegate) : this((object arg0) => ExecuteDelegate(), (object arg0) => CanExecuteDelegate()) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        public RelayCommand(Action ExecuteDelegate) : this(ExecuteDelegate, null as Func<object, bool>) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        public RelayCommand(Action<object> ExecuteDelegate) : this(ExecuteDelegate, null as Func<object, bool>) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="CanExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action ExecuteDelegate, Func<object, bool> CanExecuteDelegate) : this((object arg0) => ExecuteDelegate(), CanExecuteDelegate) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="CanExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action<object> ExecutionDelegate, Func<bool> CanExecuteDelegate) : this(ExecutionDelegate, (object arg0) => CanExecuteDelegate()) { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Determines if the command can be executed with the given parameter
        /// </summary>
        /// <param name="parameter">Some Parameter that might be needed for the command execution</param>
        /// <returns>Returns true if command can be executed</returns>
        public override bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        /// <summary>
        /// Executes the command with the given parameter
        /// </summary>
        /// <param name="parameter">Some Parameter that might be needed for the command execution</param>
        public override void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion Methods
    }
}
