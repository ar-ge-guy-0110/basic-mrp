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
    public partial class urunler_stok : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;

        int itemid;
        int stockitemid;


        public urunler_stok()
        {
            InitializeComponent();
        }

        private void urunler_stok_Load(object sender, EventArgs e)
        {
            listele();

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
            DataTable dt = new DataTable();
            string sql = "SELECT stock.id AS stock_id, item.id AS item_id, item.itemcode, item.itemname, item.itemtype, stock.amount, stock.unitcode FROM item JOIN stock ON stock.itemid = item.id";
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }



        //ÜRÜN STOK ARAMA------------------------------------------------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            //ürün ara;

            if (comboBox1.SelectedIndex != -1)
            {
                string cmd_start = "SELECT";
                string cmd_middle = " stock.id AS stock_id, item.id AS item_id, item.itemcode, item.itemname, item.itemtype, stock.amount, stock.unitcode";
                string cmd_end = " FROM item JOIN stock ON stock.itemid = item.id WHERE";

                string cmd_end2 = " FROM item JOIN stock ON stock.itemid = item.id WHERE";

                string multipstring;
                string multipstringtemp = "_";

                int cmdend_length = cmd_end.Length;
                akodlaribulkosullu();

                if (comboBox1.SelectedIndex != -1)
                {
                    cmd_end += " itemtype LIKE '%" + itype + "%'";
                    cmd_end2 = cmd_end;
                }

                if (comboBox2.SelectedIndex != -1)
                {
                    if (cmd_end.Length > cmdend_length)
                    {
                        cmd_end += " AND";
                    }

                    multipstring = multipstringtemp + multipstringtemp;
                    cmd_end += " itemcode LIKE " + "'" + multipstring + icodea1 + "%'";
                }

                if (comboBox3.SelectedIndex != -1)
                {
                    cmd_end = cmd_end2;

                    if (cmd_end.Length > cmdend_length)
                    {
                        cmd_end += " AND";
                    }

                    multipstring = string.Concat(Enumerable.Repeat(multipstringtemp, icodea1lenghth + 2));
                    cmd_end += " itemcode LIKE " + "'" + multipstring + icodea2 + "%'";
                }

                if (comboBox4.SelectedIndex != -1)
                {
                    cmd_end = cmd_end2;

                    if (cmd_end.Length > cmdend_length)
                    {
                        cmd_end += " AND";
                    }

                    multipstring = string.Concat(Enumerable.Repeat(multipstringtemp, icodea1lenghth + icodea2lenghth + 2));
                    cmd_end += " itemcode LIKE " + "'" + multipstring + icodea3 + "%'";
                }

                if (comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
                {
                    cmd_end += " AND";

                    //multipstring = string.Concat(Enumerable.Repeat(multipstringtemp, icodea1lenghth + icodea2lenghth + icodea3lenghth + 3));
                    multipstring = multipstringtemp + multipstringtemp;
                    //cmd_end += " itemcode LIKE " + "'" + multipstring + "-'+" + "@icodea4+'%-'";
                    cmd_end += " itemcode LIKE '%-" + icodea4 + "-%'";
                    //'%'+@itype+'%'
                }

                string bul = cmd_start + cmd_middle + cmd_end;
                MessageBox.Show(cmd_start + cmd_middle + cmd_end);


                if (comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || comboBox3.SelectedIndex != -1 || comboBox4.SelectedIndex != -1 || comboBox5.SelectedIndex != -1)
                {
                    DataTable dt = new DataTable();

                    baglan.Open();
                    SqlDataAdapter da = new SqlDataAdapter(bul, baglan);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();

                    MessageBox.Show(icodea4);
                    MessageBox.Show("ico1length:" + icodea1lenghth + " ico2length: " + icodea2lenghth + " ico3length: " + icodea3lenghth);
                    MessageBox.Show(icodea1 + " " + icodea2 + " " + icodea3 + " " + icodea4);

                    icodea1lenghth = 0;
                    icodea2lenghth = 0;
                    icodea3lenghth = 0;
                    icodea4length = 0;
                }
                else
                {
                    listele();
                }
            }
        }



        //---------------------------------------------------------------------------------------------------------------------------------------























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
            MessageBox.Show("Secilen katmanın id'si: " + selected_id.ToString());

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
            MessageBox.Show("Secilen katmanın id'si: " + selected_id.ToString());

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


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //ürün seç
            //tiklagetir

            try
            {
                itemid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                label1.Text = "Ürün Seç: " + dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                itemid = -1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ürün adina göre ara
            DataTable dt = new DataTable();
            string sql = "SELECT stock.id AS stock_id, item.id AS item_id, item.itemcode, item.itemname, item.itemtype, stock.amount, stock.unitcode FROM item JOIN stock ON stock.itemid = item.id WHERE itemname LIKE '%" + maskedTextBox1.Text + "%'";
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //hepsini getir
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //miktarı gir.
            if(itemid != -1 && maskedTextBox2.Text != "")
            {
                //try
                //{
                    SqlCommand guncelle = new SqlCommand("UPDATE stock SET amount = @amo WHERE itemid = @itmid", baglan);
                    guncelle.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox2.Text);
                    guncelle.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = itemid;

                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                //}
                //catch
                //{
                  //  MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                //}
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki miktarı güncellenecek veriyi seçiniz ve bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }
    }
}
