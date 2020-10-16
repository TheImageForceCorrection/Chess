using Chess.Networking.BaseConnection.ConnectionInterface;
using Chess.Networking.GameConnection;
using Chess.Game.GameInterface;
using Chess.Game.GameLogic;

namespace Chess.Game.Factories
{
    public sealed class GameFactory
    {
        private static GameFactory instance;

        private GameFactory()
        {

        }
        public IGame GetChessGame(IConnection connection)
        {
            Server chessServer = new Server(connection);
            IGame game = GameInterfaceImplementation.CreateNewGame(chessServer);
            chessServer.Game = game;
            chessServer.Start();
            return game;
        }

        public static GameFactory GetInstance()
        {
            if (instance == null)
                instance = new GameFactory();
            return instance;
        }
    }
}
