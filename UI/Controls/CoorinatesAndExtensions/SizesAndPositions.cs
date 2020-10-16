namespace Chess.UI.Controls.CoorinatesAndExtensions
{
    static class SizesAndPositions
    {
        public const int startX = 80;
        public const int startY = 24;
        public const int figureSize = 75;
        public const int halfFiguresGap = 3;
        public const int figuresGap = halfFiguresGap * 2;
        public const int squareCount = 8;
        public const int mainMenuBtnXSize = 200;
        public const int mainMenuBtnYSize = 100;
        public const int mainMenuBtnGap = 50;
        public const int mainMenuBtnCount = 2;
        public const int fieldSize = (figureSize + figuresGap) * squareCount - figuresGap;
        public const int fieldMiddleX = startX + fieldSize / 2;
        public const int fieldMiddleY = startY + fieldSize / 2;
        public const int mainMenuStartX = fieldMiddleX - mainMenuBtnXSize / 2;
        public const int mainMenuStartY = fieldMiddleY - ((mainMenuBtnYSize + mainMenuBtnGap) * mainMenuBtnCount - mainMenuBtnGap) / 2;
        public const int rightcolumnStartY = startY + 50;
        public const int rightColumnGap = 20;
        public const int rightColumnX = startX + fieldSize + rightColumnGap;
        public const int connMenuGapX = 30;
        public const int connMenuGapY = 20;
        public const int connMenuLabelSizeX = 50;
        public const int connMenuLabelSizeY = 30;
        public const int connMenuTextBoxSizeX = 250;
        public const int connMenuTextBoxSizeY = 30;
        public const int connMenuLabelX = fieldMiddleX - (connMenuLabelSizeX + connMenuTextBoxSizeX + connMenuGapX) / 2;
        public const int connMenuTextBoxX = connMenuLabelX + connMenuLabelSizeX + connMenuGapX;
        public const int hostLabelY = fieldMiddleY - (connMenuLabelSizeY + connMenuTextBoxSizeY + connMenuGapY * 2 + connMenuBtnSizeY) / 2;
        public const int portLabelY = hostLabelY + connMenuLabelSizeY + connMenuGapY;
        public const int connMenuBtnSizeX = 150;
        public const int connMenuBtnSizeY = 60;
        public const int ConnectBtnX = fieldMiddleX - connMenuBtnSizeX - connMenuGapX / 2;
        public const int ReturnToMenuBtn2X = ConnectBtnX + connMenuBtnSizeX + connMenuGapX;
        public const int connMenuBtnY = portLabelY + connMenuLabelSizeY + connMenuGapY;
    }
}
