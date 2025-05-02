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
    public partial class CALCULDEBUG : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        string customer_name = "";
        int customer_id;
        string searchsql = "";
        string orderitemssql = "";

        int sales_order_id;
        int sales_order_detail_id;
        #endregion

        #region critics
        public CALCULDEBUG()
        {
            InitializeComponent();
        }

        private void CALCULDEBUG_Load(object sender, EventArgs e)
        {

            /////////////////////////////////////////////////////////////////////////////////////////////////////////HAZIRLA
            conn.Open();
            SqlCommand debugtemizle = new SqlCommand("DELETE FROM CALCULDEBUG", conn);
            SqlCommand debugtemizleautoinc = new SqlCommand("DBCC CHECKIDENT('CALCULDEBUG', RESEED, 0)", conn);
            debugtemizle.ExecuteNonQuery();
            debugtemizleautoinc.ExecuteNonQuery();
            SqlCommand debugtemizle2 = new SqlCommand("DELETE FROM CALCULDEBUG_TEMP", conn);
            SqlCommand debugtemizle2autoinc = new SqlCommand("DBCC CHECKIDENT('CALCULDEBUG_TEMP', RESEED, 0)", conn);
            debugtemizle2.ExecuteNonQuery();
            debugtemizle2autoinc.ExecuteNonQuery();
            conn.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////HAZIRLA
            
            //musterileri doldur
            conn.Open();
            SqlCommand combodoldur1 = new SqlCommand("SELECT customername FROM customer", conn);
            SqlDataReader oku = combodoldur1.ExecuteReader();
            while (oku.Read())
            {
                cmbCustomer.Items.Add(oku["customername"]);
            }
            conn.Close();

            bull1();
            bull2();
            bull3();
            doldur();
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region funcs
        private void doldur()
        {

            DataTable dt = new DataTable();
            string sql = "SELECT customer.customername AS musteri_adi, CALCULDEBUG.orderdetailid AS siparis_parca_no, CALCULDEBUG.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, CALCULDEBUG.mainamount AS ana_urun_miktar, CALCULDEBUG.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, CALCULDEBUG.stock AS alt_urun_stok_miktar, CALCULDEBUG.requirement AS alt_urun_gereken_sonuc_miktar, CALCULDEBUG.supplytype AS alt_urun_tedarik_turu FROM CALCULDEBUG JOIN item ON item.id = CALCULDEBUG.mainitemid JOIN item AS item2 ON item2.id = CALCULDEBUG.childitemid JOIN sales_order_detail ON sales_order_detail.id = CALCULDEBUG.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void bull1()
        {
            //tüm ana siparişler için
            SqlCommand sales_ordersql = new SqlCommand("SELECT * FROM sales_order", conn);
            DataTable sales_orderdt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sales_ordersql);
            da.Fill(sales_orderdt);
            foreach (DataRow sales_orderRow in sales_orderdt.Rows)
            {
                //ana siparişlerin her birinin tüm alt siparişleri için
                SqlCommand sales_order_detailsql = new SqlCommand("SELECT * FROM sales_order_detail WHERE orderid = " + Convert.ToInt32(sales_orderRow[0]), conn);
                DataTable sales_order_detaildt = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(sales_order_detailsql);
                da2.Fill(sales_order_detaildt);
                foreach (DataRow sales_order_detailRow in sales_order_detaildt.Rows)
                {
                    //(her sales_order_detailde 1 ürün var)ürünün reçetesi için.
                    SqlCommand bomsql = new SqlCommand("SELECT * FROM bom WHERE itemid = " + Convert.ToInt32(sales_order_detailRow[2]), conn);
                    DataTable bomdt = new DataTable();
                    SqlDataAdapter da3 = new SqlDataAdapter(bomsql);
                    da3.Fill(bomdt);

                    //sipariş ürünün tüm parçaları için

                    SqlCommand bom_detailsql = new SqlCommand("SELECT * FROM bom_detail WHERE bomid = " + Convert.ToInt32(bomdt.Rows[0][0]), conn);
                    DataTable bom_detaildt = new DataTable();
                    SqlDataAdapter da4 = new SqlDataAdapter(bom_detailsql);
                    da4.Fill(bom_detaildt);
                    foreach (DataRow bom_detailRow in bom_detaildt.Rows)
                    {
                        try
                        {
                            SqlCommand mrpekle = new SqlCommand("INSERT INTO CALCULDEBUG(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                            "VALUES(CONVERT(date, @date_, 103), @orderdetailid, @bomid, @bomdetailid, @mainitemid, @childitemid, @mainamount, @childamount, @givenorderamount, @stock, @requirement, @supplytype)", conn);
                            mrpekle.Parameters.AddWithValue("@date_", SqlDbType.Date).Value = Convert.ToDateTime(sales_orderRow[2].ToString());
                            mrpekle.Parameters.AddWithValue("@orderdetailid", SqlDbType.Int).Value = Convert.ToInt32(sales_order_detailRow[0]);
                            mrpekle.Parameters.AddWithValue("@bomid", SqlDbType.Int).Value = Convert.ToInt32(bomdt.Rows[0][0]);
                            mrpekle.Parameters.AddWithValue("@bomdetailid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[0]);
                            mrpekle.Parameters.AddWithValue("@mainitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[2]);

                            mrpekle.Parameters.AddWithValue("@childitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[3]);
                            mrpekle.Parameters.AddWithValue("@mainamount", SqlDbType.Int).Value = Convert.ToInt32(sales_order_detailRow[3]);
                            mrpekle.Parameters.AddWithValue("@childamount", SqlDbType.Int).Value = Convert.ToInt32(sales_order_detailRow[3]) * Convert.ToInt32(bom_detailRow[6]);
                            mrpekle.Parameters.AddWithValue("@givenorderamount", SqlDbType.Int).Value = 0;

                            //parçanın stok durumu
                            SqlCommand stocksql = new SqlCommand("SELECT * FROM stock WHERE itemid = " + Convert.ToInt32(bom_detailRow[3]), conn);
                            DataTable stockdt = new DataTable();
                            SqlDataAdapter da5 = new SqlDataAdapter(stocksql);
                            da5.Fill(stockdt);

                            mrpekle.Parameters.AddWithValue("@stock", SqlDbType.Int).Value = Convert.ToInt32(stockdt.Rows[0][2]);

                            //gereken miktarı bul.
                            int stock = Convert.ToInt32(stockdt.Rows[0][2]);
                            int orderamo = Convert.ToInt32(sales_order_detailRow[3]) * Convert.ToInt32(bom_detailRow[6]);
                            int req;
                            if (stock < orderamo)
                            {
                                req = orderamo - stock;
                            }
                            else
                            {
                                req = 0;
                            }
                            mrpekle.Parameters.AddWithValue("@requirement", SqlDbType.Int).Value = req;

                            //tedarik durumunu belirle.
                            SqlCommand itemsql = new SqlCommand("SELECT * FROM item WHERE id = " + Convert.ToInt32(bom_detailRow[3]), conn);
                            DataTable itemdt = new DataTable();
                            SqlDataAdapter da6 = new SqlDataAdapter(itemsql);
                            da6.Fill(itemdt);
                            string supplyty;
                            if (itemdt.Rows[0][3].ToString() == "HM")
                            {
                                if (req == 0)
                                {
                                    supplyty = "Halihazırda Var";
                                }
                                else
                                {
                                    supplyty = "Sipariş";
                                }
                            }
                            else
                            {
                                if (req == 0)
                                {
                                    supplyty = "Halihazırda Var";
                                }
                                else
                                {
                                    supplyty = "Üretim";
                                }

                            }
                            mrpekle.Parameters.AddWithValue("@supplytype", SqlDbType.VarChar).Value = supplyty;

                            conn.Open();
                            mrpekle.ExecuteNonQuery();

                            //algoritma tamamlanınca + stok girişi sonra döngüye devam...
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bir hata gerçekleşti...");
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }




                }
            }
        }

        private void bull2()
        {
            //ikinci parçalama

            //parçalanan ürünleri parçala
            SqlCommand calculdebugsecondsql = new SqlCommand("SELECT * FROM calculdebug", conn);
            DataTable calculdebugseconddt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(calculdebugsecondsql);
            da.Fill(calculdebugseconddt);
            foreach (DataRow calculdebugsecondRow in calculdebugseconddt.Rows)
            {
                SqlCommand bom_detailsql = new SqlCommand("SELECT * FROM bom_detail WHERE mainitemid = " + Convert.ToInt32(calculdebugsecondRow[6]), conn);
                DataTable bom_detaildt = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(bom_detailsql);
                da1.Fill(bom_detaildt);
                foreach (DataRow bom_detailRow in bom_detaildt.Rows) // parçalanan ürünlerin reçeteleri
                {
                    try //parçalanan ürünlerin reçetelerini patlatıyoruz.
                    {
                        SqlCommand mrpekle = new SqlCommand("INSERT INTO CALCULDEBUG(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                        "VALUES(CONVERT(date, @date_, 103), @orderdetailid, @bomid, @bomdetailid, @mainitemid, @childitemid, @mainamount, @childamount, @givenorderamount, @stock, @requirement, @supplytype)", conn);
                        mrpekle.Parameters.AddWithValue("@date_", SqlDbType.Date).Value = Convert.ToDateTime(calculdebugsecondRow[1].ToString());
                        mrpekle.Parameters.AddWithValue("@orderdetailid", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[2]);
                        mrpekle.Parameters.AddWithValue("@bomid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[1]);
                        mrpekle.Parameters.AddWithValue("@bomdetailid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[0]);
                        mrpekle.Parameters.AddWithValue("@mainitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[2]);

                        mrpekle.Parameters.AddWithValue("@childitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[3]);
                        mrpekle.Parameters.AddWithValue("@mainamount", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[8]);
                        mrpekle.Parameters.AddWithValue("@childamount", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[8]) * Convert.ToInt32(bom_detailRow[6]);
                        mrpekle.Parameters.AddWithValue("@givenorderamount", SqlDbType.Int).Value = 0;

                        //parçanın stok durumu
                        SqlCommand stocksql = new SqlCommand("SELECT * FROM stock WHERE itemid = " + Convert.ToInt32(bom_detailRow[3]), conn);
                        DataTable stockdt = new DataTable();
                        SqlDataAdapter da5 = new SqlDataAdapter(stocksql);
                        da5.Fill(stockdt);

                        mrpekle.Parameters.AddWithValue("@stock", SqlDbType.Int).Value = Convert.ToInt32(stockdt.Rows[0][2]);

                        //gereken miktarı bul.
                        int stock = Convert.ToInt32(stockdt.Rows[0][2]);
                        int orderamo = Convert.ToInt32(calculdebugsecondRow[8]) * Convert.ToInt32(bom_detailRow[6]);
                        int req;
                        if (stock < orderamo)
                        {
                            req = orderamo - stock;
                        }
                        else
                        {
                            req = 0;
                        }
                        mrpekle.Parameters.AddWithValue("@requirement", SqlDbType.Int).Value = req;

                        //tedarik durumunu belirle.
                        SqlCommand itemsql = new SqlCommand("SELECT * FROM item WHERE id = " + Convert.ToInt32(bom_detailRow[3]), conn);
                        DataTable itemdt = new DataTable();
                        SqlDataAdapter da6 = new SqlDataAdapter(itemsql);
                        da6.Fill(itemdt);
                        string supplyty;
                        if (itemdt.Rows[0][3].ToString() == "HM")
                        {
                            if (req == 0)
                            {
                                supplyty = "Halihazırda Var";
                            }
                            else
                            {
                                supplyty = "Sipariş";
                            }
                        }
                        else
                        {
                            if (req == 0)
                            {
                                supplyty = "Halihazırda Var";
                            }
                            else
                            {
                                supplyty = "Üretim";
                            }

                        }
                        mrpekle.Parameters.AddWithValue("@supplytype", SqlDbType.VarChar).Value = supplyty;

                        conn.Open();
                        mrpekle.ExecuteNonQuery();

                        ////
                        SqlCommand mrpekle2 = new SqlCommand("INSERT INTO CALCULDEBUG_TEMP(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                        "VALUES(CONVERT(date, @date_, 103), @orderdetailid, @bomid, @bomdetailid, @mainitemid, @childitemid, @mainamount, @childamount, @givenorderamount, @stock, @requirement, @supplytype)", conn);
                        mrpekle2.Parameters.AddWithValue("@date_", SqlDbType.Date).Value = Convert.ToDateTime(calculdebugsecondRow[1].ToString());
                        mrpekle2.Parameters.AddWithValue("@orderdetailid", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[2]);
                        mrpekle2.Parameters.AddWithValue("@bomid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[1]);
                        mrpekle2.Parameters.AddWithValue("@bomdetailid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[0]);
                        mrpekle2.Parameters.AddWithValue("@mainitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[2]);
                        mrpekle2.Parameters.AddWithValue("@childitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[3]);
                        mrpekle2.Parameters.AddWithValue("@mainamount", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[8]);
                        mrpekle2.Parameters.AddWithValue("@childamount", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[8]) * Convert.ToInt32(bom_detailRow[6]);
                        mrpekle2.Parameters.AddWithValue("@givenorderamount", SqlDbType.Int).Value = 0;
                        mrpekle2.Parameters.AddWithValue("@stock", SqlDbType.Int).Value = Convert.ToInt32(stockdt.Rows[0][2]);
                        mrpekle2.Parameters.AddWithValue("@requirement", SqlDbType.Int).Value = req;
                        mrpekle2.Parameters.AddWithValue("@supplytype", SqlDbType.VarChar).Value = supplyty;
                        mrpekle2.ExecuteNonQuery();


                        //algoritma tamamlanınca + stok girişi sonra döngüye devam...
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata gerçekleşti...");
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void bull3()
        {
            //üçüncü parçalama

            //parçalanan ürünlerin parçalarını parçala :D
            SqlCommand calculdebugsecondsql = new SqlCommand("SELECT * FROM CALCULDEBUG_TEMP", conn);
            DataTable calculdebugseconddt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(calculdebugsecondsql);
            da.Fill(calculdebugseconddt);
            foreach (DataRow calculdebugsecondRow in calculdebugseconddt.Rows)
            {
                SqlCommand bom_detailsql = new SqlCommand("SELECT * FROM bom_detail WHERE mainitemid = " + Convert.ToInt32(calculdebugsecondRow[6]), conn);
                DataTable bom_detaildt = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(bom_detailsql);
                da1.Fill(bom_detaildt);
                foreach (DataRow bom_detailRow in bom_detaildt.Rows) // parçalanan ürünlerin reçeteleri
                {
                    try //parçalanan ürünlerin reçetelerini patlatıyoruz.
                    {
                        SqlCommand mrpekle = new SqlCommand("INSERT INTO CALCULDEBUG(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                        "VALUES(CONVERT(date, @date_, 103), @orderdetailid, @bomid, @bomdetailid, @mainitemid, @childitemid, @mainamount, @childamount, @givenorderamount, @stock, @requirement, @supplytype)", conn);
                        mrpekle.Parameters.AddWithValue("@date_", SqlDbType.Date).Value = Convert.ToDateTime(calculdebugsecondRow[1].ToString());
                        mrpekle.Parameters.AddWithValue("@orderdetailid", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[2]);
                        mrpekle.Parameters.AddWithValue("@bomid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[1]);
                        mrpekle.Parameters.AddWithValue("@bomdetailid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[0]);
                        mrpekle.Parameters.AddWithValue("@mainitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[2]);

                        mrpekle.Parameters.AddWithValue("@childitemid", SqlDbType.Int).Value = Convert.ToInt32(bom_detailRow[3]);
                        mrpekle.Parameters.AddWithValue("@mainamount", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[8]);
                        mrpekle.Parameters.AddWithValue("@childamount", SqlDbType.Int).Value = Convert.ToInt32(calculdebugsecondRow[8]) * Convert.ToInt32(bom_detailRow[6]);
                        mrpekle.Parameters.AddWithValue("@givenorderamount", SqlDbType.Int).Value = 0;

                        //parçanın stok durumu
                        SqlCommand stocksql = new SqlCommand("SELECT * FROM stock WHERE itemid = " + Convert.ToInt32(bom_detailRow[3]), conn);
                        DataTable stockdt = new DataTable();
                        SqlDataAdapter da5 = new SqlDataAdapter(stocksql);
                        da5.Fill(stockdt);

                        mrpekle.Parameters.AddWithValue("@stock", SqlDbType.Int).Value = Convert.ToInt32(stockdt.Rows[0][2]);

                        //gereken miktarı bul.
                        int stock = Convert.ToInt32(stockdt.Rows[0][2]);
                        int orderamo = Convert.ToInt32(calculdebugsecondRow[8]) * Convert.ToInt32(bom_detailRow[6]);
                        int req;
                        if (stock < orderamo)
                        {
                            req = orderamo - stock;
                        }
                        else
                        {
                            req = 0;
                        }
                        mrpekle.Parameters.AddWithValue("@requirement", SqlDbType.Int).Value = req;

                        //tedarik durumunu belirle.
                        SqlCommand itemsql = new SqlCommand("SELECT * FROM item WHERE id = " + Convert.ToInt32(bom_detailRow[3]), conn);
                        DataTable itemdt = new DataTable();
                        SqlDataAdapter da6 = new SqlDataAdapter(itemsql);
                        da6.Fill(itemdt);
                        string supplyty;
                        if (itemdt.Rows[0][3].ToString() == "HM")
                        {
                            if (req == 0)
                            {
                                supplyty = "Halihazırda Var";
                            }
                            else
                            {
                                supplyty = "Sipariş";
                            }
                        }
                        else
                        {
                            if (req == 0)
                            {
                                supplyty = "Halihazırda Var";
                            }
                            else
                            {
                                supplyty = "Üretim";
                            }

                        }
                        mrpekle.Parameters.AddWithValue("@supplytype", SqlDbType.VarChar).Value = supplyty;

                        conn.Open();
                        mrpekle.ExecuteNonQuery();

                        ////


                        //algoritma tamamlanınca + stok girişi sonra döngüye devam...
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata gerçekleşti...");
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        #endregion

        #region events
        #endregion

        #region parts
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //ara
            if (cmbCustomer.SelectedIndex != -1)
            {
                searchsql = "SELECT  customer.customername AS musteri_adi, CALCULDEBUG.orderdetailid AS siparis_parca_no, CALCULDEBUG.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, CALCULDEBUG.mainamount AS ana_urun_miktar, CALCULDEBUG.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, CALCULDEBUG.stock AS alt_urun_stok_miktar, CALCULDEBUG.requirement AS alt_urun_gereken_sonuc_miktar, CALCULDEBUG.supplytype AS alt_urun_tedarik_turu FROM CALCULDEBUG JOIN item ON item.id = CALCULDEBUG.mainitemid JOIN item AS item2 ON item2.id = CALCULDEBUG.childitemid JOIN sales_order_detail ON sales_order_detail.id = CALCULDEBUG.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE customername = N'" + cmbCustomer.SelectedItem.ToString() + "'";

                if (cmbOrder.SelectedIndex != -1)
                {
                    searchsql = "SELECT  customer.customername AS musteri_adi, CALCULDEBUG.orderdetailid AS siparis_parca_no, CALCULDEBUG.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, CALCULDEBUG.mainamount AS ana_urun_miktar, CALCULDEBUG.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, CALCULDEBUG.stock AS alt_urun_stok_miktar, CALCULDEBUG.requirement AS alt_urun_gereken_sonuc_miktar, CALCULDEBUG.supplytype AS alt_urun_tedarik_turu FROM CALCULDEBUG JOIN item ON item.id = CALCULDEBUG.mainitemid JOIN item AS item2 ON item2.id = CALCULDEBUG.childitemid JOIN sales_order_detail ON sales_order_detail.id = CALCULDEBUG.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order.id = " + cmbOrder.SelectedItem.ToString();

                    if (cmbOrderDetail.SelectedIndex != -1)
                    {
                        searchsql = "SELECT  customer.customername AS musteri_adi, CALCULDEBUG.orderdetailid AS siparis_parca_no, CALCULDEBUG.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, CALCULDEBUG.mainamount AS ana_urun_miktar, CALCULDEBUG.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, CALCULDEBUG.stock AS alt_urun_stok_miktar, CALCULDEBUG.requirement AS alt_urun_gereken_sonuc_miktar, CALCULDEBUG.supplytype AS alt_urun_tedarik_turu FROM CALCULDEBUG JOIN item ON item.id = CALCULDEBUG.mainitemid JOIN item AS item2 ON item2.id = CALCULDEBUG.childitemid JOIN sales_order_detail ON sales_order_detail.id = CALCULDEBUG.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order_detail.id = " + sales_order_detail_id;
                    }
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(searchsql, conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                doldur();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            doldur();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCustomer.Text = "";
            cmbOrder.Text = "";
            cmbOrderDetail.Text = "";
            cmbCustomer.Items.Clear();
            cmbOrder.Items.Clear();
            cmbOrderDetail.Items.Clear();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable customerr = new DataTable();

            if (cmbCustomer.SelectedIndex != -1)
            {
                cmbOrder.Text = "";
                cmbOrder.Items.Clear();

                cmbOrderDetail.Text = "";
                cmbOrderDetail.Items.Clear();

                customer_name = cmbCustomer.SelectedItem.ToString();

                string customersql = "SELECT id FROM customer WHERE customername = N'" + customer_name + "'";

                SqlDataAdapter customerrda = new SqlDataAdapter(customersql, conn);
                customerrda.Fill(customerr);
                customer_id = Convert.ToInt32(customerr.Rows[0][0]);
                customerr.Clear();

                //müşteriye göre siparişleri getir.
                conn.Open();
                SqlCommand combodoldur2 = new SqlCommand("SELECT id FROM sales_order WHERE customerid = @cstid", conn);
                combodoldur2.Parameters.AddWithValue("@cstid", SqlDbType.Int).Value = customer_id;
                SqlDataReader oku = combodoldur2.ExecuteReader();
                while (oku.Read())
                {
                    cmbOrder.Items.Add(oku["id"].ToString());
                }
                conn.Close();

            }
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrder.SelectedIndex != -1)
            {
                //siparişe göre sipariş parçaları ürünleri getir.
                cmbOrderDetail.Text = "";
                cmbOrderDetail.Items.Clear();

                sales_order_id = Convert.ToInt32(cmbOrder.SelectedItem.ToString());
                orderitemssql = "" + sales_order_id;

                conn.Open();
                SqlCommand combodoldur3 = new SqlCommand("SELECT item.itemname, sales_order_detail.id FROM item JOIN sales_order_detail ON item.id = sales_order_detail.itemid WHERE sales_order_detail.orderid = @oid", conn);
                combodoldur3.Parameters.AddWithValue("@oid", SqlDbType.Int).Value = sales_order_id;
                SqlDataReader oku = combodoldur3.ExecuteReader();
                while (oku.Read())
                {
                    cmbOrderDetail.Items.Add(oku["itemname"].ToString() + " - ID:" + oku["id"].ToString());
                }
                conn.Close();
            }
        }

        private void cmbOrderDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderDetail.SelectedIndex != -1)
            {
                string iddd = cmbOrderDetail.SelectedItem.ToString().Substring(cmbOrderDetail.SelectedItem.ToString().IndexOf(":") + 1);
                sales_order_detail_id = Convert.ToInt32(iddd);
            }
        }

        private void cmbCustomer_Enter(object sender, EventArgs e)
        {
            if (cmbCustomer.Text == "Müşteri")
            {
                cmbCustomer.Text = "";
                cmbCustomer.ForeColor = Color.White;
            }
        }

        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            if (cmbCustomer.Text == "")
            {
                cmbCustomer.Text = "Müşteri";
                cmbCustomer.ForeColor = Color.LightGray;
            }
        }

        private void cmbOrder_Enter(object sender, EventArgs e)
        {
            if (cmbOrder.Text == "Sipariş")
            {
                cmbOrder.Text = "";
                cmbOrder.ForeColor = Color.White;
            }
        }

        private void cmbOrder_Leave(object sender, EventArgs e)
        {
            if (cmbOrder.Text == "")
            {
                cmbOrder.Text = "Sipariş";
                cmbOrder.ForeColor = Color.LightGray;
            }
        }

        private void cmbOrderDetail_Enter(object sender, EventArgs e)
        {
            if (cmbOrderDetail.Text == "Siparişin Ürünü")
            {
                cmbOrderDetail.Text = "";
                cmbOrderDetail.ForeColor = Color.White;
            }
        }

        private void cmbOrderDetail_Leave(object sender, EventArgs e)
        {
            if (cmbOrderDetail.Text == "")
            {
                cmbOrderDetail.Text = "Siparişin Ürünü";
                cmbOrderDetail.ForeColor = Color.LightGray;
            }
        }
    }
}
