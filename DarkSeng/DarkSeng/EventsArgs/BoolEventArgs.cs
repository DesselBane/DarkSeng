using System;

namespace DarkSeng.EventsArgs
{
    public class BoolEventArgs : EventArgs
    {
        #region Vars

        bool _flag;

        #endregion Vars

        #region Properties

        public bool Flag
        {
            get { return _flag; }
            private set { _flag = value; }
        }

        #endregion

        #region Constructors

        public BoolEventArgs(bool flag)
        {
            Flag = flag;
        }

        #endregion
    }
}
