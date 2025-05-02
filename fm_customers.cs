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
    public partial class fm_customers : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static int id { get; set; }
        public static string customer_name { get; set; }
        public static string customer_code { get; set; }
        public static string customer_comname { get; set; }
        public static string customer_address { get; set; }
        public static string customer_taxno { get; set; }
        public static string customer_phonenum { get; set; }
        public static DataGridView ref_dataGridView1 { get; set; }
        #endregion

        #region critics
        public fm_customers()
        {
            InitializeComponent();
        }

        private void fm_customers_Load(object sender, EventArgs e)
        {
            id = -1;
            fillproduct();
            ref_dataGridView1 = dataGridView1;
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
            dataGridView1.DataSource = dt;
        }

        private void OpenFuncForm(object FormChild, string form_name)
        {
            if (Application.OpenForms[form_name] != null)
            {

            }
            else
            {
                Form fc = FormChild as Form;
                fc.BringToFront();
                //fc.FormClosed += new FormClosedEventHandler(fillproductobjectsender);
                fc.Show();

            }
        }

        private void OpenFormInMainPanel(object FormChild, string form_name)
        {
            foreach (Control item in fm_adminpanel.ref_ContainerPanel.Controls)
            {
                if (item.Name == form_name)
                {
                    fm_adminpanel.ref_ContainerPanel.Controls.Remove(item);
                    item.Dispose();
                }
            }


            Form fc = FormChild as Form;
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            fm_adminpanel.ref_ContainerPanel.Controls.Add(fc);
            fc.BringToFront();
            //fc.FormClosed += new FormClosedEventHandler(fillproductobjectsender);
            fc.Show();


        }

        #endregion

        #region events
        private void fm_customers_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (Application.OpenForms["fm_customers_customertrac"] != null)
            {
                Application.OpenForms["fm_customers_customertrac"].Close();
            }
        }

        private void fm_customers_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["fm_customers_customertrac"] != null)
            {
                Application.OpenForms["fm_customers_customertrac"].Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (Application.OpenForms["fm_customers_customertrac"] != null)
                    {
                        fm_customers_customertrac.ref_txtCtCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        fm_customers_customertrac.ref_txtCtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        fm_customers_customertrac.ref_txtCtComName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        fm_customers_customertrac.ref_txtCtAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        fm_customers_customertrac.ref_txtCtTaxNo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        fm_customers_customertrac.ref_txtCtPhoneNum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        Application.OpenForms["fm_customers_customertrac"].BringToFront();
                    }
                    txtCtCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtCtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtCtComName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtCtAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtCtTaxNo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    txtCtPhoneNum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    
                    customer_name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    customer_code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    customer_comname = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    customer_address = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    customer_taxno = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    customer_phonenum = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lütfen doğru satırı seçin.");
            }
        }

        #endregion

        #region parts
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "";

            string cmd_start = "SELECT";
            string cmd_middle = @" customer.id AS 'ID', customer.customercode AS 'Müşteri Kodu', 
            customer.customername AS 'Müşteri Adı', customer.cst_commer_title AS 'Ticari Ünvanı', 
            customer.address AS 'Müşteri Adresi', customer.taxno AS 'Vergi No', 
            customer.telno AS 'Telefon Numarası' ";
            string cmd_end = @"FROM  customer WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtCtCode.Text != "")
            {
                if (txtCtCode.Text == "Müşteri Kodu")
                {
                    txtCtCode.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " customercode LIKE N'%" + txtCtCode.Text + "%'";
            }

            if (txtCtName.Text != "")
            {
                if (txtCtName.Text == "Müşteri Adı")
                {
                    txtCtName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " customername LIKE N'%" + txtCtName.Text + "%'";
            }

            if (txtCtComName.Text != "")
            {
                if (txtCtComName.Text == "Müşteri Ticari Ünvanı")
                {
                    txtCtComName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " cst_commer_title LIKE N'%" + txtCtComName.Text + "%'";
            }
            
            if (txtCtAddress.Text != "")
            {
                if (txtCtAddress.Text == "Adresi")
                {
                    txtCtAddress.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " address LIKE N'%" + txtCtAddress.Text + "%'";
            }
            
            if (txtCtTaxNo.Text != "")
            {
                if (txtCtTaxNo.Text == "Vergi No")
                {
                    txtCtTaxNo.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " taxno LIKE N'%" + txtCtTaxNo.Text + "%'";
            }
            
            if (txtCtPhoneNum.Text != "")
            {
                if (txtCtPhoneNum.Text == "Telefon Numarası")
                {
                    txtCtPhoneNum.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " telno LIKE N'%" + txtCtPhoneNum.Text + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if ((txtCtCode.Text != "" && txtCtCode.Text != "Müşteri Kodu") || (txtCtName.Text != "" && txtCtName.Text != "Müşteri Adı") || (txtCtComName.Text != "" && txtCtComName.Text != "Müşteri Ticari Ünvanı") || (txtCtAddress.Text != "" && txtCtAddress.Text != "Adresi") || (txtCtTaxNo.Text != "" && txtCtTaxNo.Text != "Vergi No") || (txtCtPhoneNum.Text != "" && txtCtPhoneNum.Text != "Telefon Numarası"))
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(search, conn);
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
            else
            {
                fillproduct();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            fillproduct();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            id = -1;
            txtCtCode.Text = "Müşteri Kodu";
            txtCtName.Text = "Müşteri Adı";
            txtCtComName.Text = "Müşteri Ticari Ünvanı";
            txtCtAddress.Text = "Adresi";
            txtCtTaxNo.Text = "Vergi No";
            txtCtPhoneNum.Text = "Telefon Numarası";
        }

        private void btnCtTrac_Click(object sender, EventArgs e)
        {
            OpenFuncForm(new fm_customers_customertrac(), "fm_customers_customertrac");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                OpenFormInMainPanel(new fm_customers_orders(), "fm_customers_orders");
            }
            else
            {
                MessageBox.Show("Lütfen işlemler için istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
            }


        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            OpenFormInMainPanel(new fm_customers_orderlist(), "fm_customers_orderlist");
        }
        #endregion


    }
}
