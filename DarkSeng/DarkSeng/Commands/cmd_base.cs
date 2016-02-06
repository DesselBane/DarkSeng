using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DarkSeng.Commands
{
    public abstract class cmd_base : ICommand
    {
        #region Constructors

        #endregion

        #region Events
        public event EventHandler CanExecuteChanged;

        protected void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, new EventArgs());
        }
        #endregion

        #region Public

        /// <summary>
        /// Determines if the command can be executed with the given parameter
        /// </summary>
        /// <param name="parameter">Some Parameter that might be needed for the command execution</param>
        /// <returns>Returns true if command can be executed</returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Executes the command with the given parameter
        /// </summary>
        /// <param name="parameter">Some Parameter that might be needed for the command execution</param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// This will fire the CanExecuteChanged Event. This will also trigger the CommandManager to reevaluate this commands CanExecute State.
        /// </summary>
        public virtual void ReevaluateCanExecute()
        {
            OnCanExecuteChanged();
        }

        #endregion
    }
}
