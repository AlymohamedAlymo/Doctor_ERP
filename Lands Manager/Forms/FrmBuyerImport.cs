using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
using OfficeOpenXml;

namespace DoctorERP
{
    public partial class FrmBuyerImport : KryptonForm
    {

        DataGridViewComboBoxColumn colExcel = new DataGridViewComboBoxColumn();
        string[] ExFileds = { "guid", "officename", "officecr", "officephone", "officeemail", "officevatid", "officepublicnumber", "agenttype" };

        public FrmBuyerImport()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);



            tbAgent obj = new tbAgent();
            DataTable tbColumnsRows = new DataTable();
            tbColumnsRows.Columns.Add("GuiName", typeof(string));
            tbColumnsRows.Columns.Add("DbField", typeof(string));

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string GuiName = DataGUIAttribute.GetAttributeValue(typeof(tbAgent), prop.Name, DataGUIAttribute.AttributeName.GUIName).ToString();

                if (!ExFileds.Contains(prop.Name.ToLower()))
                    tbColumnsRows.Rows.Add((GuiName), prop.Name);
            }



            DataGridColumns.DataSource = tbColumnsRows;

            colExcel = new DataGridViewComboBoxColumn();
            colExcel.HeaderText = "العمود المقابل في ملف الإكسل";
            colExcel.DropDownWidth = 200;
            colExcel.Width = 200;
            colExcel.MaxDropDownItems = 5;
            colExcel.Name = "colexcel";
            DataGridColumns.Columns.Add(colExcel);
            DataGridColumns.Columns["colexcel"].DataPropertyName = "excel";
            DataGridMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            LblRowsCount.Text = string.Format("{0} {1}", ("عدد الأسطر"), 0);
        }

        private void AddExcelColumnsToGrid()
        {
            colExcel.Items.Clear();
            colExcel.Items.Add("-");
            InitExcelSheetColumnsHeader();

            foreach (var item in LstexcelCols)
            {
                colExcel.Items.Add(item.name);

            }



        }





        private void BtnSelectExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Select Excel 2010 - 2017";
            opf.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                TxtSelectExcelFile.Text = opf.FileName;
                EnumExcelSheets(opf.FileName);
            }
        }

        ExcelPackage package = new ExcelPackage();
        private void EnumExcelSheets(string ExcelFile)
        {
            package = new ExcelPackage(new FileInfo(ExcelFile));

            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            CmbSheets.Items.Clear();
            foreach (ExcelWorksheet item in package.Workbook.Worksheets)
            {
                CmbSheets.Items.Add(item.Name);
            }

            if (CmbSheets.Items.Count > 0)
                CmbSheets.SelectedIndex = 0;

        }

        private void CmbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetWorkBookInfo(package.Workbook.Worksheets[CmbSheets.SelectedIndex + 1]);

            foreach (DataGridViewRow item in DataGridColumns.Rows)
            {
                item.Cells[colExcel.Name].Value = item.Cells[ColGuiName.Name].Value.ToString();
            }
        }

        List<ExcelColumns> LstexcelCols = new List<ExcelColumns>();
        void InitExcelSheetColumnsHeader()
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[CmbSheets.SelectedIndex + 1];
            LstexcelCols = new List<ExcelColumns>();
            foreach (var startRowCell in worksheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, 1, worksheet.Dimension.End.Column])
            {
                ExcelColumns exCol = new ExcelColumns();
                exCol.address = startRowCell.Address;
                exCol.name = startRowCell.Text;
                exCol.colIndex = GetColumnByName(exCol.name);
                if (exCol.colIndex > -1)
                    LstexcelCols.Add(exCol);
            }
        }

        public int GetColumnByName(string columnName)
        {
            try
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[CmbSheets.SelectedIndex + 1];
                if (worksheet == null) throw new ArgumentNullException(nameof(worksheet));
                return worksheet.Cells["1:1"].First(c => c.Value.ToString() == columnName).Start.Column;
            }
            catch
            {
                return -1;
            }
        }

        private void GetWorkBookInfo(ExcelWorksheet worksheet)
        {
            AddExcelColumnsToGrid();
            LblRowsCount.Text = string.Format("{0} {1}", ("عدد الأسطر"), worksheet.Dimension.End.Row);

            LoadRowstoDataTable(TxtSelectExcelFile.Text);
        }

        DataTable datatable = new DataTable();
        private bool LoadRowstoDataTable(string filename)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                try
                {
                    using (var stream = File.OpenRead(filename))
                    {

                        pck.Load(stream);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                var ws = pck.Workbook.Worksheets[CmbSheets.SelectedIndex + 1];
                datatable = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    datatable.Columns.Add(true ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }

                var startRow = true ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {

                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = datatable.Rows.Add();
                    try
                    {
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;

        }

        private void BtnImport_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show(("سوف يتم تجاهل رموز العملاء المكررة هل تريد المتابعة ؟"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbAgent.Fill();

            DBConnect.StartTransAction();
            foreach (DataGridViewRow item in DataGridMain.Rows)
            {
                tbAgent acc = new tbAgent();

                acc.guid = Guid.NewGuid();




                try
                {
                    acc.name = item.Cells["name"].Value.ToString();

                }
                catch
                {
                    acc.name = string.Empty;
                }

                try
                {
                    acc.civilid = item.Cells["civilid"].Value.ToString();

                }
                catch
                {
                    acc.civilid = string.Empty;
                }



                try
                {
                    acc.mobile = item.Cells["Mobile"].Value.ToString();

                }
                catch
                {
                    acc.mobile = string.Empty;
                }

                try
                {
                    acc.email = item.Cells["email"].Value.ToString();

                }
                catch
                {
                    acc.email = string.Empty;
                }



                try
                {
                    acc.vatid = item.Cells["vatid"].Value.ToString();

                }
                catch
                {
                    acc.vatid = string.Empty;
                }

                try
                {
                    acc.publicnumber = item.Cells["publicnumber"].Value.ToString();

                }
                catch
                {
                    acc.publicnumber = string.Empty;
                }

                try
                {
                    acc.note = item.Cells["Note"].Value.ToString();

                }
                catch
                {
                    acc.note = String.Empty;
                }

                try
                {
                    acc.agentname = item.Cells["agentname"].Value.ToString();

                }
                catch
                {
                    acc.agentname = string.Empty;
                }

                try
                {
                    acc.agentcivilid = item.Cells["agentcivilid"].Value.ToString();

                }
                catch
                {
                    acc.agentcivilid = string.Empty;
                }


                try
                {
                    acc.agentmobile = item.Cells["agentmobile"].Value.ToString();

                }
                catch
                {
                    acc.agentmobile = string.Empty;
                }

                try
                {
                    acc.agentemail = item.Cells["agentemail"].Value.ToString();

                }
                catch
                {
                    acc.agentemail = string.Empty;
                }

                try
                {
                    acc.agentvatid = item.Cells["agentvatid"].Value.ToString();

                }
                catch
                {
                    acc.agentvatid = string.Empty;
                }

                try
                {
                    acc.agencynumber = item.Cells["agencynumber"].Value.ToString();

                }
                catch
                {
                    acc.agencynumber = string.Empty;
                }


                try
                {
                    acc.agentpublicnumber = item.Cells["agentpublicnumber"].Value.ToString();

                }
                catch
                {
                    acc.agentpublicnumber = string.Empty;
                }

                acc.officecr = string.Empty;
                acc.officeemail = string.Empty;
                acc.officename = string.Empty;
                acc.officephone = string.Empty;
                acc.officepublicnumber = string.Empty;
                acc.officevatid = string.Empty;

                acc.agenttype = 1;
                


                if (!acc.name.Trim().Equals(string.Empty))
                {
                    acc.number = tbAgent.GetMaxNumberTrans("Number", acc.agenttype) + 1;
                    acc.Insert();
                }

            }



            if (DBConnect.CommitTransAction())
            {
                FrmConfirm con = new FrmConfirm();
                con.ShowDialog();
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
            base.OnFormClosing(e);
        }



        private void BtnPreview_Click(object sender, EventArgs e)
        {
            LoadRowstoDataTable(TxtSelectExcelFile.Text);

            DataGridMain.Columns.Clear();

            foreach (DataGridViewRow item in DataGridColumns.Rows)
            {
                try
                {
                    DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
                    Col.ValueType = typeof(String);
                    Col.HeaderText = item.Cells[ColGuiName.Name].Value.ToString();
                    Col.Name = item.Cells[ColDBField.Name].Value.ToString();
                    Col.DataPropertyName = item.Cells[colExcel.Name].Value.ToString();
                    Col.Tag = "data";
                    if (!Col.DataPropertyName.Equals("-"))
                        DataGridMain.Columns.Add(Col);

                }
                catch
                {

                }
            }

            DataGridMain.DataSource = datatable;

            List<string> RemoveCols = new List<string>();
            for (int i = 0; i < DataGridMain.Columns.Count; i++)
            {
                try
                {
                    if (!DataGridMain.Columns[i].Tag.ToString().Equals("data"))
                    {
                        RemoveCols.Add(DataGridMain.Columns[i].DataPropertyName);
                    }
                }
                catch
                {
                    RemoveCols.Add(DataGridMain.Columns[i].DataPropertyName);
                }
            }

            foreach (string item in RemoveCols)
            {
                datatable.Columns.Remove(item);
            }

            DataGridMain.DataSource = datatable;

          
        }

        private bool IsColExist(string colname, DataGridView dgvw)
        {
            foreach (DataGridViewColumn item in DataGridMain.Columns)
            {
                if (item.Name.ToLower().Equals(colname.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        private void DataGridColumns_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!DataGridColumns.Columns[e.ColumnIndex].Name.Equals(colExcel.Name))
            {
                e.Cancel = true;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {



        }

        private void BtnExcelTemplates_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(AppSetting.GetAppPath() + "\\excel-files\\buyer.xlsx");
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
