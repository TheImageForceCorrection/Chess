using Chess.Game.GameInterface;
using Chess.Networking.BaseConnection.ConnectionInterface;
using Chess.Networking.GameConnection;
using Chess.Game.GameLogic;

namespace Chess.Game.Factories
{
    public sealed class RemoteGameFactory
    {
        private static RemoteGameFactory instance;

        private RemoteGameFactory()
        {

        }
        public IGame GetChessGame(IConnection connection)
        {
            return new RemoteGameInterfaceImplementation(new Client(connection));
        }

        public static RemoteGameFactory GetInstance()
        {
            if (instance == null)
                instance = new RemoteGameFactory();
            return instance;
        }
    }
}
