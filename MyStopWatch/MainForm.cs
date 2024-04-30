using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyStopWatch.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;

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

            var fInfo = new FlashWindowInfo { dwFlags = FlashWindowAll, uCount = 3, dwTimeout = 0 };
            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.WindowHandle = GetMainWindowHandle(Program.ProjectName());


            _ = FlashWindowEx(ref fInfo);
            SystemSounds.Beep.Play();
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

        [DllImport("user32.dll")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5392:P/Invoke に対して DefaultDllImportSearchPaths 属性を使用する", Justification = "<保留中>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "SYSLIB1054:コンパイル時に P/Invoke マーシャリング コードを生成するには、'DllImportAttribute' の代わりに 'LibraryImportAttribute' を使用します", Justification = "<保留中>")]
        private static extern int FlashWindowEx(ref FlashWindowInfo pwFlashWindowInfo);



        // 点滅を止める
        public const uint FlashWindowStop = 0;
        // タイトルバーを点滅させる
        public const uint FlashWindowCaption = 1;
        // タスクバー・ボタンを点滅させる
        public const uint FlashWindowTray = 2;
        // タスクバー・ボタンとタイトルバーを点滅させる
        public const uint FlashWindowAll = 3;
        // FlashWindowStop が指定されるまでずっと点滅させる
        public const uint FlashWindowUntilStop = 4;
        // ウィンドウが最前面に来るまでずっと点滅させる
        public const uint FlashWindowUntilForeGround = 12;

        public static nint GetMainWindowHandle(string processName) =>
            Process.GetProcessesByName(processName).FirstOrDefault(x => x.MainWindowHandle != nint.Zero)
                ?.MainWindowHandle ?? nint.Zero;
    }

    [StructLayout(LayoutKind.Sequential)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1815:equals および operator equals を値型でオーバーライドします", Justification = "<保留中>")]
    public struct FlashWindowInfo
    {
        public uint cbSize;    // FlashWindowInfo 構造体のサイズ
        public nint WindowHandle;      // 点滅対象のウィンドウ・ハンドル
        public uint dwFlags;   // FlashWindow 定数のいずれか
        public uint uCount;    // 点滅する回数
        public uint dwTimeout; // 点滅する間隔（ミリ秒単位）
    }
}
