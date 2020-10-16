using System.Windows.Forms;
using System.Drawing;
using Chess.UI.Logic;
using static Chess.UI.Controls.CoorinatesAndExtensions.SizesAndPositions;

namespace Chess.UI.Controls
{
    public sealed class RightBar
    {
        public UILogic UILogic { get; }
        public Label PlayerColourLabel { get; }
        public PictureBox PlayerColourPict { get; }
        public Label CurColourLabel { get; }
        public PictureBox CurColourPict { get; }
        public Label CheckLabel { get; }


        public RightBar(UILogic UILogic)
        {
            this.UILogic = UILogic;
            PlayerColourLabel = new Label();
            PlayerColourPict = new PictureBox();
            CurColourLabel = new Label();
            CurColourPict = new PictureBox();
            CheckLabel = new Label();

            PlayerColourLabel.AutoSize = false;
            PlayerColourLabel.Name = "PlayerColourLabel";
            PlayerColourLabel.Text = "You:";
            PlayerColourLabel.Font = new Font(PlayerColourLabel.Font.FontFamily, 10);
            PlayerColourLabel.Location = new Point(rightColumnX, rightcolumnStartY);
            PlayerColourLabel.Size = new Size(125, 20);
            PlayerColourLabel.TextAlign = ContentAlignment.MiddleCenter;
            PlayerColourLabel.Visible = false;

            PlayerColourPict.Location = new Point(rightColumnX, rightcolumnStartY + PlayerColourLabel.Height + rightColumnGap);
            PlayerColourPict.Name = "PlayerColourPict";
            PlayerColourPict.Size = new Size(125, 125);
            PlayerColourPict.SizeMode = PictureBoxSizeMode.StretchImage;
            PlayerColourPict.Visible = false;

            CurColourLabel.AutoSize = false;
            CurColourLabel.Name = "CurColourLabel";
            CurColourLabel.Text = "Whose move:";
            CurColourLabel.Font = new Font(CurColourLabel.Font.FontFamily, 10);
            CurColourLabel.Location = new Point(rightColumnX, PlayerColourPict.Location.Y + PlayerColourPict.Height + rightColumnGap);
            CurColourLabel.Size = new Size(125, 20);
            CurColourLabel.TextAlign = ContentAlignment.MiddleCenter;
            CurColourLabel.Visible = false;

            CurColourPict.Location = new Point(rightColumnX, CurColourLabel.Location.Y + CurColourLabel.Height + rightColumnGap);
            CurColourPict.Name = "CurColourPict";
            CurColourPict.Size = new Size(125, 125);
            CurColourPict.SizeMode = PictureBoxSizeMode.StretchImage;
            CurColourPict.Visible = false;

            CheckLabel.AutoSize = false;
            CheckLabel.Name = "CheckLabel";
            CheckLabel.Text = "Check";
            CheckLabel.Font = new Font(CheckLabel.Font.FontFamily, 20);
            CheckLabel.Location = new Point(rightColumnX, CurColourPict.Location.Y + CurColourPict.Height + rightColumnGap);
            CheckLabel.Size = new Size(125, 40);
            CheckLabel.TextAlign = ContentAlignment.MiddleCenter;
            CheckLabel.Visible = false;
        }

        public void Show()
        {
            PlayerColourLabel.Show();
            PlayerColourPict.Show();
            CurColourLabel.Show();
            CurColourPict.Show();
        }

        public void Hide()
        {
            PlayerColourLabel.Hide();
            PlayerColourPict.Hide();
            CurColourLabel.Hide();
            CurColourPict.Hide();
        }

        public void Refresh(bool isWhitesTurn, bool isWhitePlayer)
        {
            if (isWhitesTurn)
            {
                CurColourPict.Image = Properties.Resources.wfigures;
            }
            else
            {
                CurColourPict.Image = Properties.Resources.bfigures;
            }

            if (isWhitePlayer)
                PlayerColourPict.Image = Properties.Resources.wfigures;
            else
                PlayerColourPict.Image = Properties.Resources.bfigures;
        }
    }
}
