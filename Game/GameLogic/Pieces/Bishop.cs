using System.Collections.Generic;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public sealed class Bishop : HeavyPiece
    {
        public Bishop() : base(null, false)
        {

        }

        public Bishop(PlayingField field, bool isWhite) : base(field, isWhite)
        {

        }

        public override void CalculateAvailableMoves(int Y, int X)
        {
            var result = new List<ChessMove>();

            for (int i = 1; (X - i >= 0) && (Y - i >= 0); i++)
                if (Field.CheckEmpty(Y - i, X - i))
                    result.Add(new ChessMove(X, Y, X - i, Y - i));
                else
                {
                    if (!IsSameColourAs(Field[Y - i, X - i]))
                        result.Add(new ChessMove(X, Y, X - i, Y - i));
                    break;
                }

            for (int i = 1; (X + i <= 7) && (Y + i <= 7); i++)
                if (Field.CheckEmpty(Y + i, X + i))
                    result.Add(new ChessMove(X, Y, X + i, Y + i));
                else
                {
                    if (!IsSameColourAs(Field[Y + i, X + i]))
                        result.Add(new ChessMove(X, Y, X + i, Y + i));
                    break;
                }

            for (int i = 1; (X + i <= 7) && (Y - i >= 0); i++)
                if (Field.CheckEmpty(Y - i, X + i))
                    result.Add(new ChessMove(X, Y, X + i, Y - i));
                else
                {
                    if (!IsSameColourAs(Field[Y - i, X + i]))
                        result.Add(new ChessMove(X, Y, X + i, Y - i));
                    break;
                }

            for (int i = 1; (X - i >= 0) && (Y + i <= 7); i++)
                if (Field.CheckEmpty(Y + i, X - i))
                    result.Add(new ChessMove(X, Y, X - i, Y + i));
                else
                {
                    if (!IsSameColourAs(Field[Y + i, X - i]))
                        result.Add(new ChessMove(X, Y, X - i, Y + i));
                    break;
                }

            AvailableMoves = result;
        }

        public override FigureType GetFigureType() => FigureType.Bishop;

        public override bool IsKing() => false;
    }
}
