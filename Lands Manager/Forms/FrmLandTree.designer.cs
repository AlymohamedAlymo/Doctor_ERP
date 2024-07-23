namespace DoctorERP
{
    partial class FrmLandTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLandTree));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TxtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnClearSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblSearch = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trDocs = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuLand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuOpenLandCard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddLandCard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDeleteAllNonSolditems = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMoveToBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExpand = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnCollapse = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MenuLand.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCollapse);
            this.panel1.Controls.Add(this.BtnExpand);
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
            this.trDocs.AllowDrop = true;
            this.trDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trDocs.ImageIndex = 0;
            this.trDocs.ImageList = this.imageList1;
            this.trDocs.Location = new System.Drawing.Point(0, 0);
            this.trDocs.Name = "trDocs";
            this.trDocs.RightToLeftLayout = true;
            this.trDocs.SelectedImageIndex = 0;
            this.trDocs.Size = new System.Drawing.Size(784, 498);
            this.trDocs.TabIndex = 0;
            this.trDocs.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trDocs_ItemDrag);
            this.trDocs.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trDocs_NodeMouseClick);
            this.trDocs.Click += new System.EventHandler(this.trDocs_Click);
            this.trDocs.DragDrop += new System.Windows.Forms.DragEventHandler(this.trDocs_DragDrop);
            this.trDocs.DragEnter += new System.Windows.Forms.DragEventHandler(this.trDocs_DragEnter);
            this.trDocs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trDocs_MouseDoubleClick);
            this.trDocs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trDocs_MouseDown);
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
            this.MenuAddLandCard,
            this.MenuMoveToBlock,
            this.MenuDelete,
            this.MenuDeleteAllNonSolditems});
            this.MenuLand.Name = "MenuLand";
            this.MenuLand.Size = new System.Drawing.Size(200, 114);
            this.MenuLand.Opening += new System.ComponentModel.CancelEventHandler(this.MenuLand_Opening);
            // 
            // MenuOpenLandCard
            // 
            this.MenuOpenLandCard.Name = "MenuOpenLandCard";
            this.MenuOpenLandCard.Size = new System.Drawing.Size(199, 22);
            this.MenuOpenLandCard.Text = "بطاقة الصنف";
            this.MenuOpenLandCard.Click += new System.EventHandler(this.MenuOpenLandCard_Click);
            // 
            // MenuAddLandCard
            // 
            this.MenuAddLandCard.Name = "MenuAddLandCard";
            this.MenuAddLandCard.Size = new System.Drawing.Size(199, 22);
            this.MenuAddLandCard.Text = "إضافة صنف";
            this.MenuAddLandCard.Click += new System.EventHandler(this.MenuAddLandCard_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(199, 22);
            this.MenuDelete.Text = "حذف صنف";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // MenuDeleteAllNonSolditems
            // 
            this.MenuDeleteAllNonSolditems.Name = "MenuDeleteAllNonSolditems";
            this.MenuDeleteAllNonSolditems.Size = new System.Drawing.Size(199, 22);
            this.MenuDeleteAllNonSolditems.Text = "حذف الأصناف الغير مباعة";
            this.MenuDeleteAllNonSolditems.Click += new System.EventHandler(this.MenuDeleteAllNonSolditems_Click);
            // 
            // MenuMoveToBlock
            // 
            this.MenuMoveToBlock.Name = "MenuMoveToBlock";
            this.MenuMoveToBlock.Size = new System.Drawing.Size(199, 22);
            this.MenuMoveToBlock.Text = "نقل إلى البلوك";
            // 
            // BtnExpand
            // 
            this.BtnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExpand.Location = new System.Drawing.Point(619, 17);
            this.BtnExpand.Name = "BtnExpand";
            this.BtnExpand.Size = new System.Drawing.Size(68, 25);
            this.BtnExpand.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExpand.TabIndex = 21;
            this.BtnExpand.Values.Text = "+";
            this.BtnExpand.Click += new System.EventHandler(this.BtnExpand_Click);
            // 
            // BtnCollapse
            // 
            this.BtnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCollapse.Location = new System.Drawing.Point(545, 17);
            this.BtnCollapse.Name = "BtnCollapse";
            this.BtnCollapse.Size = new System.Drawing.Size(68, 25);
            this.BtnCollapse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCollapse.TabIndex = 21;
            this.BtnCollapse.Values.Text = "-";
            this.BtnCollapse.Click += new System.EventHandler(this.BtnCollapse_Click);
            // 
            // FrmLandTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLandTree";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير بحث";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.MenuLand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trDocs;
        private System.Windows.Forms.ImageList imageList1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnClearSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSearch;
        private System.Windows.Forms.ContextMenuStrip MenuLand;
        private System.Windows.Forms.ToolStripMenuItem MenuOpenLandCard;
        private System.Windows.Forms.ToolStripMenuItem MenuAddLandCard;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRefresh;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.ToolStripMenuItem MenuDeleteAllNonSolditems;
        private System.Windows.Forms.ToolStripMenuItem MenuMoveToBlock;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCollapse;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnExpand;
    }
}