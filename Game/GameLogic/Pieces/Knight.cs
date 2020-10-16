using System.Collections.Generic;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public sealed class Knight : NonLinearMovingPiece
    {
        public Knight() : base(null, false)
        {

        }

        public Knight(PlayingField field, bool isWhite) : base(field, isWhite)
        {

        }

        public override void CalculateAvailableMoves(int Y, int X)
        {
            var result = new List<ChessMove>();

            if (CanMoveAndCapture(X + 1, Y + 2))
                result.Add(new ChessMove(X, Y, X + 1, Y + 2));
            if (CanMoveAndCapture(X + 1, Y - 2))
                result.Add(new ChessMove(X, Y, X + 1, Y - 2));
            if (CanMoveAndCapture(X - 1, Y + 2))
                result.Add(new ChessMove(X, Y, X - 1, Y + 2));
            if (CanMoveAndCapture(X - 1, Y - 2))
                result.Add(new ChessMove(X, Y, X - 1, Y - 2));
            if (CanMoveAndCapture(X + 2, Y + 1))
                result.Add(new ChessMove(X, Y, X + 2, Y + 1));
            if (CanMoveAndCapture(X + 2, Y - 1))
                result.Add(new ChessMove(X, Y, X + 2, Y - 1));
            if (CanMoveAndCapture(X - 2, Y + 1))
                result.Add(new ChessMove(X, Y, X - 2, Y + 1));
            if (CanMoveAndCapture(X - 2, Y - 1))
                result.Add(new ChessMove(X, Y, X - 2, Y - 1));

            AvailableMoves = result;
        }

        public override FigureType GetFigureType() => FigureType.Knight;

        public override bool IsKing() => false;
    }
}
