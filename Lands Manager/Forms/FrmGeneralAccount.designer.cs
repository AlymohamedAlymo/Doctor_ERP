namespace DoctorERP
{
    partial class FrmGeneralAccount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.TxtReserveLands = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtRemainLands = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtTotalLands = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtSalesLand = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtRemain = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtPayements = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtTotalSales = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblAmount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnPrint = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.MenuReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.MenuContextReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.MenuPreview = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.MenuDesign = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridMain = new DataGridViewEx();
            this.ColGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPayments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.tableLayoutPanel1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(763, 258);
            this.PnlMain.TabIndex = 0;
            // 
            // TxtReserveLands
            // 
            this.TxtReserveLands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtReserveLands.Location = new System.Drawing.Point(3, 219);
            this.TxtReserveLands.Name = "TxtReserveLands";
            this.TxtReserveLands.ReadOnly = true;
            this.TxtReserveLands.Size = new System.Drawing.Size(582, 27);
            this.TxtReserveLands.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReserveLands.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReserveLands.TabIndex = 2;
            this.TxtReserveLands.TabStop = false;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel5.Location = new System.Drawing.Point(591, 219);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(169, 36);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 16;
            this.kryptonLabel5.Values.Text = "الأراضي المحجوزة";
            // 
            // TxtRemainLands
            // 
            this.TxtRemainLands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRemainLands.Location = new System.Drawing.Point(3, 183);
            this.TxtRemainLands.Name = "TxtRemainLands";
            this.TxtRemainLands.ReadOnly = true;
            this.TxtRemainLands.Size = new System.Drawing.Size(582, 27);
            this.TxtRemainLands.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemainLands.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemainLands.TabIndex = 2;
            this.TxtRemainLands.TabStop = false;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(591, 183);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(169, 30);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 16;
            this.kryptonLabel4.Values.Text = "الأراضي المتبقية";
            // 
            // TxtTotalLands
            // 
            this.TxtTotalLands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTotalLands.Location = new System.Drawing.Point(3, 111);
            this.TxtTotalLands.Name = "TxtTotalLands";
            this.TxtTotalLands.ReadOnly = true;
            this.TxtTotalLands.Size = new System.Drawing.Size(582, 27);
            this.TxtTotalLands.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalLands.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalLands.TabIndex = 2;
            this.TxtTotalLands.TabStop = false;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel6.Location = new System.Drawing.Point(591, 111);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(169, 30);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 16;
            this.kryptonLabel6.Values.Text = "إجمالي عدد الأراضي";
            // 
            // TxtSalesLand
            // 
            this.TxtSalesLand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSalesLand.Location = new System.Drawing.Point(3, 147);
            this.TxtSalesLand.Name = "TxtSalesLand";
            this.TxtSalesLand.ReadOnly = true;
            this.TxtSalesLand.Size = new System.Drawing.Size(582, 27);
            this.TxtSalesLand.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalesLand.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalesLand.TabIndex = 2;
            this.TxtSalesLand.TabStop = false;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel3.Location = new System.Drawing.Point(591, 147);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(169, 30);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 16;
            this.kryptonLabel3.Values.Text = "الأراضي المباعة";
            // 
            // TxtRemain
            // 
            this.TxtRemain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRemain.Location = new System.Drawing.Point(3, 75);
            this.TxtRemain.Name = "TxtRemain";
            this.TxtRemain.ReadOnly = true;
            this.TxtRemain.Size = new System.Drawing.Size(582, 27);
            this.TxtRemain.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemain.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemain.TabIndex = 2;
            this.TxtRemain.TabStop = false;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.Location = new System.Drawing.Point(591, 75);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(169, 30);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 16;
            this.kryptonLabel2.Values.Text = "المبالغ المتبقية لدى العملاء";
            // 
            // TxtPayements
            // 
            this.TxtPayements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPayements.Location = new System.Drawing.Point(3, 39);
            this.TxtPayements.Name = "TxtPayements";
            this.TxtPayements.ReadOnly = true;
            this.TxtPayements.Size = new System.Drawing.Size(582, 27);
            this.TxtPayements.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPayements.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPayements.TabIndex = 2;
            this.TxtPayements.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(591, 39);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(169, 30);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "إجمالي المبالغ النقدية الواصلة";
            // 
            // TxtTotalSales
            // 
            this.TxtTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTotalSales.Location = new System.Drawing.Point(3, 3);
            this.TxtTotalSales.Name = "TxtTotalSales";
            this.TxtTotalSales.ReadOnly = true;
            this.TxtTotalSales.Size = new System.Drawing.Size(582, 27);
            this.TxtTotalSales.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalSales.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalSales.TabIndex = 2;
            this.TxtTotalSales.TabStop = false;
            // 
            // LblAmount
            // 
            this.LblAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAmount.Location = new System.Drawing.Point(591, 3);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(169, 30);
            this.LblAmount.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmount.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmount.TabIndex = 16;
            this.LblAmount.Values.Text = "إجمالي المبيعات";
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
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnPrint);
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 447);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(763, 42);
            this.PnlBottom.TabIndex = 1;
            // 
            // BtnPrint
            // 
            this.BtnPrint.KryptonContextMenu = this.MenuReport;
            this.BtnPrint.Location = new System.Drawing.Point(505, 8);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.DataGridMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 189);
            this.panel1.TabIndex = 2;
            // 
            // DataGridMain
            // 
            this.DataGridMain.AllowUserToAddRows = false;
            this.DataGridMain.AllowUserToDeleteRows = false;
            this.DataGridMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColGuid,
            this.ColCount,
            this.ColTitle,
            this.ColPayType,
            this.ColAmount,
            this.ColPayments,
            this.ColRemain});
            this.DataGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMain.Location = new System.Drawing.Point(0, 0);
            this.DataGridMain.Name = "DataGridMain";
            this.DataGridMain.ReadOnly = true;
            this.DataGridMain.RowHeadersVisible = false;
            this.DataGridMain.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridMain.Size = new System.Drawing.Size(763, 189);
            this.DataGridMain.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.DataGridMain.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.TabIndex = 25;
            // 
            // ColGuid
            // 
            this.ColGuid.DataPropertyName = "Guid";
            this.ColGuid.HeaderText = "Guid";
            this.ColGuid.Name = "ColGuid";
            this.ColGuid.ReadOnly = true;
            this.ColGuid.Visible = false;
            // 
            // ColCount
            // 
            this.ColCount.DataPropertyName = "c";
            this.ColCount.HeaderText = "عدد القطع";
            this.ColCount.Name = "ColCount";
            this.ColCount.ReadOnly = true;
            this.ColCount.Width = 80;
            // 
            // ColTitle
            // 
            this.ColTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTitle.DataPropertyName = "Title";
            this.ColTitle.HeaderText = "البيان";
            this.ColTitle.Name = "ColTitle";
            this.ColTitle.ReadOnly = true;
            // 
            // ColPayType
            // 
            this.ColPayType.DataPropertyName = "PayType";
            this.ColPayType.HeaderText = "نوع الدفعة";
            this.ColPayType.Name = "ColPayType";
            this.ColPayType.ReadOnly = true;
            this.ColPayType.Width = 135;
            // 
            // ColAmount
            // 
            this.ColAmount.DataPropertyName = "totalnet";
            dataGridViewCellStyle6.Format = "N2";
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColAmount.HeaderText = "القيمة";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            this.ColAmount.Width = 120;
            // 
            // ColPayments
            // 
            this.ColPayments.DataPropertyName = "payments";
            dataGridViewCellStyle7.Format = "N2";
            this.ColPayments.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColPayments.HeaderText = "الواصل";
            this.ColPayments.Name = "ColPayments";
            this.ColPayments.ReadOnly = true;
            this.ColPayments.Width = 120;
            // 
            // ColRemain
            // 
            this.ColRemain.DataPropertyName = "Remain";
            dataGridViewCellStyle8.Format = "N2";
            this.ColRemain.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColRemain.HeaderText = "المتبقي";
            this.ColRemain.Name = "ColRemain";
            this.ColRemain.ReadOnly = true;
            this.ColRemain.Width = 120;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.06684F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.93316F));
            this.tableLayoutPanel1.Controls.Add(this.TxtTotalSales, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.TxtReserveLands, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.TxtPayements, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtRemain, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtRemainLands, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtTotalLands, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtSalesLand, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblAmount, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 258);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // FrmGeneralAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 489);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlBottom);
            this.Name = "FrmGeneralAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التقرير المالي للمخطط";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtTotalSales;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton BtnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu MenuReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems MenuContextReport;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuDesign;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtRemain;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPayements;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtReserveLands;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtRemainLands;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSalesLand;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.Panel panel1;
        private DataGridViewEx DataGridMain;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtTotalLands;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}