using System;

namespace DarkSeng.Commands
{
    public class RelayCommand : cmd_base
    {
        #region Vars
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        #endregion Vars

        #region Constructors
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="executeDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="canExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate)
        {
            if (executeDelegate == null)
                throw new ArgumentNullException("ExecutionDelegate must not be null.");

            _execute = executeDelegate;
            _canExecute = canExecuteDelegate;
        }

        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="executeDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="canExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action executeDelegate, Func<bool> canExecuteDelegate) : this((object arg0) => executeDelegate(), (object arg0) => canExecuteDelegate()) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="executeDelegate">The delegate that will be called on with the Execute() Method</param>
        public RelayCommand(Action executeDelegate) : this(executeDelegate, null as Func<object, bool>) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="executeDelegate">The delegate that will be called on with the Execute() Method</param>
        public RelayCommand(Action<object> executeDelegate) : this(executeDelegate, null as Func<object, bool>) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="executeDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="canExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action executeDelegate, Func<object, bool> canExecuteDelegate) : this((object arg0) => executeDelegate(), canExecuteDelegate) { }
        /// <summary>
        /// Creates a new RelayCommand
        /// </summary>
        /// <param name="ExecuteDelegate">The delegate that will be called on with the Execute() Method</param>
        /// <param name="canExecuteDelegate">The delegate to determine if this command can be executed</param>
        public RelayCommand(Action<object> executionDelegate, Func<bool> canExecuteDelegate) : this(executionDelegate, (object arg0) => canExecuteDelegate()) { }

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
        protected override void ExecuteImpl(object parameter)
        {
            _execute(parameter);
        }

        #endregion Methods
    }
}
