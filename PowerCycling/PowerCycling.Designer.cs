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
            this.SuspendLayout();
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(12, 12);
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
            this.txtMessageCentre.Location = new System.Drawing.Point(12, 215);
            this.txtMessageCentre.Multiline = true;
            this.txtMessageCentre.Name = "txtMessageCentre";
            this.txtMessageCentre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageCentre.Size = new System.Drawing.Size(399, 34);
            this.txtMessageCentre.TabIndex = 1;
            // 
            // frmPowerCycling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 261);
            this.Controls.Add(this.txtMessageCentre);
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
    }
}

