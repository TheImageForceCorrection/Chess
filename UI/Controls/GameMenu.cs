using System;
using System.Windows.Forms;
using System.Drawing;
using Chess.UI.Logic;
using static Chess.UI.Controls.CoorinatesAndExtensions.SizesAndPositions;

namespace Chess.UI.Controls
{
    public sealed class GameMenu
    {
        private UILogic UILogic { get; }
        public Button[] Menu { get; }

        public GameMenu(UILogic UILogic)
        {
            this.UILogic = UILogic;
            Menu = new Button[2];

            for (int i = 0; i < 2; i++)
            {
                Menu[i] = new Button
                {
                    Location = new Point(mainMenuStartX, mainMenuStartY + (mainMenuBtnYSize + mainMenuBtnGap) * i),
                    Name = "mainMenu" + i.ToString(),
                    Size = new Size(mainMenuBtnXSize, mainMenuBtnYSize),
                    TabIndex = i,
                    TabStop = false,
                    Visible = true,
                    UseVisualStyleBackColor = true
                };
            }
            Menu[0].Text = "New Game";
            Menu[1].Text = "Connect";
            Menu[0].Click += new EventHandler(CreateNewGameBtn_Click);
            Menu[1].Click += new EventHandler(ConnectGameBtn_Click);

        }

        public void Show()
        {
            for (int i = 0; i < 2; i++)
                Menu[i].Show();
        }

        public void Hide()
        {
            for (int i = 0; i < 2; i++)
                Menu[i].Hide();
        }

        private void CreateNewGameBtn_Click(object sender, EventArgs e)
        {
            UILogic.SetupConnection(true);
        }

        private void ConnectGameBtn_Click(object sender, EventArgs e)
        {
            UILogic.SetupConnection(false);
        }
    }
}
