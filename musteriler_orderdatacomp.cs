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
    public partial class musteriler_orderdatacomp : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;


        int customer_id;

        int slid;


        public int sales_order_id { get; set; }

        public string musteri_isim { get; set; }
        
        public musteriler_orderdatacomp()
        {
            InitializeComponent();
        }


        //sipariş ekle
        private void button1_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO sales_order(customerid, date_, duedate)" +
                        "VALUES(@cid, @dt, @dtt)", baglan);
                    ekle.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = customer_id;
                    ekle.Parameters.AddWithValue("@dt", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    ekle.Parameters.AddWithValue("@dtt", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    //MessageBox.Show(dateTimePicker1.Value.Date.ToShortDateString());
                    //MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tarihleri giriniz.");
            }
        }

        private void musteriler_orderdatacomp_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'basicmrpdbDataSetMusterininSiparis.sales_order' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sales_orderTableAdapter.Fill(this.basicmrpdbDataSetMusterininSiparis.sales_order);
            musteriler mainwin = (musteriler)Application.OpenForms["musteriler"];
            
            this.Text = "Müşteriler: " + mainwin.customername + " - BasicMRP";

            customer_id = mainwin.customer_id;
            musteri_isim = mainwin.customername;
            
            label1.Text = "Müşteri Adı: " + mainwin.customername;
            label2.Text = "Müşteri Kodu: " + mainwin.customercode;
            label3.Text = "Müşteri Ticari Ünvanı: " + mainwin.customertitle;
            label4.Text = "Müşteri Vergi No: " + mainwin.customertaxxno;
            label5.Text = "Müşteri Telefonu: " + mainwin.customertelno;
            label6.Text = "Müşteri Adresi: " + mainwin.customeraddress;

            //datayi müsterinin siparişleriyle doldur
            SqlCommand doldur = new SqlCommand("SELECT * FROM sales_order WHERE customerid=@cid", baglan);
            doldur.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = customer_id;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(doldur);
            da.Fill(ds, "sales_order");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sales_order";

            slid = -1;

        }

        private void listele()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM sales_order WHERE customerid=@cid", baglan);
            listeleq.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = customer_id;
            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "sales_order");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sales_order";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(slid != -1)
            {
                Form mst_siparisurungir = new musteriler_orderdatacompSiparisAc();
                mst_siparisurungir.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen müşterinin sipariş ettiği ürünleri girmek için müşterinin bir sipariş kaydını seçiniz.");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir.
            try
            {
                slid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sales_order_id = slid;
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz");
                slid = -1;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tarihler arasındaki siparişleri ara
            if(dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                listele();
            }
            else
            {
                SqlCommand listeleq = new SqlCommand("SELECT * FROM sales_order WHERE customerid=@cid AND date_ BETWEEN @date AND @datetwo", baglan);
                listeleq.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = customer_id;
                listeleq.Parameters.AddWithValue("@date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                listeleq.Parameters.AddWithValue("@datetwo", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(listeleq);
                da.Fill(ds, "sales_order");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "sales_order";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //sil
            if (slid != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM sales_order WHERE id=@id", baglan);
                    sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = slid;
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                    slid = -1;
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki silmek istediğiniz veriye çift tıklayıp seçili hale getiriniz.");
            }
        }
    }
}
