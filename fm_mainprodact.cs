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
    public partial class fm_mainprodact : Form
    {




        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static ComboBox ref_cmbPrType { get; set; }
        public static ComboBox ref_cmbPrCategory { get; set; }
        public static ComboBox ref_cmbPrColor { get; set; }
        public static ComboBox ref_cmbPrDepartment { get; set; }
        public static TextBox ref_txtPrCode { get; set; }
        public static TextBox ref_txtPrName { get; set; }
        public static TextBox ref_txtPrUnit { get; set; }
        int categoryid;
        int colorid;
        int departmentid;
        #endregion

        #region critics

        public fm_mainprodact()
        {
            InitializeComponent();
        }

        private void fm_mainprodact_Load(object sender, EventArgs e)
        {
            categoryid = -1;
            colorid = -1;
            departmentid = -1;

            ref_cmbPrType = cmbPrType;
            ref_cmbPrCategory = cmbPrCategory;
            ref_cmbPrColor = cmbPrColor;
            ref_cmbPrDepartment = cmbPrDepartment;
            ref_txtPrCode = txtPrCode;
            ref_txtPrName = txtPrName;
            ref_txtPrUnit = txtPrUnit;

            //cmb doldur.
            try
            {
                conn.Open();
                SqlCommand fillcmbcolor = new SqlCommand("SELECT Color_Name FROM colors", conn);
                SqlDataReader read1 = fillcmbcolor.ExecuteReader();
                while (read1.Read())
                {
                    cmbPrColor.Items.Add(read1["Color_Name"]);
                }
                conn.Close();

                conn.Open();
                SqlCommand fillcmbdepartment = new SqlCommand("SELECT department FROM prodord_department", conn);
                SqlDataReader read2 = fillcmbdepartment.ExecuteReader();
                while (read2.Read())
                {
                    cmbPrDepartment.Items.Add(read2["department"]);
                }
                conn.Close();
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

        #region UI

        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPrType_Enter(object sender, EventArgs e)
        {
            if (cmbPrType.Text == "Ürün Ana Tipi")
            {
                cmbPrType.Text = "";
                cmbPrType.ForeColor = Color.White;
            }
        }

        private void cmbPrType_Leave(object sender, EventArgs e)
        {
            if (cmbPrType.Text == "")
            {
                cmbPrType.Text = "Ürün Ana Tipi";
                cmbPrType.ForeColor = Color.LightGray;
            }
        }

        private void cmbPrCategory_Enter(object sender, EventArgs e)
        {
            if (cmbPrCategory.Text == "Ürün Kategorisi")
            {
                cmbPrCategory.Text = "";
                cmbPrCategory.ForeColor = Color.White;
            }
        }

        private void cmbPrCategory_Leave(object sender, EventArgs e)
        {
            if (cmbPrCategory.Text == "")
            {
                cmbPrCategory.Text = "Ürün Kategorisi";
                cmbPrCategory.ForeColor = Color.LightGray;
            }
        }

        private void cmbPrColor_Enter(object sender, EventArgs e)
        {
            if (cmbPrColor.Text == "Ürün Rengi")
            {
                cmbPrColor.Text = "";
                cmbPrColor.ForeColor = Color.White;
            }
        }

        private void cmbPrColor_Leave(object sender, EventArgs e)
        {
            if (cmbPrColor.Text == "")
            {
                cmbPrColor.Text = "Ürün Rengi";
                cmbPrColor.ForeColor = Color.LightGray;
            }
        }

        private void cmbPrDepartment_Enter(object sender, EventArgs e)
        {
            if (cmbPrDepartment.Text == "Departmanı")
            {
                cmbPrDepartment.Text = "";
                cmbPrDepartment.ForeColor = Color.White;
            }
        }

        private void cmbPrDepartment_Leave(object sender, EventArgs e)
        {
            if (cmbPrDepartment.Text == "")
            {
                cmbPrDepartment.Text = "Departmanı";
                cmbPrDepartment.ForeColor = Color.LightGray;
            }
        }

        private void txtPrCode_Enter(object sender, EventArgs e)
        {
            if (txtPrCode.Text == "Ürün Kodu")
            {
                txtPrCode.Text = "";
                txtPrCode.ForeColor = Color.White;
            }
        }

        private void txtPrCode_Leave(object sender, EventArgs e)
        {
            if (txtPrCode.Text == "")
            {
                txtPrCode.Text = "Ürün Kodu";
                txtPrCode.ForeColor = Color.LightGray;
            }
        }

        private void txtPrName_Enter(object sender, EventArgs e)
        {
            if (txtPrName.Text == "Ürün Adı")
            {
                txtPrName.Text = "";
                txtPrName.ForeColor = Color.White;
            }
        }

        private void txtPrName_Leave(object sender, EventArgs e)
        {
            if (txtPrName.Text == "")
            {
                txtPrName.Text = "Ürün Adı";
                txtPrName.ForeColor = Color.LightGray;
            }
        }

        private void txtPrUnit_Enter(object sender, EventArgs e)
        {
            if (txtPrUnit.Text == "Ürün Birimi")
            {
                txtPrUnit.Text = "";
                txtPrUnit.ForeColor = Color.White;
            }
        }

        private void txtPrUnit_Leave(object sender, EventArgs e)
        {
            if (txtPrUnit.Text == "")
            {
                txtPrUnit.Text = "Ürün Birimi";
                txtPrUnit.ForeColor = Color.LightGray;
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

        private void fm_mainprodact_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }
        #endregion

        #region funcs

        private void updateDataGrid(DataGridView datagridview, string sqlstring, SqlConnection connection, string datamember)
        {
            SqlCommand fill = new SqlCommand(sqlstring, connection);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(ds, datamember);
            datagridview.DataSource = ds;
            datagridview.DataMember = datamember;
        }

        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand(@"SELECT item.id AS 'ID', item.itemtype AS 'Ürün Tipi', item_categories.Category_Name AS 'Ürün Kategorisi', 
            item.itemcode AS 'Ürün Kodu', item.itemname AS 'Ürün Adı', item.unitcode AS 'Ürün Birimi', 
            colors.Color_Name AS 'Ürün Ana Rengi', item.date_of_addition AS 'Eklenme Tarihi', 
            prodord_department.department AS 'Departmanı' FROM item 
            LEFT JOIN itemndcategories ON item.id = itemndcategories.item_id 
            LEFT JOIN item_categories ON itemndcategories.category_id = item_categories.id 
            LEFT JOIN itemndcolors ON item.id = itemndcolors.item_id 
            LEFT JOIN colors ON itemndcolors.color_id = colors.id
            LEFT JOIN itemnddepartments ON item.id = itemnddepartments.item_id 
            LEFT JOIN prodord_department ON itemnddepartments.department_id = prodord_department.id
            ", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            fm_products.ref_datagridView1.DataSource = dt;
        }

        #endregion

        #region events
        private void cmbPrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbPrType.SelectedIndex != -1)
                {
                    categoryid = -1;
                    cmbPrCategory.Items.Clear();
                    cmbPrCategory.Text = "Ürün Kategorisi";
                    conn.Open();
                    SqlCommand fillcmbcategory = new SqlCommand("SELECT Category_Name FROM item_categories WHERE Category_For = N'" + cmbPrType.SelectedItem.ToString() + "'", conn);
                    SqlDataReader read = fillcmbcategory.ExecuteReader();
                    while (read.Read())
                    {
                        cmbPrCategory.Items.Add(read["Category_Name"]);
                    }
                    conn.Close();

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

        private void cmbPrCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPrCategory.SelectedIndex != -1)
                {
                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id FROM item_categories WHERE Category_Name = N'" + cmbPrCategory.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    categoryid = Convert.ToInt32(idal.Rows[0][0]);
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

        private void cmbPrColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPrColor.SelectedIndex != -1)
                {
                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id FROM colors WHERE Color_Name = N'" + cmbPrColor.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    colorid = Convert.ToInt32(idal.Rows[0][0]);
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

        private void cmbPrDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPrDepartment.SelectedIndex != -1)
                {
                    DataTable idal = new DataTable();
                    string idalsql = "SELECT id FROM prodord_department WHERE department = N'" + cmbPrDepartment.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(idalsql, conn);
                    da.Fill(idal);
                    departmentid = Convert.ToInt32(idal.Rows[0][0]);
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

        #region parts

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbPrType.SelectedIndex != -1 && (cmbPrCategory.SelectedIndex != -1 && categoryid != -1) && (cmbPrColor.SelectedIndex != -1 && colorid != -1) && (cmbPrDepartment.SelectedIndex != -1 && departmentid != -1) && (txtPrCode.Text != "" && txtPrCode.Text != "Ürün Kodu") && (txtPrName.Text != "" && txtPrName.Text != "Ürün Adı") && (txtPrUnit.Text != "" && txtPrUnit.Text != "Ürün Birimi"))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT itemname, itemcode FROM item WHERE itemname = N'" + txtPrName.Text + "' OR itemcode = N'" + txtPrCode.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);

                    if(controlnamendcode.Rows.Count == 0)
                    {
                        string itemtypestring;
                        int idall;

                        if(cmbPrType.SelectedItem.ToString() == "ANA ÜRÜN")
                        {
                            itemtypestring = "AU";
                        }
                        else if(cmbPrType.SelectedItem.ToString() == "MAMÜL")
                        {
                            itemtypestring = "MM";
                        }
                        else if(cmbPrType.SelectedItem.ToString() == "YARI MAMÜL")
                        {
                            itemtypestring = "YM";
                        }
                        else
                        {
                            itemtypestring = "HM";
                        }

                        SqlCommand addprod = new SqlCommand("INSERT INTO item(itemtype, itemcode, itemname, unitcode, date_of_addition) VALUES(@itype, @icode, @iname, @ucode, @doa) SELECT SCOPE_IDENTITY()", conn);
                        addprod.Parameters.AddWithValue("@itype", SqlDbType.NVarChar).Value = itemtypestring;
                        addprod.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = txtPrCode.Text;
                        addprod.Parameters.AddWithValue("@iname", SqlDbType.NVarChar).Value = txtPrName.Text;
                        addprod.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = txtPrUnit.Text;
                        addprod.Parameters.AddWithValue("@doa", SqlDbType.Date).Value = DateTime.Now;

                        conn.Open();
                        idall = Convert.ToInt32(addprod.ExecuteScalar());
                        conn.Close();
                        

                        //ürün kategorisini ekle.
                        SqlCommand addprodcat = new SqlCommand("INSERT INTO itemndcategories(item_id, category_id) VALUES(@id, @categoryid)", conn);
                        addprodcat.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idall;
                        addprodcat.Parameters.AddWithValue("@categoryid", SqlDbType.Int).Value = categoryid;

                        conn.Open();
                        addprodcat.ExecuteNonQuery();
                        conn.Close();

                        //ürün rengini ekle.
                        SqlCommand addprodcol = new SqlCommand("INSERT INTO itemndcolors(item_id, color_id) VALUES(@id, @colorid)", conn);
                        addprodcol.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idall;
                        addprodcol.Parameters.AddWithValue("@colorid", SqlDbType.Int).Value = colorid;

                        conn.Open();
                        addprodcol.ExecuteNonQuery();
                        conn.Close();

                        //ürünün departmanını kaydet.
                        SqlCommand signdepartment = new SqlCommand("INSERT INTO itemnddepartments(item_id, department_id) VALUES(@id, @departmentid)", conn);
                        signdepartment.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idall;
                        signdepartment.Parameters.AddWithValue("@departmentid", SqlDbType.Int).Value = departmentid;

                        conn.Open();
                        signdepartment.ExecuteNonQuery();
                        conn.Close();

                        //ürünü stoğa kaydet.
                        SqlCommand addprodstock = new SqlCommand("INSERT INTO stock(itemid, amount, unitcode) VALUES(@id, @amo, @ucode)", conn);
                        addprodstock.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idall;
                        addprodstock.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = 0;
                        addprodstock.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = txtPrUnit.Text;

                        conn.Open();
                        addprodstock.ExecuteNonQuery();
                        conn.Close();

                        //ürünün reçetesini ekle.
                        if (itemtypestring == "AU" || itemtypestring == "MM" || itemtypestring == "YM")
                        {
                            SqlCommand addprodrecipe = new SqlCommand("INSERT INTO bom(bomcode, bomname, itemid) VALUES(@bcode, @bname, @icode)", conn);
                            addprodrecipe.Parameters.AddWithValue("@bcode", SqlDbType.NVarChar).Value = txtPrCode.Text;
                            addprodrecipe.Parameters.AddWithValue("@bname", SqlDbType.NVarChar).Value = txtPrName.Text + " REÇETE";
                            addprodrecipe.Parameters.AddWithValue("@icode", SqlDbType.Int).Value = idall;

                            conn.Open();
                            addprodrecipe.ExecuteNonQuery();
                            conn.Close();
                        }

                        fillproduct();
                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip öğe halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün bilgileri girdiğinizden emin olunuz.");
                }
            }
            catch(Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(fm_products.id != -1)
                {
                    //ürünün calc verisini sil
                    SqlCommand deletecalc = new SqlCommand("DELETE FROM CALCULDEBUG WHERE mainitemid = @id OR childitemid = @id", conn);
                    deletecalc.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deletecalc.ExecuteNonQuery();
                    conn.Close();

                    //ürünün kategori bilgisini sil.
                    SqlCommand deleteprodcat = new SqlCommand("DELETE FROM itemndcategories WHERE item_id = @id", conn);
                    deleteprodcat.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deleteprodcat.ExecuteNonQuery();
                    conn.Close();

                    //ürünün renk bilgisini sil.
                    SqlCommand deleteprodcol = new SqlCommand("DELETE FROM itemndcolors WHERE item_id = @id", conn);
                    deleteprodcol.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deleteprodcol.ExecuteNonQuery();
                    conn.Close();

                    //ürünün departman kaydını sil.
                    SqlCommand deletedepartmentsign = new SqlCommand("DELETE FROM itemnddepartments WHERE item_id = @id", conn);
                    deletedepartmentsign.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deletedepartmentsign.ExecuteNonQuery();
                    conn.Close();

                    //ürünün maliyet kayıtlarını sil.
                    SqlCommand deleteitemscosts = new SqlCommand("DELETE FROM itemndcosts WHERE item_id = @id", conn);
                    deleteitemscosts.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deleteitemscosts.ExecuteNonQuery();
                    conn.Close();

                    //ürünün reçete içeriğini(reçete detay) sil.
                    SqlCommand deleteprodrecipedetail = new SqlCommand("DELETE FROM bom_detail WHERE mainitemid = @id OR childitemid = @id", conn);
                    deleteprodrecipedetail.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deleteprodrecipedetail.ExecuteNonQuery();
                    conn.Close();

                    //ürünün reçetesini sil.
                    SqlCommand deleteprodrecipe = new SqlCommand("DELETE FROM bom WHERE itemid = @id", conn);
                    deleteprodrecipe.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;
                    
                    conn.Open();
                    deleteprodrecipe.ExecuteNonQuery();
                    conn.Close();

                    //ürünün stoğunu sil.
                    SqlCommand deleteprodstock = new SqlCommand("DELETE FROM stock WHERE itemid = @id", conn);
                    deleteprodstock.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;
                    conn.Open();
                    deleteprodstock.ExecuteNonQuery();
                    conn.Close();

                    //son olarak ürünü sil.
                    SqlCommand deleteprod = new SqlCommand("DELETE FROM item WHERE id = @id",conn);
                    deleteprod.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                    conn.Open();
                    deleteprod.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();
                    fm_products.id = -1;
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
                }
            }
            catch(Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(fm_products.id != -1 && cmbPrType.SelectedIndex != -1 && (cmbPrCategory.SelectedIndex != -1 && categoryid != -1) && (cmbPrColor.SelectedIndex != -1 && colorid != -1) && (cmbPrDepartment.SelectedIndex != -1 && departmentid != -1) && (txtPrCode.Text != "" && txtPrCode.Text != "Ürün Kodu") && (txtPrName.Text != "" && txtPrName.Text != "Ürün Adı") && (txtPrUnit.Text != "" && txtPrUnit.Text != "Ürün Birimi"))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT itemname, itemcode FROM item WHERE itemname = N'" + txtPrName.Text + "' OR itemcode = N'" + txtPrCode.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);

                    if (controlnamendcode.Rows.Count == 0)
                    {
                        //ürünün kategori bilgisi güncellenir.
                        SqlCommand updateprodcat = new SqlCommand("UPDATE itemndcategories SET category_id = @categoryid WHERE item_id = @id", conn);
                        updateprodcat.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;
                        updateprodcat.Parameters.AddWithValue("@categoryid", SqlDbType.Int).Value = categoryid;

                        conn.Open();
                        updateprodcat.ExecuteNonQuery();
                        conn.Close();

                        //ürünün renk bilgisi güncellenir.
                        SqlCommand updateprodcol = new SqlCommand("UPDATE itemndcolors SET color_id = @colorid WHERE item_id = @id", conn);
                        updateprodcol.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;
                        updateprodcol.Parameters.AddWithValue("@colorid", SqlDbType.Int).Value = colorid;

                        conn.Open();
                        updateprodcol.ExecuteNonQuery();
                        conn.Close();

                        //ürünün departman kaydını güncelle.
                        SqlCommand updatedepartmentsign = new SqlCommand("UPDATE itemnddepartments SET department_id = @departmentid WHERE item_id = @id", conn);
                        updatedepartmentsign.Parameters.AddWithValue("@departmentid", SqlDbType.Int).Value = departmentid;
                        updatedepartmentsign.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                        conn.Open();
                        updatedepartmentsign.ExecuteNonQuery();
                        conn.Close();

                        //ürünün reçete detayları güncellenir.
                        SqlCommand updateprodrecipedetail = new SqlCommand("UPDATE bom_detail SET mainunitcode = @icode WHERE mainitemid = @id", conn);
                        updateprodrecipedetail.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = txtPrUnit.Text;
                        updateprodrecipedetail.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = fm_products.id;

                        conn.Open();
                        updateprodrecipedetail.ExecuteNonQuery();
                        conn.Close();

                        SqlCommand updateprodrecipedetail1 = new SqlCommand("UPDATE bom_detail SET childunitcode = @icode WHERE childitemid = @id", conn);
                        updateprodrecipedetail1.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = txtPrUnit.Text;
                        updateprodrecipedetail1.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = fm_products.id;

                        conn.Open();
                        updateprodrecipedetail1.ExecuteNonQuery();
                        conn.Close();

                        //ürünün reçetesi güncellenir.
                        SqlCommand updateprodrecipe = new SqlCommand("UPDATE bom SET bomcode = @bcode, bomname = @bname WHERE itemid = @id", conn);
                        updateprodrecipe.Parameters.AddWithValue("@bcode", SqlDbType.NVarChar).Value = txtPrCode.Text;
                        updateprodrecipe.Parameters.AddWithValue("@bname", SqlDbType.NVarChar).Value = txtPrName.Text + " REÇETE";
                        updateprodrecipe.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = fm_products.id;

                        conn.Open();
                        updateprodrecipe.ExecuteNonQuery();
                        conn.Close();

                        //ürünün stoğu güncellenir.
                        SqlCommand updateprodstock = new SqlCommand("UPDATE stock SET unitcode = @ucode WHERE itemid = @id", conn);
                        updateprodstock.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;
                        updateprodstock.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = txtPrUnit.Text;

                        conn.Open();
                        updateprodstock.ExecuteNonQuery();
                        conn.Close();


                        //ürünü güncelle.
                        string itemtypestring;

                        if (cmbPrType.SelectedItem.ToString() == "ANA ÜRÜN")
                        {
                            itemtypestring = "AU";
                        }
                        else if (cmbPrType.SelectedItem.ToString() == "MAMÜL")
                        {
                            itemtypestring = "MM";
                        }
                        else if (cmbPrType.SelectedItem.ToString() == "YARI MAMÜL")
                        {
                            itemtypestring = "YM";
                        }
                        else
                        {
                            itemtypestring = "HM";
                        }

                        SqlCommand updateprod = new SqlCommand("UPDATE item SET itemtype = @itype, itemcode = @icode, itemname = @iname, unitcode = @ucode WHERE id = @id", conn);
                        updateprod.Parameters.AddWithValue("@itype", SqlDbType.NVarChar).Value = itemtypestring;
                        updateprod.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = txtPrCode.Text;
                        updateprod.Parameters.AddWithValue("@iname", SqlDbType.NVarChar).Value = txtPrName.Text;
                        updateprod.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = txtPrUnit.Text;
                        updateprod.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_products.id;

                        conn.Open();
                        updateprod.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();
                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip öğe halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
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
