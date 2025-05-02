
namespace BasicMRP
{
    partial class fm_customers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_customers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtCtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtCtTaxNo = new System.Windows.Forms.TextBox();
            this.txtCtAddress = new System.Windows.Forms.TextBox();
            this.txtCtComName = new System.Windows.Forms.TextBox();
            this.txtCtName = new System.Windows.Forms.TextBox();
            this.txtCtCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCtTrac = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.upsidePanel.SuspendLayout();
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
            this.upsidePanel.TabIndex = 3;
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
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.txtCtPhoneNum);
            this.panelSearch.Controls.Add(this.txtCtTaxNo);
            this.panelSearch.Controls.Add(this.txtCtAddress);
            this.panelSearch.Controls.Add(this.txtCtComName);
            this.panelSearch.Controls.Add(this.txtCtName);
            this.panelSearch.Controls.Add(this.txtCtCode);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnList);
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearch.Location = new System.Drawing.Point(0, 30);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(200, 470);
            this.panelSearch.TabIndex = 5;
            // 
            // txtCtPhoneNum
            // 
            this.txtCtPhoneNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtPhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtPhoneNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtPhoneNum.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtPhoneNum.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtPhoneNum.Location = new System.Drawing.Point(0, 155);
            this.txtCtPhoneNum.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtPhoneNum.MaxLength = 12;
            this.txtCtPhoneNum.Name = "txtCtPhoneNum";
            this.txtCtPhoneNum.Size = new System.Drawing.Size(200, 31);
            this.txtCtPhoneNum.TabIndex = 17;
            this.txtCtPhoneNum.Text = "Telefon Numarası";
            this.txtCtPhoneNum.Enter += new System.EventHandler(this.txtCtPhoneNum_Enter);
            this.txtCtPhoneNum.Leave += new System.EventHandler(this.txtCtPhoneNum_Leave);
            // 
            // txtCtTaxNo
            // 
            this.txtCtTaxNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtTaxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtTaxNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtTaxNo.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtTaxNo.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtTaxNo.Location = new System.Drawing.Point(0, 124);
            this.txtCtTaxNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtTaxNo.MaxLength = 30;
            this.txtCtTaxNo.Name = "txtCtTaxNo";
            this.txtCtTaxNo.Size = new System.Drawing.Size(200, 31);
            this.txtCtTaxNo.TabIndex = 16;
            this.txtCtTaxNo.Text = "Vergi No";
            this.txtCtTaxNo.Enter += new System.EventHandler(this.txtCtTaxNo_Enter);
            this.txtCtTaxNo.Leave += new System.EventHandler(this.txtCtTaxNo_Leave);
            // 
            // txtCtAddress
            // 
            this.txtCtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtAddress.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtAddress.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtAddress.Location = new System.Drawing.Point(0, 93);
            this.txtCtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtAddress.MaxLength = 500;
            this.txtCtAddress.Name = "txtCtAddress";
            this.txtCtAddress.Size = new System.Drawing.Size(200, 31);
            this.txtCtAddress.TabIndex = 15;
            this.txtCtAddress.Text = "Adresi";
            this.txtCtAddress.Enter += new System.EventHandler(this.txtCtAddress_Enter);
            this.txtCtAddress.Leave += new System.EventHandler(this.txtCtAddress_Leave);
            // 
            // txtCtComName
            // 
            this.txtCtComName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtComName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtComName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtComName.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtComName.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtComName.Location = new System.Drawing.Point(0, 62);
            this.txtCtComName.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtComName.MaxLength = 100;
            this.txtCtComName.Name = "txtCtComName";
            this.txtCtComName.Size = new System.Drawing.Size(200, 31);
            this.txtCtComName.TabIndex = 14;
            this.txtCtComName.Text = "Müşteri Ticari Ünvanı";
            this.txtCtComName.Enter += new System.EventHandler(this.txtCtComName_Enter);
            this.txtCtComName.Leave += new System.EventHandler(this.txtCtComName_Leave);
            // 
            // txtCtName
            // 
            this.txtCtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtName.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtName.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtName.Location = new System.Drawing.Point(0, 31);
            this.txtCtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtName.MaxLength = 100;
            this.txtCtName.Name = "txtCtName";
            this.txtCtName.Size = new System.Drawing.Size(200, 31);
            this.txtCtName.TabIndex = 13;
            this.txtCtName.Text = "Müşteri Adı";
            this.txtCtName.Enter += new System.EventHandler(this.txtCtName_Enter);
            this.txtCtName.Leave += new System.EventHandler(this.txtCtName_Leave);
            // 
            // txtCtCode
            // 
            this.txtCtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtCode.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtCode.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCtCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtCode.MaxLength = 100;
            this.txtCtCode.Name = "txtCtCode";
            this.txtCtCode.Size = new System.Drawing.Size(200, 31);
            this.txtCtCode.TabIndex = 6;
            this.txtCtCode.Text = "Müşteri Kodu";
            this.txtCtCode.Enter += new System.EventHandler(this.txtCtCode_Enter);
            this.txtCtCode.Leave += new System.EventHandler(this.txtCtCode_Leave);
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
            this.panelButtons.Controls.Add(this.btnOrderList);
            this.panelButtons.Controls.Add(this.btnOrder);
            this.panelButtons.Controls.Add(this.btnCtTrac);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1050, 100);
            this.panelButtons.TabIndex = 4;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrderList.FlatAppearance.BorderSize = 0;
            this.btnOrderList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnOrderList.ForeColor = System.Drawing.Color.LightGray;
            this.btnOrderList.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderList.Image")));
            this.btnOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderList.Location = new System.Drawing.Point(637, 29);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(200, 40);
            this.btnOrderList.TabIndex = 5;
            this.btnOrderList.Text = "       Siparişleri Görüntüle";
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnOrder.ForeColor = System.Drawing.Color.LightGray;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(431, 29);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(200, 40);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "Sipariş İşlemleri";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCtTrac
            // 
            this.btnCtTrac.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCtTrac.FlatAppearance.BorderSize = 0;
            this.btnCtTrac.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCtTrac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCtTrac.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnCtTrac.ForeColor = System.Drawing.Color.LightGray;
            this.btnCtTrac.Image = ((System.Drawing.Image)(resources.GetObject("btnCtTrac.Image")));
            this.btnCtTrac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCtTrac.Location = new System.Drawing.Point(225, 29);
            this.btnCtTrac.Name = "btnCtTrac";
            this.btnCtTrac.Size = new System.Drawing.Size(200, 40);
            this.btnCtTrac.TabIndex = 2;
            this.btnCtTrac.Text = "Müşteri İşlemleri";
            this.btnCtTrac.UseVisualStyleBackColor = true;
            this.btnCtTrac.Click += new System.EventHandler(this.btnCtTrac_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.dataGridView1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(200, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(850, 470);
            this.panelContainer.TabIndex = 6;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(850, 470);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // fm_customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.upsidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fm_customers";
            this.Text = "fm_customers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fm_customers_FormClosed);
            this.Load += new System.EventHandler(this.fm_customers_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.fm_customers_ControlRemoved);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
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
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtCtComName;
        private System.Windows.Forms.TextBox txtCtName;
        private System.Windows.Forms.TextBox txtCtCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCtTrac;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCtPhoneNum;
        private System.Windows.Forms.TextBox txtCtTaxNo;
        private System.Windows.Forms.TextBox txtCtAddress;
        private System.Windows.Forms.Button btnOrderList;
    }
}