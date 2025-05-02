
namespace BasicMRP
{
    partial class fm_product_categories_trac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_product_categories_trac));
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.brick03 = new System.Windows.Forms.Panel();
            this.brick02 = new System.Windows.Forms.Panel();
            this.brick01 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxCatName = new System.Windows.Forms.TextBox();
            this.textBoxCatCode = new System.Windows.Forms.TextBox();
            this.comboBoxCatType = new System.Windows.Forms.ComboBox();
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
            this.upsidePanel.TabIndex = 7;
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
            // brick03
            // 
            this.brick03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.brick03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brick03.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brick03.Location = new System.Drawing.Point(15, 546);
            this.brick03.Name = "brick03";
            this.brick03.Size = new System.Drawing.Size(300, 15);
            this.brick03.TabIndex = 10;
            this.brick03.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick03_MouseDown);
            // 
            // brick02
            // 
            this.brick02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.brick02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brick02.Dock = System.Windows.Forms.DockStyle.Right;
            this.brick02.Location = new System.Drawing.Point(315, 0);
            this.brick02.Name = "brick02";
            this.brick02.Size = new System.Drawing.Size(15, 561);
            this.brick02.TabIndex = 9;
            this.brick02.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick02_MouseDown);
            // 
            // brick01
            // 
            this.brick01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.brick01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brick01.Dock = System.Windows.Forms.DockStyle.Left;
            this.brick01.Location = new System.Drawing.Point(0, 0);
            this.brick01.Name = "brick01";
            this.brick01.Size = new System.Drawing.Size(15, 561);
            this.brick01.TabIndex = 8;
            this.brick01.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick01_MouseDown);
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
            this.btnDelete.TabIndex = 29;
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
            this.btnUpdate.TabIndex = 28;
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
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxCatName
            // 
            this.textBoxCatName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxCatName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCatName.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.textBoxCatName.ForeColor = System.Drawing.Color.LightGray;
            this.textBoxCatName.Location = new System.Drawing.Point(15, 239);
            this.textBoxCatName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCatName.MaxLength = 150;
            this.textBoxCatName.Name = "textBoxCatName";
            this.textBoxCatName.Size = new System.Drawing.Size(300, 31);
            this.textBoxCatName.TabIndex = 26;
            this.textBoxCatName.Text = "Kategori Adı";
            this.textBoxCatName.Enter += new System.EventHandler(this.textBoxCatName_Enter);
            this.textBoxCatName.Leave += new System.EventHandler(this.textBoxCatName_Leave);
            // 
            // textBoxCatCode
            // 
            this.textBoxCatCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxCatCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCatCode.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.textBoxCatCode.ForeColor = System.Drawing.Color.LightGray;
            this.textBoxCatCode.Location = new System.Drawing.Point(15, 208);
            this.textBoxCatCode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCatCode.MaxLength = 150;
            this.textBoxCatCode.Name = "textBoxCatCode";
            this.textBoxCatCode.Size = new System.Drawing.Size(300, 31);
            this.textBoxCatCode.TabIndex = 25;
            this.textBoxCatCode.Text = "Kategori Kodu";
            this.textBoxCatCode.Enter += new System.EventHandler(this.textBoxCatCode_Enter);
            this.textBoxCatCode.Leave += new System.EventHandler(this.textBoxCatCode_Leave);
            // 
            // comboBoxCatType
            // 
            this.comboBoxCatType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboBoxCatType.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCatType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCatType.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.comboBoxCatType.ForeColor = System.Drawing.Color.LightGray;
            this.comboBoxCatType.FormattingEnabled = true;
            this.comboBoxCatType.Items.AddRange(new object[] {
            "ANA ÜRÜN",
            "MAMÜL",
            "YARI MAMÜL",
            "HAM MADDE"});
            this.comboBoxCatType.Location = new System.Drawing.Point(15, 30);
            this.comboBoxCatType.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxCatType.MaxDropDownItems = 50;
            this.comboBoxCatType.Name = "comboBoxCatType";
            this.comboBoxCatType.Size = new System.Drawing.Size(300, 28);
            this.comboBoxCatType.TabIndex = 24;
            this.comboBoxCatType.Text = "Ürün Türü";
            this.comboBoxCatType.Enter += new System.EventHandler(this.comboBoxCatType_Enter);
            this.comboBoxCatType.Leave += new System.EventHandler(this.comboBoxCatType_Leave);
            // 
            // fm_product_categories_trac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(330, 561);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.textBoxCatName);
            this.Controls.Add(this.textBoxCatCode);
            this.Controls.Add(this.comboBoxCatType);
            this.Controls.Add(this.upsidePanel);
            this.Controls.Add(this.brick03);
            this.Controls.Add(this.brick02);
            this.Controls.Add(this.brick01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fm_product_categories_trac";
            this.Text = "Kategori İşlemleri";
            this.Load += new System.EventHandler(this.fm_product_categories_trac_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fm_product_categories_trac_MouseDown);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel brick03;
        private System.Windows.Forms.Panel brick02;
        private System.Windows.Forms.Panel brick01;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBoxCatName;
        private System.Windows.Forms.TextBox textBoxCatCode;
        private System.Windows.Forms.ComboBox comboBoxCatType;
    }
}