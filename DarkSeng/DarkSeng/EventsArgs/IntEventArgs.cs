using System;

namespace DarkSeng.EventsArgs
{
    public class IntEventArgs : EventArgs
    {
        #region Properties

        public int Value { get; private set; }

        #endregion

        #region Constructors

        public IntEventArgs(int value)
        {
            Value = value;
        }

        #endregion
    }
}
