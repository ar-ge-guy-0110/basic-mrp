
namespace BasicMRP
{
    partial class fm_suppliers_orders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_suppliers_orders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.panelCustomerData = new System.Windows.Forms.Panel();
            this.lbCtPhoneNum = new System.Windows.Forms.Label();
            this.lbCtTaxNo = new System.Windows.Forms.Label();
            this.lbCtAddress = new System.Windows.Forms.Label();
            this.lbCtCode = new System.Windows.Forms.Label();
            this.lbCtName = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnOrderDetail = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSpCurrency = new System.Windows.Forms.TextBox();
            this.txtSpPrice = new System.Windows.Forms.TextBox();
            this.upsidePanel.SuspendLayout();
            this.panelCustomerData.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // upsidePanel
            // 
            this.upsidePanel.Controls.Add(this.exitLabel);
            this.upsidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upsidePanel.Location = new System.Drawing.Point(0, 0);
            this.upsidePanel.Name = "upsidePanel";
            this.upsidePanel.Size = new System.Drawing.Size(1050, 30);
            this.upsidePanel.TabIndex = 5;
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitLabel.AutoSize = true;
            this.exitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.exitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.exitLabel.Location = new System.Drawing.Point(1030, 9);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(17, 17);
            this.exitLabel.TabIndex = 0;
            this.exitLabel.Text = "X";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // panelCustomerData
            // 
            this.panelCustomerData.Controls.Add(this.lbCtPhoneNum);
            this.panelCustomerData.Controls.Add(this.lbCtTaxNo);
            this.panelCustomerData.Controls.Add(this.lbCtAddress);
            this.panelCustomerData.Controls.Add(this.lbCtCode);
            this.panelCustomerData.Controls.Add(this.lbCtName);
            this.panelCustomerData.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerData.Location = new System.Drawing.Point(0, 30);
            this.panelCustomerData.Name = "panelCustomerData";
            this.panelCustomerData.Size = new System.Drawing.Size(1050, 100);
            this.panelCustomerData.TabIndex = 6;
            // 
            // lbCtPhoneNum
            // 
            this.lbCtPhoneNum.AutoSize = true;
            this.lbCtPhoneNum.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.lbCtPhoneNum.ForeColor = System.Drawing.Color.LightGray;
            this.lbCtPhoneNum.Location = new System.Drawing.Point(669, 47);
            this.lbCtPhoneNum.Name = "lbCtPhoneNum";
            this.lbCtPhoneNum.Size = new System.Drawing.Size(88, 20);
            this.lbCtPhoneNum.TabIndex = 7;
            this.lbCtPhoneNum.Text = "Telefon No:";
            // 
            // lbCtTaxNo
            // 
            this.lbCtTaxNo.AutoSize = true;
            this.lbCtTaxNo.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.lbCtTaxNo.ForeColor = System.Drawing.Color.LightGray;
            this.lbCtTaxNo.Location = new System.Drawing.Point(669, 12);
            this.lbCtTaxNo.Name = "lbCtTaxNo";
            this.lbCtTaxNo.Size = new System.Drawing.Size(73, 20);
            this.lbCtTaxNo.TabIndex = 6;
            this.lbCtTaxNo.Text = "Vergi No:";
            // 
            // lbCtAddress
            // 
            this.lbCtAddress.AutoSize = true;
            this.lbCtAddress.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.lbCtAddress.ForeColor = System.Drawing.Color.LightGray;
            this.lbCtAddress.Location = new System.Drawing.Point(12, 77);
            this.lbCtAddress.Name = "lbCtAddress";
            this.lbCtAddress.Size = new System.Drawing.Size(54, 20);
            this.lbCtAddress.TabIndex = 5;
            this.lbCtAddress.Text = "Adresi:";
            // 
            // lbCtCode
            // 
            this.lbCtCode.AutoSize = true;
            this.lbCtCode.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.lbCtCode.ForeColor = System.Drawing.Color.LightGray;
            this.lbCtCode.Location = new System.Drawing.Point(12, 47);
            this.lbCtCode.Name = "lbCtCode";
            this.lbCtCode.Size = new System.Drawing.Size(48, 20);
            this.lbCtCode.TabIndex = 3;
            this.lbCtCode.Text = "Kodu:";
            // 
            // lbCtName
            // 
            this.lbCtName.AutoSize = true;
            this.lbCtName.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.lbCtName.ForeColor = System.Drawing.Color.LightGray;
            this.lbCtName.Location = new System.Drawing.Point(12, 12);
            this.lbCtName.Name = "lbCtName";
            this.lbCtName.Size = new System.Drawing.Size(126, 20);
            this.lbCtName.TabIndex = 2;
            this.lbCtName.Text = "Seçilen Tedarikci:";
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.txtSpPrice);
            this.panelSearch.Controls.Add(this.txtSpCurrency);
            this.panelSearch.Controls.Add(this.dateTimePicker2);
            this.panelSearch.Controls.Add(this.dateTimePicker1);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnList);
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearch.Location = new System.Drawing.Point(0, 130);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(200, 470);
            this.panelSearch.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Malgun Gothic", 11F);
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.LightGray;
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(5)))));
            this.dateTimePicker2.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker2.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.dateTimePicker2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTimePicker2.Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.dateTimePicker2.Location = new System.Drawing.Point(0, 27);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Malgun Gothic", 11F);
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.LightGray;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(5)))));
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnSearch.ForeColor = System.Drawing.Color.LightGray;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(0, 350);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 40);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Ara";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnList
            // 
            this.btnList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnList.ForeColor = System.Drawing.Color.LightGray;
            this.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.Location = new System.Drawing.Point(0, 390);
            this.btnList.Margin = new System.Windows.Forms.Padding(0);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(200, 40);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "Hepsini Göster";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnClear.ForeColor = System.Drawing.Color.LightGray;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(0, 430);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(200, 40);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Seçimleri Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnOrderDetail);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(200, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(850, 100);
            this.panelButtons.TabIndex = 8;
            // 
            // btnOrderDetail
            // 
            this.btnOrderDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrderDetail.FlatAppearance.BorderSize = 0;
            this.btnOrderDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOrderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderDetail.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnOrderDetail.ForeColor = System.Drawing.Color.LightGray;
            this.btnOrderDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderDetail.Image")));
            this.btnOrderDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderDetail.Location = new System.Drawing.Point(554, 31);
            this.btnOrderDetail.Name = "btnOrderDetail";
            this.btnOrderDetail.Size = new System.Drawing.Size(250, 40);
            this.btnOrderDetail.TabIndex = 7;
            this.btnOrderDetail.Text = "Sipariş Detayları";
            this.btnOrderDetail.UseVisualStyleBackColor = true;
            this.btnOrderDetail.Click += new System.EventHandler(this.btnOrderDetail_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnDelete.ForeColor = System.Drawing.Color.LightGray;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(298, 31);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(250, 40);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnAdd.ForeColor = System.Drawing.Color.LightGray;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(42, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(250, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.dataGridView1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(200, 130);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(850, 370);
            this.panelContainer.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(850, 370);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // txtSpCurrency
            // 
            this.txtSpCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpCurrency.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpCurrency.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpCurrency.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpCurrency.Location = new System.Drawing.Point(0, 54);
            this.txtSpCurrency.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpCurrency.MaxLength = 6;
            this.txtSpCurrency.Name = "txtSpCurrency";
            this.txtSpCurrency.Size = new System.Drawing.Size(200, 31);
            this.txtSpCurrency.TabIndex = 14;
            this.txtSpCurrency.Text = "Para Birimi";
            this.txtSpCurrency.Enter += new System.EventHandler(this.txtSpCurrency_Enter);
            this.txtSpCurrency.Leave += new System.EventHandler(this.txtSpCurrency_Leave);
            // 
            // txtSpPrice
            // 
            this.txtSpPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpPrice.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpPrice.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpPrice.Location = new System.Drawing.Point(0, 85);
            this.txtSpPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpPrice.MaxLength = 50;
            this.txtSpPrice.Name = "txtSpPrice";
            this.txtSpPrice.Size = new System.Drawing.Size(200, 31);
            this.txtSpPrice.TabIndex = 15;
            this.txtSpPrice.Text = "Toplam Fiyat";
            this.txtSpPrice.Enter += new System.EventHandler(this.txtSpPrice_Enter);
            this.txtSpPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpPrice_KeyPress);
            this.txtSpPrice.Leave += new System.EventHandler(this.txtSpPrice_Leave);
            // 
            // fm_suppliers_orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelCustomerData);
            this.Controls.Add(this.upsidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fm_suppliers_orders";
            this.Text = "fm_suppliers_orders";
            this.Load += new System.EventHandler(this.fm_suppliers_orders_Load);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.panelCustomerData.ResumeLayout(false);
            this.panelCustomerData.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel panelCustomerData;
        private System.Windows.Forms.Label lbCtPhoneNum;
        private System.Windows.Forms.Label lbCtTaxNo;
        private System.Windows.Forms.Label lbCtAddress;
        private System.Windows.Forms.Label lbCtCode;
        private System.Windows.Forms.Label lbCtName;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnOrderDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSpPrice;
        private System.Windows.Forms.TextBox txtSpCurrency;
    }
}