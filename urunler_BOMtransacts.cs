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
    public partial class urunler_BOMtransacts : Form
    {

        SqlConnection baglan = cs_dbconnections.conn;

        int productid;

        public string prd_name { get; set; }

        public int prd_id { get; set; }

        public string prd_type { get; set; }

        public int prd_bomid { get; set; }

        public string prd_unit { get; set; }

        public urunler_BOMtransacts()
        {
            InitializeComponent();
        }



        private void urunler_BOMtransacts_Load(object sender, EventArgs e)
        {
            urunler mainwin = (urunler)Application.OpenForms["urunler"];

            this.Text = "Ürünler: " + mainwin.product_name + " - BasicMRP";

            productid = mainwin.product_id;
            prd_id = productid;

            label1.Text = "Ürün Adı: " + mainwin.product_name;
            label2.Text = "Ürün ID: " + mainwin.product_id.ToString();
            label3.Text = "Ürün Kodu: " + mainwin.product_code;
            label4.Text = "Ürün Tipi: " + mainwin.product_type;
            label5.Text = "Ürün Birimi: " + mainwin.product_unit;
            label6.Text = "Eklenme Tarihi: " + mainwin.product_doa;

            prd_name = mainwin.product_name;
            prd_type = mainwin.product_type;
            prd_unit = mainwin.product_unit;

            SqlCommand selectthisbomid = new SqlCommand("SELECT id FROM bom WHERE itemid = @itmid", baglan);
            selectthisbomid.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = productid;
            baglan.Open();
            SqlDataReader idoku = selectthisbomid.ExecuteReader();
            idoku.Read();
            prd_bomid = (int)idoku[0];
            baglan.Close();

            label8.Text = "Reçete ID: " + prd_bomid;

            receteyidoldur();
        }

        //ürün için reçete oluştur.
        private void button1_Click(object sender, EventArgs e)
        {
            Form frm_bomdetail = new urunler_bomdetail();
            frm_bomdetail.ShowDialog();
        }

        private void receteyidoldur()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT bom_detail.childitemid AS urun_id, item.itemcode AS urun_kodu, item.itemname AS urun_adi, bom_detail.childamount AS gerekli_miktar, bom_detail.childunitcode AS birim, bom_detail.bomid AS ana_urun_receteid FROM item JOIN bom_detail ON item.id = bom_detail.childitemid WHERE bom_detail.bomid = " + prd_bomid;
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
    }
}
