using System;

namespace DarkSeng.EventsArgs
{
    public class DateTimeEventArgs : EventArgs
    {
        #region Vars

        DateTime _date;

        #endregion Vars

        #region Properties

        public DateTime Date
        {
            get { return _date; }
            private set { _date = value; }
        }

        #endregion Properties

        #region Constructors

        public DateTimeEventArgs(DateTime date)
        {
            Date = date;
        }

        #endregion Constructors 
    }
}
