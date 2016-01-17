using System.Net;

namespace DarkSeng.EventsArgs
{
    public class IPEndPointEventArgs
    {
        #region Properties

        public IPEndPoint Address { get; private set; }

        #endregion

        #region Constructors

        public IPEndPointEventArgs(IPEndPoint address)
        {
            Address = address;
        }

        #endregion

    }
}
