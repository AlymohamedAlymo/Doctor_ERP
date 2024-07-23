namespace DoctorERP
{
    partial class FrmSendMail
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
            this.TxtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtMessageBody = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblSubject = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblBody = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnSend = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ProgEmail = new CircularProgress.SpinningProgress.SpinningProgress();
            this.Lblsending = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblRecEmail = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtCCEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblViewAttachment = new System.Windows.Forms.LinkLabel();
            this.TxtAttachment = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnPreview = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnSaveAttach = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnDeleteAttach = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.BtnBrowseAttach = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblAttachment = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // TxtSubject
            // 
            this.TxtSubject.Location = new System.Drawing.Point(14, 39);
            this.TxtSubject.Name = "TxtSubject";
            this.TxtSubject.Size = new System.Drawing.Size(218, 21);
            this.TxtSubject.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubject.TabIndex = 19;
            // 
            // TxtMessageBody
            // 
            this.TxtMessageBody.Location = new System.Drawing.Point(14, 66);
            this.TxtMessageBody.Multiline = true;
            this.TxtMessageBody.Name = "TxtMessageBody";
            this.TxtMessageBody.Size = new System.Drawing.Size(218, 101);
            this.TxtMessageBody.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMessageBody.TabIndex = 20;
            // 
            // LblSubject
            // 
            this.LblSubject.Location = new System.Drawing.Point(238, 41);
            this.LblSubject.Name = "LblSubject";
            this.LblSubject.Size = new System.Drawing.Size(74, 17);
            this.LblSubject.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubject.TabIndex = 21;
            this.LblSubject.Values.Text = "عنوان الرسالة";
            // 
            // LblBody
            // 
            this.LblBody.Location = new System.Drawing.Point(238, 66);
            this.LblBody.Name = "LblBody";
            this.LblBody.Size = new System.Drawing.Size(65, 17);
            this.LblBody.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBody.TabIndex = 23;
            this.LblBody.Values.Text = "نص الرسالة";
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(144, 204);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(90, 25);
            this.BtnSend.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSend.TabIndex = 39;
            this.BtnSend.Values.Text = "إرسال";
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // ProgEmail
            // 
            this.ProgEmail.ActiveSegmentColour = System.Drawing.SystemColors.ActiveCaption;
            this.ProgEmail.AutoIncrementFrequency = 100D;
            this.ProgEmail.BehindTransistionSegmentIsActive = false;
            this.ProgEmail.Location = new System.Drawing.Point(108, 201);
            this.ProgEmail.Name = "ProgEmail";
            this.ProgEmail.Size = new System.Drawing.Size(30, 30);
            this.ProgEmail.TabIndex = 40;
            this.ProgEmail.TransistionSegment = 11;
            this.ProgEmail.TransistionSegmentColour = System.Drawing.Color.Blue;
            this.ProgEmail.Visible = false;
            // 
            // Lblsending
            // 
            this.Lblsending.Location = new System.Drawing.Point(12, 208);
            this.Lblsending.Name = "Lblsending";
            this.Lblsending.Size = new System.Drawing.Size(84, 17);
            this.Lblsending.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblsending.TabIndex = 23;
            this.Lblsending.Values.Text = "جاري الإرسال...";
            this.Lblsending.Visible = false;
            // 
            // LblRecEmail
            // 
            this.LblRecEmail.Location = new System.Drawing.Point(238, 14);
            this.LblRecEmail.Name = "LblRecEmail";
            this.LblRecEmail.Size = new System.Drawing.Size(92, 17);
            this.LblRecEmail.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRecEmail.TabIndex = 21;
            this.LblRecEmail.Values.Text = "الإيميل المستقبل";
            // 
            // TxtCCEmail
            // 
            this.TxtCCEmail.Location = new System.Drawing.Point(14, 12);
            this.TxtCCEmail.Name = "TxtCCEmail";
            this.TxtCCEmail.Size = new System.Drawing.Size(218, 21);
            this.TxtCCEmail.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCCEmail.TabIndex = 19;
            // 
            // LblViewAttachment
            // 
            this.LblViewAttachment.Location = new System.Drawing.Point(14, 238);
            this.LblViewAttachment.Name = "LblViewAttachment";
            this.LblViewAttachment.Size = new System.Drawing.Size(218, 26);
            this.LblViewAttachment.TabIndex = 41;
            this.LblViewAttachment.TabStop = true;
            this.LblViewAttachment.Text = "مستندات إضافية مرفقة على شكل صورة\r\n(إضغط للمعاينة)";
            this.LblViewAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblViewAttachment.Visible = false;
            this.LblViewAttachment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblViewAttachment_LinkClicked);
            // 
            // TxtAttachment
            // 
            this.TxtAttachment.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnPreview,
            this.BtnSaveAttach,
            this.BtnDeleteAttach,
            this.BtnBrowseAttach});
            this.TxtAttachment.Location = new System.Drawing.Point(14, 173);
            this.TxtAttachment.Name = "TxtAttachment";
            this.TxtAttachment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtAttachment.Size = new System.Drawing.Size(218, 21);
            this.TxtAttachment.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAttachment.TabIndex = 99;
            // 
            // BtnPreview
            // 
            this.BtnPreview.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnPreview.UniqueName = "8A991C3BB62641E9B587DF794218AD2D";
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreviewAttach_Click);
            // 
            // BtnSaveAttach
            // 
            this.BtnSaveAttach.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnSaveAttach.UniqueName = "FFB42037416B4989ABA0A9B136BBFDB1";
            this.BtnSaveAttach.Click += new System.EventHandler(this.BtnSaveAttach_Click);
            // 
            // BtnDeleteAttach
            // 
            this.BtnDeleteAttach.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnDeleteAttach.UniqueName = "0B84513BAC7A4F1365808847A123E786";
            this.BtnDeleteAttach.Click += new System.EventHandler(this.BtnDeleteAttach_Click);
            // 
            // BtnBrowseAttach
            // 
            this.BtnBrowseAttach.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.BtnBrowseAttach.UniqueName = "7FC43721AE774FE8FB9EC9699AFC6A96";
            this.BtnBrowseAttach.Click += new System.EventHandler(this.BtnBrowseAttach_Click);
            // 
            // LblAttachment
            // 
            this.LblAttachment.Location = new System.Drawing.Point(239, 175);
            this.LblAttachment.Name = "LblAttachment";
            this.LblAttachment.Size = new System.Drawing.Size(44, 17);
            this.LblAttachment.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAttachment.TabIndex = 100;
            this.LblAttachment.Values.Text = "مرفقات";
            // 
            // FrmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 271);
            this.Controls.Add(this.TxtAttachment);
            this.Controls.Add(this.LblAttachment);
            this.Controls.Add(this.LblViewAttachment);
            this.Controls.Add(this.ProgEmail);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.TxtCCEmail);
            this.Controls.Add(this.LblRecEmail);
            this.Controls.Add(this.TxtSubject);
            this.Controls.Add(this.TxtMessageBody);
            this.Controls.Add(this.LblSubject);
            this.Controls.Add(this.Lblsending);
            this.Controls.Add(this.LblBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendMail";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إرسال إيميل";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSendMail_FormClosing);
            this.Load += new System.EventHandler(this.FrmSendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtMessageBody;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblBody;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSend;
        private CircularProgress.SpinningProgress.SpinningProgress ProgEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lblsending;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblRecEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtCCEmail;
        private System.Windows.Forms.LinkLabel LblViewAttachment;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtAttachment;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnPreview;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSaveAttach;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnDeleteAttach;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnBrowseAttach;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblAttachment;
    }
}