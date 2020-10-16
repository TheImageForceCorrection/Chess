namespace Chess.UI.UIInterface
{
    public sealed class SocketInfo
    {
        public string Host { get; }
        public string Port { get; }

        public SocketInfo(string host, string port)
        {
            Host = host;
            Port = port;
        }
    }
}
