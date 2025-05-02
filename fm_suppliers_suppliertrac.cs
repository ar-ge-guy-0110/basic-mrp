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
    public partial class fm_suppliers_suppliertrac : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static TextBox ref_txtSpCode { get; set; }
        public static TextBox ref_txtSpName { get; set; }
        public static TextBox ref_txtSpAddress { get; set; }
        public static TextBox ref_txtSpTaxNo { get; set; }
        public static TextBox ref_txtSpPhoneNum { get; set; }
        #endregion

        #region critics
        public fm_suppliers_suppliertrac()
        {
            InitializeComponent();
        }

        private void fm_suppliers_suppliertrac_Load(object sender, EventArgs e)
        {
            ref_txtSpCode = txtSpCode;
            ref_txtSpName = txtSpName;
            ref_txtSpAddress = txtSpAddress;
            ref_txtSpTaxNo = txtSpTaxNo;
            ref_txtSpPhoneNum = txtSpPhoneNum;
        }
        #endregion

        #region UI
        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSpCode_Enter(object sender, EventArgs e)
        {
            if (txtSpCode.Text == "Tedarikci Kodu")
            {
                txtSpCode.Text = "";
                txtSpCode.ForeColor = Color.White;
            }
        }

        private void txtSpCode_Leave(object sender, EventArgs e)
        {
            if (txtSpCode.Text == "")
            {
                txtSpCode.Text = "Tedarikci Kodu";
                txtSpCode.ForeColor = Color.LightGray;
            }
        }

        private void txtSpName_Enter(object sender, EventArgs e)
        {
            if (txtSpName.Text == "Tedarikci Adı")
            {
                txtSpName.Text = "";
                txtSpName.ForeColor = Color.White;
            }
        }

        private void txtSpName_Leave(object sender, EventArgs e)
        {
            if (txtSpName.Text == "")
            {
                txtSpName.Text = "Tedarikci Adı";
                txtSpName.ForeColor = Color.LightGray;
            }
        }

        private void txtSpAddress_Enter(object sender, EventArgs e)
        {
            if (txtSpAddress.Text == "Adresi")
            {
                txtSpAddress.Text = "";
                txtSpAddress.ForeColor = Color.White;
            }
        }

        private void txtSpAddress_Leave(object sender, EventArgs e)
        {
            if (txtSpAddress.Text == "")
            {
                txtSpAddress.Text = "Adresi";
                txtSpAddress.ForeColor = Color.LightGray;
            }
        }

        private void txtSpTaxNo_Enter(object sender, EventArgs e)
        {
            if (txtSpTaxNo.Text == "Vergi No")
            {
                txtSpTaxNo.Text = "";
                txtSpTaxNo.ForeColor = Color.White;
            }
        }

        private void txtSpTaxNo_Leave(object sender, EventArgs e)
        {
            if (txtSpTaxNo.Text == "")
            {
                txtSpTaxNo.Text = "Vergi No";
                txtSpTaxNo.ForeColor = Color.LightGray;
            }
        }

        private void txtSpPhoneNum_Enter(object sender, EventArgs e)
        {
            if (txtSpPhoneNum.Text == "Telefon Numarası")
            {
                txtSpPhoneNum.Text = "";
                txtSpPhoneNum.ForeColor = Color.White;
            }
        }

        private void txtSpPhoneNum_Leave(object sender, EventArgs e)
        {
            if (txtSpPhoneNum.Text == "")
            {
                txtSpPhoneNum.Text = "Telefon Numarası";
                txtSpPhoneNum.ForeColor = Color.LightGray;
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

        private void fm_suppliers_suppliertrac_MouseDown(object sender, MouseEventArgs e)
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
            SqlCommand fill = new SqlCommand(@"SELECT id AS 'ID', suppliercode AS 'Tedarikci Kodu', 
            suppliername AS 'Tedarikci Adı', address AS 'Adresi', 
            taxno AS 'Vergi No', telno AS 'Telefon Numarası' FROM supplier", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(fill);
            da.Fill(dt);
            fm_suppliers.ref_dataGridView1.DataSource = dt;
        }

        #endregion

        #region events
        #endregion

        #region parts
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtSpCode.Text != "" && txtSpCode.Text != "Tedarikci Kodu") && (txtSpName.Text != "" && txtSpName.Text != "Tedarikci Adı") && (txtSpAddress.Text != "" && txtSpAddress.Text != "Adresi") && (txtSpTaxNo.Text != "" && txtSpTaxNo.Text != "Vergi No") && (txtSpPhoneNum.Text != "" && txtSpPhoneNum.Text != "Telefon Numarası"))
                {
                    DataTable controlnameandcode = new DataTable();
                    string sql = "SELECT  suppliercode, suppliername FROM supplier WHERE suppliercode = N'" + txtSpCode.Text + "' OR suppliername = N'" + txtSpName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnameandcode);

                    if (controlnameandcode.Rows.Count == 0)
                    {
                        SqlCommand addsupplier = new SqlCommand("INSERT INTO supplier(suppliercode, suppliername, address, taxno, telno)" +
                        "VALUES(@ccode, @cname, @caddress, @ctaxno, @ctelno)", conn);
                        addsupplier.Parameters.AddWithValue("@ccode", SqlDbType.NVarChar).Value = txtSpCode.Text;
                        addsupplier.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = txtSpName.Text;
                        addsupplier.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = txtSpAddress.Text;
                        addsupplier.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = txtSpTaxNo.Text;
                        addsupplier.Parameters.AddWithValue("@ctelno", SqlDbType.VarChar).Value = txtSpPhoneNum.Text;

                        conn.Open();
                        addsupplier.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();
                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip öğe halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
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
                if (fm_suppliers.id != -1)
                {
                    //delete calc datas and delete order_detail
                    SqlCommand fetchcustomerssalesorders = new SqlCommand("SELECT id FROM purchase_order WHERE supplierid = " + fm_suppliers.id, conn);
                    DataTable sales_orderidtable = new DataTable();
                    SqlDataAdapter sales_orderidtableda = new SqlDataAdapter(fetchcustomerssalesorders);
                    sales_orderidtableda.Fill(sales_orderidtable);

                    foreach (DataRow row in sales_orderidtable.Rows)
                    {
                        SqlCommand fetchcalcdata = new SqlCommand("SELECT id FROM purchase_order_detail WHERE orderid = " + Convert.ToInt32(row[0]), conn);
                        DataTable sales_order_detailidtable = new DataTable();
                        SqlDataAdapter sales_order_detailidtableda = new SqlDataAdapter(fetchcalcdata);
                        sales_order_detailidtableda.Fill(sales_order_detailidtable);

                        //foreach (DataRow row2 in sales_order_detailidtable.Rows)
                        //{
                        //    try
                        //    {
                        //        SqlCommand deletecustomerordercalcdata = new SqlCommand("DELETE FROM CALCULDEBUG WHERE orderdetailid = @orderdetailid", conn);
                        //        deletecustomerordercalcdata.Parameters.AddWithValue("@orderdetailid", SqlDbType.Int).Value = Convert.ToInt32(row2[0]);
                        //
                        //        conn.Open();
                        //        deletecustomerordercalcdata.ExecuteNonQuery();
                        //        conn.Close();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        if (conn.State == ConnectionState.Open)
                        //        {
                        //            conn.Close();
                        //        }
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //
                        //
                        //}

                        try
                        {
                            SqlCommand deletecustomersorderdetails = new SqlCommand("DELETE FROM purchase_order_detail WHERE orderid = @orderid", conn);
                            deletecustomersorderdetails.Parameters.AddWithValue("@orderid", SqlDbType.Int).Value = Convert.ToInt32(row[0]);

                            conn.Open();
                            deletecustomersorderdetails.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception ex2)
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            MessageBox.Show(ex2.Message);
                        }


                    }

                    //delete purchase_order
                    SqlCommand deletecustomersorders = new SqlCommand("DELETE FROM purchase_order WHERE supplierid = @id", conn);
                    deletecustomersorders.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_suppliers.id;
                    
                    conn.Open();
                    deletecustomersorders.ExecuteNonQuery();
                    conn.Close();
                    //then delete supplier...

                    SqlCommand deletesupplier = new SqlCommand("DELETE FROM supplier WHERE id=@id", conn);
                    deletesupplier.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_suppliers.id;

                    conn.Open();
                    deletesupplier.ExecuteNonQuery();
                    conn.Close();

                    fillproduct();
                    fm_suppliers.id = -1;
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
                if (fm_suppliers.id != -1 && (txtSpCode.Text != "" && txtSpCode.Text != "Tedarikci Kodu") && (txtSpName.Text != "" && txtSpName.Text != "Tedarikci Adı") && (txtSpAddress.Text != "" && txtSpAddress.Text != "Adresi") && (txtSpTaxNo.Text != "" && txtSpTaxNo.Text != "Vergi No") && (txtSpPhoneNum.Text != "" && txtSpPhoneNum.Text != "Telefon Numarası"))
                {
                    DataTable controlnameandcode = new DataTable();
                    string sql = "SELECT  suppliercode, suppliername FROM supplier WHERE suppliercode = N'" + txtSpCode.Text + "' OR suppliername = N'" + txtSpName.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(controlnameandcode);

                    if (controlnameandcode.Rows.Count == 0)
                    {
                        SqlCommand updatesupplier = new SqlCommand("UPDATE supplier SET suppliercode = @ccode, suppliername = @cname, address = @caddress, taxno = @ctaxno, telno = @ctelno " +
                        "WHERE id = @id", conn);
                        updatesupplier.Parameters.AddWithValue("@ccode", SqlDbType.NVarChar).Value = txtSpCode.Text;
                        updatesupplier.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = txtSpName.Text;
                        updatesupplier.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = txtSpAddress.Text;
                        updatesupplier.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = txtSpTaxNo.Text;
                        updatesupplier.Parameters.AddWithValue("@ctelno", SqlDbType.VarChar).Value = txtSpPhoneNum.Text;
                        updatesupplier.Parameters.AddWithValue("@id", SqlDbType.Int).Value = fm_suppliers.id;

                        conn.Open();
                        updatesupplier.ExecuteNonQuery();
                        conn.Close();

                        fillproduct();
                    }
                    else
                    {
                        MessageBox.Show("Aynı isime veya koda sahip öğe halihazırda bulunmaktadır. Lütfen başka isimler deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
                }
            }
            catch(Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Şu an işlem gerçekleşemiyor. Lütfen daha sonra tekrar deneyiniz.");
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


    }
}
