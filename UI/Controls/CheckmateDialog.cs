using System;
using System.Windows.Forms;
using System.Drawing;
using Chess.UI.Logic;
using static Chess.UI.Controls.CoorinatesAndExtensions.SizesAndPositions;

namespace Chess.UI.Controls
{
    public sealed class CheckmateDialog
    {
        public UILogic UILogic;
        public Label CheckmateLabel { get; }
        public Button ReturnToMenuBtn { get; }

        public CheckmateDialog(UILogic UILogic)
        {
            this.UILogic = UILogic;

            CheckmateLabel = new Label();
            ReturnToMenuBtn = new Button();

            CheckmateLabel.AutoSize = true;
            CheckmateLabel.Name = "CheckmateLabel";
            CheckmateLabel.Text = "Checkmate!!! Black won !!!";
            CheckmateLabel.Font = new Font(CheckmateLabel.Font.FontFamily, 30);
            CheckmateLabel.Size = new Size(650, 46);
            CheckmateLabel.Location = new Point(startX + fieldSize / 2 - CheckmateLabel.Width / 2, startY + fieldSize / 2 - CheckmateLabel.Height / 2);
            CheckmateLabel.Visible = false;

            ReturnToMenuBtn.Name = "ReturnToMenuBtn";
            ReturnToMenuBtn.Size = new Size(mainMenuBtnXSize, mainMenuBtnYSize);
            ReturnToMenuBtn.Location = new Point(startX + fieldSize / 2 - ReturnToMenuBtn.Width / 2, CheckmateLabel.Location.Y + CheckmateLabel.Height + mainMenuBtnGap);
            ReturnToMenuBtn.Text = "Return to Menu";
            ReturnToMenuBtn.TabIndex = 0;
            ReturnToMenuBtn.TabStop = false;
            ReturnToMenuBtn.Visible = false;
            ReturnToMenuBtn.UseVisualStyleBackColor = true;
            ReturnToMenuBtn.Click += new EventHandler(ReturnToMenuBtn_Click);

        }

        public void Show(bool isWhitesTurn)
        {
            CheckmateLabel.Text = "Checkmate!!! " + (isWhitesTurn ? "Black" : "White") + " won!!!";
            CheckmateLabel.BringToFront();
            ReturnToMenuBtn.BringToFront();
            CheckmateLabel.Show();
            ReturnToMenuBtn.Show();
        }

        public void Hide()
        {
            CheckmateLabel.Hide();
            ReturnToMenuBtn.Hide();
        }

        private void ReturnToMenuBtn_Click(object sender, EventArgs e)
        {
            UILogic.ReturnToMenu();
        }

    }
}
