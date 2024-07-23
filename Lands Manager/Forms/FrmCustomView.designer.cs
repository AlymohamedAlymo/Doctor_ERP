namespace DoctorERP
{
    partial class FrmCustomView
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
            this.ListColumns = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.BtnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnDefault = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnMoveUp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnMoveDown = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkAutoFill = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.SuspendLayout();
            // 
            // ListColumns
            // 
            this.ListColumns.CheckOnClick = true;
            this.ListColumns.FormattingEnabled = true;
            this.ListColumns.Location = new System.Drawing.Point(12, 12);
            this.ListColumns.Name = "ListColumns";
            this.ListColumns.Size = new System.Drawing.Size(288, 223);
            this.ListColumns.TabIndex = 0;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(209, 262);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(91, 25);
            this.BtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.TabIndex = 27;
            this.BtnOk.Values.Text = "موافق";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnDefault
            // 
            this.BtnDefault.Location = new System.Drawing.Point(12, 262);
            this.BtnDefault.Name = "BtnDefault";
            this.BtnDefault.Size = new System.Drawing.Size(75, 25);
            this.BtnDefault.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDefault.TabIndex = 27;
            this.BtnDefault.Values.Text = "إفتراضي";
            this.BtnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            // 
            // BtnMoveUp
            // 
            this.BtnMoveUp.AutoSize = true;
            this.BtnMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnMoveUp.Location = new System.Drawing.Point(121, 264);
            this.BtnMoveUp.Name = "BtnMoveUp";
            this.BtnMoveUp.Size = new System.Drawing.Size(22, 22);
            this.BtnMoveUp.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.BtnMoveUp.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnMoveUp.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMoveUp.TabIndex = 27;
            this.BtnMoveUp.Values.Image = global::DoctorERP.Properties.Resources.up;
            this.BtnMoveUp.Values.Text = "";
            this.BtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // BtnMoveDown
            // 
            this.BtnMoveDown.AutoSize = true;
            this.BtnMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnMoveDown.Location = new System.Drawing.Point(93, 264);
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.Size = new System.Drawing.Size(22, 22);
            this.BtnMoveDown.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.BtnMoveDown.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnMoveDown.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMoveDown.TabIndex = 27;
            this.BtnMoveDown.Values.Image = global::DoctorERP.Properties.Resources.down;
            this.BtnMoveDown.Values.Text = "";
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // chkAutoFill
            // 
            this.chkAutoFill.Location = new System.Drawing.Point(181, 239);
            this.chkAutoFill.Name = "chkAutoFill";
            this.chkAutoFill.Size = new System.Drawing.Size(119, 17);
            this.chkAutoFill.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoFill.TabIndex = 28;
            this.chkAutoFill.Values.Text = "تمدد تلقائي للأعمدة";
            // 
            // FrmCustomView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 296);
            this.Controls.Add(this.chkAutoFill);
            this.Controls.Add(this.BtnDefault);
            this.Controls.Add(this.BtnMoveDown);
            this.Controls.Add(this.BtnMoveUp);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.ListColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تخصيص مظهر التقرير";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox ListColumns;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnDefault;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnMoveUp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnMoveDown;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkAutoFill;
    }
}