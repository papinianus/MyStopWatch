using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyStopWatch.Models;
using System.ComponentModel;

namespace MyStopWatch
{
    public partial class MainForm : Form
    {
        private MainModel Model { get; } = new();
        private HistoryModel HistoryModel { get; } = new();
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
            WorkList.SelectedValue = Model.CurrentWork;
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
        private void WorkList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
            {
                return;
            }
            if (comboBox.SelectedValue == null)
            {
                return;
            }
            Model.SelectWork((int)comboBox.SelectedValue);
            Draw();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            workListBindingSource.DataSource = Model.Works;
            // Visibility reset by Binding, so re-set false
            WorksGrid.Columns[0].Visible = false;
            Draw();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Model.Dispose();
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

        private void WorksGridSaveButton_Click(object sender, EventArgs e)
        {
            Model.SaveWorks();

            WorksGrid.Refresh();
            WorkList.Refresh();
        }
    }
}
