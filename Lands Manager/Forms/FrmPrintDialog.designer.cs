namespace DoctorERP
{
    partial class FrmPrintDialog
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
            this.BtnPrintAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnPrintOneByOne = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.BtnCancel);
            this.PnlMain.Controls.Add(this.BtnPrintAll);
            this.PnlMain.Controls.Add(this.BtnPrintOneByOne);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(328, 65);
            this.PnlMain.TabIndex = 0;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 22);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(96, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnPrintAll
            // 
            this.BtnPrintAll.Location = new System.Drawing.Point(216, 22);
            this.BtnPrintAll.Name = "BtnPrintAll";
            this.BtnPrintAll.Size = new System.Drawing.Size(96, 25);
            this.BtnPrintAll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrintAll.TabIndex = 4;
            this.BtnPrintAll.Values.Text = "طباعة عقد";
            this.BtnPrintAll.Click += new System.EventHandler(this.BtnPrintAll_Click);
            // 
            // BtnPrintOneByOne
            // 
            this.BtnPrintOneByOne.Location = new System.Drawing.Point(114, 22);
            this.BtnPrintOneByOne.Name = "BtnPrintOneByOne";
            this.BtnPrintOneByOne.Size = new System.Drawing.Size(96, 25);
            this.BtnPrintOneByOne.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrintOneByOne.TabIndex = 4;
            this.BtnPrintOneByOne.Values.Text = "طباعة عقود فردية";
            this.BtnPrintOneByOne.Click += new System.EventHandler(this.BtnPrintOneByOne_Click);
            // 
            // FrmPrintDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 65);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نافذة الطباعة";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnPrintAll;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnPrintOneByOne;
    }
}