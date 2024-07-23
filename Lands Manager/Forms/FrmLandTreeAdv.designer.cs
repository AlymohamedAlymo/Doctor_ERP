namespace DoctorERP
{
    partial class FrmLandTreeAdv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLandTreeAdv));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TxtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnClearSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblSearch = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trDocs = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuLand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuOpenLandCard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddLandCard = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trDocs)).BeginInit();
            this.MenuLand.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Controls.Add(this.TxtSearch);
            this.panel1.Controls.Add(this.LblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 64);
            this.panel1.TabIndex = 0;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRefresh.Location = new System.Drawing.Point(693, 17);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(68, 25);
            this.BtnRefresh.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.TabIndex = 21;
            this.BtnRefresh.Values.Text = "تحديث";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnClearSearch});
            this.TxtSearch.Location = new System.Drawing.Point(12, 21);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(175, 21);
            this.TxtSearch.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.TabIndex = 19;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // BtnClearSearch
            // 
            this.BtnClearSearch.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnClearSearch.UniqueName = "2D4DFC044BD642233B9024686EFBFEF0";
            this.BtnClearSearch.Click += new System.EventHandler(this.BtnClearSearch_Click);
            // 
            // LblSearch
            // 
            this.LblSearch.Location = new System.Drawing.Point(193, 23);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(32, 17);
            this.LblSearch.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSearch.TabIndex = 20;
            this.LblSearch.Values.Text = "بحث";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trDocs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 498);
            this.panel2.TabIndex = 0;
            // 
            // trDocs
            // 
            this.trDocs.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.trDocs.CustomizationFormBounds = new System.Drawing.Rectangle(575, 429, 264, 272);
            this.trDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trDocs.Location = new System.Drawing.Point(0, 0);
            this.trDocs.Name = "trDocs";
            this.trDocs.Size = new System.Drawing.Size(784, 498);
            this.trDocs.TabIndex = 0;
            this.trDocs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trDocs_MouseDoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Code";
            this.treeListColumn1.FieldName = "code";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fclose.png");
            this.imageList1.Images.SetKeyName(1, "fopen.png");
            this.imageList1.Images.SetKeyName(2, "landready.png");
            this.imageList1.Images.SetKeyName(3, "landsold.png");
            this.imageList1.Images.SetKeyName(4, "landreserved.png");
            // 
            // MenuLand
            // 
            this.MenuLand.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuLand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpenLandCard,
            this.MenuAddLandCard});
            this.MenuLand.Name = "MenuLand";
            this.MenuLand.Size = new System.Drawing.Size(142, 48);
            // 
            // MenuOpenLandCard
            // 
            this.MenuOpenLandCard.Name = "MenuOpenLandCard";
            this.MenuOpenLandCard.Size = new System.Drawing.Size(141, 22);
            this.MenuOpenLandCard.Text = "بطاقة الصنف";
            this.MenuOpenLandCard.Click += new System.EventHandler(this.MenuOpenLandCard_Click);
            // 
            // MenuAddLandCard
            // 
            this.MenuAddLandCard.Name = "MenuAddLandCard";
            this.MenuAddLandCard.Size = new System.Drawing.Size(141, 22);
            this.MenuAddLandCard.Text = "إضافة صنف";
            this.MenuAddLandCard.Click += new System.EventHandler(this.MenuAddLandCard_Click);
            // 
            // FrmLandTreeAdv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLandTreeAdv";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير بحث";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trDocs)).EndInit();
            this.MenuLand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnClearSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSearch;
        private System.Windows.Forms.ContextMenuStrip MenuLand;
        private System.Windows.Forms.ToolStripMenuItem MenuOpenLandCard;
        private System.Windows.Forms.ToolStripMenuItem MenuAddLandCard;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRefresh;
        private DevExpress.XtraTreeList.TreeList trDocs;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}