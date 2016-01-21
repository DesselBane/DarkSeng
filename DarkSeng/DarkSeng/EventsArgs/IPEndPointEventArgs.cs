using System.Net;

namespace DarkSeng.EventsArgs
{
    public class IPEndPointEventArgs
    {
        #region Vars

        IPEndPoint _address;

        #endregion Vars

        #region Properties

        public IPEndPoint Address
        {
            get { return _address; }
            private set { _address = value; }
        }

        #endregion

        #region Constructors

        public IPEndPointEventArgs(IPEndPoint address)
        {
            Address = address;
        }

        #endregion

    }
}
