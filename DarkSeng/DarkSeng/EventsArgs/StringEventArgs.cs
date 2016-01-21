using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.EventsArgs
{
    public class StringEventArgs : EventArgs
    {
        #region Vars

        string _message;

        #endregion Vars

        #region Properties

        public string Message
        {
            get { return _message; }
            private set { _message = value; }
        }

        #endregion

        #region Constructors

        public StringEventArgs(string msg)
        {
            Message = msg;
        }

        #endregion
    }
}
