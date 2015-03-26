using PowerCyclingFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TotalPhase;
using PowerCycling;
using System.Threading;

namespace PowerCycling
{
    public partial class frmPowerCycling : Form
    {
        private uint uintT1Set;
        private uint uintT2Set;
        private uint uintT3Set;
        private uint uintCycleSet;
        private uint uintT1Count;
        private uint uintT2Count;
        private uint uintT3Count;
        private uint uintCycleCount;
        private ReadWriteData I2CReadWrite = new ReadWriteData();

        public frmPowerCycling()
        {
            InitializeComponent();
        }

        private void frmPowerCycling_Load(object sender, EventArgs e)
        {
            //Use to enable or disable the power cycling monitoring
            //frmTimer.Enabled = false;
            //Will be executed when the form is loading
            //To set focus on a control use the select method (focus does not work here - not sure why!)
            lblFocus.Select();

        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            // Check if the backgroundWorker is already busy running the asynchronous operation
            if (!backgroundWorker.IsBusy)
            {
                //Read the power cycling set parameters
                uintT1Set = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_T1SET_LSBCMD,
                                            (byte)Aardvark.I2CCommands.PC_T1SET_MSBCMD);
                prgT1.Maximum = (int)uintT1Set;
                txtT1Set.Text = uintT1Set.ToString();
                uintT2Set = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_T2SET_LSBCMD,
                                            (byte)Aardvark.I2CCommands.PC_T2SET_MSBCMD);
                prgT2.Maximum = (int)uintT2Set;
                txtT2Set.Text = uintT2Set.ToString();
                uintT3Set = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_T3SET_LSBCMD,
                                            (byte)Aardvark.I2CCommands.PC_T3SET_MSBCMD);
                prgT3.Maximum = (int)uintT3Set;
                txtT3Set.Text = uintT3Set.ToString();
                uintCycleSet = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_CYCLESET_LSBCMD,
                                            (byte)Aardvark.I2CCommands.PC_CYCLESET_MSBCMD);
                prgCycle.Maximum = (int)uintCycleSet;
                txtCycleSet.Text = uintCycleSet.ToString();

                txtMessageCentre.Text += "Reading power cycling parameters..." + "\r\n";
                txtMessageCentre.SelectionStart = txtMessageCentre.Text.Length;
                txtMessageCentre.ScrollToCaret();
                txtMessageCentre.Refresh();

                // This method will start the execution asynchronously in the background
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                // Cancel the asynchronous operation if still in progress
                backgroundWorker.CancelAsync();
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            txtMessageCentre.Text += "Writing power cycling parameters..." + "\r\n";
            /*-------------------------------------------------------------------------------------------------------*/
            //Read the power cycling set parameters
            //writeData = Convert.ToUInt32(txtT1Set.Text);
            txtT1Count.Text = (I2CReadWrite.WriteData(Convert.ToUInt32(txtT1Set.Text),
                                          (byte)Aardvark.I2CCommands.PC_T1SET_LSBCMD,
                                          (byte)Aardvark.I2CCommands.PC_T1SET_MSBCMD)).ToString();
            //writeData = Convert.ToUInt32(txtT2Set.Text);
            txtT2Count.Text = (I2CReadWrite.WriteData(Convert.ToUInt32(txtT2Set.Text),
                                          (byte)Aardvark.I2CCommands.PC_T2SET_LSBCMD,
                                          (byte)Aardvark.I2CCommands.PC_T2SET_MSBCMD)).ToString();
            //writeData = Convert.ToUInt32(txtT3Set.Text);
            txtT3Count.Text = (I2CReadWrite.WriteData(Convert.ToUInt32(txtT3Set.Text),
                                          (byte)Aardvark.I2CCommands.PC_T3SET_LSBCMD,
                                          (byte)Aardvark.I2CCommands.PC_T3SET_MSBCMD)).ToString();
            //writeData = Convert.ToUInt32(txtCycleSet.Text);
            txtCycleCount.Text = (I2CReadWrite.WriteData(Convert.ToUInt32(txtCycleSet.Text),
                                          (byte)Aardvark.I2CCommands.PC_CYCLESET_LSBCMD,
                                          (byte)Aardvark.I2CCommands.PC_CYCLESET_MSBCMD)).ToString();
            /*-------------------------------------------------------------------------------------------------------*/
            prgT1.Value = 0;
            prgT2.Value = 0;
            prgT3.Value = 0;
            prgCycle.Value = 0;
            lblFocus.Select();
            txtMessageCentre.Text += "Writing power cycling parameters... done!" + "\r\n";
            txtMessageCentre.SelectionStart = txtMessageCentre.Text.Length;
            txtMessageCentre.ScrollToCaret();
            txtMessageCentre.Refresh();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                txtMessageCentre.Text = "Processing cancelled";
            }
            else if (e.Error != null)
            {
                txtMessageCentre.Text = e.Error.Message + "\r\n";
            }
            else
            {
                txtMessageCentre.Text = e.Result.ToString();
            }
        }


        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            I2CCountReads i2c = (I2CCountReads)e.UserState;
            if (i2c != null)
            {
                prgT1.Value = (int)i2c.Item1;
                txtT1Count.Text  = i2c.Item1.ToString();
                prgT2.Value = (int)i2c.Item2;
                txtT2Count.Text = i2c.Item2.ToString();
                prgT3.Value = (int)i2c.Item3;
                txtT3Count.Text = i2c.Item3.ToString();
                prgCycle.Value = (int)i2c.Item4;
                txtCycleCount.Text = i2c.Item4.ToString();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadWriteData I2CRead = new ReadWriteData();
            int i = 0;

            while (true)
            {
                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    backgroundWorker.ReportProgress(100);
                    break;
                }
                else
                {
                    uintT1Count = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T1COUNT_LSBCMD,
                              (byte)Aardvark.I2CCommands.PC_T1COUNT_MSBCMD);
                    uintT2Count = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T2COUNT_LSBCMD,
                              (byte)Aardvark.I2CCommands.PC_T2COUNT_MSBCMD);
                    uintT3Count = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T3COUNT_LSBCMD,
                              (byte)Aardvark.I2CCommands.PC_T3COUNT_MSBCMD);
                    uintCycleCount = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_CYCLECOUNT_LSBCMD,
                              (byte)Aardvark.I2CCommands.PC_CYCLECOUNT_MSBCMD);
                    backgroundWorker.ReportProgress(i, new I2CCountReads(uintT1Count, uintT2Count, uintT3Count, uintCycleCount));

                    Thread.Sleep(1);
                }
            }
        }

        private void txtSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            //See MSDN and look for the "Key Enumeration" and "8" is the backspace key
            //and "46" is the delete key. Allows only digit keys and backspace key
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public class I2CCountReads : System.Tuple<uint, uint, uint, uint>
        {
            public I2CCountReads(uint r1, uint r2, uint r3, uint r4) : base(r1, r2, r3, r4)
            {
            }
        }
    }
}
