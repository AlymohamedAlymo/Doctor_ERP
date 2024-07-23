namespace DoctorERP
{
    partial class FrmScanImage2
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
            this.BtnScanner = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TxtFileName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblFileName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChkColor = new System.Windows.Forms.CheckBox();
            this.ChkMultiPages = new System.Windows.Forms.CheckBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblPos = new System.Windows.Forms.Label();
            this.BtnLeft = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnRight = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnScanner
            // 
            this.BtnScanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnScanner.Location = new System.Drawing.Point(630, 11);
            this.BtnScanner.Name = "BtnScanner";
            this.BtnScanner.Size = new System.Drawing.Size(144, 25);
            this.BtnScanner.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnScanner.TabIndex = 36;
            this.BtnScanner.Values.Text = "جلب من الماسح الضوئي";
            this.BtnScanner.Click += new System.EventHandler(this.BtnScanner_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnOk.Location = new System.Drawing.Point(10, 11);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(102, 25);
            this.BtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.TabIndex = 36;
            this.BtnOk.Values.Text = "موافق";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // TxtFileName
            // 
            this.TxtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtFileName.Location = new System.Drawing.Point(118, 13);
            this.TxtFileName.Name = "TxtFileName";
            this.TxtFileName.Size = new System.Drawing.Size(154, 21);
            this.TxtFileName.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFileName.TabIndex = 37;
            // 
            // LblFileName
            // 
            this.LblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblFileName.Location = new System.Drawing.Point(279, 15);
            this.LblFileName.Name = "LblFileName";
            this.LblFileName.Size = new System.Drawing.Size(62, 17);
            this.LblFileName.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFileName.TabIndex = 38;
            this.LblFileName.Values.Text = "اسم الملف";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(415, 10);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(310, 21);
            this.comboBox1.TabIndex = 39;
            // 
            // dsViewer1
            // 
            this.dsViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsViewer1.Location = new System.Drawing.Point(0, 0);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(784, 392);
            this.dsViewer1.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnOk);
            this.panel1.Controls.Add(this.LblFileName);
            this.panel1.Controls.Add(this.TxtFileName);
            this.panel1.Controls.Add(this.BtnScanner);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 515);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 46);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ChkColor);
            this.panel2.Controls.Add(this.ChkMultiPages);
            this.panel2.Controls.Add(this.kryptonLabel1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 81);
            this.panel2.TabIndex = 42;
            // 
            // ChkColor
            // 
            this.ChkColor.AutoSize = true;
            this.ChkColor.Location = new System.Drawing.Point(675, 34);
            this.ChkColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkColor.Name = "ChkColor";
            this.ChkColor.Size = new System.Drawing.Size(48, 17);
            this.ChkColor.TabIndex = 41;
            this.ChkColor.Text = "ملون";
            this.ChkColor.UseVisualStyleBackColor = true;
            // 
            // ChkMultiPages
            // 
            this.ChkMultiPages.AutoSize = true;
            this.ChkMultiPages.Checked = true;
            this.ChkMultiPages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMultiPages.Location = new System.Drawing.Point(623, 56);
            this.ChkMultiPages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChkMultiPages.Name = "ChkMultiPages";
            this.ChkMultiPages.Size = new System.Drawing.Size(95, 17);
            this.ChkMultiPages.TabIndex = 41;
            this.ChkMultiPages.Text = "صفحات متعددة";
            this.ChkMultiPages.UseVisualStyleBackColor = true;
            this.ChkMultiPages.CheckedChanged += new System.EventHandler(this.ChkMultiPages_CheckedChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(731, 11);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(42, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 40;
            this.kryptonLabel1.Values.Text = "المصدر";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblPos);
            this.panel3.Controls.Add(this.BtnLeft);
            this.panel3.Controls.Add(this.BtnRight);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 473);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 42);
            this.panel3.TabIndex = 43;
            // 
            // LblPos
            // 
            this.LblPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPos.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPos.Location = new System.Drawing.Point(653, 11);
            this.LblPos.Name = "LblPos";
            this.LblPos.Size = new System.Drawing.Size(62, 20);
            this.LblPos.TabIndex = 38;
            this.LblPos.Text = "0/0";
            this.LblPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLeft
            // 
            this.BtnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLeft.Location = new System.Drawing.Point(594, 9);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(54, 25);
            this.BtnLeft.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLeft.TabIndex = 37;
            this.BtnLeft.Values.Text = ">";
            this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // BtnRight
            // 
            this.BtnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRight.Location = new System.Drawing.Point(720, 9);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(54, 25);
            this.BtnRight.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRight.TabIndex = 37;
            this.BtnRight.Values.Text = "<";
            this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dsViewer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 392);
            this.panel4.TabIndex = 44;
            // 
            // FrmScanImage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmScanImage2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جلب من الماسح الضوئي";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScanImage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScanImage2_FormClosed);
            this.Load += new System.EventHandler(this.FrmScanImage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnScanner;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtFileName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblFileName;
        private System.Windows.Forms.ComboBox comboBox1;
        private Dynamsoft.Forms.DSViewer dsViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.CheckBox ChkMultiPages;
        private System.Windows.Forms.CheckBox ChkColor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnLeft;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnRight;
        private System.Windows.Forms.Label LblPos;
    }
}