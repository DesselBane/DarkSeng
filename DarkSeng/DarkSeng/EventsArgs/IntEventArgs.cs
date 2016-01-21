using System;

namespace DarkSeng.EventsArgs
{
    public class IntEventArgs : EventArgs
    {
        #region Vars

        int _value;

        #endregion Vars

        #region Properties

        public int Value
        {
            get { return _value; }
            private set { _value = value; }
        }

        #endregion

        #region Constructors

        public IntEventArgs(int value)
        {
            Value = value;
        }

        #endregion
    }
}
