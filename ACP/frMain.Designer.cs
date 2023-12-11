namespace ACP
{
    partial class frMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Product Management");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Supplier Management");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Process", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Category Hierarchy");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Setup", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Warehouse & Inventory", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Setup");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Retail", 7, 7, new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Setup");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Human Resource", 8, 8, new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Setup");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Accounting", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Setup");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Administration", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMain));
            this.pHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pSidebar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.imageModule = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pBody = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            this.pSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.pHeader.Controls.Add(this.btnClose);
            this.pHeader.Controls.Add(this.label1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(977, 30);
            this.pHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "MALL OF ACE CENTERPOINT";
            // 
            // pSidebar
            // 
            this.pSidebar.BackColor = System.Drawing.Color.White;
            this.pSidebar.Controls.Add(this.label2);
            this.pSidebar.Controls.Add(this.tvModule);
            this.pSidebar.Controls.Add(this.label3);
            this.pSidebar.Controls.Add(this.pictureBox2);
            this.pSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSidebar.Location = new System.Drawing.Point(0, 30);
            this.pSidebar.Name = "pSidebar";
            this.pSidebar.Size = new System.Drawing.Size(244, 568);
            this.pSidebar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Iner E. Tora";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvModule
            // 
            this.tvModule.BackColor = System.Drawing.Color.White;
            this.tvModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageModule;
            this.tvModule.Location = new System.Drawing.Point(3, 119);
            this.tvModule.Name = "tvModule";
            treeNode1.Name = "ProductMgt";
            treeNode1.Text = "Product Management";
            treeNode2.Name = "supmgt";
            treeNode2.Text = "Supplier Management";
            treeNode3.Name = "cWareProcesss";
            treeNode3.Text = "Process";
            treeNode4.Name = "catHierarchy";
            treeNode4.Text = "Category Hierarchy";
            treeNode5.Name = "cWareSetup";
            treeNode5.Text = "Setup";
            treeNode6.Name = "cWareReports";
            treeNode6.Text = "Reports";
            treeNode7.ImageIndex = 6;
            treeNode7.Name = "pWI";
            treeNode7.SelectedImageIndex = 6;
            treeNode7.Text = "Warehouse & Inventory";
            treeNode8.Name = "cRetailProcess";
            treeNode8.Text = "Process";
            treeNode9.Name = "cRetailSetup";
            treeNode9.Text = "Setup";
            treeNode10.Name = "cRetailReports";
            treeNode10.Text = "Reports";
            treeNode11.ImageIndex = 7;
            treeNode11.Name = "pRetail";
            treeNode11.SelectedImageIndex = 7;
            treeNode11.Text = "Retail";
            treeNode12.Name = "cHRProcess";
            treeNode12.Text = "Process";
            treeNode13.Name = "cHRSetup";
            treeNode13.Text = "Setup";
            treeNode14.Name = "cHRReports";
            treeNode14.Text = "Reports";
            treeNode15.ImageIndex = 8;
            treeNode15.Name = "pHR";
            treeNode15.SelectedImageIndex = 8;
            treeNode15.Text = "Human Resource";
            treeNode16.Name = "cAccountingProcess";
            treeNode16.Text = "Process";
            treeNode17.Name = "cAccountingSetup";
            treeNode17.Text = "Setup";
            treeNode18.Name = "cAccountingReports";
            treeNode18.Text = "Reports";
            treeNode19.ImageIndex = 0;
            treeNode19.Name = "pAccounting";
            treeNode19.Text = "Accounting";
            treeNode20.Name = "cAdminProcess";
            treeNode20.Text = "Process";
            treeNode21.Name = "cAdminSetup";
            treeNode21.Text = "Setup";
            treeNode22.Name = "cAdminReports";
            treeNode22.Text = "Reports";
            treeNode23.ImageIndex = 4;
            treeNode23.Name = "pAdmin";
            treeNode23.SelectedImageIndex = 4;
            treeNode23.Text = "Administration";
            this.tvModule.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode11,
            treeNode15,
            treeNode19,
            treeNode23});
            this.tvModule.SelectedImageIndex = 0;
            this.tvModule.Size = new System.Drawing.Size(238, 485);
            this.tvModule.TabIndex = 6;
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            // 
            // imageModule
            // 
            this.imageModule.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageModule.ImageStream")));
            this.imageModule.TransparentColor = System.Drawing.Color.Transparent;
            this.imageModule.Images.SetKeyName(0, "accounting.png");
            this.imageModule.Images.SetKeyName(1, "basket.png");
            this.imageModule.Images.SetKeyName(2, "budget.png");
            this.imageModule.Images.SetKeyName(3, "contract.png");
            this.imageModule.Images.SetKeyName(4, "engineer.png");
            this.imageModule.Images.SetKeyName(5, "inventory.png");
            this.imageModule.Images.SetKeyName(6, "received.png");
            this.imageModule.Images.SetKeyName(7, "report.png");
            this.imageModule.Images.SetKeyName(8, "resource (1).png");
            this.imageModule.Images.SetKeyName(9, "settings.png");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Administrator";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(53, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(81, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(950, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(15, 16);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pBody
            // 
            this.pBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBody.Location = new System.Drawing.Point(244, 30);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(733, 568);
            this.pBody.TabIndex = 3;
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 598);
            this.ControlBox = false;
            this.Controls.Add(this.pBody);
            this.Controls.Add(this.pSidebar);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frMain_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pSidebar.ResumeLayout(false);
            this.pSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pSidebar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageModule;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel pBody;
    }
}