using System;
using System.Windows.Forms;
using System.Drawing;
using Chess.UI.Logic;
using static Chess.UI.Controls.CoorinatesAndExtensions.SizesAndPositions;
using Chess.Game.GameInterface;

namespace Chess.UI.Controls
{
    public sealed class PlayingField
    {
        public UILogic UILogic { get; }
        private readonly FieldSquare[,] field;

        public PlayingField(UILogic UILogic)
        {
            this.UILogic = UILogic;

            field = new FieldSquare[8, 8];

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    field[i, j] = new FieldSquare();

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    field[i, j].Figure.Location = new Point(startX + i * (figureSize + figuresGap), startY + j * (figureSize + figuresGap));
                    field[i, j].Figure.Name = "field" + i.ToString() + j.ToString();
                    field[i, j].Figure.Size = new Size(figureSize, figureSize);
                    field[i, j].Figure.TabIndex = i * 8 + j;
                    field[i, j].Figure.TabStop = false;
                    field[i, j].Figure.Tag = i * 8 + j;
                    field[i, j].Figure.Click += new EventHandler(PlayingField_Click);
                    field[i, j].Figure.Visible = false;
                    field[i, j].Figure.SizeMode = PictureBoxSizeMode.StretchImage;
                    field[i, j].Figure.Margin = new Padding(0, 0, 0, 0);


                    field[i, j].TopBacklight.Location = new Point(startX + i * (figureSize + figuresGap) - halfFiguresGap, startY + j * (figureSize + figuresGap) - halfFiguresGap);
                    field[i, j].TopBacklight.Name = "fieldTopBacklight" + i.ToString() + j.ToString();
                    field[i, j].TopBacklight.Size = new Size((figureSize + figuresGap), halfFiguresGap);
                    field[i, j].TopBacklight.TabIndex = 0;
                    field[i, j].TopBacklight.TabStop = false;
                    field[j, i].TopBacklight.Image = Properties.Resources.bhorizontalbacklight;
                    field[i, j].TopBacklight.SizeMode = PictureBoxSizeMode.StretchImage;
                    field[i, j].TopBacklight.Visible = false;
                    field[i, j].TopBacklight.Margin = new Padding(0, 0, 0, 0);


                    field[i, j].BottomBacklight.Location = new Point(startX + i * (figureSize + figuresGap) - halfFiguresGap, startY + (j + 1) * (figureSize + figuresGap) - figuresGap);
                    field[i, j].BottomBacklight.Name = "fieldBottomBacklight" + i.ToString() + j.ToString();
                    field[i, j].BottomBacklight.Size = new Size((figureSize + figuresGap), halfFiguresGap);
                    field[i, j].BottomBacklight.TabIndex = 0;
                    field[i, j].BottomBacklight.TabStop = false;
                    field[j, i].BottomBacklight.Image = Properties.Resources.bhorizontalbacklight;
                    field[i, j].BottomBacklight.SizeMode = PictureBoxSizeMode.StretchImage;
                    field[i, j].BottomBacklight.Visible = false;
                    field[i, j].BottomBacklight.Margin = new Padding(0, 0, 0, 0);

                    field[i, j].LeftBacklight.Location = new Point(startX + i * (figureSize + figuresGap) - halfFiguresGap, startY + j * (figureSize + figuresGap));
                    field[i, j].LeftBacklight.Name = "fieldLeftBacklight" + i.ToString() + j.ToString();
                    field[i, j].LeftBacklight.Size = new Size(halfFiguresGap, figureSize);
                    field[i, j].LeftBacklight.TabIndex = 0;
                    field[i, j].LeftBacklight.TabStop = false;
                    field[j, i].LeftBacklight.Image = Properties.Resources.bverticalbacklight;
                    field[i, j].LeftBacklight.SizeMode = PictureBoxSizeMode.StretchImage;
                    field[i, j].LeftBacklight.Visible = false;
                    field[i, j].LeftBacklight.Margin = new Padding(0, 0, 0, 0);


                    field[i, j].RightBacklight.Location = new Point(startX + (i + 1) * (figureSize + figuresGap) - figuresGap, startY + j * (figureSize + figuresGap));
                    field[i, j].RightBacklight.Name = "fieldRightBacklight" + i.ToString() + j.ToString();
                    field[i, j].RightBacklight.Size = new Size(halfFiguresGap, figureSize);
                    field[i, j].RightBacklight.TabIndex = 0;
                    field[i, j].RightBacklight.TabStop = false;
                    field[j, i].RightBacklight.Image = Properties.Resources.bverticalbacklight;
                    field[i, j].RightBacklight.SizeMode = PictureBoxSizeMode.StretchImage;
                    field[i, j].RightBacklight.Visible = false;
                    field[i, j].RightBacklight.Margin = new Padding(0, 0, 0, 0);
                }
        }

        public FieldSquare this[int i, int j]
        {
            get
            {
                return field[i, j];
            }
            set
            {
                field[i, j] = value;
            }
        }

        public void Show()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    field[i, j].Show();
        }

        public void Hide()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    field[i, j].Hide();
        }

        public void ResetBacklight()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    field[i, j].SetBacklight(BacklightColour.Black);
                }
        }

        public void Refresh(Figure[,] field)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    string resourceName = ((i + j) % 2 == 0) ? "w" : "b";
                    if (field[i, j] == null)
                        resourceName += "empty";
                    else
                    {
                        if (field[i, j].IsWhite)
                            resourceName += "w";
                        else
                            resourceName += "b";

                        switch (field[i, j].FigureType)
                        {
                            case FigureType.Pawn:
                                resourceName += "pawn";
                                break;
                            case FigureType.Rook:
                                resourceName += "rook";
                                break;
                            case FigureType.Knight:
                                resourceName += "knight";
                                break;
                            case FigureType.Bishop:
                                resourceName += "bishop";
                                break;
                            case FigureType.Queen:
                                resourceName += "queen";
                                break;
                            case FigureType.King:
                                resourceName += "king";
                                break;

                        }
                    }
                    this.field[j, i].Figure.Image = Properties.Resources.ResourceManager.GetObject(resourceName) as Bitmap;

                }
        }

        private void PlayingField_Click(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            int? y = (pictureBox.Tag as int?) % 8;
            int? x = (pictureBox.Tag as int?) / 8;

            UILogic.StartOrMakeAMove(y.Value, x.Value);
        }
    }

}
