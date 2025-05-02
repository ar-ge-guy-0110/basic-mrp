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
    public partial class fm_product_categories_colors : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static int id { get; set; }
        public static DataGridView ref_dataGridView1 { get; set; }
        #endregion

        #region critics
        public fm_product_categories_colors()
        {
            InitializeComponent();
        }

        private void fm_product_categories_colors_Load(object sender, EventArgs e)
        {
            id = -1;
            ref_dataGridView1 = dataGridView1;
            fillproduct();
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["fm_product_categories_colors_trac"] != null)
            {
                Application.OpenForms["fm_product_categories_colors_trac"].Close();
            }
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
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', Color_Code AS 'Renk Kodu', Color_Name AS 'Renk Adı' FROM colors", conn);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(ds, "colors");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "colors";
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
        #endregion

        #region events
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (Application.OpenForms["fm_product_categories_colors_trac"] != null)
                    {
                        fm_product_categories_colors_trac.ref_txtColCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        fm_product_categories_colors_trac.ref_txtColName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        Application.OpenForms["fm_product_categories_colors_trac"].BringToFront();
                    }
                    txtColCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtColName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }
        #endregion

        #region parts
        private void btnColorAdd_Click(object sender, EventArgs e)
        {
            OpenFuncForm(new fm_product_categories_colors_trac(), "fm_product_categories_colors_trac");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "";

            string cmd_start = "SELECT";
            string cmd_middle = @" id AS 'ID', Color_Code AS 'Renk Kodu', Color_Name AS 'Renk Adı' ";
            string cmd_end = @"FROM colors WHERE";

            int cmdend_length = cmd_end.Length;

            if(txtColCode.Text != "")
            {
                if(txtColCode.Text == "Renk Kodu")
                {
                    txtColCode.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " Color_Code LIKE N'%" + txtColCode.Text + "%'";
            }

            if (txtColName.Text != "")
            {
                if (txtColName.Text == "Renk Adı")
                {
                    txtColName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " Color_Name LIKE N'%" + txtColName.Text + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if(txtColCode.Text != "" || txtColName.Text != "")
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
            txtColCode.Text = "Renk Kodu";
            txtColName.Text = "Renk Adı";
        }

        #endregion




    }
}
