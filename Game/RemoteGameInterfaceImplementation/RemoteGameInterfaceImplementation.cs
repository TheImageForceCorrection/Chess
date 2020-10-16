using System.Collections.Generic;
using Chess.Networking.GameConnection;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic
{
    public sealed class RemoteGameInterfaceImplementation : IGame
    {
        private readonly Client client;

        public GameAndServerState GameAndServerState
        {
            get; private set;
        }

        public bool IsWhitesTurn
        {
            get
            {
                return GameAndServerState.IsWhitesTurn;
            }
        }

        public RemoteGameInterfaceImplementation(Client client)
        {
            this.client = client;
        }

        public Figure[,] GetField()
        {
            return GameAndServerState.Field;
        }

        public bool IsCheckmate()
        {
            return GameAndServerState.IsCheckmate;
        }

        public bool IsServerStops()
        {
            return GameAndServerState.IsServerStops;
        }

        public bool CheckAndMakeAMove(ChessMove move)
        {
            return (client.InvokeMethod<bool?>("CheckAndMakeAMove", new object[] { move })).Value;
        }

        public List<ChessMove> GetAvailableMoves(int x, int y)
        {
            return client.InvokeMethod<List<ChessMove>>("GetAvailableMoves", new object[] { x, y });
        }

        public void Disconnect()
        {
            client.InvokeMethod("Disconnect", null);
            client.CloseConnection();
        }

        public void Refresh()
        {
            GameAndServerState = client.InvokeMethod<GameAndServerState>("GameAndServerState", null);
        }
    }

}
