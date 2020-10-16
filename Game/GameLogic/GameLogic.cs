using System;
using System.Collections.Generic;
using Chess.Game.GameLogic.Pieces;
using Chess.Game.GameInterface;

namespace Chess.Game.GameLogic
{
    public sealed class GameLogic
    {
        private int whiteKingX, whiteKingY, blackKingX, blackKingY;
        private King WhiteKing => playingField[whiteKingY, whiteKingX] as King;
        private King BlackKing => playingField[blackKingY, blackKingX] as King;

        private King CurrentKing => IsWhitesTurn ? WhiteKing : BlackKing;
        private King OppositeKing => IsWhitesTurn ? BlackKing : WhiteKing;

        private PlayingField playingField;
        public bool IsWhitesTurn
        {
            get; private set;
        }

        private static GameLogic instance;

        private GameLogic()
        {
            playingField = new PlayingField();

            whiteKingX = 3;
            whiteKingY = 0;
            blackKingX = 3;
            blackKingY = 7;

            IsWhitesTurn = true;

            CalculateAvailableMoves();
        }

        public static GameLogic GetInstance()
        {
            return instance;
        }

        public static GameLogic CreateNewGame()
        {
            instance = new GameLogic();
            return instance;
        }

        public Figure[,] GetField()
        {
            var result = new Figure[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (playingField.CheckEmpty(i, j))
                        result[i, j] = null;
                    else
                        result[i, j] = new Figure(playingField[i, j].GetFigureType(), playingField[i, j].IsWhite());

            return result;
        }

        public bool IsCheckmate()
        {
            return CurrentKing.IsCheckmated;
        }

        public void CalculateAvailableMoves()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (playingField[i, j] != null)
                        playingField[i, j].CalculateAvailableMoves(i, j);
        }

        public void TryCheckKings()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (!playingField.CheckEmpty(i, j))
                    {
                        WhiteKing.TryCheckBy(playingField[i, j], whiteKingY, whiteKingX);
                        BlackKing.TryCheckBy(playingField[i, j], blackKingY, blackKingX);
                    }

        }

        public void TryToCheckmateOppositeKing()
        {
            if (!OppositeKing.IsChecked)
                throw new ArgumentException("Must be checked", "King king");

            bool kingCanBeUnchecked = false;

            for (int i = 0; i < 8 && !kingCanBeUnchecked; i++)
                for (int j = 0; j < 8 && !kingCanBeUnchecked; j++)
                    if (!playingField.CheckEmpty(i, j) && OppositeKing.IsSameColourAs(playingField[i, j]))
                        foreach (var move in playingField[i, j].AvailableMoves)
                        {
                            Piece capturedFigure = playingField[move.EndY, move.EndX];

                            MakeOrCancelAMove(move);

                            if (!OppositeKing.IsChecked)
                            {
                                kingCanBeUnchecked = true;
                                MakeOrCancelAMove(move.Reverse(), capturedFigure);
                                break;
                            }

                            MakeOrCancelAMove(move.Reverse(), capturedFigure);

                        }

            OppositeKing.IsCheckmated = !kingCanBeUnchecked;

        }

        public void ResetKingsChecks()
        {
            WhiteKing.ResetCheck();
            BlackKing.ResetCheck();
        }

        private void MakeOrCancelAMove(ChessMove move, Piece capturedFigure = null)
        {
            if (playingField[move.StartY, move.StartX].IsKing())
                if (playingField[move.StartY, move.StartX].IsWhite())
                {
                    whiteKingX = move.EndX;
                    whiteKingY = move.EndY;
                }
                else
                {
                    blackKingX = move.EndX;
                    blackKingY = move.EndY;
                }

            playingField[move.EndY, move.EndX] = playingField[move.StartY, move.StartX];
            playingField[move.StartY, move.StartX] = capturedFigure;

            ResetKingsChecks();
            CalculateAvailableMoves();
            TryCheckKings();
        }

        public void CheckAvailableMoves()
        {
            PlayingField tempPlField = playingField.Clone() as PlayingField;
            int tempWhiteKingX = whiteKingX, tempWhiteKingY = whiteKingY;
            int tempBlackKingX = blackKingX, tempBlackKingY = blackKingY;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (!playingField.CheckEmpty(i, j))
                    {
                        foreach (var move in playingField[i, j].AvailableMoves)
                            if (playingField.CheckEmpty(move.EndY, move.EndX) || !playingField[move.EndY, move.EndX].IsKing())
                            {
                                Piece capturedFigure = playingField[move.EndY, move.EndX];

                                MakeOrCancelAMove(move);

                                if (OppositeKing.IsChecked)
                                    tempPlField[i, j].AvailableMoves.Remove(move);

                                MakeOrCancelAMove(move.Reverse(), capturedFigure);

                            }
                    }
            playingField = tempPlField;
            whiteKingX = tempWhiteKingX;
            whiteKingY = tempWhiteKingY;
            blackKingX = tempBlackKingX;
            blackKingY = tempBlackKingY;

        }

        public bool CheckAndMakeAMove(ChessMove move)
        {
            if (playingField.CheckEmpty(move.StartY, move.StartX) || !playingField[move.StartY, move.StartX].CheckMove(move))
                return false;

            Piece capturedFigure = playingField[move.EndY, move.EndX];

            MakeOrCancelAMove(move);

            if (IsWhitesTurn ? WhiteKing.IsChecked : BlackKing.IsChecked)
            {
                MakeOrCancelAMove(move.Reverse(), capturedFigure);
                return false;
            }
            else
            {
                if (OppositeKing.IsChecked)
                    TryToCheckmateOppositeKing();
                CheckAvailableMoves();
                IsWhitesTurn = !IsWhitesTurn;

                return true;
            }
        }

        public List<ChessMove> GetAvailableMoves(int x, int y)
        {
            return playingField[y, x].AvailableMoves;
        }
    }

}

