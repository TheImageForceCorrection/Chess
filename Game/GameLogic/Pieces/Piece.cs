using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public abstract class Piece : ICloneablePiece
    {
        public PlayingField Field { get; private set; }

        public List<ChessMove> AvailableMoves { get; protected set; }

        private Piece()
        {

        }
        public Piece(PlayingField field)
        {
            this.Field = field;
        }

        public abstract void CalculateAvailableMoves(int Y, int X);

        public bool CheckMove(ChessMove move)
        {
            if (GameLogic.GetInstance().IsWhitesTurn == IsWhite())
                foreach (var curMove in AvailableMoves)
                    if (curMove == move)
                        return true;

            return false;
        }

        public abstract bool IsWhite();

        public bool IsSameColourAs(Piece figure)
        {
            return (IsWhite() == figure.IsWhite());
        }

        public abstract FigureType GetFigureType();

        public abstract bool IsKing();

        public virtual object Clone(PlayingField field)
        {
            object cloneFigure = Activator.CreateInstance(GetType());
            (cloneFigure as Piece).Field = field;
            (cloneFigure as Piece).AvailableMoves = AvailableMoves.ToList<ChessMove>();
            return cloneFigure;
        }
    }
}