using System.Diagnostics;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private Stopwatch PrimeClock { get; } = new Stopwatch();
        private Timer TimeDriven { get; } = new Timer { Interval = 10 };
        private MainModel Model { get; } = new MainModel();
        public MainForm()
        {
            
            InitializeComponent();
            Model.SetTimerEvent(TimerTrigger);
            StopWatchDisplay.Focus();
            SetButtonClickShortcut(this, Keys.Space, StartStopButton);
            SetButtonClickShortcut(this, Keys.Z, ResetButton);

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
            switch (Model.state)
            {
                case State.Initial:
                    StartStopButton.Enabled = true;
                    ResetButton.Enabled = false;
                    StartStopButton.Text = "はじめる";
                    break;
                case State.Running:
                    StartStopButton.Enabled = true;
                    ResetButton.Enabled = false;
                    StartStopButton.Text = "とまって";
                    break;
                case State.Stop:
                    StartStopButton.Enabled = true;
                    ResetButton.Enabled = true;
                    StartStopButton.Text = "はじめる";
                    break;
            }
            StopWatchDisplay.Text = Model.GetElapsed();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            var button = sender as Button;
            if(button != null && button.Enabled)
            {
                Model.ToggleStartStop();
                Draw();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            var button = sender as Button;
            if (button != null && button.Enabled)
            {
                Model.Reset();
                Draw();
            }
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

    }
}
