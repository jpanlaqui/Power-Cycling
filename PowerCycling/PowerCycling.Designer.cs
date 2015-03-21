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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.txtT1Count = new System.Windows.Forms.TextBox();
            this.txtT2Count = new System.Windows.Forms.TextBox();
            this.txtT3Count = new System.Windows.Forms.TextBox();
            this.txtCycleSet = new System.Windows.Forms.TextBox();
            this.txtT1Set = new System.Windows.Forms.TextBox();
            this.txtT2Set = new System.Windows.Forms.TextBox();
            this.txtT3Set = new System.Windows.Forms.TextBox();
            this.txtCycleCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(246, 9);
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
            this.txtMessageCentre.AcceptsTab = true;
            this.txtMessageCentre.Location = new System.Drawing.Point(12, 225);
            this.txtMessageCentre.Multiline = true;
            this.txtMessageCentre.Name = "txtMessageCentre";
            this.txtMessageCentre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageCentre.Size = new System.Drawing.Size(541, 46);
            this.txtMessageCentre.TabIndex = 1;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(246, 38);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 0;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 130);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(176, 14);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(195, 130);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(176, 14);
            this.progressBar2.TabIndex = 2;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(377, 130);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(176, 14);
            this.progressBar3.TabIndex = 2;
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(13, 150);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(540, 14);
            this.progressBar4.TabIndex = 2;
            // 
            // txtT1Count
            // 
            this.txtT1Count.Location = new System.Drawing.Point(51, 104);
            this.txtT1Count.Name = "txtT1Count";
            this.txtT1Count.ReadOnly = true;
            this.txtT1Count.Size = new System.Drawing.Size(100, 20);
            this.txtT1Count.TabIndex = 3;
            this.txtT1Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT2Count
            // 
            this.txtT2Count.Location = new System.Drawing.Point(233, 104);
            this.txtT2Count.Name = "txtT2Count";
            this.txtT2Count.ReadOnly = true;
            this.txtT2Count.Size = new System.Drawing.Size(100, 20);
            this.txtT2Count.TabIndex = 3;
            this.txtT2Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT3Count
            // 
            this.txtT3Count.Location = new System.Drawing.Point(415, 104);
            this.txtT3Count.Name = "txtT3Count";
            this.txtT3Count.ReadOnly = true;
            this.txtT3Count.Size = new System.Drawing.Size(100, 20);
            this.txtT3Count.TabIndex = 3;
            this.txtT3Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCycleSet
            // 
            this.txtCycleSet.Location = new System.Drawing.Point(233, 170);
            this.txtCycleSet.Name = "txtCycleSet";
            this.txtCycleSet.Size = new System.Drawing.Size(100, 20);
            this.txtCycleSet.TabIndex = 3;
            this.txtCycleSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT1Set
            // 
            this.txtT1Set.Location = new System.Drawing.Point(51, 78);
            this.txtT1Set.Name = "txtT1Set";
            this.txtT1Set.Size = new System.Drawing.Size(100, 20);
            this.txtT1Set.TabIndex = 3;
            this.txtT1Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT2Set
            // 
            this.txtT2Set.Location = new System.Drawing.Point(233, 78);
            this.txtT2Set.Name = "txtT2Set";
            this.txtT2Set.Size = new System.Drawing.Size(100, 20);
            this.txtT2Set.TabIndex = 3;
            this.txtT2Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtT3Set
            // 
            this.txtT3Set.Location = new System.Drawing.Point(415, 78);
            this.txtT3Set.Name = "txtT3Set";
            this.txtT3Set.Size = new System.Drawing.Size(100, 20);
            this.txtT3Set.TabIndex = 3;
            this.txtT3Set.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCycleCount
            // 
            this.txtCycleCount.Location = new System.Drawing.Point(233, 196);
            this.txtCycleCount.Name = "txtCycleCount";
            this.txtCycleCount.ReadOnly = true;
            this.txtCycleCount.Size = new System.Drawing.Size(100, 20);
            this.txtCycleCount.TabIndex = 3;
            this.txtCycleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPowerCycling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 283);
            this.Controls.Add(this.txtCycleCount);
            this.Controls.Add(this.txtCycleSet);
            this.Controls.Add(this.txtT3Set);
            this.Controls.Add(this.txtT3Count);
            this.Controls.Add(this.txtT2Set);
            this.Controls.Add(this.txtT2Count);
            this.Controls.Add(this.txtT1Set);
            this.Controls.Add(this.txtT1Count);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtMessageCentre);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnMonitor);
            this.Name = "frmPowerCycling";
            this.Text = "Power Cycling Control";
            this.Load += new System.EventHandler(this.frmPowerCycling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.TextBox txtMessageCentre;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.TextBox txtT1Count;
        private System.Windows.Forms.TextBox txtT2Count;
        private System.Windows.Forms.TextBox txtT3Count;
        private System.Windows.Forms.TextBox txtCycleSet;
        private System.Windows.Forms.TextBox txtT1Set;
        private System.Windows.Forms.TextBox txtT2Set;
        private System.Windows.Forms.TextBox txtT3Set;
        private System.Windows.Forms.TextBox txtCycleCount;
    }
}

