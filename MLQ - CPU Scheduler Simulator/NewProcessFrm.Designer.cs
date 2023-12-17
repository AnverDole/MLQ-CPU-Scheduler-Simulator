namespace MLQ___CPU_Scheduler_Simulator
{
    partial class NewProcessFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.queueDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.arrivelTimeNumBox = new System.Windows.Forms.NumericUpDown();
            this.burstTimeNumBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.arrivelTimeNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.burstTimeNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(11, 37);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(306, 27);
            this.nameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Arrivel Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Burst Time";
            // 
            // queueDropDown
            // 
            this.queueDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queueDropDown.FormattingEnabled = true;
            this.queueDropDown.Location = new System.Drawing.Point(10, 215);
            this.queueDropDown.Name = "queueDropDown";
            this.queueDropDown.Size = new System.Drawing.Size(306, 28);
            this.queueDropDown.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Queue";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(123, 261);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 29);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(223, 261);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // arrivelTimeNumBox
            // 
            this.arrivelTimeNumBox.Location = new System.Drawing.Point(11, 97);
            this.arrivelTimeNumBox.Name = "arrivelTimeNumBox";
            this.arrivelTimeNumBox.Size = new System.Drawing.Size(305, 27);
            this.arrivelTimeNumBox.TabIndex = 13;
            // 
            // burstTimeNumBox
            // 
            this.burstTimeNumBox.Location = new System.Drawing.Point(12, 157);
            this.burstTimeNumBox.Name = "burstTimeNumBox";
            this.burstTimeNumBox.Size = new System.Drawing.Size(305, 27);
            this.burstTimeNumBox.TabIndex = 14;
            // 
            // NewProcessFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 306);
            this.Controls.Add(this.burstTimeNumBox);
            this.Controls.Add(this.arrivelTimeNumBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.queueDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewProcessFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Process";
            ((System.ComponentModel.ISupportInitialize)(this.arrivelTimeNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.burstTimeNumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox nameTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox queueDropDown;
        private Label label4;
        private Button cancelBtn;
        private Button addButton;
        private NumericUpDown arrivelTimeNumBox;
        private NumericUpDown burstTimeNumBox;
    }
}