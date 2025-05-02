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
    public partial class fm_suppliers_orders : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static int id { get; set; }
        #endregion

        #region critics
        public fm_suppliers_orders()
        {
            InitializeComponent();
        }

        private void fm_suppliers_orders_Load(object sender, EventArgs e)
        {
            id = -1;
            lbCtName.Text = "Seçilen Tedarikci: " + fm_suppliers.supplier_name;
            lbCtCode.Text = "Kodu: " + fm_suppliers.supplier_code;
            lbCtAddress.Text = "Adresi: " + fm_suppliers.supplier_address;
            lbCtTaxNo.Text = "Vergi No: " + fm_suppliers.supplier_taxno;
            lbCtPhoneNum.Text = "Telefon No: " + fm_suppliers.supplier_phonenum;
            fillproduct();
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSpPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSpCurrency_Enter(object sender, EventArgs e)
        {
            if (txtSpCurrency.Text == "Para Birimi")
            {
                txtSpCurrency.Text = "";
                txtSpCurrency.ForeColor = Color.White;
            }
        }

        private void txtSpCurrency_Leave(object sender, EventArgs e)
        {
            if (txtSpCurrency.Text == "")
            {
                txtSpCurrency.Text = "Para Birimi";
                txtSpCurrency.ForeColor = Color.LightGray;
            }
        }

        private void txtSpPrice_Enter(object sender, EventArgs e)
        {
            if (txtSpPrice.Text == "Toplam Fiyat")
            {
                txtSpPrice.Text = "";
                txtSpPrice.ForeColor = Color.White;
            }
        }

        private void txtSpPrice_Leave(object sender, EventArgs e)
        {
            if (txtSpPrice.Text == "")
            {
                txtSpPrice.Text = "Toplam Fiyat";
                txtSpPrice.ForeColor = Color.LightGray;
            }
        }
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand("SELECT id AS 'Sipariş ID', date_ AS 'Siparişin Verilme Tarihi', duedate AS 'Siparişin Bitiş Tarihi', totalprice AS 'Sipariş Fiyatı' ,currency AS 'Para Birimi' FROM purchase_order WHERE supplierid = " + fm_suppliers.id, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
        #endregion

        #region events
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    //if (Application.OpenForms["fm_customers_customertrac"] != null)
                    //{
                    //    fm_customers_customertrac.ref_txtCtCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //    fm_customers_customertrac.ref_txtCtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    //    fm_customers_customertrac.ref_txtCtComName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    //    fm_customers_customertrac.ref_txtCtAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    //    fm_customers_customertrac.ref_txtCtTaxNo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    //    fm_customers_customertrac.ref_txtCtPhoneNum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    //    Application.OpenForms["fm_customers_customertrac"].BringToFront();
                    //}
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    txtSpCurrency.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtSpPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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


            string cmd_start = "SELECT TOP 200";
            string cmd_middle = @" id AS 'Sipariş ID', date_ AS 'Siparişin Verilme Tarihi', duedate AS 'Siparişin Bitiş Tarihi', totalprice AS 'Sipariş Fiyatı' ,currency AS 'Para Birimi' ";
            string cmd_end = @"FROM purchase_order WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtSpCurrency.Text != "")
            {
                if (txtSpCurrency.Text == "Para Birimi")
                {
                    txtSpCurrency.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " currency LIKE N'%" + txtSpCurrency.Text + "%'";
            }

            float amount;
            if (txtSpPrice.Text != "" && txtSpPrice.Text != "Toplam Fiyat")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }

                amount = (float)Convert.ToDouble(txtSpPrice.Text);
                cmd_end += " totalprice  <= " + amount;
            }

            if (dateTimePicker1.Checked && dateTimePicker2.Checked && (dateTimePicker1.Value != dateTimePicker2.Value))
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " date_ >= @dt1 AND duedate <= @dt2";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if ((txtSpCurrency.Text != "" && txtSpCurrency.Text != "Para Birimi") || (txtSpPrice.Text != "" && txtSpPrice.Text != "Toplam Fiyat") || ((dateTimePicker1.Checked && dateTimePicker2.Checked && (dateTimePicker1.Value != dateTimePicker2.Value))))
            {
                SqlCommand seearch = new SqlCommand(search, conn);
                seearch.Parameters.AddWithValue("@dt1", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                seearch.Parameters.AddWithValue("@dt2", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(seearch);
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            txtSpCurrency.Text = "Para Birimi";
            txtSpPrice.Text = "Toplam Fiyat";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dateTimePicker1.Value <= dateTimePicker2.Value) && (txtSpCurrency.Text != "" && txtSpCurrency.Text != "Para Birimi") && (txtSpCurrency.Text != "" && txtSpCurrency.Text != "Toplam Fiyat"))
                {

                    SqlCommand addorder = new SqlCommand("INSERT INTO purchase_order(supplierid, date_, duedate, currency, totalprice)" +
                        "VALUES(@cid, @dt, @dtt, @cr, @tp)", conn);
                    addorder.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = fm_suppliers.id;
                    addorder.Parameters.AddWithValue("@dt", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    addorder.Parameters.AddWithValue("@dtt", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                    addorder.Parameters.AddWithValue("@cr", SqlDbType.NVarChar).Value = txtSpCurrency.Text;
                    addorder.Parameters.AddWithValue("@tp", SqlDbType.Float).Value = (float)Convert.ToDouble(txtSpPrice.Text);

                    conn.Open();
                    addorder.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();

                }
                else
                {
                    MessageBox.Show("Lütfen tarihleri ve bilgileri doğru giriniz.");
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
                    //siparişin içeriklerinin hesaplama verilerini sil ve sonra bu sipariş içeriklerini sil.
                    //SqlCommand fetchordersdetails = new SqlCommand("SELECT id FROM purchase_order_detail WHERE orderid = " + id, conn);
                    //DataTable ordersdetailsdt = new DataTable();
                    //SqlDataAdapter ordersdetailsda = new SqlDataAdapter(fetchordersdetails);
                    //ordersdetailsda.Fill(ordersdetailsdt);
                    //
                    //int ordersdetailid;
                    //
                    //foreach (DataRow row in ordersdetailsdt.Rows)
                    //{
                    //    ordersdetailid = Convert.ToInt32(row[0]);
                    //    SqlCommand deleteordersdetailscalcdata = new SqlCommand("DELETE FROM CALCULDEBUG WHERE orderdetailid = " + ordersdetailid, conn);
                    //    conn.Open();
                    //    deleteordersdetailscalcdata.ExecuteNonQuery();
                    //    conn.Close();
                    //
                    //}

                    SqlCommand deleteorderdetails = new SqlCommand("DELETE FROM purchase_order_detail WHERE orderid = @orderid", conn);
                    deleteorderdetails.Parameters.AddWithValue("@orderid", SqlDbType.Int).Value = id;
                    conn.Open();
                    deleteorderdetails.ExecuteNonQuery();
                    conn.Close();

                    //siparişi sil.
                    SqlCommand deleteorder = new SqlCommand("DELETE FROM purchase_order WHERE id=@id", conn);
                    deleteorder.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    conn.Open();
                    deleteorder.ExecuteNonQuery();
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

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                OpenFormInMainPanel(new fm_suppliers_orders_details(), "fm_suppliers_orders_details");
            }
            else
            {
                MessageBox.Show("Lütfen işlemler için istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
            }
        }




        #endregion


    }
}
