using System.Text;
using System.Net.Sockets;
using Chess.Networking.BaseConnection.ConnectionInterface;

namespace Chess.Networking.BaseConnection.TcpIPConnection
{
    public sealed class TcpIPServer : IConnection
    {
        private readonly TcpListener server;
        private TcpClient client;

        public TcpIPServer(string hostname, int port)
        {
            try
            {
                System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(hostname);
                server = new TcpListener(ipAddress, port);
                server.Start();
            }
            catch (SocketException e)
            {
                throw new ConnectionException(e.Message);
            }
        }

        public bool TryToOpen()
        {
            if (server.Pending())
            {
                client = server.AcceptTcpClient();
                return true;
            }

            return false;
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
            server.Stop();
        }
    }
}
