using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BasicMRP
{
    public partial class fm_products : Form
    {

        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static DataGridView ref_datagridView1 { get; set; }
        public static int id { get; set; }
        public static string product_type { get; set; }
        public static string product_type_abb { get; set; }

        #endregion

        #region critics
        public fm_products()
        {
            InitializeComponent();
        }

        private void fm_products_Load(object sender, EventArgs e)
        {
            fillproduct();
            ref_datagridView1 = dataGridView1;
            id = -1;

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
        #endregion

        #region funcs
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
            dataGridView1.DataSource = dt;
        }

        private void fillproductobjectsender(object sender, FormClosedEventArgs e)
        {
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', 
            itemcode AS 'Ürün Program Kodu', 
            itemname AS 'Ürün Adı', 
            itemtype AS 'Ürün Tipi', 
            unitcode AS 'Birimi', 
            date_of_addition AS 'Eklenme Tarihi' FROM item
            ", conn);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(ds, "item");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "item";
        }

        private void OpenFuncForm(object FormChild, string form_name)
        {
            if (Application.OpenForms[form_name] != null)
            {
                
            }
            else
            {
                Form fc = FormChild as Form;
                fc.BringToFront();
                //fc.FormClosed += new FormClosedEventHandler(fillproductobjectsender);
                fc.Show();

            }
        }

        private void OpenFormInMainPanel(object FormChild, string form_name)
        {
            foreach(Control item in fm_adminpanel.ref_ContainerPanel.Controls)
            {
                if(item.Name == form_name)
                {
                    fm_adminpanel.ref_ContainerPanel.Controls.Remove(item);
                    item.Dispose();
                }
            }

            
            Form fc = FormChild as Form;
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            fm_adminpanel.ref_ContainerPanel.Controls.Add(fc);
            fc.BringToFront();
            //fc.FormClosed += new FormClosedEventHandler(fillproductobjectsender);
            fc.Show();

            
        }



        #endregion

        #region events

        private void fm_products_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["fm_mainprodact"] != null)
            {
                Application.OpenForms["fm_mainprodact"].Close();
            }
        }

        private void fm_products_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (Application.OpenForms["fm_mainprodact"] != null)
            {
                Application.OpenForms["fm_mainprodact"].Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    string itemtypestring;

                    if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "AU")
                    {
                        itemtypestring = "ANA ÜRÜN";
                        product_type = itemtypestring;
                        product_type_abb = "AU";
                    }
                    else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "MM")
                    {
                        itemtypestring = "MAMÜL";
                        product_type = itemtypestring;
                        product_type_abb = "MM";
                    }
                    else if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "YM")
                    {
                        itemtypestring = "YARI MAMÜL";
                        product_type = itemtypestring;
                        product_type_abb = "YM";
                    }
                    else
                    {
                        itemtypestring = "HAM MADDE";
                        product_type = itemtypestring;
                        product_type_abb = "HM";
                    }

                    if (Application.OpenForms["fm_mainprodact"] != null)
                    {
                        fm_mainprodact.ref_cmbPrType.SelectedItem = itemtypestring;
                        fm_mainprodact.ref_cmbPrCategory.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        fm_mainprodact.ref_txtPrCode.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        fm_mainprodact.ref_txtPrName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        fm_mainprodact.ref_txtPrUnit.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        fm_mainprodact.ref_cmbPrColor.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        fm_mainprodact.ref_cmbPrDepartment.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                        Application.OpenForms["fm_mainprodact"].BringToFront();
                    }
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

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenFuncForm(new fm_mainprodact(), "fm_mainprodact");
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {

            if(id != -1 && product_type != "HAM MADDE")
            {
                OpenFormInMainPanel(new fm_products_recipe(), "fm_products_recipe");
            }
            else
            {
                MessageBox.Show("Lütfen işlemler için istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new fm_products_stock(), "fm_products_stock()");
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new fm_product_categories(), "fm_product_categories");
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                OpenFormInMainPanel(new fm_products_costs(), "fm_products_costs");
            }
            else
            {
                MessageBox.Show("Lütfen işlemler için istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
            LEFT JOIN prodord_department ON itemnddepartments.department_id = prodord_department.id WHERE";

            int cmdend_length = cmd_end.Length;

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
                fillproduct();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            fillproduct();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            id = -1;
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




        #endregion


    }
}
