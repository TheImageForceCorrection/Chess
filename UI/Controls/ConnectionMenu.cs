using System;
using System.Windows.Forms;
using System.Drawing;
using Chess.UI.Logic;
using static Chess.UI.Controls.CoorinatesAndExtensions.SizesAndPositions;


namespace Chess.UI.Controls
{
    public sealed class ConnectionMenu
    {
        public UILogic UILogic { get; }
        public Label HostLabel { get; }
        public Label PortLabel { get; }
        public TextBox HostTextBox { get; }
        public TextBox PortTextBox { get; }
        public Button StartStopWaitingConnectionBtn { get; }
        public Button ReturnToMenuBtn2 { get; }

        public ConnectionMenu(UILogic UILogic)
        {
            this.UILogic = UILogic;
            HostLabel = new Label();
            PortLabel = new Label();
            HostTextBox = new TextBox();
            PortTextBox = new TextBox();
            StartStopWaitingConnectionBtn = new Button();
            ReturnToMenuBtn2 = new Button();

            HostLabel.AutoSize = false;
            HostLabel.Name = "HostLabel";
            HostLabel.Text = "Host:";
            HostLabel.Location = new Point(connMenuLabelX, hostLabelY);
            HostLabel.Size = new Size(connMenuLabelSizeX, connMenuLabelSizeY);
            HostLabel.TextAlign = ContentAlignment.MiddleCenter;
            HostLabel.Visible = false;

            PortLabel.AutoSize = false;
            PortLabel.Name = "PortLabel";
            PortLabel.Text = "Port:";
            PortLabel.Location = new Point(connMenuLabelX, portLabelY);
            PortLabel.Size = new Size(connMenuLabelSizeX, connMenuLabelSizeY);
            PortLabel.TextAlign = ContentAlignment.MiddleCenter;
            PortLabel.Visible = false;

            HostTextBox.Location = new Point(connMenuTextBoxX, hostLabelY);
            HostTextBox.Name = "HostTextBox";
            HostTextBox.Size = new Size(connMenuTextBoxSizeX, connMenuTextBoxSizeY);
            HostTextBox.TabIndex = 0;
            HostTextBox.Visible = false;

            PortTextBox.Location = new Point(connMenuTextBoxX, portLabelY);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(connMenuTextBoxSizeX, connMenuTextBoxSizeY);
            PortTextBox.TabIndex = 1;
            PortTextBox.Visible = false;

            StartStopWaitingConnectionBtn.Name = "StartStopWaitingConnectionBtn";
            StartStopWaitingConnectionBtn.Size = new Size(connMenuBtnSizeX, connMenuBtnSizeY);
            StartStopWaitingConnectionBtn.Location = new Point(ConnectBtnX, connMenuBtnY);
            StartStopWaitingConnectionBtn.Text = "Start waiting for connection";
            StartStopWaitingConnectionBtn.TabIndex = 2;
            StartStopWaitingConnectionBtn.TabStop = false;
            StartStopWaitingConnectionBtn.Visible = false;
            StartStopWaitingConnectionBtn.UseVisualStyleBackColor = true;
            StartStopWaitingConnectionBtn.Click += new EventHandler(StartStopWaitingConnectionBtn_Click);

            ReturnToMenuBtn2.Name = "ReturnToMenuBtn2";
            ReturnToMenuBtn2.Size = new Size(connMenuBtnSizeX, connMenuBtnSizeY);
            ReturnToMenuBtn2.Location = new Point(ReturnToMenuBtn2X, connMenuBtnY);
            ReturnToMenuBtn2.Text = "Return to main menu";
            ReturnToMenuBtn2.TabIndex = 3;
            ReturnToMenuBtn2.TabStop = false;
            ReturnToMenuBtn2.Visible = false;
            ReturnToMenuBtn2.UseVisualStyleBackColor = true;
            ReturnToMenuBtn2.Click += new EventHandler(ReturnToMenuBtn_Click);

        }

        public void Show(bool isServerSide)
        {
            HostLabel.Show();
            PortLabel.Show();
            HostTextBox.Show();
            PortTextBox.Show();
            StartStopWaitingConnectionBtn.Show();
            ReturnToMenuBtn2.Show();
            StartStopWaitingConnectionBtn.Text = "Waiting for connection";
            HostTextBox.ReadOnly = isServerSide;
            if (isServerSide)
            {
                HostTextBox.Text = "127.0.0.1";
                PortTextBox.Text = "20";
            }
            else
            {
                HostTextBox.Text = "localhost";
                PortTextBox.Text = "20";
            }
        }

        public void Hide()
        {
            HostLabel.Hide();
            PortLabel.Hide();
            HostTextBox.Hide();
            PortTextBox.Hide();
            StartStopWaitingConnectionBtn.Hide();
            ReturnToMenuBtn2.Hide();
        }

        private void StartStopWaitingConnectionBtn_Click(object sender, EventArgs e)
        {
            UILogic.StartStopWaitingConnection();
        }

        private void ReturnToMenuBtn_Click(object sender, EventArgs e)
        {
            UILogic.ReturnToMenu();
        }
    }

}
