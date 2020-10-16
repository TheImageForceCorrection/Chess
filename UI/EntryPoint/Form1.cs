using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Chess.UI.UIInterface;
using Chess.UI.Logic;
using Chess.UI.Controls;
using Chess.UI.Controls.CoorinatesAndExtensions;
using Chess.Game.GameInterface;

namespace Chess.UI.EntryPoint
{
    public partial class Form1 : Form, IGameUI
    {
        public SocketInfo SocketInfo => new SocketInfo(connectionMenu.HostTextBox.Text, connectionMenu.PortTextBox.Text);

        public Form1()
        {
            uiLogic = new UILogic(this);

            gameControls = new GameControls(uiLogic);
            connectionMenu = new ConnectionMenu(uiLogic);
            gameMenu = new GameMenu(uiLogic);

            Controls.Add(gameControls);
            Controls.Add(connectionMenu);
            Controls.Add(gameMenu);

            InitializeComponent();
        }

        public void ShowConnectionMenu(bool isServerSide)
        {
            connectionMenu.Show(isServerSide);
            gameControls.Hide();
            gameMenu.Hide();
        }

        public void ShowMenu()
        {
            gameControls.Hide();
            connectionMenu.Hide();
            gameMenu.Show();
        }

        public void ShowCheckmateDlg(bool isWhitesTurn)
        {
            gameControls.CheckmateDialog.Show(isWhitesTurn);
        }

        public void StartStopWaitingConnBtnRename(bool isStartingConn)
        {
            if (isStartingConn)
                connectionMenu.StartStopWaitingConnectionBtn.Text = "Stop waiting for connection";
            else
                connectionMenu.StartStopWaitingConnectionBtn.Text = "Start waiting for connection";
        }

        public void ShowGame()
        {
            gameControls.Show();
            gameMenu.Hide();
            connectionMenu.Hide();
        }

        public void ResetPlayingFieldBacklight()
        {
            gameControls.PlayingField.ResetBacklight();
        }

        public void RefreshPlayingField(Figure[,] field, bool isWhitesTurn, bool isWhitePlayer)
        {
            gameControls.PlayingField.Refresh(field);
            gameControls.RightBar.Refresh(isWhitesTurn, isWhitePlayer);
        }

        public void MakeSquareActive(int x, int y, List<ChessMove> availableMoves)
        {
            gameControls.PlayingField[x, y].SetBacklight(BacklightColour.Red);
            foreach (var move in availableMoves)
                gameControls.PlayingField[move.EndX, move.EndY].SetBacklight(BacklightColour.Green);
        }

        public void ShowMessageBox(string text, string caption)
        {
            Invoke((Func<string, string, MessageBoxButtons, DialogResult>)MessageBox.Show, new object[] { text, caption, MessageBoxButtons.OK });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            uiLogic.StopGame(true);
        }
    }
}