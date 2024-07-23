namespace DoctorERP
{
    partial class FrmPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPay));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.dtPayDate = new System.Windows.Forms.DateTimePicker();
            this.TxtSelect = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnAddAgent = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnShowCard = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.TxtAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblAmount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblAccount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtNote = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblFromDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnPrint = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.MenuReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.MenuContextReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.MenuPreview = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.MenuDesign = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.BtnNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TxtLastAction = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.TxtLastAction);
            this.PnlMain.Controls.Add(this.kryptonLabel15);
            this.PnlMain.Controls.Add(this.dtPayDate);
            this.PnlMain.Controls.Add(this.TxtSelect);
            this.PnlMain.Controls.Add(this.TxtAmount);
            this.PnlMain.Controls.Add(this.LblAmount);
            this.PnlMain.Controls.Add(this.TxtNumber);
            this.PnlMain.Controls.Add(this.kryptonLabel1);
            this.PnlMain.Controls.Add(this.LblAccount);
            this.PnlMain.Controls.Add(this.TxtNote);
            this.PnlMain.Controls.Add(this.LblID);
            this.PnlMain.Controls.Add(this.LblFromDate);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 28);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(646, 220);
            this.PnlMain.TabIndex = 0;
            // 
            // dtPayDate
            // 
            this.dtPayDate.CustomFormat = "dd/MM/yyyy";
            this.dtPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPayDate.Location = new System.Drawing.Point(182, 33);
            this.dtPayDate.Name = "dtPayDate";
            this.dtPayDate.Size = new System.Drawing.Size(338, 20);
            this.dtPayDate.TabIndex = 0;
            // 
            // TxtSelect
            // 
            this.TxtSelect.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnSearch,
            this.BtnAddAgent,
            this.BtnShowCard});
            this.TxtSelect.Location = new System.Drawing.Point(182, 59);
            this.TxtSelect.Name = "TxtSelect";
            this.TxtSelect.Size = new System.Drawing.Size(338, 21);
            this.TxtSelect.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSelect.TabIndex = 1;
            this.TxtSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSelect_KeyDown);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Image = global::DoctorERP.Properties.Resources.BtnSearch;
            this.BtnSearch.UniqueName = "E3BBAC1E54F946ADA49433CFF1391045";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSeacrh_Click);
            // 
            // BtnAddAgent
            // 
            this.BtnAddAgent.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnAddAgent.Image = global::DoctorERP.Properties.Resources.add;
            this.BtnAddAgent.UniqueName = "152BBCBC42894A4DC8A1D4783A9BAED8";
            this.BtnAddAgent.Click += new System.EventHandler(this.BtnAddAgent_Click);
            // 
            // BtnShowCard
            // 
            this.BtnShowCard.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnShowCard.Image = global::DoctorERP.Properties.Resources.Card;
            this.BtnShowCard.ToolTipBody = "إظهار البطاقة المختارة";
            this.BtnShowCard.ToolTipTitle = "شس";
            this.BtnShowCard.UniqueName = "B0CAF56D63214FFE058534D9E19E12F4";
            this.BtnShowCard.Click += new System.EventHandler(this.BtnShowCard_Click);
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(182, 86);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(338, 21);
            this.TxtAmount.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.TabIndex = 2;
            // 
            // LblAmount
            // 
            this.LblAmount.Location = new System.Drawing.Point(524, 88);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(38, 17);
            this.LblAmount.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmount.TabIndex = 16;
            this.LblAmount.Values.Text = "المبلغ";
            // 
            // TxtNumber
            // 
            this.TxtNumber.Location = new System.Drawing.Point(182, 6);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.ReadOnly = true;
            this.TxtNumber.Size = new System.Drawing.Size(338, 21);
            this.TxtNumber.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtNumber.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumber.TabIndex = 0;
            this.TxtNumber.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(524, 35);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(39, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "التاريخ";
            // 
            // LblAccount
            // 
            this.LblAccount.Location = new System.Drawing.Point(524, 61);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(48, 17);
            this.LblAccount.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAccount.TabIndex = 16;
            this.LblAccount.Values.Text = "الحساب";
            // 
            // TxtNote
            // 
            this.TxtNote.Location = new System.Drawing.Point(182, 113);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(338, 67);
            this.TxtNote.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNote.TabIndex = 3;
            // 
            // LblID
            // 
            this.LblID.Location = new System.Drawing.Point(524, 8);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(33, 17);
            this.LblID.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblID.TabIndex = 16;
            this.LblID.Values.Text = "الرقم";
            // 
            // LblFromDate
            // 
            this.LblFromDate.Location = new System.Drawing.Point(524, 115);
            this.LblFromDate.Name = "LblFromDate";
            this.LblFromDate.Size = new System.Drawing.Size(52, 17);
            this.LblFromDate.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFromDate.TabIndex = 16;
            this.LblFromDate.Values.Text = "ملاحظات";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(86, 8);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(68, 25);
            this.BtnDelete.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Values.Text = "حذف";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(408, 8);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(112, 25);
            this.BtnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.TabIndex = 2;
            this.BtnEdit.Values.Text = "تعديل";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(408, 8);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(112, 25);
            this.BtnAdd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Values.Text = "حفظ السند الجديد";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(646, 28);
            this.PnlTop.TabIndex = 31;
            this.PnlTop.Visible = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(157, 8);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(174, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.bindingNavigator1);
            this.PnlBottom.Controls.Add(this.BtnPrint);
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnDelete);
            this.PnlBottom.Controls.Add(this.BtnEdit);
            this.PnlBottom.Controls.Add(this.BtnAdd);
            this.PnlBottom.Controls.Add(this.BtnNew);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 248);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(646, 42);
            this.PnlBottom.TabIndex = 1;
            // 
            // BtnPrint
            // 
            this.BtnPrint.KryptonContextMenu = this.MenuReport;
            this.BtnPrint.Location = new System.Drawing.Point(334, 8);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(68, 25);
            this.BtnPrint.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.TabIndex = 6;
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
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(526, 8);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(112, 25);
            this.BtnNew.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Values.Text = "إنشاء سند جديد";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // TxtLastAction
            // 
            this.TxtLastAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLastAction.Location = new System.Drawing.Point(182, 186);
            this.TxtLastAction.Name = "TxtLastAction";
            this.TxtLastAction.ReadOnly = true;
            this.TxtLastAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtLastAction.Size = new System.Drawing.Size(338, 21);
            this.TxtLastAction.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtLastAction.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastAction.TabIndex = 46;
            this.TxtLastAction.TabStop = false;
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel15.Location = new System.Drawing.Point(524, 188);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel15.Size = new System.Drawing.Size(57, 17);
            this.kryptonLabel15.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel15.TabIndex = 47;
            this.kryptonLabel15.Values.Text = "آخر عملية";
            // 
            // FrmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 290);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بطاقة";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNote;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblFromDate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAdd;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnNew;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAccount;
        private System.Windows.Forms.DateTimePicker dtPayDate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton BtnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu MenuReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems MenuContextReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuDesign;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSelect;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnShowCard;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnAddAgent;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtLastAction;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
    }
}