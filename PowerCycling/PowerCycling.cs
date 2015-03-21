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
            txtMessageCentre.Text += "how are you" + "\r\n";
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {

            int port;

            Aardvark OpenConnection = new Aardvark();
            port = OpenConnection.Aadetect(txtMessageCentre);

            txtMessageCentre.Text += "how are you" + "\r\n";

        }
    }
}
