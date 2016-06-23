using System;
using System.Windows.Input;
using DarkSeng.Commands;

namespace DarkSeng.Wpf.Extensions
{
    public static class CommandExtensions
    {
        /// <summary>
        /// Hooks up the CommandManager.RequerySuggested Event to fire a ReevaluetePermissions event. This can be used to "automagically" reevaluete commands. Free the command once you're done with it or there will be memory leaks!
        /// </summary>
        /// <param name="cmd">The command that should be hooked up</param>
        /// <returns>Returns the event handler for unsibscription</returns>
        public static EventHandler AddToCommandManager(this cmd_base cmd)
        {
            EventHandler func = (sender, args) => { cmd.ReevaluatePermissions(); };
            CommandManager.RequerySuggested += func;
            return func;
        }

        /// <summary>
        /// Frees the Command of CommandManager.RequerySuggested Event handlers.
        /// </summary>
        /// <param name="cmd">Command to be freed</param>
        /// <param name="originalEventHandler">The Handler from the AddToCommandManager function</param>
        public static void RemoveFromCommandManager(this cmd_base cmd,EventHandler originalEventHandler )
        {
            CommandManager.RequerySuggested -= originalEventHandler;
        }
    }
}
