using System.Windows.Forms;

namespace Chess.UI.Controls.CoorinatesAndExtensions
{
    public static class ControlCollectionExtensions
    {
        public static void Add(this Control.ControlCollection controls, GameControls gameControls)
        {
            controls.Add(gameControls.PlayingField);
            controls.Add(gameControls.RightBar);
            controls.Add(gameControls.CheckmateDialog);
        }

        public static void Add(this Control.ControlCollection controls, PlayingField field)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    controls.Add(field[i, j].Figure);
                    controls.Add(field[i, j].TopBacklight);
                    controls.Add(field[i, j].BottomBacklight);
                    controls.Add(field[i, j].LeftBacklight);
                    controls.Add(field[i, j].RightBacklight);
                }
        }

        public static void Add(this Control.ControlCollection controls, RightBar RightBar)
        {
            controls.Add(RightBar.CurColourLabel);
            controls.Add(RightBar.CurColourPict);
            controls.Add(RightBar.PlayerColourLabel);
            controls.Add(RightBar.PlayerColourPict);
            controls.Add(RightBar.CheckLabel);
        }

        public static void Add(this Control.ControlCollection controls, CheckmateDialog CheckmateDialog)
        {
            controls.Add(CheckmateDialog.CheckmateLabel);
            controls.Add(CheckmateDialog.ReturnToMenuBtn);
        }

        public static void Add(this Control.ControlCollection controls, ConnectionMenu connectionMenu)
        {
            controls.Add(connectionMenu.HostLabel);
            controls.Add(connectionMenu.HostTextBox);
            controls.Add(connectionMenu.PortLabel);
            controls.Add(connectionMenu.PortTextBox);
            controls.Add(connectionMenu.StartStopWaitingConnectionBtn);
            controls.Add(connectionMenu.ReturnToMenuBtn2);
        }

        public static void Add(this Control.ControlCollection controls, GameMenu gameMenu)
        {
            for (int i = 0; i < 2; i++)
            {
                controls.Add(gameMenu.Menu[i]);
            }
        }
    }
}