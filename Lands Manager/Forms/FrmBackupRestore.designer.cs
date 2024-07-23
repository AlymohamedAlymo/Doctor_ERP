namespace DoctorERP
{
    partial class FrmBackupRestore
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
            this.TxtDataBase = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.LblDataBase = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnStart = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Progress1 = new System.Windows.Forms.ProgressBar();
            this.LblProgress = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtBackupPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnPath = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblBackupPath = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ProgSpin = new CircularProgress.SpinningProgress.SpinningProgress();
            this.LblRestoreHint = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // TxtDataBase
            // 
            this.TxtDataBase.Location = new System.Drawing.Point(12, 11);
            this.TxtDataBase.Name = "TxtDataBase";
            this.TxtDataBase.ReadOnly = true;
            this.TxtDataBase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtDataBase.Size = new System.Drawing.Size(320, 21);
            this.TxtDataBase.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.TxtDataBase.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDataBase.TabIndex = 8;
            // 
            // LblDataBase
            // 
            this.LblDataBase.Location = new System.Drawing.Point(335, 13);
            this.LblDataBase.Name = "LblDataBase";
            this.LblDataBase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblDataBase.Size = new System.Drawing.Size(73, 17);
            this.LblDataBase.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDataBase.TabIndex = 9;
            this.LblDataBase.Values.Text = "قاعدة البيانات";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(12, 111);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(68, 25);
            this.BtnStart.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.TabIndex = 10;
            this.BtnStart.Values.Text = "بدء";
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Progress1
            // 
            this.Progress1.Location = new System.Drawing.Point(12, 88);
            this.Progress1.Name = "Progress1";
            this.Progress1.Size = new System.Drawing.Size(320, 17);
            this.Progress1.TabIndex = 11;
            this.Progress1.Visible = false;
            // 
            // LblProgress
            // 
            this.LblProgress.AutoSize = false;
            this.LblProgress.Location = new System.Drawing.Point(12, 65);
            this.LblProgress.Name = "LblProgress";
            this.LblProgress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblProgress.Size = new System.Drawing.Size(301, 17);
            this.LblProgress.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProgress.TabIndex = 9;
            this.LblProgress.Values.Text = "جاري التحضير ....";
            this.LblProgress.Visible = false;
            // 
            // TxtBackupPath
            // 
            this.TxtBackupPath.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnPath});
            this.TxtBackupPath.Location = new System.Drawing.Point(12, 38);
            this.TxtBackupPath.Name = "TxtBackupPath";
            this.TxtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtBackupPath.Size = new System.Drawing.Size(320, 21);
            this.TxtBackupPath.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBackupPath.TabIndex = 19;
            // 
            // BtnPath
            // 
            this.BtnPath.Image = global::DoctorERP.Properties.Resources.browse;
            this.BtnPath.UniqueName = "A391E3F642E9431DB8BCC811EA9085C7";
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // LblBackupPath
            // 
            this.LblBackupPath.Location = new System.Drawing.Point(334, 40);
            this.LblBackupPath.Name = "LblBackupPath";
            this.LblBackupPath.Size = new System.Drawing.Size(114, 17);
            this.LblBackupPath.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBackupPath.TabIndex = 20;
            this.LblBackupPath.Values.Text = "ملف النسخ الإحتياطي";
            // 
            // TxtLog
            // 
            this.TxtLog.Location = new System.Drawing.Point(12, 142);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(320, 108);
            this.TxtLog.TabIndex = 21;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(338, 142);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 17);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 20;
            this.kryptonLabel1.Values.Text = "سجل العملية";
            // 
            // ProgSpin
            // 
            this.ProgSpin.ActiveSegmentColour = System.Drawing.SystemColors.ActiveCaption;
            this.ProgSpin.AutoIncrementFrequency = 100D;
            this.ProgSpin.BehindTransistionSegmentIsActive = false;
            this.ProgSpin.Location = new System.Drawing.Point(313, 65);
            this.ProgSpin.Name = "ProgSpin";
            this.ProgSpin.Size = new System.Drawing.Size(16, 17);
            this.ProgSpin.TabIndex = 41;
            this.ProgSpin.TransistionSegment = 7;
            this.ProgSpin.TransistionSegmentColour = System.Drawing.Color.Blue;
            this.ProgSpin.Visible = false;
            // 
            // LblRestoreHint
            // 
            this.LblRestoreHint.AutoSize = false;
            this.LblRestoreHint.Location = new System.Drawing.Point(99, 115);
            this.LblRestoreHint.Name = "LblRestoreHint";
            this.LblRestoreHint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblRestoreHint.Size = new System.Drawing.Size(244, 17);
            this.LblRestoreHint.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblRestoreHint.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRestoreHint.TabIndex = 42;
            this.LblRestoreHint.Values.Text = "يجب عدم إغلاق النافذة أثناء بدء الإستعادة";
            this.LblRestoreHint.Visible = false;
            // 
            // FrmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 262);
            this.Controls.Add(this.LblRestoreHint);
            this.Controls.Add(this.ProgSpin);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.TxtBackupPath);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.LblBackupPath);
            this.Controls.Add(this.Progress1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TxtDataBase);
            this.Controls.Add(this.LblProgress);
            this.Controls.Add(this.LblDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBackupRestore";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "النسخ الإحتياطي";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBackupRestore_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtDataBase;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblDataBase;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnStart;
        private System.Windows.Forms.ProgressBar Progress1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblProgress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtBackupPath;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnPath;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblBackupPath;
        private System.Windows.Forms.TextBox TxtLog;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private CircularProgress.SpinningProgress.SpinningProgress ProgSpin;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblRestoreHint;
    }
}