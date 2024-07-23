partial class FrmConnection
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
            this.GrbBox1 = new System.Windows.Forms.GroupBox();
            this.LblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblUserName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblServerName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtUserName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.CheckBoxWin = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.CmbServer = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtDatabasePath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnDataBasePath = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.CmbSqlType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.LblLocalHints = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.GrbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSqlType)).BeginInit();
            this.SuspendLayout();
            // 
            // GrbBox1
            // 
            this.GrbBox1.Controls.Add(this.LblPassword);
            this.GrbBox1.Controls.Add(this.LblUserName);
            this.GrbBox1.Controls.Add(this.LblServerName);
            this.GrbBox1.Controls.Add(this.TxtPassword);
            this.GrbBox1.Controls.Add(this.TxtUserName);
            this.GrbBox1.Controls.Add(this.CheckBoxWin);
            this.GrbBox1.Controls.Add(this.CmbServer);
            this.GrbBox1.Location = new System.Drawing.Point(44, 39);
            this.GrbBox1.Name = "GrbBox1";
            this.GrbBox1.Size = new System.Drawing.Size(340, 134);
            this.GrbBox1.TabIndex = 0;
            this.GrbBox1.TabStop = false;
            this.GrbBox1.Text = "المخدم";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = false;
            this.LblPassword.Location = new System.Drawing.Point(230, 97);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(80, 27);
            this.LblPassword.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.LblPassword.TabIndex = 4;
            this.LblPassword.Values.Text = "كلمة المرور:";
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = false;
            this.LblUserName.Location = new System.Drawing.Point(230, 72);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(74, 22);
            this.LblUserName.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.LblUserName.TabIndex = 4;
            this.LblUserName.Values.Text = "المستخدم:";
            // 
            // LblServerName
            // 
            this.LblServerName.AutoSize = false;
            this.LblServerName.Location = new System.Drawing.Point(232, 19);
            this.LblServerName.Name = "LblServerName";
            this.LblServerName.Size = new System.Drawing.Size(82, 21);
            this.LblServerName.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.LblServerName.TabIndex = 4;
            this.LblServerName.Values.Text = "اسم المخدم:";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(11, 100);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtPassword.Size = new System.Drawing.Size(215, 23);
            this.TxtPassword.TabIndex = 3;
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(11, 71);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtUserName.Size = new System.Drawing.Size(215, 23);
            this.TxtUserName.TabIndex = 2;
            this.TxtUserName.Text = "sa";
            // 
            // CheckBoxWin
            // 
            this.CheckBoxWin.AutoSize = false;
            this.CheckBoxWin.Location = new System.Drawing.Point(11, 42);
            this.CheckBoxWin.Name = "CheckBoxWin";
            this.CheckBoxWin.Size = new System.Drawing.Size(215, 24);
            this.CheckBoxWin.TabIndex = 1;
            this.CheckBoxWin.Values.Text = "نمط تحقق ويندوز";
            this.CheckBoxWin.CheckedChanged += new System.EventHandler(this.CheckBoxWin_CheckedChanged);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownWidth = 215;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(11, 19);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbServer.Size = new System.Drawing.Size(215, 21);
            this.CmbServer.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(274, 180);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel1.TabIndex = 7;
            this.kryptonLabel1.Values.Text = "مسار قواعد البيانات";
            // 
            // TxtDatabasePath
            // 
            this.TxtDatabasePath.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnDataBasePath});
            this.TxtDatabasePath.Location = new System.Drawing.Point(55, 179);
            this.TxtDatabasePath.Name = "TxtDatabasePath";
            this.TxtDatabasePath.ReadOnly = true;
            this.TxtDatabasePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtDatabasePath.Size = new System.Drawing.Size(215, 23);
            this.TxtDatabasePath.TabIndex = 6;
            // 
            // BtnDataBasePath
            // 
            this.BtnDataBasePath.UniqueName = "74AFECDEC96E4BB6CE8BE0BD724A60C2";
            this.BtnDataBasePath.Click += new System.EventHandler(this.BtnDataBasePath_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(181, 243);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(89, 32);
            this.BtnOk.TabIndex = 2;
            this.BtnOk.Values.Text = "موافق";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(276, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 6;
            this.label1.Values.Text = "نوع الـ SQL";
            // 
            // CmbSqlType
            // 
            this.CmbSqlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSqlType.DropDownWidth = 215;
            this.CmbSqlType.FormattingEnabled = true;
            this.CmbSqlType.Items.AddRange(new object[] {
            "محلية (localDB)",
            "شبكية (SQL Server)"});
            this.CmbSqlType.Location = new System.Drawing.Point(55, 15);
            this.CmbSqlType.Name = "CmbSqlType";
            this.CmbSqlType.Size = new System.Drawing.Size(215, 21);
            this.CmbSqlType.TabIndex = 5;
            this.CmbSqlType.SelectedIndexChanged += new System.EventHandler(this.CmbSqlType_SelectedIndexChanged);
            // 
            // LblLocalHints
            // 
            this.LblLocalHints.AutoSize = false;
            this.LblLocalHints.Location = new System.Drawing.Point(3, 208);
            this.LblLocalHints.Name = "LblLocalHints";
            this.LblLocalHints.Size = new System.Drawing.Size(381, 29);
            this.LblLocalHints.StateNormal.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.LblLocalHints.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLocalHints.StateNormal.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.LblLocalHints.StateNormal.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.LblLocalHints.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.LblLocalHints.TabIndex = 8;
            this.LblLocalHints.Values.Text = "يجب عمل مجلد لقاعدة البيانات عند تخزينها على قرص النظام.";
            // 
            // FrmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 283);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.TxtDatabasePath);
            this.Controls.Add(this.LblLocalHints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbSqlType);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.GrbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات الإتصال";
            this.GrbBox1.ResumeLayout(false);
            this.GrbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSqlType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox GrbBox1;
    private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOk;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbServer;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPassword;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtUserName;
    private ComponentFactory.Krypton.Toolkit.KryptonCheckBox CheckBoxWin;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPassword;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel LblUserName;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel LblServerName;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
    private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbSqlType;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtDatabasePath;
    private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnDataBasePath;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel LblLocalHints;
}
