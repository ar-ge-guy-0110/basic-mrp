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
    public partial class urunler_bomdetail : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;
        int urunid;
        string uruntip;

        int bomdetailid;

        int urunreceteid;
        int cocukurunid;
        int anaurunmiktar;
        int cocukurunmiktar;
        string anaurunbirim;
        string cocukurunbirim;

        public urunler_bomdetail()
        {
            InitializeComponent();
        }

        private void urunler_bomdetail_Load(object sender, EventArgs e)
        {
            urunler_BOMtransacts mainwin = (urunler_BOMtransacts)Application.OpenForms["urunler_BOMtransacts"];

            urunid = mainwin.prd_id;
            uruntip = mainwin.prd_type;

            bomdetailid = -1;

            this.Text = mainwin.prd_name + ": Reçeteye Ekle - BasicMRP";




            //urun arama kısmı----------------
            if(uruntip == "TM")
            {
                comboBox1.Items.Clear();

                comboBox1.Items.Add("MAMÜLLER");
                comboBox1.Items.Add("YARI MAMÜLLER");
                comboBox1.Items.Add("HAMMADDELER");
            }
            else if(uruntip == "MM")
            {
                comboBox1.Items.Clear();

                comboBox1.Items.Add("YARI MAMÜLLER");
                comboBox1.Items.Add("HAMMADDELER");
            }
            else
            {
                //else YM
                comboBox1.Items.Clear();

                comboBox1.Items.Add("HAMMADDELER");
            }


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

            //detay recete icin gerekli bilgiler

            urunreceteid = mainwin.prd_bomid;
            //urunid: yukarda
            //cocukurunid: asagida
            anaurunmiktar = 1; //herzaman 1, çünkü bir ürünün en temel reçetesini çiziyoruz şu an.
            anaurunbirim = mainwin.prd_unit;
            //cocukurunmiktar: asagida
            //cocukurunbirim: asagida

            //--

            urunlerilistele();
            recetedetaydoldur();
        }

        //ürünler yüklensin----------------------

        //ana gruplardan birinci katman secimine---------------------------------------------------------------------------------

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uruntip == "TM")
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
                    SqlCommand komut = new SqlCommand("SELECT * from akodmamul1katman", baglan);
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
                    SqlCommand komut = new SqlCommand("SELECT * from akodyarimamul1katman", baglan);
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
                    SqlCommand komut = new SqlCommand("SELECT * from akodhammadde1katman", baglan);
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        comboBox2.Items.Add(oku["birinci_katman_adi"]);
                    }
                    baglan.Close();
                }
            }
            else if (uruntip == "MM")
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
                    SqlCommand komut = new SqlCommand("SELECT * from akodyarimamul1katman", baglan);
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
                    SqlCommand komut = new SqlCommand("SELECT * from akodhammadde1katman", baglan);
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        comboBox2.Items.Add(oku["birinci_katman_adi"]);
                    }
                    baglan.Close();
                }
            }
            else
            {
                //else YM
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
                    SqlCommand komut = new SqlCommand("SELECT * from akodhammadde1katman", baglan);
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        comboBox2.Items.Add(oku["birinci_katman_adi"]);
                    }
                    baglan.Close();
                }
            }
        }

        //--

        //birinci katmanlardan ikinci katmanlar secimine-------------------------------------------------------------------------

        int selected_id;
        string selectcommand;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seçileni bul
            if (uruntip == "TM")
            {
                string selected = comboBox2.Text;


                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodmamul1katman WHERE birinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    selectcommand = "Select * FROM akodyarimamul1katman WHERE birinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 2)
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

            }
            else if (uruntip == "MM")
            {
                string selected = comboBox2.Text;


                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodyarimamul1katman WHERE birinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
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

            }
            else
            {
                //else YM

                string selected = comboBox2.Text;


                if (comboBox1.SelectedIndex == 0)
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

            }

            //-------

            if (uruntip == "TM")
            {
                if (comboBox1.SelectedIndex == 0)
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

                if (comboBox1.SelectedIndex == 1)
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

                if (comboBox1.SelectedIndex == 2)
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
            else if (uruntip == "MM")
            {
                if (comboBox1.SelectedIndex == 0)
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

                if (comboBox1.SelectedIndex == 1)
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
            else
            {
                //else YM
                if (comboBox1.SelectedIndex == 0)
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
        }


        //--

        //ikinci katmanlardan ucuncu katmanlar secimine--------------------------------------------------------------------------

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seçileni bul

            if (uruntip == "TM")
            {
                string selected = comboBox3.Text;


                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodmamul2katman WHERE ikinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    selectcommand = "Select * FROM akodyarimamul2katman WHERE ikinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 2)
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

            }
            else if (uruntip == "MM")
            {
                string selected = comboBox3.Text;


                if (comboBox1.SelectedIndex == 0)
                {
                    selectcommand = "Select * FROM akodyarimamul2katman WHERE ikinci_katman_adi = @fname";
                }

                if (comboBox1.SelectedIndex == 1)
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

            }
            else
            {
                //else YM
                string selected = comboBox3.Text;


                if (comboBox1.SelectedIndex == 0)
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

            }

            //--


            if (uruntip == "TM")
            {
                if (comboBox1.SelectedIndex == 0)
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

                if (comboBox1.SelectedIndex == 1)
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

                if (comboBox1.SelectedIndex == 2)
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
            else if (uruntip == "MM")
            {
                if (comboBox1.SelectedIndex == 0)
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

                if (comboBox1.SelectedIndex == 1)
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
            else
            {
                //else YM
                if (comboBox1.SelectedIndex == 0)
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
        }

        //--

        //ürünler arama kısmı--------------------------------------------------------------------------------------------

        //ara butonu
        private void button1_Click(object sender, EventArgs e)
        {
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



                if (comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || comboBox3.SelectedIndex != -1 || comboBox4.SelectedIndex != -1 || comboBox5.SelectedIndex != -1)
                {
                    DataTable dt = new DataTable();

                    baglan.Open();
                    SqlDataAdapter da = new SqlDataAdapter(bul, baglan);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();



                    icodea1lenghth = 0;
                    icodea2lenghth = 0;
                    icodea3lenghth = 0;
                    icodea4length = 0;
                }
                else
                {
                    urunlerilistele();
                }

            }
        }

        //isme gore ara butonu
        private void button2_Click(object sender, EventArgs e)
        {
            if (uruntip == "TM")
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM item WHERE itemname LIKE '%" + maskedTextBox1.Text + "%' AND itemtype = 'MM' OR itemtype = 'YM' OR itemtype = 'HM'";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else if (uruntip == "MM")
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM item WHERE itemname LIKE '%" + maskedTextBox1.Text + "%' AND itemtype = 'YM' OR itemtype = 'HM'";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                //else YM
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM item WHERE itemname LIKE '%" + maskedTextBox1.Text + "%' AND itemtype = 'HM'";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
        }

        //hepsini getir
        private void button3_Click(object sender, EventArgs e)
        {
            urunlerilistele();
        }


        //--

        //yardimci fonksiyonlarımız--------------------------------------------------------------------------------------



        //ürünleri grid tabloda göster
        private void urunlerilistele()
        {
            if (uruntip == "TM")
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM item WHERE itemtype = 'MM' OR itemtype = 'YM' OR itemtype = 'HM'";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else if (uruntip == "MM")
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM item WHERE itemtype = 'YM' OR itemtype = 'HM'";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                //else YM
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM item WHERE itemtype = 'HM'";
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
        }
        //--

        //recete detaylarını grid tabloda göster---------------------------------------------------------------------------------
        private void recetedetaydoldur()
        {
            SqlCommand doldur = new SqlCommand(@"SELECT 
                                                    bom_detail.id AS 'Recete Detay ID',
                                                    bom_detail.bomid AS 'Recete ID',
                                                    item.itemname AS 'Ana Urun Adı',
                                                    bom_detail.mainamount AS 'Ana Miktar',
                                                    item.unitcode AS 'Ana Urun Birimi',
                                                    item2.itemname AS 'Cocuk Urun Adı',
                                                    bom_detail.childamount AS 'Cocuk Miktar',
                                                    item2.unitcode AS 'Cocuk Urun Birimi'
                                                 FROM bom_detail
                                                    JOIN item ON bom_detail.mainitemid = item.id
                                                    JOIN item AS item2 ON bom_detail.childitemid = item2.id
                                                 WHERE bom_detail.bomid = @bomid", baglan);
            doldur.Parameters.AddWithValue("@bomid", SqlDbType.Int).Value = urunreceteid;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(doldur);
            da.Fill(ds, "bom_detail");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "bom_detail";

            /*
            DataTable ds = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(doldur);
            da.Fill(ds);
            dataGridView2.DataSource = ds;
            */
        }


        //--

        //arama icin gerekli fonksiyon
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

            if (uruntip == "TM")
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        icode1 = "2";
                        itype = "MM";
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        icode1 = "1";
                        itype = "YM";
                    }

                    if (comboBox1.SelectedIndex == 2)
                    {
                        icode1 = "0";
                        itype = "HM";
                    }
                }
            }
            else if (uruntip == "MM")
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        icode1 = "1";
                        itype = "YM";
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        icode1 = "0";
                        itype = "HM";
                    }
                }
            }
            else
            {
                //else YM
                if (comboBox1.SelectedIndex != -1)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        icode1 = "0";
                        itype = "HM";
                    }
                }
            }

            //---------------------------------------

            //icode2--------------------------------

            //assagidaki kodlardan alınacak

            string selected;

            if (uruntip == "TM")
            {
                if (comboBox2.SelectedIndex != -1)
                {

                    selected = comboBox2.Text;

                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectcommand = "Select * FROM akodmamul1katman WHERE birinci_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        selectcommand = "Select * FROM akodyarimamul1katman WHERE birinci_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 2)
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
            }
            else if (uruntip == "MM")
            {
                if (comboBox2.SelectedIndex != -1)
                {

                    selected = comboBox2.Text;

                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectcommand = "Select * FROM akodyarimamul1katman WHERE birinci_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 1)
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
            }
            else
            {
                //else YM
                if (comboBox2.SelectedIndex != -1)
                {

                    selected = comboBox2.Text;

                    if (comboBox1.SelectedIndex == 0)
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
            }

            //,,

            if (uruntip == "TM")
            {
                if (comboBox3.SelectedIndex != -1)
                {
                    selected = comboBox3.Text;


                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectcommand = "Select * FROM akodmamul2katman WHERE ikinci_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        selectcommand = "Select * FROM akodyarimamul2katman WHERE ikinci_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 2)
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
            }
            else if (uruntip == "MM")
            {
                if (comboBox3.SelectedIndex != -1)
                {
                    selected = comboBox3.Text;


                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectcommand = "Select * FROM akodyarimamul2katman WHERE ikinci_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 1)
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
            }
            else
            {
                //else YM
                if (comboBox3.SelectedIndex != -1)
                {
                    selected = comboBox3.Text;


                    if (comboBox1.SelectedIndex == 0)
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
            }

            //,,

            if (uruntip == "TM")
            {
                if (comboBox4.SelectedIndex != -1)
                {
                    selected = comboBox4.Text;


                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectcommand = "Select * FROM akodmamul3katman WHERE ucuncu_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        selectcommand = "Select * FROM akodyarimamul3katman WHERE ucuncu_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 2)
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
            }
            else if (uruntip == "MM")
            {
                if (comboBox4.SelectedIndex != -1)
                {
                    selected = comboBox4.Text;


                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectcommand = "Select * FROM akodyarimamul3katman WHERE ucuncu_katman_adi = @fname";
                    }

                    if (comboBox1.SelectedIndex == 1)
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
            }
            else
            {
                //else YM
                if (comboBox4.SelectedIndex != -1)
                {
                    selected = comboBox4.Text;


                    if (comboBox1.SelectedIndex == 0)
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

        //--

        //ürün gir/sil ------------------------------------------------------------------------------

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text != "")
            {
                cocukurunmiktar = Convert.ToInt32(maskedTextBox2.Text);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //URUN SEÇIMI ONEMLI!!
            try
            {
                cocukurunid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cocukurunbirim = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                label1.Text = "Ürün Seç: " + dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                cocukurunid = -1;
                label1.Text = "Ürün Seç: ";
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //receteden urun silmek icin receteden urun sec
            try
            {
                bomdetailid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                bomdetailid = -1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ürünü receteye ekle
            if (cocukurunid != -1 && maskedTextBox2.Text != "")
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO bom_detail(bomid, mainitemid, childitemid, mainamount, mainunitcode, childamount, childunitcode)" +
                        "VALUES(@bid, @mid, @cid, @mamo, @mucode, @camo, @cucode)", baglan);
                    ekle.Parameters.AddWithValue("@bid", SqlDbType.Int).Value = urunreceteid;
                    ekle.Parameters.AddWithValue("@mid", SqlDbType.Int).Value = urunid;
                    ekle.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = cocukurunid;
                    ekle.Parameters.AddWithValue("@mamo", SqlDbType.Int).Value = anaurunmiktar;
                    ekle.Parameters.AddWithValue("@mucode", SqlDbType.NVarChar).Value = anaurunbirim;
                    ekle.Parameters.AddWithValue("@camo", SqlDbType.Int).Value = cocukurunmiktar;
                    ekle.Parameters.AddWithValue("@cucode", SqlDbType.NVarChar).Value = cocukurunbirim;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    recetedetaydoldur();

                    cocukurunid = -1;
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

        private void button5_Click(object sender, EventArgs e)
        {
            //receteden urun sil
            if (bomdetailid != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM bom_detail WHERE id=@bdid", baglan);
                    sil.Parameters.AddWithValue("@bdid", SqlDbType.Int).Value = bomdetailid;
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    recetedetaydoldur();
                    bomdetailid = -1;
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki silmek istediğiniz urun detayına çift tıklatıp seçili hale getiriniz.");
            }
        }
    }
}
