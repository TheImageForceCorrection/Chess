using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public abstract class Pawn : Piece
    {
        public Pawn(PlayingField field) : base(field)
        {

        }

        protected bool CanMove(int X, int Y)
        {
            return PlayingField.CheckRanges(Y, X) && Field.CheckEmpty(Y, X);
        }

        protected bool CanCapture(int Y, int X)
        {
            return PlayingField.CheckRanges(Y, X) &&
                    !Field.CheckEmpty(Y, X) && !IsSameColourAs(Field[Y, X]);
        }

        public override FigureType GetFigureType() => FigureType.Pawn;

        public override bool IsKing() => false;
    }
}