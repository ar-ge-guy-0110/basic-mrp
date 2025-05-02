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
    public partial class fm_adminpanel : Form
    {
        #region values
        public static Panel ref_ContainerPanel { get; set; }

        int menuvertical_width;
        #endregion

        #region critics
        public fm_adminpanel()
        {
            InitializeComponent();
        }


        private void fm_adminpanel_Load(object sender, EventArgs e)
        {
            ref_ContainerPanel = ContainerPanel;

            menuvertical_width = MenuVertical.Width;
        }
        #endregion

        #region UI
        private void btnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == menuvertical_width)
            {
                MenuVertical.Width = 50;
                picBoxBrand.Visible = false;
            }
            else
            {
                MenuVertical.Width = menuvertical_width;
                picBoxBrand.Visible = true;
            }
        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picBoxMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picBoxRefresh.Visible = true;
            picBoxMaximize.Visible = false;
        }

        private void picBoxRefresh_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picBoxRefresh.Visible = false;
            picBoxMaximize.Visible = true;
        }

        private void picBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ContainerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void MenuVertical_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void UpsideMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        #endregion

        #region funcs

        private void OpenFormInPanel(object FormChild)
        {
            if(this.ContainerPanel.Controls.Count > 0)
            {
                //this.ContainerPanel.Controls.RemoveAt(0);

                /*
                List<Control> listControls = new List<Control>();

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    listControls.Add(control);
                }

                foreach (Control control in listControls)
                {
                    flowLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                }
                */

                List<Control> listControls = new List<Control>();

                foreach (Control control in ContainerPanel.Controls)
                {
                    listControls.Add(control);
                }

                foreach (Control control in listControls)
                {
                    ContainerPanel.Controls.Remove(control);
                    control.Dispose();
                }
            }


            Form fc = FormChild as Form;
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            this.ContainerPanel.Controls.Add(fc);
            this.ContainerPanel.Tag = fc;
            fc.FormClosed += new FormClosedEventHandler(btnformclosepaint);
            fc.Show();
        }

        private void btnformopenpaint(Panel pnl, Button btn)
        {
            //List<Control> listbuttons = new List<Control>();
            foreach(Control control in pnl.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = Color.FromArgb(240, 55, 65);
                }
            }

            btn.BackColor = Color.FromArgb(30, 30, 30);
        }




        private void btnformclosepaint(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["fm_products"] == null)
            {
                btnProducts.BackColor = Color.FromArgb(240, 55, 65);
            }
        }

        #endregion

        #region events

        #endregion

        #region parts

        private void btnProducts_Click(object sender, EventArgs e)
        {
            btnformopenpaint(MenuVertical, btnProducts);

            if (ContainerPanel.Controls.ContainsKey("fm_products"))
            {

            }
            else
            {
                OpenFormInPanel(new fm_products());
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            btnformopenpaint(MenuVertical, btnDepartment);

            if (ContainerPanel.Controls.ContainsKey("fm_departments"))
            {

            }
            else
            {
                OpenFormInPanel(new fm_departments());
            }
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            btnformopenpaint(MenuVertical, btnCost);

            if (ContainerPanel.Controls.ContainsKey("fm_costs"))
            {

            }
            else
            {
                OpenFormInPanel(new fm_costs());
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            btnformopenpaint(MenuVertical, btnCustomer);

            if (ContainerPanel.Controls.ContainsKey("fm_customers"))
            {

            }
            else
            {
                OpenFormInPanel(new fm_customers());
            }
        }

        #endregion

        private void btnProdPlan_Click(object sender, EventArgs e)
        {
            btnformopenpaint(MenuVertical, btnProdPlan);

            if (ContainerPanel.Controls.ContainsKey("CALCULDEBUG"))
            {

            }
            else
            {
                OpenFormInPanel(new CALCULDEBUG());
            }

        }


        private void btnSupplier_Click(object sender, EventArgs e)
        {
            btnformopenpaint(MenuVertical, btnSupplier);

            if (ContainerPanel.Controls.ContainsKey("fm_suppliers"))
            {

            }
            else
            {
                OpenFormInPanel(new fm_suppliers());
            }
        }
    }
}
