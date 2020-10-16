namespace Chess.Networking.BaseConnection.ConnectionInterface
{
    public interface IConnection
    {
        bool TryToOpen();
        void Write(string str);
        string Read();
        void Close();
    }
}
