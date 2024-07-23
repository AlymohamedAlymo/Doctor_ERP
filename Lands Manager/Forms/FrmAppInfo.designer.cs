namespace DoctorERP
{
    partial class FrmAppInfo
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
            this.BtnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnBrowse = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnRemove = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAppInfo = new System.Windows.Forms.TabPage();
            this.CmbStyle = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.ChkShowConfirmMSG = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkBackupOnExit = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.TxtBackupPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnPath = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblStyle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblBackupPath = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtColumnCount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtAppTitle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblAppTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tbNumberFormat = new System.Windows.Forms.TabPage();
            this.TxtCurrencyPreview = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnRefreshCurrencyFormat = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.TxtQtyFormatPreview = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnRefreshQtyFormat = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.CmbCurrencyFormat = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.LblCurrentPreview = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.CmbQtyFormat = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.LblCurrencyFormat = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblQtyPreview = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblQtyFormat = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabAppBackground = new System.Windows.Forms.TabPage();
            this.PicBK = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.BtnRemoveLogo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnLogo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tabControl1.SuspendLayout();
            this.tabAppInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbStyle)).BeginInit();
            this.tbNumberFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCurrencyFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbQtyFormat)).BeginInit();
            this.tabAppBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBK)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(12, 237);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(68, 25);
            this.BtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Values.Text = "موافق";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(33, 171);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(22, 17);
            this.BtnBrowse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBrowse.TabIndex = 23;
            this.BtnBrowse.Values.Text = "...";
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(5, 171);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(22, 17);
            this.BtnRemove.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.TabIndex = 25;
            this.BtnRemove.Values.Text = "x";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAppInfo);
            this.tabControl1.Controls.Add(this.tbNumberFormat);
            this.tabControl1.Controls.Add(this.tabAppBackground);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(379, 231);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAppInfo
            // 
            this.tabAppInfo.Controls.Add(this.CmbStyle);
            this.tabAppInfo.Controls.Add(this.ChkShowConfirmMSG);
            this.tabAppInfo.Controls.Add(this.chkBackupOnExit);
            this.tabAppInfo.Controls.Add(this.TxtBackupPath);
            this.tabAppInfo.Controls.Add(this.LblStyle);
            this.tabAppInfo.Controls.Add(this.LblBackupPath);
            this.tabAppInfo.Controls.Add(this.TxtColumnCount);
            this.tabAppInfo.Controls.Add(this.kryptonLabel1);
            this.tabAppInfo.Controls.Add(this.TxtAppTitle);
            this.tabAppInfo.Controls.Add(this.LblAppTitle);
            this.tabAppInfo.Location = new System.Drawing.Point(4, 22);
            this.tabAppInfo.Name = "tabAppInfo";
            this.tabAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppInfo.Size = new System.Drawing.Size(371, 205);
            this.tabAppInfo.TabIndex = 0;
            this.tabAppInfo.Text = "خيارات البرنامج";
            this.tabAppInfo.UseVisualStyleBackColor = true;
            // 
            // CmbStyle
            // 
            this.CmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStyle.DropDownWidth = 205;
            this.CmbStyle.Items.AddRange(new object[] {
            "Professional System",
            "Professional Office 2003",
            "Office 2007 Blue",
            "Office 2007 Silver",
            "Office 2007 Black",
            "Office 2010 Blue",
            "Office 2010 Silver",
            "Office 2010 Black"});
            this.CmbStyle.Location = new System.Drawing.Point(8, 109);
            this.CmbStyle.Name = "CmbStyle";
            this.CmbStyle.Size = new System.Drawing.Size(211, 21);
            this.CmbStyle.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbStyle.TabIndex = 20;
            // 
            // ChkShowConfirmMSG
            // 
            this.ChkShowConfirmMSG.Location = new System.Drawing.Point(102, 136);
            this.ChkShowConfirmMSG.Name = "ChkShowConfirmMSG";
            this.ChkShowConfirmMSG.Size = new System.Drawing.Size(113, 17);
            this.ChkShowConfirmMSG.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkShowConfirmMSG.TabIndex = 19;
            this.ChkShowConfirmMSG.Values.Text = "السؤال عند الإضافة";
            // 
            // chkBackupOnExit
            // 
            this.chkBackupOnExit.Location = new System.Drawing.Point(89, 182);
            this.chkBackupOnExit.Name = "chkBackupOnExit";
            this.chkBackupOnExit.Size = new System.Drawing.Size(126, 17);
            this.chkBackupOnExit.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBackupOnExit.TabIndex = 19;
            this.chkBackupOnExit.Values.Text = "أخذ نسخة عند الخروج";
            this.chkBackupOnExit.Visible = false;
            // 
            // TxtBackupPath
            // 
            this.TxtBackupPath.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnPath});
            this.TxtBackupPath.Location = new System.Drawing.Point(8, 83);
            this.TxtBackupPath.Name = "TxtBackupPath";
            this.TxtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBackupPath.Size = new System.Drawing.Size(211, 21);
            this.TxtBackupPath.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBackupPath.TabIndex = 0;
            this.TxtBackupPath.Visible = false;
            // 
            // BtnPath
            // 
            this.BtnPath.Image = global::DoctorERP.Properties.Resources.browse;
            this.BtnPath.UniqueName = "A391E3F642E9431DB8BCC811EA9085C7";
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // LblStyle
            // 
            this.LblStyle.Location = new System.Drawing.Point(221, 111);
            this.LblStyle.Name = "LblStyle";
            this.LblStyle.Size = new System.Drawing.Size(64, 17);
            this.LblStyle.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStyle.TabIndex = 18;
            this.LblStyle.Values.Text = "قالب الألوان";
            // 
            // LblBackupPath
            // 
            this.LblBackupPath.Location = new System.Drawing.Point(221, 83);
            this.LblBackupPath.Name = "LblBackupPath";
            this.LblBackupPath.Size = new System.Drawing.Size(69, 17);
            this.LblBackupPath.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBackupPath.TabIndex = 18;
            this.LblBackupPath.Values.Text = "مسار النسخ";
            this.LblBackupPath.Visible = false;
            // 
            // TxtColumnCount
            // 
            this.TxtColumnCount.Location = new System.Drawing.Point(8, 56);
            this.TxtColumnCount.Name = "TxtColumnCount";
            this.TxtColumnCount.Size = new System.Drawing.Size(211, 21);
            this.TxtColumnCount.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColumnCount.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(221, 58);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(146, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 18;
            this.kryptonLabel1.Values.Text = "عدد أعمدة الشاشة الرئيسية";
            // 
            // TxtAppTitle
            // 
            this.TxtAppTitle.Location = new System.Drawing.Point(8, 29);
            this.TxtAppTitle.Name = "TxtAppTitle";
            this.TxtAppTitle.Size = new System.Drawing.Size(211, 21);
            this.TxtAppTitle.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAppTitle.TabIndex = 0;
            // 
            // LblAppTitle
            // 
            this.LblAppTitle.Location = new System.Drawing.Point(221, 31);
            this.LblAppTitle.Name = "LblAppTitle";
            this.LblAppTitle.Size = new System.Drawing.Size(70, 17);
            this.LblAppTitle.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAppTitle.TabIndex = 18;
            this.LblAppTitle.Values.Text = "اسم البرنامج";
            // 
            // tbNumberFormat
            // 
            this.tbNumberFormat.Controls.Add(this.TxtCurrencyPreview);
            this.tbNumberFormat.Controls.Add(this.TxtQtyFormatPreview);
            this.tbNumberFormat.Controls.Add(this.CmbCurrencyFormat);
            this.tbNumberFormat.Controls.Add(this.LblCurrentPreview);
            this.tbNumberFormat.Controls.Add(this.CmbQtyFormat);
            this.tbNumberFormat.Controls.Add(this.LblCurrencyFormat);
            this.tbNumberFormat.Controls.Add(this.LblQtyPreview);
            this.tbNumberFormat.Controls.Add(this.LblQtyFormat);
            this.tbNumberFormat.Location = new System.Drawing.Point(4, 22);
            this.tbNumberFormat.Name = "tbNumberFormat";
            this.tbNumberFormat.Padding = new System.Windows.Forms.Padding(3);
            this.tbNumberFormat.Size = new System.Drawing.Size(371, 205);
            this.tbNumberFormat.TabIndex = 2;
            this.tbNumberFormat.Text = "تنسيق الأرقام";
            this.tbNumberFormat.UseVisualStyleBackColor = true;
            // 
            // TxtCurrencyPreview
            // 
            this.TxtCurrencyPreview.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnRefreshCurrencyFormat});
            this.TxtCurrencyPreview.Location = new System.Drawing.Point(6, 117);
            this.TxtCurrencyPreview.Name = "TxtCurrencyPreview";
            this.TxtCurrencyPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtCurrencyPreview.Size = new System.Drawing.Size(170, 21);
            this.TxtCurrencyPreview.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCurrencyPreview.TabIndex = 1;
            this.TxtCurrencyPreview.Text = "1500";
            // 
            // BtnRefreshCurrencyFormat
            // 
            this.BtnRefreshCurrencyFormat.UniqueName = "9ABF690C637C49651786F81A8E81CB89";
            this.BtnRefreshCurrencyFormat.Click += new System.EventHandler(this.BtnRefreshQtyFormat_Click);
            // 
            // TxtQtyFormatPreview
            // 
            this.TxtQtyFormatPreview.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnRefreshQtyFormat});
            this.TxtQtyFormatPreview.Location = new System.Drawing.Point(8, 49);
            this.TxtQtyFormatPreview.Name = "TxtQtyFormatPreview";
            this.TxtQtyFormatPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtQtyFormatPreview.Size = new System.Drawing.Size(170, 21);
            this.TxtQtyFormatPreview.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQtyFormatPreview.TabIndex = 1;
            this.TxtQtyFormatPreview.Text = "1500";
            // 
            // BtnRefreshQtyFormat
            // 
            this.BtnRefreshQtyFormat.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.BtnRefreshQtyFormat.UniqueName = "725FF1F4A27D4D8E12A54CAB57F38488";
            this.BtnRefreshQtyFormat.Click += new System.EventHandler(this.BtnRefreshQtyFormat_Click);
            // 
            // CmbCurrencyFormat
            // 
            this.CmbCurrencyFormat.DropDownWidth = 205;
            this.CmbCurrencyFormat.Items.AddRange(new object[] {
            "#,###",
            "#,###.00",
            "N0",
            "N2",
            "F0",
            "F2"});
            this.CmbCurrencyFormat.Location = new System.Drawing.Point(6, 90);
            this.CmbCurrencyFormat.Name = "CmbCurrencyFormat";
            this.CmbCurrencyFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbCurrencyFormat.Size = new System.Drawing.Size(170, 21);
            this.CmbCurrencyFormat.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrencyFormat.TabIndex = 0;
            this.CmbCurrencyFormat.Click += new System.EventHandler(this.CmbQtyFormat_SelectedValueChanged);
            // 
            // LblCurrentPreview
            // 
            this.LblCurrentPreview.Location = new System.Drawing.Point(182, 119);
            this.LblCurrentPreview.Name = "LblCurrentPreview";
            this.LblCurrentPreview.Size = new System.Drawing.Size(38, 17);
            this.LblCurrentPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentPreview.TabIndex = 23;
            this.LblCurrentPreview.Values.Text = "معاينة";
            // 
            // CmbQtyFormat
            // 
            this.CmbQtyFormat.DropDownWidth = 205;
            this.CmbQtyFormat.Items.AddRange(new object[] {
            "#,###",
            "#,###.00",
            "N0",
            "N2",
            "F0",
            "F2"});
            this.CmbQtyFormat.Location = new System.Drawing.Point(8, 22);
            this.CmbQtyFormat.Name = "CmbQtyFormat";
            this.CmbQtyFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbQtyFormat.Size = new System.Drawing.Size(170, 21);
            this.CmbQtyFormat.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbQtyFormat.TabIndex = 0;
            this.CmbQtyFormat.SelectedValueChanged += new System.EventHandler(this.CmbQtyFormat_SelectedValueChanged);
            // 
            // LblCurrencyFormat
            // 
            this.LblCurrencyFormat.Location = new System.Drawing.Point(182, 92);
            this.LblCurrencyFormat.Name = "LblCurrencyFormat";
            this.LblCurrencyFormat.Size = new System.Drawing.Size(101, 17);
            this.LblCurrencyFormat.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrencyFormat.TabIndex = 23;
            this.LblCurrencyFormat.Values.Text = "تنسيق أرقام العملة";
            // 
            // LblQtyPreview
            // 
            this.LblQtyPreview.Location = new System.Drawing.Point(184, 51);
            this.LblQtyPreview.Name = "LblQtyPreview";
            this.LblQtyPreview.Size = new System.Drawing.Size(38, 17);
            this.LblQtyPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtyPreview.TabIndex = 23;
            this.LblQtyPreview.Values.Text = "معاينة";
            // 
            // LblQtyFormat
            // 
            this.LblQtyFormat.Location = new System.Drawing.Point(184, 24);
            this.LblQtyFormat.Name = "LblQtyFormat";
            this.LblQtyFormat.Size = new System.Drawing.Size(103, 17);
            this.LblQtyFormat.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtyFormat.TabIndex = 23;
            this.LblQtyFormat.Values.Text = "تنسيق أرقام الأعداد";
            // 
            // tabAppBackground
            // 
            this.tabAppBackground.Controls.Add(this.BtnRemove);
            this.tabAppBackground.Controls.Add(this.PicBK);
            this.tabAppBackground.Controls.Add(this.BtnBrowse);
            this.tabAppBackground.Location = new System.Drawing.Point(4, 22);
            this.tabAppBackground.Name = "tabAppBackground";
            this.tabAppBackground.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppBackground.Size = new System.Drawing.Size(371, 205);
            this.tabAppBackground.TabIndex = 1;
            this.tabAppBackground.Text = "خلفية البرنامج";
            this.tabAppBackground.UseVisualStyleBackColor = true;
            // 
            // PicBK
            // 
            this.PicBK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBK.Location = new System.Drawing.Point(6, 6);
            this.PicBK.Name = "PicBK";
            this.PicBK.Size = new System.Drawing.Size(283, 159);
            this.PicBK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBK.TabIndex = 26;
            this.PicBK.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PicLogo);
            this.tabPage1.Controls.Add(this.BtnRemoveLogo);
            this.tabPage1.Controls.Add(this.BtnLogo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 205);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "صورة الشعار";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PicLogo
            // 
            this.PicLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicLogo.Location = new System.Drawing.Point(19, 11);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(261, 159);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 27;
            this.PicLogo.TabStop = false;
            // 
            // BtnRemoveLogo
            // 
            this.BtnRemoveLogo.Location = new System.Drawing.Point(230, 176);
            this.BtnRemoveLogo.Name = "BtnRemoveLogo";
            this.BtnRemoveLogo.Size = new System.Drawing.Size(22, 17);
            this.BtnRemoveLogo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemoveLogo.TabIndex = 25;
            this.BtnRemoveLogo.Values.Text = "x";
            this.BtnRemoveLogo.Click += new System.EventHandler(this.BtnRemoveLogo_Click);
            // 
            // BtnLogo
            // 
            this.BtnLogo.Location = new System.Drawing.Point(258, 176);
            this.BtnLogo.Name = "BtnLogo";
            this.BtnLogo.Size = new System.Drawing.Size(22, 17);
            this.BtnLogo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogo.TabIndex = 26;
            this.BtnLogo.Values.Text = "...";
            this.BtnLogo.Click += new System.EventHandler(this.BtnLogo_Click);
            // 
            // FrmAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 270);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معلومات البرنامج";
            this.tabControl1.ResumeLayout(false);
            this.tabAppInfo.ResumeLayout(false);
            this.tabAppInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbStyle)).EndInit();
            this.tbNumberFormat.ResumeLayout(false);
            this.tbNumberFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbCurrencyFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbQtyFormat)).EndInit();
            this.tabAppBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBK)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnBrowse;
        private System.Windows.Forms.PictureBox PicBK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRemove;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAppInfo;
        private System.Windows.Forms.TabPage tabAppBackground;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtAppTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAppTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtBackupPath;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblBackupPath;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnPath;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkBackupOnExit;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbStyle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblStyle;
        private System.Windows.Forms.TabPage tbNumberFormat;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbQtyFormat;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblQtyFormat;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtQtyFormatPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblQtyPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCurrencyPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbCurrencyFormat;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCurrentPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCurrencyFormat;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnRefreshQtyFormat;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnRefreshCurrencyFormat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox PicLogo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRemoveLogo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnLogo;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox ChkShowConfirmMSG;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtColumnCount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}