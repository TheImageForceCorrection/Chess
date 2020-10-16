using System.Net.Sockets;
using System.Text;
using Chess.Networking.BaseConnection.ConnectionInterface;

namespace Chess.Networking.BaseConnection.TcpIPConnection
{
    public sealed class TcpIPClient : IConnection
    {
        private TcpClient client;
        private readonly string hostname;
        private readonly int port;

        public TcpIPClient(string hostname, int port)
        {
            this.hostname = hostname;
            this.port = port;
        }

        public bool TryToOpen()
        {
            try
            {
                client = new TcpClient(hostname, port);
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void Write(string str)
        {
            byte[] buf = Encoding.UTF8.GetBytes(str);
            client.GetStream().Write(buf, 0, buf.Length);
        }

        public string Read()
        {
            byte[] buf = new byte[10];
            string data = "";

            NetworkStream stream = client.GetStream();

            int i;

            while (stream.DataAvailable)
            {
                i = stream.Read(buf, 0, buf.Length);
                data += Encoding.UTF8.GetString(buf, 0, i);
            }

            return data;
        }

        public void Close()
        {
            if (client != null)
                client.Close();
        }
    }
}

