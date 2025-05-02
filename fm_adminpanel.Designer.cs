
namespace BasicMRP
{
    partial class fm_adminpanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_adminpanel));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnCost = new System.Windows.Forms.Button();
            this.btnProdPlan = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.picBoxBrand = new System.Windows.Forms.PictureBox();
            this.UpsideMenu = new System.Windows.Forms.Panel();
            this.oneLine1 = new System.Windows.Forms.Panel();
            this.picBoxMinimize = new System.Windows.Forms.PictureBox();
            this.picBoxRefresh = new System.Windows.Forms.PictureBox();
            this.picBoxMaximize = new System.Windows.Forms.PictureBox();
            this.picBoxExit = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBrand)).BeginInit();
            this.UpsideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.MenuVertical.Controls.Add(this.btnSupplier);
            this.MenuVertical.Controls.Add(this.btnDepartment);
            this.MenuVertical.Controls.Add(this.btnCost);
            this.MenuVertical.Controls.Add(this.btnProdPlan);
            this.MenuVertical.Controls.Add(this.btnCustomer);
            this.MenuVertical.Controls.Add(this.btnProducts);
            this.MenuVertical.Controls.Add(this.picBoxBrand);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(250, 650);
            this.MenuVertical.TabIndex = 0;
            this.MenuVertical.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuVertical_MouseDown);
            // 
            // btnDepartment
            // 
            this.btnDepartment.FlatAppearance.BorderSize = 0;
            this.btnDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartment.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnDepartment.ForeColor = System.Drawing.Color.LightGray;
            this.btnDepartment.Image = ((System.Drawing.Image)(resources.GetObject("btnDepartment.Image")));
            this.btnDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartment.Location = new System.Drawing.Point(0, 131);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(250, 40);
            this.btnDepartment.TabIndex = 7;
            this.btnDepartment.Text = "Departman Tanımları";
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnCost
            // 
            this.btnCost.FlatAppearance.BorderSize = 0;
            this.btnCost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCost.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnCost.ForeColor = System.Drawing.Color.LightGray;
            this.btnCost.Image = ((System.Drawing.Image)(resources.GetObject("btnCost.Image")));
            this.btnCost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCost.Location = new System.Drawing.Point(0, 177);
            this.btnCost.Name = "btnCost";
            this.btnCost.Size = new System.Drawing.Size(250, 40);
            this.btnCost.TabIndex = 6;
            this.btnCost.Text = "Maliyet Tanımları";
            this.btnCost.UseVisualStyleBackColor = true;
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnProdPlan
            // 
            this.btnProdPlan.FlatAppearance.BorderSize = 0;
            this.btnProdPlan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnProdPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdPlan.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnProdPlan.ForeColor = System.Drawing.Color.LightGray;
            this.btnProdPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnProdPlan.Image")));
            this.btnProdPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdPlan.Location = new System.Drawing.Point(0, 269);
            this.btnProdPlan.Name = "btnProdPlan";
            this.btnProdPlan.Size = new System.Drawing.Size(250, 40);
            this.btnProdPlan.TabIndex = 3;
            this.btnProdPlan.Text = "Üretim Planları";
            this.btnProdPlan.UseVisualStyleBackColor = true;
            this.btnProdPlan.Click += new System.EventHandler(this.btnProdPlan_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnCustomer.ForeColor = System.Drawing.Color.LightGray;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(0, 223);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(250, 40);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "Müşteri Tanımları";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnProducts.ForeColor = System.Drawing.Color.LightGray;
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(0, 85);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(250, 40);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "Ürün Tanımları";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // picBoxBrand
            // 
            this.picBoxBrand.Image = ((System.Drawing.Image)(resources.GetObject("picBoxBrand.Image")));
            this.picBoxBrand.Location = new System.Drawing.Point(15, 7);
            this.picBoxBrand.Name = "picBoxBrand";
            this.picBoxBrand.Size = new System.Drawing.Size(220, 50);
            this.picBoxBrand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxBrand.TabIndex = 0;
            this.picBoxBrand.TabStop = false;
            // 
            // UpsideMenu
            // 
            this.UpsideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.UpsideMenu.Controls.Add(this.oneLine1);
            this.UpsideMenu.Controls.Add(this.picBoxMinimize);
            this.UpsideMenu.Controls.Add(this.picBoxRefresh);
            this.UpsideMenu.Controls.Add(this.picBoxMaximize);
            this.UpsideMenu.Controls.Add(this.picBoxExit);
            this.UpsideMenu.Controls.Add(this.btnSlide);
            this.UpsideMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpsideMenu.Location = new System.Drawing.Point(250, 0);
            this.UpsideMenu.Name = "UpsideMenu";
            this.UpsideMenu.Size = new System.Drawing.Size(1050, 50);
            this.UpsideMenu.TabIndex = 1;
            this.UpsideMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpsideMenu_MouseDown);
            // 
            // oneLine1
            // 
            this.oneLine1.BackColor = System.Drawing.Color.DimGray;
            this.oneLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oneLine1.Location = new System.Drawing.Point(0, 49);
            this.oneLine1.Name = "oneLine1";
            this.oneLine1.Size = new System.Drawing.Size(1050, 1);
            this.oneLine1.TabIndex = 5;
            // 
            // picBoxMinimize
            // 
            this.picBoxMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxMinimize.Image = ((System.Drawing.Image)(resources.GetObject("picBoxMinimize.Image")));
            this.picBoxMinimize.Location = new System.Drawing.Point(975, 7);
            this.picBoxMinimize.Name = "picBoxMinimize";
            this.picBoxMinimize.Size = new System.Drawing.Size(20, 20);
            this.picBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxMinimize.TabIndex = 4;
            this.picBoxMinimize.TabStop = false;
            this.picBoxMinimize.Click += new System.EventHandler(this.picBoxMinimize_Click);
            // 
            // picBoxRefresh
            // 
            this.picBoxRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("picBoxRefresh.Image")));
            this.picBoxRefresh.Location = new System.Drawing.Point(1001, 7);
            this.picBoxRefresh.Name = "picBoxRefresh";
            this.picBoxRefresh.Size = new System.Drawing.Size(20, 20);
            this.picBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxRefresh.TabIndex = 3;
            this.picBoxRefresh.TabStop = false;
            this.picBoxRefresh.Visible = false;
            this.picBoxRefresh.Click += new System.EventHandler(this.picBoxRefresh_Click);
            // 
            // picBoxMaximize
            // 
            this.picBoxMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxMaximize.Image = ((System.Drawing.Image)(resources.GetObject("picBoxMaximize.Image")));
            this.picBoxMaximize.Location = new System.Drawing.Point(1001, 7);
            this.picBoxMaximize.Name = "picBoxMaximize";
            this.picBoxMaximize.Size = new System.Drawing.Size(20, 20);
            this.picBoxMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxMaximize.TabIndex = 2;
            this.picBoxMaximize.TabStop = false;
            this.picBoxMaximize.Click += new System.EventHandler(this.picBoxMaximize_Click);
            // 
            // picBoxExit
            // 
            this.picBoxExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("picBoxExit.Image")));
            this.picBoxExit.Location = new System.Drawing.Point(1027, 7);
            this.picBoxExit.Name = "picBoxExit";
            this.picBoxExit.Size = new System.Drawing.Size(20, 20);
            this.picBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxExit.TabIndex = 1;
            this.picBoxExit.TabStop = false;
            this.picBoxExit.Click += new System.EventHandler(this.picBoxExit_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Image = ((System.Drawing.Image)(resources.GetObject("btnSlide.Image")));
            this.btnSlide.Location = new System.Drawing.Point(6, 7);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(36, 36);
            this.btnSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSlide.TabIndex = 0;
            this.btnSlide.TabStop = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(250, 50);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(1050, 600);
            this.ContainerPanel.TabIndex = 2;
            this.ContainerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContainerPanel_MouseDown);
            // 
            // btnSupplier
            // 
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.btnSupplier.ForeColor = System.Drawing.Color.LightGray;
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(0, 315);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(250, 40);
            this.btnSupplier.TabIndex = 8;
            this.btnSupplier.Text = "Tedarikci Tanımları";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // fm_adminpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.UpsideMenu);
            this.Controls.Add(this.MenuVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fm_adminpanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetici Paneli";
            this.Load += new System.EventHandler(this.fm_adminpanel_Load);
            this.MenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBrand)).EndInit();
            this.UpsideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel UpsideMenu;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.PictureBox picBoxBrand;
        private System.Windows.Forms.PictureBox picBoxExit;
        private System.Windows.Forms.PictureBox picBoxMinimize;
        private System.Windows.Forms.PictureBox picBoxRefresh;
        private System.Windows.Forms.PictureBox picBoxMaximize;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProdPlan;
        private System.Windows.Forms.Panel oneLine1;
        private System.Windows.Forms.Button btnCost;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnSupplier;
    }
}