using System.Collections.Generic;

namespace Chess.Game.GameInterface
{
    public interface IGame
    {
        bool IsWhitesTurn { get; }
        Figure[,] GetField();
        bool CheckAndMakeAMove(ChessMove move);
        bool IsCheckmate();
        List<ChessMove> GetAvailableMoves(int x, int y);
        bool IsServerStops();
        void Disconnect();
        void Refresh();
        GameAndServerState GameAndServerState { get; }
    }
}