using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicMRP
{
    public partial class anaform : Form
    {
        

        public bool uwin_opened { get; set; }
        public bool mwin_opened { get; set; }
        public bool mrpwin_opened { get; set; }
        public anaform()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (treeView1.SelectedNode.Text == "Ürün Tanımları" && uwin_opened == false)
            {
                Form uwin = new urunler();
                uwin.Show();
                uwin_opened = true;
            }
            
            if(treeView1.SelectedNode.Text == "Müşteri Tanımları" && mwin_opened == false)
            {
                Form mwin = new musteriler();
                mwin.Show();
                mwin_opened = true;
            }

            if (treeView1.SelectedNode.Text == "Malzeme Planlama" && mrpwin_opened == false)
            {
                Form mrpwin = new mrpcalcmain();
                mrpwin.Show();
                mrpwin_opened = true;
            }
        }

        private void anaform_Load(object sender, EventArgs e)
        {
            uwin_opened = false;
            mwin_opened = false;
            mrpwin_opened = false;
        }

        private void anaform_FormClosed(object sender, FormClosedEventArgs e)
        {
            cs_pm.usernamebox.ForeColor = Color.DimGray;
            cs_pm.passwordbox.ForeColor = Color.DimGray;
            cs_pm.usernamebox.Text = "KULLANICI ADI";
            cs_pm.passwordbox.Text = "ŞİFRE";
            cs_pm.passwordbox.PasswordChar = '\0';
            cs_pm.loginlabel.Text = "";

            cs_pm.mainloginform.Show();
        }
    }
}
