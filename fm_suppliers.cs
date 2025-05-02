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
    public partial class fm_suppliers : Form
    {
        #region values
        SqlConnection conn = cs_dbconnections.conn;
        public static int id { get; set; }
        public static string supplier_code { get; set; }
        public static string supplier_name { get; set; }
        public static string supplier_address { get; set; }
        public static string supplier_taxno { get; set; }
        public static string supplier_phonenum { get; set; }
        public static DataGridView ref_dataGridView1 { get; set; }
        #endregion

        #region critics
        public fm_suppliers()
        {
            InitializeComponent();
        }

        private void fm_suppliers_Load(object sender, EventArgs e)
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
        private void fm_suppliers_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["fm_suppliers_suppliertrac"] != null)
            {
                Application.OpenForms["fm_suppliers_suppliertrac"].Close();
            }
        }

        private void fm_suppliers_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (Application.OpenForms["fm_suppliers_suppliertrac"] != null)
            {
                Application.OpenForms["fm_suppliers_suppliertrac"].Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (Application.OpenForms["fm_suppliers_suppliertrac"] != null)
                    {
                        fm_suppliers_suppliertrac.ref_txtSpCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        fm_suppliers_suppliertrac.ref_txtSpName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        fm_suppliers_suppliertrac.ref_txtSpAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        fm_suppliers_suppliertrac.ref_txtSpTaxNo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        fm_suppliers_suppliertrac.ref_txtSpPhoneNum.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        Application.OpenForms["fm_suppliers_suppliertrac"].BringToFront();
                    }
                    txtSpCode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtSpName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtSpAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtSpTaxNo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtSpPhoneNum.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    
                    supplier_name = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    supplier_code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    supplier_address = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    supplier_taxno = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    supplier_phonenum = dataGridView1.CurrentRow.Cells[5].Value.ToString();
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
            string cmd_middle = @" id AS 'ID', suppliercode AS 'Tedarikci Kodu', 
            suppliername AS 'Tedarikci Adı', address AS 'Adresi', 
            taxno AS 'Vergi No', telno AS 'Telefon Numarası' ";
            string cmd_end = @"FROM  supplier WHERE";

            int cmdend_length = cmd_end.Length;

            if (txtSpCode.Text != "")
            {
                if (txtSpCode.Text == "Tedarikci Kodu")
                {
                    txtSpCode.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " suppliercode LIKE N'%" + txtSpCode.Text + "%'";
            }

            if (txtSpName.Text != "")
            {
                if (txtSpName.Text == "Tedarikci Adı")
                {
                    txtSpName.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " suppliername LIKE N'%" + txtSpName.Text + "%'";
            }

            if (txtSpAddress.Text != "")
            {
                if (txtSpAddress.Text == "Adresi")
                {
                    txtSpAddress.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " address LIKE N'%" + txtSpAddress.Text + "%'";
            }

            if (txtSpTaxNo.Text != "")
            {
                if (txtSpTaxNo.Text == "Vergi No")
                {
                    txtSpTaxNo.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " taxno LIKE N'%" + txtSpTaxNo.Text + "%'";
            }

            if (txtSpPhoneNum.Text != "")
            {
                if (txtSpPhoneNum.Text == "Telefon Numarası")
                {
                    txtSpPhoneNum.Text = "";
                }

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " telno LIKE N'%" + txtSpPhoneNum.Text + "%'";
            }

            search = cmd_start + cmd_middle + cmd_end;

            if ((txtSpCode.Text != "" && txtSpCode.Text != "Tedarikci Kodu") || (txtSpName.Text != "" && txtSpName.Text != "Tedarikci Adı") || (txtSpAddress.Text != "" && txtSpAddress.Text != "Adresi") || (txtSpTaxNo.Text != "" && txtSpTaxNo.Text != "Vergi No") || (txtSpPhoneNum.Text != "" && txtSpPhoneNum.Text != "Telefon Numarası"))
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
            txtSpCode.Text = "Tedarikci Kodu";
            txtSpName.Text = "Tedarikci Adı";
            txtSpAddress.Text = "Adresi";
            txtSpTaxNo.Text = "Vergi No";
            txtSpPhoneNum.Text = "Telefon Numarası";
        }

        private void btnCtTrac_Click(object sender, EventArgs e)
        {
            OpenFuncForm(new fm_suppliers_suppliertrac(), "fm_suppliers_suppliertrac");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                OpenFormInMainPanel(new fm_suppliers_orders(), "fm_suppliers_orders");
            }
            else
            {
                MessageBox.Show("Lütfen işlemler için istediğiniz öğeye çift tıklayıp öğeyi seçili hale getiriniz.");
            }
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
