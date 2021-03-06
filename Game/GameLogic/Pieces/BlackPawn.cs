﻿using System.Collections.Generic;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic.Pieces
{
    public sealed class BlackPawn : Pawn
    {
        public BlackPawn() : base(null)
        {

        }

        public BlackPawn(PlayingField field) : base(field)
        {

        }

        public override void CalculateAvailableMoves(int Y, int X)
        {
            var result = new List<ChessMove>();

            if (CanMove(X, Y - 1))
            {
                result.Add(new ChessMove(X, Y, X, Y - 1));
                if (Y == 6 && CanMove(X, Y - 2))
                {
                    result.Add(new ChessMove(X, Y, X, Y - 2));
                }
            }
            if (CanCapture(Y - 1, X + 1))
                result.Add(new ChessMove(X, Y, X + 1, Y - 1));

            if (CanCapture(Y - 1, X - 1))
                result.Add(new ChessMove(X, Y, X - 1, Y - 1));

            AvailableMoves = result;
        }

        public override bool IsWhite() => false;
    }
}
