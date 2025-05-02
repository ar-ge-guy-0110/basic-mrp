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
    public partial class fm_customers_customertrac : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static TextBox ref_txtCtCode { get; set; }
        public static TextBox ref_txtCtName { get; set; }
        public static TextBox ref_txtCtComName { get; set; }
        public static TextBox ref_txtCtAddress { get; set; }
        public static TextBox ref_txtCtTaxNo { get; set; }
        public static TextBox ref_txtCtPhoneNum { get; set; }
        #endregion

        #region critics
        public fm_customers_customertrac()
        {
            InitializeComponent();
        }

        private void fm_customers_customertrac_Load(object sender, EventArgs e)
        {
            ref_txtCtCode = txtCtCode;
            ref_txtCtName = txtCtName;
            ref_txtCtComName = txtCtComName;
            ref_txtCtAddress = txtCtAddress;
            ref_txtCtTaxNo = txtCtTaxNo;
            ref_txtCtPhoneNum = txtCtPhoneNum;
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCtCode_Enter(object sender, EventArgs e)
        {
            if (txtCtCode.Text == "Müşteri Kodu")
            {
                txtCtCode.Text = "";
                txtCtCode.ForeColor = Color.White;
            }
        }

        private void txtCtCode_Leave(object sender, EventArgs e)
        {
            if (txtCtCode.Text == "")
            {
                txtCtCode.Text = "Müşteri Kodu";
                txtCtCode.ForeColor = Color.LightGray;
            }
        }

        private void txtCtName_Enter(object sender, EventArgs e)
        {
            if (txtCtName.Text == "Müşteri Adı")
            {
                txtCtName.Text = "";
                txtCtName.ForeColor = Color.White;
            }
        }

        private void txtCtName_Leave(object sender, EventArgs e)
        {
            if (txtCtName.Text == "")
            {
                txtCtName.Text = "Müşteri Adı";
                txtCtName.ForeColor = Color.LightGray;
            }
        }

        private void txtCtComName_Enter(object sender, EventArgs e)
        {
            if (txtCtComName.Text == "Müşteri Ticari Ünvanı")
            {
                txtCtComName.Text = "";
                txtCtComName.ForeColor = Color.White;
            }
        }

        private void txtCtComName_Leave(object sender, EventArgs e)
        {
            if (txtCtComName.Text == "")
            {
                txtCtComName.Text = "Müşteri Ticari Ünvanı";
                txtCtComName.ForeColor = Color.LightGray;
            }
        }

        private void txtCtAddress_Enter(object sender, EventArgs e)
        {
            if (txtCtAddress.Text == "Adresi")
            {
                txtCtAddress.Text = "";
                txtCtAddress.ForeColor = Color.White;
            }
        }

        private void txtCtAddress_Leave(object sender, EventArgs e)
        {
            if (txtCtAddress.Text == "")
            {
                txtCtAddress.Text = "Adresi";
                txtCtAddress.ForeColor = Color.LightGray;
            }
        }

        private void txtCtTaxNo_Enter(object sender, EventArgs e)
        {
            if (txtCtTaxNo.Text == "Vergi No")
            {
                txtCtTaxNo.Text = "";
                txtCtTaxNo.ForeColor = Color.White;
            }
        }

        private void txtCtTaxNo_Leave(object sender, EventArgs e)
        {
            if (txtCtTaxNo.Text == "")
            {
                txtCtTaxNo.Text = "Vergi No";
                txtCtTaxNo.ForeColor = Color.LightGray;
            }
        }

        private void txtCtPhoneNum_Enter(object sender, EventArgs e)
        {
            if (txtCtPhoneNum.Text == "Telefon Numarası")
            {
                txtCtPhoneNum.Text = "";
                txtCtPhoneNum.ForeColor = Color.White;
            }
        }

        private void txtCtPhoneNum_Leave(object sender, EventArgs e)
        {
            if (txtCtPhoneNum.Text == "")
            {
                txtCtPhoneNum.Text = "Telefon Numarası";
                txtCtPhoneNum.ForeColor = Color.LightGray;
            }
        }

        private void upsidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void brick01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void brick03_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void brick02_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }

        private void fm_customers_customertrac_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cs_fmstyle.ReleaseCapture();
                cs_fmstyle.SendMessage(Handle, cs_fmstyle.WM_NCLBUTTONDOWN, cs_fmstyle.HT_CAPTION, 0);
            }
        }
        #endregion

        #region funcs
        private void fillproduct()
        {
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', customer.customercode AS 'Müşteri Kodu', 
            customer.customername AS 'Müşteri Adı', customer.cst_commer_title AS 'Ticari Ünvanı',
            customer.address AS 'Müşteri Adresi', customer.taxno AS 'Vergi No',
            customer.telno AS 'Telefon Numarası' FROM customer", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            fm_customers.ref_dataGridView1.DataSource = dt;
        }

        #endregion

        #region events
        #endregion

        #region parts
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtCtCode.Text != "" && txtCtCode.Text != "Müşteri Kodu") && (txtCtName.Text != "" && txtCtName.Text != "Müşteri Adı") && (txtCtComName.Text != "" && txtCtComName.Text != "Maliyet Ticari Ünvanı") && (txtCtAddress.Text != "" && txtCtAddress.Text != "Adresi") && (txtCtTaxNo.Text != "" && txtCtTaxNo.Text != "Vergi No") && (txtCtPhoneNum.Text != "" && txtCtPhoneNum.Text != "Telefon Numarası"))
                {
                    DataTable controlnameandcodeandcomname = new DataTable();
                    string sql = "SELECT  customercode, customername, cst_commer_title FROM customer WHERE customercode = N'" + txtCtCode.Text + "' OR customername = N'" + txtCtName.Text + "' OR cst_commer_title = N'" + txtCtComName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnameandcodeandcomname);

                    if (controlnameandcodeandcomname.Rows.Count == 0)
                    {
                        SqlCommand addcustomer = new SqlCommand("INSERT INTO customer(customercode, customername, cst_commer_title, address, taxno, telno)" +
                        "VALUES(@ccode, @cname, @ccname, @caddress, @ctaxno, @ctelno)", conn);
                        addcustomer.Parameters.AddWithValue("@ccode", SqlDbType.NVarChar).Value = txtCtCode.Text;
                        addcustomer.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = txtCtName.Text;
                        addcustomer.Parameters.AddWithValue("@ccname", SqlDbType.NVarChar).Value = txtCtComName.Text;
                        addcustomer.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = txtCtAddress.Text;
                        addcustomer.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = txtCtTaxNo.Text;
                        addcustomer.Parameters.AddWithValue("@ctelno", SqlDbType.VarChar).Value = txtCtPhoneNum.Text;

                        conn.Open();
                        addcustomer.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();
                    }
                    else
                    {
                        MessageBox.Show("Aynı isime, koda veya ticari ünvana sahip öğe halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün bilgileri girdiğinizden emin olunuz.");
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (fm_customers.id != -1)
                {
                    //delete mrpcalc datas and delete sales_order_detail
                    SqlCommand fetchcustomerssalesorders = new SqlCommand("SELECT id FROM sales_order WHERE customerid = " + fm_customers.id, conn);
                    DataTable sales_orderidtable = new DataTable();
                    SqlDataAdapter sales_orderidtableda = new SqlDataAdapter(fetchcustomerssalesorders);
                    sales_orderidtableda.Fill(sales_orderidtable);

                    foreach(DataRow row in sales_orderidtable.Rows)
                    {
                        SqlCommand fetchcalcdata = new SqlCommand("SELECT id FROM sales_order_detail WHERE orderid = " + Convert.ToInt32(row[0]), conn);
                        DataTable sales_order_detailidtable = new DataTable();
                        SqlDataAdapter sales_order_detailidtableda = new SqlDataAdapter(fetchcalcdata);
                        sales_order_detailidtableda.Fill(sales_order_detailidtable);
                        
                        foreach(DataRow row2 in sales_order_detailidtable.Rows)
                        {
                            try
                            {
                                SqlCommand deletecustomerordercalcdata = new SqlCommand("DELETE FROM CALCULDEBUG WHERE orderdetailid = @orderdetailid", conn);
                                deletecustomerordercalcdata.Parameters.AddWithValue("@orderdetailid", SqlDbType.Int).Value = Convert.ToInt32(row2[0]);

                                conn.Open();
                                deletecustomerordercalcdata.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch(Exception ex)
                            {
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();
                                }
                                MessageBox.Show(ex.Message);
                            }


                        }

                        try
                        {
                            SqlCommand deletecustomersorderdetails = new SqlCommand("DELETE FROM sales_order_detail WHERE orderid = @orderid", conn);
                            deletecustomersorderdetails.Parameters.AddWithValue("@orderid", SqlDbType.Int).Value = Convert.ToInt32(row[0]);

                            conn.Open();
                            deletecustomersorderdetails.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch(Exception ex2)
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            MessageBox.Show(ex2.Message);
                        }


                    }


                    //delete sales_order
                    SqlCommand deletecustomersorders = new SqlCommand("DELETE FROM sales_order WHERE customerid = @id", conn);
                    deletecustomersorders.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_customers.id;

                    conn.Open();
                    deletecustomersorders.ExecuteNonQuery();
                    conn.Close();
                    //then delete customer...

                    SqlCommand deletecustomer = new SqlCommand("DELETE FROM customer WHERE id=@id", conn);
                    deletecustomer.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_customers.id;

                    conn.Open();
                    deletecustomer.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();
                    fm_customers.id = -1;
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
                }
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (fm_customers.id != -1 && (txtCtCode.Text != "" && txtCtCode.Text != "Müşteri Kodu") && (txtCtName.Text != "" && txtCtName.Text != "Müşteri Adı") && (txtCtComName.Text != "" && txtCtComName.Text != "Maliyet Ticari Ünvanı") && (txtCtAddress.Text != "" && txtCtAddress.Text != "Adresi") && (txtCtTaxNo.Text != "" && txtCtTaxNo.Text != "Vergi No") && (txtCtPhoneNum.Text != "" && txtCtPhoneNum.Text != "Telefon Numarası"))
                {
                    DataTable controlnameandcodeandcomname = new DataTable();
                    string sql = "SELECT  customercode, customername, cst_commer_title FROM customer WHERE customercode = N'" + txtCtCode.Text + "' OR customername = N'" + txtCtName.Text + "' OR cst_commer_title = N'" + txtCtComName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnameandcodeandcomname);

                    if (controlnameandcodeandcomname.Rows.Count == 0)
                    {
                        SqlCommand updatecustomer = new SqlCommand("UPDATE customer SET customercode = @ccode, customername = @cname, cst_commer_title = @ccname, address = @caddress, taxno = @ctaxno, telno = @ctelno WHERE id = @id", conn);
                        updatecustomer.Parameters.AddWithValue("@ccode", SqlDbType.NVarChar).Value = txtCtCode.Text;
                        updatecustomer.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = txtCtName.Text;
                        updatecustomer.Parameters.AddWithValue("@ccname", SqlDbType.NVarChar).Value = txtCtComName.Text;
                        updatecustomer.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = txtCtAddress.Text;
                        updatecustomer.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = txtCtTaxNo.Text;
                        updatecustomer.Parameters.AddWithValue("@ctelno", SqlDbType.VarChar).Value = txtCtPhoneNum.Text;
                        updatecustomer.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_customers.id;

                        conn.Open();
                        updatecustomer.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();


                    }
                    else
                    {
                        MessageBox.Show("Aynı isime, koda veya ticari ünvana sahip öğe halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
                }
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        #endregion


    }
}
