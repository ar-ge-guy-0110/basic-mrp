using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BasicMRP
{
    public partial class urunler_kodlamasis : Form
    {
        SqlConnection baglan = cs_dbconnections.conn;
        //idler----------------------------------------------

        //takimlar icin idler
        int id;
        int idd;

        //mamuller icin idler
        int md;
        int mdd;

        //yarımamuller icin idler
        int yd;
        int ydd;

        //hammaddeler icin idler
        int hd;
        int hdd;

        //renkler icin id
        int rd;

        //----------------------------------------------------

        //panel salterleri------------------------------------
        
        //ana paneller salterleri
        bool takimpaneliacikmi = false;
        bool mamulpaneliacikmi = false;
        bool yarimamulpaneliacikmi = false;
        bool hammaddepaneliacikmi = false;
        bool renkkodlaripaneliacikmi = false;
        
        //yardimci panel salterleri
        bool takim1paneliacikmi = false;
        bool takim2paneliacikmi = false;
        bool takim3paneliacikmi = false;

        bool mamul1paneliacikmi = false;
        bool mamul2paneliacikmi = false;
        bool mamul3paneliacikmi = false;

        bool yarimamul1paneliacikmi = false;
        bool yarimamul2paneliacikmi = false;
        bool yarimamul3paneliacikmi = false;

        bool hammadde1paneliacikmi = false;
        bool hammadde2paneliacikmi = false;
        bool hammadde3paneliacikmi = false;

        //----------------------------------------------------

        public urunler_kodlamasis()
        {
            InitializeComponent();
        }

        private void urunler_kodlamasis_Load(object sender, EventArgs e)
        {

            /*
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODrenkler.akodrenkler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodrenklerTableAdapter.Fill(this.basicmrpdbDataSetAKODrenkler.akodrenkler);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODrenklerUP.akodrenkler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodrenklerTableAdapter1.Fill(this.basicmrpdbDataSetAKODrenklerUP.akodrenkler);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODrenkler.akodrenkler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodrenklerTableAdapter.Fill(this.basicmrpdbDataSetAKODrenkler.akodrenkler);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODhammadde3.akodhammadde3katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodhammadde3katmanTableAdapter.Fill(this.basicmrpdbDataSetAKODhammadde3.akodhammadde3katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSet4.akodhammadde2katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodhammadde2katmanTableAdapter.Fill(this.basicmrpdbDataSet4.akodhammadde2katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODhammadde1.akodhammadde1katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodhammadde1katmanTableAdapter.Fill(this.basicmrpdbDataSetAKODhammadde1.akodhammadde1katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSet3.akodyarimamul3katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodyarimamul3katmanTableAdapter.Fill(this.basicmrpdbDataSet3.akodyarimamul3katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODyarimamul2.akodyarimamul2katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodyarimamul2katmanTableAdapter.Fill(this.basicmrpdbDataSetAKODyarimamul2.akodyarimamul2katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODyarimamul1.akodyarimamul1katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodyarimamul1katmanTableAdapter.Fill(this.basicmrpdbDataSetAKODyarimamul1.akodyarimamul1katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODmamul3.akodmamul3katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodmamul3katmanTableAdapter.Fill(this.basicmrpdbDataSetAKODmamul3.akodmamul3katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKODmamul2.akodmamul2katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodmamul2katmanTableAdapter.Fill(this.basicmrpdbDataSetAKODmamul2.akodmamul2katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSet2.akodmamul1katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodmamul1katmanTableAdapter.Fill(this.basicmrpdbDataSet2.akodmamul1katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSet1.akodtakim3katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodtakim3katmanTableAdapter.Fill(this.basicmrpdbDataSet1.akodtakim3katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKOT2.akodtakim2katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodtakim2katmanTableAdapter.Fill(this.basicmrpdbDataSetAKOT2.akodtakim2katman);
            // TODO: Bu kod satırı 'basicmrpdbDataSetAKOT1.akodtakim1katman' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akodtakim1katmanTableAdapter.Fill(this.basicmrpdbDataSetAKOT1.akodtakim1katman);
            */

            listele1(); //takim1
            listele2(); //takim2
            listele3(); //takim3

            listele4(); //mamul1
            listele5(); //mamul2
            listele6(); //mamul3

            listele7(); //yarimamul1
            listele8(); //yarimamul2
            listele9(); //yarimamul3

            listele10(); //hammadde1
            listele11(); //hammadde2
            listele12(); //hammadde3

            listele13(); //renkler


            id = -1;
            idd = -1;
            
            md = -1;
            mdd = -1;

            yd = -1;
            ydd = -1;

            hd = -1;
            hdd = -1;

            rd = -1;
        }

        private void urunler_kodlamasis_FormClosed(object sender, FormClosedEventArgs e)
        {
            urunler mainwin = (urunler)Application.OpenForms["urunler"];
            if (mainwin != null)
            {
                mainwin.smcwin_opened = false;
            }
        }

        private void takimButton1_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                try
                {
                    /*
                    int newid = 1;
                    DataTable lookids = new DataTable();
                    string lookidssql = "SELECT TOP 1 id FROM akodtakim1katman ORDER BY id DESC";
                    SqlDataAdapter lookidda = new SqlDataAdapter(lookidssql, baglan);
                    */
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodtakim1katman(tbkid, birinci_katman_adi) VALUES(@tbkid, @tk)", baglan);
                    ekle.Parameters.AddWithValue("@tbkid", SqlDbType.Int).Value = Convert.ToInt32(takimMaskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takimMaskedTextBox2.Text;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele1();
                    //id = -1;
                    if (takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takimMaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void listele1()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodtakim1katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodtakim1katman");
            takimDataGridView1.DataSource = ds;
            takimDataGridView1.DataMember = "akodtakim1katman";
        }

        private void takimMaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
            {
                id = Convert.ToInt32(takimMaskedTextBox1.Text);
            }
        }

        private void takimButton2_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodtakim1katman WHERE tbkid=@tid", baglan);
                    sil.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takimMaskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele1();
                    //id = -1;
                    if (takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takimMaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //takim paneli
            if(takimpaneliacikmi != true)
            {
                takimpaneliacikmi = true;
                panel1.Visible = true;
            }
            else
            {
                takimpaneliacikmi = false;
                panel1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //mamul paneli
            if (mamulpaneliacikmi != true)
            {
                mamulpaneliacikmi = true;
                panel2.Visible = true;
            }
            else
            {
                mamulpaneliacikmi = false;
                panel2.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //yarımamül paneli
            if (yarimamulpaneliacikmi != true)
            {
                yarimamulpaneliacikmi = true;
                panel3.Visible = true;
            }
            else
            {
                yarimamulpaneliacikmi = false;
                panel3.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //hammadde paneli
            if (hammaddepaneliacikmi != true)
            {
                hammaddepaneliacikmi = true;
                panel4.Visible = true;
            }
            else
            {
                hammaddepaneliacikmi = false;
                panel4.Visible = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            //renk kodları paneli
            if (renkkodlaripaneliacikmi != true)
            {
                renkkodlaripaneliacikmi = true;
                renkpanel1.Visible = true;
            }
            else
            {
                renkkodlaripaneliacikmi = false;
                renkpanel1.Visible = false;
            }

            if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
            {
                rd = Convert.ToInt32(renkmaskedTextBox1.Text);
                renktestlabel1.Text = "rd: " + rd;
            }
            else
            {
                rd = -1;
                renktestlabel1.Text = "rd: " + rd;
            }
        }


        private void takim1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (takim1paneliacikmi != true)
            {
                takim1paneliacikmi = true;
                takim1panel.Visible = true;
            }
            else
            {
                takim1paneliacikmi = false;
                takim1panel.Visible = false;
            }

            if (takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
            {
                id = Convert.ToInt32(takimMaskedTextBox1.Text);
            }
            else
            {
                id = -1;
            }
        }

        private void takimButton3_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodtakim1katman SET tbkid=@tid, birinci_katman_adi=@tk WHERE tbkid=@tid", baglan);
                    guncelle.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takimMaskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takimMaskedTextBox2.Text;
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele1();
                    //id = -1;
                    if (takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takimMaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void takimButton4_Click(object sender, EventArgs e)
        {
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodtakim1katman WHERE";
            
            if (takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tbkid = @tid";
            }

            if (takimMaskedTextBox2.Text != null && takimMaskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " birinci_katman_adi LIKE '%'+@tk+'%'";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (takimMaskedTextBox1.Text != null && takimMaskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takimMaskedTextBox1.Text);
            if (takimMaskedTextBox2.Text != null && takimMaskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takimMaskedTextBox2.Text;

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if(takimMaskedTextBox1.Text != "" || takimMaskedTextBox2.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodtakim1katman");
                takimDataGridView1.DataSource = ds;
                takimDataGridView1.DataMember = "akodtakim1katman";
            }
            else
            {
                listele1();
            }
        }

        private void takimDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //takim 1 tiklagetir
            try
            {
                id = Convert.ToInt32(takimDataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
            }

            takimMaskedTextBox1.Text = takimDataGridView1.CurrentRow.Cells[0].Value.ToString();
            takimMaskedTextBox2.Text = takimDataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        //takim 2ncil------------------------------------------------------------------

        private void takim2MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
            {
                id = Convert.ToInt32(takim2MaskedTextBox1.Text);
            }
        }

        private void takim2MaskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (takim2MaskedTextBox3.Text != null && takim2MaskedTextBox3.Text != "")
            {
                idd = Convert.ToInt32(takim2MaskedTextBox3.Text);
            }
        }

        private void takim2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (takim2paneliacikmi != true)
            {
                takim2paneliacikmi = true;
                takim2panel.Visible = true;
            }
            else
            {
                takim2paneliacikmi = false;
                takim2panel.Visible = false;
            }
            id = -1;
            idd = -1;

            if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
            {
                id = Convert.ToInt32(takim2MaskedTextBox1.Text);
            }
            else
            {
                id = -1;
            }

            if (takim2MaskedTextBox3.Text != null && takim2MaskedTextBox3.Text != "")
            {
                idd = Convert.ToInt32(takim2MaskedTextBox3.Text);
            }
            else
            {
                idd = -1;
            }
        }

        private void listele2()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodtakim2katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodtakim2katman");
            takim2DataGridView1.DataSource = ds;
            takim2DataGridView1.DataMember = "akodtakim2katman";
        }

        private void takim2Button1_Click(object sender, EventArgs e)
        {
            //ekle takim 2
            if (id != -1 && idd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodtakim2katman(tbkid, ikinci_katman_adi, bagil_ustkatmanid) VALUES(@tbkid, @tk, @idd)", baglan);
                    ekle.Parameters.AddWithValue("@tbkid", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takim2MaskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@idd", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele2();
                    //id = -1;
                    if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takim2MaskedTextBox1.Text);
                        takim2controllabel1.Text = "id: " + id;
                    }

                    if (takim2MaskedTextBox3.Text != null && takim2MaskedTextBox3.Text != "")
                    {
                        idd = Convert.ToInt32(takim2MaskedTextBox3.Text);
                        takim2controllabel2.Text = "idd: " + idd;
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void takim2Button2_Click(object sender, EventArgs e)
        {
            // sil takim 2
            if (id != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodtakim2katman WHERE tbkid=@tid", baglan);
                    sil.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele2();
                    //id = -1;
                    if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takim2MaskedTextBox1.Text);
                    }

                    takim2controllabel1.Text = "id: " + id;
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    baglan.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void takim2Button3_Click(object sender, EventArgs e)
        {
            //takim 2 guncelle
            if (id != -1 && idd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodtakim2katman SET tbkid=@tid, ikinci_katman_adi=@tk, bagil_ustkatmanid=@idd WHERE tbkid=@tid", baglan);
                    guncelle.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takim2MaskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@idd", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele2();
                    //id = -1;
                    if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takim2MaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void takim2Button4_Click(object sender, EventArgs e)
        {
            //takim 2 ara

            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodtakim2katman WHERE";

            if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tbkid = @tid";
            }

            if (takim2MaskedTextBox2.Text != null && takim2MaskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ikinci_katman_adi LIKE '%'+@tk+'%'";
            }

            if (takim2MaskedTextBox3.Text != null && takim2MaskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @idd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (takim2MaskedTextBox1.Text != null && takim2MaskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox1.Text);
            if (takim2MaskedTextBox2.Text != null && takim2MaskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takim2MaskedTextBox2.Text;
            if (takim2MaskedTextBox3.Text != null && takim2MaskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@idd", SqlDbType.Int).Value = Convert.ToInt32(takim2MaskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (takim2MaskedTextBox1.Text != "" || takim2MaskedTextBox2.Text != "" || takim2MaskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodtakim2katman");
                takim2DataGridView1.DataSource = ds;
                takim2DataGridView1.DataMember = "akodtakim2katman";
            }
            else
            {
                listele2();
            }
        }

        private void takim2DataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            //takim2 tiklagetir
            try
            {
                id = Convert.ToInt32(takim2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                idd = Convert.ToInt32(takim2DataGridView1.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
                idd = -1;
            }

            takim2MaskedTextBox1.Text = takim2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            takim2MaskedTextBox2.Text = takim2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            takim2MaskedTextBox3.Text = takim2DataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        //takim 3ncil------------------------------------------------------------------
        private void takim3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //paneli acma
            if (takim3paneliacikmi != true)
            {
                takim3paneliacikmi = true;
                takimPanel3.Visible = true;
            }
            else
            {
                takim3paneliacikmi = false;
                takimPanel3.Visible = false;
            }

            if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
            {
                id = Convert.ToInt32(takim3MaskedTextBox1.Text);
                takim3testlabel.Text = "id: " + id;
            }
            else
            {
                id = -1;
            }

            if (takim3MaskedTextBox3.Text != null && takim3MaskedTextBox3.Text != "")
            {
                idd = Convert.ToInt32(takim3MaskedTextBox3.Text);
                takim3testlabel2.Text = "idd: " + idd;
            }
            else
            {
                idd = -1;
            }
        }

        private void takim3MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //id degistir goster
            if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
            {
                id = Convert.ToInt32(takim3MaskedTextBox1.Text);
                takim3testlabel.Text = "id: " + id;
            }
        }

        private void takim3MaskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //idd degistir goster
            if (takim3MaskedTextBox3.Text != null && takim3MaskedTextBox3.Text != "")
            {
                idd = Convert.ToInt32(takim3MaskedTextBox3.Text);
                takim3testlabel2.Text = "idd: " + idd;
            }
        }

        private void listele3()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodtakim3katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodtakim3katman");
            takim3dataGridView.DataSource = ds;
            takim3dataGridView.DataMember = "akodtakim3katman";
        }

        private void takim3Button1_Click(object sender, EventArgs e)
        {
            //takim3 ekle
            if (id != -1 && idd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodtakim3katman(tbkid, ucuncu_katman_adi, bagil_ustkatmanid) VALUES(@tbkid, @tk, @idd)", baglan);
                    ekle.Parameters.AddWithValue("@tbkid", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takim3MaskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@idd", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele3();
                    //id = -1;
                    if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takim3MaskedTextBox1.Text);
                    }

                    if (takim3MaskedTextBox3.Text != null && takim3MaskedTextBox3.Text != "")
                    {
                        idd = Convert.ToInt32(takim3MaskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void takim3Button2_Click(object sender, EventArgs e)
        {
            //takim3 sil
            if (id != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodtakim3katman WHERE tbkid=@tid", baglan);
                    sil.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele3();
                    //id = -1;
                    if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takim3MaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void takim3Button3_Click(object sender, EventArgs e)
        {
            //takim3 guncelle
            if (id != -1 && idd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodtakim3katman SET tbkid=@tid, ucuncu_katman_adi=@tk, bagil_ustkatmanid=@idd WHERE tbkid=@tid", baglan);
                    guncelle.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takim3MaskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@idd", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele3();
                    //id = -1;
                    if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
                    {
                        id = Convert.ToInt32(takim3MaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void takim3Button4_Click(object sender, EventArgs e)
        {
            //takım3 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodtakim3katman WHERE";

            if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tbkid = @tid";
            }

            if (takim3MaskedTextBox2.Text != null && takim3MaskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ucuncu_katman_adi LIKE '%'+@tk+'%'";
            }

            if (takim3MaskedTextBox3.Text != null && takim3MaskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @idd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (takim3MaskedTextBox1.Text != null && takim3MaskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox1.Text);
            if (takim3MaskedTextBox2.Text != null && takim3MaskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@tk", SqlDbType.NVarChar).Value = takim3MaskedTextBox2.Text;
            if (takim3MaskedTextBox3.Text != null && takim3MaskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@idd", SqlDbType.Int).Value = Convert.ToInt32(takim3MaskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (takim3MaskedTextBox1.Text != "" || takim3MaskedTextBox2.Text != "" || takim3MaskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodtakim3katman");
                takim3dataGridView.DataSource = ds;
                takim3dataGridView.DataMember = "akodtakim3katman";
            }
            else
            {
                listele3();
            }
        }

        private void takim3dataGridView_DoubleClick(object sender, EventArgs e)
        {
            //takim3 kolonatiklagetir
            try
            {
                id = Convert.ToInt32(takim3dataGridView.CurrentRow.Cells[0].Value.ToString());
                idd = Convert.ToInt32(takim3dataGridView.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
                idd = -1;
            }

            takim3MaskedTextBox1.Text = takim3dataGridView.CurrentRow.Cells[0].Value.ToString();
            takim3MaskedTextBox2.Text = takim3dataGridView.CurrentRow.Cells[1].Value.ToString();
            takim3MaskedTextBox3.Text = takim3dataGridView.CurrentRow.Cells[2].Value.ToString();
        }

        //Mamuller Bolumu--------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------

        //mamul 1----------------------------------------------------------------------------------------------------------------
        private void mamulradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //mamul1 paneli ac
            if (mamul1paneliacikmi != true)
            {
                mamul1paneliacikmi = true;
                mamulpanel1.Visible = true;
            }
            else
            {
                mamul1paneliacikmi = false;
                mamulpanel1.Visible = false;
            }

            if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
            {
                md = Convert.ToInt32(mamul1maskedTextBox1.Text);
                mamul1testlabel.Text = "md: " + md;
            }
            else
            {
                md = -1;
            }
        }

        private void mamul1maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //md degistir goster
            if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
            {
                md = Convert.ToInt32(mamul1maskedTextBox1.Text);
                mamul1testlabel.Text = "md: " + md;
            }
        }

        private void listele4()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodmamul1katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodmamul1katman");
            mamuldataGridView1.DataSource = ds;
            mamuldataGridView1.DataMember = "akodmamul1katman";
        }

        private void mamul1button1_Click(object sender, EventArgs e)
        {
            //ekle
            if (md != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodmamul1katman(mbkid, birinci_katman_adi) VALUES(@mbkid, @mk)", baglan);
                    ekle.Parameters.AddWithValue("@mbkid", SqlDbType.Int).Value = Convert.ToInt32(mamul1maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul1maskedTextBox2.Text;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele4();
                    //md = -1;
                    if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void mamul1button2_Click(object sender, EventArgs e)
        {
            //sil
            if (md != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodmamul1katman WHERE mbkid=@mid", baglan);
                    sil.Parameters.AddWithValue("@mid", SqlDbType.Int).Value = Convert.ToInt32(mamul1maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele4();
                    //id = -1;
                    if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void mamul1button3_Click(object sender, EventArgs e)
        {
            //guncelle
            if (md != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodmamul1katman SET mbkid=@mid, birinci_katman_adi=@mk WHERE mbkid=@mid", baglan);
                    guncelle.Parameters.AddWithValue("@mid", SqlDbType.Int).Value = Convert.ToInt32(mamul1maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul1maskedTextBox2.Text;
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele4();
                    //id = -1;
                    if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void mamul1button4_Click(object sender, EventArgs e)
        {
            //ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodmamul1katman WHERE";

            if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " mbkid = @mid";
            }

            if (mamul1maskedTextBox2.Text != null && mamul1maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " birinci_katman_adi LIKE '%'+@mk+'%'";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (mamul1maskedTextBox1.Text != null && mamul1maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@mid", SqlDbType.Int).Value = Convert.ToInt32(mamul1maskedTextBox1.Text);
            if (mamul1maskedTextBox2.Text != null && mamul1maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul1maskedTextBox2.Text;

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (mamul1maskedTextBox1.Text != "" || mamul1maskedTextBox2.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodmamul1katman");
                mamuldataGridView1.DataSource = ds;
                mamuldataGridView1.DataMember = "akodmamul1katman";
            }
            else
            {
                listele4();
            }
        }

        private void mamuldataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                md = Convert.ToInt32(mamuldataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                md = -1;
            }

            mamul1maskedTextBox1.Text = mamuldataGridView1.CurrentRow.Cells[0].Value.ToString();
            mamul1maskedTextBox2.Text = mamuldataGridView1.CurrentRow.Cells[1].Value.ToString();
        }



        //mamul 2----------------------------------------------------------------------------------------------------------------

        private void mamulradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //mamul2 paneli ac
            if (mamul2paneliacikmi != true)
            {
                mamul2paneliacikmi = true;
                mamulpanel2.Visible = true;
            }
            else
            {
                mamul2paneliacikmi = false;
                mamulpanel2.Visible = false;
            }

            if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
            {
                md = Convert.ToInt32(mamul2maskedTextBox1.Text);
                mamul2testlabel1.Text = "md: " + md;
            }
            else
            {
                md = -1;
            }

            if (mamul2maskedTextBox3.Text != null && mamul2maskedTextBox3.Text != "")
            {
                mdd = Convert.ToInt32(mamul2maskedTextBox3.Text);
                mamul2testlabel2.Text = "mdd: " + mdd;
            }
            else
            {
                mdd = -1;
            }
        }

        private void mamul2maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //md degistir goster
            if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
            {
                md = Convert.ToInt32(mamul2maskedTextBox1.Text);
                mamul2testlabel1.Text = "md: " + md;
            }
        }

        private void mamul2maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //mdd degistir goster
            if (mamul2maskedTextBox3.Text != null && mamul2maskedTextBox3.Text != "")
            {
                mdd = Convert.ToInt32(mamul2maskedTextBox3.Text);
                mamul2testlabel2.Text = "mdd: " + mdd;
            }
        }

        private void listele5()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodmamul2katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodmamul2katman");
            mamuldataGridView2.DataSource = ds;
            mamuldataGridView2.DataMember = "akodmamul2katman";
        }

        private void mamul2button1_Click(object sender, EventArgs e)
        {
            //ekle
            if (md != -1 && mdd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodmamul2katman(mbkid, ikinci_katman_adi, bagil_ustkatmanid) VALUES(@mbkid, @mk, @mdd)", baglan);
                    ekle.Parameters.AddWithValue("@mbkid", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul2maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@mdd", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele5();
                    //md = -1;
                    if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul2maskedTextBox1.Text);
                    }

                    if (mamul2maskedTextBox3.Text != null && mamul2maskedTextBox3.Text != "")
                    {
                        mdd = Convert.ToInt32(mamul2maskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void mamul2button2_Click(object sender, EventArgs e)
        {
            //sil
            if (md != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodmamul2katman WHERE mbkid=@md", baglan);
                    sil.Parameters.AddWithValue("@md", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele5();
                    //id = -1;
                    if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul2maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void mamul2button3_Click(object sender, EventArgs e)
        {
            //güncelle
            if (md != -1 && mdd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodmamul2katman SET mbkid=@md, ikinci_katman_adi=@mk, bagil_ustkatmanid=@mdd WHERE mbkid=@md", baglan);
                    guncelle.Parameters.AddWithValue("@md", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul2maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@mdd", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele5();
                    //id = -1;
                    if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul2maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void mamul2button4_Click(object sender, EventArgs e)
        {
            //ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodmamul2katman WHERE";

            if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " mbkid = @mid";
            }

            if (mamul2maskedTextBox2.Text != null && mamul2maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ikinci_katman_adi LIKE '%'+@mk+'%'";
            }

            if (mamul2maskedTextBox3.Text != null && mamul2maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @mdd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (mamul2maskedTextBox1.Text != null && mamul2maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@mid", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox1.Text);
            if (mamul2maskedTextBox2.Text != null && mamul2maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul2maskedTextBox2.Text;
            if (mamul2maskedTextBox3.Text != null && mamul2maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@mdd", SqlDbType.Int).Value = Convert.ToInt32(mamul2maskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (mamul2maskedTextBox1.Text != "" || mamul2maskedTextBox2.Text != "" || mamul2maskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodmamul2katman");
                mamuldataGridView2.DataSource = ds;
                mamuldataGridView2.DataMember = "akodmamul2katman";
            }
            else
            {
                listele5();
            }
        }

        private void mamuldataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                md = Convert.ToInt32(mamuldataGridView2.CurrentRow.Cells[0].Value.ToString());
                mdd = Convert.ToInt32(mamuldataGridView2.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                md = -1;
                mdd = -1;
            }

            mamul2maskedTextBox1.Text = mamuldataGridView2.CurrentRow.Cells[0].Value.ToString();
            mamul2maskedTextBox2.Text = mamuldataGridView2.CurrentRow.Cells[1].Value.ToString();
            mamul2maskedTextBox3.Text = mamuldataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        //mamul 3----------------------------------------------------------------------------------------------------------------

        private void mamulradioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //mamul3 panel aç
            if (mamul3paneliacikmi != true)
            {
                mamul3paneliacikmi = true;
                mamulpanel3.Visible = true;
            }
            else
            {
                mamul3paneliacikmi = false;
                mamulpanel3.Visible = false;
            }

            if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
            {
                md = Convert.ToInt32(mamul3maskedTextBox1.Text);
                mamul3testlabel1.Text = "md: " + md;
            }
            else
            {
                md = -1;
            }

            if (mamul3maskedTextBox3.Text != null && mamul3maskedTextBox3.Text != "")
            {
                mdd = Convert.ToInt32(mamul3maskedTextBox3.Text);
                mamul3testlabel2.Text = "mdd: " + mdd;
            }
            else
            {
                mdd = -1;
            }

        }

        private void mamul3maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //md degistir goster
            if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
            {
                md = Convert.ToInt32(mamul3maskedTextBox1.Text);
                mamul3testlabel1.Text = "md: " + md;
            }

            if(mamul3maskedTextBox1.Text == "")
            {
                md = -1;
                mamul3testlabel1.Text = "md: " + md;
            }
        }

        private void mamul3maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //mdd degistir goster
            if (mamul3maskedTextBox3.Text != null && mamul3maskedTextBox3.Text != "")
            {
                mdd = Convert.ToInt32(mamul3maskedTextBox3.Text);
                mamul3testlabel2.Text = "mdd: " + mdd;
            }

            if (mamul3maskedTextBox3.Text == "")
            {
                mdd = -1;
                mamul3testlabel2.Text = "mdd: " + md;
            }
        }

        private void listele6()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodmamul3katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodmamul3katman");
            mamuldataGridView3.DataSource = ds;
            mamuldataGridView3.DataMember = "akodmamul3katman";
        }

        private void mamul3button1_Click(object sender, EventArgs e)
        {
            //mamul3 ekle
            if (md != -1 && mdd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodmamul3katman(mbkid, ucuncu_katman_adi, bagil_ustkatmanid) VALUES(@mbkid, @mk, @mdd)", baglan);
                    ekle.Parameters.AddWithValue("@mbkid", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul3maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@mdd", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele6();
                    //md = -1;
                    if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul3maskedTextBox1.Text);
                    }

                    if (mamul3maskedTextBox3.Text != null && mamul3maskedTextBox3.Text != "")
                    {
                        mdd = Convert.ToInt32(mamul3maskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void mamul3button2_Click(object sender, EventArgs e)
        {
            //mamul3 sil
            if (md != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodmamul3katman WHERE mbkid=@md", baglan);
                    sil.Parameters.AddWithValue("@md", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele6();
                    //id = -1;
                    if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul3maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void mamul3button3_Click(object sender, EventArgs e)
        {
            //mamul3 guncelle
            if (md != -1 && mdd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodmamul3katman SET mbkid=@md, ucuncu_katman_adi=@mk, bagil_ustkatmanid=@mdd WHERE mbkid=@md", baglan);
                    guncelle.Parameters.AddWithValue("@md", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul3maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@mdd", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele6();
                    //id = -1;
                    if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
                    {
                        md = Convert.ToInt32(mamul3maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void mamul3button4_Click(object sender, EventArgs e)
        {
            //mamul3 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodmamul3katman WHERE";

            if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " mbkid = @mid";
            }

            if (mamul3maskedTextBox2.Text != null && mamul3maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ucuncu_katman_adi LIKE '%'+@mk+'%'";
            }

            if (mamul3maskedTextBox3.Text != null && mamul3maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 28)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @mdd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (mamul3maskedTextBox1.Text != null && mamul3maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@mid", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox1.Text);
            if (mamul3maskedTextBox2.Text != null && mamul3maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@mk", SqlDbType.NVarChar).Value = mamul3maskedTextBox2.Text;
            if (mamul3maskedTextBox3.Text != null && mamul3maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@mdd", SqlDbType.Int).Value = Convert.ToInt32(mamul3maskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (mamul3maskedTextBox1.Text != "" || mamul3maskedTextBox2.Text != "" || mamul3maskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodmamul3katman");
                mamuldataGridView3.DataSource = ds;
                mamuldataGridView3.DataMember = "akodmamul3katman";
            }
            else
            {
                listele6();
            }
        }

        private void mamuldataGridView3_DoubleClick(object sender, EventArgs e)
        {
            //mamul3 tiklagetir
            try
            {
                md = Convert.ToInt32(mamuldataGridView3.CurrentRow.Cells[0].Value.ToString());
                mdd = Convert.ToInt32(mamuldataGridView3.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                md = -1;
                mdd = -1;
            }

            mamul3maskedTextBox1.Text = mamuldataGridView3.CurrentRow.Cells[0].Value.ToString();
            mamul3maskedTextBox2.Text = mamuldataGridView3.CurrentRow.Cells[1].Value.ToString();
            mamul3maskedTextBox3.Text = mamuldataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        //Mamuller Bolumu--------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------

        //yarımamul 1----------------------------------------------------------------------------------------------------------------

        private void yarimamulradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //yarımamul 1 paneli ac
            if (yarimamul1paneliacikmi != true)
            {
                yarimamul1paneliacikmi = true;
                yarimamulpanel1.Visible = true;
            }
            else
            {
                yarimamul1paneliacikmi = false;
                yarimamulpanel1.Visible = false;
            }

            if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
            {
                yd = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
                yarimamul1testlabel1.Text = "yd: " + yd;
            }
            else
            {
                yd = -1;
                yarimamul1testlabel1.Text = "yd: " + yd;
            }
        }

        private void yarimamul1maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //yd degistir goster
            if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
            {
                yd = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
                yarimamul1testlabel1.Text = "yd: " + yd;
            }

            if (yarimamul1maskedTextBox1.Text == "")
            {
                yd = -1;
                yarimamul1testlabel1.Text = "yd: " + yd;
            }
        }

        private void listele7()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodyarimamul1katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodyarimamul1katman");
            yarimamuldataGridView1.DataSource = ds;
            yarimamuldataGridView1.DataMember = "akodyarimamul1katman";
        }

        private void yarimamul1button1_Click(object sender, EventArgs e)
        {
            //yarimamul1 ekle
            if (yd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodyarimamul1katman(ybkid, birinci_katman_adi) VALUES(@ybkid, @yk)", baglan);
                    ekle.Parameters.AddWithValue("@ybkid", SqlDbType.Int).Value = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul1maskedTextBox2.Text;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele7();
                    //yd = -1;
                    if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void yarimamul1button2_Click(object sender, EventArgs e)
        {
            //yarimamul1 sil
            if (yd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodyarimamul1katman WHERE ybkid=@yd", baglan);
                    sil.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele7();
                    //yd = -1;
                    if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void yarimamul1button3_Click(object sender, EventArgs e)
        {
            //yarimamul1 guncelle
            if (yd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodyarimamul1katman SET ybkid=@yd, birinci_katman_adi=@yk WHERE ybkid=@yd", baglan);
                    guncelle.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul1maskedTextBox2.Text;
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele7();
                    //yd = -1;
                    if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void yarimamul1button4_Click(object sender, EventArgs e)
        {
            //yarimamul1 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodyarimamul1katman WHERE";

            if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ybkid = @yd";
            }

            if (yarimamul1maskedTextBox2.Text != null && yarimamul1maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " birinci_katman_adi LIKE '%'+@yk+'%'";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (yarimamul1maskedTextBox1.Text != null && yarimamul1maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul1maskedTextBox1.Text);
            if (yarimamul1maskedTextBox2.Text != null && yarimamul1maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul1maskedTextBox2.Text;

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (yarimamul1maskedTextBox1.Text != "" || yarimamul1maskedTextBox2.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodyarimamul1katman");
                yarimamuldataGridView1.DataSource = ds;
                yarimamuldataGridView1.DataMember = "akodyarimamul1katman";
            }
            else
            {
                listele7();
            }
        }

        private void yarimamuldataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //yarimamul1 tiklagetir
            try
            {
                yd = Convert.ToInt32(yarimamuldataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                yd = -1;
            }

            yarimamul1maskedTextBox1.Text = yarimamuldataGridView1.CurrentRow.Cells[0].Value.ToString();
            yarimamul1maskedTextBox2.Text = yarimamuldataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        //yarımamul 2----------------------------------------------------------------------------------------------------------------

        private void yarimamulradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //yarımamul 2 paneli ac
            if (yarimamul2paneliacikmi != true)
            {
                yarimamul2paneliacikmi = true;
                yarimamulpanel2.Visible = true;
            }
            else
            {
                yarimamul2paneliacikmi = false;
                yarimamulpanel2.Visible = false;
            }

            if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
            {
                yd = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
                yarimamul2testlabel1.Text = "yd: " + yd;
            }
            else
            {
                yd = -1;
                yarimamul2testlabel1.Text = "yd: " + yd;
            }

            if (yarimamul2maskedTextBox3.Text != null && yarimamul2maskedTextBox3.Text != "")
            {
                ydd = Convert.ToInt32(yarimamul2maskedTextBox3.Text);
                yarimamul2testlabel2.Text = "ydd: " + ydd;
            }
            else
            {
                ydd = -1;
                yarimamul2testlabel2.Text = "ydd: " + ydd;
            }
        }

        private void yarimamul2maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //yd degistir goster
            if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
            {
                yd = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
                yarimamul2testlabel1.Text = "yd: " + yd;
            }

            if (yarimamul2maskedTextBox1.Text == "")
            {
                yd = -1;
                yarimamul2testlabel1.Text = "yd: " + yd;
            }
        }

        private void yarimamul2maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //ydd degistir goster
            if (yarimamul2maskedTextBox3.Text != null && yarimamul2maskedTextBox3.Text != "")
            {
                ydd = Convert.ToInt32(yarimamul2maskedTextBox3.Text);
                yarimamul2testlabel2.Text = "ydd: " + ydd;
            }

            if (yarimamul2maskedTextBox3.Text == "")
            {
                ydd = -1;
                yarimamul2testlabel2.Text = "ydd: " + ydd;
            }
        }

        private void listele8()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodyarimamul2katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodyarimamul2katman");
            yarimamuldataGridView2.DataSource = ds;
            yarimamuldataGridView2.DataMember = "akodyarimamul2katman";
        }

        private void yarimamul2button1_Click(object sender, EventArgs e)
        {
            //yarimamul2 ekle
            if (yd != -1 && ydd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodyarimamul2katman(ybkid, ikinci_katman_adi, bagil_ustkatmanid) VALUES(@ybkid, @yk, @ydd)", baglan);
                    ekle.Parameters.AddWithValue("@ybkid", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul2maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@ydd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele8();
                    //yd = -1;
                    if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
                    }

                    if (yarimamul2maskedTextBox3.Text != null && yarimamul2maskedTextBox3.Text != "")
                    {
                        ydd = Convert.ToInt32(yarimamul2maskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void yarimamul2button2_Click(object sender, EventArgs e)
        {
            //yarimamul2 sil
            if (yd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodyarimamul2katman WHERE ybkid=@yd", baglan);
                    sil.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele8();
                    //yd = -1;
                    if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void yarimamul2button3_Click(object sender, EventArgs e)
        {
            //yarimamul2 güncelle
            if (yd != -1 && ydd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodyarimamul2katman SET ybkid=@yd, ikinci_katman_adi=@yk, bagil_ustkatmanid=@ydd WHERE ybkid=@yd", baglan);
                    guncelle.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul2maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@ydd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele8();
                    //yd = -1;
                    if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void yarimamul2button4_Click(object sender, EventArgs e)
        {
            //yarimamul2 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodyarimamul2katman WHERE";

            if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ybkid = @yd";
            }

            if (yarimamul2maskedTextBox2.Text != null && yarimamul2maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ikinci_katman_adi LIKE '%'+@yk+'%'";
            }

            if (yarimamul2maskedTextBox3.Text != null && yarimamul2maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @ydd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (yarimamul2maskedTextBox1.Text != null && yarimamul2maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox1.Text);
            if (yarimamul2maskedTextBox2.Text != null && yarimamul2maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul2maskedTextBox2.Text;
            if (yarimamul2maskedTextBox3.Text != null && yarimamul2maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@ydd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul2maskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (yarimamul2maskedTextBox1.Text != "" || yarimamul2maskedTextBox2.Text != "" || yarimamul2maskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodyarimamul2katman");
                yarimamuldataGridView2.DataSource = ds;
                yarimamuldataGridView2.DataMember = "akodyarimamul2katman";
            }
            else
            {
                listele8();
            }
        }

        private void yarimamuldataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //yarimamul2 tiklagetir
            try
            {
                yd = Convert.ToInt32(yarimamuldataGridView2.CurrentRow.Cells[0].Value.ToString());
                ydd = Convert.ToInt32(yarimamuldataGridView2.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                yd = -1;
                ydd = -1;
            }

            yarimamul2maskedTextBox1.Text = yarimamuldataGridView2.CurrentRow.Cells[0].Value.ToString();
            yarimamul2maskedTextBox2.Text = yarimamuldataGridView2.CurrentRow.Cells[1].Value.ToString();
            yarimamul2maskedTextBox3.Text = yarimamuldataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        //yarımamul 3----------------------------------------------------------------------------------------------------------------

        private void yarimamulradioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //yarımamul 3 paneli ac
            if (yarimamul3paneliacikmi != true)
            {
                yarimamul3paneliacikmi = true;
                yarimamulpanel3.Visible = true;
            }
            else
            {
                yarimamul3paneliacikmi = false;
                yarimamulpanel3.Visible = false;
            }

            if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
            {
                yd = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
                yarimamul3testlabel1.Text = "yd: " + yd;
            }
            else
            {
                yd = -1;
                yarimamul3testlabel1.Text = "yd: " + yd;
            }

            if (yarimamul3maskedTextBox3.Text != null && yarimamul3maskedTextBox3.Text != "")
            {
                ydd = Convert.ToInt32(yarimamul3maskedTextBox3.Text);
                yarimamul3testlabel2.Text = "ydd: " + ydd;
            }
            else
            {
                ydd = -1;
                yarimamul3testlabel2.Text = "ydd: " + ydd;
            }
        }

        private void yarimamul3maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //yd degistir goster
            if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
            {
                yd = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
                yarimamul3testlabel1.Text = "yd: " + yd;
            }

            if (yarimamul3maskedTextBox1.Text == "")
            {
                yd = -1;
                yarimamul3testlabel1.Text = "yd: " + yd;
            }
        }

        private void yarimamul3maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //ydd degistir goster
            if (yarimamul3maskedTextBox3.Text != null && yarimamul3maskedTextBox3.Text != "")
            {
                ydd = Convert.ToInt32(yarimamul3maskedTextBox3.Text);
                yarimamul3testlabel2.Text = "ydd: " + ydd;
            }

            if (yarimamul3maskedTextBox3.Text == "")
            {
                ydd = -1;
                yarimamul3testlabel2.Text = "ydd: " + yd;
            }
        }

        private void listele9()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodyarimamul3katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodyarimamul3katman");
            yarimamuldataGridView3.DataSource = ds;
            yarimamuldataGridView3.DataMember = "akodyarimamul3katman";
        }

        private void yarimamul3button1_Click(object sender, EventArgs e)
        {
            //yarimamul3 ekle
            if (yd != -1 && ydd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodyarimamul3katman(ybkid, ucuncu_katman_adi, bagil_ustkatmanid) VALUES(@ybkid, @yk, @ydd)", baglan);
                    ekle.Parameters.AddWithValue("@ybkid", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul3maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@ydd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele9();
                    //yd = -1;
                    if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
                    }

                    if (yarimamul3maskedTextBox3.Text != null && yarimamul3maskedTextBox3.Text != "")
                    {
                        ydd = Convert.ToInt32(yarimamul3maskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void yarimamul3button2_Click(object sender, EventArgs e)
        {
            //yarimamul3 sil
            if (yd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodyarimamul3katman WHERE ybkid=@yd", baglan);
                    sil.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele9();
                    //yd = -1;
                    if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void yarimamul3button3_Click(object sender, EventArgs e)
        {
            //yarimamul3 güncelle
            if (yd != -1 && ydd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodyarimamul3katman SET ybkid=@yd, ucuncu_katman_adi=@yk, bagil_ustkatmanid=@ydd WHERE ybkid=@yd", baglan);
                    guncelle.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul3maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@ydd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele9();
                    //yd = -1;
                    if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
                    {
                        yd = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void yarimamul3button4_Click(object sender, EventArgs e)
        {
            //yarimamul3 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodyarimamul3katman WHERE";

            if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ybkid = @yd";
            }

            if (yarimamul3maskedTextBox2.Text != null && yarimamul3maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ucuncu_katman_adi LIKE '%'+@yk+'%'";
            }

            if (yarimamul3maskedTextBox3.Text != null && yarimamul3maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 32)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @ydd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (yarimamul3maskedTextBox1.Text != null && yarimamul3maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@yd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox1.Text);
            if (yarimamul3maskedTextBox2.Text != null && yarimamul3maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@yk", SqlDbType.NVarChar).Value = yarimamul3maskedTextBox2.Text;
            if (yarimamul3maskedTextBox3.Text != null && yarimamul3maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@ydd", SqlDbType.Int).Value = Convert.ToInt32(yarimamul3maskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (yarimamul3maskedTextBox1.Text != "" || yarimamul3maskedTextBox2.Text != "" || yarimamul3maskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodyarimamul3katman");
                yarimamuldataGridView3.DataSource = ds;
                yarimamuldataGridView3.DataMember = "akodyarimamul3katman";
            }
            else
            {
                listele9();
            }
        }

        private void yarimamuldataGridView3_DoubleClick(object sender, EventArgs e)
        {
            //yarimamul3 tiklagetir
            try
            {
                yd = Convert.ToInt32(yarimamuldataGridView3.CurrentRow.Cells[0].Value.ToString());
                ydd = Convert.ToInt32(yarimamuldataGridView3.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                yd = -1;
                ydd = -1;
            }

            yarimamul3maskedTextBox1.Text = yarimamuldataGridView3.CurrentRow.Cells[0].Value.ToString();
            yarimamul3maskedTextBox2.Text = yarimamuldataGridView3.CurrentRow.Cells[1].Value.ToString();
            yarimamul3maskedTextBox3.Text = yarimamuldataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        //Hammaddeler Bolumu--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------

        //hammadde 1----------------------------------------------------------------------------------------------------------------

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            //hammadde 1 paneli ac
            if (hammadde1paneliacikmi != true)
            {
                hammadde1paneliacikmi = true;
                hammaddepanel1.Visible = true;
            }
            else
            {
                hammadde1paneliacikmi = false;
                hammaddepanel1.Visible = false;
            }

            if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
            {
                hd = Convert.ToInt32(hammadde1maskedTextBox1.Text);
                hammadde1testlabel1.Text = "hd: " + hd;
            }
            else
            {
                hd = -1;
                hammadde1testlabel1.Text = "hd: " + hd;
            }
        }

        private void hammadde1maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //hd degistir goster
            if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
            {
                hd = Convert.ToInt32(hammadde1maskedTextBox1.Text);
                hammadde1testlabel1.Text = "hd: " + hd;
            }

            if (hammadde1maskedTextBox1.Text == "")
            {
                hd = -1;
                hammadde1testlabel1.Text = "hd: " + hd;
            }
        }

        private void listele10()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodhammadde1katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodhammadde1katman");
            hammaddedataGridView1.DataSource = ds;
            hammaddedataGridView1.DataMember = "akodhammadde1katman";
        }

        private void hammadde1button1_Click(object sender, EventArgs e)
        {
            //hammadde 1 ekle
            if (hd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodhammadde1katman(hbkid, birinci_katman_adi) VALUES(@hbkid, @hk)", baglan);
                    ekle.Parameters.AddWithValue("@hbkid", SqlDbType.Int).Value = Convert.ToInt32(hammadde1maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde1maskedTextBox2.Text;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele10();
                    //hd = -1;
                    if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void hammadde1button2_Click(object sender, EventArgs e)
        {
            //hammadde 1 sil
            if (hd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodhammadde1katman WHERE hbkid=@hd", baglan);
                    sil.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde1maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele10();
                    //hd = -1;
                    if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void hammadde1button3_Click(object sender, EventArgs e)
        {
            //hammadde 1 güncelle
            if (hd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodhammadde1katman SET hbkid=@hd, birinci_katman_adi=@hk WHERE hbkid=@hd", baglan);
                    guncelle.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde1maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde1maskedTextBox2.Text;
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele10();
                    //hd = -1;
                    if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde1maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void hammadde1button4_Click(object sender, EventArgs e)
        {
            //hammadde 1 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodhammadde1katman WHERE";

            if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " hbkid = @hd";
            }

            if (hammadde1maskedTextBox2.Text != null && hammadde1maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " birinci_katman_adi LIKE '%'+@hk+'%'";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (hammadde1maskedTextBox1.Text != null && hammadde1maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde1maskedTextBox1.Text);
            if (hammadde1maskedTextBox2.Text != null && hammadde1maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde1maskedTextBox2.Text;

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (hammadde1maskedTextBox1.Text != "" || hammadde1maskedTextBox2.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodhammadde1katman");
                hammaddedataGridView1.DataSource = ds;
                hammaddedataGridView1.DataMember = "akodhammadde1katman";
            }
            else
            {
                listele10();
            }
        }

        private void hammaddedataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //hammadde 1 tiklagetir
            try
            {
                hd = Convert.ToInt32(hammaddedataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                hd = -1;
            }

            hammadde1maskedTextBox1.Text = hammaddedataGridView1.CurrentRow.Cells[0].Value.ToString();
            hammadde1maskedTextBox2.Text = hammaddedataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        //hammadde 2----------------------------------------------------------------------------------------------------------------

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //hammadde 2 paneli ac
            if (hammadde2paneliacikmi != true)
            {
                hammadde2paneliacikmi = true;
                hammaddepanel2.Visible = true;
            }
            else
            {
                hammadde2paneliacikmi = false;
                hammaddepanel2.Visible = false;
            }

            if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
            {
                hd = Convert.ToInt32(hammadde2maskedTextBox1.Text);
                hammadde2testlabel1.Text = "hd: " + hd;
            }
            else
            {
                hd = -1;
                hammadde2testlabel1.Text = "hd: " + hd;
            }

            if (hammadde2maskedTextBox3.Text != null && hammadde2maskedTextBox3.Text != "")
            {
                hdd = Convert.ToInt32(hammadde2maskedTextBox3.Text);
                hammadde2testlabel2.Text = "hdd: " + hdd;
            }
            else
            {
                hdd = -1;
                hammadde2testlabel2.Text = "hdd: " + hdd;
            }
        }

        private void hammadde2maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //hd degistir goster
            if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
            {
                hd = Convert.ToInt32(hammadde2maskedTextBox1.Text);
                hammadde2testlabel1.Text = "hd: " + hd;
            }

            if (hammadde2maskedTextBox1.Text == "")
            {
                hd = -1;
                hammadde2testlabel1.Text = "hd: " + hd;
            }
        }

        private void hammadde2maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //hdd degistir goster
            if (hammadde2maskedTextBox3.Text != null && hammadde2maskedTextBox3.Text != "")
            {
                hdd = Convert.ToInt32(hammadde2maskedTextBox3.Text);
                hammadde2testlabel2.Text = "hdd: " + hdd;
            }

            if (hammadde2maskedTextBox3.Text == "")
            {
                hdd = -1;
                hammadde2testlabel2.Text = "hdd: " + hdd;
            }
        }

        private void listele11()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodhammadde2katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodhammadde2katman");
            hammaddedataGridView2.DataSource = ds;
            hammaddedataGridView2.DataMember = "akodhammadde2katman";
        }

        private void hammadde2button1_Click(object sender, EventArgs e)
        {
            //hammadde 2 ekle
            if (hd != -1 && hdd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodhammadde2katman(hbkid, ikinci_katman_adi, bagil_ustkatmanid) VALUES(@hbkid, @hk, @hdd)", baglan);
                    ekle.Parameters.AddWithValue("@hbkid", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde2maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@hdd", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele11();
                    //hd = -1;
                    if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde2maskedTextBox1.Text);
                    }

                    if (hammadde2maskedTextBox3.Text != null && hammadde2maskedTextBox3.Text != "")
                    {
                        hdd = Convert.ToInt32(hammadde2maskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void hammadde2button2_Click(object sender, EventArgs e)
        {
            //hammadde 2 sil
            if (hd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodhammadde2katman WHERE hbkid=@hd", baglan);
                    sil.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele11();
                    //hd = -1;
                    if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde2maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void hammadde2button3_Click(object sender, EventArgs e)
        {
            //hammadde 2 güncelle
            if (hd != -1 && hdd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodhammadde2katman SET hbkid=@hd, ikinci_katman_adi=@hk, bagil_ustkatmanid=@hdd WHERE hbkid=@hd", baglan);
                    guncelle.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde2maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@hdd", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele11();
                    //hd = -1;
                    if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde2maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void hammadde2button4_Click(object sender, EventArgs e)
        {
            //hammadde 2 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodhammadde2katman WHERE";

            if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " hbkid = @hd";
            }

            if (hammadde2maskedTextBox2.Text != null && hammadde2maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ikinci_katman_adi LIKE '%'+@hk+'%'";
            }

            if (hammadde2maskedTextBox3.Text != null && hammadde2maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @hdd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (hammadde2maskedTextBox1.Text != null && hammadde2maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox1.Text);
            if (hammadde2maskedTextBox2.Text != null && hammadde2maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde2maskedTextBox2.Text;
            if (hammadde2maskedTextBox3.Text != null && hammadde2maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@hdd", SqlDbType.Int).Value = Convert.ToInt32(hammadde2maskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (hammadde2maskedTextBox1.Text != "" || hammadde2maskedTextBox2.Text != "" || hammadde2maskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodhammadde2katman");
                hammaddedataGridView2.DataSource = ds;
                hammaddedataGridView2.DataMember = "akodhammadde2katman";
            }
            else
            {
                listele11();
            }
        }

        private void hammaddedataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //hammadde 2 tiklagetir
            try
            {
                hd = Convert.ToInt32(hammaddedataGridView2.CurrentRow.Cells[0].Value.ToString());
                hdd = Convert.ToInt32(hammaddedataGridView2.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                hd = -1;
                hdd = -1;
            }

            hammadde2maskedTextBox1.Text = hammaddedataGridView2.CurrentRow.Cells[0].Value.ToString();
            hammadde2maskedTextBox2.Text = hammaddedataGridView2.CurrentRow.Cells[1].Value.ToString();
            hammadde2maskedTextBox3.Text = hammaddedataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        //hammadde 3----------------------------------------------------------------------------------------------------------------

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //hammadde 3 paneli ac
            if (hammadde3paneliacikmi != true)
            {
                hammadde3paneliacikmi = true;
                hammaddepanel3.Visible = true;
            }
            else
            {
                hammadde3paneliacikmi = false;
                hammaddepanel3.Visible = false;
            }

            if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
            {
                hd = Convert.ToInt32(hammadde3maskedTextBox1.Text);
                hammadde3testlabel1.Text = "hd: " + hd;
            }
            else
            {
                hd = -1;
                hammadde3testlabel1.Text = "hd: " + hd;
            }

            if (hammadde3maskedTextBox3.Text != null && hammadde3maskedTextBox3.Text != "")
            {
                hdd = Convert.ToInt32(hammadde3maskedTextBox3.Text);
                hammadde3testlabel2.Text = "hdd: " + hdd;
            }
            else
            {
                hdd = -1;
                hammadde3testlabel2.Text = "hdd: " + hdd;
            }
        }

        private void hammadde3maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //hd degistir goster
            if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
            {
                hd = Convert.ToInt32(hammadde3maskedTextBox1.Text);
                hammadde3testlabel1.Text = "hd: " + hd;
            }

            if (hammadde3maskedTextBox1.Text == "")
            {
                hd = -1;
                hammadde3testlabel1.Text = "hd: " + hd;
            }
        }

        private void hammadde3maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            //hdd degistir goster
            if (hammadde3maskedTextBox3.Text != null && hammadde3maskedTextBox3.Text != "")
            {
                hdd = Convert.ToInt32(hammadde3maskedTextBox3.Text);
                hammadde3testlabel2.Text = "hdd: " + hdd;
            }

            if (hammadde3maskedTextBox3.Text == "")
            {
                hdd = -1;
                hammadde3testlabel2.Text = "hdd: " + hdd;
            }
        }

        private void listele12()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodhammadde3katman", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodhammadde3katman");
            hammaddedataGridView3.DataSource = ds;
            hammaddedataGridView3.DataMember = "akodhammadde3katman";
        }

        private void hammadde3button1_Click(object sender, EventArgs e)
        {
            //hammadde 3 ekle
            if (hd != -1 && hdd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodhammadde3katman(hbkid, ucuncu_katman_adi, bagil_ustkatmanid) VALUES(@hbkid, @hk, @hdd)", baglan);
                    ekle.Parameters.AddWithValue("@hbkid", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde3maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@hdd", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox3.Text);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele12();
                    //hd = -1;
                    if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde3maskedTextBox1.Text);
                    }

                    if (hammadde3maskedTextBox3.Text != null && hammadde3maskedTextBox3.Text != "")
                    {
                        hdd = Convert.ToInt32(hammadde3maskedTextBox3.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void hammadde3button2_Click(object sender, EventArgs e)
        {
            //hammadde 3 sil
            if (hd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodhammadde3katman WHERE hbkid=@hd", baglan);
                    sil.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele12();
                    //hd = -1;
                    if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde3maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void hammadde3button3_Click(object sender, EventArgs e)
        {
            //hammadde 3 guncelle
            if (hd != -1 && hdd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodhammadde3katman SET hbkid=@hd, ucuncu_katman_adi=@hk, bagil_ustkatmanid=@hdd WHERE hbkid=@hd", baglan);
                    guncelle.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde3maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@hdd", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox3.Text);
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele12();
                    //hd = -1;
                    if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
                    {
                        hd = Convert.ToInt32(hammadde3maskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void hammadde3button4_Click(object sender, EventArgs e)
        {
            //hammadde 3 ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodhammadde3katman WHERE";

            if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " hbkid = @hd";
            }

            if (hammadde3maskedTextBox2.Text != null && hammadde3maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " ucuncu_katman_adi LIKE '%'+@hk+'%'";
            }

            if (hammadde3maskedTextBox3.Text != null && hammadde3maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > 31)
                {
                    cmd_end += " AND";
                }
                cmd_end += " bagil_ustkatmanid = @hdd";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (hammadde3maskedTextBox1.Text != null && hammadde3maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@hd", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox1.Text);
            if (hammadde3maskedTextBox2.Text != null && hammadde3maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@hk", SqlDbType.NVarChar).Value = hammadde3maskedTextBox2.Text;
            if (hammadde3maskedTextBox3.Text != null && hammadde3maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@hdd", SqlDbType.Int).Value = Convert.ToInt32(hammadde3maskedTextBox3.Text);

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (hammadde3maskedTextBox1.Text != "" || hammadde3maskedTextBox2.Text != "" || hammadde3maskedTextBox3.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodhammadde3katman");
                hammaddedataGridView3.DataSource = ds;
                hammaddedataGridView3.DataMember = "akodhammadde3katman";
            }
            else
            {
                listele12();
            }
        }

        private void hammaddedataGridView3_DoubleClick(object sender, EventArgs e)
        {
            //hammadde 3 tiklagetir
            try
            {
                hd = Convert.ToInt32(hammaddedataGridView3.CurrentRow.Cells[0].Value.ToString());
                hdd = Convert.ToInt32(hammaddedataGridView3.CurrentRow.Cells[2].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                hd = -1;
                hdd = -1;
            }

            hammadde3maskedTextBox1.Text = hammaddedataGridView3.CurrentRow.Cells[0].Value.ToString();
            hammadde3maskedTextBox2.Text = hammaddedataGridView3.CurrentRow.Cells[1].Value.ToString();
            hammadde3maskedTextBox3.Text = hammaddedataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        //renkler----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------

        private void renkmaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //rd degistir goster
            if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
            {
                rd = Convert.ToInt32(renkmaskedTextBox1.Text);
                renktestlabel1.Text = "rd: " + rd;
            }

            if (renkmaskedTextBox1.Text == "")
            {
                rd = -1;
                renktestlabel1.Text = "rd: " + rd;
            }
        }

        private void listele13()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM akodrenkler", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "akodrenkler");
            renkdataGridView1.DataSource = ds;
            renkdataGridView1.DataMember = "akodrenkler";
        }

        private void renkbutton1_Click(object sender, EventArgs e)
        {
            //ekle
            if (rd != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO akodrenkler(rid, renk_adi) VALUES(@rd, @rk)", baglan);
                    ekle.Parameters.AddWithValue("@rd", SqlDbType.Int).Value = Convert.ToInt32(renkmaskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@rk", SqlDbType.NVarChar).Value = renkmaskedTextBox2.Text;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele13();
                    //rd = -1;
                    if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
                    {
                        rd = Convert.ToInt32(renkmaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void renkbutton2_Click(object sender, EventArgs e)
        {
            //sil
            if (rd != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM akodrenkler WHERE rid=@rd", baglan);
                    sil.Parameters.AddWithValue("@rd", SqlDbType.Int).Value = Convert.ToInt32(renkmaskedTextBox1.Text);
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele13();
                    //rd = -1;
                    if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
                    {
                        rd = Convert.ToInt32(renkmaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void renkbutton3_Click(object sender, EventArgs e)
        {
            //güncelle
            if (rd != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE akodrenkler SET rid=@rd, renk_adi=@rk WHERE rid=@rd", baglan);
                    guncelle.Parameters.AddWithValue("@rd", SqlDbType.Int).Value = Convert.ToInt32(renkmaskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@rk", SqlDbType.NVarChar).Value = renkmaskedTextBox2.Text;
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele13();
                    //rd = -1;
                    if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
                    {
                        rd = Convert.ToInt32(renkmaskedTextBox1.Text);
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
                MessageBox.Show("Lütfen bilgilerin eksiksiz girildiğine emin olunuz.");
            }
        }

        private void renkbutton4_Click(object sender, EventArgs e)
        {
            //ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM akodrenkler WHERE";

            if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
            {
                if (cmd_end.Length > 23)
                {
                    cmd_end += " AND";
                }
                cmd_end += " rid = @rd";
            }

            if (renkmaskedTextBox2.Text != null && renkmaskedTextBox2.Text != "")
            {
                if (cmd_end.Length > 23)
                {
                    cmd_end += " AND";
                }
                cmd_end += " renk_adi LIKE '%'+@rk+'%'";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (renkmaskedTextBox1.Text != null && renkmaskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@rd", SqlDbType.Int).Value = Convert.ToInt32(renkmaskedTextBox1.Text);
            if (renkmaskedTextBox2.Text != null && renkmaskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@rk", SqlDbType.NVarChar).Value = renkmaskedTextBox2.Text;

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (renkmaskedTextBox1.Text != "" || renkmaskedTextBox2.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "akodrenkler");
                renkdataGridView1.DataSource = ds;
                renkdataGridView1.DataMember = "akodrenkler";
            }
            else
            {
                listele13();
            }
        }

        private void renkdataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                rd = Convert.ToInt32(renkdataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                rd = -1;
            }

            renkmaskedTextBox1.Text = renkdataGridView1.CurrentRow.Cells[0].Value.ToString();
            renkmaskedTextBox2.Text = renkdataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
