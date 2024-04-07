namespace WinFormsApp1
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
            SuspendLayout();
            // 
            // StopWatchDisplay
            // 
            StopWatchDisplay.AutoSize = true;
            StopWatchDisplay.Font = new Font("Yu Gothic UI", 72F);
            StopWatchDisplay.ForeColor = Color.FromArgb(255, 192, 255);
            StopWatchDisplay.Location = new Point(1, -2);
            StopWatchDisplay.Name = "StopWatchDisplay";
            StopWatchDisplay.Size = new Size(585, 128);
            StopWatchDisplay.TabIndex = 0;
            StopWatchDisplay.Text = "00:00:00.000";
            // 
            // StartStopButton
            // 
            StartStopButton.Font = new Font("Yu Gothic UI", 16F);
            StartStopButton.Location = new Point(27, 140);
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
            ResetButton.Location = new Point(417, 140);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(130, 75);
            ResetButton.TabIndex = 2;
            ResetButton.Text = "ゼロにする";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 224);
            Controls.Add(ResetButton);
            Controls.Add(StartStopButton);
            Controls.Add(StopWatchDisplay);
            Name = "MainForm";
            Text = "すとっぷうぉっち";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StopWatchDisplay;
        private Button StartStopButton;
        private Button ResetButton;
    }
}
