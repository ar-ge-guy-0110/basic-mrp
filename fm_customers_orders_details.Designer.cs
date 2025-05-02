
namespace BasicMRP
{
    partial class fm_customers_orders_details
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_customers_orders_details));
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.lbSelectedO = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.panelContainer1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtPrUnit = new System.Windows.Forms.TextBox();
            this.txtPrName = new System.Windows.Forms.TextBox();
            this.txtPrCode = new System.Windows.Forms.TextBox();
            this.cmbPrDepartment = new System.Windows.Forms.ComboBox();
            this.cmbPrColor = new System.Windows.Forms.ComboBox();
            this.cmbPrCategory = new System.Windows.Forms.ComboBox();
            this.cmbPrType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelContainer2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.txtOdAmount = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.upsidePanel.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // upsidePanel
            // 
            this.upsidePanel.Controls.Add(this.lbSelectedO);
            this.upsidePanel.Controls.Add(this.exitLabel);
            this.upsidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upsidePanel.Location = new System.Drawing.Point(0, 0);
            this.upsidePanel.Name = "upsidePanel";
            this.upsidePanel.Size = new System.Drawing.Size(1050, 30);
            this.upsidePanel.TabIndex = 4;
            // 
            // lbSelectedO
            // 
            this.lbSelectedO.AutoSize = true;
            this.lbSelectedO.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.lbSelectedO.ForeColor = System.Drawing.Color.LightGray;
            this.lbSelectedO.Location = new System.Drawing.Point(3, 6);
            this.lbSelectedO.Name = "lbSelectedO";
            this.lbSelectedO.Size = new System.Drawing.Size(118, 20);
            this.lbSelectedO.TabIndex = 1;
            this.lbSelectedO.Text = "Seçili Sipariş ID:";
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
            // panelContainer1
            // 
            this.panelContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer1.Controls.Add(this.dataGridView1);
            this.panelContainer1.Controls.Add(this.panel1);
            this.panelContainer1.Controls.Add(this.panelSearch);
            this.panelContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelContainer1.Location = new System.Drawing.Point(0, 30);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.Size = new System.Drawing.Size(525, 570);
            this.panelContainer1.TabIndex = 5;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 180);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(523, 388);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 45);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(218, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Listesi";
            // 
            // panelSearch
            // 
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.txtPrUnit);
            this.panelSearch.Controls.Add(this.txtPrName);
            this.panelSearch.Controls.Add(this.txtPrCode);
            this.panelSearch.Controls.Add(this.cmbPrDepartment);
            this.panelSearch.Controls.Add(this.cmbPrColor);
            this.panelSearch.Controls.Add(this.cmbPrCategory);
            this.panelSearch.Controls.Add(this.cmbPrType);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnList);
            this.panelSearch.Controls.Add(this.btnClear);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(523, 135);
            this.panelSearch.TabIndex = 12;
            // 
            // txtPrUnit
            // 
            this.txtPrUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrUnit.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrUnit.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrUnit.Location = new System.Drawing.Point(200, 63);
            this.txtPrUnit.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrUnit.MaxLength = 100;
            this.txtPrUnit.Name = "txtPrUnit";
            this.txtPrUnit.Size = new System.Drawing.Size(200, 31);
            this.txtPrUnit.TabIndex = 20;
            this.txtPrUnit.Text = "Ürün Birimi";
            this.txtPrUnit.Enter += new System.EventHandler(this.txtPrUnit_Enter);
            this.txtPrUnit.Leave += new System.EventHandler(this.txtPrUnit_Leave);
            // 
            // txtPrName
            // 
            this.txtPrName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrName.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrName.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrName.Location = new System.Drawing.Point(200, 32);
            this.txtPrName.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrName.MaxLength = 100;
            this.txtPrName.Name = "txtPrName";
            this.txtPrName.Size = new System.Drawing.Size(200, 31);
            this.txtPrName.TabIndex = 19;
            this.txtPrName.Text = "Ürün Adı";
            this.txtPrName.Enter += new System.EventHandler(this.txtPrName_Enter);
            this.txtPrName.Leave += new System.EventHandler(this.txtPrName_Leave);
            // 
            // txtPrCode
            // 
            this.txtPrCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrCode.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrCode.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrCode.Location = new System.Drawing.Point(200, 1);
            this.txtPrCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrCode.MaxLength = 100;
            this.txtPrCode.Name = "txtPrCode";
            this.txtPrCode.Size = new System.Drawing.Size(200, 31);
            this.txtPrCode.TabIndex = 18;
            this.txtPrCode.Text = "Ürün Kodu";
            this.txtPrCode.Enter += new System.EventHandler(this.txtPrCode_Enter);
            this.txtPrCode.Leave += new System.EventHandler(this.txtPrCode_Leave);
            // 
            // cmbPrDepartment
            // 
            this.cmbPrDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrDepartment.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrDepartment.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrDepartment.FormattingEnabled = true;
            this.cmbPrDepartment.Location = new System.Drawing.Point(0, 83);
            this.cmbPrDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrDepartment.MaxDropDownItems = 50;
            this.cmbPrDepartment.Name = "cmbPrDepartment";
            this.cmbPrDepartment.Size = new System.Drawing.Size(200, 28);
            this.cmbPrDepartment.TabIndex = 17;
            this.cmbPrDepartment.Text = "Departmanı";
            this.cmbPrDepartment.Enter += new System.EventHandler(this.cmbPrDepartment_Enter);
            this.cmbPrDepartment.Leave += new System.EventHandler(this.cmbPrDepartment_Leave);
            // 
            // cmbPrColor
            // 
            this.cmbPrColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrColor.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrColor.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrColor.FormattingEnabled = true;
            this.cmbPrColor.Location = new System.Drawing.Point(0, 59);
            this.cmbPrColor.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrColor.MaxDropDownItems = 50;
            this.cmbPrColor.Name = "cmbPrColor";
            this.cmbPrColor.Size = new System.Drawing.Size(200, 28);
            this.cmbPrColor.TabIndex = 16;
            this.cmbPrColor.Text = "Ürün Rengi";
            this.cmbPrColor.Enter += new System.EventHandler(this.cmbPrColor_Enter);
            this.cmbPrColor.Leave += new System.EventHandler(this.cmbPrColor_Leave);
            // 
            // cmbPrCategory
            // 
            this.cmbPrCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrCategory.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrCategory.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrCategory.FormattingEnabled = true;
            this.cmbPrCategory.Location = new System.Drawing.Point(0, 31);
            this.cmbPrCategory.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrCategory.MaxDropDownItems = 50;
            this.cmbPrCategory.Name = "cmbPrCategory";
            this.cmbPrCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbPrCategory.TabIndex = 13;
            this.cmbPrCategory.Text = "Ürün Kategorisi";
            this.cmbPrCategory.Enter += new System.EventHandler(this.cmbPrCategory_Enter);
            this.cmbPrCategory.Leave += new System.EventHandler(this.cmbPrCategory_Leave);
            // 
            // cmbPrType
            // 
            this.cmbPrType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrType.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrType.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrType.FormattingEnabled = true;
            this.cmbPrType.Items.AddRange(new object[] {
            "ANA ÜRÜN",
            "MAMÜL",
            "YARI MAMÜL",
            "HAM MADDE"});
            this.cmbPrType.Location = new System.Drawing.Point(0, 3);
            this.cmbPrType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrType.MaxDropDownItems = 50;
            this.cmbPrType.Name = "cmbPrType";
            this.cmbPrType.Size = new System.Drawing.Size(200, 28);
            this.cmbPrType.TabIndex = 12;
            this.cmbPrType.Text = "Ürün Ana Tipi";
            this.cmbPrType.SelectedIndexChanged += new System.EventHandler(this.cmbPrType_SelectedIndexChanged);
            this.cmbPrType.Enter += new System.EventHandler(this.cmbPrType_Enter);
            this.cmbPrType.Leave += new System.EventHandler(this.cmbPrType_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnSearch.ForeColor = System.Drawing.Color.LightGray;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(400, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Ara";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnList
            // 
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnList.ForeColor = System.Drawing.Color.LightGray;
            this.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.Location = new System.Drawing.Point(400, 40);
            this.btnList.Margin = new System.Windows.Forms.Padding(0);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(120, 40);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "Hepsini Göster";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnClear.ForeColor = System.Drawing.Color.LightGray;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(400, 80);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 54);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Seçimleri Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelContainer2
            // 
            this.panelContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer2.Controls.Add(this.dataGridView2);
            this.panelContainer2.Controls.Add(this.panel2);
            this.panelContainer2.Controls.Add(this.panelButtons);
            this.panelContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer2.Location = new System.Drawing.Point(525, 30);
            this.panelContainer2.Name = "panelContainer2";
            this.panelContainer2.Size = new System.Drawing.Size(525, 570);
            this.panelContainer2.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(0, 180);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(523, 388);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 45);
            this.panel2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(189, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sipariş Detay Listesi";
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.txtOdAmount);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(523, 135);
            this.panelButtons.TabIndex = 13;
            // 
            // txtOdAmount
            // 
            this.txtOdAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOdAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOdAmount.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtOdAmount.ForeColor = System.Drawing.Color.LightGray;
            this.txtOdAmount.Location = new System.Drawing.Point(2, 10);
            this.txtOdAmount.Margin = new System.Windows.Forms.Padding(0);
            this.txtOdAmount.MaxLength = 30;
            this.txtOdAmount.Name = "txtOdAmount";
            this.txtOdAmount.Size = new System.Drawing.Size(200, 31);
            this.txtOdAmount.TabIndex = 14;
            this.txtOdAmount.Text = "Sipariş Miktarı";
            this.txtOdAmount.Enter += new System.EventHandler(this.txtOdAmount_Enter);
            this.txtOdAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOdAmount_KeyPress);
            this.txtOdAmount.Leave += new System.EventHandler(this.txtOdAmount_Leave);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnDelete.ForeColor = System.Drawing.Color.LightGray;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(306, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(205, 40);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnAdd.ForeColor = System.Drawing.Color.LightGray;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(307, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(205, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // fm_customers_orders_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.panelContainer2);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.upsidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fm_customers_orders_details";
            this.Text = "fm_customers_orders_details";
            this.Load += new System.EventHandler(this.fm_customers_orders_details_Load);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.panelContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label lbSelectedO;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel panelContainer1;
        private System.Windows.Forms.Panel panelContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtPrUnit;
        private System.Windows.Forms.TextBox txtPrName;
        private System.Windows.Forms.TextBox txtPrCode;
        private System.Windows.Forms.ComboBox cmbPrDepartment;
        private System.Windows.Forms.ComboBox cmbPrColor;
        private System.Windows.Forms.ComboBox cmbPrCategory;
        private System.Windows.Forms.ComboBox cmbPrType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TextBox txtOdAmount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}