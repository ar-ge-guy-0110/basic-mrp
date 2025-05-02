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
    public partial class mrpcalc_core : Form
    {

        SqlConnection baglan = cs_dbconnections.conn;

        string teststring;

        int order_detailid;
        int order_itemid;
        int order_amount;
        string order_unitcode;
        string order_itemtype;
        int order_itembom;

        string order_startdate;
        int order_mainorderid;

        int order_available_amount;
        int order_req_amount;

        //parcalama itemleri için
        int stagetwo_orderdetailid;
        int stagetwo_itemid;
        int stagetwo_amount;
        string stagetwo_unitcode;
        string stagetwo_itemtype;
        int stagetwo_itembom;

        string stagetwo_startdate;

        int stagetwo_available_amount;
        int stagetwo_req_amount;
        //--

        string process_date;

        int bomitem_bomdetailid;

        int mrp_mainitemid;
        int mrp_childitemid;
        int mrp_mainamount;
        int mrp_childamount;
        int mrp_givenorderamount;
        int mrp_stock;
        int mrp_req;
        string mrp_supplytype;

        string mrp_childitemtype;

        int mrp_available_amount;

        //--
        int temp1 = -1;
        int temp2 = -1;


        public mrpcalc_core()
        {
            InitializeComponent();
        }


        private void mrpcalc_core_Load(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand debugtemizle = new SqlCommand("DELETE FROM mrp_calculation", baglan);
            SqlCommand debugtemizleautoinc = new SqlCommand("DBCC CHECKIDENT('mrp_calculation', RESEED, 0)", baglan);
            SqlCommand debugtemizle2 = new SqlCommand("DELETE FROM mrp_calculation_temp", baglan);
            SqlCommand debugtemizle2autoinc = new SqlCommand("DBCC CHECKIDENT('mrp_calculation_temp', RESEED, 0)", baglan);
            debugtemizle.ExecuteNonQuery();
            debugtemizleautoinc.ExecuteNonQuery();
            debugtemizle2.ExecuteNonQuery();
            debugtemizle2autoinc.ExecuteNonQuery();
            baglan.Close();

            process_date = DateTime.Now.Date.ToString();

            //tablolar ------------------------------------------------------------------------------------
            //işlem için sipariş ürünleri veri tablosu
            DataTable mrpcalc_orderdetail_dt = new DataTable();
            string mrpcalc_ordersql = "SELECT * FROM sales_order_detail";

            //işlem için ürün reçeteleri veri tablosu
            DataTable mrpcalc_bomdetail_dt = new DataTable();
            string mrpcalc_bomdetailsql = "";

            //işlem için ürün tablosu
            DataTable mrpcalc_item_dt = new DataTable();
            string mrpcalc_itemsql = "";

            //işlem için ana reçete tanımları tablosu
            DataTable mrpcalc_bom_dt = new DataTable();
            string mrpcalc_bomsql = "";

            //işlem için stok tablosu
            DataTable mrpcalc_stock_dt = new DataTable();
            string mrpcalc_stocksql = "";

            //mrpcalc_nextitem tablosu
            DataTable mrpcalc_nextitem_dt = new DataTable();
            string mrpcalc_nextitemsql = "SELECT * FROM mrp_calculation";

            //childitemtype
            DataTable childitemtype_table = new DataTable();
            string chsql = "";

            //sales_order
            DataTable mrpcalc_salesorder_dt = new DataTable();
            string salesordersql = "";

            //
            DataTable tempsql_dt = new DataTable();
            string tempsql = "";



            //------------------------------------------------------------------------------------------------

            //veri tablosunu sipariş edilen ürünlerle doldur.
            SqlDataAdapter mrpcalc_orderda = new SqlDataAdapter(mrpcalc_ordersql, baglan);
            mrpcalc_orderda.Fill(mrpcalc_orderdetail_dt);


            //her sipariş için calc bilgisi topla ve işlem yap.
            foreach (DataRow row in mrpcalc_orderdetail_dt.Rows)
            {

                //ürünün sipariş detayları
                order_detailid = Convert.ToInt32(row["id"]);
                order_itemid = Convert.ToInt32(row["itemid"]);
                order_amount = Convert.ToInt32(row["amount"]);
                order_unitcode = row["unitcode"].ToString();
                order_mainorderid = Convert.ToInt32(row["orderid"]);

                //sipariş başlangıç tarihi
                salesordersql = "SELECT date_ FROM sales_order WHERE id = " + order_mainorderid;
                SqlDataAdapter salesorderda = new SqlDataAdapter(salesordersql, baglan);
                salesorderda.Fill(mrpcalc_salesorder_dt);
                order_startdate = (mrpcalc_salesorder_dt.Rows[0][0]).ToString();
                mrpcalc_salesorder_dt.Clear();

                //sipariş ürününün bilgisi
                mrpcalc_itemsql = "SELECT * FROM item WHERE id = " + order_itemid;
                SqlDataAdapter mrpcalc_itemda = new SqlDataAdapter(mrpcalc_itemsql, baglan);
                mrpcalc_itemda.Fill(mrpcalc_item_dt);
                order_itemtype = (mrpcalc_item_dt.Rows[0][3]).ToString();
                mrpcalc_item_dt.Clear();

                /**/
                //sipariş ürününün stok bilgisi
                mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + order_itemid;
                SqlDataAdapter mrpcalc_stockda2 = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                mrpcalc_stockda2.Fill(mrpcalc_stock_dt);
                order_available_amount = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                mrpcalc_stock_dt.Clear();

                //bu sipariş ürününden toplam kaç tane istenmiş?
                /*
                tempsql = "SELECT SUM(amount) FROM sales_order_detail WHERE itemid = " + order_itemid;
                SqlDataAdapter tempda = new SqlDataAdapter(tempsql, baglan);
                tempda.Fill(tempsql_dt);
                order_sum_amount = Convert.ToInt32(tempsql_dt.Rows[0][0]);
                */
                /**/

                if(temp1 != -1)
                {
                    order_available_amount = temp1;
                }


                //&& order_amount > order_available_amount
                if (order_itemtype != "HM")
                {
                    /**/

                    //sanal stok işlem
                    if(order_available_amount < order_amount)
                    {
                        order_req_amount = order_amount - order_available_amount;
                        order_available_amount = 0;
                        temp1 = order_available_amount;
                    }
                    else if(order_available_amount >= order_amount)
                    {
                        order_available_amount -= order_amount;
                        order_req_amount = 0;
                        temp1 = order_available_amount;
                    }





                    //gerçek stok işlem

                    /**/


                    //sipariş ürününün recetesi
                    mrpcalc_bomsql = "SELECT * FROM bom WHERE itemid = " + order_itemid;
                    SqlDataAdapter mrpcalc_bomda = new SqlDataAdapter(mrpcalc_bomsql, baglan);
                    mrpcalc_bomda.Fill(mrpcalc_bom_dt);
                    order_itembom = Convert.ToInt32(mrpcalc_bom_dt.Rows[0][0]);
                    mrpcalc_bom_dt.Clear();


                    //sipariş ürününün parçalanması
                    mrpcalc_bomdetailsql = "SELECT * FROM bom_detail WHERE mainitemid = " + order_itemid;
                    SqlDataAdapter mrpcalc_bomdetailda = new SqlDataAdapter(mrpcalc_bomdetailsql, baglan);
                    mrpcalc_bomdetailda.Fill(mrpcalc_bomdetail_dt);

                    foreach (DataRow row2 in mrpcalc_bomdetail_dt.Rows)
                    {
                        //sipariş ürününün reçete detayları ve calculation
                        bomitem_bomdetailid = Convert.ToInt32(row2["id"]);
                        mrp_mainitemid = order_itemid;
                        mrp_childitemid = Convert.ToInt32(row2["childitemid"]);

                        //childitem ürün türü
                        chsql = "SELECT itemtype FROM item WHERE id = " + mrp_childitemid;
                        SqlDataAdapter chsqlda = new SqlDataAdapter(chsql, baglan);
                        chsqlda.Fill(childitemtype_table);
                        mrp_childitemtype = childitemtype_table.Rows[0][0].ToString();
                        childitemtype_table.Clear();

                        //childitem stok bilgisi
                        mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + mrp_childitemid;
                        SqlDataAdapter mrpcalc_stockda3 = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                        mrpcalc_stockda3.Fill(mrpcalc_stock_dt);
                        mrp_available_amount = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                        mrpcalc_stock_dt.Clear();

                        if(temp2 != -1)
                        {
                            mrp_available_amount = temp2;
                        }

                        mrp_givenorderamount = 0;

                        mrp_mainamount = order_req_amount;
                        mrp_childamount = order_req_amount * Convert.ToInt32(row2["childamount"]);

                        //mrp_childamount : sihirli kısım alt ürün stoğa göre sanal plan oluşturma.
                        //ama ilerde yazacagım butona tıklarsan siparişler ve stoklar bidaha eski haline dönmez işlem girilir bu mrpcalca göre
                        if (mrp_available_amount < mrp_childamount)
                        {
                            mrp_stock = mrp_available_amount;
                            mrp_req = mrp_childamount - mrp_available_amount;
                            mrp_available_amount = 0;

                            temp2 = mrp_available_amount;
                        }

                        if(mrp_available_amount >= mrp_childamount)
                        {
                            mrp_stock = mrp_available_amount;
                            mrp_available_amount -= mrp_childamount;
                            mrp_req = 0;

                            temp2 = mrp_available_amount;
                        }


                        /*

                        mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + mrp_childitemid;
                        SqlDataAdapter mrpcalc_stockda = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                        mrpcalc_stockda.Fill(mrpcalc_stock_dt);
                        mrp_stock = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                        mrpcalc_stock_dt.Clear();

                        if (mrp_givenorderamount + mrp_stock > mrp_childamount || mrp_givenorderamount + mrp_stock == mrp_childamount)
                        {
                            mrp_req = 0;
                        }
                        else if (mrp_givenorderamount + mrp_stock < mrp_childamount)
                        {
                            mrp_req = (mrp_givenorderamount + mrp_stock) - mrp_childamount;
                            if (mrp_req < 0)
                                mrp_req *= -1;
                        }
                        else
                        {

                        }
                        */


                        if(mrp_childitemtype != "HM")
                        {
                            mrp_supplytype = "UR";
                        }
                        else
                        {
                            mrp_supplytype = "SP";
                        }




                        try
                        {
                            SqlCommand mrpekle = new SqlCommand("INSERT INTO mrp_calculation(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                            "VALUES(CONVERT(date, @processdate, 103), @order_detailid, @order_itembom, @bomitem_bomdetailid, @mrp_mainitemid, @mrp_childitemid, @mrp_mainamount, @mrp_childamount, @mrp_givenorderamount, @mrp_stock, @mrp_req, @mrp_supplytype)", baglan);
                            mrpekle.Parameters.AddWithValue("@processdate", SqlDbType.Date).Value = order_startdate;
                            mrpekle.Parameters.AddWithValue("@order_detailid", SqlDbType.Int).Value = order_detailid;
                            mrpekle.Parameters.AddWithValue("@order_itembom", SqlDbType.Int).Value = order_itembom;
                            mrpekle.Parameters.AddWithValue("@bomitem_bomdetailid", SqlDbType.Int).Value = bomitem_bomdetailid;
                            mrpekle.Parameters.AddWithValue("@mrp_mainitemid", SqlDbType.Int).Value = mrp_mainitemid;
                            mrpekle.Parameters.AddWithValue("@mrp_childitemid", SqlDbType.Int).Value = mrp_childitemid;
                            mrpekle.Parameters.AddWithValue("@mrp_mainamount", SqlDbType.Int).Value = mrp_mainamount;
                            mrpekle.Parameters.AddWithValue("@mrp_childamount", SqlDbType.Int).Value = mrp_childamount;
                            mrpekle.Parameters.AddWithValue("@mrp_givenorderamount", SqlDbType.Int).Value = mrp_givenorderamount;
                            mrpekle.Parameters.AddWithValue("@mrp_stock", SqlDbType.Int).Value = mrp_stock;
                            mrpekle.Parameters.AddWithValue("@mrp_req", SqlDbType.Int).Value = mrp_req;
                            mrpekle.Parameters.AddWithValue("@mrp_supplytype", SqlDbType.VarChar).Value = mrp_supplytype;

                            baglan.Open();
                            mrpekle.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Bir hata gerçekleşti...");
                        }
                        finally
                        {
                            baglan.Close();
                        }
                    }
                    mrpcalc_bomdetail_dt.Clear();
                }



                //sipariş ürünü zaten varsa toplam miktar azalsın



                //gerçek bölüm
                /*
                if (order_available_amount >= order_amount)
                {
                    order_available_amount -= order_amount;

                    SqlCommand stokazalt = new SqlCommand("UPDATE stock SET amount = @amo WHERE itemid = @itmid", baglan);
                    stokazalt.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = order_available_amount;
                    stokazalt.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = order_itemid;
                    baglan.Open();
                    stokazalt.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    order_available_amount = 0;
                    SqlCommand stokazalt = new SqlCommand("UPDATE stock SET amount = @amo WHERE itemid = @itmid", baglan);
                    stokazalt.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = order_available_amount;
                    stokazalt.Parameters.AddWithValue("@itmid", SqlDbType.Int).Value = order_itemid;
                    baglan.Open();
                    stokazalt.ExecuteNonQuery();
                    baglan.Close();
                }
                */






            }
            temp1 = -1;
            temp2 = -1;







            //sipariş ürünün ilk seviye parcalanması bitti, eger geriye kalanlar hala hammadde degilse onlarıda alt seviyeye parcala.

            //veri tablosunu tekrar parçalama için ürünlerle doldur.
            SqlDataAdapter mrpcalc_nextitemda = new SqlDataAdapter(mrpcalc_nextitemsql, baglan);
            mrpcalc_nextitemda.Fill(mrpcalc_nextitem_dt);

            //her siparişin alt ürünleri için calc bilgisi topla ve işlem yap.
            foreach (DataRow row in mrpcalc_nextitem_dt.Rows)
            {

                //ürün bilgisi
                stagetwo_startdate = row["date_"].ToString();
                stagetwo_orderdetailid = Convert.ToInt32(row["orderdetailid"]);
                stagetwo_itemid = Convert.ToInt32(row["childitemid"]);
                stagetwo_amount = Convert.ToInt32(row["childamount"]);
                //stagetwo_unitcode

                //alt ürünün türü
                mrpcalc_itemsql = "SELECT * FROM item WHERE id = " + stagetwo_itemid;
                SqlDataAdapter mrpcalc_stagetwoitemda = new SqlDataAdapter(mrpcalc_itemsql, baglan);
                mrpcalc_stagetwoitemda.Fill(mrpcalc_item_dt);
                stagetwo_itemtype = (mrpcalc_item_dt.Rows[0][3]).ToString();
                mrpcalc_item_dt.Clear();

                //alt ürünün stok bilgisi
                mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + stagetwo_itemid;
                SqlDataAdapter mrpcalc_stockda4 = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                mrpcalc_stockda4.Fill(mrpcalc_stock_dt);
                stagetwo_available_amount = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                mrpcalc_stock_dt.Clear();

                if (temp1 != -1)
                {
                    stagetwo_available_amount = temp1;
                }


                if (stagetwo_itemtype != "HM")
                {

                    /**/

                    //sanal stok işlem
                    if (stagetwo_available_amount < stagetwo_amount)
                    {
                        stagetwo_req_amount = stagetwo_amount - stagetwo_available_amount;
                        stagetwo_available_amount = 0;
                        temp1 = stagetwo_available_amount;
                    }
                    else if (stagetwo_available_amount >= stagetwo_amount)
                    {
                        stagetwo_available_amount -= stagetwo_amount;
                        stagetwo_req_amount = 0;
                        temp1 = stagetwo_available_amount;
                    }





                    //gerçek stok işlem

                    /**/

                    //alt ürünün recetesi
                    mrpcalc_bomsql = "SELECT * FROM bom WHERE itemid = " + stagetwo_itemid;
                    SqlDataAdapter mrpcalc_bomda = new SqlDataAdapter(mrpcalc_bomsql, baglan);
                    mrpcalc_bomda.Fill(mrpcalc_bom_dt);
                    stagetwo_itembom = Convert.ToInt32(mrpcalc_bom_dt.Rows[0][0]);
                    mrpcalc_bom_dt.Clear();

                    //alt ürünün parçalanması
                    mrpcalc_bomdetailsql = "SELECT * FROM bom_detail WHERE mainitemid = " + stagetwo_itemid;
                    SqlDataAdapter mrpcalc_bomdetailda = new SqlDataAdapter(mrpcalc_bomdetailsql, baglan);
                    mrpcalc_bomdetailda.Fill(mrpcalc_bomdetail_dt);

                    foreach (DataRow row2 in mrpcalc_bomdetail_dt.Rows)
                    {
                        //alt ürünün reçete detayları ve calculation
                        bomitem_bomdetailid = Convert.ToInt32(row2["id"]);
                        mrp_mainitemid = stagetwo_itemid;
                        mrp_childitemid = Convert.ToInt32(row2["childitemid"]);

                        //
                        chsql = "SELECT itemtype FROM item WHERE id = " + mrp_childitemid;
                        SqlDataAdapter chsqlda = new SqlDataAdapter(chsql, baglan);
                        chsqlda.Fill(childitemtype_table);
                        mrp_childitemtype = childitemtype_table.Rows[0][0].ToString();
                        childitemtype_table.Clear();

                        //childitem stok bilgisi
                        mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + mrp_childitemid;
                        SqlDataAdapter mrpcalc_stockda5 = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                        mrpcalc_stockda5.Fill(mrpcalc_stock_dt);
                        mrp_available_amount = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                        mrpcalc_stock_dt.Clear();

                        if (temp2 != -1)
                        {
                            mrp_available_amount = temp2;
                        }



                        mrp_mainamount = stagetwo_req_amount;
                        mrp_childamount = stagetwo_req_amount * Convert.ToInt32(row2["childamount"]);
                        mrp_givenorderamount = 0;

                        //mrp_childamount : sihirli kısım alt ürün stoğa göre sanal plan oluşturma.
                        //ama ilerde yazacagım butona tıklarsan siparişler ve stoklar bidaha eski haline dönmez işlem girilir bu mrpcalca göre
                        if (mrp_available_amount < mrp_childamount)
                        {
                            mrp_stock = mrp_available_amount;
                            mrp_req = mrp_childamount - mrp_available_amount;
                            mrp_available_amount = 0;

                            temp2 = mrp_available_amount;
                        }

                        if (mrp_available_amount >= mrp_childamount)
                        {
                            mrp_stock = mrp_available_amount;
                            mrp_available_amount -= mrp_childamount;
                            mrp_req = 0;

                            temp2 = mrp_available_amount;
                        }

                        /*
                        mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + mrp_childitemid;
                        SqlDataAdapter mrpcalc_stockda = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                        mrpcalc_stockda.Fill(mrpcalc_stock_dt);
                        mrp_stock = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                        mrpcalc_stock_dt.Clear();

                        if (mrp_givenorderamount + mrp_stock > mrp_childamount || mrp_givenorderamount + mrp_stock == mrp_childamount)
                        {
                            mrp_req = 0;
                        }
                        else if (mrp_givenorderamount + mrp_stock < mrp_childamount)
                        {
                            mrp_req = (mrp_givenorderamount + mrp_stock) - mrp_childamount;
                            if (mrp_req < 0)
                                mrp_req *= -1;
                        }
                        else
                        {

                        }
                        */


                        if (mrp_childitemtype != "HM")
                        {
                            mrp_supplytype = "UR";
                        }
                        else
                        {
                            mrp_supplytype = "SP";
                        }


                        try
                        {
                            SqlCommand mrpekle = new SqlCommand("INSERT INTO mrp_calculation(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                            "VALUES(CONVERT(date, @processdate, 103), @order_detailid, @order_itembom, @bomitem_bomdetailid, @mrp_mainitemid, @mrp_childitemid, @mrp_mainamount, @mrp_childamount, @mrp_givenorderamount, @mrp_stock, @mrp_req, @mrp_supplytype)", baglan);
                            mrpekle.Parameters.AddWithValue("@processdate", SqlDbType.Date).Value = stagetwo_startdate;
                            mrpekle.Parameters.AddWithValue("@order_detailid", SqlDbType.Int).Value = stagetwo_orderdetailid;
                            mrpekle.Parameters.AddWithValue("@order_itembom", SqlDbType.Int).Value = stagetwo_itembom;
                            mrpekle.Parameters.AddWithValue("@bomitem_bomdetailid", SqlDbType.Int).Value = bomitem_bomdetailid;
                            mrpekle.Parameters.AddWithValue("@mrp_mainitemid", SqlDbType.Int).Value = mrp_mainitemid;
                            mrpekle.Parameters.AddWithValue("@mrp_childitemid", SqlDbType.Int).Value = mrp_childitemid;
                            mrpekle.Parameters.AddWithValue("@mrp_mainamount", SqlDbType.Int).Value = mrp_mainamount;
                            mrpekle.Parameters.AddWithValue("@mrp_childamount", SqlDbType.Int).Value = mrp_childamount;
                            mrpekle.Parameters.AddWithValue("@mrp_givenorderamount", SqlDbType.Int).Value = mrp_givenorderamount;
                            mrpekle.Parameters.AddWithValue("@mrp_stock", SqlDbType.Int).Value = mrp_stock;
                            mrpekle.Parameters.AddWithValue("@mrp_req", SqlDbType.Int).Value = mrp_req;
                            mrpekle.Parameters.AddWithValue("@mrp_supplytype", SqlDbType.VarChar).Value = mrp_supplytype;

                            //ileride parcalanacakları ayır.
                            SqlCommand mrpekle2 = new SqlCommand("INSERT INTO mrp_calculation_temp(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                            "VALUES(CONVERT(date, @processdate, 103), @order_detailid, @order_itembom, @bomitem_bomdetailid, @mrp_mainitemid, @mrp_childitemid, @mrp_mainamount, @mrp_childamount, @mrp_givenorderamount, @mrp_stock, @mrp_req, @mrp_supplytype)", baglan);
                            mrpekle2.Parameters.AddWithValue("@processdate", SqlDbType.Date).Value = stagetwo_startdate;
                            mrpekle2.Parameters.AddWithValue("@order_detailid", SqlDbType.Int).Value = stagetwo_orderdetailid;
                            mrpekle2.Parameters.AddWithValue("@order_itembom", SqlDbType.Int).Value = stagetwo_itembom;
                            mrpekle2.Parameters.AddWithValue("@bomitem_bomdetailid", SqlDbType.Int).Value = bomitem_bomdetailid;
                            mrpekle2.Parameters.AddWithValue("@mrp_mainitemid", SqlDbType.Int).Value = mrp_mainitemid;
                            mrpekle2.Parameters.AddWithValue("@mrp_childitemid", SqlDbType.Int).Value = mrp_childitemid;
                            mrpekle2.Parameters.AddWithValue("@mrp_mainamount", SqlDbType.Int).Value = mrp_mainamount;
                            mrpekle2.Parameters.AddWithValue("@mrp_childamount", SqlDbType.Int).Value = mrp_childamount;
                            mrpekle2.Parameters.AddWithValue("@mrp_givenorderamount", SqlDbType.Int).Value = mrp_givenorderamount;
                            mrpekle2.Parameters.AddWithValue("@mrp_stock", SqlDbType.Int).Value = mrp_stock;
                            mrpekle2.Parameters.AddWithValue("@mrp_req", SqlDbType.Int).Value = mrp_req;
                            mrpekle2.Parameters.AddWithValue("@mrp_supplytype", SqlDbType.VarChar).Value = mrp_supplytype;

                            baglan.Open();
                            mrpekle.ExecuteNonQuery();
                            mrpekle2.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Bir hata gerçekleşti...");
                        }
                        finally
                        {
                            baglan.Close();
                        }
                    }

                    mrpcalc_bomdetail_dt.Clear();
                }


            }
            temp1 = -1;
            temp2 = -1;



            mrpcalc_nextitem_dt.Clear();

            //sipariş ürünün ikinci seviye parcalanması bitti, eger geriye kalanlar hala hammadde degilse onlarıda alt seviyeye parcala.

            //veri tablosunu tekrar parçalama için ürünlerle doldur.
            mrpcalc_nextitemsql = "SELECT * FROM mrp_calculation_temp";
            SqlDataAdapter mrpcalc_nextitemda2 = new SqlDataAdapter(mrpcalc_nextitemsql, baglan);
            mrpcalc_nextitemda2.Fill(mrpcalc_nextitem_dt);

            foreach (DataRow row in mrpcalc_nextitem_dt.Rows)
            {

                //ürün bilgisi
                stagetwo_startdate = row["date_"].ToString();
                stagetwo_orderdetailid = Convert.ToInt32(row["orderdetailid"]);
                stagetwo_itemid = Convert.ToInt32(row["childitemid"]);
                stagetwo_amount = Convert.ToInt32(row["childamount"]);
                //stagetwo_unitcode

                //alt ürünün bilgisi
                mrpcalc_itemsql = "SELECT * FROM item WHERE id = " + stagetwo_itemid;
                SqlDataAdapter mrpcalc_stagetwoitemda = new SqlDataAdapter(mrpcalc_itemsql, baglan);
                mrpcalc_stagetwoitemda.Fill(mrpcalc_item_dt);
                stagetwo_itemtype = (mrpcalc_item_dt.Rows[0][3]).ToString();
                mrpcalc_item_dt.Clear();

                //alt ürünün stok bilgisi
                mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + stagetwo_itemid;
                SqlDataAdapter mrpcalc_stockda6 = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                mrpcalc_stockda6.Fill(mrpcalc_stock_dt);
                stagetwo_available_amount = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                mrpcalc_stock_dt.Clear();

                if (temp1 != -1)
                {
                    stagetwo_available_amount = temp1;
                }

                if (stagetwo_itemtype != "HM")
                {

                    /**/

                    //sanal stok işlem
                    if (stagetwo_available_amount < stagetwo_amount)
                    {
                        stagetwo_req_amount = stagetwo_amount - stagetwo_available_amount;
                        stagetwo_available_amount = 0;
                        temp1 = stagetwo_available_amount;
                    }
                    else if (stagetwo_available_amount >= stagetwo_amount)
                    {
                        stagetwo_available_amount -= stagetwo_amount;
                        stagetwo_req_amount = 0;
                        temp1 = stagetwo_available_amount;
                    }





                    //gerçek stok işlem

                    /**/

                    //alt ürünün recetesi
                    mrpcalc_bomsql = "SELECT * FROM bom WHERE itemid = " + stagetwo_itemid;
                    SqlDataAdapter mrpcalc_bomda = new SqlDataAdapter(mrpcalc_bomsql, baglan);
                    mrpcalc_bomda.Fill(mrpcalc_bom_dt);
                    stagetwo_itembom = Convert.ToInt32(mrpcalc_bom_dt.Rows[0][0]);
                    mrpcalc_bom_dt.Clear();

                    //alt ürünün parçalanması
                    mrpcalc_bomdetailsql = "SELECT * FROM bom_detail WHERE mainitemid = " + stagetwo_itemid;
                    SqlDataAdapter mrpcalc_bomdetailda = new SqlDataAdapter(mrpcalc_bomdetailsql, baglan);
                    mrpcalc_bomdetailda.Fill(mrpcalc_bomdetail_dt);

                    foreach (DataRow row2 in mrpcalc_bomdetail_dt.Rows)
                    {
                        //alt ürünün reçete detayları ve calculation
                        bomitem_bomdetailid = Convert.ToInt32(row2["id"]);
                        mrp_mainitemid = stagetwo_itemid;
                        mrp_childitemid = Convert.ToInt32(row2["childitemid"]);

                        //
                        chsql = "SELECT itemtype FROM item WHERE id = " + mrp_childitemid;
                        SqlDataAdapter chsqlda = new SqlDataAdapter(chsql, baglan);
                        chsqlda.Fill(childitemtype_table);
                        mrp_childitemtype = childitemtype_table.Rows[0][0].ToString();
                        childitemtype_table.Clear();

                        //childitem stok bilgisi
                        mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + mrp_childitemid;
                        SqlDataAdapter mrpcalc_stockda7 = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                        mrpcalc_stockda7.Fill(mrpcalc_stock_dt);
                        mrp_available_amount = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                        mrpcalc_stock_dt.Clear();

                        if (temp2 != -1)
                        {
                            mrp_available_amount = temp2;
                        }

                        mrp_mainamount = stagetwo_req_amount;
                        mrp_childamount = stagetwo_req_amount * Convert.ToInt32(row2["childamount"]);
                        mrp_givenorderamount = 0;

                        //mrp_childamount : sihirli kısım alt ürün stoğa göre sanal plan oluşturma.
                        //ama ilerde yazacagım butona tıklarsan siparişler ve stoklar bidaha eski haline dönmez işlem girilir bu mrpcalca göre
                        if (mrp_available_amount < mrp_childamount)
                        {
                            mrp_stock = mrp_available_amount;
                            mrp_req = mrp_childamount - mrp_available_amount;
                            mrp_available_amount = 0;

                            temp2 = mrp_available_amount;
                        }

                        if (mrp_available_amount >= mrp_childamount)
                        {
                            mrp_stock = mrp_available_amount;
                            mrp_available_amount -= mrp_childamount;
                            mrp_req = 0;

                            temp2 = mrp_available_amount;
                        }


                        /*
                        mrpcalc_stocksql = "SELECT * FROM stock WHERE itemid = " + mrp_childitemid;
                        SqlDataAdapter mrpcalc_stockda = new SqlDataAdapter(mrpcalc_stocksql, baglan);
                        mrpcalc_stockda.Fill(mrpcalc_stock_dt);
                        mrp_stock = Convert.ToInt32(mrpcalc_stock_dt.Rows[0][2]);
                        mrpcalc_stock_dt.Clear();

                        if (mrp_givenorderamount + mrp_stock > mrp_childamount || mrp_givenorderamount + mrp_stock == mrp_childamount)
                        {
                            mrp_req = 0;
                        }
                        else if (mrp_givenorderamount + mrp_stock < mrp_childamount)
                        {
                            mrp_req = (mrp_givenorderamount + mrp_stock) - mrp_childamount;
                            if (mrp_req < 0)
                                mrp_req *= -1;
                        }
                        else
                        {

                        }
                        */



                        if (mrp_childitemtype == "HM")
                        {
                            mrp_supplytype = "SP";
                        }
                        else
                        {
                            mrp_supplytype = "UR";
                        }


                        try
                        {
                            SqlCommand mrpekle = new SqlCommand("INSERT INTO mrp_calculation(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                            "VALUES(CONVERT(date, @processdate, 103), @order_detailid, @order_itembom, @bomitem_bomdetailid, @mrp_mainitemid, @mrp_childitemid, @mrp_mainamount, @mrp_childamount, @mrp_givenorderamount, @mrp_stock, @mrp_req, @mrp_supplytype)", baglan);
                            mrpekle.Parameters.AddWithValue("@processdate", SqlDbType.Date).Value = stagetwo_startdate;
                            mrpekle.Parameters.AddWithValue("@order_detailid", SqlDbType.Int).Value = stagetwo_orderdetailid;
                            mrpekle.Parameters.AddWithValue("@order_itembom", SqlDbType.Int).Value = stagetwo_itembom;
                            mrpekle.Parameters.AddWithValue("@bomitem_bomdetailid", SqlDbType.Int).Value = bomitem_bomdetailid;
                            mrpekle.Parameters.AddWithValue("@mrp_mainitemid", SqlDbType.Int).Value = mrp_mainitemid;
                            mrpekle.Parameters.AddWithValue("@mrp_childitemid", SqlDbType.Int).Value = mrp_childitemid;
                            mrpekle.Parameters.AddWithValue("@mrp_mainamount", SqlDbType.Int).Value = mrp_mainamount;
                            mrpekle.Parameters.AddWithValue("@mrp_childamount", SqlDbType.Int).Value = mrp_childamount;
                            mrpekle.Parameters.AddWithValue("@mrp_givenorderamount", SqlDbType.Int).Value = mrp_givenorderamount;
                            mrpekle.Parameters.AddWithValue("@mrp_stock", SqlDbType.Int).Value = mrp_stock;
                            mrpekle.Parameters.AddWithValue("@mrp_req", SqlDbType.Int).Value = mrp_req;
                            mrpekle.Parameters.AddWithValue("@mrp_supplytype", SqlDbType.VarChar).Value = mrp_supplytype;

                            //ileride parcalanacakları ayır.
                            SqlCommand mrpekle2 = new SqlCommand("INSERT INTO mrp_calculation_temp(date_, orderdetailid, bomid, bomdetailid, mainitemid, childitemid, mainamount, childamount, givenorderamount, stock, requirement, supplytype)" +
                            "VALUES(CONVERT(date, @processdate, 103), @order_detailid, @order_itembom, @bomitem_bomdetailid, @mrp_mainitemid, @mrp_childitemid, @mrp_mainamount, @mrp_childamount, @mrp_givenorderamount, @mrp_stock, @mrp_req, @mrp_supplytype)", baglan);
                            mrpekle2.Parameters.AddWithValue("@processdate", SqlDbType.Date).Value = stagetwo_startdate;
                            mrpekle2.Parameters.AddWithValue("@order_detailid", SqlDbType.Int).Value = stagetwo_orderdetailid;
                            mrpekle2.Parameters.AddWithValue("@order_itembom", SqlDbType.Int).Value = stagetwo_itembom;
                            mrpekle2.Parameters.AddWithValue("@bomitem_bomdetailid", SqlDbType.Int).Value = bomitem_bomdetailid;
                            mrpekle2.Parameters.AddWithValue("@mrp_mainitemid", SqlDbType.Int).Value = mrp_mainitemid;
                            mrpekle2.Parameters.AddWithValue("@mrp_childitemid", SqlDbType.Int).Value = mrp_childitemid;
                            mrpekle2.Parameters.AddWithValue("@mrp_mainamount", SqlDbType.Int).Value = mrp_mainamount;
                            mrpekle2.Parameters.AddWithValue("@mrp_childamount", SqlDbType.Int).Value = mrp_childamount;
                            mrpekle2.Parameters.AddWithValue("@mrp_givenorderamount", SqlDbType.Int).Value = mrp_givenorderamount;
                            mrpekle2.Parameters.AddWithValue("@mrp_stock", SqlDbType.Int).Value = mrp_stock;
                            mrpekle2.Parameters.AddWithValue("@mrp_req", SqlDbType.Int).Value = mrp_req;
                            mrpekle2.Parameters.AddWithValue("@mrp_supplytype", SqlDbType.VarChar).Value = mrp_supplytype;

                            baglan.Open();
                            mrpekle.ExecuteNonQuery();
                            mrpekle2.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Bir hata gerçekleşti...");
                        }
                        finally
                        {
                            baglan.Close();
                        }
                    }

                    mrpcalc_bomdetail_dt.Clear();
                }

            }
            temp1 = -1;
            temp2 = -1;


            doldur();

            //------------------------------------------------------------------------------------------------------------
            //

            //mrp arama

            //musterileri doldur
            baglan.Open();
            SqlCommand combodoldur1 = new SqlCommand("SELECT customername FROM customer", baglan);
            SqlDataReader oku = combodoldur1.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["customername"]);
            }
            baglan.Close();

        }

        private void doldur()
        {
            
            DataTable dt = new DataTable();
            string sql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            datatab.DataSource = dt;
        }



        //mrp arama

        string customer_name = "";
        int customer_id;
        string searchsql = "";
        string orderitemssql = "";

        int sales_order_id;
        int sales_order_detail_id;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable customerr = new DataTable();

            if(comboBox1.SelectedIndex != -1)
            {
                comboBox2.Text = "";
                comboBox2.Items.Clear();

                comboBox3.Text = "";
                comboBox3.Items.Clear();

                customer_name = comboBox1.SelectedItem.ToString();

                string customersql = "SELECT id FROM customer WHERE customername = N'" + customer_name + "'";

                SqlDataAdapter customerrda = new SqlDataAdapter(customersql, baglan);
                customerrda.Fill(customerr);
                customer_id = Convert.ToInt32(customerr.Rows[0][0]);
                customerr.Clear();

                //müşteriye göre siparişleri getir.
                baglan.Open();
                SqlCommand combodoldur2 = new SqlCommand("SELECT id FROM sales_order WHERE customerid = @cstid", baglan);
                combodoldur2.Parameters.AddWithValue("@cstid", SqlDbType.Int).Value = customer_id;
                SqlDataReader oku = combodoldur2.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["id"].ToString());
                }
                baglan.Close();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex != -1)
            {
                //siparişe göre sipariş parçaları ürünleri getir.
                comboBox3.Text = "";
                comboBox3.Items.Clear();

                sales_order_id = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                orderitemssql = "" + sales_order_id;

                baglan.Open();
                SqlCommand combodoldur3 = new SqlCommand("SELECT item.itemname, sales_order_detail.id FROM item JOIN sales_order_detail ON item.id = sales_order_detail.itemid WHERE sales_order_detail.orderid = @oid", baglan);
                combodoldur3.Parameters.AddWithValue("@oid", SqlDbType.Int).Value = sales_order_id;
                SqlDataReader oku = combodoldur3.ExecuteReader();
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku["itemname"].ToString() + " - ID:" + oku["id"].ToString());
                }
                baglan.Close();
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                string iddd = comboBox3.SelectedItem.ToString().Substring(comboBox3.SelectedItem.ToString().IndexOf(":") + 1);
                sales_order_detail_id = Convert.ToInt32(iddd);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ara
            if(comboBox1.SelectedIndex != -1)
            {
                searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE customername = N'" + comboBox1.SelectedItem.ToString() + "'";

                if(comboBox2.SelectedIndex != -1)
                {
                    searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order.id = " + comboBox2.SelectedItem.ToString();

                    if(comboBox3.SelectedIndex != -1)
                    {
                        searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order_detail.id = " + sales_order_detail_id;
                    }
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(searchsql, baglan);
                da.Fill(dt);
                datatab.DataSource = dt;
            }
            else
            {
                doldur();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doldur();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE customername = N'" + comboBox1.SelectedItem.ToString() + "'" + " AND mrp_calculation.requirement != 0";

                if (comboBox2.SelectedIndex != -1)
                {
                    searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order.id = " + comboBox2.SelectedItem.ToString() + " AND mrp_calculation.requirement != 0";

                    if (comboBox3.SelectedIndex != -1)
                    {
                        searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order_detail.id = " + sales_order_detail_id + " AND mrp_calculation.requirement != 0";
                    }
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(searchsql, baglan);
                da.Fill(dt);
                datatab.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                string sql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE mrp_calculation.requirement != 0";
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                datatab.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE customername = N'" + comboBox1.SelectedItem.ToString() + "'" + " AND mrp_calculation.requirement = 0";

                if (comboBox2.SelectedIndex != -1)
                {
                    searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order.id = " + comboBox2.SelectedItem.ToString() + " AND mrp_calculation.requirement = 0";

                    if (comboBox3.SelectedIndex != -1)
                    {
                        searchsql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE sales_order_detail.id = " + sales_order_detail_id + " AND mrp_calculation.requirement = 0";
                    }
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(searchsql, baglan);
                da.Fill(dt);
                datatab.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                string sql = "SELECT  customer.customername AS musteri_adi, mrp_calculation.orderdetailid AS siparis_parca_no, mrp_calculation.date_ AS gorev_tarihi, item.itemname AS ana_urun, item2.itemname AS alt_urun, mrp_calculation.mainamount AS ana_urun_miktar, mrp_calculation.childamount AS alt_urun_gerekli_miktar, item2.unitcode AS alt_urun_birim, mrp_calculation.stock AS alt_urun_stok_miktar, mrp_calculation.requirement AS alt_urun_gereken_sonuc_miktar, mrp_calculation.supplytype AS alt_urun_tedarik_turu FROM mrp_calculation JOIN item ON item.id = mrp_calculation.mainitemid JOIN item AS item2 ON item2.id = mrp_calculation.childitemid JOIN sales_order_detail ON sales_order_detail.id = mrp_calculation.orderdetailid JOIN sales_order ON sales_order.id = sales_order_detail.orderid JOIN customer ON sales_order.customerid = customer.id WHERE mrp_calculation.requirement = 0";
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                datatab.DataSource = dt;
            }
        }
    }
}
