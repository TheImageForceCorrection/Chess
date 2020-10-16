using System.Collections.Generic;
using Chess.Game.GameInterface;
using Chess.Networking.GameConnection;

namespace Chess.Game.GameLogic
{
    public sealed class GameInterfaceImplementation : IGame
    {
        private GameLogic game;
        private bool isServerStops;
        private readonly Server server;

        public bool IsWhitesTurn
        {
            get
            {
                return game.IsWhitesTurn;
            }
        }

        private static GameInterfaceImplementation instance;

        private GameInterfaceImplementation(Server server)
        {
            this.server = server;

            DisconnectedPlayersCount = 0;
        }

        public static GameInterfaceImplementation CreateNewGame(Server server)
        {
            instance = new GameInterfaceImplementation(server)
            {
                game = GameLogic.CreateNewGame()
            };
            return instance;
        }

        public Figure[,] GetField()
        {
            return game.GetField();
        }

        public bool IsCheckmate()
        {
            return game.IsCheckmate();
        }

        public bool CheckAndMakeAMove(ChessMove move)
        {
            return game.CheckAndMakeAMove(move);
        }

        public List<ChessMove> GetAvailableMoves(int x, int y)
        {
            return game.GetAvailableMoves(x, y);
        }

        public bool IsServerStops()
        {
            return isServerStops;
        }

        public int DisconnectedPlayersCount { get; private set; }

        public void Disconnect()
        {
            if (DisconnectedPlayersCount >= 1)
                server.Stop();

            DisconnectedPlayersCount++;
            isServerStops = true;
        }

        public GameAndServerState GameAndServerState
            => new GameAndServerState(IsWhitesTurn, GetField(),
                IsCheckmate(), IsServerStops());

        public void Refresh()
        {

        }
    }
}
