namespace DataBaseTemplate
{
    partial class FrmPayContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayContract));
            this.PnlTop = new DevExpress.XtraEditors.PanelControl();
            this.Txtnumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Lblnumber = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtPayDate = new DevExpress.XtraEditors.DateEdit();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.TxtNote = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.PnlMain = new DevExpress.XtraEditors.PanelControl();
            this.MainGridReadyItems = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColParentGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColContractNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnSelectItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColAgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTotalNet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColRemain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.PnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.BtnPrint = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.MenuPreView = new DevExpress.XtraBars.BarButtonItem();
            this.MenuPrint = new DevExpress.XtraBars.BarButtonItem();
            this.MenuDesign = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.BtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.BtnNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.PnlTop)).BeginInit();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPayDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPayDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMain)).BeginInit();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridReadyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSelectItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PnlBottom)).BeginInit();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.Txtnumber);
            this.PnlTop.Controls.Add(this.Lblnumber);
            this.PnlTop.Controls.Add(this.dtPayDate);
            this.PnlTop.Controls.Add(this.dataNavigator1);
            this.PnlTop.Controls.Add(this.TxtNote);
            this.PnlTop.Controls.Add(this.labelControl5);
            this.PnlTop.Controls.Add(this.labelControl7);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1085, 71);
            this.PnlTop.TabIndex = 0;
            // 
            // Txtnumber
            // 
            this.Txtnumber.Location = new System.Drawing.Point(12, 10);
            this.Txtnumber.Name = "Txtnumber";
            this.Txtnumber.ReadOnly = true;
            this.Txtnumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtnumber.Size = new System.Drawing.Size(145, 21);
            this.Txtnumber.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txtnumber.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtnumber.TabIndex = 25;
            this.Txtnumber.TabStop = false;
            // 
            // Lblnumber
            // 
            this.Lblnumber.Location = new System.Drawing.Point(160, 12);
            this.Lblnumber.Name = "Lblnumber";
            this.Lblnumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lblnumber.Size = new System.Drawing.Size(33, 17);
            this.Lblnumber.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblnumber.TabIndex = 26;
            this.Lblnumber.Values.Text = "الرقم";
            // 
            // dtPayDate
            // 
            this.dtPayDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPayDate.EditValue = null;
            this.dtPayDate.Location = new System.Drawing.Point(805, 7);
            this.dtPayDate.Name = "dtPayDate";
            this.dtPayDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPayDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPayDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtPayDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPayDate.Size = new System.Drawing.Size(209, 20);
            this.dtPayDate.TabIndex = 21;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Buttons.Append.Visible = false;
            this.dataNavigator1.Buttons.CancelEdit.Visible = false;
            this.dataNavigator1.Buttons.EndEdit.Visible = false;
            this.dataNavigator1.Buttons.Remove.Visible = false;
            this.dataNavigator1.Location = new System.Drawing.Point(12, 37);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(183, 24);
            this.dataNavigator1.TabIndex = 18;
            this.dataNavigator1.Text = "dataNavigator1";
            this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigator1.TextStringFormat = "{1} / {0}";
            // 
            // TxtNote
            // 
            this.TxtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNote.Location = new System.Drawing.Point(805, 33);
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(209, 20);
            this.TxtNote.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(1017, 36);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "ملاحظات";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Location = new System.Drawing.Point(1017, 10);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(28, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "التاريخ";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.MainGridReadyItems);
            this.PnlMain.Controls.Add(this.panel1);
            this.PnlMain.Controls.Add(this.labelControl2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 71);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1085, 395);
            this.PnlMain.TabIndex = 0;
            // 
            // MainGridReadyItems
            // 
            this.MainGridReadyItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGridReadyItems.Location = new System.Drawing.Point(2, 2);
            this.MainGridReadyItems.MainView = this.GridView1;
            this.MainGridReadyItems.Name = "MainGridReadyItems";
            this.MainGridReadyItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.BtnSelectItem});
            this.MainGridReadyItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MainGridReadyItems.Size = new System.Drawing.Size(1081, 326);
            this.MainGridReadyItems.TabIndex = 1;
            this.MainGridReadyItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            this.MainGridReadyItems.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.MainGridReadyItems_ProcessGridKey);
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColGuid,
            this.ColParentGuid,
            this.ColNumber,
            this.ColContractNo,
            this.ColCode,
            this.ColLand,
            this.ColAgent,
            this.ColAmount,
            this.ColTotalNet,
            this.ColRemain,
            this.ColNote});
            this.GridView1.GridControl = this.MainGridReadyItems;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.GridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.GridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.GridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // ColGuid
            // 
            this.ColGuid.Caption = "gridColumn1";
            this.ColGuid.FieldName = "guid";
            this.ColGuid.Name = "ColGuid";
            this.ColGuid.Width = 69;
            // 
            // ColParentGuid
            // 
            this.ColParentGuid.Caption = "gridColumn1";
            this.ColParentGuid.FieldName = "parentguid";
            this.ColParentGuid.Name = "ColParentGuid";
            this.ColParentGuid.Width = 69;
            // 
            // ColNumber
            // 
            this.ColNumber.Caption = "م";
            this.ColNumber.FieldName = "number";
            this.ColNumber.Name = "ColNumber";
            this.ColNumber.OptionsColumn.FixedWidth = true;
            this.ColNumber.Visible = true;
            this.ColNumber.VisibleIndex = 0;
            this.ColNumber.Width = 25;
            // 
            // ColContractNo
            // 
            this.ColContractNo.Caption = "رقم العقد";
            this.ColContractNo.ColumnEdit = this.BtnSelectItem;
            this.ColContractNo.FieldName = "contractno";
            this.ColContractNo.Name = "ColContractNo";
            this.ColContractNo.Visible = true;
            this.ColContractNo.VisibleIndex = 1;
            this.ColContractNo.Width = 100;
            // 
            // BtnSelectItem
            // 
            this.BtnSelectItem.AutoHeight = false;
            this.BtnSelectItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BtnSelectItem.Name = "BtnSelectItem";
            this.BtnSelectItem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SelectItem_ButtonClick);
            this.BtnSelectItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectItem_KeyDown);
            // 
            // ColCode
            // 
            this.ColCode.Caption = "الكود";
            this.ColCode.FieldName = "code";
            this.ColCode.Name = "ColCode";
            this.ColCode.Visible = true;
            this.ColCode.VisibleIndex = 2;
            this.ColCode.Width = 70;
            // 
            // ColLand
            // 
            this.ColLand.Caption = "رقم الأرض";
            this.ColLand.FieldName = "land";
            this.ColLand.Name = "ColLand";
            this.ColLand.Visible = true;
            this.ColLand.VisibleIndex = 3;
            this.ColLand.Width = 100;
            // 
            // ColAgent
            // 
            this.ColAgent.Caption = "العميل";
            this.ColAgent.FieldName = "agent";
            this.ColAgent.Name = "ColAgent";
            this.ColAgent.Visible = true;
            this.ColAgent.VisibleIndex = 4;
            this.ColAgent.Width = 100;
            // 
            // ColAmount
            // 
            this.ColAmount.Caption = "المبلغ";
            this.ColAmount.FieldName = "amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.Visible = true;
            this.ColAmount.VisibleIndex = 5;
            this.ColAmount.Width = 120;
            // 
            // ColTotalNet
            // 
            this.ColTotalNet.Caption = "قيمة العقد";
            this.ColTotalNet.FieldName = "totalnet";
            this.ColTotalNet.Name = "ColTotalNet";
            this.ColTotalNet.Visible = true;
            this.ColTotalNet.VisibleIndex = 6;
            this.ColTotalNet.Width = 120;
            // 
            // ColRemain
            // 
            this.ColRemain.Caption = "المتبقي";
            this.ColRemain.FieldName = "remain";
            this.ColRemain.Name = "ColRemain";
            this.ColRemain.Width = 120;
            // 
            // ColNote
            // 
            this.ColNote.Caption = "ملاحظات";
            this.ColNote.FieldName = "note";
            this.ColNote.Name = "ColNote";
            this.ColNote.Visible = true;
            this.ColNote.VisibleIndex = 7;
            this.ColNote.Width = 200;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 65);
            this.panel1.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(467, 110);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "labelControl2";
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
            this.PnlBottom.Location = new System.Drawing.Point(0, 466);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(1085, 58);
            this.PnlBottom.TabIndex = 36;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.DropDownControl = this.popupMenu1;
            this.BtnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrint.ImageOptions.Image")));
            this.BtnPrint.Location = new System.Drawing.Point(696, 10);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(103, 38);
            this.BtnPrint.TabIndex = 11;
            this.BtnPrint.Text = "طباعة";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPreView),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuDesign)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // MenuPreView
            // 
            this.MenuPreView.Caption = "معاينة";
            this.MenuPreView.Id = 0;
            this.MenuPreView.Name = "MenuPreView";
            // 
            // MenuPrint
            // 
            this.MenuPrint.Caption = "طباعة";
            this.MenuPrint.Id = 1;
            this.MenuPrint.Name = "MenuPrint";
            // 
            // MenuDesign
            // 
            this.MenuDesign.Caption = "تصميم";
            this.MenuDesign.Id = 2;
            this.MenuDesign.Name = "MenuDesign";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MenuPreView,
            this.MenuPrint,
            this.MenuDesign});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1085, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 524);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1085, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 524);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1085, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 524);
            // 
            // BtnCancel
            // 
            this.BtnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.ImageOptions.Image")));
            this.BtnCancel.Location = new System.Drawing.Point(12, 10);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(103, 38);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "إلغاء الأمر";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.ImageOptions.Image")));
            this.BtnDelete.Location = new System.Drawing.Point(121, 10);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(103, 38);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "حذف";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnEdit.ImageOptions.Image")));
            this.BtnEdit.Location = new System.Drawing.Point(805, 10);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(103, 38);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "تعديل";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.ImageOptions.Image")));
            this.BtnAdd.Location = new System.Drawing.Point(805, 10);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(103, 38);
            this.BtnAdd.TabIndex = 9;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.ImageOptions.Image")));
            this.BtnNew.Location = new System.Drawing.Point(914, 10);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(103, 38);
            this.BtnNew.TabIndex = 10;
            this.BtnNew.Text = "جديد";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // FrmPayContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 524);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmPayContract";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سند قبض عقود";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReadyItems_FormClosing);
            this.Load += new System.EventHandler(this.FrmReadyItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PnlTop)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPayDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPayDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMain)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridReadyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSelectItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PnlBottom)).EndInit();
            this.PnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl PnlTop;
        private DevExpress.XtraEditors.PanelControl PnlMain;
        private DevExpress.XtraEditors.PanelControl PnlBottom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl MainGridReadyItems;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit BtnSelectItem;
        private DevExpress.XtraEditors.TextEdit TxtNote;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton BtnEdit;
        private DevExpress.XtraEditors.SimpleButton BtnAdd;
        private DevExpress.XtraEditors.SimpleButton BtnNew;
        private DevExpress.XtraEditors.DateEdit dtPayDate;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtnumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lblnumber;
        private DevExpress.XtraEditors.DropDownButton BtnPrint;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem MenuPreView;
        private DevExpress.XtraBars.BarButtonItem MenuPrint;
        private DevExpress.XtraBars.BarButtonItem MenuDesign;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ColGuid;
        private DevExpress.XtraGrid.Columns.GridColumn ColParentGuid;
        private DevExpress.XtraGrid.Columns.GridColumn ColNumber;
        private DevExpress.XtraGrid.Columns.GridColumn ColContractNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColLand;
        private DevExpress.XtraGrid.Columns.GridColumn ColAmount;
        private DevExpress.XtraGrid.Columns.GridColumn ColTotalNet;
        private DevExpress.XtraGrid.Columns.GridColumn ColRemain;
        private DevExpress.XtraGrid.Columns.GridColumn ColNote;
        private DevExpress.XtraGrid.Columns.GridColumn ColAgent;
    }
}