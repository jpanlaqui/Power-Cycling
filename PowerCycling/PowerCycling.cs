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
        private PowerCyclingCom I2CReadWrite = new PowerCyclingCom();

        /*==============================================================================================================
        | Description: 
        ==============================================================================================================*/
        public frmPowerCycling()
        {
            InitializeComponent();
        }
        /*==============================================================================================================
        | Description: 
        ==============================================================================================================*/
        private void frmPowerCycling_Load(object sender, EventArgs e)
        {
            //Use to enable or disable the power cycling monitoring
            //frmTimer.Enabled = false;
            //Will be executed when the form is loading
            //To set focus on a control use the select method (focus does not work here - not sure why!)
            lblFocus.Select();

        }
        /*==============================================================================================================
        | Description: 
        ==============================================================================================================*/
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

                //Reset all textboxes and progress bars
                prgT1.Value = 0;
                txtT1Count.Text = "0";
                prgT2.Value = 0;
                txtT2Count.Text = "0";
                prgT3.Value = 0;
                txtT3Count.Text = "0";
                prgCycle.Value = 0;
                txtCycleCount.Text = "0";

                //Send message to message centre textbox
                txtMessageCentre.Text = "Monitoring power cycling parameters...";
                txtMessageCentre.SelectionStart = txtMessageCentre.Text.Length;
                txtMessageCentre.ScrollToCaret();
                txtMessageCentre.Refresh();

                //Change "Monitor" button text
                btnMonitor.Text = "Stop Monitor";

                //This method will start the execution asynchronously in the background
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                //Change "Monitor" button text
                btnMonitor.Text = "Monitor";
                //Cancel the asynchronous operation if still in progress
                backgroundWorker.CancelAsync();
            }
        }
        /*==============================================================================================================
        | Description: 
        ==============================================================================================================*/
        private void btnWrite_Click(object sender, EventArgs e)
        {
            txtMessageCentre.Text =  "Writing power cycling parameters...";
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
            txtMessageCentre.Text =  "Writing power cycling parameters... done!";
            txtMessageCentre.SelectionStart = txtMessageCentre.Text.Length;
            txtMessageCentre.ScrollToCaret();
            txtMessageCentre.Refresh();
        }
        /*==============================================================================================================
        | Description: Reads power cycling parameters and send to background worker progress change
        ==============================================================================================================*/
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //ReadWriteData I2CRead = new ReadWriteData();
            int i = 1;
            uint uintCycleCountPrevious = 0;

            uintT1Count = 0;
            uintT2Count = 0;
            uintT3Count = 0;
            uintCycleCount = 0;

            while (i == 1)
            {
                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    backgroundWorker.ReportProgress(100);
                    break;
                }
                else
                {
                    if (uintT1Count != uintT1Set)
                    {
                        uintT1Count = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_T1COUNT_LSBCMD,
                                  (byte)Aardvark.I2CCommands.PC_T1COUNT_MSBCMD);
                    }
                    else if (uintT2Count != uintT2Set)
                    {
                        uintT2Count = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_T2COUNT_LSBCMD,
                                  (byte)Aardvark.I2CCommands.PC_T2COUNT_MSBCMD);
                    }
                    else
                    {
                        uintT3Count = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_T3COUNT_LSBCMD,
                                  (byte)Aardvark.I2CCommands.PC_T3COUNT_MSBCMD);
                        uintCycleCount = I2CReadWrite.ReadData((byte)Aardvark.I2CCommands.PC_CYCLECOUNT_LSBCMD,
                                  (byte)Aardvark.I2CCommands.PC_CYCLECOUNT_MSBCMD);
                        
                        if (uintCycleCount == uintCycleSet)
                        {
                            i = 0;
                            /*Added to set the T3 progress bar complete at the end of power cycling monitoring*/
                            uintT3Count = uintT3Set;
                        }
                        else if (uintCycleCount > uintCycleCountPrevious)
                        {
                            uintCycleCountPrevious = uintCycleCount;
                            /*Added to set the T3 progress bar complete because I2C is not fast enough to read data*/
                            uintT3Count = uintT3Set;

                            backgroundWorker.ReportProgress(i, new FourUintData(uintT1Count, uintT2Count,
                                                            uintT3Count, uintCycleCount));

                            /*Delay for the T3 progress bar to show complete*/
                            Thread.Sleep(500);

                            /*Reset T1 and T2 count to start updating their progress bar*/
                            uintT1Count = 0;
                            uintT2Count = 0;
                            uintT3Count = 0;
                        }
                    }

                    /*Update the backgroundworker progress change*/
                    backgroundWorker.ReportProgress(i, new FourUintData(uintT1Count, uintT2Count,
                                                    uintT3Count, uintCycleCount));
                    Thread.Sleep(1);
                }
            }
            e.Result = "Monitoring power cycling... done!";
        }
        /*==============================================================================================================
        | Description: Received backgroundWorker power cycling parameters and update UI
        ==============================================================================================================*/
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FourUintData data = (FourUintData)e.UserState;
            if (data != null)
            {
                prgT1.Value = (int)data.Item1;
                txtT1Count.Text = data.Item1.ToString();
                prgT2.Value = (int)data.Item2;
                txtT2Count.Text = data.Item2.ToString();
                prgT3.Value = (int)data.Item3;
                txtT3Count.Text = data.Item3.ToString();
                prgCycle.Value = (int)data.Item4;
                txtCycleCount.Text = data.Item4.ToString();
            }
        }
        /*==============================================================================================================
        | Description: Update message center when background worker is cancelled
        ==============================================================================================================*/
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                txtMessageCentre.Text = "Processing cancelled";
            }
            else if (e.Error != null)
            {
                txtMessageCentre.Text = e.Error.Message;
            }
            else
            {
                //Send message to message centre textbox
                txtMessageCentre.Text = e.Result.ToString();
                //Change "Monitor" button text
                btnMonitor.Text = "Monitor";
            }
        }
        /*==============================================================================================================
        | Description: Accepts only digits and other ke enumeration for entering power cycling paremeters 
        ==============================================================================================================*/
        private void txtSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            //See MSDN and look for the "Key Enumeration", and "8" is the backspace key
            //and "46" is the delete key. Allows only digit keys and backspace key
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        /*==============================================================================================================
        | Description: Exit application when Exit button is pressed
        ==============================================================================================================*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /*==============================================================================================================
        | Description: Data repository for the read power cycling parameters
        ==============================================================================================================*/
        public class FourUintData : System.Tuple<uint, uint, uint, uint>
        {
            public FourUintData(uint r1, uint r2, uint r3, uint r4) : base(r1, r2, r3, r4)
            {
            }
        }
    }
}
