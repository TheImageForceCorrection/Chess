namespace Chess.Game.GameLogic.Pieces
{
    public interface ICloneablePiece
    {
        object Clone(PlayingField field);
    }
}