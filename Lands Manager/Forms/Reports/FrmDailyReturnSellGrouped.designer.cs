namespace DoctorERP
{
    partial class FrmDailyReturnSellGrouped
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDailyReturnSellGrouped));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.BtnTools = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCustomView = new System.Windows.Forms.ToolStripMenuItem();
            this.LblHint = new System.Windows.Forms.ToolStripStatusLabel();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.LblBank = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblCash = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblTotal = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.CmbChangeDate = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.LblEndDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.LblStartDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnClearSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblSearch = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.DataGridMain = new DataGridViewEx();
            this.BtnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.StatusBar.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbChangeDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnTools,
            this.LblHint});
            this.StatusBar.Location = new System.Drawing.Point(0, 540);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 25;
            this.StatusBar.Text = "statusStrip1";
            // 
            // BtnTools
            // 
            this.BtnTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPreview,
            this.MenuPrint,
            this.MenuDesign,
            this.toolStripSeparator1,
            this.MenuExportToExcel,
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
            this.MenuPreview.Size = new System.Drawing.Size(167, 22);
            this.MenuPreview.Text = "معاينة / تصدير";
            this.MenuPreview.Click += new System.EventHandler(this.MenuPreview_Click);
            // 
            // MenuPrint
            // 
            this.MenuPrint.Name = "MenuPrint";
            this.MenuPrint.Size = new System.Drawing.Size(167, 22);
            this.MenuPrint.Text = "طباعة";
            this.MenuPrint.Click += new System.EventHandler(this.MenuPrint_Click);
            // 
            // MenuDesign
            // 
            this.MenuDesign.Name = "MenuDesign";
            this.MenuDesign.Size = new System.Drawing.Size(167, 22);
            this.MenuDesign.Text = "تصميم";
            this.MenuDesign.Click += new System.EventHandler(this.MenuDesign_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // MenuExportToExcel
            // 
            this.MenuExportToExcel.Name = "MenuExportToExcel";
            this.MenuExportToExcel.Size = new System.Drawing.Size(167, 22);
            this.MenuExportToExcel.Text = "تصدير إلى إكسل ...";
            this.MenuExportToExcel.Click += new System.EventHandler(this.MenuExportToExcel_Click);
            // 
            // MenuCustomView
            // 
            this.MenuCustomView.Name = "MenuCustomView";
            this.MenuCustomView.Size = new System.Drawing.Size(167, 22);
            this.MenuCustomView.Text = "تخصيص المظهر";
            this.MenuCustomView.Click += new System.EventHandler(this.MenuCustomView_Click);
            // 
            // LblHint
            // 
            this.LblHint.Name = "LblHint";
            this.LblHint.Size = new System.Drawing.Size(701, 17);
            this.LblHint.Spring = true;
            this.LblHint.Text = "إضغط بزر الفأرة الأيمن على رأس أي عمود للبحث";
            this.LblHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblHint.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.LblBank);
            this.PnlBottom.Controls.Add(this.LblCash);
            this.PnlBottom.Controls.Add(this.LblTotal);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 470);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(784, 70);
            this.PnlBottom.TabIndex = 27;
            // 
            // LblBank
            // 
            this.LblBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblBank.AutoSize = false;
            this.LblBank.Location = new System.Drawing.Point(515, 38);
            this.LblBank.Name = "LblBank";
            this.LblBank.Size = new System.Drawing.Size(266, 26);
            this.LblBank.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBank.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblBank.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblBank.TabIndex = 17;
            this.LblBank.Values.Text = "البنك 0.0";
            // 
            // LblCash
            // 
            this.LblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCash.AutoSize = false;
            this.LblCash.Location = new System.Drawing.Point(515, 6);
            this.LblCash.Name = "LblCash";
            this.LblCash.Size = new System.Drawing.Size(266, 26);
            this.LblCash.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCash.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblCash.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblCash.TabIndex = 17;
            this.LblCash.Values.Text = "النقدي 0.0";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = false;
            this.LblTotal.Location = new System.Drawing.Point(12, 2);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(203, 62);
            this.LblTotal.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblTotal.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.LblTotal.TabIndex = 17;
            this.LblTotal.Values.Text = "الإجمالي 0.0";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnRefresh);
            this.PnlTop.Controls.Add(this.CmbChangeDate);
            this.PnlTop.Controls.Add(this.kryptonLabel8);
            this.PnlTop.Controls.Add(this.dtEndDate);
            this.PnlTop.Controls.Add(this.LblEndDate);
            this.PnlTop.Controls.Add(this.dtStartDate);
            this.PnlTop.Controls.Add(this.LblStartDate);
            this.PnlTop.Controls.Add(this.TxtSearch);
            this.PnlTop.Controls.Add(this.LblSearch);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(784, 106);
            this.PnlTop.TabIndex = 28;
            // 
            // CmbChangeDate
            // 
            this.CmbChangeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbChangeDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbChangeDate.DropDownWidth = 168;
            this.CmbChangeDate.Items.AddRange(new object[] {
            "بدون",
            "يوم",
            "أسبوع",
            "شهر",
            "ثلاثة أشهر",
            "ستة أشهر",
            "سنة"});
            this.CmbChangeDate.Location = new System.Drawing.Point(548, 14);
            this.CmbChangeDate.Name = "CmbChangeDate";
            this.CmbChangeDate.Size = new System.Drawing.Size(154, 19);
            this.CmbChangeDate.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbChangeDate.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbChangeDate.TabIndex = 125;
            this.CmbChangeDate.SelectedIndexChanged += new System.EventHandler(this.CmbChangeDate_SelectedIndexChanged);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel8.AutoSize = false;
            this.kryptonLabel8.Location = new System.Drawing.Point(709, 14);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(69, 17);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel8.TabIndex = 126;
            this.kryptonLabel8.Values.Text = "التاريخ";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(548, 65);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(154, 20);
            this.dtEndDate.TabIndex = 121;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // LblEndDate
            // 
            this.LblEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEndDate.Location = new System.Drawing.Point(709, 66);
            this.LblEndDate.Name = "LblEndDate";
            this.LblEndDate.Size = new System.Drawing.Size(27, 17);
            this.LblEndDate.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEndDate.TabIndex = 123;
            this.LblEndDate.Values.Text = "إلى";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(548, 39);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(154, 20);
            this.dtStartDate.TabIndex = 122;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // LblStartDate
            // 
            this.LblStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblStartDate.Location = new System.Drawing.Point(709, 40);
            this.LblStartDate.Name = "LblStartDate";
            this.LblStartDate.Size = new System.Drawing.Size(24, 17);
            this.LblStartDate.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStartDate.TabIndex = 124;
            this.LblStartDate.Values.Text = "من";
            // 
            // TxtSearch
            // 
            this.TxtSearch.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnClearSearch});
            this.TxtSearch.Location = new System.Drawing.Point(11, 12);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(175, 21);
            this.TxtSearch.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.TabIndex = 17;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // BtnClearSearch
            // 
            this.BtnClearSearch.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnClearSearch.Image = global::DoctorERP.Properties.Resources.delete;
            this.BtnClearSearch.UniqueName = "2D4DFC044BD642233B9024686EFBFEF0";
            this.BtnClearSearch.Click += new System.EventHandler(this.BtnClearSearch_Click);
            // 
            // LblSearch
            // 
            this.LblSearch.Location = new System.Drawing.Point(192, 14);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(32, 17);
            this.LblSearch.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSearch.TabIndex = 18;
            this.LblSearch.Values.Text = "بحث";
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
            this.DataGridMain.Location = new System.Drawing.Point(0, 106);
            this.DataGridMain.Name = "DataGridMain";
            this.DataGridMain.ReadOnly = true;
            this.DataGridMain.RowHeadersVisible = false;
            this.DataGridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridMain.Size = new System.Drawing.Size(784, 364);
            this.DataGridMain.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.DataGridMain.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.TabIndex = 24;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(11, 39);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(175, 25);
            this.BtnRefresh.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.TabIndex = 128;
            this.BtnRefresh.Values.Text = "تحديث";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // FrmDailyReturnSellGrouped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.DataGridMain);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.PnlBottom);
            this.Controls.Add(this.StatusBar);
            this.Name = "FrmDailyReturnSellGrouped";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير بحث";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbChangeDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewEx DataGridMain;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripSplitButton BtnTools;
        private System.Windows.Forms.ToolStripMenuItem MenuExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem MenuCustomView;
        private System.Windows.Forms.ToolStripStatusLabel LblHint;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblTotal;
        private System.Windows.Forms.Panel PnlTop;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnClearSearch;
        private System.Windows.Forms.ToolStripMenuItem MenuPreview;
        private System.Windows.Forms.ToolStripMenuItem MenuPrint;
        private System.Windows.Forms.ToolStripMenuItem MenuDesign;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbChangeDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblBank;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCash;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRefresh;
    }
}