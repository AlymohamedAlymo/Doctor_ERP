namespace DoctorERP
{
    partial class FrmTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTable));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.dtRegDate = new System.Windows.Forms.DateTimePicker();
            this.chkFav = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.CmbType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.TxtSelect = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnShowCard = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.TxtPrice = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblPrice = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtNote = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblRegDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblNumber = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblNote = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
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
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbType)).BeginInit();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.dtRegDate);
            this.PnlMain.Controls.Add(this.chkFav);
            this.PnlMain.Controls.Add(this.CmbType);
            this.PnlMain.Controls.Add(this.TxtSelect);
            this.PnlMain.Controls.Add(this.TxtPrice);
            this.PnlMain.Controls.Add(this.TxtName);
            this.PnlMain.Controls.Add(this.LblPrice);
            this.PnlMain.Controls.Add(this.TxtNumber);
            this.PnlMain.Controls.Add(this.LblName);
            this.PnlMain.Controls.Add(this.TxtNote);
            this.PnlMain.Controls.Add(this.LblRegDate);
            this.PnlMain.Controls.Add(this.LblNumber);
            this.PnlMain.Controls.Add(this.LblType);
            this.PnlMain.Controls.Add(this.LblNote);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 28);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(516, 256);
            this.PnlMain.TabIndex = 0;
            // 
            // dtRegDate
            // 
            this.dtRegDate.CustomFormat = "dd/MM/yyyy";
            this.dtRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRegDate.Location = new System.Drawing.Point(294, 8);
            this.dtRegDate.Name = "dtRegDate";
            this.dtRegDate.Size = new System.Drawing.Size(112, 20);
            this.dtRegDate.TabIndex = 0;
            // 
            // chkFav
            // 
            this.chkFav.Location = new System.Drawing.Point(326, 109);
            this.chkFav.Name = "chkFav";
            this.chkFav.Size = new System.Drawing.Size(80, 17);
            this.chkFav.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFav.TabIndex = 4;
            this.chkFav.Values.Text = "في المفضلة";
            // 
            // CmbType
            // 
            this.CmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbType.DropDownWidth = 205;
            this.CmbType.Location = new System.Drawing.Point(68, 82);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(338, 21);
            this.CmbType.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbType.TabIndex = 3;
            // 
            // TxtSelect
            // 
            this.TxtSelect.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnSearch,
            this.BtnShowCard});
            this.TxtSelect.Location = new System.Drawing.Point(68, 229);
            this.TxtSelect.Name = "TxtSelect";
            this.TxtSelect.Size = new System.Drawing.Size(338, 21);
            this.TxtSelect.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSelect.TabIndex = 2;
            this.TxtSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSelect_KeyDown);
            // 
            // BtnSearch
            // 
            this.BtnSearch.UniqueName = "E3BBAC1E54F946ADA49433CFF1391045";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSeacrh_Click);
            // 
            // BtnShowCard
            // 
            this.BtnShowCard.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnShowCard.ToolTipBody = "إظهار البطاقة المختارة";
            this.BtnShowCard.ToolTipTitle = "شس";
            this.BtnShowCard.UniqueName = "B0CAF56D63214FFE058534D9E19E12F4";
            this.BtnShowCard.Click += new System.EventHandler(this.BtnShowCard_Click);
            // 
            // TxtPrice
            // 
            this.TxtPrice.Location = new System.Drawing.Point(68, 132);
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.Size = new System.Drawing.Size(338, 21);
            this.TxtPrice.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrice.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(68, 58);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(338, 21);
            this.TxtName.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.TabIndex = 2;
            // 
            // LblPrice
            // 
            this.LblPrice.Location = new System.Drawing.Point(412, 134);
            this.LblPrice.Name = "LblPrice";
            this.LblPrice.Size = new System.Drawing.Size(38, 17);
            this.LblPrice.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrice.TabIndex = 16;
            this.LblPrice.Values.Text = "السعر";
            // 
            // TxtNumber
            // 
            this.TxtNumber.Location = new System.Drawing.Point(68, 34);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Size = new System.Drawing.Size(338, 21);
            this.TxtNumber.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumber.TabIndex = 1;
            // 
            // LblName
            // 
            this.LblName.Location = new System.Drawing.Point(412, 60);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(39, 17);
            this.LblName.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.TabIndex = 16;
            this.LblName.Values.Text = "الاسم";
            // 
            // TxtNote
            // 
            this.TxtNote.Location = new System.Drawing.Point(68, 156);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(338, 67);
            this.TxtNote.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNote.TabIndex = 5;
            // 
            // LblRegDate
            // 
            this.LblRegDate.Location = new System.Drawing.Point(411, 10);
            this.LblRegDate.Name = "LblRegDate";
            this.LblRegDate.Size = new System.Drawing.Size(39, 17);
            this.LblRegDate.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegDate.TabIndex = 16;
            this.LblRegDate.Values.Text = "التاريخ";
            // 
            // LblNumber
            // 
            this.LblNumber.Location = new System.Drawing.Point(412, 36);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(33, 17);
            this.LblNumber.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumber.TabIndex = 16;
            this.LblNumber.Values.Text = "الرقم";
            // 
            // LblType
            // 
            this.LblType.Location = new System.Drawing.Point(412, 84);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(32, 17);
            this.LblType.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.TabIndex = 16;
            this.LblType.Values.Text = "النوع";
            // 
            // LblNote
            // 
            this.LblNote.Location = new System.Drawing.Point(412, 156);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(52, 17);
            this.LblNote.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.TabIndex = 16;
            this.LblNote.Values.Text = "ملاحظات";
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
            this.BtnEdit.Location = new System.Drawing.Point(262, 8);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(68, 25);
            this.BtnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.TabIndex = 2;
            this.BtnEdit.Values.Text = "تعديل";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(338, 8);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(68, 25);
            this.BtnAdd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Values.Text = "إضافة";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.bindingNavigator1);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(516, 28);
            this.PnlTop.TabIndex = 31;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(516, 25);
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
            this.PnlBottom.Controls.Add(this.BtnPrint);
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnDelete);
            this.PnlBottom.Controls.Add(this.BtnEdit);
            this.PnlBottom.Controls.Add(this.BtnAdd);
            this.PnlBottom.Controls.Add(this.BtnNew);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 284);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(516, 42);
            this.PnlBottom.TabIndex = 1;
            // 
            // BtnPrint
            // 
            this.BtnPrint.KryptonContextMenu = this.MenuReport;
            this.BtnPrint.Location = new System.Drawing.Point(188, 8);
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
            this.BtnNew.Location = new System.Drawing.Point(412, 8);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(68, 25);
            this.BtnNew.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Values.Text = "جديد";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // FrmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 326);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTable";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بطاقة";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbType)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNote;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblNote;
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
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblType;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkFav;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblName;
        private System.Windows.Forms.DateTimePicker dtRegDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblRegDate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSelect;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton BtnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu MenuReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems MenuContextReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuDesign;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnShowCard;
    }
}