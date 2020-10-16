using System;
using System.Collections.Generic;
using Chess.Game.GameInterface;

namespace Chess.UI.UIInterface
{
    public interface IGameUI
    {
        SocketInfo SocketInfo { get; }
        void ShowConnectionMenu(bool isServerSide);
        void ShowMenu();
        void ShowCheckmateDlg(bool isWhitesTurn);
        void StartStopWaitingConnBtnRename(bool isStartingConn);
        void ShowGame();
        void ResetPlayingFieldBacklight();
        void RefreshPlayingField(Figure[,] field, bool isWhitesTurn, bool isWhitePlayer);
        void MakeSquareActive(int x, int y, List<ChessMove> availableMoves);
        object Invoke(Delegate method, params object[] args);
        void ShowMessageBox(string text, string caption);
    }
}
