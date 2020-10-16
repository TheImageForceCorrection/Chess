namespace Chess.Game.GameLogic.Pieces
{
    public abstract class NonLinearMovingPiece : HeavyPiece
    {
        public NonLinearMovingPiece(PlayingField field, bool isWhite) : base(field, isWhite)
        {

        }

        protected bool CanMoveAndCapture(int X, int Y)
        {
            if (!PlayingField.CheckRanges(X, Y))
                return false;
            return Field.CheckEmpty(Y, X) || !IsSameColourAs(Field[Y, X]);
        }
    }
}
