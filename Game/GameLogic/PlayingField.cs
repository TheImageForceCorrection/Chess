using System;
using Chess.Game.GameLogic.Pieces;

namespace Chess.Game.GameLogic
{
    public sealed class PlayingField : ICloneable
    {
        private readonly Piece[,] field;
        public PlayingField()
        {
            field = new Piece[8, 8] {
           {new Rook(this,true), new Knight(this,true), new Bishop(this,true), new King(this,true), new Queen(this,true), new Bishop(this,true), new Knight(this,true), new Rook(this,true)},
           {new WhitePawn(this), new WhitePawn(this), new WhitePawn(this), new WhitePawn(this), new WhitePawn(this), new WhitePawn(this), new WhitePawn(this), new WhitePawn(this)},
           {null, null, null, null, null, null, null, null },
           {null, null, null, null, null, null, null, null },
            {null, null, null, null, null, null, null, null },
            {null, null, null, null, null, null, null, null },
           {new BlackPawn(this), new BlackPawn(this), new BlackPawn(this), new BlackPawn(this), new BlackPawn(this), new BlackPawn(this), new BlackPawn(this), new BlackPawn(this)},
           {new Rook(this,false), new Knight(this,false), new Bishop(this,false), new King(this,false), new Queen(this,false), new Bishop(this,false), new Knight(this,false), new Rook(this,false)}
                       };
        }

        public Piece this[int i, int j]
        {
            get
            {
                return field[i, j];
            }
            set
            {
                field[i, j] = value;
            }
        }

        public bool CheckEmpty(int Y, int X)
        {
            return (field[Y, X] == null);
        }

        public static bool CheckRanges(int i, int j)
        {
            if (i < 0 || j < 0 || i > 7 || j > 7)
                return false;
            return true;
        }

        public object Clone()
        {
            var plField = new PlayingField();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (CheckEmpty(i, j))
                        plField[i, j] = null;
                    else
                        plField[i, j] = field[i, j].Clone(plField) as Piece;
            return plField;
        }
    }
}
