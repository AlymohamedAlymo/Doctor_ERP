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
    public partial class FrmLandImport : KryptonForm
    {

        DataGridViewComboBoxColumn colExcel = new DataGridViewComboBoxColumn();
        string[] ExFileds = { "number", "guid", "discounttotalvalue", "reservereason", "discounttotal", "isdiscounttotal", "discountfeevalue", "discountfee", "isdiscountfee", "status", "isvat", "isworkfee", "isbuildingfee", "issalefee", "total" };

        public FrmLandImport()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);



            tbLand obj = new tbLand();
            DataTable tbColumnsRows = new DataTable();
            tbColumnsRows.Columns.Add("GuiName", typeof(string));
            tbColumnsRows.Columns.Add("DbField", typeof(string));

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string GuiName = DataGUIAttribute.GetAttributeValue(typeof(tbLand), prop.Name, DataGUIAttribute.AttributeName.GUIName).ToString();

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


        decimal CalcTotal(decimal amount, decimal salesfee, decimal buildingfee, decimal workfee, decimal vatfee, decimal discountotal, decimal discountfee)
        {

            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            return total;


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

            if (MessageBox.Show(("سوف يتم تجاهل رموز الأصناف المكررة هل تريد المتابعة ؟"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbLand.Fill();

            tbTaxDiscount.Fill();






            DBConnect.StartTransAction();
            foreach (DataGridViewRow item in DataGridMain.Rows)
            {
                tbLand land = new tbLand();

                land.guid = Guid.NewGuid();


                try
                {
                    int code;
                    int.TryParse(item.Cells["code"].Value.ToString(), out code);
                    land.code = code;
                }
                catch
                {
                    land.code = 0;
                }

                try
                {
                    int blocknumber;
                    int.TryParse(item.Cells["blocknumber"].Value.ToString(), out blocknumber);
                    land.blocknumber = blocknumber;
                }
                catch
                {
                    land.blocknumber = 0;
                }


                decimal area;
                try
                {
                    decimal.TryParse(item.Cells["area"].Value.ToString(), out area);
                    land.area = area;
                }
                catch
                {
                    land.area = 0;
                }

                try
                {
                    land.deednumber = item.Cells["deednumber"].Value.ToString();
                }
                catch
                {
                    land.deednumber = string.Empty;
                }

                decimal amount = 0;
                try
                {
                    decimal.TryParse(item.Cells["amount"].Value.ToString(), out amount);
                    land.amount = amount;
                }
                catch
                {
                    land.amount = 0;
                }








                try
                {
                    land.landtype = item.Cells["landtype"].Value.ToString();
                }
                catch
                {
                    land.landtype = string.Empty;
                }


                try
                {
                    land.south = item.Cells["south"].Value.ToString();
                }
                catch
                {
                    land.south = string.Empty;
                }

                try
                {
                    land.southdesc = item.Cells["southdesc"].Value.ToString();
                }
                catch
                {
                    land.southdesc = string.Empty;
                }

                try
                {
                    land.north = item.Cells["north"].Value.ToString();
                }
                catch
                {
                    land.north = string.Empty;
                }

                try
                {
                    land.northdesc = item.Cells["northdesc"].Value.ToString();
                }
                catch
                {
                    land.northdesc = string.Empty;
                }

                try
                {
                    land.west = item.Cells["west"].Value.ToString();
                }
                catch
                {
                    land.west = string.Empty;
                }


                try
                {
                    land.westdesc = item.Cells["westdesc"].Value.ToString();
                }
                catch
                {
                    land.westdesc = string.Empty;
                }

                try
                {
                    land.east = item.Cells["east"].Value.ToString();
                }
                catch
                {
                    land.east = string.Empty;
                }

                try
                {
                    land.eastdesc = item.Cells["eastdesc"].Value.ToString();
                }
                catch
                {
                    land.eastdesc = string.Empty;
                }


                try
                {
                    land.note = item.Cells["note"].Value.ToString();
                }
                catch
                {
                    land.note = string.Empty;
                }
                try
                {
                    land.landtype = item.Cells["landtype"].Value.ToString();
                }
                catch
                {
                    land.landtype = "غير مصنف";
                }

                if (land.landtype.Trim() == string.Empty)
                {
                    land.landtype = "غير مصنف";
                }

                land.reservereason = string.Empty;

                if (tbTaxDiscount.lstData.Count > 0)
                {
                    tbTaxDiscount taxdiscount = tbTaxDiscount.lstData[0];

                    land.isbuildingfee = taxdiscount.isbuildingfee;
                    land.buildingfee = taxdiscount.buildingfee;
                    land.isdiscountfee = taxdiscount.isdiscountfee;
                    land.discountfee = taxdiscount.discountfee;
                    land.discountfeevalue = taxdiscount.discountfeevalue;
                    land.isdiscounttotal = taxdiscount.isdiscounttotal;
                    land.discounttotal = taxdiscount.discounttotal;
                    land.discounttotalvalue = taxdiscount.discounttotalvalue;
                    land.isvat = taxdiscount.isvat;
                    land.vat = taxdiscount.vat;
                    land.isworkfee = taxdiscount.isworkfee;
                    land.workfee = taxdiscount.workfee;
                    land.issalefee = taxdiscount.issalefee;
                    land.salesfee = taxdiscount.salesfee;

                }

                land.status = "متاح";
                land.total = CalcTotal(amount, land.salesfee, land.buildingfee, land.workfee, land.vat, 0, 0);

                land.number = land.code;



                land.Insert();



            }






            if (DBConnect.CommitTransAction())
            {
                FrmConfirm con = new FrmConfirm();
                con.ShowDialog();
                this.Close();
            }
        }

        decimal CalcTotal(decimal amount, decimal salesfee, decimal buildingfee, decimal workfee, decimal vatfee)
        {

            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            return total;

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





            if (!IsColExist("deednumber", DataGridMain))
            {
                MessageBox.Show(("لم يتم إختيار عمود رقم الصك سوف يتم تجاهل الأصناف التي بدون رقم صك"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                Process.Start(AppSetting.GetAppPath() + "\\excel-files\\land.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
