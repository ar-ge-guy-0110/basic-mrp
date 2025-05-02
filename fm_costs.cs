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
    public partial class fm_costs : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        int id;
        #endregion

        #region critics
        public fm_costs()
        {
            InitializeComponent();
        }

        private void fm_costs_Load(object sender, EventArgs e)
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

        private void txtCsName_Enter(object sender, EventArgs e)
        {
            if(txtCsName.Text == "Maliyet")
            {
                txtCsName.Text = "";
                txtCsName.ForeColor = Color.White;
            }
        }

        private void txtCsName_Leave(object sender, EventArgs e)
        {
            if(txtCsName.Text == "")
            {
                txtCsName.Text = "Maliyet";
                txtCsName.ForeColor = Color.LightGray;
            }
        }

        private void txtCsUnit_Enter(object sender, EventArgs e)
        {
            if(txtCsUnit.Text == "Maliyet Birimi")
            {
               txtCsUnit.Text = "";
               txtCsUnit.ForeColor = Color.White;
            }
        }

        private void txtCsUnit_Leave(object sender, EventArgs e)
        {
            if(txtCsUnit.Text == "")
            {
               txtCsUnit.Text = "Maliyet Birimi";
               txtCsUnit.ForeColor = Color.LightGray;
            }
        }

        private void txtCsAmount_Enter(object sender, EventArgs e)
        {
            if (txtCsAmount.Text == "Maliyet Miktarı")
            {
                txtCsAmount.Text = "";
                txtCsAmount.ForeColor = Color.White;
            }
        }

        private void txtCsAmount_Leave(object sender, EventArgs e)
        {
            if (txtCsAmount.Text == "")
            {
                txtCsAmount.Text = "Maliyet Miktarı";
                txtCsAmount.ForeColor = Color.LightGray;
            }
        }

        private void txtCsAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //float

            // allows 0-9, dot, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 44)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand("SELECT costs.id AS 'ID', costs.resource_spent AS 'Maliyet', costs.unitcode AS 'Birimi', costs.amount AS 'Varsayılan Miktarı' FROM costs", conn);
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
                    txtCsName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtCsUnit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtCsAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
                if ((txtCsName.Text != "" && txtCsName.Text != "Maliyet") && (txtCsUnit.Text != "" && txtCsUnit.Text != "Maliyet Birimi") && (txtCsAmount.Text != "" && txtCsAmount.Text != "Maliyet Miktarı"))
                {
                    DataTable controlname = new DataTable();
                    string sql = "SELECT resource_spent FROM costs WHERE resource_spent = N'" + txtCsName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlname);

                    if (controlname.Rows.Count == 0)
                    {
                        SqlCommand createcost = new SqlCommand("INSERT INTO costs(resource_spent, unitcode, amount) VALUES(@spent, @ucode, @amo)", conn);
                        createcost.Parameters.AddWithValue("@spent", SqlDbType.NVarChar).Value = txtCsName.Text;
                        createcost.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = txtCsUnit.Text;
                        createcost.Parameters.AddWithValue("@amo", SqlDbType.NVarChar).Value = (float)Convert.ToDouble(txtCsAmount.Text);

                        conn.Open();
                        createcost.ExecuteNonQuery();
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
                if (id != -1)
                {
                    //varsa ürün maliyet bağını sil.
                    SqlCommand deleteitemcost = new SqlCommand("DELETE FROM itemndcosts WHERE cost_id = @id", conn);
                    deleteitemcost.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    conn.Open();
                    deleteitemcost.ExecuteNonQuery();
                    conn.Close();

                    //maliyeti sil.
                    SqlCommand deletecost = new SqlCommand("DELETE FROM costs WHERE id = @id", conn);
                    deletecost.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    conn.Open();
                    deletecost.ExecuteNonQuery();
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
                if (id != -1 && (txtCsName.Text != "" && txtCsName.Text != "Maliyet") && (txtCsUnit.Text != "" && txtCsUnit.Text != "Maliyet Birimi") && (txtCsAmount.Text != "" && txtCsAmount.Text != "Maliyet Miktarı"))
                {
                    DataTable controlname = new DataTable();
                    string sql = "SELECT resource_spent FROM costs WHERE resource_spent = N'" + txtCsName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlname);

                    if (controlname.Rows.Count == 0)
                    {
                        SqlCommand updatecost = new SqlCommand("UPDATE costs SET  resource_spent = @spent, unitcode = @ucode, amount = @amo WHERE id = @id", conn);
                        updatecost.Parameters.AddWithValue("@spent", SqlDbType.NVarChar).Value = txtCsName.Text;
                        updatecost.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = txtCsUnit.Text;
                        updatecost.Parameters.AddWithValue("@amo", SqlDbType.NVarChar).Value = (float)Convert.ToDouble(txtCsAmount.Text);
                        updatecost.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                        conn.Open();
                        updatecost.ExecuteNonQuery();
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
            string cmd_middle = @" costs.id AS 'ID', costs.resource_spent AS 'Maliyet', costs.unitcode AS 'Birimi', costs.amount AS ' Varsayılan Miktarı' ";
            string cmd_end = @"FROM  costs WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtCsName.Text != "")
            {
                if (txtCsName.Text == "Maliyet")
                {
                    txtCsName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " resource_spent LIKE N'%" + txtCsName.Text + "%'";
            }

            if (txtCsUnit.Text != "")
            {
                if (txtCsUnit.Text == "Maliyet Birimi")
                {
                    txtCsUnit.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " unitcode LIKE N'%" + txtCsUnit.Text + "%'";
            }

            float amount;

            if (txtCsAmount.Text != "" && txtCsAmount.Text != "Maliyet Miktarı")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }

                amount = (float)Convert.ToDouble(txtCsAmount.Text);
                cmd_end += " amount  <= " + amount;
            }

            search = cmd_start + cmd_middle + cmd_end;

            if ((txtCsName.Text != "" && txtCsName.Text != "Maliyet") || (txtCsUnit.Text != "" && txtCsUnit.Text != "Maliyet Birimi") || (txtCsAmount.Text != "" && txtCsAmount.Text != "Maliyet Miktarı"))
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
            txtCsName.Text = "Maliyet";
            txtCsUnit.Text = "Maliyet Birimi";
            txtCsAmount.Text = "Maliyet Miktarı";
        }
        #endregion


    }
}
