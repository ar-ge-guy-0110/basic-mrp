using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicMRP
{
    public partial class urunler : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;

        public bool smartcoding = false;
        public bool smcwin_opened { get; set; }

        int id;

        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public string product_unit { get; set; }
        public string product_doa { get; set; }

        public urunler()
        {
            InitializeComponent();
        }

        private void urunler_FormClosed(object sender, FormClosedEventArgs e)
        {
            urunler_kodlamasis childwin = (urunler_kodlamasis)Application.OpenForms["urunler_kodlamasis"];
            if(childwin != null)
            {
                childwin.Close();
            }
        }

        private void urunler_Load(object sender, EventArgs e)
        {
            smcwin_opened = false;

            id = -1;

            listele();

            //renkler gelsin--
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM akodrenkler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox5.Items.Add(oku["renk_adi"]);
            }
            baglan.Close();
        }

        private void listele()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM item", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "item");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "item";
        }

        private void akıllıKodlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(smcwin_opened == false)
            {
                Form smcwin = new urunler_kodlamasis();
                smcwin.Show();
                smcwin_opened = true;
            }
        }

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

            if(comboBox1.SelectedIndex == 2)
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

        //renk ekleme----------------------------------------------------------------------------------------------------------------------------

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedindexcolor = comboBox5.SelectedIndex.ToString();
        }



        //klasik ekleme--------------------------------------------------------------------------------------------------------------------------

        private void temizle()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            //sil
            if (id != -1)
            {
                try
                {
                    //bomdetailde baglı oldugu seyleri sil
                    SqlCommand bomdetailsil = new SqlCommand("DELETE FROM bom_detail WHERE mainitemid = @id OR childitemid = @id", baglan);
                    bomdetailsil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    baglan.Open();
                    bomdetailsil.ExecuteNonQuery();
                    baglan.Close();

                    //Reçeteyi sil
                    SqlCommand receteyisil = new SqlCommand("DELETE FROM bom WHERE itemid = @itmid", baglan);
                    receteyisil.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = id;
                    baglan.Open();
                    receteyisil.ExecuteNonQuery();
                    baglan.Close();

                    //Stoğu sil
                    SqlCommand stogusil = new SqlCommand("DELETE FROM stock WHERE itemid = @itmid", baglan);
                    stogusil.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = id;
                    baglan.Open();
                    stogusil.ExecuteNonQuery();
                    baglan.Close();


                    SqlCommand sil = new SqlCommand("DELETE FROM item WHERE id=@id", baglan);
                    sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();

                    listele();
                    id = -1;
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
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            //güncelle
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && comboBoxm.SelectedIndex != -1 && maskedTextBox4.Text != "" && id != -1)
            {
                try
                {
                    //bom_detail da bu urunlu bir sey varsa onlarında bilgilerinin guncellenmesi gerek!
                    SqlCommand bomdetailguncelle = new SqlCommand("UPDATE bom_detail SET mainunitcode = @icode WHERE mainitemid = @id", baglan);
                    bomdetailguncelle.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = maskedTextBox4.Text;
                    bomdetailguncelle.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

                    baglan.Open();
                    bomdetailguncelle.ExecuteNonQuery();
                    baglan.Close();

                    SqlCommand bomdetailguncelle2 = new SqlCommand("UPDATE bom_detail SET childunitcode = @icode WHERE childitemid = @id", baglan);
                    bomdetailguncelle2.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = maskedTextBox4.Text;
                    bomdetailguncelle2.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

                    baglan.Open();
                    bomdetailguncelle2.ExecuteNonQuery();
                    baglan.Close();

                    //bom bilgileri statik oyüzden onuda güncellemek lazım.
                    SqlCommand bomguncelle = new SqlCommand("UPDATE bom SET bomcode = @bcode, bomname = @bname WHERE itemid = @itmid", baglan);
                    bomguncelle.Parameters.AddWithValue("@bcode", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    bomguncelle.Parameters.AddWithValue("@bname", SqlDbType.NVarChar).Value = maskedTextBox2.Text + " RECETE";
                    bomguncelle.Parameters.AddWithValue("@itmid", SqlDbType.NVarChar).Value = id;

                    baglan.Open();
                    bomguncelle.ExecuteNonQuery();
                    baglan.Close();

                    
                    //stok buna referans oyuzden string bilgileri güncellemeye gerek yok.
                    
                    SqlCommand guncelle = new SqlCommand("UPDATE item SET itemname = @iname, itemtype = @itype, unitcode = @ucode WHERE id = @id", baglan);
                    guncelle.Parameters.AddWithValue("@iname", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@itype", SqlDbType.NVarChar).Value = uruntipi;
                    guncelle.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = maskedTextBox4.Text;
                    guncelle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki güncellenecek veriyi seçiniz ve bilgileri eksiksiz girdiğinize emin olunuz.");
            }
            */
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                if(dataGridView1.CurrentRow.Cells[3].Value.ToString() == "TM")
                {
                    //comboBoxm.SelectedIndex = 0;
                }
                else if(dataGridView1.CurrentRow.Cells[3].Value.ToString() == "MM")
                {
                    //comboBoxm.SelectedIndex = 1;
                }
                else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "YM")
                {
                    //comboBoxm.SelectedIndex = 2;
                }
                else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "HM")
                {
                    //comboBoxm.SelectedIndex = 3;
                }
                else
                {
                    //comboBoxm.SelectedIndex = 3;
                }


                product_id = id;
                product_code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                product_name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                product_type = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                product_unit = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                product_doa = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        //akıllı ekleme-----------------------------------------------------------------------------------------------------------

        string icode1; //ürünün ana kategorisi
        string icode2; //ürünün alt kategori bilgileri
        string icode3; //ürünün renk kodu
        string icode4; //ürünün açıklayıcı yazısı
        string lastcode; //son kod
        string itype; //ürün tipi

        string icodea1;
        string icodea2;
        string icodea3;
        string icodea4;

        int icodea1lenghth = 0;
        int icodea2lenghth = 0;
        int icodea3lenghth = 0;
        int icodea4length = 0;


        private void akodlaribul()
        {
            //icode1--------------------------------
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
            //---------------------------------------

            //icode2--------------------------------

            //assagidaki kodlardan alınacak

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

            icode2 = selected_id.ToString();
            
            icodea1 = icode2;
            icodea1lenghth = icode2.Length;

            //,,

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

            icodea2 = icode2;
            icodea2lenghth = icode2.Length;

            //,,

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

            icodea3 = icode2;
            icodea3lenghth = icode2.Length;

            //--------------------------------------

            //icode3--------------------------------

            if(comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
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
                icodea4length = icode3.Length;
            }
            else
            {
                icode3 = "00";

                icodea4 = icode3;
                icodea4length = icode3.Length;
            }
            //--------------------------------------

            //icode4--------------------------------

            if(akmaskedTextBox3.Text != "")
            {
                icode4 = akmaskedTextBox3.Text;
            }
            else
            {
                icode4 = "";
            }

            //--------------------------------------

            //lastcode------------------------------

            lastcode = icode1 + "-" + icode2 + "-" + icode3 + "-" + icode4;

            //--------------------------------------

        }

        private void akodlaribulkosullu()
        {
            //icode1--------------------------------

            if(comboBox1.SelectedIndex != -1)
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

            if(comboBox3.SelectedIndex != -1)
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

            if(comboBox4.SelectedIndex != -1)
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

            if (akmaskedTextBox3.Text != "")
            {
                icode4 = akmaskedTextBox3.Text;
            }
            else
            {
                icode4 = "";
            }

            //--------------------------------------

            //lastcode------------------------------

            lastcode = icode1 + "-" + icode2 + "-" + icode3 + "-" + icode4;

            //--------------------------------------

        }



        private void button10_Click(object sender, EventArgs e)
        {
            //ekleme
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && akmaskedTextBox1.Text != "" && akmaskedTextBox2.Text != "" && akmaskedTextBox3.Text != "")
            {
                akodlaribul();
                try
                {
                    int idbull;

                    SqlCommand ekle = new SqlCommand("INSERT INTO item(itemcode, itemname, itemtype, unitcode, date_of_addition)" +
                        "VALUES(@icode, @iname, @itype, @ucode, @doa) SELECT SCOPE_IDENTITY()", baglan);
                    ekle.Parameters.AddWithValue("@icode", SqlDbType.NVarChar).Value = lastcode;
                    ekle.Parameters.AddWithValue("@iname", SqlDbType.NVarChar).Value = akmaskedTextBox1.Text;
                    ekle.Parameters.AddWithValue("@itype", SqlDbType.NVarChar).Value = itype;
                    ekle.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = akmaskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@doa", SqlDbType.Date).Value = DateTime.Now;
                   
                    baglan.Open();
                    idbull = Convert.ToInt32(ekle.ExecuteScalar());

                    baglan.Close();
                    listele();



                    //ürünü stoğa kaydet.
                    SqlCommand stokolustur = new SqlCommand("INSERT INTO stock(itemid, amount, unitcode) VALUES(@id, @amo, @ucode)", baglan);
                    stokolustur.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idbull;
                    stokolustur.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = 0;
                    stokolustur.Parameters.AddWithValue("@ucode", SqlDbType.NVarChar).Value = akmaskedTextBox2.Text;

                    baglan.Open();
                    stokolustur.ExecuteNonQuery();
                    baglan.Close();

                    //ürünün reçetesini ekle
                    if (itype == "TM" || itype == "MM" || itype == "YM")
                    {
                        SqlCommand receteolustur = new SqlCommand("INSERT INTO bom(bomcode, bomname, itemid) VALUES(@bcode, @bname, @icode)", baglan);
                        receteolustur.Parameters.AddWithValue("@bcode", SqlDbType.NVarChar).Value = lastcode;
                        receteolustur.Parameters.AddWithValue("@bname", SqlDbType.NVarChar).Value = akmaskedTextBox1.Text + " RECETE";
                        receteolustur.Parameters.AddWithValue("@icode", SqlDbType.Int).Value = idbull;

                        baglan.Open();
                        receteolustur.ExecuteNonQuery();
                        baglan.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen gerekli bilgileri ilgili yerlere doldurduğunuza emin olunuz.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
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
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "item";



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

        private void button7_Click(object sender, EventArgs e)
        {
            listele();
        }

        //seçili ürünün reçete işlemlerini aç
        private void button8_Click(object sender, EventArgs e)
        {
            if (id != -1 && product_type != "HM")
            {
                Form u_bomtransacts = new urunler_BOMtransacts();
                u_bomtransacts.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen reçetesini görmek istediğiniz ürünü seçiniz.");
            }
        }

        private void ürünStoklarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ustock = new urunler_stok();
            ustock.ShowDialog();
        }


    }
}
