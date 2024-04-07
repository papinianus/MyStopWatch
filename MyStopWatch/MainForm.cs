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
                    StartStopButton.Text = "�͂��߂�";
                    break;
                case State.Running:
                    StartStopButton.Enabled = true;
                    ResetButton.Enabled = false;
                    StartStopButton.Text = "�Ƃ܂���";
                    break;
                case State.Stop:
                    StartStopButton.Enabled = true;
                    ResetButton.Enabled = true;
                    StartStopButton.Text = "�͂��߂�";
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
        /// �L�[���͂Ń{�^���N���b�N�C�x���g�����B
        /// </summary>
        /// <param name="control">�L�[���͊Ď�</param>
        /// <param name="keys">���̓L�[</param>
        /// <param name="button">�N���b�N�C�x���g�𔭐�������{�^��</param>
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
        /// �L�[���͂Ń��\�b�h���s�B
        /// </summary>
        /// <param name="control">�L�[���͊Ď�</param>
        /// <param name="keys">���̓L�[</param>
        /// <param name="action">���s���郁�\�b�h</param>
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
