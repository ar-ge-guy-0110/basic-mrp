
namespace BasicMRP
{
    partial class fm_products_stock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPrUnit = new System.Windows.Forms.TextBox();
            this.txtPrName = new System.Windows.Forms.TextBox();
            this.txtPrCode = new System.Windows.Forms.TextBox();
            this.cmbPrColor = new System.Windows.Forms.ComboBox();
            this.cmbPrCategory = new System.Windows.Forms.ComboBox();
            this.btnList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbPrType = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPrStock = new System.Windows.Forms.TextBox();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.upsidePanel.SuspendLayout();
            this.panelSearch.SuspendLayout();
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
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1050, 100);
            this.panelButtons.TabIndex = 4;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.btnUpdateStock);
            this.panelSearch.Controls.Add(this.txtPrStock);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtPrUnit);
            this.panelSearch.Controls.Add(this.txtPrName);
            this.panelSearch.Controls.Add(this.txtPrCode);
            this.panelSearch.Controls.Add(this.cmbPrColor);
            this.panelSearch.Controls.Add(this.cmbPrCategory);
            this.panelSearch.Controls.Add(this.btnList);
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Controls.Add(this.cmbPrType);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearch.Location = new System.Drawing.Point(0, 30);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(200, 470);
            this.panelSearch.TabIndex = 5;
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
            // txtPrUnit
            // 
            this.txtPrUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrUnit.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrUnit.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrUnit.Location = new System.Drawing.Point(0, 146);
            this.txtPrUnit.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrUnit.MaxLength = 100;
            this.txtPrUnit.Name = "txtPrUnit";
            this.txtPrUnit.Size = new System.Drawing.Size(200, 31);
            this.txtPrUnit.TabIndex = 14;
            this.txtPrUnit.Text = "Ürün Birimi";
            this.txtPrUnit.Enter += new System.EventHandler(this.txtPrUnit_Enter);
            this.txtPrUnit.Leave += new System.EventHandler(this.txtPrUnit_Leave);
            // 
            // txtPrName
            // 
            this.txtPrName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrName.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrName.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrName.Location = new System.Drawing.Point(0, 115);
            this.txtPrName.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrName.MaxLength = 100;
            this.txtPrName.Name = "txtPrName";
            this.txtPrName.Size = new System.Drawing.Size(200, 31);
            this.txtPrName.TabIndex = 13;
            this.txtPrName.Text = "Ürün Adı";
            this.txtPrName.Enter += new System.EventHandler(this.txtPrName_Enter);
            this.txtPrName.Leave += new System.EventHandler(this.txtPrName_Leave);
            // 
            // txtPrCode
            // 
            this.txtPrCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrCode.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrCode.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrCode.Location = new System.Drawing.Point(0, 84);
            this.txtPrCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrCode.MaxLength = 100;
            this.txtPrCode.Name = "txtPrCode";
            this.txtPrCode.Size = new System.Drawing.Size(200, 31);
            this.txtPrCode.TabIndex = 6;
            this.txtPrCode.Text = "Ürün Kodu";
            this.txtPrCode.Enter += new System.EventHandler(this.txtPrCode_Enter);
            this.txtPrCode.Leave += new System.EventHandler(this.txtPrCode_Leave);
            // 
            // cmbPrColor
            // 
            this.cmbPrColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPrColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrColor.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrColor.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrColor.FormattingEnabled = true;
            this.cmbPrColor.Location = new System.Drawing.Point(0, 56);
            this.cmbPrColor.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrColor.MaxDropDownItems = 50;
            this.cmbPrColor.Name = "cmbPrColor";
            this.cmbPrColor.Size = new System.Drawing.Size(200, 28);
            this.cmbPrColor.TabIndex = 15;
            this.cmbPrColor.Text = "Ürün Rengi";
            this.cmbPrColor.SelectedIndexChanged += new System.EventHandler(this.cmbPrColor_SelectedIndexChanged);
            this.cmbPrColor.Enter += new System.EventHandler(this.cmbPrColor_Enter);
            this.cmbPrColor.Leave += new System.EventHandler(this.cmbPrColor_Leave);
            // 
            // cmbPrCategory
            // 
            this.cmbPrCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPrCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrCategory.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrCategory.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrCategory.FormattingEnabled = true;
            this.cmbPrCategory.Location = new System.Drawing.Point(0, 28);
            this.cmbPrCategory.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrCategory.MaxDropDownItems = 50;
            this.cmbPrCategory.Name = "cmbPrCategory";
            this.cmbPrCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbPrCategory.TabIndex = 12;
            this.cmbPrCategory.Text = "Ürün Kategorisi";
            this.cmbPrCategory.SelectedIndexChanged += new System.EventHandler(this.cmbPrCategory_SelectedIndexChanged);
            this.cmbPrCategory.Enter += new System.EventHandler(this.cmbPrCategory_Enter);
            this.cmbPrCategory.Leave += new System.EventHandler(this.cmbPrCategory_Leave);
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
            // cmbPrType
            // 
            this.cmbPrType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPrType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrType.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrType.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrType.FormattingEnabled = true;
            this.cmbPrType.Items.AddRange(new object[] {
            "ANA ÜRÜN",
            "MAMÜL",
            "YARI MAMÜL",
            "HAM MADDE"});
            this.cmbPrType.Location = new System.Drawing.Point(0, 0);
            this.cmbPrType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrType.MaxDropDownItems = 50;
            this.cmbPrType.Name = "cmbPrType";
            this.cmbPrType.Size = new System.Drawing.Size(200, 28);
            this.cmbPrType.TabIndex = 0;
            this.cmbPrType.Text = "Ürün Ana Tipi";
            this.cmbPrType.SelectedIndexChanged += new System.EventHandler(this.cmbPrType_SelectedIndexChanged);
            this.cmbPrType.Enter += new System.EventHandler(this.cmbPrType_Enter);
            this.cmbPrType.Leave += new System.EventHandler(this.cmbPrType_Leave);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(200, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(850, 470);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // txtPrStock
            // 
            this.txtPrStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrStock.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrStock.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrStock.Location = new System.Drawing.Point(0, 177);
            this.txtPrStock.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrStock.MaxLength = 9;
            this.txtPrStock.Name = "txtPrStock";
            this.txtPrStock.Size = new System.Drawing.Size(200, 31);
            this.txtPrStock.TabIndex = 16;
            this.txtPrStock.Text = "Stok Miktarı";
            this.txtPrStock.Enter += new System.EventHandler(this.txtPrStock_Enter);
            this.txtPrStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrStock_KeyPress);
            this.txtPrStock.Leave += new System.EventHandler(this.txtPrStock_Leave);
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdateStock.FlatAppearance.BorderSize = 0;
            this.btnUpdateStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnUpdateStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStock.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnUpdateStock.ForeColor = System.Drawing.Color.LightGray;
            this.btnUpdateStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateStock.Location = new System.Drawing.Point(0, 310);
            this.btnUpdateStock.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(200, 40);
            this.btnUpdateStock.TabIndex = 17;
            this.btnUpdateStock.Text = "Stoğu Güncelle";
            this.btnUpdateStock.UseVisualStyleBackColor = true;
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click);
            // 
            // fm_products_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.upsidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fm_products_stock";
            this.Text = "fm_products_stock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fm_products_stock_FormClosed);
            this.Load += new System.EventHandler(this.fm_products_stock_Load);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPrUnit;
        private System.Windows.Forms.TextBox txtPrName;
        private System.Windows.Forms.TextBox txtPrCode;
        private System.Windows.Forms.ComboBox cmbPrColor;
        private System.Windows.Forms.ComboBox cmbPrCategory;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbPrType;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPrStock;
        private System.Windows.Forms.Button btnUpdateStock;
    }
}