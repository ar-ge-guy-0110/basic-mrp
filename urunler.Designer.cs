namespace BasicMRP
{
    partial class urunler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunler));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_of_addition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.basicmrpdbDataSetITEMS = new BasicMRP.basicmrpdbDataSetITEMS();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basicmrpdbDataSet = new BasicMRP.basicmrpdbDataSet();
            this.itemTableAdapter = new BasicMRP.basicmrpdbDataSetTableAdapters.itemTableAdapter();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.akmaskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.akmaskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.akmaskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.akıllıKodlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünStoklarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTableAdapter1 = new BasicMRP.basicmrpdbDataSetITEMSTableAdapters.itemTableAdapter();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicmrpdbDataSetITEMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicmrpdbDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.itemcodeDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.itemtypeDataGridViewTextBoxColumn,
            this.unitcodeDataGridViewTextBoxColumn,
            this.date_of_addition});
            this.dataGridView1.DataSource = this.itemBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(700, 710);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 40;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "itemcode";
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "itemcode";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcodeDataGridViewTextBoxColumn.Width = 75;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "itemname";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "itemname";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 77;
            // 
            // itemtypeDataGridViewTextBoxColumn
            // 
            this.itemtypeDataGridViewTextBoxColumn.DataPropertyName = "itemtype";
            this.itemtypeDataGridViewTextBoxColumn.HeaderText = "itemtype";
            this.itemtypeDataGridViewTextBoxColumn.Name = "itemtypeDataGridViewTextBoxColumn";
            this.itemtypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemtypeDataGridViewTextBoxColumn.Width = 71;
            // 
            // unitcodeDataGridViewTextBoxColumn
            // 
            this.unitcodeDataGridViewTextBoxColumn.DataPropertyName = "unitcode";
            this.unitcodeDataGridViewTextBoxColumn.HeaderText = "unitcode";
            this.unitcodeDataGridViewTextBoxColumn.Name = "unitcodeDataGridViewTextBoxColumn";
            this.unitcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitcodeDataGridViewTextBoxColumn.Width = 73;
            // 
            // date_of_addition
            // 
            this.date_of_addition.DataPropertyName = "date_of_addition";
            this.date_of_addition.HeaderText = "date_of_addition";
            this.date_of_addition.Name = "date_of_addition";
            this.date_of_addition.ReadOnly = true;
            this.date_of_addition.Width = 111;
            // 
            // itemBindingSource1
            // 
            this.itemBindingSource1.DataMember = "item";
            this.itemBindingSource1.DataSource = this.basicmrpdbDataSetITEMS;
            // 
            // basicmrpdbDataSetITEMS
            // 
            this.basicmrpdbDataSetITEMS.DataSetName = "basicmrpdbDataSetITEMS";
            this.basicmrpdbDataSetITEMS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataMember = "item";
            this.itemBindingSource.DataSource = this.basicmrpdbDataSet;
            // 
            // basicmrpdbDataSet
            // 
            this.basicmrpdbDataSet.DataSetName = "basicmrpdbDataSet";
            this.basicmrpdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(135, 215);
            this.maskedTextBox1.Mask = "AAAAAAAAAAAAAAAA";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.Size = new System.Drawing.Size(121, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Ana Kodu:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 295);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Temizle";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Güncelle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.akmaskedTextBox3);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.akmaskedTextBox2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.akmaskedTextBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox5);
            this.panel2.Controls.Add(this.maskedTextBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(716, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 409);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(135, 355);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 25);
            this.button7.TabIndex = 22;
            this.button7.Text = "Bütün Ürünleri Listele";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(135, 324);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 25);
            this.button6.TabIndex = 21;
            this.button6.Text = "Kategoriye Göre Ara";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Ürün Açıklayıcı Kısa Kod:";
            // 
            // akmaskedTextBox3
            // 
            this.akmaskedTextBox3.Location = new System.Drawing.Point(135, 151);
            this.akmaskedTextBox3.Mask = "AAAAAAAAAAAAAAAAAAAA";
            this.akmaskedTextBox3.Name = "akmaskedTextBox3";
            this.akmaskedTextBox3.PromptChar = ' ';
            this.akmaskedTextBox3.Size = new System.Drawing.Size(121, 20);
            this.akmaskedTextBox3.TabIndex = 19;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(135, 293);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(121, 25);
            this.button10.TabIndex = 14;
            this.button10.Text = "Ekle";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Birim Kodu:";
            // 
            // akmaskedTextBox2
            // 
            this.akmaskedTextBox2.Location = new System.Drawing.Point(135, 267);
            this.akmaskedTextBox2.Mask = "AAAAAAAAAA";
            this.akmaskedTextBox2.Name = "akmaskedTextBox2";
            this.akmaskedTextBox2.PromptChar = ' ';
            this.akmaskedTextBox2.Size = new System.Drawing.Size(121, 20);
            this.akmaskedTextBox2.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Ürün Adı:";
            // 
            // akmaskedTextBox1
            // 
            this.akmaskedTextBox1.Location = new System.Drawing.Point(135, 241);
            this.akmaskedTextBox1.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
    "AAAAAAA";
            this.akmaskedTextBox1.Name = "akmaskedTextBox1";
            this.akmaskedTextBox1.PromptChar = ' ';
            this.akmaskedTextBox1.Size = new System.Drawing.Size(121, 20);
            this.akmaskedTextBox1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Renk:";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Renk Yok"});
            this.comboBox5.Location = new System.Drawing.Point(135, 124);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 8;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Üçüncü Katman:";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(135, 97);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "İkinci Katman:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(135, 70);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Birinci Katman:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(135, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ana Tür:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TAKIM",
            "MAMÜL",
            "YARI MAMÜL",
            "HAMMADDE"});
            this.comboBox1.Location = new System.Drawing.Point(135, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akıllıKodlamaToolStripMenuItem,
            this.ürünStoklarıToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // akıllıKodlamaToolStripMenuItem
            // 
            this.akıllıKodlamaToolStripMenuItem.Name = "akıllıKodlamaToolStripMenuItem";
            this.akıllıKodlamaToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.akıllıKodlamaToolStripMenuItem.Text = "Akıllı Kodlama";
            this.akıllıKodlamaToolStripMenuItem.Click += new System.EventHandler(this.akıllıKodlamaToolStripMenuItem_Click);
            // 
            // ürünStoklarıToolStripMenuItem
            // 
            this.ürünStoklarıToolStripMenuItem.Name = "ürünStoklarıToolStripMenuItem";
            this.ürünStoklarıToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.ürünStoklarıToolStripMenuItem.Text = "Ürün Stokları";
            this.ürünStoklarıToolStripMenuItem.Click += new System.EventHandler(this.ürünStoklarıToolStripMenuItem_Click);
            // 
            // itemTableAdapter1
            // 
            this.itemTableAdapter1.ClearBeforeFill = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(716, 554);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(260, 40);
            this.button8.TabIndex = 8;
            this.button8.Text = "Ürün Reçete İşlemleri";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // urunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(984, 762);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "urunler";
            this.Text = "Ürün Tanımları - Basic Mrp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.urunler_FormClosed);
            this.Load += new System.EventHandler(this.urunler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicmrpdbDataSetITEMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicmrpdbDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private basicmrpdbDataSet basicmrpdbDataSet;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private basicmrpdbDataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem akıllıKodlamaToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox5;
        private basicmrpdbDataSetITEMS basicmrpdbDataSetITEMS;
        private System.Windows.Forms.BindingSource itemBindingSource1;
        private basicmrpdbDataSetITEMSTableAdapters.itemTableAdapter itemTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_of_addition;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox akmaskedTextBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox akmaskedTextBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox akmaskedTextBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ToolStripMenuItem ürünStoklarıToolStripMenuItem;
    }
}