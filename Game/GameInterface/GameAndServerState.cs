namespace Chess.Game.GameInterface
{
    public sealed class GameAndServerState
    {
        public bool IsWhitesTurn { get; }
        public Figure[,] Field { get; }
        public bool IsCheckmate { get; }
        public bool IsServerStops { get; }

        public GameAndServerState(bool isWhitesTurn, Figure[,] field,
            bool isCheckmate, bool isServerStops)
        {
            this.IsWhitesTurn = isWhitesTurn;
            this.Field = field;
            this.IsCheckmate = isCheckmate;
            this.IsServerStops = isServerStops;
        }
    }
}
