namespace DoctorERP
{
    partial class FrmTaxAndDiscount
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Txtsalesfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Chkisdiscounttotal = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Chkisworkfee = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Chkissalefee = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Chkisbuildingfee = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Chkisdiscountfee = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Chkisvat = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.Lbldiscount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txtdiscounttotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txtdiscounttotalvalue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txtdiscountfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txtdiscountfeevalue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txtvat = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txtbuildingfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.Txtworkfee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.groupControl2);
            this.PnlMain.Controls.Add(this.groupControl1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(385, 327);
            this.PnlMain.TabIndex = 0;
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
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(291, 8);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(68, 25);
            this.BtnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Values.Text = "حفظ";
            this.BtnSave.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnSave);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 327);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(385, 42);
            this.PnlBottom.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.kryptonLabel9);
            this.groupControl1.Controls.Add(this.kryptonLabel8);
            this.groupControl1.Controls.Add(this.kryptonLabel6);
            this.groupControl1.Controls.Add(this.kryptonLabel7);
            this.groupControl1.Controls.Add(this.Txtsalesfee);
            this.groupControl1.Controls.Add(this.Chkisworkfee);
            this.groupControl1.Controls.Add(this.Chkissalefee);
            this.groupControl1.Controls.Add(this.Chkisbuildingfee);
            this.groupControl1.Controls.Add(this.Chkisvat);
            this.groupControl1.Controls.Add(this.Txtvat);
            this.groupControl1.Controls.Add(this.Txtbuildingfee);
            this.groupControl1.Controls.Add(this.Txtworkfee);
            this.groupControl1.Location = new System.Drawing.Point(75, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(284, 147);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "الضرائب";
            // 
            // Txtsalesfee
            // 
            this.Txtsalesfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtsalesfee.Enabled = false;
            this.Txtsalesfee.Location = new System.Drawing.Point(67, 28);
            this.Txtsalesfee.Name = "Txtsalesfee";
            this.Txtsalesfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtsalesfee.Size = new System.Drawing.Size(61, 21);
            this.Txtsalesfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtsalesfee.TabIndex = 0;
            // 
            // Chkisdiscounttotal
            // 
            this.Chkisdiscounttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Chkisdiscounttotal.Location = new System.Drawing.Point(108, 37);
            this.Chkisdiscounttotal.Name = "Chkisdiscounttotal";
            this.Chkisdiscounttotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chkisdiscounttotal.Size = new System.Drawing.Size(162, 17);
            this.Chkisdiscounttotal.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkisdiscounttotal.TabIndex = 5;
            this.Chkisdiscounttotal.Values.Text = "خصم من قيمة الأرض لا يتجاوز";
            this.Chkisdiscounttotal.CheckedChanged += new System.EventHandler(this.Chkisdiscounttotal_CheckedChanged);
            // 
            // Chkisworkfee
            // 
            this.Chkisworkfee.Location = new System.Drawing.Point(151, 85);
            this.Chkisworkfee.Name = "Chkisworkfee";
            this.Chkisworkfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chkisworkfee.Size = new System.Drawing.Size(119, 17);
            this.Chkisworkfee.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkisworkfee.TabIndex = 4;
            this.Chkisworkfee.Values.Text = "نسبة عمولة السعي";
            this.Chkisworkfee.CheckedChanged += new System.EventHandler(this.Chkisworkfee_CheckedChanged);
            // 
            // Chkissalefee
            // 
            this.Chkissalefee.Location = new System.Drawing.Point(148, 29);
            this.Chkissalefee.Name = "Chkissalefee";
            this.Chkissalefee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chkissalefee.Size = new System.Drawing.Size(122, 17);
            this.Chkissalefee.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkissalefee.TabIndex = 3;
            this.Chkissalefee.Values.Text = "نسبة ضريبة المبيعات";
            this.Chkissalefee.CheckedChanged += new System.EventHandler(this.Chkissalefee_CheckedChanged);
            // 
            // Chkisbuildingfee
            // 
            this.Chkisbuildingfee.Location = new System.Drawing.Point(139, 58);
            this.Chkisbuildingfee.Name = "Chkisbuildingfee";
            this.Chkisbuildingfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chkisbuildingfee.Size = new System.Drawing.Size(131, 17);
            this.Chkisbuildingfee.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkisbuildingfee.TabIndex = 2;
            this.Chkisbuildingfee.Values.Text = "نسبة التصرفات العقارية";
            this.Chkisbuildingfee.CheckedChanged += new System.EventHandler(this.Chkisbuildingfee_CheckedChanged);
            // 
            // Chkisdiscountfee
            // 
            this.Chkisdiscountfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Chkisdiscountfee.Location = new System.Drawing.Point(102, 92);
            this.Chkisdiscountfee.Name = "Chkisdiscountfee";
            this.Chkisdiscountfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chkisdiscountfee.Size = new System.Drawing.Size(168, 17);
            this.Chkisdiscountfee.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkisdiscountfee.TabIndex = 1;
            this.Chkisdiscountfee.Values.Text = "خصم من قيمة العمولة لا يتجاوز";
            this.Chkisdiscountfee.CheckedChanged += new System.EventHandler(this.Chkisdiscountfee_CheckedChanged);
            // 
            // Chkisvat
            // 
            this.Chkisvat.Location = new System.Drawing.Point(145, 112);
            this.Chkisvat.Name = "Chkisvat";
            this.Chkisvat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chkisvat.Size = new System.Drawing.Size(125, 17);
            this.Chkisvat.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkisvat.TabIndex = 0;
            this.Chkisvat.Values.Text = "نسبة الضريبة المضافة";
            this.Chkisvat.CheckedChanged += new System.EventHandler(this.Chkisvat_CheckedChanged);
            // 
            // Lbldiscount
            // 
            this.Lbldiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbldiscount.Location = new System.Drawing.Point(208, 64);
            this.Lbldiscount.Name = "Lbldiscount";
            this.Lbldiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbldiscount.Size = new System.Drawing.Size(36, 17);
            this.Lbldiscount.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbldiscount.TabIndex = 44;
            this.Lbldiscount.Values.Text = "نسبة";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel3.Location = new System.Drawing.Point(98, 64);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel3.Size = new System.Drawing.Size(32, 17);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "قيمة";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel4.Location = new System.Drawing.Point(208, 117);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel4.Size = new System.Drawing.Size(36, 17);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 44;
            this.kryptonLabel4.Values.Text = "نسبة";
            // 
            // Txtdiscounttotal
            // 
            this.Txtdiscounttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtdiscounttotal.Enabled = false;
            this.Txtdiscounttotal.Location = new System.Drawing.Point(162, 62);
            this.Txtdiscounttotal.Name = "Txtdiscounttotal";
            this.Txtdiscounttotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtdiscounttotal.Size = new System.Drawing.Size(44, 21);
            this.Txtdiscounttotal.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdiscounttotal.TabIndex = 18;
            this.Txtdiscounttotal.TextChanged += new System.EventHandler(this.Txtdiscounttotal_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel5.Location = new System.Drawing.Point(98, 117);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel5.Size = new System.Drawing.Size(32, 17);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 6;
            this.kryptonLabel5.Values.Text = "قيمة";
            // 
            // Txtdiscounttotalvalue
            // 
            this.Txtdiscounttotalvalue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtdiscounttotalvalue.Enabled = false;
            this.Txtdiscounttotalvalue.Location = new System.Drawing.Point(15, 62);
            this.Txtdiscounttotalvalue.Name = "Txtdiscounttotalvalue";
            this.Txtdiscounttotalvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtdiscounttotalvalue.Size = new System.Drawing.Size(82, 21);
            this.Txtdiscounttotalvalue.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdiscounttotalvalue.TabIndex = 5;
            this.Txtdiscounttotalvalue.TextChanged += new System.EventHandler(this.Txtdiscounttotalvalue_TextChanged);
            // 
            // Txtdiscountfee
            // 
            this.Txtdiscountfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtdiscountfee.Enabled = false;
            this.Txtdiscountfee.Location = new System.Drawing.Point(162, 115);
            this.Txtdiscountfee.Name = "Txtdiscountfee";
            this.Txtdiscountfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtdiscountfee.Size = new System.Drawing.Size(44, 21);
            this.Txtdiscountfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdiscountfee.TabIndex = 18;
            this.Txtdiscountfee.TextChanged += new System.EventHandler(this.Txtdiscountfee_TextChanged);
            // 
            // Txtdiscountfeevalue
            // 
            this.Txtdiscountfeevalue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtdiscountfeevalue.Enabled = false;
            this.Txtdiscountfeevalue.Location = new System.Drawing.Point(15, 115);
            this.Txtdiscountfeevalue.Name = "Txtdiscountfeevalue";
            this.Txtdiscountfeevalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtdiscountfeevalue.Size = new System.Drawing.Size(82, 21);
            this.Txtdiscountfeevalue.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdiscountfeevalue.TabIndex = 7;
            this.Txtdiscountfeevalue.TextChanged += new System.EventHandler(this.Txtdiscountfeevalue_TextChanged);
            // 
            // Txtvat
            // 
            this.Txtvat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtvat.Enabled = false;
            this.Txtvat.Location = new System.Drawing.Point(67, 111);
            this.Txtvat.Name = "Txtvat";
            this.Txtvat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtvat.Size = new System.Drawing.Size(61, 21);
            this.Txtvat.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtvat.TabIndex = 3;
            // 
            // Txtbuildingfee
            // 
            this.Txtbuildingfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtbuildingfee.Enabled = false;
            this.Txtbuildingfee.Location = new System.Drawing.Point(67, 57);
            this.Txtbuildingfee.Name = "Txtbuildingfee";
            this.Txtbuildingfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtbuildingfee.Size = new System.Drawing.Size(61, 21);
            this.Txtbuildingfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtbuildingfee.TabIndex = 1;
            // 
            // Txtworkfee
            // 
            this.Txtworkfee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtworkfee.Enabled = false;
            this.Txtworkfee.Location = new System.Drawing.Point(67, 84);
            this.Txtworkfee.Name = "Txtworkfee";
            this.Txtworkfee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtworkfee.Size = new System.Drawing.Size(61, 21);
            this.Txtworkfee.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtworkfee.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.kryptonLabel1);
            this.groupControl2.Controls.Add(this.kryptonLabel2);
            this.groupControl2.Controls.Add(this.Chkisdiscounttotal);
            this.groupControl2.Controls.Add(this.Txtdiscountfeevalue);
            this.groupControl2.Controls.Add(this.Txtdiscountfee);
            this.groupControl2.Controls.Add(this.Txtdiscounttotalvalue);
            this.groupControl2.Controls.Add(this.kryptonLabel5);
            this.groupControl2.Controls.Add(this.Chkisdiscountfee);
            this.groupControl2.Controls.Add(this.Txtdiscounttotal);
            this.groupControl2.Controls.Add(this.kryptonLabel4);
            this.groupControl2.Controls.Add(this.Lbldiscount);
            this.groupControl2.Controls.Add(this.kryptonLabel3);
            this.groupControl2.Location = new System.Drawing.Point(73, 165);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(284, 154);
            this.groupControl2.TabIndex = 15;
            this.groupControl2.Text = "الخصم";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(138, 117);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel1.Size = new System.Drawing.Size(21, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 45;
            this.kryptonLabel1.Values.Text = "%";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(138, 64);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel2.Size = new System.Drawing.Size(21, 17);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 46;
            this.kryptonLabel2.Values.Text = "%";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel6.Location = new System.Drawing.Point(40, 86);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel6.Size = new System.Drawing.Size(21, 17);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 47;
            this.kryptonLabel6.Values.Text = "%";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel7.Location = new System.Drawing.Point(40, 30);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel7.Size = new System.Drawing.Size(21, 17);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 48;
            this.kryptonLabel7.Values.Text = "%";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel8.Location = new System.Drawing.Point(40, 59);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel8.Size = new System.Drawing.Size(21, 17);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.TabIndex = 49;
            this.kryptonLabel8.Values.Text = "%";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel9.Location = new System.Drawing.Point(40, 113);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel9.Size = new System.Drawing.Size(21, 17);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.TabIndex = 50;
            this.kryptonLabel9.Values.Text = "%";
            // 
            // FrmTaxAndDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 369);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaxAndDiscount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات الضرائب و الخصم";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSave;
        private System.Windows.Forms.Panel PnlBottom;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtsalesfee;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox Chkisdiscounttotal;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox Chkisworkfee;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox Chkissalefee;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox Chkisbuildingfee;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox Chkisdiscountfee;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox Chkisvat;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbldiscount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtdiscounttotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtdiscounttotalvalue;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtdiscountfee;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtdiscountfeevalue;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtvat;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtbuildingfee;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtworkfee;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
    }
}