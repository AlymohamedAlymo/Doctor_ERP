namespace DoctorERP
{
    partial class FrmActivate
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
            this.BtnActivate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.LblVersion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtVersion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblCode = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblHints = new System.Windows.Forms.Label();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblWebSite = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblEmail2 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.LblEmail1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnActivate
            // 
            this.BtnActivate.Location = new System.Drawing.Point(6, 202);
            this.BtnActivate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnActivate.Name = "BtnActivate";
            this.BtnActivate.Size = new System.Drawing.Size(390, 31);
            this.BtnActivate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActivate.TabIndex = 4;
            this.BtnActivate.Values.Text = "تفعيل";
            this.BtnActivate.Click += new System.EventHandler(this.BtnActivate_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.Location = new System.Drawing.Point(406, 102);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(81, 21);
            this.LblVersion.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.TabIndex = 73;
            this.LblVersion.Values.Text = "رقم النسخة";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(6, 100);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.ReadOnly = true;
            this.TxtVersion.Size = new System.Drawing.Size(390, 24);
            this.TxtVersion.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVersion.TabIndex = 2;
            // 
            // TxtCode
            // 
            this.TxtCode.Location = new System.Drawing.Point(6, 133);
            this.TxtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(390, 24);
            this.TxtCode.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCode.TabIndex = 3;
            // 
            // LblCode
            // 
            this.LblCode.Location = new System.Drawing.Point(402, 135);
            this.LblCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblCode.Name = "LblCode";
            this.LblCode.Size = new System.Drawing.Size(77, 21);
            this.LblCode.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCode.TabIndex = 73;
            this.LblCode.Values.Text = "كود التفعيل";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(106, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "كود التفعيل لحاسب واحد فقط";
            // 
            // LblHints
            // 
            this.LblHints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblHints.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHints.Location = new System.Drawing.Point(6, 11);
            this.LblHints.Name = "LblHints";
            this.LblHints.Size = new System.Drawing.Size(389, 81);
            this.LblHints.TabIndex = 75;
            this.LblHints.Text = "نشكر إهتمامكم بمنتجاتنا \r\nثقتكم بنا هي رأس مالنا\r\nأرسل لنا رقم النسخة ليتم إرسال " +
    "كود التفعيل";
            this.LblHints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 287);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.PicLogo);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.LblWebSite);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.LblEmail2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.LblEmail1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(489, 192);
            this.kryptonHeaderGroup1.TabIndex = 76;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "معلومات التواصل";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // PicLogo
            // 
            this.PicLogo.BackColor = System.Drawing.Color.Transparent;
            
            this.PicLogo.Location = new System.Drawing.Point(346, 55);
            this.PicLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(135, 101);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicLogo.TabIndex = 77;
            this.PicLogo.TabStop = false;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.AutoSize = false;
            this.kryptonLabel3.Location = new System.Drawing.Point(5, 4);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(478, 39);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel3.TabIndex = 76;
            this.kryptonLabel3.Values.Text = "شركة قوّة الرمز لتقنية المعلومات";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(180, 60);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(99, 21);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 76;
            this.kryptonLabel4.Values.Text = "موقع الشركة";
            // 
            // LblWebSite
            // 
            this.LblWebSite.Location = new System.Drawing.Point(14, 58);
            this.LblWebSite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblWebSite.Name = "LblWebSite";
            this.LblWebSite.Size = new System.Drawing.Size(164, 24);
            this.LblWebSite.TabIndex = 75;
            this.LblWebSite.Values.Text = "www.powerofcode.net";
            this.LblWebSite.LinkClicked += new System.EventHandler(this.LblWebSite_LinkClicked);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(180, 124);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(67, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 74;
            this.kryptonLabel2.Values.Text = "المبيعات";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(180, 92);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(92, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 74;
            this.kryptonLabel1.Values.Text = "الدعم الفني";
            // 
            // LblEmail2
            // 
            this.LblEmail2.Location = new System.Drawing.Point(14, 122);
            this.LblEmail2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblEmail2.Name = "LblEmail2";
            this.LblEmail2.Size = new System.Drawing.Size(168, 24);
            this.LblEmail2.TabIndex = 0;
            this.LblEmail2.Values.Text = "sale@powerofcode.net";
            this.LblEmail2.LinkClicked += new System.EventHandler(this.LblEmail2_LinkClicked);
            // 
            // LblEmail1
            // 
            this.LblEmail1.Location = new System.Drawing.Point(14, 90);
            this.LblEmail1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LblEmail1.Name = "LblEmail1";
            this.LblEmail1.Size = new System.Drawing.Size(168, 24);
            this.LblEmail1.TabIndex = 0;
            this.LblEmail1.Values.Text = "info@powerofcode.net";
            this.LblEmail1.LinkClicked += new System.EventHandler(this.LblEmail1_LinkClicked);
            // 
            // FrmActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 479);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.LblHints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblCode);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnActivate);
            this.Controls.Add(this.TxtCode);
            this.Controls.Add(this.TxtVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmActivate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تفعيل البرنامج";
            this.Load += new System.EventHandler(this.FrmActivate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnActivate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblVersion;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtVersion;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblHints;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel LblEmail2;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel LblEmail1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel LblWebSite;
        private System.Windows.Forms.PictureBox PicLogo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}