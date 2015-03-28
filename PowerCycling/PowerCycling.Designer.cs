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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(318, 12);
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
            this.txtMessageCentre.Location = new System.Drawing.Point(12, 263);
            this.txtMessageCentre.Name = "txtMessageCentre";
            this.txtMessageCentre.ReadOnly = true;
            this.txtMessageCentre.Size = new System.Drawing.Size(541, 20);
            this.txtMessageCentre.TabIndex = 1;
            this.txtMessageCentre.TabStop = false;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(399, 12);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // prgT1
            // 
            this.prgT1.Location = new System.Drawing.Point(13, 143);
            this.prgT1.Maximum = 10000;
            this.prgT1.Name = "prgT1";
            this.prgT1.Size = new System.Drawing.Size(176, 14);
            this.prgT1.TabIndex = 2;
            // 
            // prgT2
            // 
            this.prgT2.Location = new System.Drawing.Point(195, 143);
            this.prgT2.Name = "prgT2";
            this.prgT2.Size = new System.Drawing.Size(176, 14);
            this.prgT2.TabIndex = 2;
            // 
            // prgT3
            // 
            this.prgT3.Location = new System.Drawing.Point(377, 143);
            this.prgT3.Name = "prgT3";
            this.prgT3.Size = new System.Drawing.Size(176, 14);
            this.prgT3.TabIndex = 2;
            // 
            // prgCycle
            // 
            this.prgCycle.Location = new System.Drawing.Point(13, 163);
            this.prgCycle.Name = "prgCycle";
            this.prgCycle.Size = new System.Drawing.Size(540, 14);
            this.prgCycle.TabIndex = 2;
            // 
            // txtT1Count
            // 
            this.txtT1Count.Location = new System.Drawing.Point(51, 117);
            this.txtT1Count.Name = "txtT1Count";
            this.txtT1Count.ReadOnly = true;
            this.txtT1Count.Size = new System.Drawing.Size(100, 20);
            this.txtT1Count.TabIndex = 3;
            this.txtT1Count.TabStop = false;
            this.txtT1Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT2Count
            // 
            this.txtT2Count.Location = new System.Drawing.Point(233, 117);
            this.txtT2Count.Name = "txtT2Count";
            this.txtT2Count.ReadOnly = true;
            this.txtT2Count.Size = new System.Drawing.Size(100, 20);
            this.txtT2Count.TabIndex = 3;
            this.txtT2Count.TabStop = false;
            this.txtT2Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT3Count
            // 
            this.txtT3Count.Location = new System.Drawing.Point(415, 117);
            this.txtT3Count.Name = "txtT3Count";
            this.txtT3Count.ReadOnly = true;
            this.txtT3Count.Size = new System.Drawing.Size(100, 20);
            this.txtT3Count.TabIndex = 3;
            this.txtT3Count.TabStop = false;
            this.txtT3Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCycleSet
            // 
            this.txtCycleSet.Location = new System.Drawing.Point(233, 183);
            this.txtCycleSet.MaxLength = 10;
            this.txtCycleSet.Name = "txtCycleSet";
            this.txtCycleSet.Size = new System.Drawing.Size(100, 20);
            this.txtCycleSet.TabIndex = 6;
            this.txtCycleSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCycleSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSet_KeyPress);
            // 
            // txtT1Set
            // 
            this.txtT1Set.Location = new System.Drawing.Point(51, 94);
            this.txtT1Set.MaxLength = 10;
            this.txtT1Set.Name = "txtT1Set";
            this.txtT1Set.Size = new System.Drawing.Size(100, 20);
            this.txtT1Set.TabIndex = 3;
            this.txtT1Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT1Set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSet_KeyPress);
            // 
            // txtT2Set
            // 
            this.txtT2Set.Location = new System.Drawing.Point(233, 94);
            this.txtT2Set.MaxLength = 10;
            this.txtT2Set.Name = "txtT2Set";
            this.txtT2Set.Size = new System.Drawing.Size(100, 20);
            this.txtT2Set.TabIndex = 4;
            this.txtT2Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT2Set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSet_KeyPress);
            // 
            // txtT3Set
            // 
            this.txtT3Set.Location = new System.Drawing.Point(415, 94);
            this.txtT3Set.MaxLength = 10;
            this.txtT3Set.Name = "txtT3Set";
            this.txtT3Set.Size = new System.Drawing.Size(100, 20);
            this.txtT3Set.TabIndex = 5;
            this.txtT3Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtT3Set.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSet_KeyPress);
            // 
            // txtCycleCount
            // 
            this.txtCycleCount.Location = new System.Drawing.Point(233, 206);
            this.txtCycleCount.Name = "txtCycleCount";
            this.txtCycleCount.ReadOnly = true;
            this.txtCycleCount.Size = new System.Drawing.Size(100, 20);
            this.txtCycleCount.TabIndex = 3;
            this.txtCycleCount.TabStop = false;
            this.txtCycleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(480, 12);
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
            this.lblFocus.Location = new System.Drawing.Point(446, 266);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(69, 13);
            this.lblFocus.TabIndex = 7;
            this.lblFocus.Text = "SettingFocus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "T1 (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "T2 (ms)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "T3 (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cycle (ms)";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(12, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Message Centre";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 24);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Power Cycling Control";
            // 
            // frmPowerCycling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 301);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label5);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblTitle;
    }
}

