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
    public partial class fm_departments : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        int id;
        #endregion

        #region critics
        public fm_departments()
        {
            InitializeComponent();
        }

        private void fm_departments_Load(object sender, EventArgs e)
        {
            id = -1;
            fillproduct();
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDpName_Enter(object sender, EventArgs e)
        {
            if (txtDpName.Text == "Departman Adı")
            {
                txtDpName.Text = "";
                txtDpName.ForeColor = Color.White;
            }
        }

        private void txtDpName_Leave(object sender, EventArgs e)
        {
            if (txtDpName.Text == "")
            {
                txtDpName.Text = "Departman Adı";
                txtDpName.ForeColor = Color.LightGray;
            }
        }

        private void txtDpCode_Enter(object sender, EventArgs e)
        {
            if (txtDpCode.Text == "Departman Kodu")
            {
                txtDpCode.Text = "";
                txtDpCode.ForeColor = Color.White;
            }
        }

        private void txtDpCode_Leave(object sender, EventArgs e)
        {
            if (txtDpCode.Text == "")
            {
                txtDpCode.Text = "Departman Kodu";
                txtDpCode.ForeColor = Color.LightGray;
            }
        }
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand("SELECT prodord_department.id AS 'ID', prodord_department.department AS 'Departman Adı', prodord_department.departmentcode AS 'Departman Kodu' FROM  prodord_department", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
                    //if (Application.OpenForms["fm_product_categories_trac"] != null)
                    //{
                    //    fm_product_categories_trac.ref_comboBoxCatType.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //    fm_product_categories_trac.ref_textBoxCatCode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    //    fm_product_categories_trac.ref_textBoxCatName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    //    Application.OpenForms["fm_product_categories_trac"].BringToFront();
                    //}
                    txtDpName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtDpCode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }
        #endregion

        #region parts
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if((txtDpName.Text != "" && txtDpName.Text != "Departman Adı") && (txtDpCode.Text != "" && txtDpCode.Text != "Departman Kodu"))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT department, departmentcode FROM prodord_department WHERE department = N'" + txtDpName.Text + "' OR departmentcode = N'" + txtDpCode.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);

                    if (controlnamendcode.Rows.Count == 0)
                    {
                        SqlCommand createdepartment = new SqlCommand("INSERT INTO prodord_department(department, departmentcode) VALUES(@dname, @dcode)", conn);
                        createdepartment.Parameters.AddWithValue("@dname", SqlDbType.NVarChar).Value = txtDpName.Text;
                        createdepartment.Parameters.AddWithValue("@dcode", SqlDbType.NVarChar).Value = txtDpCode.Text;

                        conn.Open();
                        createdepartment.ExecuteNonQuery();
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
                if(id != -1)
                {
                    //ürün departman bağını sil.
                    SqlCommand deleteitemconn = new SqlCommand("DELETE FROM itemnddepartments WHERE department_id = @id", conn);
                    deleteitemconn.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    conn.Open();
                    deleteitemconn.ExecuteNonQuery();
                    conn.Close();

                    //departmanı sil.
                    SqlCommand deletedepartment = new SqlCommand("DELETE FROM prodord_department WHERE id = @id", conn);
                    deletedepartment.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    conn.Open();
                    deletedepartment.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();
                    id = -1;
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
            try
            {
                if (id != -1 && (txtDpName.Text != "" && txtDpName.Text != "Departman Adı") && (txtDpCode.Text != "" && txtDpCode.Text != "Departman Kodu"))
                {
                    DataTable controlnamendcode = new DataTable();
                    string sql = "SELECT department, departmentcode FROM prodord_department WHERE department = N'" + txtDpName.Text + "' OR departmentcode = N'" + txtDpCode.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnamendcode);

                    if (controlnamendcode.Rows.Count == 0)
                    {
                        SqlCommand updatedepartment = new SqlCommand("UPDATE prodord_department SET  department = @dname, departmentcode = @dcode WHERE id = @id", conn);
                        updatedepartment.Parameters.AddWithValue("@dname", SqlDbType.NVarChar).Value = txtDpName.Text;
                        updatedepartment.Parameters.AddWithValue("@dcode", SqlDbType.NVarChar).Value = txtDpCode.Text;
                        updatedepartment.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                        conn.Open();
                        updatedepartment.ExecuteNonQuery();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "";

            string cmd_start = "SELECT";
            string cmd_middle = @" prodord_department.id AS 'ID', prodord_department.department AS 'Departman Adı', prodord_department.departmentcode AS 'Departman Kodu' ";
            string cmd_end = @"FROM  prodord_department WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtDpName.Text != "")
            {
                if (txtDpName.Text == "Departman Adı")
                {
                    txtDpName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " department LIKE N'%" + txtDpName.Text + "%'";
            }

            if (txtDpCode.Text != "")
            {
                if (txtDpCode.Text == "Departman Kodu")
                {
                    txtDpCode.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " departmentcode LIKE N'%" + txtDpCode.Text + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if (txtDpName.Text != "" || txtDpCode.Text != "")
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
            txtDpName.Text = "Departman Adı";
            txtDpCode.Text = "Departman Kodu";
        }
        #endregion


    }
}
