namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private MainModel Model { get; } = new MainModel();
        public MainForm()
        {

            InitializeComponent();
            Model.SetTimerEvent(TimerTrigger);
            StopWatchDisplay.Focus();
            SetButtonClickShortcut(this, Keys.Space, StartStopButton);
            SetButtonClickShortcut(this, Keys.Z, ResetButton);
            WorkList.DataSource = Model.WorkTitles();

            MaximizeBox = false;
            MinimizeBox = false;
            MaximumSize = Size;

            Draw();
        }

        private void TimerTrigger(object? sender, EventArgs e)
        {
            Draw();
        }
        private void Draw()
        {
            StartStopButton.Enabled = Model.CanStart() || Model.CanStop();
            ResetButton.Enabled = Model.CanReset();
            StartStopButton.Text = Model.StartStopTitle();
            StopWatchDisplay.Text = Model.GetElapsed();
            WorkList.SelectedIndex = Model.CurrentWork;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            var button = sender as Button;
            if (button == null || !button.Enabled)
            {
                return;
            }
            Model.ToggleStartStop();
            Draw();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            var button = sender as Button;
            if (button == null || !button.Enabled)
            {
                return;
            }
            Model.Reset();
            Draw();
        }

        //https://sabine.hatenablog.com/entry/2012/07/24/001113
        /// <summary>
        /// キー入力でボタンクリックイベント発生。
        /// </summary>
        /// <param name="control">キー入力監視</param>
        /// <param name="keys">入力キー</param>
        /// <param name="button">クリックイベントを発生させるボタン</param>
        public static void SetButtonClickShortcut(Control control, Keys keys, Button button)
        {
            control.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == keys)
                {
                    button.PerformClick();
                }
            };
        }

        /// <summary>
        /// キー入力でメソッド実行。
        /// </summary>
        /// <param name="control">キー入力監視</param>
        /// <param name="keys">入力キー</param>
        /// <param name="action">実行するメソッド</param>
        public static void SetMethodInvokeShortcut(Control control, Keys keys, MethodInvoker action)
        {
            control.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == keys)
                {
                    action.Invoke();
                }
            };
        }

        private void WorkList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
            {
                return;
            }
            Model.SelectWork(comboBox.SelectedIndex);
            Draw();
        }
    }
}
