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
    public partial class fm_products_recipe : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        int itemid;
        int reciperegistryid;
        int mainitemreciperegistryid;
        string mainitemunitcode;
        #endregion

        #region critics
        public fm_products_recipe()
        {
            InitializeComponent();
        }

        private void fm_products_recipe_Load(object sender, EventArgs e)
        {
            itemid = -1;
            reciperegistryid = -1;
            fillproduct1();
            fillproduct2();

            SqlCommand getname = new SqlCommand("SELECT item.itemname, item.unitcode FROM item WHERE item.id = " + fm_products.id, conn);
            DataTable getitemname = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(getname);
            da.Fill(getitemname);
            lbSelectedPr.Text = "Seçilen Ürün: " + getitemname.Rows[0][0].ToString();
            mainitemunitcode = getitemname.Rows[0][1].ToString();

            SqlCommand getbomid = new SqlCommand("SELECT id FROM bom WHERE itemid = " + fm_products.id, conn);
            DataTable bomtable = new DataTable();
            SqlDataAdapter bomtableda = new SqlDataAdapter(getbomid);
            bomtableda.Fill(bomtable);
            mainitemreciperegistryid = Convert.ToInt32(bomtable.Rows[0][0]);


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

            if (fm_products.product_type == "ANA ÜRÜN")
            {
                cmbPrType.Items.Clear();
                cmbPrType.Items.Add("MAMÜL");
                cmbPrType.Items.Add("YARI MAMÜL");
                cmbPrType.Items.Add("HAM MADDE");
            }
            else if (fm_products.product_type == "MAMÜL")
            {
                cmbPrType.Items.Clear();
                cmbPrType.Items.Add("YARI MAMÜL");
                cmbPrType.Items.Add("HAM MADDE");
            }
            else
            {
                cmbPrType.Items.Clear();
                cmbPrType.Items.Add("HAM MADDE");
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

        private void txtRpAmount_Enter(object sender, EventArgs e)
        {
            if (txtRpAmount.Text == "Gereken Miktar")
            {
                txtRpAmount.Text = "";
                txtRpAmount.ForeColor = Color.White;
            }
        }

        private void txtRpAmount_Leave(object sender, EventArgs e)
        {
            if (txtRpAmount.Text == "")
            {
                txtRpAmount.Text = "Gereken Miktar";
                txtRpAmount.ForeColor = Color.LightGray;
            }
        }

        private void txtRpAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        #endregion

        #region funcs
        private void fillproduct1()
        {
            string sqladd;
            if (fm_products.product_type == "ANA ÜRÜN")
            {
                sqladd = "WHERE item.itemtype = N'MM' OR item.itemtype = N'YM' OR item.itemtype = N'HM'";
            }
            else if (fm_products.product_type == "MAMÜL")
            {
                sqladd = "WHERE item.itemtype = N'YM' OR item.itemtype = N'HM'";
            }
            else
            {
                sqladd = "WHERE item.itemtype = N'HM'";
            }

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
            " + sqladd, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void fillproduct2()
        {
            SqlCommand fill = new SqlCommand(@"SELECT 
                                                    bom_detail.id AS 'Kayıt ID',
                                                    bom_detail.bomid AS 'Reçete ID',
                                                    item.itemname AS 'Ana Ürün Adı',
                                                    bom_detail.mainamount AS 'Ana Miktar',
                                                    item.unitcode AS 'Ana Ürün Birimi',
                                                    item2.itemname AS 'Gereken Alt Ürün Adı',
                                                    bom_detail.childamount AS 'Gereken Alt Ürün Miktarı',
                                                    item2.unitcode AS 'Gereken Alt Ürün Birimi'
                                                 FROM bom_detail
                                                    JOIN item ON bom_detail.mainitemid = item.id
                                                    JOIN item AS item2 ON bom_detail.childitemid = item2.id
                                                 WHERE bom_detail.mainitemid = " + fm_products.id, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }




        #endregion

        #region events

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    itemid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    string itemtypestring;

                    if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "AU")
                    {
                        itemtypestring = "ANA ÜRÜN";
                    }
                    else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "MM")
                    {
                        itemtypestring = "MAMÜL";
                    }
                    else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "YM")
                    {
                        itemtypestring = "YARI MAMÜL";
                    }
                    else
                    {
                        itemtypestring = "HAM MADDE";
                    }

                    //if (Application.OpenForms["fm_mainprodact"] != null)
                    //{
                    //    fm_mainprodact.ref_cmbPrType.SelectedItem = itemtypestring;
                    //    fm_mainprodact.ref_cmbPrCategory.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    //    fm_mainprodact.ref_txtPrCode.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    //    fm_mainprodact.ref_txtPrName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    //    fm_mainprodact.ref_txtPrUnit.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    //    fm_mainprodact.ref_cmbPrColor.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    //    fm_mainprodact.ref_cmbPrDepartment.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    //    Application.OpenForms["fm_mainprodact"].BringToFront();
                    //}
                    cmbPrType.SelectedItem = itemtypestring;
                    cmbPrCategory.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtPrCode.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtPrName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtPrUnit.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    cmbPrColor.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    cmbPrDepartment.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    reciperegistryid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }

        private void cmbPrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbPrCategory.Items.Clear();
                cmbPrCategory.Text = "Ürün Kategorisi";
                if (cmbPrType.SelectedIndex != -1)
                {
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
        #endregion

        #region parts
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqladd;
            if (fm_products.product_type == "ANA ÜRÜN")
            {
                sqladd = " (item.itemtype = N'MM' OR item.itemtype = N'YM' OR item.itemtype = N'HM')";
            }
            else if (fm_products.product_type == "MAMÜL")
            {
                sqladd = " (item.itemtype = N'YM' OR item.itemtype = N'HM')";
            }
            else
            {
                sqladd = " (item.itemtype = N'HM')";
            }

            string itemtypestring;
            string search = "";

            string cmd_start = "SELECT";
            string cmd_middle = @" item.id AS 'ID', item.itemtype AS 'Ürün Tipi', item_categories.Category_Name AS 'Ürün Kategorisi', 
            item.itemcode AS 'Ürün Kodu', item.itemname AS 'Ürün Adı', item.unitcode AS 'Ürün Birimi', 
            colors.Color_Name AS 'Ürün Ana Rengi', item.date_of_addition AS 'Eklenme Tarihi', prodord_department.department AS 'Departmanı' ";
            string cmd_end = @"FROM item 
            LEFT JOIN itemndcategories ON item.id = itemndcategories.item_id 
            LEFT JOIN item_categories ON itemndcategories.category_id = item_categories.id 
            LEFT JOIN itemndcolors ON item.id = itemndcolors.item_id 
            LEFT JOIN colors ON itemndcolors.color_id = colors.id 
            LEFT JOIN itemnddepartments ON item.id = itemnddepartments.item_id 
            LEFT JOIN prodord_department ON itemnddepartments.department_id = prodord_department.id WHERE" +sqladd;

            string cmd_end2 = @"FROM item 
            LEFT JOIN itemndcategories ON item.id = itemndcategories.item_id 
            LEFT JOIN item_categories ON itemndcategories.category_id = item_categories.id 
            LEFT JOIN itemndcolors ON item.id = itemndcolors.item_id 
            LEFT JOIN colors ON itemndcolors.color_id = colors.id 
            LEFT JOIN itemnddepartments ON item.id = itemnddepartments.item_id 
            LEFT JOIN prodord_department ON itemnddepartments.department_id = prodord_department.id WHERE";

            int cmdend_length = cmd_end.Length;

            cmdend_length -= 1;

            if (cmbPrType.SelectedIndex != -1)
            {
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
                cmd_end = cmd_end2;
                cmdend_length = cmd_end.Length;
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " item.itemtype LIKE N'%" + itemtypestring + "%'";
                
            }

            if (cmbPrCategory.SelectedIndex != -1)
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " item_categories.Category_Name LIKE N'%" + cmbPrCategory.SelectedItem.ToString() + "%'";
            }

            if (cmbPrColor.SelectedIndex != -1)
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " colors.Color_Name LIKE N'%" + cmbPrColor.SelectedItem.ToString() + "%'";
            }

            if (cmbPrDepartment.SelectedIndex != -1)
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " prodord_department.department LIKE N'%" + cmbPrDepartment.SelectedItem.ToString() + "%'";
            }

            if (txtPrCode.Text != "")
            {
                if (txtPrCode.Text == "Ürün Kodu")
                {
                    txtPrCode.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " item.itemcode LIKE N'%" + txtPrCode.Text + "%'";
            }

            if (txtPrName.Text != "")
            {
                if (txtPrName.Text == "Ürün Adı")
                {
                    txtPrName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " item.itemname LIKE N'%" + txtPrName.Text + "%'";
            }

            if (txtPrUnit.Text != "")
            {
                if (txtPrUnit.Text == "Ürün Birimi")
                {
                    txtPrUnit.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " item.unitcode LIKE N'%" + txtPrUnit.Text + "%'";
            }



            search = cmd_start + cmd_middle + cmd_end;

            if (cmbPrType.SelectedIndex != -1 || cmbPrCategory.SelectedIndex != -1 || cmbPrColor.SelectedIndex != -1 || cmbPrDepartment.SelectedIndex != -1 || txtPrCode.Text != "" || txtPrName.Text != "" || txtPrUnit.Text != "")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
            else
            {
                fillproduct1();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            fillproduct1();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            itemid = -1;
            reciperegistryid = -1;
            cmbPrType.SelectedIndex = -1;
            cmbPrType.Text = "Ürün Ana Tipi";
            cmbPrCategory.SelectedIndex = -1;
            cmbPrCategory.Text = "Ürün Kategorisi";
            cmbPrColor.SelectedIndex = -1;
            cmbPrColor.Text = "Ürün Rengi";
            cmbPrDepartment.SelectedIndex = -1;
            cmbPrDepartment.Text = "Departmanı";
            txtPrCode.Text = "Ürün Kodu";
            txtPrName.Text = "Ürün Adı";
            txtPrUnit.Text = "Ürün Birimi";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemid != -1 && (txtRpAmount.Text != "" && txtRpAmount.Text != "Gereken Miktar"))
                {
                    DataTable controlifalreadyhavethis = new DataTable();
                    string sql = "SELECT childitemid FROM bom_detail WHERE mainitemid = " + fm_products.id + " AND childitemid = " + itemid;
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlifalreadyhavethis);

                    if (controlifalreadyhavethis.Rows.Count == 0)
                    {
                        string childitemunitcode;

                        SqlCommand fetchchilditemdata = new SqlCommand("SELECT unitcode FROM item WHERE id = " + itemid, conn);
                        DataTable fetch = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(fetchchilditemdata);
                        da2.Fill(fetch);
                        childitemunitcode = fetch.Rows[0][0].ToString();


                        SqlCommand addtoitemsrecipe = new SqlCommand("INSERT INTO bom_detail(bomid, mainitemid, childitemid, mainamount, mainunitcode, childamount, childunitcode) VALUES(@bomid, @mainitemid, @childitemid, @mainamount, @mainunitcode, @childamount, @childunitcode)", conn);
                        addtoitemsrecipe.Parameters.AddWithValue("@bomid", SqlDbType.Int).Value = mainitemreciperegistryid;
                        addtoitemsrecipe.Parameters.AddWithValue("@mainitemid", SqlDbType.Int).Value = fm_products.id;
                        addtoitemsrecipe.Parameters.AddWithValue("@childitemid", SqlDbType.Int).Value = itemid;
                        addtoitemsrecipe.Parameters.AddWithValue("@mainamount", SqlDbType.Int).Value = 1;
                        addtoitemsrecipe.Parameters.AddWithValue("@mainunitcode", SqlDbType.NVarChar).Value = mainitemunitcode;
                        addtoitemsrecipe.Parameters.AddWithValue("@childamount", SqlDbType.Int).Value = Convert.ToInt32(txtRpAmount.Text);
                        addtoitemsrecipe.Parameters.AddWithValue("@childunitcode", SqlDbType.NVarChar).Value = childitemunitcode;
                        conn.Open();
                        addtoitemsrecipe.ExecuteNonQuery();
                        conn.Close();

                        fillproduct2();
                    }
                    else
                    {
                        MessageBox.Show("Aynı öğe halihazırda bulunmaktadır. Lütfen başka öğe eklemeyi deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen eklemek istediğiniz öğeyi çift tıklatarak öğeyi seçili hale getiriniz ve miktar bilgisini giriniz.");
                }
            }
            catch (Exception ex)
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
                if (reciperegistryid != -1)
                {
                    SqlCommand deletechildfromitemrecipelist = new SqlCommand("DELETE FROM bom_detail WHERE id = @id", conn);
                    deletechildfromitemrecipelist.Parameters.AddWithValue("@id", SqlDbType.Int).Value = reciperegistryid;

                    conn.Open();
                    deletechildfromitemrecipelist.ExecuteNonQuery();
                    conn.Close();

                    fillproduct2();
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

        #endregion


    }
}
