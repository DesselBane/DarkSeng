using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.ViewModel.General.Interfaces
{
    /// <summary>
    /// Gives access to Application functions like shutdown
    /// </summary>
    public interface IAppContentHost
    {
        /// <summary>
        /// Restarts the Application
        /// </summary>
        void Restart();
        /// <summary>
        /// Shuts down the application
        /// </summary>
        /// <param name="exitCode">Used for error reporting</param>
        void Shutdown(int exitCode = 0);
    }
}
