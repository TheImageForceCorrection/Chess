namespace Chess.Game.GameInterface
{
    public sealed class Figure
    {
        public Figure(FigureType figureType, bool isWhite)
        {
            this.FigureType = figureType;
            this.IsWhite = isWhite;
        }
        public FigureType FigureType
        {
            get;
            private set;
        }
        public bool IsWhite
        {
            get;
            private set;
        }
    }
}
