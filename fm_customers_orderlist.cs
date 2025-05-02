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
    public partial class fm_customers_orderlist : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        #endregion

        #region critics
        public fm_customers_orderlist()
        {
            InitializeComponent();
        }

        private void fm_customers_orderlist_Load(object sender, EventArgs e)
        {
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
            DataTable dt = new DataTable();
            string sql = "SELECT customer.customername AS 'Müşteri Adı', sales_order.date_ AS 'Siparişin Verilme Tarihi', sales_order.duedate AS 'Siparişin Bitiş Tarihi', item.itemname AS 'Sipariş Edilen Ürün', sales_order_detail.amount AS 'Sipariş Edilen Miktar' FROM customer JOIN sales_order ON customer.id = sales_order.customerid JOIN sales_order_detail ON sales_order.id = sales_order_detail.orderid JOIN item ON item.id = sales_order_detail.itemid";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        #endregion

        #region events
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
                SqlCommand fill = new SqlCommand("SELECT customer.customername AS 'Müşteri Adı', sales_order.date_ AS 'Siparişin Verilme Tarihi', sales_order.duedate AS 'Siparişin Bitiş Tarihi', item.itemname AS 'Sipariş Edilen Ürün', sales_order_detail.amount AS 'Sipariş Edilen Miktar' FROM customer JOIN sales_order ON customer.id = sales_order.customerid JOIN sales_order_detail ON sales_order.id = sales_order_detail.orderid JOIN item ON item.id = sales_order_detail.itemid WHERE sales_order.date_ BETWEEN @date AND @datetwo", conn);
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        #endregion


    }


}
