using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.EventsArgs
{
    public class StringEventArgs : EventArgs
    {
        #region Properties

        public string Message { get; private set; }

        #endregion

        #region Constructors

        public StringEventArgs(string msg)
        {
            Message = msg;
        }

        #endregion
    }
}
