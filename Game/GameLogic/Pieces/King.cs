using System.Collections.Generic;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public sealed class King : NonLinearMovingPiece
    {
        public bool IsChecked
        {
            get; private set;
        }

        public bool IsCheckmated
        {
            get; set;
        }

        public King() : base(null, false)
        {

        }

        public King(PlayingField field, bool isWhite) : base(field, isWhite)
        {

        }

        public override void CalculateAvailableMoves(int Y, int X)
        {
            var result = new List<ChessMove>();

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        if (CanMoveAndCapture(X + i, Y + j))
                            result.Add(new ChessMove(X, Y, X + i, Y + j));
            AvailableMoves = result;
        }

        public override FigureType GetFigureType() => FigureType.King;

        public override bool IsKing() => true;

        public void TryCheckBy(Piece figure, int Y, int X)
        {
            foreach (var move in figure.AvailableMoves)
                if (move.EndX == X && move.EndY == Y)
                    IsChecked = true;
        }

        public void ResetCheck()
        {
            IsChecked = false;
        }

        public override object Clone(PlayingField field)
        {
            object cloneFigure = base.Clone(field);
            (cloneFigure as King).IsChecked = IsChecked;
            (cloneFigure as King).IsCheckmated = IsCheckmated;
            return cloneFigure;
        }
    }
}
