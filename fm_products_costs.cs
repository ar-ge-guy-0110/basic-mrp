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
    public partial class fm_products_costs : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        int costid;
        int itemcostid;
        #endregion

        #region critics
        public fm_products_costs()
        {
            InitializeComponent();
        }

        private void fm_products_costs_Load(object sender, EventArgs e)
        {
            costid = -1;
            itemcostid = -1;
            fillproduct1();
            //load the item to the form.
            SqlCommand getname = new SqlCommand("SELECT item.itemname FROM item WHERE item.id = " + fm_products.id, conn);
            DataTable getitemname = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(getname);
            da.Fill(getitemname);
            lbSelectedPr.Text = "Seçilen Ürün: " + getitemname.Rows[0][0].ToString();
            fillproduct2();
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCsName_Enter(object sender, EventArgs e)
        {
            if (txtCsName.Text == "Maliyet")
            {
                txtCsName.Text = "";
                txtCsName.ForeColor = Color.White;
            }
        }

        private void txtCsName_Leave(object sender, EventArgs e)
        {
            if (txtCsName.Text == "")
            {
                txtCsName.Text = "Maliyet";
                txtCsName.ForeColor = Color.LightGray;
            }
        }

        private void txtCsUnit_Enter(object sender, EventArgs e)
        {
            if (txtCsUnit.Text == "Maliyet Birimi")
            {
                txtCsUnit.Text = "";
                txtCsUnit.ForeColor = Color.White;
            }
        }

        private void txtCsUnit_Leave(object sender, EventArgs e)
        {
            if (txtCsUnit.Text == "")
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
        private void fillproduct1()
        {
            SqlCommand fill = new SqlCommand("SELECT costs.id AS 'ID', costs.resource_spent AS 'Maliyet', costs.unitcode AS 'Birimi', costs.amount AS 'Varsayılan Miktarı' FROM costs", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void fillproduct2()
        {
            SqlCommand fill = new SqlCommand(@"SELECT itemndcosts.id AS 'Kayıt ID', costs.resource_spent AS 
            'Maliyet', itemndcosts.amount AS 'Miktarı', costs.unitcode AS 
            'Birimi' FROM itemndcosts JOIN costs ON itemndcosts.cost_id = costs.id 
            WHERE itemndcosts.item_id = " + fm_products.id, conn);
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
                    costid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    itemcostid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }
        #endregion

        #region parts
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

            int amount;

            if (txtCsAmount.Text != "" && txtCsAmount.Text != "Maliyet Miktarı")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }

                amount = Convert.ToInt32(txtCsAmount.Text);
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
                fillproduct1();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            fillproduct1();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            costid = -1;
            itemcostid = -1;
            txtCsName.Text = "Maliyet";
            txtCsUnit.Text = "Maliyet Birimi";
            txtCsAmount.Text = "Maliyet Miktarı";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (costid != -1 && (txtCsAmount.Text != "" && txtCsAmount.Text != "Maliyet Miktarı"))
                {
                    DataTable controlifalreadyhavethis = new DataTable();
                    string sql = "SELECT cost_id FROM itemndcosts WHERE item_id = " + fm_products.id + " AND cost_id = " + costid;
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlifalreadyhavethis);

                    if (controlifalreadyhavethis.Rows.Count == 0)
                    {
                        SqlCommand addtoitemacost = new SqlCommand("INSERT INTO itemndcosts(item_id, cost_id, amount) VALUES(@item_id, @cost_id, @amount)", conn);
                        addtoitemacost.Parameters.AddWithValue("@item_id", SqlDbType.Int).Value = fm_products.id;
                        addtoitemacost.Parameters.AddWithValue("@cost_id", SqlDbType.Int).Value = costid;
                        addtoitemacost.Parameters.AddWithValue("@amount", SqlDbType.Float).Value = (float)Convert.ToDouble(txtCsAmount.Text);

                        conn.Open();
                        addtoitemacost.ExecuteNonQuery();
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
                if (itemcostid != -1)
                {
                    SqlCommand deletefromitemthiscost = new SqlCommand("DELETE FROM itemndcosts WHERE id = @id", conn);
                    deletefromitemthiscost.Parameters.AddWithValue("@id", SqlDbType.Int).Value = itemcostid;

                    conn.Open();
                    deletefromitemthiscost.ExecuteNonQuery();
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
