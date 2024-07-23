namespace DoctorERP
{
    partial class FrmSendFreeSMS
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
            this.BtnSend = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TxtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.TxtMessageBody = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblSubject = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblBody = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(140, 146);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(90, 25);
            this.BtnSend.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSend.TabIndex = 44;
            this.BtnSend.Values.Text = "إرسال";
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // TxtSubject
            // 
            this.TxtSubject.Location = new System.Drawing.Point(12, 12);
            this.TxtSubject.Name = "TxtSubject";
            this.TxtSubject.Size = new System.Drawing.Size(218, 21);
            this.TxtSubject.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubject.TabIndex = 40;
            // 
            // TxtMessageBody
            // 
            this.TxtMessageBody.Location = new System.Drawing.Point(12, 39);
            this.TxtMessageBody.Multiline = true;
            this.TxtMessageBody.Name = "TxtMessageBody";
            this.TxtMessageBody.Size = new System.Drawing.Size(218, 101);
            this.TxtMessageBody.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMessageBody.TabIndex = 41;
            // 
            // LblSubject
            // 
            this.LblSubject.Location = new System.Drawing.Point(236, 14);
            this.LblSubject.Name = "LblSubject";
            this.LblSubject.Size = new System.Drawing.Size(59, 17);
            this.LblSubject.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubject.TabIndex = 42;
            this.LblSubject.Values.Text = "رقم الهاتف";
            // 
            // LblBody
            // 
            this.LblBody.Location = new System.Drawing.Point(236, 39);
            this.LblBody.Name = "LblBody";
            this.LblBody.Size = new System.Drawing.Size(65, 17);
            this.LblBody.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBody.TabIndex = 43;
            this.LblBody.Values.Text = "نص الرسالة";
            // 
            // FrmSendFreeSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 181);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.TxtSubject);
            this.Controls.Add(this.TxtMessageBody);
            this.Controls.Add(this.LblSubject);
            this.Controls.Add(this.LblBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendFreeSMS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "رسالة SMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSend;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtMessageBody;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblBody;
    }
}