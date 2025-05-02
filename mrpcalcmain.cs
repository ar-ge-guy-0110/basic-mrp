using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicMRP
{
    public partial class mrpcalcmain : Form
    {
        public mrpcalcmain()
        {
            InitializeComponent();
        }

        private void mrpcalcmain_FormClosed(object sender, FormClosedEventArgs e)
        {
            anaform mainwin = (anaform)Application.OpenForms["anaform"];
            mainwin.mrpwin_opened = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mrpcalc_sod = new mrpcalc_customerorder();
            mrpcalc_sod.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form mrpcalc_cr = new mrpcalc_core();
            mrpcalc_cr.ShowDialog();
        }

        private void mrpcalcmain_Load(object sender, EventArgs e)
        {

        }
    }
}
