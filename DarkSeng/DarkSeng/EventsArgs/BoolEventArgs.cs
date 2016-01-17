using System;

namespace DarkSeng.EventsArgs
{
    public class BoolEventArgs : EventArgs
    {
        #region Properties

        public bool Flag { get; private set; }

        #endregion

        #region Constructors

        public BoolEventArgs(bool flag)
        {
            Flag = flag;
        }

        #endregion
    }
}
