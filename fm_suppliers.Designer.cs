
namespace BasicMRP
{
    partial class fm_suppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_suppliers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSpName = new System.Windows.Forms.TextBox();
            this.txtSpCode = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSpAddress = new System.Windows.Forms.TextBox();
            this.txtSpTaxNo = new System.Windows.Forms.TextBox();
            this.txtSpPhoneNum = new System.Windows.Forms.TextBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCtTrac = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.upsidePanel.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelSearch.SuspendLayout();
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
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnOrderList);
            this.panelButtons.Controls.Add(this.btnOrder);
            this.panelButtons.Controls.Add(this.btnCtTrac);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1050, 100);
            this.panelButtons.TabIndex = 6;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.txtSpPhoneNum);
            this.panelSearch.Controls.Add(this.txtSpTaxNo);
            this.panelSearch.Controls.Add(this.txtSpAddress);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSpName);
            this.panelSearch.Controls.Add(this.txtSpCode);
            this.panelSearch.Controls.Add(this.btnList);
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearch.Location = new System.Drawing.Point(0, 30);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(200, 470);
            this.panelSearch.TabIndex = 7;
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
            // txtSpName
            // 
            this.txtSpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpName.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpName.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpName.Location = new System.Drawing.Point(0, 31);
            this.txtSpName.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpName.MaxLength = 30;
            this.txtSpName.Name = "txtSpName";
            this.txtSpName.Size = new System.Drawing.Size(200, 31);
            this.txtSpName.TabIndex = 13;
            this.txtSpName.Text = "Tedarikci Adı";
            this.txtSpName.Enter += new System.EventHandler(this.txtSpName_Enter);
            this.txtSpName.Leave += new System.EventHandler(this.txtSpName_Leave);
            // 
            // txtSpCode
            // 
            this.txtSpCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpCode.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpCode.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpCode.Location = new System.Drawing.Point(0, 0);
            this.txtSpCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpCode.MaxLength = 50;
            this.txtSpCode.Name = "txtSpCode";
            this.txtSpCode.Size = new System.Drawing.Size(200, 31);
            this.txtSpCode.TabIndex = 6;
            this.txtSpCode.Text = "Tedarikci Kodu";
            this.txtSpCode.Enter += new System.EventHandler(this.txtSpCode_Enter);
            this.txtSpCode.Leave += new System.EventHandler(this.txtSpCode_Leave);
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
            // txtSpAddress
            // 
            this.txtSpAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpAddress.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpAddress.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpAddress.Location = new System.Drawing.Point(0, 62);
            this.txtSpAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpAddress.MaxLength = 30;
            this.txtSpAddress.Name = "txtSpAddress";
            this.txtSpAddress.Size = new System.Drawing.Size(200, 31);
            this.txtSpAddress.TabIndex = 14;
            this.txtSpAddress.Text = "Adresi";
            this.txtSpAddress.Enter += new System.EventHandler(this.txtSpAddress_Enter);
            this.txtSpAddress.Leave += new System.EventHandler(this.txtSpAddress_Leave);
            // 
            // txtSpTaxNo
            // 
            this.txtSpTaxNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpTaxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpTaxNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpTaxNo.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpTaxNo.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpTaxNo.Location = new System.Drawing.Point(0, 93);
            this.txtSpTaxNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpTaxNo.MaxLength = 30;
            this.txtSpTaxNo.Name = "txtSpTaxNo";
            this.txtSpTaxNo.Size = new System.Drawing.Size(200, 31);
            this.txtSpTaxNo.TabIndex = 15;
            this.txtSpTaxNo.Text = "Vergi No";
            this.txtSpTaxNo.Enter += new System.EventHandler(this.txtSpTaxNo_Enter);
            this.txtSpTaxNo.Leave += new System.EventHandler(this.txtSpTaxNo_Leave);
            // 
            // txtSpPhoneNum
            // 
            this.txtSpPhoneNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSpPhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpPhoneNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSpPhoneNum.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtSpPhoneNum.ForeColor = System.Drawing.Color.LightGray;
            this.txtSpPhoneNum.Location = new System.Drawing.Point(0, 124);
            this.txtSpPhoneNum.Margin = new System.Windows.Forms.Padding(0);
            this.txtSpPhoneNum.MaxLength = 30;
            this.txtSpPhoneNum.Name = "txtSpPhoneNum";
            this.txtSpPhoneNum.Size = new System.Drawing.Size(200, 31);
            this.txtSpPhoneNum.TabIndex = 16;
            this.txtSpPhoneNum.Text = "Telefon Numarası";
            this.txtSpPhoneNum.Enter += new System.EventHandler(this.txtSpPhoneNum_Enter);
            this.txtSpPhoneNum.Leave += new System.EventHandler(this.txtSpPhoneNum_Leave);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.dataGridView1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(200, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(850, 470);
            this.panelContainer.TabIndex = 8;
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
            this.btnOrderList.Location = new System.Drawing.Point(631, 30);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(200, 40);
            this.btnOrderList.TabIndex = 8;
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
            this.btnOrder.Location = new System.Drawing.Point(425, 30);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(200, 40);
            this.btnOrder.TabIndex = 7;
            this.btnOrder.Text = "Tedarik İşlemleri";
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
            this.btnCtTrac.Location = new System.Drawing.Point(219, 30);
            this.btnCtTrac.Name = "btnCtTrac";
            this.btnCtTrac.Size = new System.Drawing.Size(200, 40);
            this.btnCtTrac.TabIndex = 6;
            this.btnCtTrac.Text = "Tedarikci İşlemleri";
            this.btnCtTrac.UseVisualStyleBackColor = true;
            this.btnCtTrac.Click += new System.EventHandler(this.btnCtTrac_Click);
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
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // fm_suppliers
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
            this.Name = "fm_suppliers";
            this.Text = "fm_suppliers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fm_suppliers_FormClosed);
            this.Load += new System.EventHandler(this.fm_suppliers_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.fm_suppliers_ControlRemoved);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSpName;
        private System.Windows.Forms.TextBox txtSpCode;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSpPhoneNum;
        private System.Windows.Forms.TextBox txtSpTaxNo;
        private System.Windows.Forms.TextBox txtSpAddress;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCtTrac;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}