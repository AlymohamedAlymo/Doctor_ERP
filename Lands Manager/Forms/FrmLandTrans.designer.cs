namespace DoctorERP
{
    partial class FrmLandTrans
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colguid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collandguid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colagent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colregdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.coldeednumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbuildingnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbuildingfeevalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colremain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Colnote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.DataGridMain = new DataGridViewEx();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnPrint = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.MenuReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.MenuContextReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.MenuPreview = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.MenuDesign = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).BeginInit();
            this.PnlBottom.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.xtraTabControl1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1059, 385);
            this.PnlMain.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1059, 385);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1057, 360);
            this.xtraTabPage1.Text = "الأرضي الغير مفرغة";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1057, 360);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colguid,
            this.collandguid,
            this.colnumber,
            this.ColLand,
            this.colagent,
            this.colregdate,
            this.coldeednumber,
            this.colbuildingnumber,
            this.colbuildingfeevalue,
            this.colremain,
            this.Colnote});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colguid
            // 
            this.colguid.Caption = "guid";
            this.colguid.FieldName = "guid";
            this.colguid.Name = "colguid";
            // 
            // collandguid
            // 
            this.collandguid.Caption = "landguid";
            this.collandguid.FieldName = "landguid";
            this.collandguid.Name = "collandguid";
            // 
            // colnumber
            // 
            this.colnumber.Caption = "م";
            this.colnumber.FieldName = "number";
            this.colnumber.Name = "colnumber";
            this.colnumber.OptionsColumn.FixedWidth = true;
            this.colnumber.Visible = true;
            this.colnumber.VisibleIndex = 0;
            // 
            // ColLand
            // 
            this.ColLand.Caption = "الصنف";
            this.ColLand.FieldName = "land";
            this.ColLand.Name = "ColLand";
            this.ColLand.OptionsColumn.FixedWidth = true;
            this.ColLand.Visible = true;
            this.ColLand.VisibleIndex = 1;
            this.ColLand.Width = 120;
            // 
            // colagent
            // 
            this.colagent.Caption = "المشتري";
            this.colagent.FieldName = "agent";
            this.colagent.Name = "colagent";
            this.colagent.OptionsColumn.FixedWidth = true;
            this.colagent.Visible = true;
            this.colagent.VisibleIndex = 2;
            this.colagent.Width = 150;
            // 
            // colregdate
            // 
            this.colregdate.Caption = "تاريخ الإفراغ";
            this.colregdate.ColumnEdit = this.repositoryItemDateEdit1;
            this.colregdate.FieldName = "regdate";
            this.colregdate.Name = "colregdate";
            this.colregdate.OptionsColumn.FixedWidth = true;
            this.colregdate.Visible = true;
            this.colregdate.VisibleIndex = 3;
            this.colregdate.Width = 110;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemDateEdit1_ButtonClick);
            // 
            // coldeednumber
            // 
            this.coldeednumber.Caption = "رقم الصك الجديد";
            this.coldeednumber.FieldName = "deednumber";
            this.coldeednumber.Name = "coldeednumber";
            this.coldeednumber.OptionsColumn.FixedWidth = true;
            this.coldeednumber.Visible = true;
            this.coldeednumber.VisibleIndex = 4;
            this.coldeednumber.Width = 80;
            // 
            // colbuildingnumber
            // 
            this.colbuildingnumber.Caption = "رقم التصرفات العقارية";
            this.colbuildingnumber.FieldName = "buildingnumber";
            this.colbuildingnumber.Name = "colbuildingnumber";
            this.colbuildingnumber.OptionsColumn.FixedWidth = true;
            this.colbuildingnumber.Visible = true;
            this.colbuildingnumber.VisibleIndex = 5;
            this.colbuildingnumber.Width = 120;
            // 
            // colbuildingfeevalue
            // 
            this.colbuildingfeevalue.Caption = "قيمة ضريبة التصرفات العقارية";
            this.colbuildingfeevalue.FieldName = "buildingfeevalue";
            this.colbuildingfeevalue.Name = "colbuildingfeevalue";
            this.colbuildingfeevalue.OptionsColumn.FixedWidth = true;
            this.colbuildingfeevalue.Visible = true;
            this.colbuildingfeevalue.VisibleIndex = 6;
            this.colbuildingfeevalue.Width = 120;
            // 
            // colremain
            // 
            this.colremain.Caption = "الرصيد المتبقي";
            this.colremain.FieldName = "remain";
            this.colremain.Name = "colremain";
            this.colremain.OptionsColumn.FixedWidth = true;
            this.colremain.Visible = true;
            this.colremain.VisibleIndex = 7;
            this.colremain.Width = 110;
            // 
            // Colnote
            // 
            this.Colnote.Caption = "ملاحظات";
            this.Colnote.FieldName = "note";
            this.Colnote.Name = "Colnote";
            this.Colnote.Visible = true;
            this.Colnote.VisibleIndex = 8;
            this.Colnote.Width = 149;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.DataGridMain);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1057, 360);
            this.xtraTabPage2.Text = "الأراضي المفرغة";
            // 
            // DataGridMain
            // 
            this.DataGridMain.AllowUserToAddRows = false;
            this.DataGridMain.AllowUserToDeleteRows = false;
            this.DataGridMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMain.Location = new System.Drawing.Point(0, 0);
            this.DataGridMain.Name = "DataGridMain";
            this.DataGridMain.ReadOnly = true;
            this.DataGridMain.RowHeadersVisible = false;
            this.DataGridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridMain.Size = new System.Drawing.Size(1057, 360);
            this.DataGridMain.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.DataGridMain.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.TabIndex = 25;
            this.DataGridMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridMain_MouseDown);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 12);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(979, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(68, 25);
            this.BtnAdd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Values.Text = "حفظ";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnPrint);
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnAdd);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 385);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(1059, 49);
            this.PnlBottom.TabIndex = 1;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.KryptonContextMenu = this.MenuReport;
            this.BtnPrint.Location = new System.Drawing.Point(905, 12);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(68, 25);
            this.BtnPrint.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.TabIndex = 32;
            this.BtnPrint.Values.Text = "طباعة";
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // MenuReport
            // 
            this.MenuReport.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.MenuContextReport});
            // 
            // MenuContextReport
            // 
            this.MenuContextReport.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.MenuPreview,
            this.MenuDesign});
            // 
            // MenuPreview
            // 
            this.MenuPreview.StateNormal.ItemTextStandard.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPreview.Text = "معاينة";
            this.MenuPreview.Click += new System.EventHandler(this.MenuPreview_Click);
            // 
            // MenuDesign
            // 
            this.MenuDesign.StateNormal.ItemTextStandard.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuDesign.Text = "تصميم";
            this.MenuDesign.Click += new System.EventHandler(this.MenuDesign_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // MenuRemove
            // 
            this.MenuRemove.Name = "MenuRemove";
            this.MenuRemove.Size = new System.Drawing.Size(180, 22);
            this.MenuRemove.Text = "حذف";
            this.MenuRemove.Click += new System.EventHandler(this.MenuRemove_Click);
            // 
            // FrmLandTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 434);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.Name = "FrmLandTrans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير إفراغات الأراضي";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMat_FormClosing);
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).EndInit();
            this.PnlBottom.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAdd;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton BtnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu MenuReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems MenuContextReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuDesign;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colguid;
        private DevExpress.XtraGrid.Columns.GridColumn collandguid;
        private DevExpress.XtraGrid.Columns.GridColumn colnumber;
        private DevExpress.XtraGrid.Columns.GridColumn ColLand;
        private DevExpress.XtraGrid.Columns.GridColumn colagent;
        private DevExpress.XtraGrid.Columns.GridColumn colregdate;
        private DevExpress.XtraGrid.Columns.GridColumn coldeednumber;
        private DevExpress.XtraGrid.Columns.GridColumn colbuildingnumber;
        private DevExpress.XtraGrid.Columns.GridColumn colbuildingfeevalue;
        private DevExpress.XtraGrid.Columns.GridColumn colremain;
        private DevExpress.XtraGrid.Columns.GridColumn Colnote;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DataGridViewEx DataGridMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuRemove;
    }
}