namespace Chess.Game.GameLogic.Pieces
{
    public abstract class HeavyPiece : Piece
    {
        private bool isWhite;

        public HeavyPiece(PlayingField field, bool isWhite) : base(field)
        {
            this.isWhite = isWhite;
        }

        public override bool IsWhite() => isWhite;

        public override object Clone(PlayingField field)
        {
            object cloneFigure = base.Clone(field);
            (cloneFigure as HeavyPiece).isWhite = isWhite;
            return cloneFigure;
        }
    }
}
