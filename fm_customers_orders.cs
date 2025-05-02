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
    public partial class fm_customers_orders : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static int id { get; set; }
        #endregion

        #region critics
        public fm_customers_orders()
        {
            InitializeComponent();
        }

        private void fm_customers_orders_Load(object sender, EventArgs e)
        {
            id = -1;

            lbCtName.Text = "Seçilen Müşteri: " + fm_customers.customer_name;
            lbCtCode.Text = "Kodu: " + fm_customers.customer_code;
            lbCtComName.Text = "Ticari Ünvanı: " + fm_customers.customer_comname;
            lbCtAddress.Text = "Adresi: " + fm_customers.customer_address;
            lbCtTaxNo.Text = "Vergi No: " + fm_customers.customer_taxno;
            lbCtPhoneNum.Text = "Telefon No: " + fm_customers.customer_phonenum;
            fillproduct();
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand("SELECT id AS 'Sipariş ID', date_ AS 'Siparişin Verilme Tarihi', duedate AS 'Siparişin Bitiş Tarihi' FROM sales_order WHERE customerid = " + fm_customers.id, conn);
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
            //tarihler arasındaki siparişleri ara
            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                fillproduct();
            }
            else
            {
                SqlCommand fill = new SqlCommand("SELECT id AS 'Sipariş ID', date_ AS 'Siparişin Verilme Tarihi', duedate AS 'Siparişin Bitiş Tarihi' FROM sales_order WHERE customerid = " + fm_customers.id + " AND date_ BETWEEN @date AND @datetwo", conn);
                fill.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                fill.Parameters.AddWithValue("@datetwo", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(fill);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(dateTimePicker1.Value <= dateTimePicker2.Value)
                {

                    SqlCommand addorder = new SqlCommand("INSERT INTO sales_order(customerid, date_, duedate)" +
                        "VALUES(@cid, @dt, @dtt)", conn);
                    addorder.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = fm_customers.id;
                    addorder.Parameters.AddWithValue("@dt", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    addorder.Parameters.AddWithValue("@dtt", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                    conn.Open();
                    addorder.ExecuteNonQuery();
                    conn.Close();
                    
                    fillproduct();

                }
                else
                {
                    MessageBox.Show("Lütfen tarihleri doğru giriniz.");
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
                    SqlCommand fetchordersdetails = new SqlCommand("SELECT id FROM sales_order_detail WHERE orderid = " + id, conn);
                    DataTable ordersdetailsdt = new DataTable();
                    SqlDataAdapter ordersdetailsda = new SqlDataAdapter(fetchordersdetails);
                    ordersdetailsda.Fill(ordersdetailsdt);

                    int ordersdetailid;

                    foreach (DataRow row in ordersdetailsdt.Rows)
                    {
                        ordersdetailid = Convert.ToInt32(row[0]);
                        SqlCommand deleteordersdetailscalcdata = new SqlCommand("DELETE FROM CALCULDEBUG WHERE orderdetailid = " + ordersdetailid, conn);
                        conn.Open();
                        deleteordersdetailscalcdata.ExecuteNonQuery();
                        conn.Close();

                    }

                    SqlCommand deleteorderdetails = new SqlCommand("DELETE FROM sales_order_detail WHERE orderid = @orderid", conn);
                    deleteorderdetails.Parameters.AddWithValue("@orderid", SqlDbType.Int).Value = id;
                    conn.Open();
                    deleteorderdetails.ExecuteNonQuery();
                    conn.Close();

                    //siparişi sil.
                    SqlCommand deleteorder = new SqlCommand("DELETE FROM sales_order WHERE id=@id", conn);
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
                OpenFormInMainPanel(new fm_customers_orders_details(), "fm_customers_orders_details");
            }
            else
            {
                MessageBox.Show("Lütfen işlemler için istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
            }
        }
        #endregion


    }
}
