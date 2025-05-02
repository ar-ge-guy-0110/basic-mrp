
namespace BasicMRP
{
    partial class fm_mainprodact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_mainprodact));
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.brick01 = new System.Windows.Forms.Panel();
            this.brick02 = new System.Windows.Forms.Panel();
            this.brick03 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPrUnit = new System.Windows.Forms.TextBox();
            this.txtPrName = new System.Windows.Forms.TextBox();
            this.txtPrCode = new System.Windows.Forms.TextBox();
            this.cmbPrColor = new System.Windows.Forms.ComboBox();
            this.cmbPrCategory = new System.Windows.Forms.ComboBox();
            this.cmbPrType = new System.Windows.Forms.ComboBox();
            this.cmbPrDepartment = new System.Windows.Forms.ComboBox();
            this.upsidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // upsidePanel
            // 
            this.upsidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upsidePanel.Controls.Add(this.exitLabel);
            this.upsidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upsidePanel.Location = new System.Drawing.Point(15, 0);
            this.upsidePanel.Name = "upsidePanel";
            this.upsidePanel.Size = new System.Drawing.Size(300, 30);
            this.upsidePanel.TabIndex = 3;
            this.upsidePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.upsidePanel_MouseDown);
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitLabel.AutoSize = true;
            this.exitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.exitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.exitLabel.Location = new System.Drawing.Point(278, 9);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(17, 17);
            this.exitLabel.TabIndex = 0;
            this.exitLabel.Text = "X";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // brick01
            // 
            this.brick01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.brick01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brick01.Dock = System.Windows.Forms.DockStyle.Left;
            this.brick01.Location = new System.Drawing.Point(0, 0);
            this.brick01.Name = "brick01";
            this.brick01.Size = new System.Drawing.Size(15, 561);
            this.brick01.TabIndex = 4;
            this.brick01.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick01_MouseDown);
            // 
            // brick02
            // 
            this.brick02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.brick02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brick02.Dock = System.Windows.Forms.DockStyle.Right;
            this.brick02.Location = new System.Drawing.Point(315, 0);
            this.brick02.Name = "brick02";
            this.brick02.Size = new System.Drawing.Size(15, 561);
            this.brick02.TabIndex = 5;
            this.brick02.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick02_MouseDown);
            // 
            // brick03
            // 
            this.brick03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.brick03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brick03.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brick03.Location = new System.Drawing.Point(15, 546);
            this.brick03.Name = "brick03";
            this.brick03.Size = new System.Drawing.Size(300, 15);
            this.brick03.TabIndex = 6;
            this.brick03.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick03_MouseDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnDelete.ForeColor = System.Drawing.Color.LightGray;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(15, 466);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(300, 40);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnUpdate.ForeColor = System.Drawing.Color.LightGray;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(15, 506);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(300, 40);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnAdd.ForeColor = System.Drawing.Color.LightGray;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(15, 426);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(300, 40);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPrUnit
            // 
            this.txtPrUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPrUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPrUnit.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtPrUnit.ForeColor = System.Drawing.Color.LightGray;
            this.txtPrUnit.Location = new System.Drawing.Point(15, 204);
            this.txtPrUnit.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrUnit.MaxLength = 20;
            this.txtPrUnit.Name = "txtPrUnit";
            this.txtPrUnit.Size = new System.Drawing.Size(300, 31);
            this.txtPrUnit.TabIndex = 28;
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
            this.txtPrName.Location = new System.Drawing.Point(15, 173);
            this.txtPrName.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrName.MaxLength = 100;
            this.txtPrName.Name = "txtPrName";
            this.txtPrName.Size = new System.Drawing.Size(300, 31);
            this.txtPrName.TabIndex = 27;
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
            this.txtPrCode.Location = new System.Drawing.Point(15, 142);
            this.txtPrCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrCode.MaxLength = 100;
            this.txtPrCode.Name = "txtPrCode";
            this.txtPrCode.Size = new System.Drawing.Size(300, 31);
            this.txtPrCode.TabIndex = 25;
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
            this.cmbPrColor.Location = new System.Drawing.Point(15, 86);
            this.cmbPrColor.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrColor.MaxDropDownItems = 50;
            this.cmbPrColor.Name = "cmbPrColor";
            this.cmbPrColor.Size = new System.Drawing.Size(300, 28);
            this.cmbPrColor.TabIndex = 29;
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
            this.cmbPrCategory.Location = new System.Drawing.Point(15, 58);
            this.cmbPrCategory.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrCategory.MaxDropDownItems = 50;
            this.cmbPrCategory.Name = "cmbPrCategory";
            this.cmbPrCategory.Size = new System.Drawing.Size(300, 28);
            this.cmbPrCategory.TabIndex = 26;
            this.cmbPrCategory.Text = "Ürün Kategorisi";
            this.cmbPrCategory.SelectedIndexChanged += new System.EventHandler(this.cmbPrCategory_SelectedIndexChanged);
            this.cmbPrCategory.Enter += new System.EventHandler(this.cmbPrCategory_Enter);
            this.cmbPrCategory.Leave += new System.EventHandler(this.cmbPrCategory_Leave);
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
            this.cmbPrType.Location = new System.Drawing.Point(15, 30);
            this.cmbPrType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrType.MaxDropDownItems = 50;
            this.cmbPrType.Name = "cmbPrType";
            this.cmbPrType.Size = new System.Drawing.Size(300, 28);
            this.cmbPrType.TabIndex = 24;
            this.cmbPrType.Text = "Ürün Ana Tipi";
            this.cmbPrType.SelectedIndexChanged += new System.EventHandler(this.cmbPrType_SelectedIndexChanged);
            this.cmbPrType.Enter += new System.EventHandler(this.cmbPrType_Enter);
            this.cmbPrType.Leave += new System.EventHandler(this.cmbPrType_Leave);
            // 
            // cmbPrDepartment
            // 
            this.cmbPrDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbPrDepartment.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPrDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrDepartment.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.cmbPrDepartment.ForeColor = System.Drawing.Color.LightGray;
            this.cmbPrDepartment.FormattingEnabled = true;
            this.cmbPrDepartment.Location = new System.Drawing.Point(15, 114);
            this.cmbPrDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPrDepartment.MaxDropDownItems = 50;
            this.cmbPrDepartment.Name = "cmbPrDepartment";
            this.cmbPrDepartment.Size = new System.Drawing.Size(300, 28);
            this.cmbPrDepartment.TabIndex = 30;
            this.cmbPrDepartment.Text = "Departmanı";
            this.cmbPrDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbPrDepartment_SelectedIndexChanged);
            this.cmbPrDepartment.Enter += new System.EventHandler(this.cmbPrDepartment_Enter);
            this.cmbPrDepartment.Leave += new System.EventHandler(this.cmbPrDepartment_Leave);
            // 
            // fm_mainprodact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(330, 561);
            this.Controls.Add(this.txtPrUnit);
            this.Controls.Add(this.txtPrName);
            this.Controls.Add(this.txtPrCode);
            this.Controls.Add(this.cmbPrDepartment);
            this.Controls.Add(this.cmbPrColor);
            this.Controls.Add(this.cmbPrCategory);
            this.Controls.Add(this.cmbPrType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.upsidePanel);
            this.Controls.Add(this.brick03);
            this.Controls.Add(this.brick02);
            this.Controls.Add(this.brick01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fm_mainprodact";
            this.Text = "Ürün Ekle";
            this.Load += new System.EventHandler(this.fm_mainprodact_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fm_mainprodact_MouseDown);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel brick01;
        private System.Windows.Forms.Panel brick02;
        private System.Windows.Forms.Panel brick03;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPrUnit;
        private System.Windows.Forms.TextBox txtPrName;
        private System.Windows.Forms.TextBox txtPrCode;
        private System.Windows.Forms.ComboBox cmbPrColor;
        private System.Windows.Forms.ComboBox cmbPrCategory;
        private System.Windows.Forms.ComboBox cmbPrType;
        private System.Windows.Forms.ComboBox cmbPrDepartment;
    }
}