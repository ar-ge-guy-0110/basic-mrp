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
    public partial class musteriler_orderdatacompSiparisAc : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;

        int salesid;

        int salesdetailid;

        int itemid;

        string itemunitcode;

        //for mrpcalculation--------

        string islemtarihi;
        int orderdetailid;
        int bomid;
        int bomdetailid;
        int mainitemid;
        int childitemid;
        int mainamount;
        int givenorderamount;
        int stock;
        int requirement;
        string supplytype;


        //--------------------------

        public musteriler_orderdatacompSiparisAc()
        {
            InitializeComponent();
        }

        private void musteriler_orderdatacompSiparisAc_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'basicmrpdbDataSetKisiSiparisDetay.sales_order_detail' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sales_order_detailTableAdapter.Fill(this.basicmrpdbDataSetKisiSiparisDetay.sales_order_detail);
            // TODO: Bu kod satırı 'basicmrpdbDataSetSiparisUrunleri.item' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.itemTableAdapter.Fill(this.basicmrpdbDataSetSiparisUrunleri.item);

            musteriler_orderdatacomp mainwin = (musteriler_orderdatacomp)Application.OpenForms["musteriler_orderdatacomp"];

            salesid = mainwin.sales_order_id;

            listele();

            this.Text = mainwin.musteri_isim + " :" + "Sipariş Aç - BasicMRP";

            itemid = -1;

            salesdetailid = -1;

            //ürünler bölüm--------------------------------------------------------------

            //renkler gelsin--
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM akodrenkler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox5.Items.Add(oku["renk_adi"]);
            }
            baglan.Close();
            //--

        }

        private void listele()
        {
            SqlCommand doldur = new SqlCommand(@"SELECT 
            sales_order_detail.id AS 'Sipariş Detay ID',
            item.itemname AS 'Sipariş Edilen Ürünün Adı',
            sales_order_detail.amount AS 'Sipariş Miktarı',
            sales_order_detail.unitcode AS 'Birimi'
            FROM sales_order_detail
            JOIN item ON sales_order_detail.itemid = item.id WHERE orderid = @oid", baglan);
            doldur.Parameters.AddWithValue("@oid", SqlDbType.Int).Value = salesid;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(doldur);
            da.Fill(ds, "sales_order_detail");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sales_order_detail";
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir: urunu sec
            try
            {
                itemid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());

                maskedTextBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();

                label1.Text = "Ürün Seç: " + dataGridView2.CurrentRow.Cells[2].Value.ToString();

                itemunitcode = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                itemid = -1;
                label1.Text = "Ürün Seç: ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //siparişe ürün ekle
            //ekleyince itemid = -1;
            //label1 = "Ürün İsmi: ";
            if(itemid != -1 && maskedTextBox1.Text != "")
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO sales_order_detail(orderid, itemid, amount, unitcode)" +
                        "VALUES(@oid, @itmid, @amo, @ucode)", baglan);
                    ekle.Parameters.AddWithValue("@oid", SqlDbType.Int).Value = salesid;
                    ekle.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = itemid;
                    ekle.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = itemunitcode;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele();

                    itemid = -1;
                    label1.Text = "Ürün Seç:";
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen ürünü seçtiğinizden ve ürün miktarını girdiğinizden emin olunuz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //siparişteki ürünü sil
            if(salesdetailid != -1)
            {
                try
                {
                    //mrp calc danda siparişle ilgili ürünlerin ihtiyaç verilerini sil.
                    SqlCommand ihtiyacplanlamasil = new SqlCommand("DELETE FROM mrp_calculation WHERE orderdetailid = @id", baglan);
                    ihtiyacplanlamasil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = salesdetailid;

                    SqlCommand ihtiyacplanlamasil2 = new SqlCommand("DELETE FROM mrp_calculation_temp WHERE orderdetailid = @id", baglan);
                    ihtiyacplanlamasil2.Parameters.AddWithValue("@id", SqlDbType.Int).Value = salesdetailid;


                    SqlCommand sil = new SqlCommand("DELETE FROM sales_order_detail WHERE id=@id", baglan);
                    sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = salesdetailid;
                    baglan.Open();
                    ihtiyacplanlamasil.ExecuteNonQuery();
                    ihtiyacplanlamasil2.ExecuteNonQuery();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                    salesdetailid = -1;
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki silmek istediğiniz sipariş detayına çift tıklatıp seçili hale getiriniz.");
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir siparişteki ürünü seç
            try
            {
                salesdetailid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                salesdetailid = -1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //hepsini getir
            listele2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Ürünü adına göre ara
            SqlCommand listeleq = new SqlCommand("SELECT * FROM item WHERE itemname LIKE '%'+@iname+'%'", baglan);
            listeleq.Parameters.AddWithValue("@iname", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "item");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "item";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ürün ara;

            if (comboBox1.SelectedIndex != -1)
            {
                string cmd_start = "SELECT";
                string cmd_middle = " *";
                string cmd_end = " FROM item WHERE";

                string cmd_end2 = " FROM item WHERE";

                string multipstring;
                string multipstringtemp = "_";

                int cmdend_length = cmd_end.Length;
                akodlaribulkosullu();

                if (comboBox1.SelectedIndex != -1)
                {
                    cmd_end += " itemtype LIKE '%'+@itype+'%'";
                    cmd_end2 = cmd_end;
                }

                if (comboBox2.SelectedIndex != -1)
                {
                    if (cmd_end.Length > cmdend_length)
                    {
                        cmd_end += " AND";
                    }

                    multipstring = multipstringtemp + multipstringtemp;
                    cmd_end += " itemcode LIKE " + "'" + multipstring + "'+" + "@icodea1+'%'";
                }

                if (comboBox3.SelectedIndex != -1)
                {
                    cmd_end = cmd_end2;

                    if (cmd_end.Length > cmdend_length)
                    {
                        cmd_end += " AND";
                    }

                    multipstring = string.Concat(Enumerable.Repeat(multipstringtemp, icodea1lenghth + 2));
                    cmd_end += " itemcode LIKE " + "'" + multipstring + "'+" + "@icodea2+'%'";
                }

                if (comboBox4.SelectedIndex != -1)
                {
                    cmd_end = cmd_end2;

                    if (cmd_end.Length > cmdend_length)
                    {
                        cmd_end += " AND";
                    }

                    multipstring = string.Concat(Enumerable.Repeat(multipstringtemp, icodea1lenghth + icodea2lenghth + 2));
                    cmd_end += " itemcode LIKE " + "'" + multipstring + "'+" + "@icodea3+'%'";
                }

                if (comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
                {
                    cmd_end += " AND";

                    //multipstring = string.Concat(Enumerable.Repeat(multipstringtemp, icodea1lenghth + icodea2lenghth + icodea3lenghth + 3));
                    multipstring = multipstringtemp + multipstringtemp;
                    //cmd_end += " itemcode LIKE " + "'" + multipstring + "-'+" + "@icodea4+'%-'";
                    cmd_end += " itemcode LIKE '%-'+@icodea4+'-%'";
                    //'%'+@itype+'%'
                }

                if(maskedTextBox2.Text != "")
                {

                }

                SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

                if (comboBox1.SelectedIndex != -1)
                    bul.Parameters.AddWithValue("@itype", SqlDbType.NVarChar).Value = itype;
                if (comboBox2.SelectedIndex != -1)
                    bul.Parameters.AddWithValue("@icodea1", SqlDbType.NVarChar).Value = icodea1;
                if (comboBox3.SelectedIndex != -1)
                    bul.Parameters.AddWithValue("@icodea2", SqlDbType.NVarChar).Value = icodea2;
                if (comboBox4.SelectedIndex != -1)
                    bul.Parameters.AddWithValue("@icodea3", SqlDbType.NVarChar).Value = icodea3;
                if (comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
                    bul.Parameters.AddWithValue("@icodea4", SqlDbType.NVarChar).Value = icodea4;


                if (comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || comboBox3.SelectedIndex != -1 || comboBox4.SelectedIndex != -1 || comboBox5.SelectedIndex != -1)
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(bul);
                    da.Fill(ds, "item");
                    dataGridView2.DataSource = ds;
                    dataGridView2.DataMember = "item";



                    icodea1lenghth = 0;
                    icodea2lenghth = 0;
                    icodea3lenghth = 0;
                    icodea4length = 0;
                }
                else
                {
                    listele2();
                }
            }
        }

        private void listele2()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM item", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "item");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "item";
        }



        //ürünler yüklensin----------------------

        //ana gruplardan birinci katman secimine---------------------------------------------------------------------------------

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox5.SelectedIndex = 0;

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodtakim1katman", baglan);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["birinci_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox5.SelectedIndex = 0;

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodmamul1katman", baglan);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["birinci_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox5.SelectedIndex = 0;

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodyarimamul1katman", baglan);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["birinci_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox5.SelectedIndex = 0;


                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM akodhammadde1katman", baglan);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["birinci_katman_adi"]);
                }
                baglan.Close();
            }
        }

        //--

        //birinci katmanlardan ikinci katmanlar secimine-------------------------------------------------------------------------

        int selected_id;
        string selectcommand;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seçileni bul
            string selected = comboBox2.Text;


            if (comboBox1.SelectedIndex == 0)
            {
                selectcommand = "Select * FROM akodtakim1katman WHERE birinci_katman_adi = @fname";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                selectcommand = "Select * FROM akodmamul1katman WHERE birinci_katman_adi = @fname";
            }

            if (comboBox1.SelectedIndex == 2)
            {
                selectcommand = "Select * FROM akodyarimamul1katman WHERE birinci_katman_adi = @fname";
            }

            if (comboBox1.SelectedIndex == 3)
            {
                selectcommand = "Select * FROM akodhammadde1katman WHERE birinci_katman_adi = @fname";
            }

            baglan.Open();
            SqlCommand idal = new SqlCommand(selectcommand, baglan);
            idal.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = selected;
            SqlDataReader idoku = idal.ExecuteReader();
            idoku.Read();
            selected_id = (int)idoku[0];
            baglan.Close();

            //-------

            if (comboBox1.SelectedIndex == 0)
            {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox3.Text = "";
                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodtakim2katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["ikinci_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 1)
            {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox3.Text = "";
                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodmamul2katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["ikinci_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 2)
            {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox3.Text = "";
                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodyarimamul2katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["ikinci_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 3)
            {
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();

                comboBox3.Text = "";
                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodhammadde2katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["ikinci_katman_adi"]);

                }
                baglan.Close();
            }
        }


        //--

        //ikinci katmanlardan ucuncu katmanlar secimine--------------------------------------------------------------------------

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seçileni bul

            string selected = comboBox3.Text;


            if (comboBox1.SelectedIndex == 0)
            {
                selectcommand = "Select * FROM akodtakim2katman WHERE ikinci_katman_adi = @fname";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                selectcommand = "Select * FROM akodmamul2katman WHERE ikinci_katman_adi = @fname";
            }

            if (comboBox1.SelectedIndex == 2)
            {
                selectcommand = "Select * FROM akodyarimamul2katman WHERE ikinci_katman_adi = @fname";
            }

            if (comboBox1.SelectedIndex == 3)
            {
                selectcommand = "Select * FROM akodhammadde2katman WHERE ikinci_katman_adi = @fname";
            }

            baglan.Open();
            SqlCommand idal = new SqlCommand(selectcommand, baglan);
            idal.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = selected;
            SqlDataReader idoku = idal.ExecuteReader();
            idoku.Read();
            selected_id = (int)idoku[0];
            baglan.Close();

            //---

            if (comboBox1.SelectedIndex == 0)
            {
                comboBox4.Items.Clear();

                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodtakim3katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox4.Items.Add(oku["ucuncu_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 1)
            {
                comboBox4.Items.Clear();

                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodmamul3katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox4.Items.Add(oku["ucuncu_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 2)
            {
                comboBox4.Items.Clear();

                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodyarimamul3katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox4.Items.Add(oku["ucuncu_katman_adi"]);
                }
                baglan.Close();
            }

            if (comboBox1.SelectedIndex == 3)
            {
                comboBox4.Items.Clear();

                comboBox4.Text = "";

                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT * from akodhammadde3katman WHERE bagil_ustkatmanid = @chooseid", baglan);
                komut.Parameters.AddWithValue("@chooseid", SqlDbType.Int).Value = selected_id;
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox4.Items.Add(oku["ucuncu_katman_adi"]);
                }
                baglan.Close();
            }
        }

        //--

        //arama fonksiyonu için gerekli fonksiyon--------

        string icode1; //ürünün ana kategorisi
        string icode2; //ürünün alt kategori bilgileri
        string icode3; //ürünün renk kodu
        string itype; //ürün tipi

        string icodea1;
        string icodea2;
        string icodea3;
        string icodea4;

        int icodea1lenghth = 0;
        int icodea2lenghth = 0;
        int icodea3lenghth = 0;
        int icodea4length = 0;


        private void akodlaribulkosullu()
        {
            //icode1--------------------------------

            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    icode1 = "3";
                    itype = "TM";
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    icode1 = "2";
                    itype = "MM";
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    icode1 = "1";
                    itype = "YM";
                }

                if (comboBox1.SelectedIndex == 3)
                {
                    icode1 = "0";
                    itype = "HM";
                }
            }

            //---------------------------------------

            //icode2--------------------------------

            //assagidaki kodlardan alınacak

            string selected;

            if (comboBox2.SelectedIndex != -1)
            {

                selected = comboBox2.Text;

                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodtakim1katman WHERE birinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    selectcommand = "Select * FROM akodmamul1katman WHERE birinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    selectcommand = "Select * FROM akodyarimamul1katman WHERE birinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 3)
                {
                    selectcommand = "Select * FROM akodhammadde1katman WHERE birinci_katman_adi = @fname";
                }

                baglan.Open();
                SqlCommand idal = new SqlCommand(selectcommand, baglan);
                idal.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = selected;
                SqlDataReader idoku = idal.ExecuteReader();
                idoku.Read();
                selected_id = (int)idoku[0];
                baglan.Close();

                icode2 = selected_id.ToString();

                icodea1 = icode2;
                icodea1lenghth = icode2.Length;
            }



            //,,

            if (comboBox3.SelectedIndex != -1)
            {
                selected = comboBox3.Text;


                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodtakim2katman WHERE ikinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    selectcommand = "Select * FROM akodmamul2katman WHERE ikinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    selectcommand = "Select * FROM akodyarimamul2katman WHERE ikinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 3)
                {
                    selectcommand = "Select * FROM akodhammadde2katman WHERE ikinci_katman_adi = @fname";
                }

                baglan.Open();
                SqlCommand idal2 = new SqlCommand(selectcommand, baglan);
                idal2.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = selected;
                SqlDataReader idoku2 = idal2.ExecuteReader();
                idoku2.Read();
                selected_id = (int)idoku2[0];
                baglan.Close();

                icode2 += selected_id.ToString();

                icodea2 = selected_id.ToString();
                icodea2lenghth = icodea2.Length;
            }



            //,,

            if (comboBox4.SelectedIndex != -1)
            {
                selected = comboBox4.Text;


                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodtakim3katman WHERE ucuncu_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    selectcommand = "Select * FROM akodmamul3katman WHERE ucuncu_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    selectcommand = "Select * FROM akodyarimamul3katman WHERE ucuncu_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 3)
                {
                    selectcommand = "Select * FROM akodhammadde3katman WHERE ucuncu_katman_adi = @fname";
                }

                baglan.Open();
                SqlCommand idal3 = new SqlCommand(selectcommand, baglan);
                idal3.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = selected;
                SqlDataReader idoku3 = idal3.ExecuteReader();
                idoku3.Read();
                selected_id = (int)idoku3[0];
                baglan.Close();

                icode2 += selected_id.ToString();

                icodea3 = selected_id.ToString();
                icodea3lenghth = icodea3.Length;
            }

            //--------------------------------------

            //icode3--------------------------------

            if (comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
            {
                selected = comboBox5.Text;

                selectcommand = "SELECT * FROM akodrenkler WHERE renk_adi = @renk";

                baglan.Open();
                SqlCommand idal4 = new SqlCommand(selectcommand, baglan);
                idal4.Parameters.AddWithValue("@renk", SqlDbType.NVarChar).Value = selected;
                SqlDataReader idoku4 = idal4.ExecuteReader();
                idoku4.Read();
                selected_id = (int)idoku4[0];
                baglan.Close();

                icode3 = selected_id.ToString();

                icodea4 = icode3;
                icodea4length = icodea4.Length;
            }
            else
            {
                icode3 = "00";

                icodea4 = icode3;
                icodea4length = icode3.Length;
            }
            //--------------------------------------

            //icode4--------------------------------



            //--------------------------------------

            //lastcode------------------------------


            //--------------------------------------

        }

        //--

        private void button4_Click(object sender, EventArgs e)
        {


        }


    }
}
