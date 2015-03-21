using PowerCyclingFunctions;
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
        public frmPowerCycling()
        {
            InitializeComponent();
        }

        private void frmPowerCycling_Load(object sender, EventArgs e)
        {
            //txtMessageCentre.Text += "how are you" + "\r\n";
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {

            int port;
            int handle;
            ushort readData;

                

            Aardvark OpenConnection = new Aardvark();
            port = OpenConnection.Aadetect(txtMessageCentre);
            OpenConnection.InitAardvark(port, txtMessageCentre);


            AardvarkApi.aa_close(port);
            handle = AardvarkApi.aa_open(port);

            ReadWriteData I2CRead = new ReadWriteData();

            readData = I2CRead.ReadData(handle,
                                              Aardvark.I2C_ADDRESS,
                                              (byte)Aardvark.I2CCommands.PC_T1_SET_LSB_CMD);

            txtMessageCentre.Text = readData.ToString();


        }
    }
}
