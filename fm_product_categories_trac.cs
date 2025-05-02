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
    public partial class fm_product_categories_trac : Form
    {


        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static ComboBox ref_comboBoxCatType { get; set; }
        public static TextBox ref_textBoxCatCode { get; set; }
        public static TextBox ref_textBoxCatName { get; set; }

        #endregion

        #region critics
        public fm_product_categories_trac()
        {
            InitializeComponent();
        }

        private void fm_product_categories_trac_Load(object sender, EventArgs e)
        {
            ref_comboBoxCatType = comboBoxCatType;
            ref_textBoxCatCode = textBoxCatCode;
            ref_textBoxCatName = textBoxCatName;
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCatCode_Enter(object sender, EventArgs e)
        {
            if (textBoxCatCode.Text == "Kategori Kodu")
            {
                textBoxCatCode.Text = "";
                textBoxCatCode.ForeColor = Color.White;
            }
        }

        private void textBoxCatCode_Leave(object sender, EventArgs e)
        {
            if (textBoxCatCode.Text == "")
            {
                textBoxCatCode.Text = "Kategori Kodu";
                textBoxCatCode.ForeColor = Color.LightGray;
            }
        }

        private void textBoxCatName_Enter(object sender, EventArgs e)
        {
            if (textBoxCatName.Text == "Kategori Adı")
            {
                textBoxCatName.Text = "";
                textBoxCatName.ForeColor = Color.White;
            }
        }

        private void textBoxCatName_Leave(object sender, EventArgs e)
        {
            if (textBoxCatName.Text == "")
            {
                textBoxCatName.Text = "Kategori Adı";
                textBoxCatName.ForeColor = Color.LightGray;
            }
        }

        private void comboBoxCatType_Leave(object sender, EventArgs e)
        {
            if (comboBoxCatType.Text == "")
            {
                comboBoxCatType.Text = "Ürün Türü";
                comboBoxCatType.ForeColor = Color.LightGray;
            }
        }

        private void comboBoxCatType_Enter(object sender, EventArgs e)
        {
            if (comboBoxCatType.Text == "Ürün Türü")
            {
                comboBoxCatType.Text = "";
                comboBoxCatType.ForeColor = Color.White;
            }
        }

        private void fm_product_categories_trac_MouseDown(object sender, MouseEventArgs e)
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

        private void brick02_MouseDown(object sender, MouseEventArgs e)
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

        private void upsidePanel_MouseDown(object sender, MouseEventArgs e)
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
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', Category_For AS 'Kategori Tipi', Category_Code AS 'Kategori Kodu', Category_Name AS 'Kategori Adı' FROM item_categories", conn);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(ds, "item_categories");
            fm_product_categories.ref_dataGridView1.DataSource = ds;
            fm_product_categories.ref_dataGridView1.DataMember = "item_categories";
        }
        #endregion

        #region events
        #endregion

        #region parts
        //Ekle
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCatType.SelectedIndex != -1 && (textBoxCatCode.Text != "Kategori Kodu" && textBoxCatCode.Text != "")
                && (textBoxCatName.Text != "Kategori Adı" && textBoxCatName.Text != ""))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT Category_Name, Category_Code FROM item_categories WHERE Category_Name = N'" + textBoxCatName.Text + "' OR Category_Code = N'" + textBoxCatCode.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);

                    if (controlnamendcode.Rows.Count == 0)
                    {
                        SqlCommand addcategory = new SqlCommand("INSERT INTO item_categories(Category_For, Category_Code, Category_Name) VALUES(@cf, @cc, @cn)", conn);
                        addcategory.Parameters.AddWithValue("@cf", SqlDbType.NVarChar).Value = comboBoxCatType.SelectedItem.ToString();
                        addcategory.Parameters.AddWithValue("@cc", SqlDbType.NVarChar).Value = textBoxCatCode.Text;
                        addcategory.Parameters.AddWithValue("@cn", SqlDbType.NVarChar).Value = textBoxCatName.Text;

                        conn.Open();
                        addcategory.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();


                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip kategori halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
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

        //Sil
        private void btnDelete_Click(object sender, EventArgs e)
        {


            try
            {
                if (fm_product_categories.id != -1)
                {
                    //önce bagintililari temizle veya sil veya güncelle düzelt işte..
                    SqlCommand deletecatforitems = new SqlCommand("DELETE FROM itemndcategories WHERE category_id = @id", conn);
                    deletecatforitems.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_product_categories.id;

                    conn.Open();
                    deletecatforitems.ExecuteNonQuery();
                    conn.Close();

                    //sonra sil
                    SqlCommand deletecategory = new SqlCommand("DELETE FROM item_categories WHERE id = @id", conn);
                    deletecategory.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_product_categories.id;
                    
                    conn.Open();
                    deletecategory.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();
                    fm_product_categories.id = -1;
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

        //Güncelle
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(fm_product_categories.id != -1 && comboBoxCatType.SelectedIndex != -1 && (textBoxCatCode.Text != "Kategori Kodu" && textBoxCatCode.Text != "") && (textBoxCatName.Text != "Kategori Adı" && textBoxCatName.Text != ""))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT Category_Name, Category_Code FROM item_categories WHERE Category_Name = N'" + textBoxCatName.Text + "' OR Category_Code = N'" + textBoxCatCode.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);

                    if (controlnamendcode.Rows.Count == 0)
                    {
                        SqlCommand updatecategory = new SqlCommand("UPDATE item_categories SET Category_For = @cf, Category_Code = @cc, Category_Name = @cn WHERE id = @id", conn);
                        updatecategory.Parameters.AddWithValue("@cf", SqlDbType.NVarChar).Value = comboBoxCatType.SelectedItem.ToString();
                        updatecategory.Parameters.AddWithValue("@cc", SqlDbType.NVarChar).Value = textBoxCatCode.Text;
                        updatecategory.Parameters.AddWithValue("@cn", SqlDbType.NVarChar).Value = textBoxCatName.Text;
                        updatecategory.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_product_categories.id;

                        conn.Open();
                        updatecategory.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();


                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip kategori halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
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
