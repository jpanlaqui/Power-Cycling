﻿using PowerCyclingFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalPhase;
using PowerCycling;

namespace PowerCycling
{
    public partial class frmPowerCycling : Form
    {
        private static int count1;
        private static int count2;
        
        public frmPowerCycling()
        {
            InitializeComponent();
        }

        private void frmPowerCycling_Load(object sender, EventArgs e)
        {
            //Use to enable or disable the power cycling monitoring
            frmTimer.Enabled = false;
            //Will be executed when the form is loading
            //To set focus on a control use the select method (focus does not work here - not sure why!)
            lblFocus.Select();

        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            frmTimer.Enabled = !frmTimer.Enabled;
            lblFocus.Select();

            count2 = count1;

            if (!frmTimer.Enabled)
            {
                txtMessageCentre.Text += "Reading power cycling parameters... done!" + "\r\n";
                txtMessageCentre.SelectionStart = txtMessageCentre.Text.Length;
                txtMessageCentre.ScrollToCaret();
                txtMessageCentre.Refresh();
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            txtMessageCentre.Text += "Writing power cycling parameters..." + "\r\n";
            uint readData, writeData;
            ReadWriteData I2CWrite = new ReadWriteData();
            /*-------------------------------------------------------------------------------------------------------*/
            //Read the power cycling set parameters
            writeData = Convert.ToUInt32(txtT1Set.Text);
            readData = I2CWrite.WriteData(writeData,
                                          (byte)Aardvark.I2CCommands.PC_T1_SET_LSB_CMD,
                                          (byte)Aardvark.I2CCommands.PC_T1_SET_MSB_CMD);
            writeData = Convert.ToUInt32(txtT2Set.Text);
            readData = I2CWrite.WriteData(writeData,
                                          (byte)Aardvark.I2CCommands.PC_T2_SET_LSB_CMD,
                                          (byte)Aardvark.I2CCommands.PC_T2_SET_MSB_CMD);
            writeData = Convert.ToUInt32(txtT3Set.Text);
            readData = I2CWrite.WriteData(writeData,
                                          (byte)Aardvark.I2CCommands.PC_T3_SET_LSB_CMD,
                                          (byte)Aardvark.I2CCommands.PC_T3_SET_MSB_CMD);
            writeData = Convert.ToUInt32(txtCycleSet.Text);
            readData = I2CWrite.WriteData(writeData,
                                          (byte)Aardvark.I2CCommands.PC_COUNT_SET_LSB_CMD,
                                          (byte)Aardvark.I2CCommands.PC_COUNT_SET_MSB_CMD);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtT1Set_KeyPress(object sender, KeyPressEventArgs e)
        {
            //See MSDN and look for the "Key Enumeration" and "8" is the backspace key
            //and "46" is the delete key. Allows only digit keys and backspace key
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;

            }
        }

        private void frmTimer_Tick(object sender, EventArgs e)
        {
            txtMessageCentre.Text += "Reading power cycling parameters..." + "\r\n";

            uint readData;
            ReadWriteData I2CRead = new ReadWriteData();
            /*-------------------------------------------------------------------------------------------------------*/
            if (count2 == count1)
            {
                //Read the power cycling set parameters
                readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T1_SET_LSB_CMD,
                                            (byte)Aardvark.I2CCommands.PC_T1_SET_MSB_CMD);
                prgT1.Maximum = (int)readData;
                txtT1Set.Text = readData.ToString();
                readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T2_SET_LSB_CMD,
                                            (byte)Aardvark.I2CCommands.PC_T2_SET_MSB_CMD);
                prgT2.Maximum = (int)readData;
                txtT2Set.Text = readData.ToString();
                readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T3_SET_LSB_CMD,
                                            (byte)Aardvark.I2CCommands.PC_T3_SET_MSB_CMD);
                prgT3.Maximum = (int)readData;
                txtT3Set.Text = readData.ToString();
                readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_COUNT_SET_LSB_CMD,
                                            (byte)Aardvark.I2CCommands.PC_COUNT_SET_MSB_CMD);
                prgCycle.Maximum = (int)readData;
                txtCycleSet.Text = readData.ToString();

                count1++;
            }

            /*-------------------------------------------------------------------------------------------------------*/
            //Read the power cycling counts
            readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T1_COUNT_LSB_CMD,
                                        (byte)Aardvark.I2CCommands.PC_T1_COUNT_MSB_CMD);
            prgT1.Value = (int)readData;
            txtT1Count.Text = readData.ToString();
            readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T2_COUNT_LSB_CMD,
                                        (byte)Aardvark.I2CCommands.PC_T2_COUNT_MSB_CMD);
            prgT2.Value = (int)readData;
            txtT2Count.Text = readData.ToString();
            readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_T3_COUNT_LSB_CMD,
                                        (byte)Aardvark.I2CCommands.PC_T3_COUNT_MSB_CMD);
            prgT3.Value = (int)readData;
            txtT3Count.Text = readData.ToString();
            readData = I2CRead.ReadData((byte)Aardvark.I2CCommands.PC_COUNT_LSB_CMD,
                                        (byte)Aardvark.I2CCommands.PC_COUNT_MSB_CMD);
            prgCycle.Value = (int)readData;
            txtCycleCount.Text = readData.ToString();
            /*-------------------------------------------------------------------------------------------------------*/
        }
    }
}
