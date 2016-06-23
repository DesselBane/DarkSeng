using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkSeng.ViewModel.General.Enums;

namespace DarkSeng.ViewModel.General.Interfaces
{
    public interface IBasicContentHost
    {
        /// <summary>
        /// Closes the Content Host
        /// </summary>
        void CloseHost();
        
        /// <summary>
        /// Displays an Error
        /// </summary>
        /// <param name="errorMsg">The Error Message</param>
        /// <param name="errorTitle">The Error Title</param>
        void ShowError(string errorMsg, string errorTitle);
        
        /// <summary>
        /// Creates and shows a content host in non Modal mode
        /// </summary>
        /// <param name="content">The content View Model</param>
        /// <returns>Returns the new IBasicContentHost object</returns>
        IBasicContentHost ShowHost(object content);
        
        /// <summary>
        /// Creates and shows a content host in Modal mode
        /// </summary>
        /// <param name="content">The content View Model</param>
        /// <returns>Returns the new IBasicContentHost object</returns>
        IBasicContentHost ShowModalHost(object content);
        
        /// <summary>
        /// Shows a custom Message Box
        /// </summary>
        /// <param name="messageKey">The message Key or message that should be displayed</param>
        /// <param name="headerKey">The header Key or header that should be displayed</param>
        /// <param name="buttons">The Button configuration (e.g. Ok / Ok and Cancel)</param>
        /// <param name="icon">The Icon (Warning, Question etc.)</param>
        /// <returns></returns>
        BoxResult ShowMessageBox(string messageKey, string headerKey, BoxButtons buttons = BoxButtons.Ok,
            BoxIcon icon = BoxIcon.None);
    }
}
