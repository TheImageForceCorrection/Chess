using System;

namespace Chess.Game.GameInterface
{
    public sealed class ChessMove
    {
        private int startX, startY, endX, endY;

        public ChessMove(int startX, int startY, int endX, int endY)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.EndX = endX;
            this.EndY = endY;
        }

        public int StartX
        {
            get
            {
                return startX;
            }

            private set
            {
                if (value > 7 && value < 0)
                    throw new ArgumentOutOfRangeException("X", "X and Y coordinates of Piece must be in range from 0 to 7");
                startX = value;
            }
        }

        public int StartY
        {
            get
            {
                return startY;
            }

            private set
            {
                if (value > 7 && value < 0)
                    throw new ArgumentOutOfRangeException("X", "X and Y coordinates of Piece must be in range from 0 to 7");
                startY = value;
            }
        }

        public int EndX
        {
            get
            {
                return endX;
            }

            private set
            {
                if (value > 7 && value < 0)
                    throw new ArgumentOutOfRangeException("X", "X and Y coordinates of Piece must be in range from 0 to 7");
                endX = value;
            }
        }

        public int EndY
        {
            get
            {
                return endY;
            }

            private set
            {
                if (value > 7 && value < 0)
                    throw new ArgumentOutOfRangeException("X", "X and Y coordinates of Piece must be in range from 0 to 7");
                endY = value;
            }
        }

        public ChessMove Reverse()
        {
            return new ChessMove(EndX, EndY, StartX, StartY);
        }

        public static bool operator ==(ChessMove move1, ChessMove move2)
        {
            if (move1.StartX == move2.StartX && move1.StartY == move2.StartY && move1.EndX == move2.EndX && move1.EndY == move2.EndY)
                return true;
            return false;
        }

        public static bool operator !=(ChessMove move1, ChessMove move2)
        {
            if (move1 == move2)
                return false;
            return true;
        }

        public override bool Equals(Object O)
        {
            if (O is ChessMove move)
                return (this == move);
            return false;
        }

        public override int GetHashCode() => 1;

    }
}
