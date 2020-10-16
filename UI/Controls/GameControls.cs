using Chess.UI.Logic;

namespace Chess.UI.Controls
{
    public sealed class GameControls
    {
        public UILogic UILogic { get; }
        public PlayingField PlayingField { get; }
        public RightBar RightBar { get; }
        public CheckmateDialog CheckmateDialog { get; }

        public GameControls(UILogic UILogic)
        {
            this.UILogic = UILogic;
            PlayingField = new PlayingField(UILogic);
            RightBar = new RightBar(UILogic);
            CheckmateDialog = new CheckmateDialog(UILogic);
        }

        public void Show()
        {
            PlayingField.Show();
            RightBar.Show();
        }

        public void Hide()
        {
            PlayingField.Hide();
            RightBar.Hide();
            CheckmateDialog.Hide();
        }
    }
}
