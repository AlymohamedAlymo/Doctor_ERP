namespace DoctorERP
{
    partial class FrmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.MenuDesign = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDesginAttahment = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPreview = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtConfirm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.CheckBoxIsAdmin = new System.Windows.Forms.CheckBox();
            this.LblName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.checkListRules = new System.Windows.Forms.CheckedListBox();
            this.LblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblConfirm = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnSelectNone = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSelectAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ChkLstPermissions = new System.Windows.Forms.CheckedListBox();
            this.MenuContextReport = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.PnlMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // PnlTop
            // 
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(567, 28);
            this.PnlTop.TabIndex = 34;
            this.PnlTop.Visible = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.bindingNavigator1.Size = new System.Drawing.Size(178, 27);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // MenuDesign
            // 
            this.MenuDesign.StateNormal.ItemTextStandard.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuDesign.Text = "تصميم";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(338, 8);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(68, 25);
            this.BtnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Values.Text = "تعديل";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(412, 8);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(68, 25);
            this.BtnAdd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Values.Text = "إضافة";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(488, 8);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(68, 25);
            this.BtnNew.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.TabIndex = 4;
            this.BtnNew.Values.Text = "جديد";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.bindingNavigator1);
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnDelete);
            this.PnlBottom.Controls.Add(this.BtnEdit);
            this.PnlBottom.Controls.Add(this.BtnAdd);
            this.PnlBottom.Controls.Add(this.BtnNew);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 257);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(567, 42);
            this.PnlBottom.TabIndex = 33;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(86, 8);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(68, 25);
            this.BtnDelete.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Values.Text = "حذف";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExtract,
            this.MenuSendEmail,
            this.toolStripSeparator2,
            this.MenuPrint,
            this.MenuPrev,
            this.MenuDesginAttahment,
            this.toolStripSeparator1,
            this.MenuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 148);
            // 
            // MenuExtract
            // 
            this.MenuExtract.Name = "MenuExtract";
            this.MenuExtract.Size = new System.Drawing.Size(142, 22);
            this.MenuExtract.Text = "إستخراج";
            // 
            // MenuSendEmail
            // 
            this.MenuSendEmail.Name = "MenuSendEmail";
            this.MenuSendEmail.Size = new System.Drawing.Size(142, 22);
            this.MenuSendEmail.Text = "إرسال بالإيميل";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // MenuPrint
            // 
            this.MenuPrint.Name = "MenuPrint";
            this.MenuPrint.Size = new System.Drawing.Size(142, 22);
            this.MenuPrint.Text = "طباعة";
            // 
            // MenuPrev
            // 
            this.MenuPrev.Name = "MenuPrev";
            this.MenuPrev.Size = new System.Drawing.Size(142, 22);
            this.MenuPrev.Text = "معاينة";
            // 
            // MenuDesginAttahment
            // 
            this.MenuDesginAttahment.Name = "MenuDesginAttahment";
            this.MenuDesginAttahment.Size = new System.Drawing.Size(142, 22);
            this.MenuDesginAttahment.Text = "تصميم";
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(142, 22);
            this.MenuDelete.Text = "حذف";
            // 
            // MenuPreview
            // 
            this.MenuPreview.StateNormal.ItemTextStandard.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPreview.Text = "معاينة";
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.tabControl1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 28);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(567, 229);
            this.PnlMain.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 229);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtName);
            this.tabPage1.Controls.Add(this.TxtPassword);
            this.tabPage1.Controls.Add(this.TxtConfirm);
            this.tabPage1.Controls.Add(this.CheckBoxIsAdmin);
            this.tabPage1.Controls.Add(this.LblName);
            this.tabPage1.Controls.Add(this.checkListRules);
            this.tabPage1.Controls.Add(this.LblPassword);
            this.tabPage1.Controls.Add(this.LblConfirm);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 203);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "عام";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(202, 11);
            this.TxtName.Name = "TxtName";
            this.TxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtName.Size = new System.Drawing.Size(200, 21);
            this.TxtName.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.TabIndex = 0;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(202, 38);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '●';
            this.TxtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtPassword.Size = new System.Drawing.Size(200, 21);
            this.TxtPassword.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // TxtConfirm
            // 
            this.TxtConfirm.Location = new System.Drawing.Point(202, 65);
            this.TxtConfirm.Name = "TxtConfirm";
            this.TxtConfirm.PasswordChar = '●';
            this.TxtConfirm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtConfirm.Size = new System.Drawing.Size(200, 21);
            this.TxtConfirm.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirm.TabIndex = 2;
            this.TxtConfirm.UseSystemPasswordChar = true;
            // 
            // CheckBoxIsAdmin
            // 
            this.CheckBoxIsAdmin.AutoSize = true;
            this.CheckBoxIsAdmin.Location = new System.Drawing.Point(97, 12);
            this.CheckBoxIsAdmin.Name = "CheckBoxIsAdmin";
            this.CheckBoxIsAdmin.Size = new System.Drawing.Size(98, 17);
            this.CheckBoxIsAdmin.TabIndex = 5;
            this.CheckBoxIsAdmin.Text = "مسؤول البرنامج";
            this.CheckBoxIsAdmin.UseVisualStyleBackColor = true;
            this.CheckBoxIsAdmin.CheckedChanged += new System.EventHandler(this.CheckBoxIsAdmin_CheckedChanged);
            // 
            // LblName
            // 
            this.LblName.Location = new System.Drawing.Point(408, 12);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(39, 17);
            this.LblName.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.TabIndex = 16;
            this.LblName.Values.Text = "الاسم";
            // 
            // checkListRules
            // 
            this.checkListRules.FormattingEnabled = true;
            this.checkListRules.Items.AddRange(new object[] {
            "إضافة",
            "تعديل",
            "حذف",
            "طباعة"});
            this.checkListRules.Location = new System.Drawing.Point(202, 92);
            this.checkListRules.Name = "checkListRules";
            this.checkListRules.Size = new System.Drawing.Size(200, 64);
            this.checkListRules.TabIndex = 4;
            // 
            // LblPassword
            // 
            this.LblPassword.Location = new System.Drawing.Point(408, 39);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(63, 17);
            this.LblPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.TabIndex = 16;
            this.LblPassword.Values.Text = "كلمة المرور";
            // 
            // LblConfirm
            // 
            this.LblConfirm.Location = new System.Drawing.Point(408, 66);
            this.LblConfirm.Name = "LblConfirm";
            this.LblConfirm.Size = new System.Drawing.Size(89, 17);
            this.LblConfirm.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConfirm.TabIndex = 16;
            this.LblConfirm.Values.Text = "تأكيد كلمة المرور";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnSelectNone);
            this.tabPage2.Controls.Add(this.BtnSelectAll);
            this.tabPage2.Controls.Add(this.ChkLstPermissions);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 203);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "صلاحيات متقدمة";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnSelectNone
            // 
            this.BtnSelectNone.Location = new System.Drawing.Point(186, 167);
            this.BtnSelectNone.Name = "BtnSelectNone";
            this.BtnSelectNone.Size = new System.Drawing.Size(68, 25);
            this.BtnSelectNone.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectNone.TabIndex = 24;
            this.BtnSelectNone.Values.Text = "إلغاء التحديد";
            this.BtnSelectNone.Click += new System.EventHandler(this.BtnSelectNone_Click);
            // 
            // BtnSelectAll
            // 
            this.BtnSelectAll.Location = new System.Drawing.Point(334, 167);
            this.BtnSelectAll.Name = "BtnSelectAll";
            this.BtnSelectAll.Size = new System.Drawing.Size(68, 25);
            this.BtnSelectAll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectAll.TabIndex = 23;
            this.BtnSelectAll.Values.Text = "تحديد الكل";
            this.BtnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // ChkLstPermissions
            // 
            this.ChkLstPermissions.FormattingEnabled = true;
            this.ChkLstPermissions.Items.AddRange(new object[] {
            "معلومات المخطط",
            "تعريف المالك",
            "فتح مرفق المخطط النهاري",
            "إستيراد من إكسل",
            "رسالة جوال حرة",
            "نسخة إحتياطية إلى ملف",
            "إستعادة نسخة إحتياطية",
            "بطاقة عميل",
            "بطاقة صنف",
            "شجرة الأصناف",
            "إفراغات الأراضي",
            "عقد بيع",
            "سند قبض",
            "عقد بيع ( خارجي )",
            "سند قبض ( خارجي )",
            "بطاقة حساب",
            "سند قبض",
            "سند صرف",
            "كشف حساب",
            "أرصدة الحسابات",
            "بحث عن صنف",
            "بحث عن عميل",
            "مبيعات يومية",
            "مبيعات يومية تجميعي",
            "جرد المبيعات",
            "مرتجع مبيعات يومية",
            "مرتجع مبيعات يومية تجميعي",
            "جرد جميع الأصناف",
            "جرد الأصناف المتبقية",
            "جرد حسب الكمية",
            "ضريبة التصرفات العقارية",
            "ضريبة عمولة السعي",
            "عمولة السعي",
            "كشف حساب عميل",
            "كشف حساب عميل تفصيلي",
            "تقرير مالي المخطط العام",
            "إعدادات المعلومات الضريبية للشركة",
            "إعدادات ضرائب الأصناف و الخصم",
            "إعدادات الجوال",
            "إعدادت البريد الإلكتروني",
            "سجل المستخدمين",
            "خيارات البرنامج"});
            this.ChkLstPermissions.Location = new System.Drawing.Point(186, 6);
            this.ChkLstPermissions.Name = "ChkLstPermissions";
            this.ChkLstPermissions.Size = new System.Drawing.Size(216, 154);
            this.ChkLstPermissions.TabIndex = 22;
            // 
            // MenuContextReport
            // 
            this.MenuContextReport.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.MenuPreview,
            this.MenuDesign});
            // 
            // FrmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 299);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المستخدمون";
            this.Load += new System.EventHandler(this.FrmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuDesign;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnNew;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuExtract;
        private System.Windows.Forms.ToolStripMenuItem MenuSendEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuPrint;
        private System.Windows.Forms.ToolStripMenuItem MenuPrev;
        private System.Windows.Forms.ToolStripMenuItem MenuDesginAttahment;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem MenuPreview;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.CheckBox CheckBoxIsAdmin;
        private System.Windows.Forms.CheckedListBox checkListRules;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtName;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems MenuContextReport;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblConfirm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtConfirm;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSelectNone;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSelectAll;
        private System.Windows.Forms.CheckedListBox ChkLstPermissions;
    }
}