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
    public partial class fm_product_categories : Form
    {


        #region values
        SqlConnection conn = cs_dbconnections.conn;

        public static DataGridView ref_dataGridView1 { get; set; }

        public static int id { get; set; }
        #endregion

        #region critics

        public fm_product_categories()
        {
            InitializeComponent();
        }

        private void fm_product_categories_Load(object sender, EventArgs e)
        {
            fillproduct();

            ref_dataGridView1 = dataGridView1;

            id = -1;
        }

        #endregion

        #region UI

        private void exitLabel_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["fm_product_categories_trac"] != null)
            {
                Application.OpenForms["fm_product_categories_trac"].Close();
            }
            this.Close();
        }

        private void comboBoxCatType_Enter(object sender, EventArgs e)
        {
            if (comboBoxCatType.Text == "Ürün Türü")
            {
                comboBoxCatType.Text = "";
                comboBoxCatType.ForeColor = Color.White;
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
        #endregion

        #region funcs
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
            foreach (Control item in fm_adminpanel.ref_ContainerPanel.Controls)
            {
                if (item.Name == form_name)
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

        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', Category_For AS 'Kategori Tipi', Category_Code AS 'Kategori Kodu', Category_Name AS 'Kategori Adı' FROM item_categories", conn);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(ds, "item_categories");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "item_categories";
        }
        #endregion

        #region events
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if(Application.OpenForms["fm_product_categories_trac"] != null)
                    {
                        fm_product_categories_trac.ref_comboBoxCatType.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        fm_product_categories_trac.ref_textBoxCatCode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        fm_product_categories_trac.ref_textBoxCatName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        Application.OpenForms["fm_product_categories_trac"].BringToFront();
                    }
                    comboBoxCatType.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBoxCatCode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBoxCatName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }
        #endregion

        #region parts

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            OpenFuncForm(new fm_product_categories_trac(), "fm_product_categories_trac");
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new fm_product_categories_colors(), "fm_product_categories_colors");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "";

            string cmd_start = "SELECT";
            string cmd_middle = @" id AS 'ID', Category_For AS 'Kategori Tipi', Category_Code AS 'Kategori Kodu', Category_Name AS 'Kategori Adı' ";
            string cmd_end = @"FROM item_categories WHERE";

            int cmdend_length = cmd_end.Length;

            if (comboBoxCatType.SelectedIndex != -1)
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " Category_For LIKE N'%" + comboBoxCatType.SelectedItem.ToString() + "%'";
            }

            if (textBoxCatCode.Text != "")
            {
                if (textBoxCatCode.Text == "Kategori Kodu")
                {
                    textBoxCatCode.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " Category_Code LIKE N'%" + textBoxCatCode.Text + "%'";
            }

            if (textBoxCatName.Text != "")
            {
                if (textBoxCatName.Text == "Kategori Adı")
                {
                    textBoxCatName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " Category_Name LIKE N'%" + textBoxCatName.Text + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if (comboBoxCatType.SelectedIndex != -1 || textBoxCatCode.Text != "" || textBoxCatName.Text != "")
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
            comboBoxCatType.SelectedIndex = -1;
            comboBoxCatType.Text = "Ürün Türü";
            textBoxCatCode.Text = "Kategori Kodu";
            textBoxCatName.Text = "Kategori Adı";
        }
        #endregion


    }
}
