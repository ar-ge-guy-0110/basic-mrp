namespace BasicMRP
{
    partial class anaform
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Ürün Tanımları");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Müşteri Tanımları");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Malzeme Planlama");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(anaform));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnCommercial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.treeView1.Location = new System.Drawing.Point(12, 30);
            this.treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.Color.Silver;
            treeNode1.ForeColor = System.Drawing.Color.Black;
            treeNode1.Name = "uruntanim";
            treeNode1.Text = "Ürün Tanımları";
            treeNode2.BackColor = System.Drawing.Color.Silver;
            treeNode2.ForeColor = System.Drawing.Color.Black;
            treeNode2.Name = "musteritanim";
            treeNode2.Text = "Müşteri Tanımları";
            treeNode3.BackColor = System.Drawing.Color.Silver;
            treeNode3.ForeColor = System.Drawing.Color.Black;
            treeNode3.Name = "mrp";
            treeNode3.Text = "Malzeme Planlama";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(170, 520);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnUser.ForeColor = System.Drawing.Color.LightGray;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(342, 189);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(250, 40);
            this.btnUser.TabIndex = 7;
            this.btnUser.Text = "Kullanıcı Tanımları";
            this.btnUser.UseVisualStyleBackColor = false;
            // 
            // btnCommercial
            // 
            this.btnCommercial.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCommercial.FlatAppearance.BorderSize = 0;
            this.btnCommercial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCommercial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommercial.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnCommercial.ForeColor = System.Drawing.Color.LightGray;
            this.btnCommercial.Image = ((System.Drawing.Image)(resources.GetObject("btnCommercial.Image")));
            this.btnCommercial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommercial.Location = new System.Drawing.Point(342, 143);
            this.btnCommercial.Name = "btnCommercial";
            this.btnCommercial.Size = new System.Drawing.Size(250, 40);
            this.btnCommercial.TabIndex = 6;
            this.btnCommercial.Text = "Sermaye İşlemleri";
            this.btnCommercial.UseVisualStyleBackColor = false;
            // 
            // anaform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnCommercial);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "anaform";
            this.Text = "BasicMRP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.anaform_FormClosed);
            this.Load += new System.EventHandler(this.anaform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnCommercial;
    }
}

