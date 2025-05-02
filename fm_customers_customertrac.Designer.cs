
namespace BasicMRP
{
    partial class fm_customers_customertrac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_customers_customertrac));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.upsidePanel = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.brick03 = new System.Windows.Forms.Panel();
            this.brick02 = new System.Windows.Forms.Panel();
            this.brick01 = new System.Windows.Forms.Panel();
            this.txtCtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtCtTaxNo = new System.Windows.Forms.TextBox();
            this.txtCtAddress = new System.Windows.Forms.TextBox();
            this.txtCtComName = new System.Windows.Forms.TextBox();
            this.txtCtName = new System.Windows.Forms.TextBox();
            this.txtCtCode = new System.Windows.Forms.TextBox();
            this.upsidePanel.SuspendLayout();
            this.SuspendLayout();
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
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnDelete.TabIndex = 30;
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
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // upsidePanel
            // 
            this.upsidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upsidePanel.Controls.Add(this.exitLabel);
            this.upsidePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upsidePanel.Location = new System.Drawing.Point(15, 0);
            this.upsidePanel.Name = "upsidePanel";
            this.upsidePanel.Size = new System.Drawing.Size(300, 30);
            this.upsidePanel.TabIndex = 24;
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
            this.brick03.TabIndex = 27;
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
            this.brick02.TabIndex = 26;
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
            this.brick01.TabIndex = 25;
            this.brick01.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brick01_MouseDown);
            // 
            // txtCtPhoneNum
            // 
            this.txtCtPhoneNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCtPhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtPhoneNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCtPhoneNum.Font = new System.Drawing.Font("Malgun Gothic", 13F);
            this.txtCtPhoneNum.ForeColor = System.Drawing.Color.LightGray;
            this.txtCtPhoneNum.Location = new System.Drawing.Point(15, 185);
            this.txtCtPhoneNum.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtPhoneNum.MaxLength = 12;
            this.txtCtPhoneNum.Name = "txtCtPhoneNum";
            this.txtCtPhoneNum.Size = new System.Drawing.Size(300, 31);
            this.txtCtPhoneNum.TabIndex = 36;
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
            this.txtCtTaxNo.Location = new System.Drawing.Point(15, 154);
            this.txtCtTaxNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtTaxNo.MaxLength = 30;
            this.txtCtTaxNo.Name = "txtCtTaxNo";
            this.txtCtTaxNo.Size = new System.Drawing.Size(300, 31);
            this.txtCtTaxNo.TabIndex = 35;
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
            this.txtCtAddress.Location = new System.Drawing.Point(15, 123);
            this.txtCtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtAddress.MaxLength = 500;
            this.txtCtAddress.Name = "txtCtAddress";
            this.txtCtAddress.Size = new System.Drawing.Size(300, 31);
            this.txtCtAddress.TabIndex = 34;
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
            this.txtCtComName.Location = new System.Drawing.Point(15, 92);
            this.txtCtComName.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtComName.MaxLength = 100;
            this.txtCtComName.Name = "txtCtComName";
            this.txtCtComName.Size = new System.Drawing.Size(300, 31);
            this.txtCtComName.TabIndex = 33;
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
            this.txtCtName.Location = new System.Drawing.Point(15, 61);
            this.txtCtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtName.MaxLength = 100;
            this.txtCtName.Name = "txtCtName";
            this.txtCtName.Size = new System.Drawing.Size(300, 31);
            this.txtCtName.TabIndex = 32;
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
            this.txtCtCode.Location = new System.Drawing.Point(15, 30);
            this.txtCtCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCtCode.MaxLength = 100;
            this.txtCtCode.Name = "txtCtCode";
            this.txtCtCode.Size = new System.Drawing.Size(300, 31);
            this.txtCtCode.TabIndex = 31;
            this.txtCtCode.Text = "Müşteri Kodu";
            this.txtCtCode.Enter += new System.EventHandler(this.txtCtCode_Enter);
            this.txtCtCode.Leave += new System.EventHandler(this.txtCtCode_Leave);
            // 
            // fm_customers_customertrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(330, 561);
            this.Controls.Add(this.txtCtPhoneNum);
            this.Controls.Add(this.txtCtTaxNo);
            this.Controls.Add(this.txtCtAddress);
            this.Controls.Add(this.txtCtComName);
            this.Controls.Add(this.txtCtName);
            this.Controls.Add(this.txtCtCode);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.upsidePanel);
            this.Controls.Add(this.brick03);
            this.Controls.Add(this.brick02);
            this.Controls.Add(this.brick01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fm_customers_customertrac";
            this.Text = "Müşteri Ekle";
            this.Load += new System.EventHandler(this.fm_customers_customertrac_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fm_customers_customertrac_MouseDown);
            this.upsidePanel.ResumeLayout(false);
            this.upsidePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel upsidePanel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Panel brick03;
        private System.Windows.Forms.Panel brick02;
        private System.Windows.Forms.Panel brick01;
        private System.Windows.Forms.TextBox txtCtPhoneNum;
        private System.Windows.Forms.TextBox txtCtTaxNo;
        private System.Windows.Forms.TextBox txtCtAddress;
        private System.Windows.Forms.TextBox txtCtComName;
        private System.Windows.Forms.TextBox txtCtName;
        private System.Windows.Forms.TextBox txtCtCode;
    }
}