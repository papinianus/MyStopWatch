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

        private void WorksGridSaveButton_Click(object sender, EventArgs e)
        {
            Model.SaveWorks();

            WorksGrid.Refresh();
            WorkList.Refresh();
        }

        [DllImport("user32.dll")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5392:P/Invoke �ɑ΂��� DefaultDllImportSearchPaths �������g�p����", Justification = "<�ۗ���>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "SYSLIB1054:�R���p�C������ P/Invoke �}�[�V�������O �R�[�h�𐶐�����ɂ́A'DllImportAttribute' �̑���� 'LibraryImportAttribute' ���g�p���܂�", Justification = "<�ۗ���>")]
        private static extern int FlashWindowEx(ref FlashWindowInfo pwFlashWindowInfo);



        // �_�ł��~�߂�
        public const uint FlashWindowStop = 0;
        // �^�C�g���o�[��_�ł�����
        public const uint FlashWindowCaption = 1;
        // �^�X�N�o�[�E�{�^����_�ł�����
        public const uint FlashWindowTray = 2;
        // �^�X�N�o�[�E�{�^���ƃ^�C�g���o�[��_�ł�����
        public const uint FlashWindowAll = 3;
        // FlashWindowStop ���w�肳���܂ł����Ɠ_�ł�����
        public const uint FlashWindowUntilStop = 4;
        // �E�B���h�E���őO�ʂɗ���܂ł����Ɠ_�ł�����
        public const uint FlashWindowUntilForeGround = 12;

        public static nint GetMainWindowHandle(string processName) =>
            Process.GetProcessesByName(processName).FirstOrDefault(x => x.MainWindowHandle != nint.Zero)
                ?.MainWindowHandle ?? nint.Zero;
    }

    [StructLayout(LayoutKind.Sequential)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1815:equals ����� operator equals ��l�^�ŃI�[�o�[���C�h���܂�", Justification = "<�ۗ���>")]
    public struct FlashWindowInfo
    {
        public uint cbSize;    // FlashWindowInfo �\���̂̃T�C�Y
        public nint WindowHandle;      // �_�őΏۂ̃E�B���h�E�E�n���h��
        public uint dwFlags;   // FlashWindow �萔�̂����ꂩ
        public uint uCount;    // �_�ł����
        public uint dwTimeout; // �_�ł���Ԋu�i�~���b�P�ʁj
    }
}
