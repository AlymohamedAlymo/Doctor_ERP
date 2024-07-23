namespace DoctorERP
{
    partial class FrmWebCam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWebCam));
            this.PicView = new System.Windows.Forms.PictureBox();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.BtnFix = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.CmbWebcam = new System.Windows.Forms.ComboBox();
            this.LblCamSource = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicView)).BeginInit();
            this.SuspendLayout();
            // 
            // PicView
            // 
            this.PicView.BackColor = System.Drawing.Color.Black;
            this.PicView.Location = new System.Drawing.Point(12, 28);
            this.PicView.Name = "PicView";
            this.PicView.Size = new System.Drawing.Size(320, 240);
            this.PicView.TabIndex = 0;
            this.PicView.TabStop = false;
            this.PicView.Paint += new System.Windows.Forms.PaintEventHandler(this.PicView_Paint);
            // 
            // BtnPreview
            // 
            this.BtnPreview.Location = new System.Drawing.Point(261, 274);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(75, 23);
            this.BtnPreview.TabIndex = 1;
            this.BtnPreview.Text = "معاينة";
            this.BtnPreview.UseVisualStyleBackColor = true;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // BtnFix
            // 
            this.BtnFix.Enabled = false;
            this.BtnFix.Location = new System.Drawing.Point(180, 274);
            this.BtnFix.Name = "BtnFix";
            this.BtnFix.Size = new System.Drawing.Size(75, 23);
            this.BtnFix.TabIndex = 2;
            this.BtnFix.Text = "تثبيت";
            this.BtnFix.UseVisualStyleBackColor = true;
            this.BtnFix.Click += new System.EventHandler(this.BtnFix_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Enabled = false;
            this.BtnOk.Location = new System.Drawing.Point(12, 274);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 2;
            this.BtnOk.Text = "موافق";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // CmbWebcam
            // 
            this.CmbWebcam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbWebcam.FormattingEnabled = true;
            this.CmbWebcam.Location = new System.Drawing.Point(12, 3);
            this.CmbWebcam.Name = "CmbWebcam";
            this.CmbWebcam.Size = new System.Drawing.Size(269, 21);
            this.CmbWebcam.TabIndex = 3;
            // 
            // LblCamSource
            // 
            this.LblCamSource.AutoSize = true;
            this.LblCamSource.Location = new System.Drawing.Point(287, 6);
            this.LblCamSource.Name = "LblCamSource";
            this.LblCamSource.Size = new System.Drawing.Size(44, 13);
            this.LblCamSource.TabIndex = 4;
            this.LblCamSource.Text = "الكاميرا:";
            // 
            // FrmWebCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 304);
            this.Controls.Add(this.LblCamSource);
            this.Controls.Add(this.CmbWebcam);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnFix);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.PicView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWebCam";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إلتقاط صورة من الكاميرا";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWebCam_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PicView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicView;
        private System.Windows.Forms.Button BtnPreview;
        private System.Windows.Forms.Button BtnFix;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.ComboBox CmbWebcam;
        private System.Windows.Forms.Label LblCamSource;
    }
}