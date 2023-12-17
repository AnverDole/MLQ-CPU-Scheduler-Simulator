namespace MLQ___CPU_Scheduler_Simulator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.queuesDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.allProcessesDataGrid = new System.Windows.Forms.DataGridView();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.examplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.example1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.example2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.runBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addNewQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.addNewProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.arrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queuesDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allProcessesDataGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.queuesDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(14, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 601);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Queues";
            // 
            // queuesDataGridView
            // 
            this.queuesDataGridView.AllowUserToAddRows = false;
            this.queuesDataGridView.AllowUserToDeleteRows = false;
            this.queuesDataGridView.AllowUserToResizeColumns = false;
            this.queuesDataGridView.AllowUserToResizeRows = false;
            this.queuesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queuesDataGridView.EnableHeadersVisualStyles = false;
            this.queuesDataGridView.Location = new System.Drawing.Point(6, 27);
            this.queuesDataGridView.MultiSelect = false;
            this.queuesDataGridView.Name = "queuesDataGridView";
            this.queuesDataGridView.ReadOnly = true;
            this.queuesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.queuesDataGridView.RowTemplate.Height = 29;
            this.queuesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.queuesDataGridView.Size = new System.Drawing.Size(352, 569);
            this.queuesDataGridView.TabIndex = 1;
            this.queuesDataGridView.VirtualMode = true;
            this.queuesDataGridView.SelectionChanged += new System.EventHandler(this.queuesDataGridView_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.allProcessesDataGrid);
            this.groupBox2.Location = new System.Drawing.Point(385, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 297);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All processes";
            // 
            // allProcessesDataGrid
            // 
            this.allProcessesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allProcessesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allProcessesDataGrid.Location = new System.Drawing.Point(7, 27);
            this.allProcessesDataGrid.Name = "allProcessesDataGrid";
            this.allProcessesDataGrid.RowHeadersWidth = 51;
            this.allProcessesDataGrid.RowTemplate.Height = 29;
            this.allProcessesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allProcessesDataGrid.Size = new System.Drawing.Size(677, 265);
            this.allProcessesDataGrid.TabIndex = 1;
            this.allProcessesDataGrid.SelectionChanged += new System.EventHandler(this.allProcessesDataGrid_SelectionChanged);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examplesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(46, 24);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // examplesToolStripMenuItem
            // 
            this.examplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.example1ToolStripMenuItem,
            this.example2ToolStripMenuItem});
            this.examplesToolStripMenuItem.Name = "examplesToolStripMenuItem";
            this.examplesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.examplesToolStripMenuItem.Text = "Examples";
            // 
            // example1ToolStripMenuItem
            // 
            this.example1ToolStripMenuItem.Name = "example1ToolStripMenuItem";
            this.example1ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.example1ToolStripMenuItem.Text = "Example 1(Three Queues)";
            this.example1ToolStripMenuItem.Click += new System.EventHandler(this.example1ToolStripMenuItem_Click);
            // 
            // example2ToolStripMenuItem
            // 
            this.example2ToolStripMenuItem.Name = "example2ToolStripMenuItem";
            this.example2ToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.example2ToolStripMenuItem.Text = "Example 2 (Two Queues)";
            this.example2ToolStripMenuItem.Click += new System.EventHandler(this.example2ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // runBtn
            // 
            this.runBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.runBtn.Image = ((System.Drawing.Image)(resources.GetObject("runBtn.Image")));
            this.runBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(38, 24);
            this.runBtn.Text = "Run";
            this.runBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton4,
            this.toolStripSeparator3,
            this.runBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1089, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewQueueToolStripMenuItem,
            this.deleteSelectedQueueToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(66, 24);
            this.toolStripDropDownButton2.Text = "Queue";
            // 
            // addNewQueueToolStripMenuItem
            // 
            this.addNewQueueToolStripMenuItem.Name = "addNewQueueToolStripMenuItem";
            this.addNewQueueToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.addNewQueueToolStripMenuItem.Text = "Add New";
            this.addNewQueueToolStripMenuItem.Click += new System.EventHandler(this.addNewQueueToolStripMenuItem_Click);
            // 
            // deleteSelectedQueueToolStripMenuItem
            // 
            this.deleteSelectedQueueToolStripMenuItem.Enabled = false;
            this.deleteSelectedQueueToolStripMenuItem.Name = "deleteSelectedQueueToolStripMenuItem";
            this.deleteSelectedQueueToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.deleteSelectedQueueToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedQueueToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedQueueToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProcessToolStripMenuItem,
            this.deleteSelectedProcessToolStripMenuItem});
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(86, 24);
            this.toolStripDropDownButton4.Text = "Processes";
            // 
            // addNewProcessToolStripMenuItem
            // 
            this.addNewProcessToolStripMenuItem.Name = "addNewProcessToolStripMenuItem";
            this.addNewProcessToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.addNewProcessToolStripMenuItem.Text = "Add New Process";
            this.addNewProcessToolStripMenuItem.Click += new System.EventHandler(this.addNewProcessToolStripMenuItem_Click);
            // 
            // deleteSelectedProcessToolStripMenuItem
            // 
            this.deleteSelectedProcessToolStripMenuItem.Enabled = false;
            this.deleteSelectedProcessToolStripMenuItem.Name = "deleteSelectedProcessToolStripMenuItem";
            this.deleteSelectedProcessToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.deleteSelectedProcessToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedProcessToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedProcessToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.resultsDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(385, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(690, 299);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.arrivalTime,
            this.name,
            this.queue,
            this.serviceTime,
            this.remainingTime});
            this.resultsDataGridView.Location = new System.Drawing.Point(6, 27);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.RowHeadersWidth = 51;
            this.resultsDataGridView.RowTemplate.Height = 29;
            this.resultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsDataGridView.Size = new System.Drawing.Size(678, 261);
            this.resultsDataGridView.TabIndex = 1;
            // 
            // arrivalTime
            // 
            this.arrivalTime.HeaderText = "Arrival Time";
            this.arrivalTime.MinimumWidth = 6;
            this.arrivalTime.Name = "arrivalTime";
            this.arrivalTime.ReadOnly = true;
            this.arrivalTime.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // queue
            // 
            this.queue.HeaderText = "Queue";
            this.queue.MinimumWidth = 6;
            this.queue.Name = "queue";
            this.queue.ReadOnly = true;
            this.queue.Width = 125;
            // 
            // serviceTime
            // 
            this.serviceTime.HeaderText = "Service Time";
            this.serviceTime.MinimumWidth = 6;
            this.serviceTime.Name = "serviceTime";
            this.serviceTime.ReadOnly = true;
            this.serviceTime.Width = 125;
            // 
            // remainingTime
            // 
            this.remainingTime.HeaderText = "Remaining time";
            this.remainingTime.MinimumWidth = 6;
            this.remainingTime.Name = "remainingTime";
            this.remainingTime.ReadOnly = true;
            this.remainingTime.Width = 125;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 655);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(1095, 691);
            this.Name = "Main";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLQ - CPU Scheduler Simulator";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queuesDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allProcessesDataGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStripLabel toolStripLabel1;
        private GroupBox groupBox1;
        private DataGridView queuesDataGridView;
        private GroupBox groupBox2;
        private DataGridView allProcessesDataGrid;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton runBtn;
        private ToolStrip toolStrip1;
        private GroupBox groupBox3;
        private DataGridView resultsDataGridView;
        private DataGridViewTextBoxColumn arrivalTime;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn queue;
        private DataGridViewTextBoxColumn serviceTime;
        private DataGridViewTextBoxColumn remainingTime;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem addNewQueueToolStripMenuItem;
        private ToolStripMenuItem deleteSelectedQueueToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton4;
        private ToolStripMenuItem addNewProcessToolStripMenuItem;
        private ToolStripMenuItem deleteSelectedProcessToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem examplesToolStripMenuItem;
        private ToolStripMenuItem example1ToolStripMenuItem;
        private ToolStripMenuItem example2ToolStripMenuItem;
    }
}