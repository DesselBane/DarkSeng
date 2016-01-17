using System;

namespace DarkSeng.EventsArgs
{
    public class DateTimeEventArgs : EventArgs
    {
        #region Properties

        public DateTime Date { get; private set; }

        #endregion Properties

        #region Constructors

        public DateTimeEventArgs(DateTime date)
        {
            Date = date;
        }
        
        #endregion Constructors 
    }
}
