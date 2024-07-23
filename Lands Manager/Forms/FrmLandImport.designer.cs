namespace DoctorERP
{
    partial class FrmLandImport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbSheets = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.TxtSelectExcelFile = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.BtnSelectExcelFile = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.LblRowsCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblExcelSheet = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LblExcelFile = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.LblData = new System.Windows.Forms.Label();
            this.BtnPreview = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DataGridMain = new DataGridViewEx();
            this.DataGridColumns = new DataGridViewEx();
            this.ColGuiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDBField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnExcelTemplates = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSheets)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnExcelTemplates);
            this.panel1.Controls.Add(this.CmbSheets);
            this.panel1.Controls.Add(this.TxtSelectExcelFile);
            this.panel1.Controls.Add(this.LblRowsCount);
            this.panel1.Controls.Add(this.LblExcelSheet);
            this.panel1.Controls.Add(this.LblExcelFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 62);
            this.panel1.TabIndex = 2;
            // 
            // CmbSheets
            // 
            this.CmbSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSheets.DropDownWidth = 422;
            this.CmbSheets.Location = new System.Drawing.Point(408, 11);
            this.CmbSheets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbSheets.Name = "CmbSheets";
            this.CmbSheets.Size = new System.Drawing.Size(253, 21);
            this.CmbSheets.TabIndex = 7;
            this.CmbSheets.SelectedIndexChanged += new System.EventHandler(this.CmbSheets_SelectedIndexChanged);
            // 
            // TxtSelectExcelFile
            // 
            this.TxtSelectExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSelectExcelFile.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.BtnSelectExcelFile});
            this.TxtSelectExcelFile.Location = new System.Drawing.Point(713, 11);
            this.TxtSelectExcelFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtSelectExcelFile.Name = "TxtSelectExcelFile";
            this.TxtSelectExcelFile.Size = new System.Drawing.Size(253, 23);
            this.TxtSelectExcelFile.TabIndex = 6;
            // 
            // BtnSelectExcelFile
            // 
            this.BtnSelectExcelFile.UniqueName = "B990065CE16245458AB7485AA518AF81";
            this.BtnSelectExcelFile.Click += new System.EventHandler(this.BtnSelectExcelFile_Click);
            // 
            // LblRowsCount
            // 
            this.LblRowsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRowsCount.AutoSize = false;
            this.LblRowsCount.Location = new System.Drawing.Point(408, 38);
            this.LblRowsCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LblRowsCount.Name = "LblRowsCount";
            this.LblRowsCount.Size = new System.Drawing.Size(558, 20);
            this.LblRowsCount.TabIndex = 3;
            this.LblRowsCount.Values.Text = "عدد الأسطر 0";
            // 
            // LblExcelSheet
            // 
            this.LblExcelSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblExcelSheet.Location = new System.Drawing.Point(664, 12);
            this.LblExcelSheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LblExcelSheet.Name = "LblExcelSheet";
            this.LblExcelSheet.Size = new System.Drawing.Size(40, 20);
            this.LblExcelSheet.TabIndex = 4;
            this.LblExcelSheet.Values.Text = "الورقة";
            // 
            // LblExcelFile
            // 
            this.LblExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblExcelFile.Location = new System.Drawing.Point(962, 14);
            this.LblExcelFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LblExcelFile.Name = "LblExcelFile";
            this.LblExcelFile.Size = new System.Drawing.Size(73, 20);
            this.LblExcelFile.TabIndex = 5;
            this.LblExcelFile.Values.Text = "ملف الإكسل";
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(8, 10);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(137, 44);
            this.BtnImport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImport.TabIndex = 1;
            this.BtnImport.Values.Text = "استيراد";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click_1);
            // 
            // LblData
            // 
            this.LblData.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblData.Location = new System.Drawing.Point(642, 0);
            this.LblData.Name = "LblData";
            this.LblData.Size = new System.Drawing.Size(405, 66);
            this.LblData.TabIndex = 26;
            this.LblData.Text = "البيانات التي سيتم إستيرادها";
            this.LblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnPreview
            // 
            this.BtnPreview.Location = new System.Drawing.Point(151, 10);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(137, 44);
            this.BtnPreview.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.TabIndex = 9;
            this.BtnPreview.Values.Text = "معاينة";
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblData);
            this.panel2.Controls.Add(this.BtnPreview);
            this.panel2.Controls.Add(this.BtnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1047, 66);
            this.panel2.TabIndex = 27;
            // 
            // DataGridMain
            // 
            this.DataGridMain.AllowUserToAddRows = false;
            this.DataGridMain.AllowUserToDeleteRows = false;
            this.DataGridMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridMain.Location = new System.Drawing.Point(0, 308);
            this.DataGridMain.Name = "DataGridMain";
            this.DataGridMain.ReadOnly = true;
            this.DataGridMain.RowHeadersVisible = false;
            this.DataGridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridMain.Size = new System.Drawing.Size(1047, 254);
            this.DataGridMain.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.DataGridMain.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridMain.TabIndex = 25;
            // 
            // DataGridColumns
            // 
            this.DataGridColumns.AllowUserToAddRows = false;
            this.DataGridColumns.AllowUserToDeleteRows = false;
            this.DataGridColumns.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColGuiName,
            this.ColDBField});
            this.DataGridColumns.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataGridColumns.Location = new System.Drawing.Point(0, 62);
            this.DataGridColumns.Name = "DataGridColumns";
            this.DataGridColumns.RowHeadersVisible = false;
            this.DataGridColumns.Size = new System.Drawing.Size(1047, 180);
            this.DataGridColumns.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.DataGridColumns.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridColumns.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridColumns.TabIndex = 25;
            this.DataGridColumns.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridColumns_CellBeginEdit);
            // 
            // ColGuiName
            // 
            this.ColGuiName.DataPropertyName = "GuiName";
            this.ColGuiName.HeaderText = "اسم الحقل";
            this.ColGuiName.Name = "ColGuiName";
            this.ColGuiName.Width = 200;
            // 
            // ColDBField
            // 
            this.ColDBField.DataPropertyName = "DbField";
            this.ColDBField.HeaderText = "DBField";
            this.ColDBField.Name = "ColDBField";
            this.ColDBField.Visible = false;
            // 
            // BtnExcelTemplates
            // 
            this.BtnExcelTemplates.Location = new System.Drawing.Point(12, 11);
            this.BtnExcelTemplates.Name = "BtnExcelTemplates";
            this.BtnExcelTemplates.Size = new System.Drawing.Size(137, 44);
            this.BtnExcelTemplates.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcelTemplates.TabIndex = 10;
            this.BtnExcelTemplates.Values.Text = "قالب الإكسل المعتمد";
            this.BtnExcelTemplates.Click += new System.EventHandler(this.BtnExcelTemplates_Click);
            // 
            // FrmLandImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 562);
            this.Controls.Add(this.DataGridMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DataGridColumns);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLandImport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "استيراد الأصناف";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSheets)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DataGridViewEx DataGridMain;
        private System.Windows.Forms.Label LblData;
        private DataGridViewEx DataGridColumns;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox CmbSheets;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtSelectExcelFile;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny BtnSelectExcelFile;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblRowsCount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblExcelSheet;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel LblExcelFile;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnImport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnPreview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGuiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDBField;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnExcelTemplates;
    }
}