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
            components = new System.ComponentModel.Container();
            StopWatchDisplay = new Label();
            StartStopButton = new Button();
            ResetButton = new Button();
            WorkList = new ComboBox();
            workListBindingSource = new BindingSource(components);
            TabContainer = new TabControl();
            StopWatchPage = new TabPage();
            HistoryPage = new TabPage();
            WorksGridSaveButton = new Button();
            WorksGrid = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)workListBindingSource).BeginInit();
            TabContainer.SuspendLayout();
            StopWatchPage.SuspendLayout();
            HistoryPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WorksGrid).BeginInit();
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
            WorkList.DataSource = workListBindingSource;
            WorkList.DisplayMember = "Title";
            WorkList.DropDownStyle = ComboBoxStyle.DropDownList;
            WorkList.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorkList.FormattingEnabled = true;
            WorkList.Location = new Point(163, 131);
            WorkList.Name = "WorkList";
            WorkList.Size = new Size(248, 38);
            WorkList.TabIndex = 3;
            WorkList.ValueMember = "Id";
            WorkList.SelectionChangeCommitted += WorkList_SelectionChangeCommitted;
            // 
            // workListBindingSource
            // 
            workListBindingSource.DataSource = typeof(Models.Work);
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
            HistoryPage.Controls.Add(WorksGridSaveButton);
            HistoryPage.Controls.Add(WorksGrid);
            HistoryPage.Location = new Point(4, 4);
            HistoryPage.Name = "HistoryPage";
            HistoryPage.Padding = new Padding(3);
            HistoryPage.Size = new Size(586, 214);
            HistoryPage.TabIndex = 1;
            HistoryPage.Text = "History";
            HistoryPage.UseVisualStyleBackColor = true;
            // 
            // WorksGridSaveButton
            // 
            WorksGridSaveButton.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            WorksGridSaveButton.Location = new Point(1, 184);
            WorksGridSaveButton.Margin = new Padding(0);
            WorksGridSaveButton.Name = "WorksGridSaveButton";
            WorksGridSaveButton.Size = new Size(52, 30);
            WorksGridSaveButton.TabIndex = 1;
            WorksGridSaveButton.Text = "保存";
            WorksGridSaveButton.UseVisualStyleBackColor = true;
            WorksGridSaveButton.Click += WorksGridSaveButton_Click;
            // 
            // WorksGrid
            // 
            WorksGrid.AutoGenerateColumns = false;
            WorksGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            WorksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WorksGrid.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, titleDataGridViewTextBoxColumn });
            WorksGrid.DataSource = workListBindingSource;
            WorksGrid.Location = new Point(1, 1);
            WorksGrid.Name = "WorksGrid";
            WorksGrid.ScrollBars = ScrollBars.Vertical;
            WorksGrid.Size = new Size(204, 180);
            WorksGrid.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.HeaderText = "しゅくだい";
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 246);
            Controls.Add(TabContainer);
            Name = "MainForm";
            Text = "すとっぷうぉっち";
            ((System.ComponentModel.ISupportInitialize)workListBindingSource).EndInit();
            TabContainer.ResumeLayout(false);
            StopWatchPage.ResumeLayout(false);
            StopWatchPage.PerformLayout();
            HistoryPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)WorksGrid).EndInit();
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
        private BindingSource workListBindingSource;
        private DataGridView WorksGrid;
        private Button WorksGridSaveButton;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
    }
}
