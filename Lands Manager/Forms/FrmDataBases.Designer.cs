namespace DoctorERP
{
    partial class FrmDataBases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataBases));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TxtFileLocation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtDatabaseName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtServer = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblFileLocation = new System.Windows.Forms.Label();
            this.LblDataBase = new System.Windows.Forms.Label();
            this.LblServer = new System.Windows.Forms.Label();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ملفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCreateNewDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowAllDatabases = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuConnectionSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuUpdateasArcDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBackupDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSetAsDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnNewDatabase = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnRemove = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnDescription = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnBackup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSetAsDefault = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listView1.RightToLeftLayout = true;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(532, 347);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.ListView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database.png");
            this.imageList1.Images.SetKeyName(1, "DefDB.png");
            // 
            // TxtFileLocation
            // 
            this.TxtFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFileLocation.Location = new System.Drawing.Point(3, 60);
            this.TxtFileLocation.Multiline = true;
            this.TxtFileLocation.Name = "TxtFileLocation";
            this.TxtFileLocation.ReadOnly = true;
            this.TxtFileLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtFileLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtFileLocation.Size = new System.Drawing.Size(188, 42);
            this.TxtFileLocation.TabIndex = 4;
            this.TxtFileLocation.TextChanged += new System.EventHandler(this.TxtFileLocation_TextChanged);
            // 
            // TxtDatabaseName
            // 
            this.TxtDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDatabaseName.Location = new System.Drawing.Point(3, 31);
            this.TxtDatabaseName.Name = "TxtDatabaseName";
            this.TxtDatabaseName.ReadOnly = true;
            this.TxtDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtDatabaseName.Size = new System.Drawing.Size(188, 23);
            this.TxtDatabaseName.TabIndex = 4;
            this.TxtDatabaseName.TextChanged += new System.EventHandler(this.TxtDatabaseName_TextChanged);
            // 
            // TxtServer
            // 
            this.TxtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtServer.Location = new System.Drawing.Point(3, 3);
            this.TxtServer.Name = "TxtServer";
            this.TxtServer.ReadOnly = true;
            this.TxtServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtServer.Size = new System.Drawing.Size(188, 23);
            this.TxtServer.TabIndex = 4;
            // 
            // LblFileLocation
            // 
            this.LblFileLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFileLocation.Location = new System.Drawing.Point(197, 57);
            this.LblFileLocation.Name = "LblFileLocation";
            this.LblFileLocation.Size = new System.Drawing.Size(69, 68);
            this.LblFileLocation.TabIndex = 1;
            this.LblFileLocation.Text = "موقع الملف:";
            this.LblFileLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblDataBase
            // 
            this.LblDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDataBase.Location = new System.Drawing.Point(197, 28);
            this.LblDataBase.Name = "LblDataBase";
            this.LblDataBase.Size = new System.Drawing.Size(69, 29);
            this.LblDataBase.TabIndex = 0;
            this.LblDataBase.Text = "قاعدة البيانات:";
            this.LblDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblServer
            // 
            this.LblServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblServer.Location = new System.Drawing.Point(197, 0);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(69, 28);
            this.LblServer.TabIndex = 0;
            this.LblServer.Text = "المخدم:";
            this.LblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.Location = new System.Drawing.Point(748, 8);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(68, 25);
            this.BtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.TabIndex = 7;
            this.BtnOk.Values.Text = "موافق";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnOk);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 406);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 44);
            this.panel2.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ملفToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // ملفToolStripMenuItem
            // 
            this.ملفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCreateNewDatabase,
            this.MenuShowAllDatabases,
            this.toolStripSeparator2,
            this.MenuConnectionSettings});
            this.ملفToolStripMenuItem.Name = "ملفToolStripMenuItem";
            this.ملفToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ملفToolStripMenuItem.Text = "أدوات";
            // 
            // MenuCreateNewDatabase
            // 
            this.MenuCreateNewDatabase.Name = "MenuCreateNewDatabase";
            this.MenuCreateNewDatabase.Size = new System.Drawing.Size(195, 22);
            this.MenuCreateNewDatabase.Text = "إنشاء قاعدة بيانات جديدة";
            this.MenuCreateNewDatabase.Click += new System.EventHandler(this.MenuCreateNewDatabase_Click);
            // 
            // MenuShowAllDatabases
            // 
            this.MenuShowAllDatabases.CheckOnClick = true;
            this.MenuShowAllDatabases.Name = "MenuShowAllDatabases";
            this.MenuShowAllDatabases.Size = new System.Drawing.Size(195, 22);
            this.MenuShowAllDatabases.Text = "إظهار كافة قواعد البيانات";
            this.MenuShowAllDatabases.Click += new System.EventHandler(this.MenuShowAllDatabases_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // MenuConnectionSettings
            // 
            this.MenuConnectionSettings.Name = "MenuConnectionSettings";
            this.MenuConnectionSettings.Size = new System.Drawing.Size(195, 22);
            this.MenuConnectionSettings.Text = "إعدادات الإتصال";
            this.MenuConnectionSettings.Click += new System.EventHandler(this.MenuConnectionSettings_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUpdateasArcDatabase,
            this.MenuBackupDB,
            this.toolStripSeparator1,
            this.MenuSetAsDefault,
            this.MenuRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 98);
            // 
            // MenuUpdateasArcDatabase
            // 
            this.MenuUpdateasArcDatabase.Name = "MenuUpdateasArcDatabase";
            this.MenuUpdateasArcDatabase.Size = new System.Drawing.Size(208, 22);
            this.MenuUpdateasArcDatabase.Text = "تعيين وصف لقاعدة البيانات";
            this.MenuUpdateasArcDatabase.Click += new System.EventHandler(this.MenuUpdateasArcDatabase_Click);
            // 
            // MenuBackupDB
            // 
            this.MenuBackupDB.Name = "MenuBackupDB";
            this.MenuBackupDB.Size = new System.Drawing.Size(208, 22);
            this.MenuBackupDB.Text = "نسخة إحتياطية";
            this.MenuBackupDB.Click += new System.EventHandler(this.MenuBackupDB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // MenuSetAsDefault
            // 
            this.MenuSetAsDefault.Name = "MenuSetAsDefault";
            this.MenuSetAsDefault.Size = new System.Drawing.Size(208, 22);
            this.MenuSetAsDefault.Text = "تعيين كإفتراضية";
            this.MenuSetAsDefault.Click += new System.EventHandler(this.MenuSetAsDefault_Click);
            // 
            // MenuRemove
            // 
            this.MenuRemove.Name = "MenuRemove";
            this.MenuRemove.Size = new System.Drawing.Size(208, 22);
            this.MenuRemove.Text = "إزالة";
            this.MenuRemove.Click += new System.EventHandler(this.MenuRemove_Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.kryptonPanel2);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(828, 357);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(828, 382);
            this.toolStripContainer2.TabIndex = 11;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel2.Size = new System.Drawing.Size(828, 357);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(5, 5);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonHeaderGroup1);
            this.kryptonSplitContainer1.Panel1MinSize = 100;
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.listView1);
            this.kryptonSplitContainer1.Panel2MinSize = 100;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(818, 347);
            this.kryptonSplitContainer1.SplitterDistance = 281;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tableLayoutPanel2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(281, 347);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "أدوات و خصائص";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.Click += new System.EventHandler(this.KryptonHeaderGroup1_Click);
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.ColorMap = System.Drawing.Color.Black;
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowLeft;
            this.buttonSpecHeaderGroup1.UniqueName = "F83F8E4720614585F83F8E4720614585";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.ButtonSpecHeaderGroup1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel2.Controls.Add(this.BtnNewDatabase, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnRemove, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.BtnDescription, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnBackup, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.BtnSetAsDefault, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 145);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(269, 165);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // BtnNewDatabase
            // 
            this.BtnNewDatabase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnNewDatabase.Location = new System.Drawing.Point(105, 8);
            this.BtnNewDatabase.Name = "BtnNewDatabase";
            this.BtnNewDatabase.Size = new System.Drawing.Size(144, 25);
            this.BtnNewDatabase.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewDatabase.TabIndex = 8;
            this.BtnNewDatabase.Values.Text = "إنشاء قاعدة بيانات جديدة...";
            this.BtnNewDatabase.Click += new System.EventHandler(this.BtnNewDatabase_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnRemove.Location = new System.Drawing.Point(4, 131);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(66, 25);
            this.BtnRemove.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.TabIndex = 8;
            this.BtnRemove.Values.Text = " إزالة";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnDescription
            // 
            this.BtnDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnDescription.Location = new System.Drawing.Point(105, 49);
            this.BtnDescription.Name = "BtnDescription";
            this.BtnDescription.Size = new System.Drawing.Size(144, 25);
            this.BtnDescription.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDescription.TabIndex = 8;
            this.BtnDescription.Values.Text = "تعيين وصف";
            this.BtnDescription.Click += new System.EventHandler(this.BtnDescription_Click);
            // 
            // BtnBackup
            // 
            this.BtnBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnBackup.Location = new System.Drawing.Point(105, 131);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(144, 25);
            this.BtnBackup.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBackup.TabIndex = 8;
            this.BtnBackup.Values.Text = "نسخة إحتياطية";
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BtnSetAsDefault
            // 
            this.BtnSetAsDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSetAsDefault.Location = new System.Drawing.Point(105, 90);
            this.BtnSetAsDefault.Name = "BtnSetAsDefault";
            this.BtnSetAsDefault.Size = new System.Drawing.Size(144, 25);
            this.BtnSetAsDefault.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSetAsDefault.TabIndex = 8;
            this.BtnSetAsDefault.Values.Text = "تعيين كإفتراضية";
            this.BtnSetAsDefault.Click += new System.EventHandler(this.BtnSetAsDefault_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LblServer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtDatabaseName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblDataBase, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblFileLocation, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtFileLocation, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(269, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FrmDataBases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 450);
            this.Controls.Add(this.toolStripContainer2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FrmDataBases";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إختيار قاعدة البيانات";
            this.Load += new System.EventHandler(this.FrmDataBases_Load);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ملفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuCreateNewDatabase;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuRemove;
        private System.Windows.Forms.ToolStripMenuItem MenuShowAllDatabases;
        private System.Windows.Forms.ToolStripMenuItem MenuUpdateasArcDatabase;
        private System.Windows.Forms.ToolStripMenuItem MenuConnectionSettings;
        private System.Windows.Forms.Label LblDataBase;
        private System.Windows.Forms.Label LblFileLocation;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtFileLocation;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtDatabaseName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtServer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnNewDatabase;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRemove;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnBackup;
        private System.Windows.Forms.ToolStripMenuItem MenuBackupDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuSetAsDefault;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSetAsDefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}