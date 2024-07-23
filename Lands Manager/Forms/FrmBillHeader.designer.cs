namespace DoctorERP
{
    partial class FrmBillHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBillHeader));
            this.PnlTop = new DevExpress.XtraEditors.PanelControl();
            this.Txtlastaction = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnAddFromBlock = new DevExpress.XtraEditors.SimpleButton();
            this.CmbBuyerData = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CmbOwnerData = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Txtnumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblHint = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Lblnumber = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSelectBuyer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnAddBuyer = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnShowBuyerCard = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnSearchBuyer = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblAgent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSelectOwner = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnAddOwner = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnShowOwnerCard = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnSearchOwner = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblOwner = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtRegDate = new DevExpress.XtraEditors.DateEdit();
            this.TxtNote = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.PnlMain = new DevExpress.XtraEditors.PanelControl();
            this.MainGridReadyItems = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColGuid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColParentGuid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColLandGuid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColOwnerGuid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColBuyerGuid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColContractNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColLand = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.BtnSelectItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ColPrice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColDiscountTotalText = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColNetPrice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColDiscountTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColDiscountTotalValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColBuildingFeeValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.WorkFeeBands = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColWorkFeeValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColDiscountFeeValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColDiscountFee = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColDiscountFeeText = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColNetWorkFee = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColVatValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColVatWorkFee = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ColTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColTotalNet = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColNote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ColStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtotalworkfeeDiscount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txttotalworkfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtTotalVat = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txttotalbuidlingfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txttotaldiscountfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtPrice = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtNetPrice = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txttotaldiscounttotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtTotalNet = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtNetPiceNetWorkFeeVAT = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtNetPrice2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtNetPiceNetWorkFee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtTotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Lbltotalareaprice = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.PnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.BtnPrint = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.MenuPreView = new DevExpress.XtraBars.BarButtonItem();
            this.MenuPrint = new DevExpress.XtraBars.BarButtonItem();
            this.MenuDesign = new DevExpress.XtraBars.BarButtonItem();
            this.MenuOneByOne = new DevExpress.XtraBars.BarSubItem();
            this.MenuPrintOnebyOne = new DevExpress.XtraBars.BarButtonItem();
            this.MenuPreviewOneByOne = new DevExpress.XtraBars.BarButtonItem();
            this.MenuDesignOneByOne = new DevExpress.XtraBars.BarButtonItem();
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
            this.barManagerGrid = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.MenuLand = new DevExpress.XtraBars.BarButtonItem();
            this.MenuConvertToReturn = new DevExpress.XtraBars.BarButtonItem();
            this.MenuPrintOne = new DevExpress.XtraBars.BarButtonItem();
            this.MenuPreviewOne = new DevExpress.XtraBars.BarButtonItem();
            this.MenuPrintLandInfo = new DevExpress.XtraBars.BarButtonItem();
            this.MenuAllowEditPrice = new DevExpress.XtraBars.BarButtonItem();
            this.MenuGrid = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PnlTop)).BeginInit();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBuyerData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOwnerData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMain)).BeginInit();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridReadyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSelectItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PnlBottom)).BeginInit();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.Txtlastaction);
            this.PnlTop.Controls.Add(this.kryptonLabel15);
            this.PnlTop.Controls.Add(this.BtnAddFromBlock);
            this.PnlTop.Controls.Add(this.CmbBuyerData);
            this.PnlTop.Controls.Add(this.CmbOwnerData);
            this.PnlTop.Controls.Add(this.Txtnumber);
            this.PnlTop.Controls.Add(this.LblHint);
            this.PnlTop.Controls.Add(this.Lblnumber);
            this.PnlTop.Controls.Add(this.TxtSelectBuyer);
            this.PnlTop.Controls.Add(this.LblAgent);
            this.PnlTop.Controls.Add(this.TxtSelectOwner);
            this.PnlTop.Controls.Add(this.LblOwner);
            this.PnlTop.Controls.Add(this.dtRegDate);
            this.PnlTop.Controls.Add(this.TxtNote);
            this.PnlTop.Controls.Add(this.labelControl5);
            this.PnlTop.Controls.Add(this.labelControl7);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1152, 120);
            this.PnlTop.TabIndex = 0;
            // 
            // Txtlastaction
            // 
            this.Txtlastaction.Location = new System.Drawing.Point(12, 88);
            this.Txtlastaction.Name = "Txtlastaction";
            this.Txtlastaction.ReadOnly = true;
            this.Txtlastaction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtlastaction.Size = new System.Drawing.Size(189, 21);
            this.Txtlastaction.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txtlastaction.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtlastaction.TabIndex = 48;
            this.Txtlastaction.TabStop = false;
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(206, 92);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel15.Size = new System.Drawing.Size(57, 17);
            this.kryptonLabel15.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel15.TabIndex = 49;
            this.kryptonLabel15.Values.Text = "آخر عملية";
            // 
            // BtnAddFromBlock
            // 
            this.BtnAddFromBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddFromBlock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddFromBlock.ImageOptions.Image")));
            this.BtnAddFromBlock.Location = new System.Drawing.Point(589, 9);
            this.BtnAddFromBlock.Name = "BtnAddFromBlock";
            this.BtnAddFromBlock.Size = new System.Drawing.Size(149, 28);
            this.BtnAddFromBlock.TabIndex = 28;
            this.BtnAddFromBlock.Text = "إدراج أراضي من بلوك";
            this.BtnAddFromBlock.Click += new System.EventHandler(this.BtnAddFromBlock_Click);
            // 
            // CmbBuyerData
            // 
            this.CmbBuyerData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbBuyerData.Location = new System.Drawing.Point(589, 79);
            this.CmbBuyerData.Name = "CmbBuyerData";
            this.CmbBuyerData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.CmbBuyerData.Properties.Appearance.Options.UseFont = true;
            this.CmbBuyerData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbBuyerData.Properties.Items.AddRange(new object[] {
            "العميل",
            "الوكيل"});
            this.CmbBuyerData.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbBuyerData.Size = new System.Drawing.Size(149, 30);
            this.CmbBuyerData.TabIndex = 27;
            this.CmbBuyerData.SelectedIndexChanged += new System.EventHandler(this.CmbBuyer_SelectedIndexChanged);
            // 
            // CmbOwnerData
            // 
            this.CmbOwnerData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbOwnerData.Location = new System.Drawing.Point(589, 43);
            this.CmbOwnerData.Name = "CmbOwnerData";
            this.CmbOwnerData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.CmbOwnerData.Properties.Appearance.Options.UseFont = true;
            this.CmbOwnerData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbOwnerData.Properties.Items.AddRange(new object[] {
            "المالك",
            "الوكيل",
            "المكتب"});
            this.CmbOwnerData.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbOwnerData.Size = new System.Drawing.Size(149, 30);
            this.CmbOwnerData.TabIndex = 27;
            this.CmbOwnerData.SelectedIndexChanged += new System.EventHandler(this.CmbOwner_SelectedIndexChanged);
            // 
            // Txtnumber
            // 
            this.Txtnumber.Location = new System.Drawing.Point(12, 10);
            this.Txtnumber.Name = "Txtnumber";
            this.Txtnumber.ReadOnly = true;
            this.Txtnumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtnumber.Size = new System.Drawing.Size(189, 21);
            this.Txtnumber.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txtnumber.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtnumber.TabIndex = 25;
            this.Txtnumber.TabStop = false;
            // 
            // LblHint
            // 
            this.LblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblHint.Location = new System.Drawing.Point(430, 50);
            this.LblHint.Name = "LblHint";
            this.LblHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblHint.Size = new System.Drawing.Size(143, 30);
            this.LblHint.StateCommon.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.LblHint.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHint.TabIndex = 26;
            this.LblHint.Values.Text = "عقد بيع أرض";
            // 
            // Lblnumber
            // 
            this.Lblnumber.Location = new System.Drawing.Point(206, 12);
            this.Lblnumber.Name = "Lblnumber";
            this.Lblnumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lblnumber.Size = new System.Drawing.Size(33, 17);
            this.Lblnumber.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblnumber.TabIndex = 26;
            this.Lblnumber.Values.Text = "الرقم";
            // 
            // TxtSelectBuyer
            // 
            this.TxtSelectBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSelectBuyer.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnAddBuyer,
            this.BtnShowBuyerCard,
            this.BtnSearchBuyer});
            this.TxtSelectBuyer.Location = new System.Drawing.Point(744, 79);
            this.TxtSelectBuyer.Name = "TxtSelectBuyer";
            this.TxtSelectBuyer.Size = new System.Drawing.Size(337, 30);
            this.TxtSelectBuyer.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 14F);
            this.TxtSelectBuyer.TabIndex = 23;
            this.TxtSelectBuyer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSelectBuyer_KeyDown);
            // 
            // BtnAddBuyer
            // 
            this.BtnAddBuyer.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.BtnAddBuyer.Image = global::DoctorERP.Properties.Resources.add;
            this.BtnAddBuyer.UniqueName = "77FFB538B37047AF78B17F2D143A27C2";
            this.BtnAddBuyer.Click += new System.EventHandler(this.BtnAddBuyer_Click);
            // 
            // BtnShowBuyerCard
            // 
            this.BtnShowBuyerCard.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.BtnShowBuyerCard.Image = global::DoctorERP.Properties.Resources.Card;
            this.BtnShowBuyerCard.ToolTipBody = "إظهار البطاقة المختارة";
            this.BtnShowBuyerCard.ToolTipTitle = "شس";
            this.BtnShowBuyerCard.UniqueName = "B0CAF56D63214FFE058534D9E19E12F4";
            this.BtnShowBuyerCard.Click += new System.EventHandler(this.BtnShowBuyerCard_Click);
            // 
            // BtnSearchBuyer
            // 
            this.BtnSearchBuyer.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnSearchBuyer.Image = global::DoctorERP.Properties.Resources.BtnSearch;
            this.BtnSearchBuyer.UniqueName = "E3BBAC1E54F946ADA49433CFF1391045";
            this.BtnSearchBuyer.Click += new System.EventHandler(this.BtnSeacrhBuyer_Click);
            // 
            // LblAgent
            // 
            this.LblAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAgent.Location = new System.Drawing.Point(1091, 86);
            this.LblAgent.Name = "LblAgent";
            this.LblAgent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblAgent.Size = new System.Drawing.Size(41, 17);
            this.LblAgent.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgent.TabIndex = 24;
            this.LblAgent.Values.Text = "العميل";
            // 
            // TxtSelectOwner
            // 
            this.TxtSelectOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSelectOwner.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnAddOwner,
            this.BtnShowOwnerCard,
            this.BtnSearchOwner});
            this.TxtSelectOwner.Location = new System.Drawing.Point(744, 43);
            this.TxtSelectOwner.Name = "TxtSelectOwner";
            this.TxtSelectOwner.Size = new System.Drawing.Size(337, 30);
            this.TxtSelectOwner.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 14F);
            this.TxtSelectOwner.TabIndex = 23;
            this.TxtSelectOwner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSelectOwner_KeyDown);
            // 
            // BtnAddOwner
            // 
            this.BtnAddOwner.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.BtnAddOwner.Image = global::DoctorERP.Properties.Resources.add;
            this.BtnAddOwner.UniqueName = "77FFB538B37047AF78B17F2D143A27C2";
            this.BtnAddOwner.Click += new System.EventHandler(this.BtnAddOwner_Click);
            // 
            // BtnShowOwnerCard
            // 
            this.BtnShowOwnerCard.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.BtnShowOwnerCard.Image = global::DoctorERP.Properties.Resources.Card;
            this.BtnShowOwnerCard.ToolTipBody = "إظهار البطاقة المختارة";
            this.BtnShowOwnerCard.ToolTipTitle = "شس";
            this.BtnShowOwnerCard.UniqueName = "B0CAF56D63214FFE058534D9E19E12F4";
            this.BtnShowOwnerCard.Click += new System.EventHandler(this.BtnShowOwnerCard_Click);
            // 
            // BtnSearchOwner
            // 
            this.BtnSearchOwner.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnSearchOwner.Image = global::DoctorERP.Properties.Resources.BtnSearch;
            this.BtnSearchOwner.UniqueName = "E3BBAC1E54F946ADA49433CFF1391045";
            this.BtnSearchOwner.Click += new System.EventHandler(this.BtnSeacrhOwner_Click);
            // 
            // LblOwner
            // 
            this.LblOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOwner.Location = new System.Drawing.Point(1091, 50);
            this.LblOwner.Name = "LblOwner";
            this.LblOwner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblOwner.Size = new System.Drawing.Size(39, 17);
            this.LblOwner.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOwner.TabIndex = 24;
            this.LblOwner.Values.Text = "المالك";
            // 
            // dtRegDate
            // 
            this.dtRegDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegDate.EditValue = null;
            this.dtRegDate.Location = new System.Drawing.Point(744, 7);
            this.dtRegDate.Name = "dtRegDate";
            this.dtRegDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.dtRegDate.Properties.Appearance.Options.UseFont = true;
            this.dtRegDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtRegDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtRegDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtRegDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtRegDate.Size = new System.Drawing.Size(337, 30);
            this.dtRegDate.TabIndex = 21;
            // 
            // TxtNote
            // 
            this.TxtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNote.Location = new System.Drawing.Point(331, 13);
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(209, 20);
            this.TxtNote.TabIndex = 7;
            this.TxtNote.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(543, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "ملاحظات";
            this.labelControl5.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Location = new System.Drawing.Point(1091, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(28, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "التاريخ";
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Buttons.Append.Visible = false;
            this.dataNavigator1.Buttons.CancelEdit.Visible = false;
            this.dataNavigator1.Buttons.EndEdit.Visible = false;
            this.dataNavigator1.Buttons.Remove.Visible = false;
            this.dataNavigator1.Location = new System.Drawing.Point(230, 10);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(229, 38);
            this.dataNavigator1.TabIndex = 18;
            this.dataNavigator1.Text = "dataNavigator1";
            this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigator1.TextStringFormat = "{1} / {0}";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.MainGridReadyItems);
            this.PnlMain.Controls.Add(this.panel1);
            this.PnlMain.Controls.Add(this.labelControl2);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 120);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1152, 346);
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
            this.MainGridReadyItems.Size = new System.Drawing.Size(1148, 232);
            this.MainGridReadyItems.TabIndex = 1;
            this.MainGridReadyItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            this.MainGridReadyItems.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.MainGridReadyItems_ProcessGridKey);
            // 
            // GridView1
            // 
            this.GridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand4,
            this.gridBand1,
            this.WorkFeeBands,
            this.gridBand5,
            this.gridBand6,
            this.gridBand3});
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.ColGuid,
            this.ColParentGuid,
            this.ColLandGuid,
            this.ColOwnerGuid,
            this.ColBuyerGuid,
            this.ColNumber,
            this.ColContractNo,
            this.ColCode,
            this.ColLand,
            this.ColPrice,
            this.ColWorkFeeValue,
            this.ColBuildingFeeValue,
            this.ColDiscountTotalText,
            this.ColDiscountTotal,
            this.ColDiscountTotalValue,
            this.ColDiscountFeeText,
            this.ColDiscountFee,
            this.ColDiscountFeeValue,
            this.ColVatValue,
            this.ColNetPrice,
            this.ColNetWorkFee,
            this.ColVatWorkFee,
            this.ColTotal,
            this.ColTotalNet,
            this.ColNote,
            this.ColStatus});
            this.GridView1.GridControl = this.MainGridReadyItems;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.GridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GridView1_PopupMenuShowing);
            this.GridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.GridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.GridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // gridBand2
            // 
            this.gridBand2.Columns.Add(this.ColGuid);
            this.gridBand2.Columns.Add(this.ColParentGuid);
            this.gridBand2.Columns.Add(this.ColLandGuid);
            this.gridBand2.Columns.Add(this.ColOwnerGuid);
            this.gridBand2.Columns.Add(this.ColBuyerGuid);
            this.gridBand2.Columns.Add(this.ColNumber);
            this.gridBand2.Columns.Add(this.ColContractNo);
            this.gridBand2.Columns.Add(this.ColCode);
            this.gridBand2.Columns.Add(this.ColLand);
            this.gridBand2.Columns.Add(this.ColPrice);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.OptionsBand.AllowHotTrack = false;
            this.gridBand2.OptionsBand.AllowMove = false;
            this.gridBand2.OptionsBand.AllowPress = false;
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 266;
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
            // ColLandGuid
            // 
            this.ColLandGuid.Caption = "landguid";
            this.ColLandGuid.FieldName = "landguid";
            this.ColLandGuid.Name = "ColLandGuid";
            this.ColLandGuid.Width = 50;
            // 
            // ColOwnerGuid
            // 
            this.ColOwnerGuid.Caption = "ownerguid";
            this.ColOwnerGuid.FieldName = "ownerguid";
            this.ColOwnerGuid.Name = "ColOwnerGuid";
            this.ColOwnerGuid.Width = 60;
            // 
            // ColBuyerGuid
            // 
            this.ColBuyerGuid.Caption = "buyerguid";
            this.ColBuyerGuid.FieldName = "buyerguid";
            this.ColBuyerGuid.Name = "ColBuyerGuid";
            this.ColBuyerGuid.Width = 58;
            // 
            // ColNumber
            // 
            this.ColNumber.Caption = "م";
            this.ColNumber.FieldName = "number";
            this.ColNumber.Name = "ColNumber";
            this.ColNumber.OptionsColumn.FixedWidth = true;
            this.ColNumber.Visible = true;
            this.ColNumber.Width = 25;
            // 
            // ColContractNo
            // 
            this.ColContractNo.Caption = "رقم العقد";
            this.ColContractNo.FieldName = "contractno";
            this.ColContractNo.Name = "ColContractNo";
            this.ColContractNo.Visible = true;
            this.ColContractNo.Width = 62;
            // 
            // ColCode
            // 
            this.ColCode.Caption = "الكود";
            this.ColCode.FieldName = "code";
            this.ColCode.Name = "ColCode";
            this.ColCode.Width = 43;
            // 
            // ColLand
            // 
            this.ColLand.Caption = "رقم الأرض";
            this.ColLand.ColumnEdit = this.BtnSelectItem;
            this.ColLand.FieldName = "land";
            this.ColLand.Name = "ColLand";
            this.ColLand.Visible = true;
            this.ColLand.Width = 106;
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
            // ColPrice
            // 
            this.ColPrice.Caption = "القيمة الدفترية";
            this.ColPrice.FieldName = "price";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.Visible = true;
            this.ColPrice.Width = 73;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "خصم قيمة الأرض";
            this.gridBand4.Columns.Add(this.ColDiscountTotalText);
            this.gridBand4.Columns.Add(this.ColNetPrice);
            this.gridBand4.Columns.Add(this.ColDiscountTotal);
            this.gridBand4.Columns.Add(this.ColDiscountTotalValue);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.AllowHotTrack = false;
            this.gridBand4.OptionsBand.AllowMove = false;
            this.gridBand4.OptionsBand.AllowPress = false;
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 229;
            // 
            // ColDiscountTotalText
            // 
            this.ColDiscountTotalText.Caption = "نسبة % أو قيمة";
            this.ColDiscountTotalText.FieldName = "discounttotaltext";
            this.ColDiscountTotalText.Name = "ColDiscountTotalText";
            this.ColDiscountTotalText.Visible = true;
            this.ColDiscountTotalText.Width = 109;
            // 
            // ColNetPrice
            // 
            this.ColNetPrice.Caption = "صافي قيمة الأرض";
            this.ColNetPrice.FieldName = "netprice";
            this.ColNetPrice.Name = "ColNetPrice";
            this.ColNetPrice.Visible = true;
            this.ColNetPrice.Width = 120;
            // 
            // ColDiscountTotal
            // 
            this.ColDiscountTotal.Caption = "نسبة";
            this.ColDiscountTotal.FieldName = "discounttotal";
            this.ColDiscountTotal.Name = "ColDiscountTotal";
            this.ColDiscountTotal.Width = 101;
            // 
            // ColDiscountTotalValue
            // 
            this.ColDiscountTotalValue.Caption = "قيمة";
            this.ColDiscountTotalValue.FieldName = "discounttotalvalue";
            this.ColDiscountTotalValue.Name = "ColDiscountTotalValue";
            this.ColDiscountTotalValue.Width = 99;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Columns.Add(this.ColBuildingFeeValue);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowHotTrack = false;
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.OptionsBand.AllowPress = false;
            this.gridBand1.VisibleIndex = 2;
            this.gridBand1.Width = 95;
            // 
            // ColBuildingFeeValue
            // 
            this.ColBuildingFeeValue.Caption = "ضريبة التصرفات العقارية";
            this.ColBuildingFeeValue.FieldName = "buildingfeevalue";
            this.ColBuildingFeeValue.Name = "ColBuildingFeeValue";
            this.ColBuildingFeeValue.Visible = true;
            this.ColBuildingFeeValue.Width = 95;
            // 
            // WorkFeeBands
            // 
            this.WorkFeeBands.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.WorkFeeBands.AppearanceHeader.Options.UseFont = true;
            this.WorkFeeBands.AppearanceHeader.Options.UseTextOptions = true;
            this.WorkFeeBands.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WorkFeeBands.Caption = "عمولة السعي";
            this.WorkFeeBands.Columns.Add(this.ColWorkFeeValue);
            this.WorkFeeBands.Columns.Add(this.ColDiscountFeeValue);
            this.WorkFeeBands.Columns.Add(this.ColDiscountFee);
            this.WorkFeeBands.Name = "WorkFeeBands";
            this.WorkFeeBands.OptionsBand.AllowHotTrack = false;
            this.WorkFeeBands.OptionsBand.AllowMove = false;
            this.WorkFeeBands.OptionsBand.AllowPress = false;
            this.WorkFeeBands.VisibleIndex = 3;
            this.WorkFeeBands.Width = 136;
            // 
            // ColWorkFeeValue
            // 
            this.ColWorkFeeValue.Caption = "عمولة السعي";
            this.ColWorkFeeValue.FieldName = "workfeevalue";
            this.ColWorkFeeValue.Name = "ColWorkFeeValue";
            this.ColWorkFeeValue.Visible = true;
            this.ColWorkFeeValue.Width = 136;
            // 
            // ColDiscountFeeValue
            // 
            this.ColDiscountFeeValue.Caption = "خصم قيمة";
            this.ColDiscountFeeValue.FieldName = "discountfeevalue";
            this.ColDiscountFeeValue.Name = "ColDiscountFeeValue";
            this.ColDiscountFeeValue.Width = 85;
            // 
            // ColDiscountFee
            // 
            this.ColDiscountFee.Caption = "خصم نسبة";
            this.ColDiscountFee.FieldName = "discountfee";
            this.ColDiscountFee.Name = "ColDiscountFee";
            this.ColDiscountFee.Width = 89;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.Caption = "خصم عمولة السعي";
            this.gridBand5.Columns.Add(this.ColDiscountFeeText);
            this.gridBand5.Columns.Add(this.ColNetWorkFee);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 192;
            // 
            // ColDiscountFeeText
            // 
            this.ColDiscountFeeText.Caption = "نسبة % أو قيمة";
            this.ColDiscountFeeText.FieldName = "discountfeetext";
            this.ColDiscountFeeText.Name = "ColDiscountFeeText";
            this.ColDiscountFeeText.Visible = true;
            this.ColDiscountFeeText.Width = 93;
            // 
            // ColNetWorkFee
            // 
            this.ColNetWorkFee.Caption = "صافي عمولة السعي";
            this.ColNetWorkFee.FieldName = "networkfee";
            this.ColNetWorkFee.Name = "ColNetWorkFee";
            this.ColNetWorkFee.Visible = true;
            this.ColNetWorkFee.Width = 99;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "ضريبة السعي";
            this.gridBand6.Columns.Add(this.ColVatValue);
            this.gridBand6.Columns.Add(this.ColVatWorkFee);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.OptionsBand.AllowHotTrack = false;
            this.gridBand6.OptionsBand.AllowMove = false;
            this.gridBand6.OptionsBand.AllowPress = false;
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 166;
            // 
            // ColVatValue
            // 
            this.ColVatValue.Caption = "الضريبة المضافة";
            this.ColVatValue.FieldName = "vatvalue";
            this.ColVatValue.Name = "ColVatValue";
            this.ColVatValue.Visible = true;
            this.ColVatValue.Width = 65;
            // 
            // ColVatWorkFee
            // 
            this.ColVatWorkFee.Caption = "صافي السعي مع الضريبة";
            this.ColVatWorkFee.FieldName = "vatworkfee";
            this.ColVatWorkFee.Name = "ColVatWorkFee";
            this.ColVatWorkFee.Visible = true;
            this.ColVatWorkFee.Width = 101;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.ColTotal);
            this.gridBand3.Columns.Add(this.ColTotalNet);
            this.gridBand3.Columns.Add(this.ColNote);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.OptionsBand.AllowHotTrack = false;
            this.gridBand3.OptionsBand.AllowMove = false;
            this.gridBand3.OptionsBand.AllowPress = false;
            this.gridBand3.VisibleIndex = 6;
            this.gridBand3.Width = 153;
            // 
            // ColTotal
            // 
            this.ColTotal.Caption = "الإجمالي";
            this.ColTotal.FieldName = "total";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.Width = 89;
            // 
            // ColTotalNet
            // 
            this.ColTotalNet.Caption = "المجموع";
            this.ColTotalNet.FieldName = "totalnet";
            this.ColTotalNet.Name = "ColTotalNet";
            this.ColTotalNet.Visible = true;
            this.ColTotalNet.Width = 81;
            // 
            // ColNote
            // 
            this.ColNote.AutoFillDown = true;
            this.ColNote.Caption = "ملاحظات";
            this.ColNote.FieldName = "note";
            this.ColNote.Name = "ColNote";
            this.ColNote.Visible = true;
            this.ColNote.Width = 72;
            // 
            // ColStatus
            // 
            this.ColStatus.Caption = "الحالة";
            this.ColStatus.FieldName = "status";
            this.ColStatus.Name = "ColStatus";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtotalworkfeeDiscount);
            this.panel1.Controls.Add(this.kryptonLabel9);
            this.panel1.Controls.Add(this.Txttotalworkfee);
            this.panel1.Controls.Add(this.kryptonLabel5);
            this.panel1.Controls.Add(this.TxtTotalVat);
            this.panel1.Controls.Add(this.kryptonLabel7);
            this.panel1.Controls.Add(this.Txttotalbuidlingfee);
            this.panel1.Controls.Add(this.kryptonLabel6);
            this.panel1.Controls.Add(this.Txttotaldiscountfee);
            this.panel1.Controls.Add(this.kryptonLabel3);
            this.panel1.Controls.Add(this.TxtPrice);
            this.panel1.Controls.Add(this.kryptonLabel1);
            this.panel1.Controls.Add(this.TxtNetPrice);
            this.panel1.Controls.Add(this.kryptonLabel8);
            this.panel1.Controls.Add(this.Txttotaldiscounttotal);
            this.panel1.Controls.Add(this.kryptonLabel2);
            this.panel1.Controls.Add(this.TxtTotalNet);
            this.panel1.Controls.Add(this.kryptonLabel4);
            this.panel1.Controls.Add(this.TxtNetPiceNetWorkFeeVAT);
            this.panel1.Controls.Add(this.TxtNetPrice2);
            this.panel1.Controls.Add(this.TxtNetPiceNetWorkFee);
            this.panel1.Controls.Add(this.kryptonLabel10);
            this.panel1.Controls.Add(this.TxtTotal);
            this.panel1.Controls.Add(this.Lbltotalareaprice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 110);
            this.panel1.TabIndex = 2;
            // 
            // TxtotalworkfeeDiscount
            // 
            this.TxtotalworkfeeDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtotalworkfeeDiscount.Location = new System.Drawing.Point(621, 39);
            this.TxtotalworkfeeDiscount.Name = "TxtotalworkfeeDiscount";
            this.TxtotalworkfeeDiscount.ReadOnly = true;
            this.TxtotalworkfeeDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtotalworkfeeDiscount.Size = new System.Drawing.Size(118, 27);
            this.TxtotalworkfeeDiscount.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtotalworkfeeDiscount.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtotalworkfeeDiscount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtotalworkfeeDiscount.TabIndex = 23;
            this.TxtotalworkfeeDiscount.TabStop = false;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel9.Location = new System.Drawing.Point(745, 44);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel9.Size = new System.Drawing.Size(104, 17);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.TabIndex = 25;
            this.kryptonLabel9.Values.Text = "خصم عمولة السعي";
            // 
            // Txttotalworkfee
            // 
            this.Txttotalworkfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txttotalworkfee.Location = new System.Drawing.Point(621, 6);
            this.Txttotalworkfee.Name = "Txttotalworkfee";
            this.Txttotalworkfee.ReadOnly = true;
            this.Txttotalworkfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txttotalworkfee.Size = new System.Drawing.Size(118, 27);
            this.Txttotalworkfee.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txttotalworkfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotalworkfee.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotalworkfee.TabIndex = 23;
            this.Txttotalworkfee.TabStop = false;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel5.Location = new System.Drawing.Point(742, 11);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel5.Size = new System.Drawing.Size(77, 17);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 25;
            this.kryptonLabel5.Values.Text = "عمولة السعي";
            // 
            // TxtTotalVat
            // 
            this.TxtTotalVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTotalVat.Location = new System.Drawing.Point(400, 70);
            this.TxtTotalVat.Name = "TxtTotalVat";
            this.TxtTotalVat.ReadOnly = true;
            this.TxtTotalVat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalVat.Size = new System.Drawing.Size(110, 27);
            this.TxtTotalVat.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtTotalVat.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalVat.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalVat.TabIndex = 24;
            this.TxtTotalVat.TabStop = false;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel7.Location = new System.Drawing.Point(512, 75);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel7.Size = new System.Drawing.Size(107, 17);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 26;
            this.kryptonLabel7.Values.Text = "ضريبة عمولة السعي";
            // 
            // Txttotalbuidlingfee
            // 
            this.Txttotalbuidlingfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txttotalbuidlingfee.Location = new System.Drawing.Point(400, 6);
            this.Txttotalbuidlingfee.Name = "Txttotalbuidlingfee";
            this.Txttotalbuidlingfee.ReadOnly = true;
            this.Txttotalbuidlingfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txttotalbuidlingfee.Size = new System.Drawing.Size(110, 27);
            this.Txttotalbuidlingfee.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txttotalbuidlingfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotalbuidlingfee.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotalbuidlingfee.TabIndex = 24;
            this.Txttotalbuidlingfee.TabStop = false;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel6.Location = new System.Drawing.Point(516, 11);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel6.Size = new System.Drawing.Size(88, 17);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 26;
            this.kryptonLabel6.Values.Text = "التصرفات العقارية";
            // 
            // Txttotaldiscountfee
            // 
            this.Txttotaldiscountfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txttotaldiscountfee.Location = new System.Drawing.Point(621, 70);
            this.Txttotaldiscountfee.Name = "Txttotaldiscountfee";
            this.Txttotaldiscountfee.ReadOnly = true;
            this.Txttotaldiscountfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txttotaldiscountfee.Size = new System.Drawing.Size(118, 27);
            this.Txttotaldiscountfee.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txttotaldiscountfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotaldiscountfee.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotaldiscountfee.TabIndex = 21;
            this.Txttotaldiscountfee.TabStop = false;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel3.Location = new System.Drawing.Point(745, 75);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel3.Size = new System.Drawing.Size(108, 17);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 22;
            this.kryptonLabel3.Values.Text = "صافي عمولة السعي";
            // 
            // TxtPrice
            // 
            this.TxtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPrice.Location = new System.Drawing.Point(856, 6);
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.ReadOnly = true;
            this.TxtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPrice.Size = new System.Drawing.Size(152, 27);
            this.TxtPrice.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtPrice.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrice.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrice.TabIndex = 21;
            this.TxtPrice.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(1014, 11);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel1.Size = new System.Drawing.Size(78, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 22;
            this.kryptonLabel1.Values.Text = "القيمة الدفترية";
            // 
            // TxtNetPrice
            // 
            this.TxtNetPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNetPrice.Location = new System.Drawing.Point(856, 70);
            this.TxtNetPrice.Name = "TxtNetPrice";
            this.TxtNetPrice.ReadOnly = true;
            this.TxtNetPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNetPrice.Size = new System.Drawing.Size(152, 27);
            this.TxtNetPrice.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtNetPrice.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPrice.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPrice.TabIndex = 21;
            this.TxtNetPrice.TabStop = false;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel8.Location = new System.Drawing.Point(1014, 75);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel8.Size = new System.Drawing.Size(130, 17);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.TabIndex = 22;
            this.kryptonLabel8.Values.Text = "القيمة الدفترية بعد الخصم";
            // 
            // Txttotaldiscounttotal
            // 
            this.Txttotaldiscounttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txttotaldiscounttotal.Location = new System.Drawing.Point(856, 39);
            this.Txttotaldiscounttotal.Name = "Txttotaldiscounttotal";
            this.Txttotaldiscounttotal.ReadOnly = true;
            this.Txttotaldiscounttotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txttotaldiscounttotal.Size = new System.Drawing.Size(152, 27);
            this.Txttotaldiscounttotal.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.Txttotaldiscounttotal.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotaldiscounttotal.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotaldiscounttotal.TabIndex = 21;
            this.Txttotaldiscounttotal.TabStop = false;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(1013, 44);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel2.Size = new System.Drawing.Size(74, 17);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 22;
            this.kryptonLabel2.Values.Text = "خصم الأراضي";
            // 
            // TxtTotalNet
            // 
            this.TxtTotalNet.Location = new System.Drawing.Point(292, 80);
            this.TxtTotalNet.Name = "TxtTotalNet";
            this.TxtTotalNet.ReadOnly = true;
            this.TxtTotalNet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotalNet.Size = new System.Drawing.Size(57, 27);
            this.TxtTotalNet.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtTotalNet.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalNet.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalNet.TabIndex = 21;
            this.TxtTotalNet.TabStop = false;
            this.TxtTotalNet.Visible = false;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(205, 11);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel4.Size = new System.Drawing.Size(94, 17);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 22;
            this.kryptonLabel4.Values.Text = "صافي قيمة الأرض";
            // 
            // TxtNetPiceNetWorkFeeVAT
            // 
            this.TxtNetPiceNetWorkFeeVAT.Location = new System.Drawing.Point(10, 70);
            this.TxtNetPiceNetWorkFeeVAT.Name = "TxtNetPiceNetWorkFeeVAT";
            this.TxtNetPiceNetWorkFeeVAT.ReadOnly = true;
            this.TxtNetPiceNetWorkFeeVAT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNetPiceNetWorkFeeVAT.Size = new System.Drawing.Size(189, 27);
            this.TxtNetPiceNetWorkFeeVAT.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtNetPiceNetWorkFeeVAT.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPiceNetWorkFeeVAT.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPiceNetWorkFeeVAT.TabIndex = 21;
            this.TxtNetPiceNetWorkFeeVAT.TabStop = false;
            // 
            // TxtNetPrice2
            // 
            this.TxtNetPrice2.Location = new System.Drawing.Point(10, 6);
            this.TxtNetPrice2.Name = "TxtNetPrice2";
            this.TxtNetPrice2.ReadOnly = true;
            this.TxtNetPrice2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNetPrice2.Size = new System.Drawing.Size(189, 27);
            this.TxtNetPrice2.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtNetPrice2.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPrice2.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPrice2.TabIndex = 21;
            this.TxtNetPrice2.TabStop = false;
            // 
            // TxtNetPiceNetWorkFee
            // 
            this.TxtNetPiceNetWorkFee.Location = new System.Drawing.Point(10, 37);
            this.TxtNetPiceNetWorkFee.Name = "TxtNetPiceNetWorkFee";
            this.TxtNetPiceNetWorkFee.ReadOnly = true;
            this.TxtNetPiceNetWorkFee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNetPiceNetWorkFee.Size = new System.Drawing.Size(189, 27);
            this.TxtNetPiceNetWorkFee.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtNetPiceNetWorkFee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPiceNetWorkFee.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNetPiceNetWorkFee.TabIndex = 21;
            this.TxtNetPiceNetWorkFee.TabStop = false;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(205, 75);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel10.Size = new System.Drawing.Size(199, 17);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.TabIndex = 22;
            this.kryptonLabel10.Values.Text = "صافي القيمة + صافي العمولة + الضريبة";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Location = new System.Drawing.Point(315, 70);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtTotal.Size = new System.Drawing.Size(49, 27);
            this.TxtTotal.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtTotal.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.TabIndex = 21;
            this.TxtTotal.TabStop = false;
            this.TxtTotal.Visible = false;
            // 
            // Lbltotalareaprice
            // 
            this.Lbltotalareaprice.Location = new System.Drawing.Point(205, 42);
            this.Lbltotalareaprice.Name = "Lbltotalareaprice";
            this.Lbltotalareaprice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbltotalareaprice.Size = new System.Drawing.Size(150, 17);
            this.Lbltotalareaprice.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbltotalareaprice.TabIndex = 22;
            this.Lbltotalareaprice.Values.Text = "صافي القيمة + صافي العمولة";
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
            this.PnlBottom.Controls.Add(this.dataNavigator1);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 466);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(1152, 58);
            this.PnlBottom.TabIndex = 36;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.Appearance.Options.UseFont = true;
            this.BtnPrint.DropDownControl = this.popupMenu1;
            this.BtnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrint.ImageOptions.Image")));
            this.BtnPrint.Location = new System.Drawing.Point(736, 10);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(103, 38);
            this.BtnPrint.TabIndex = 11;
            this.BtnPrint.Text = "طباعة";
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPreView),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuDesign),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuOneByOne)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // MenuPreView
            // 
            this.MenuPreView.Caption = "معاينة";
            this.MenuPreView.Id = 0;
            this.MenuPreView.Name = "MenuPreView";
            this.MenuPreView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuPreView_ItemClick);
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
            this.MenuDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuDesign_ItemClick);
            // 
            // MenuOneByOne
            // 
            this.MenuOneByOne.Caption = "طباعة فردية";
            this.MenuOneByOne.Id = 3;
            this.MenuOneByOne.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPrintOnebyOne),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPreviewOneByOne),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuDesignOneByOne)});
            this.MenuOneByOne.Name = "MenuOneByOne";
            // 
            // MenuPrintOnebyOne
            // 
            this.MenuPrintOnebyOne.Caption = "طباعة";
            this.MenuPrintOnebyOne.Id = 6;
            this.MenuPrintOnebyOne.Name = "MenuPrintOnebyOne";
            this.MenuPrintOnebyOne.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuPrintOnebyOne_ItemClick);
            // 
            // MenuPreviewOneByOne
            // 
            this.MenuPreviewOneByOne.Caption = "معاينة";
            this.MenuPreviewOneByOne.Id = 4;
            this.MenuPreviewOneByOne.Name = "MenuPreviewOneByOne";
            this.MenuPreviewOneByOne.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuPreviewOneByOne_ItemClick);
            // 
            // MenuDesignOneByOne
            // 
            this.MenuDesignOneByOne.Caption = "تصميم";
            this.MenuDesignOneByOne.Id = 5;
            this.MenuDesignOneByOne.Name = "MenuDesignOneByOne";
            this.MenuDesignOneByOne.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuDesignOneByOne_ItemClick);
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
            this.MenuDesign,
            this.MenuOneByOne,
            this.MenuPreviewOneByOne,
            this.MenuDesignOneByOne,
            this.MenuPrintOnebyOne});
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1152, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 524);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1152, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1152, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 524);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Appearance.Options.UseFont = true;
            this.BtnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.ImageOptions.Image")));
            this.BtnCancel.Location = new System.Drawing.Point(12, 10);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(103, 38);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Appearance.Options.UseFont = true;
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
            this.BtnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.Appearance.Options.UseFont = true;
            this.BtnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnEdit.ImageOptions.Image")));
            this.BtnEdit.Location = new System.Drawing.Point(845, 10);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(130, 38);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "تعديل";
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.ImageOptions.Image")));
            this.BtnAdd.Location = new System.Drawing.Point(845, 10);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(130, 38);
            this.BtnAdd.TabIndex = 9;
            this.BtnAdd.Text = "حفظ العقد الجديد";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.Appearance.Options.UseFont = true;
            this.BtnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.ImageOptions.Image")));
            this.BtnNew.Location = new System.Drawing.Point(981, 10);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(138, 38);
            this.BtnNew.TabIndex = 10;
            this.BtnNew.Text = "إنشاء عقد جديد";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // barManagerGrid
            // 
            this.barManagerGrid.DockControls.Add(this.barDockControl1);
            this.barManagerGrid.DockControls.Add(this.barDockControl2);
            this.barManagerGrid.DockControls.Add(this.barDockControl3);
            this.barManagerGrid.DockControls.Add(this.barDockControl4);
            this.barManagerGrid.Form = this;
            this.barManagerGrid.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MenuLand,
            this.MenuConvertToReturn,
            this.MenuPrintOne,
            this.MenuPreviewOne,
            this.MenuPrintLandInfo,
            this.MenuAllowEditPrice});
            this.barManagerGrid.MaxItemId = 6;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManagerGrid;
            this.barDockControl1.Size = new System.Drawing.Size(1152, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 524);
            this.barDockControl2.Manager = this.barManagerGrid;
            this.barDockControl2.Size = new System.Drawing.Size(1152, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManagerGrid;
            this.barDockControl3.Size = new System.Drawing.Size(0, 524);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1152, 0);
            this.barDockControl4.Manager = this.barManagerGrid;
            this.barDockControl4.Size = new System.Drawing.Size(0, 524);
            // 
            // MenuLand
            // 
            this.MenuLand.Caption = "بطاقة الصنف";
            this.MenuLand.Id = 0;
            this.MenuLand.Name = "MenuLand";
            this.MenuLand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuLand_ItemClick);
            // 
            // MenuConvertToReturn
            // 
            this.MenuConvertToReturn.Caption = "تحويل إلى مرتجع";
            this.MenuConvertToReturn.Id = 1;
            this.MenuConvertToReturn.Name = "MenuConvertToReturn";
            this.MenuConvertToReturn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuConvertToReturn_ItemClick);
            // 
            // MenuPrintOne
            // 
            this.MenuPrintOne.Caption = "طباعة العقد";
            this.MenuPrintOne.Id = 2;
            this.MenuPrintOne.Name = "MenuPrintOne";
            this.MenuPrintOne.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuPrintOne_ItemClick);
            // 
            // MenuPreviewOne
            // 
            this.MenuPreviewOne.Caption = "معاينة العقد";
            this.MenuPreviewOne.Id = 3;
            this.MenuPreviewOne.Name = "MenuPreviewOne";
            this.MenuPreviewOne.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuPreviewOne_ItemClick);
            // 
            // MenuPrintLandInfo
            // 
            this.MenuPrintLandInfo.Caption = "معاينة معلومات الأرض";
            this.MenuPrintLandInfo.Id = 4;
            this.MenuPrintLandInfo.Name = "MenuPrintLandInfo";
            this.MenuPrintLandInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuPrintLandInfo_ItemClick);
            // 
            // MenuAllowEditPrice
            // 
            this.MenuAllowEditPrice.Caption = "السماح بتعديل القيمة الدفترية";
            this.MenuAllowEditPrice.Id = 5;
            this.MenuAllowEditPrice.Name = "MenuAllowEditPrice";
            this.MenuAllowEditPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MenuAllowEditPrice_ItemClick);
            // 
            // MenuGrid
            // 
            this.MenuGrid.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuLand),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuConvertToReturn),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPreviewOne),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPrintOne),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuPrintLandInfo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuAllowEditPrice)});
            this.MenuGrid.Manager = this.barManagerGrid;
            this.MenuGrid.Name = "MenuGrid";
            // 
            // FrmBillHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 524);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "FrmBillHeader";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة بيع";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReadyItems_FormClosing);
            this.Load += new System.EventHandler(this.FrmReadyItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PnlTop)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBuyerData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOwnerData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMain)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridReadyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSelectItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PnlBottom)).EndInit();
            this.PnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGrid)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit dtRegDate;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView GridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColGuid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColParentGuid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColLandGuid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColOwnerGuid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColBuyerGuid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColContractNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColLand;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColPrice;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColWorkFeeValue;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColBuildingFeeValue;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColDiscountTotalValue;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColDiscountFeeValue;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColVatValue;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColNote;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSelectOwner;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnAddOwner;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnShowOwnerCard;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSearchOwner;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblOwner;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbltotalareaprice;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txttotaldiscounttotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txttotaldiscountfee;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtTotalNet;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txttotalworkfee;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txttotalbuidlingfee;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtTotalVat;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtnumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lblnumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSelectBuyer;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnAddBuyer;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnShowBuyerCard;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSearchBuyer;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAgent;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColDiscountTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColDiscountFee;
        private DevExpress.XtraEditors.ComboBoxEdit CmbBuyerData;
        private DevExpress.XtraEditors.ComboBoxEdit CmbOwnerData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColDiscountTotalText;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColDiscountFeeText;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColTotalNet;
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
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColNetPrice;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColNetWorkFee;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColStatus;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManagerGrid;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem MenuLand;
        private DevExpress.XtraBars.BarButtonItem MenuConvertToReturn;
        private DevExpress.XtraBars.PopupMenu MenuGrid;
        private DevExpress.XtraBars.BarSubItem MenuOneByOne;
        private DevExpress.XtraBars.BarButtonItem MenuPreviewOneByOne;
        private DevExpress.XtraBars.BarButtonItem MenuDesignOneByOne;
        private DevExpress.XtraBars.BarButtonItem MenuPrintOnebyOne;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ColVatWorkFee;
        private DevExpress.XtraBars.BarButtonItem MenuPrintOne;
        private DevExpress.XtraBars.BarButtonItem MenuPreviewOne;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand WorkFeeBands;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraBars.BarButtonItem MenuPrintLandInfo;
        private DevExpress.XtraEditors.SimpleButton BtnAddFromBlock;
        private DevExpress.XtraBars.BarButtonItem MenuAllowEditPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNetPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtotalworkfeeDiscount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNetPiceNetWorkFee;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNetPiceNetWorkFeeVAT;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtNetPrice2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblHint;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtlastaction;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
    }
}