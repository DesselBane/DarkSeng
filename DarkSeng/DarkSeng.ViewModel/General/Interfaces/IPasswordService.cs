using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.ViewModel.General.Interfaces
{
    /// <summary>
    /// Passwords should not be stored in Properties therefore binding wont work. Use this interface to access passwords from the View
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Returns the password with the given id
        /// </summary>
        /// <param name="id">The id of the password in case there are more then one.</param>
        /// <returns>Returns the password</returns>
        string GetPassword(int id = 0);
    }
}
