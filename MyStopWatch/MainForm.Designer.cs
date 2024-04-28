namespace MyStopWatch
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StopWatchDisplay = new Label();
            StartStopButton = new Button();
            ResetButton = new Button();
            WorkList = new ComboBox();
            TabContainer = new TabControl();
            StopWatchPage = new TabPage();
            HistoryPage = new TabPage();
            TabContainer.SuspendLayout();
            StopWatchPage.SuspendLayout();
            SuspendLayout();
            // 
            // StopWatchDisplay
            // 
            StopWatchDisplay.AutoSize = true;
            StopWatchDisplay.Font = new Font("Yu Gothic UI", 72F);
            StopWatchDisplay.ForeColor = Color.FromArgb(255, 192, 255);
            StopWatchDisplay.Location = new Point(0, 0);
            StopWatchDisplay.Name = "StopWatchDisplay";
            StopWatchDisplay.Size = new Size(585, 128);
            StopWatchDisplay.TabIndex = 0;
            StopWatchDisplay.Text = "00:00:00.000";
            // 
            // StartStopButton
            // 
            StartStopButton.Font = new Font("Yu Gothic UI", 16F);
            StartStopButton.Location = new Point(3, 131);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(130, 75);
            StartStopButton.TabIndex = 1;
            StartStopButton.Text = "はじめる";
            StartStopButton.UseVisualStyleBackColor = true;
            StartStopButton.Click += StartButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Font = new Font("Yu Gothic UI", 16F);
            ResetButton.Location = new Point(453, 131);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(130, 75);
            ResetButton.TabIndex = 2;
            ResetButton.Text = "ゼロにする";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // WorkList
            // 
            WorkList.DropDownStyle = ComboBoxStyle.DropDownList;
            WorkList.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkList.FormattingEnabled = true;
            WorkList.Location = new Point(163, 131);
            WorkList.Name = "WorkList";
            WorkList.Size = new Size(248, 38);
            WorkList.TabIndex = 3;
            WorkList.SelectionChangeCommitted += WorkList_SelectionChangeCommitted;
            // 
            // TabContainer
            // 
            TabContainer.Alignment = TabAlignment.Bottom;
            TabContainer.Controls.Add(StopWatchPage);
            TabContainer.Controls.Add(HistoryPage);
            TabContainer.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TabContainer.Location = new Point(0, 0);
            TabContainer.Name = "TabContainer";
            TabContainer.SelectedIndex = 0;
            TabContainer.Size = new Size(594, 248);
            TabContainer.TabIndex = 4;
            // 
            // StopWatchPage
            // 
            StopWatchPage.Controls.Add(StopWatchDisplay);
            StopWatchPage.Controls.Add(WorkList);
            StopWatchPage.Controls.Add(StartStopButton);
            StopWatchPage.Controls.Add(ResetButton);
            StopWatchPage.Location = new Point(4, 4);
            StopWatchPage.Name = "StopWatchPage";
            StopWatchPage.Padding = new Padding(3);
            StopWatchPage.Size = new Size(586, 214);
            StopWatchPage.TabIndex = 0;
            StopWatchPage.Text = "StopWatch";
            StopWatchPage.UseVisualStyleBackColor = true;
            // 
            // HistoryPage
            // 
            HistoryPage.Location = new Point(4, 4);
            HistoryPage.Name = "HistoryPage";
            HistoryPage.Padding = new Padding(3);
            HistoryPage.Size = new Size(586, 214);
            HistoryPage.TabIndex = 1;
            HistoryPage.Text = "History";
            HistoryPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 246);
            Controls.Add(TabContainer);
            Name = "MainForm";
            Text = "すとっぷうぉっち";
            TabContainer.ResumeLayout(false);
            StopWatchPage.ResumeLayout(false);
            StopWatchPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label StopWatchDisplay;
        private Button StartStopButton;
        private Button ResetButton;
        private ComboBox WorkList;
        private TabControl TabContainer;
        private TabPage StopWatchPage;
        private TabPage HistoryPage;
    }
}
