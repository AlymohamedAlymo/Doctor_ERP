namespace DoctorERP
{
    partial class FrmAddAmountoAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddAmountoAgent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.BtnTools = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCustomView = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.LblAmountIn = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblBalance = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblAmountOut = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.BtnPreview = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.CmbBank = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.CmbPayType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.LblType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtCheckNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblCheck = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblAmount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtContractTotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtRemainAfterPay = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtAgentBalance = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSelect = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnShowCard = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.DataGridMain = new DataGridViewEx();
            this.StatusBar.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbPayType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnTools});
            this.StatusBar.Location = new System.Drawing.Point(0, 561);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(826, 22);
            this.StatusBar.TabIndex = 25;
            this.StatusBar.Text = "statusStrip1";
            // 
            // BtnTools
            // 
            this.BtnTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPreview,
            this.MenuPrint,
            this.toolStripSeparator1,
            this.MenuCustomView});
            this.BtnTools.Image = ((System.Drawing.Image)(resources.GetObject("BtnTools.Image")));
            this.BtnTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnTools.Name = "BtnTools";
            this.BtnTools.Size = new System.Drawing.Size(68, 20);
            this.BtnTools.Text = "أدوات";
            // 
            // MenuPreview
            // 
            this.MenuPreview.Name = "MenuPreview";
            this.MenuPreview.Size = new System.Drawing.Size(178, 22);
            this.MenuPreview.Text = "معاينة سندات القبض";
            this.MenuPreview.Click += new System.EventHandler(this.MenuPreview_Click);
            // 
            // MenuPrint
            // 
            this.MenuPrint.Name = "MenuPrint";
            this.MenuPrint.Size = new System.Drawing.Size(178, 22);
            this.MenuPrint.Text = "طباعة سدات القبض";
            this.MenuPrint.Click += new System.EventHandler(this.MenuPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // MenuCustomView
            // 
            this.MenuCustomView.Name = "MenuCustomView";
            this.MenuCustomView.Size = new System.Drawing.Size(178, 22);
            this.MenuCustomView.Text = "تخصيص المظهر";
            this.MenuCustomView.Click += new System.EventHandler(this.MenuCustomView_Click);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.LblAmountIn);
            this.PnlBottom.Controls.Add(this.LblBalance);
            this.PnlBottom.Controls.Add(this.LblAmountOut);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 531);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(826, 30);
            this.PnlBottom.TabIndex = 27;
            // 
            // LblAmountIn
            // 
            this.LblAmountIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmountIn.AutoSize = false;
            this.LblAmountIn.Location = new System.Drawing.Point(611, 3);
            this.LblAmountIn.Name = "LblAmountIn";
            this.LblAmountIn.Size = new System.Drawing.Size(203, 26);
            this.LblAmountIn.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmountIn.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblAmountIn.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblAmountIn.TabIndex = 17;
            this.LblAmountIn.Values.Text = "القيمة 0.0";
            // 
            // LblBalance
            // 
            this.LblBalance.AutoSize = false;
            this.LblBalance.Location = new System.Drawing.Point(11, 3);
            this.LblBalance.Name = "LblBalance";
            this.LblBalance.Size = new System.Drawing.Size(203, 26);
            this.LblBalance.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBalance.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblBalance.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblBalance.TabIndex = 17;
            this.LblBalance.Values.Text = "المتبقي 0.0";
            // 
            // LblAmountOut
            // 
            this.LblAmountOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmountOut.AutoSize = false;
            this.LblAmountOut.Location = new System.Drawing.Point(402, 3);
            this.LblAmountOut.Name = "LblAmountOut";
            this.LblAmountOut.Size = new System.Drawing.Size(203, 26);
            this.LblAmountOut.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmountOut.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblAmountOut.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblAmountOut.TabIndex = 17;
            this.LblAmountOut.Values.Text = "المدفوع 0.0";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnPreview);
            this.PnlTop.Controls.Add(this.BtnSave);
            this.PnlTop.Controls.Add(this.CmbBank);
            this.PnlTop.Controls.Add(this.kryptonLabel6);
            this.PnlTop.Controls.Add(this.CmbPayType);
            this.PnlTop.Controls.Add(this.LblType);
            this.PnlTop.Controls.Add(this.TxtCheckNo);
            this.PnlTop.Controls.Add(this.LblCheck);
            this.PnlTop.Controls.Add(this.TxtAmount);
            this.PnlTop.Controls.Add(this.LblAmount);
            this.PnlTop.Controls.Add(this.TxtContractTotal);
            this.PnlTop.Controls.Add(this.kryptonLabel5);
            this.PnlTop.Controls.Add(this.TxtRemainAfterPay);
            this.PnlTop.Controls.Add(this.kryptonLabel3);
            this.PnlTop.Controls.Add(this.TxtAgentBalance);
            this.PnlTop.Controls.Add(this.kryptonLabel2);
            this.PnlTop.Controls.Add(this.kryptonLabel1);
            this.PnlTop.Controls.Add(this.TxtSelect);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(826, 214);
            this.PnlTop.TabIndex = 28;
            // 
            // BtnPreview
            // 
            this.BtnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPreview.Location = new System.Drawing.Point(562, 147);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(133, 25);
            this.BtnPreview.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.TabIndex = 141;
            this.BtnPreview.Values.Text = "معاينة توزيع المبلغ";
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(562, 178);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(133, 25);
            this.BtnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.TabIndex = 141;
            this.BtnSave.Values.Text = "توزيع المبلغ و الحفظ";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CmbBank
            // 
            this.CmbBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBank.DropDownWidth = 205;
            this.CmbBank.Enabled = false;
            this.CmbBank.Location = new System.Drawing.Point(562, 93);
            this.CmbBank.Name = "CmbBank";
            this.CmbBank.Size = new System.Drawing.Size(133, 21);
            this.CmbBank.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBank.TabIndex = 137;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel6.Location = new System.Drawing.Point(701, 95);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(58, 17);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 139;
            this.kryptonLabel6.Values.Text = "اسم البنك";
            // 
            // CmbPayType
            // 
            this.CmbPayType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbPayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPayType.DropDownWidth = 205;
            this.CmbPayType.Items.AddRange(new object[] {
            "نقدي",
            "شبكة",
            "شيك",
            "تحويل بنكي"});
            this.CmbPayType.Location = new System.Drawing.Point(562, 66);
            this.CmbPayType.Name = "CmbPayType";
            this.CmbPayType.Size = new System.Drawing.Size(133, 21);
            this.CmbPayType.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPayType.TabIndex = 138;
            this.CmbPayType.SelectedIndexChanged += new System.EventHandler(this.CmbPayType_SelectedIndexChanged);
            // 
            // LblType
            // 
            this.LblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblType.Location = new System.Drawing.Point(701, 68);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(65, 17);
            this.LblType.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.TabIndex = 140;
            this.LblType.Values.Text = "طريقة الدفع";
            // 
            // TxtCheckNo
            // 
            this.TxtCheckNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCheckNo.Enabled = false;
            this.TxtCheckNo.Location = new System.Drawing.Point(311, 93);
            this.TxtCheckNo.Name = "TxtCheckNo";
            this.TxtCheckNo.Size = new System.Drawing.Size(133, 21);
            this.TxtCheckNo.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCheckNo.TabIndex = 133;
            // 
            // LblCheck
            // 
            this.LblCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCheck.Location = new System.Drawing.Point(448, 95);
            this.LblCheck.Name = "LblCheck";
            this.LblCheck.Size = new System.Drawing.Size(61, 17);
            this.LblCheck.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCheck.TabIndex = 135;
            this.LblCheck.Values.Text = "رقم الشيك";
            // 
            // TxtAmount
            // 
            this.TxtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAmount.Location = new System.Drawing.Point(562, 120);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(133, 21);
            this.TxtAmount.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAmount.TabIndex = 134;
            this.TxtAmount.TextChanged += new System.EventHandler(this.TxtAmount_TextChanged);
            // 
            // LblAmount
            // 
            this.LblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmount.Location = new System.Drawing.Point(699, 122);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(38, 17);
            this.LblAmount.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmount.TabIndex = 136;
            this.LblAmount.Values.Text = "المبلغ";
            // 
            // TxtContractTotal
            // 
            this.TxtContractTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtContractTotal.Location = new System.Drawing.Point(562, 39);
            this.TxtContractTotal.Name = "TxtContractTotal";
            this.TxtContractTotal.ReadOnly = true;
            this.TxtContractTotal.Size = new System.Drawing.Size(133, 21);
            this.TxtContractTotal.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtContractTotal.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContractTotal.TabIndex = 131;
            this.TxtContractTotal.TabStop = false;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel5.Location = new System.Drawing.Point(699, 41);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(102, 17);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 132;
            this.kryptonLabel5.Values.Text = "إجمالي قيمة العقود";
            // 
            // TxtRemainAfterPay
            // 
            this.TxtRemainAfterPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRemainAfterPay.Location = new System.Drawing.Point(311, 120);
            this.TxtRemainAfterPay.Name = "TxtRemainAfterPay";
            this.TxtRemainAfterPay.ReadOnly = true;
            this.TxtRemainAfterPay.Size = new System.Drawing.Size(133, 21);
            this.TxtRemainAfterPay.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtRemainAfterPay.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemainAfterPay.TabIndex = 129;
            this.TxtRemainAfterPay.TabStop = false;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel3.Location = new System.Drawing.Point(448, 122);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(93, 17);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 130;
            this.kryptonLabel3.Values.Text = "المتبقي بعد الدفع";
            // 
            // TxtAgentBalance
            // 
            this.TxtAgentBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAgentBalance.Location = new System.Drawing.Point(311, 39);
            this.TxtAgentBalance.Name = "TxtAgentBalance";
            this.TxtAgentBalance.ReadOnly = true;
            this.TxtAgentBalance.Size = new System.Drawing.Size(133, 21);
            this.TxtAgentBalance.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtAgentBalance.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAgentBalance.TabIndex = 129;
            this.TxtAgentBalance.TabStop = false;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(448, 41);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(105, 17);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 130;
            this.kryptonLabel2.Values.Text = "إجمالي رصيد العميل";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(696, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(41, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel1.TabIndex = 128;
            this.kryptonLabel1.Values.Text = "العميل";
            // 
            // TxtSelect
            // 
            this.TxtSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSelect.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnSearch,
            this.BtnShowCard});
            this.TxtSelect.Location = new System.Drawing.Point(311, 12);
            this.TxtSelect.Name = "TxtSelect";
            this.TxtSelect.Size = new System.Drawing.Size(384, 21);
            this.TxtSelect.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSelect.TabIndex = 127;
            this.TxtSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSelect_KeyDown);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Image = global::DoctorERP.Properties.Resources.BtnSearch;
            this.BtnSearch.UniqueName = "E3BBAC1E54F946ADA49433CFF1391045";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSeacrh_Click);
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
            // DataGridMain
            // 
            this.DataGridMain.AllowUserToAddRows = false;
            this.DataGridMain.AllowUserToDeleteRows = false;
            this.DataGridMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMain.Location = new System.Drawing.Point(0, 214);
            this.DataGridMain.Name = "DataGridMain";
            this.DataGridMain.ReadOnly = true;
            this.DataGridMain.RowHeadersVisible = false;
            this.DataGridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridMain.Size = new System.Drawing.Size(826, 317);
            this.DataGridMain.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.DataGridMain.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.TabIndex = 24;
            // 
            // FrmAddAmountoAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 583);
            this.Controls.Add(this.DataGridMain);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.PnlBottom);
            this.Controls.Add(this.StatusBar);
            this.Name = "FrmAddAmountoAgent";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير بحث";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbPayType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewEx DataGridMain;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripSplitButton BtnTools;
        private System.Windows.Forms.ToolStripMenuItem MenuCustomView;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAmountIn;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAmountOut;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.ToolStripMenuItem MenuPreview;
        private System.Windows.Forms.ToolStripMenuItem MenuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSelect;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnShowCard;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtAgentBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtContractTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbBank;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbPayType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblType;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCheckNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCheck;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtRemainAfterPay;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnPreview;
    }
}