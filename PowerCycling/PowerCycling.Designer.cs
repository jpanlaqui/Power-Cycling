namespace PowerCycling
{
    partial class frmPowerCycling
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
            this.components = new System.ComponentModel.Container();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtMessageCentre = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.prgT1 = new System.Windows.Forms.ProgressBar();
            this.prgT2 = new System.Windows.Forms.ProgressBar();
            this.prgT3 = new System.Windows.Forms.ProgressBar();
            this.prgCycle = new System.Windows.Forms.ProgressBar();
            this.txtT1Count = new System.Windows.Forms.TextBox();
            this.txtT2Count = new System.Windows.Forms.TextBox();
            this.txtT3Count = new System.Windows.Forms.TextBox();
            this.txtCycleSet = new System.Windows.Forms.TextBox();
            this.txtT1Set = new System.Windows.Forms.TextBox();
            this.txtT2Set = new System.Windows.Forms.TextBox();
            this.txtT3Set = new System.Windows.Forms.TextBox();
            this.txtCycleCount = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblFocus = new System.Windows.Forms.Label();
            this.frmTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(13, 11);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 0;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtMessageCentre
            // 
            this.txtMessageCentre.AcceptsReturn = true;
            this.txtMessageCentre.Location = new System.Drawing.Point(12, 215);
            this.txtMessageCentre.Multiline = true;
            this.txtMessageCentre.Name = "txtMessageCentre";
            this.txtMessageCentre.ReadOnly = true;
            this.txtMessageCentre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageCentre.Size = new System.Drawing.Size(541, 35);
            this.txtMessageCentre.TabIndex = 1;
            this.txtMessageCentre.TabStop = false;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(94, 11);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // prgT1
            // 
            this.prgT1.Location = new System.Drawing.Point(13, 109);
            this.prgT1.Name = "prgT1";
            this.prgT1.Size = new System.Drawing.Size(176, 14);
            this.prgT1.TabIndex = 2;
            // 
            // prgT2
            // 
            this.prgT2.Location = new System.Drawing.Point(195, 109);
            this.prgT2.Name = "prgT2";
            this.prgT2.Size = new System.Drawing.Size(176, 14);
            this.prgT2.TabIndex = 2;
            // 
            // prgT3
            // 
            this.prgT3.Location = new System.Drawing.Point(377, 109);
            this.prgT3.Name = "prgT3";
            this.prgT3.Size = new System.Drawing.Size(176, 14);
            this.prgT3.TabIndex = 2;
            // 
            // prgCycle
            // 
            this.prgCycle.Location = new System.Drawing.Point(13, 129);
            this.prgCycle.Name = "prgCycle";
            this.prgCycle.Size = new System.Drawing.Size(540, 14);
            this.prgCycle.TabIndex = 2;
            // 
            // txtT1Count
            // 
            this.txtT1Count.Location = new System.Drawing.Point(51, 83);
            this.txtT1Count.Name = "txtT1Count";
            this.txtT1Count.ReadOnly = true;
            this.txtT1Count.Size = new System.Drawing.Size(100, 20);
            this.txtT1Count.TabIndex = 3;
            this.txtT1Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT2Count
            // 
            this.txtT2Count.Location = new System.Drawing.Point(233, 83);
            this.txtT2Count.Name = "txtT2Count";
            this.txtT2Count.ReadOnly = true;
            this.txtT2Count.Size = new System.Drawing.Size(100, 20);
            this.txtT2Count.TabIndex = 3;
            this.txtT2Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT3Count
            // 
            this.txtT3Count.Location = new System.Drawing.Point(415, 83);
            this.txtT3Count.Name = "txtT3Count";
            this.txtT3Count.ReadOnly = true;
            this.txtT3Count.Size = new System.Drawing.Size(100, 20);
            this.txtT3Count.TabIndex = 3;
            this.txtT3Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCycleSet
            // 
            this.txtCycleSet.Location = new System.Drawing.Point(233, 149);
            this.txtCycleSet.MaxLength = 10;
            this.txtCycleSet.Name = "txtCycleSet";
            this.txtCycleSet.Size = new System.Drawing.Size(100, 20);
            this.txtCycleSet.TabIndex = 6;
            this.txtCycleSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCycleSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT1Set_KeyPress);
            // 
            // txtT1Set
            // 
            this.txtT1Set.Location = new System.Drawing.Point(51, 60);
            this.txtT1Set.MaxLength = 10;
            this.txtT1Set.Name = "txtT1Set";
            this.txtT1Set.Size = new System.Drawing.Size(100, 20);
            this.txtT1Set.TabIndex = 3;
            this.txtT1Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT1Set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT1Set_KeyPress);
            // 
            // txtT2Set
            // 
            this.txtT2Set.Location = new System.Drawing.Point(233, 60);
            this.txtT2Set.MaxLength = 10;
            this.txtT2Set.Name = "txtT2Set";
            this.txtT2Set.Size = new System.Drawing.Size(100, 20);
            this.txtT2Set.TabIndex = 4;
            this.txtT2Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT2Set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT1Set_KeyPress);
            // 
            // txtT3Set
            // 
            this.txtT3Set.Location = new System.Drawing.Point(415, 60);
            this.txtT3Set.MaxLength = 10;
            this.txtT3Set.Name = "txtT3Set";
            this.txtT3Set.Size = new System.Drawing.Size(100, 20);
            this.txtT3Set.TabIndex = 5;
            this.txtT3Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT3Set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtT1Set_KeyPress);
            // 
            // txtCycleCount
            // 
            this.txtCycleCount.Location = new System.Drawing.Point(233, 172);
            this.txtCycleCount.Name = "txtCycleCount";
            this.txtCycleCount.ReadOnly = true;
            this.txtCycleCount.Size = new System.Drawing.Size(100, 20);
            this.txtCycleCount.TabIndex = 3;
            this.txtCycleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(175, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFocus
            // 
            this.lblFocus.AutoSize = true;
            this.lblFocus.Location = new System.Drawing.Point(446, 217);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(69, 13);
            this.lblFocus.TabIndex = 7;
            this.lblFocus.Text = "SettingFocus";
            // 
            // frmTimer
            // 
            this.frmTimer.Interval = 10;
            this.frmTimer.Tick += new System.EventHandler(this.frmTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "T1 (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "T2 (ms)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "T3 (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cycle (ms)";
            // 
            // frmPowerCycling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 259);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCycleCount);
            this.Controls.Add(this.txtCycleSet);
            this.Controls.Add(this.txtT3Set);
            this.Controls.Add(this.txtT3Count);
            this.Controls.Add(this.txtT2Set);
            this.Controls.Add(this.txtT2Count);
            this.Controls.Add(this.txtT1Set);
            this.Controls.Add(this.txtT1Count);
            this.Controls.Add(this.prgT3);
            this.Controls.Add(this.prgT2);
            this.Controls.Add(this.prgCycle);
            this.Controls.Add(this.prgT1);
            this.Controls.Add(this.txtMessageCentre);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.lblFocus);
            this.Name = "frmPowerCycling";
            this.Text = "Power Cycling Control";
            this.Load += new System.EventHandler(this.frmPowerCycling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtT1Set_KeyPress(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.TextBox txtMessageCentre;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.ProgressBar prgT1;
        private System.Windows.Forms.ProgressBar prgT2;
        private System.Windows.Forms.ProgressBar prgT3;
        private System.Windows.Forms.ProgressBar prgCycle;
        private System.Windows.Forms.TextBox txtT1Count;
        private System.Windows.Forms.TextBox txtT2Count;
        private System.Windows.Forms.TextBox txtT3Count;
        private System.Windows.Forms.TextBox txtCycleSet;
        private System.Windows.Forms.TextBox txtT1Set;
        private System.Windows.Forms.TextBox txtT2Set;
        private System.Windows.Forms.TextBox txtT3Set;
        private System.Windows.Forms.TextBox txtCycleCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblFocus;
        private System.Windows.Forms.Timer frmTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

