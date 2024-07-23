namespace DoctorERP
{
    partial class FrmPaymentNotes
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txtlandpricenotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblMobile = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txtworkfeenotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txtvatnotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Txtdiscountnotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Controls.Add(this.Txtdiscountnotes);
            this.PnlMain.Controls.Add(this.kryptonLabel3);
            this.PnlMain.Controls.Add(this.Txtvatnotes);
            this.PnlMain.Controls.Add(this.kryptonLabel2);
            this.PnlMain.Controls.Add(this.Txtworkfeenotes);
            this.PnlMain.Controls.Add(this.kryptonLabel1);
            this.PnlMain.Controls.Add(this.Txtlandpricenotes);
            this.PnlMain.Controls.Add(this.LblMobile);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(566, 422);
            this.PnlMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 52);
            this.label1.TabIndex = 16;
            this.label1.Text = "%العميل% تستبدل باسم العميل\r\n%الأرض% تستبدل باسم الأرض\r\n%العقد% تستبدل برقم العقد" +
    "\r\n%نوع الدفعة% تستبدل بنوع الدفعة إذا تم إختيارها";
            // 
            // Txtlandpricenotes
            // 
            this.Txtlandpricenotes.Location = new System.Drawing.Point(12, 12);
            this.Txtlandpricenotes.Multiline = true;
            this.Txtlandpricenotes.Name = "Txtlandpricenotes";
            this.Txtlandpricenotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtlandpricenotes.Size = new System.Drawing.Size(362, 80);
            this.Txtlandpricenotes.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtlandpricenotes.TabIndex = 0;
            // 
            // LblMobile
            // 
            this.LblMobile.Location = new System.Drawing.Point(380, 12);
            this.LblMobile.Name = "LblMobile";
            this.LblMobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblMobile.Size = new System.Drawing.Size(108, 17);
            this.LblMobile.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMobile.TabIndex = 15;
            this.LblMobile.Values.Text = "ملاحظات قيمة الأرض";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(68, 25);
            this.BtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Values.Text = "خروج";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(306, 8);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(68, 25);
            this.BtnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Values.Text = "حفظ";
            this.BtnSave.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnSave);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 422);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(566, 42);
            this.PnlBottom.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(380, 98);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel1.Size = new System.Drawing.Size(146, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "ملاحظات سعي عمولة الأرض";
            // 
            // Txtworkfeenotes
            // 
            this.Txtworkfeenotes.Location = new System.Drawing.Point(12, 98);
            this.Txtworkfeenotes.Multiline = true;
            this.Txtworkfeenotes.Name = "Txtworkfeenotes";
            this.Txtworkfeenotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtworkfeenotes.Size = new System.Drawing.Size(362, 80);
            this.Txtworkfeenotes.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtworkfeenotes.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(380, 184);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel2.Size = new System.Drawing.Size(153, 17);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 15;
            this.kryptonLabel2.Values.Text = "ملاحظات ضريبة عمولة السعي";
            // 
            // Txtvatnotes
            // 
            this.Txtvatnotes.Location = new System.Drawing.Point(12, 184);
            this.Txtvatnotes.Multiline = true;
            this.Txtvatnotes.Name = "Txtvatnotes";
            this.Txtvatnotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtvatnotes.Size = new System.Drawing.Size(362, 80);
            this.Txtvatnotes.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtvatnotes.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(380, 270);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel3.Size = new System.Drawing.Size(127, 17);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 15;
            this.kryptonLabel3.Values.Text = "ملاحظات خصم إستثنائي";
            // 
            // Txtdiscountnotes
            // 
            this.Txtdiscountnotes.Location = new System.Drawing.Point(12, 270);
            this.Txtdiscountnotes.Multiline = true;
            this.Txtdiscountnotes.Name = "Txtdiscountnotes";
            this.Txtdiscountnotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtdiscountnotes.Size = new System.Drawing.Size(362, 80);
            this.Txtdiscountnotes.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdiscountnotes.TabIndex = 3;
            // 
            // FrmPaymentNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 464);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.PnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPaymentNotes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات ملاحظات سند قبض العقد";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSave;
        private System.Windows.Forms.Panel PnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtlandpricenotes;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblMobile;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtworkfeenotes;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtdiscountnotes;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox Txtvatnotes;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}