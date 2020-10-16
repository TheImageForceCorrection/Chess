using System.Collections.Generic;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public sealed class Rook : HeavyPiece
    {
        public Rook() : base(null, false)
        {

        }

        public Rook(PlayingField field, bool isWhite) : base(field, isWhite)
        {

        }

        public override void CalculateAvailableMoves(int Y, int X)
        {
            var result = new List<ChessMove>();

            for (int i = X - 1; i >= 0; i--)
                if (Field.CheckEmpty(Y, i))
                    result.Add(new ChessMove(X, Y, i, Y));
                else
                {
                    if (!IsSameColourAs(Field[Y, i]))
                        result.Add(new ChessMove(X, Y, i, Y));
                    break;
                }

            for (int i = X + 1; i <= 7; i++)
                if (Field.CheckEmpty(Y, i))
                    result.Add(new ChessMove(X, Y, i, Y));
                else
                {
                    if (!IsSameColourAs(Field[Y, i]))
                        result.Add(new ChessMove(X, Y, i, Y));
                    break;
                }

            for (int i = Y - 1; i >= 0; i--)
                if (Field.CheckEmpty(i, X))
                    result.Add(new ChessMove(X, Y, X, i));
                else
                {
                    if (!IsSameColourAs(Field[i, X]))
                        result.Add(new ChessMove(X, Y, X, i));
                    break;
                }

            for (int i = Y + 1; i <= 7; i++)
                if (Field.CheckEmpty(i, X))
                    result.Add(new ChessMove(X, Y, X, i));
                else
                {
                    if (!IsSameColourAs(Field[i, X]))
                        result.Add(new ChessMove(X, Y, X, i));
                    break;
                }

            AvailableMoves = result;
        }

        public override FigureType GetFigureType() => FigureType.Rook;

        public override bool IsKing() => false;
    }

}
