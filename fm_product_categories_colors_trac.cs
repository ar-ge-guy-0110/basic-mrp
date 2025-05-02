using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BasicMRP
{
    public partial class fm_product_categories_colors_trac : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static TextBox ref_txtColCode { get; set; }
        public static TextBox ref_txtColName { get; set; }
        #endregion

        #region critics
        public fm_product_categories_colors_trac()
        {
            InitializeComponent();
        }

        private void fm_product_categories_colors_trac_Load(object sender, EventArgs e)
        {
            ref_txtColCode = txtColCode;
            ref_txtColName = txtColName;
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtColCode_Enter(object sender, EventArgs e)
        {
            if (txtColCode.Text == "Renk Kodu")
            {
                txtColCode.Text = "";
                txtColCode.ForeColor = Color.White;
            }
        }

        private void txtColCode_Leave(object sender, EventArgs e)
        {
            if (txtColCode.Text == "")
            {
                txtColCode.Text = "Renk Kodu";
                txtColCode.ForeColor = Color.LightGray;
            }
        }

        private void txtColName_Enter(object sender, EventArgs e)
        {
            if (txtColName.Text == "Renk Adı")
            {
                txtColName.Text = "";
                txtColName.ForeColor = Color.White;
            }
        }

        private void txtColName_Leave(object sender, EventArgs e)
        {
            if (txtColName.Text == "")
            {
                txtColName.Text = "Renk Adı";
                txtColName.ForeColor = Color.LightGray;
            }
        }

        private void upsidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void brick01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void brick03_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void brick02_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void fm_product_categories_colors_trac_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', Color_Code AS 'Renk Kodu', Color_Name AS 'Renk Adı' FROM colors", conn);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(ds, "colors");
            fm_product_categories_colors.ref_dataGridView1.DataSource = ds;
            fm_product_categories_colors.ref_dataGridView1.DataMember = "colors";
        }
        #endregion

        #region events
        #endregion

        #region parts
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Ekle
            try
            {
                if((txtColCode.Text != "" && txtColCode.Text != "Renk Kodu") && (txtColName.Text != "" && txtColName.Text != "Renk Adı"))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT Color_Code, Color_Name FROM colors WHERE Color_Code = N'" + txtColCode.Text + "' OR Color_Name = N'" + txtColName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);
                    if (controlnamendcode.Rows.Count == 0)
                    {
                        SqlCommand addcolor = new SqlCommand("INSERT INTO colors(Color_Code, Color_Name) VALUES(@cc, @cn)", conn);
                        addcolor.Parameters.AddWithValue("@cc", SqlDbType.NVarChar).Value = txtColCode.Text;
                        addcolor.Parameters.AddWithValue("@cn", SqlDbType.NVarChar).Value = txtColName.Text;

                        conn.Open();
                        addcolor.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();


                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip renk halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün bilgileri girdiğinizden emin olunuz.");
                }
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Sil
            try
            {
                if (fm_product_categories_colors.id != -1)
                {
                    //önce bagintililari temizle veya sil veya güncelle düzelt işte..
                    SqlCommand deletecolforitems = new SqlCommand("DELETE FROM itemndcolors WHERE color_id = @id", conn);
                    deletecolforitems.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_product_categories_colors.id;

                    conn.Open();
                    deletecolforitems.ExecuteNonQuery();
                    conn.Close();

                    //sonra sil
                    SqlCommand deletecolor = new SqlCommand("DELETE FROM colors WHERE id = @id", conn);
                    deletecolor.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_product_categories_colors.id;

                    conn.Open();
                    deletecolor.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();
                    fm_product_categories_colors.id = -1;
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
                }
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Güncelle
            try
            {
                if (fm_product_categories_colors.id != -1 && (txtColCode.Text != "" && txtColCode.Text != "Renk Kodu") && (txtColName.Text != "" && txtColName.Text != "Renk Adı"))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT Color_Code, Color_Name FROM colors WHERE Color_Code = N'" + txtColCode.Text + "' OR Color_Name = N'" + txtColName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);
                    if (controlnamendcode.Rows.Count == 0)
                    {
                        SqlCommand updatecolor = new SqlCommand("UPDATE colors SET Color_Code = @cc, Color_Name = @cn WHERE id = @id", conn);
                        updatecolor.Parameters.AddWithValue("@cc", SqlDbType.NVarChar).Value = txtColCode.Text;
                        updatecolor.Parameters.AddWithValue("@cn", SqlDbType.NVarChar).Value = txtColName.Text;
                        updatecolor.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_product_categories_colors.id;

                        conn.Open();
                        updatecolor.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();


                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip renk halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
                }
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
            }
        }






        #endregion


    }
}
