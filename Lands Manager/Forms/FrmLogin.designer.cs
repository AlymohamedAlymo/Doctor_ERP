namespace DoctorERP
{
    partial class FrmLogin
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
            this.LblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.CmbUsers = new System.Windows.Forms.ComboBox();
            this.LblUserName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblPasswordHint = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(197, 145);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(68, 25);
            this.BtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.TabIndex = 20;
            this.BtnOk.Values.Text = "موافق";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblPassword
            // 
            this.LblPassword.Location = new System.Drawing.Point(197, 103);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(63, 17);
            this.LblPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.TabIndex = 21;
            this.LblPassword.Values.Text = "كلمة المرور";
            this.LblPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.LblPassword_Paint);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(6, 102);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '●';
            this.TxtPassword.Size = new System.Drawing.Size(185, 21);
            this.TxtPassword.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.TabIndex = 19;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // CmbUsers
            // 
            this.CmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.Location = new System.Drawing.Point(6, 75);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.Size = new System.Drawing.Size(185, 21);
            this.CmbUsers.TabIndex = 22;
            this.CmbUsers.SelectedIndexChanged += new System.EventHandler(this.CmbUsers_SelectedIndexChanged);
            // 
            // LblUserName
            // 
            this.LblUserName.Location = new System.Drawing.Point(197, 77);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(85, 17);
            this.LblUserName.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserName.TabIndex = 21;
            this.LblUserName.Values.Text = "اسم المستخدم";
            this.LblUserName.Paint += new System.Windows.Forms.PaintEventHandler(this.LblPassword_Paint);
            // 
            // LblPasswordHint
            // 
            this.LblPasswordHint.Location = new System.Drawing.Point(71, 125);
            this.LblPasswordHint.Name = "LblPasswordHint";
            this.LblPasswordHint.Size = new System.Drawing.Size(117, 17);
            this.LblPasswordHint.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPasswordHint.TabIndex = 21;
            this.LblPasswordHint.Values.Text = "لم يتم تعيين كلمة مرور";
            this.LblPasswordHint.Paint += new System.Windows.Forms.PaintEventHandler(this.LblPassword_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(39, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 24;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(197, 50);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(47, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 23;
            this.kryptonLabel1.Values.Text = "المخطط";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(90, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "جميع المخططات";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 187);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.CmbUsers);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblPasswordHint);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.TxtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtPassword;
        private System.Windows.Forms.ComboBox CmbUsers;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblPasswordHint;
        private System.Windows.Forms.ComboBox comboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}