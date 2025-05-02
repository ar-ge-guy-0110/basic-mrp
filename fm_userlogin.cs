using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data.SqlClient;

namespace BasicMRP
{
    public partial class fm_userllogin : Form
    {
        SqlConnection conn = cs_dbconnections.conn;
        public fm_userllogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void fm_userlogin_Load(object sender, EventArgs e)
        {
            cs_pm.mainloginform = this;
            cs_pm.usernamebox = txtusername;
            cs_pm.passwordbox = txtpass;
            cs_pm.loginlabel = infolabel;

            infolabel.Text = "";

            /*
            Form debugg = new fm_debugtest();
            debugg.Show();
            */
        }

        #region UI

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if(txtusername.Text == "KULLANICI ADI")
            {
                txtusername.Text = "";
                txtusername.ForeColor = Color.LightGray;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                txtusername.Text = "KULLANICI ADI";
                txtusername.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "ŞİFRE")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                //txtpass.UseSystemPasswordChar = true;
                txtpass.PasswordChar = '*';
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if(txtpass.Text == "")
            {
                txtpass.Text = "ŞİFRE";
                txtpass.ForeColor = Color.DimGray;
                //txtpass.UseSystemPasswordChar = false;
                txtpass.PasswordChar = '\0';
            }
        }

        private void exitlabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void altlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void fm_userllogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region LoginTransactions
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if((txtusername.Text != "" && txtusername.Text != "KULLANICI ADI") && (txtpass.Text != "" && txtpass.Text != "ŞİFRE"))
            {
                DataTable accounts = new DataTable();
                string sql = "SELECT * FROM puser WHERE username = N'" + txtusername.Text + "' AND password = N'" + txtpass.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(accounts);

                if(accounts.Rows.Count == 1)
                {
                    infolabel.Text = "";
                    cs_pm.logged_user = accounts.Rows[0][1].ToString();
                    cs_pm.logged_user_id = Convert.ToInt32(accounts.Rows[0][0]);
                    cs_pm.logged_user_authority = Convert.ToInt32(accounts.Rows[0][7]);

                    if(cs_pm.logged_user_authority == 1)
                    {
                        this.Hide();
                        //Form adminpanel = new anaform();
                        Form adminpanel = new fm_adminpanel();
                        adminpanel.Show();
                    }
                    else if(cs_pm.logged_user_authority == 2)
                    {
                        this.Close();
                    }
                }
                else
                {
                    infolabel.Text = "Kayıtlarımızda böyle bir hesap bulunamadı.";
                }
            }
            else
            {
                infolabel.Text = "Lütfen bilgilerinizi eksiksiz giriniz.";
            }
        }


        #endregion


    }
}
