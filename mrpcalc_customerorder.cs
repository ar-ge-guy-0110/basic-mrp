using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BasicMRP
{
    public partial class mrpcalc_customerorder : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;

        public mrpcalc_customerorder()
        {
            InitializeComponent();
        }

        private void mrpcalc_customerorder_Load(object sender, EventArgs e)
        {
            siparislerilistele();
        }

        private void siparislerilistele()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT customer.customername AS musteri_adi, sales_order.date_ AS siparis_tarihi, sales_order.duedate AS bitis_tarihi, item.itemname AS siparis_urunu, sales_order_detail.amount AS istenilen_miktar FROM customer JOIN sales_order ON customer.id = sales_order.customerid JOIN sales_order_detail ON sales_order.id = sales_order_detail.orderid JOIN item ON item.id = sales_order_detail.itemid";
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void mrpcalc_customerorder_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        //butonlar----------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            //tarihler arasındaki siparişleri ara
            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                siparislerilistele();
            }
            else
            {

                DataTable dt = new DataTable();
                string sql = "SELECT customer.customername AS musteri_adi, sales_order.date_ AS siparis_tarihi, sales_order.duedate AS bitis_tarihi, item.itemname AS siparis_urunu, sales_order_detail.amount AS istenilen_miktar FROM customer JOIN sales_order ON customer.id = sales_order.customerid JOIN sales_order_detail ON sales_order.id = sales_order_detail.orderid JOIN item ON item.id = sales_order_detail.itemid WHERE sales_order.date_ BETWEEN CONVERT(date, '" + dateTimePicker1.Value.Date + "', 103) AND CONVERT(date, '" + dateTimePicker2.Value.Date + "', 103)";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
        }


    }
}
