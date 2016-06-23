using System;
using System.Windows.Input;

namespace DarkSeng.Commands
{
    public abstract class cmd_base : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        protected void OnCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            handler?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the command can be executed with the given parameter
        /// </summary>
        /// <param name="parameter">Some Parameter that might be needed for the command execution</param>
        /// <returns>Returns true if command can be executed. The default is true</returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command with the given parameter
        /// </summary>
        /// <param name="param">Some Parameter that might be needed for the command execution</param>
        protected abstract void ExecuteImpl(object param);

        /// <summary>
        /// Checks if CanExecute returns true. If so executes the command. Otherwise throws an InvalidOperationException
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                throw new InvalidOperationException("Cannot Execute Command if CanExecute() returns false");

            ExecuteImpl(parameter);
        }

        /// <summary>
        /// This will fire the CanExecuteChanged Event. This will also trigger the CommandManager to reevaluate this commands CanExecute State.
        /// </summary>
        public virtual void ReevaluatePermissions()
        {
            OnCanExecuteChanged();
        }

        #endregion
    }
}
