using System.Windows.Forms;
using System.Drawing;

namespace Chess.UI.Controls
{
    public sealed class FieldSquare
    {
        public PictureBox Figure { get; set; }
        public PictureBox TopBacklight { get; set; }
        public PictureBox BottomBacklight { get; set; }
        public PictureBox LeftBacklight { get; set; }
        public PictureBox RightBacklight { get; set; }

        public FieldSquare()
        {
            Figure = new PictureBox();
            TopBacklight = new PictureBox();
            BottomBacklight = new PictureBox();
            LeftBacklight = new PictureBox();
            RightBacklight = new PictureBox();
        }

        public void Show()
        {
            Figure.Visible = true;
            TopBacklight.Visible = true;
            BottomBacklight.Visible = true;
            LeftBacklight.Visible = true;
            RightBacklight.Visible = true;
        }
        public void Hide()
        {
            Figure.Visible = false;
            TopBacklight.Visible = false;
            BottomBacklight.Visible = false;
            LeftBacklight.Visible = false;
            RightBacklight.Visible = false;
        }
        public void SetBacklight(BacklightColour colour)
        {
            string colourPrefix = "";
            switch (colour)
            {
                case BacklightColour.Black:
                    colourPrefix = "b";
                    break;
                case BacklightColour.Red:
                    colourPrefix = "r";
                    break;
                case BacklightColour.Green:
                    colourPrefix = "g";
                    break;
            }

            TopBacklight.Image = Properties.Resources.ResourceManager.GetObject(colourPrefix + "horizontalbacklight") as Bitmap;
            BottomBacklight.Image = Properties.Resources.ResourceManager.GetObject(colourPrefix + "horizontalbacklight") as Bitmap;
            LeftBacklight.Image = Properties.Resources.ResourceManager.GetObject(colourPrefix + "verticalbacklight") as Bitmap;
            RightBacklight.Image = Properties.Resources.ResourceManager.GetObject(colourPrefix + "verticalbacklight") as Bitmap;
        }
    }
}
