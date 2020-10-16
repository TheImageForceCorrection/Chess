using System;

namespace Chess.Networking.BaseConnection.ConnectionInterface
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message) : base(message)
        {

        }
    }
}
