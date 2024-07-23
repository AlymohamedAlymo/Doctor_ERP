using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DgvFilterPopup;
using System.Xml.Serialization;
using System.IO;

namespace DoctorERP
{
    public partial class FrmLandReport : KryptonForm
    {
        DgvFilterManager dgvManager;
        string ReportTitle = string.Empty;


        public FrmLandReport(string ReportTitle)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;
            CmbLandStatus.SelectedIndex = 0;
            DataGridMain.MouseDoubleClick += DataGridMain_MouseDoubleClick;
            DataGridMain.MouseDown += DataGridMain_MouseDown;

            DataGridMain.RowsAdded += DataGridMain_RowsAdded;
            DataGridMain.RowsRemoved += DataGridMain_RowsRemoved;
            BtnDelete.Visible = FrmMain.currentuser.IsAdmin;

        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            InitGrid();
            FillGrid();
        }


        void FillGrid()
        {
            dgvManager.ActivateAllFilters(false);
            // DataGridMain.AutoGenerateColumns = false;

            if (CmbLandStatus.SelectedIndex == 0)
                vwLand.Fill();
            else
                vwLand.Fill("Status", (object)CmbLandStatus.Text);

            DataGridMain.DataSource = vwLand.dtData;



            SetColumnsFilter(DataGridMain);

            ColorGrid();
        }

        void InitGrid()
        {
            vwLand.Fill("Guid", Guid.Empty);
            DataGridMain.DataSource = vwLand.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwLand));


            dgvManager = new DgvFilterManager(DataGridMain);

            SetColumnsFilter(DataGridMain);

            CalcTotal();

            DataGridColumns.SetCustomView(DataGridMain, ReportTitle);


        }



        #region DataGrid Keys
        private void DataGridMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Guid guid = (Guid)DataGridMain["guid", DataGridMain.CurrentRow.Index].Value;
                vwLand mat = vwLand.FindBy("Guid", guid);
                FrmLand frmtable = new FrmLand(guid, false, string.Empty);
                frmtable.ShowDialog();
            }
            catch
            {

            }
        }

        private void DataGridMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridView.HitTestInfo hit = DataGridMain.HitTest(e.X, e.Y);
                    DataGridMain.CurrentCell = DataGridMain[hit.ColumnIndex, hit.RowIndex];
                }
            }
            catch
            {

            }
        }


        void DataGridMain_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcTotal();
        }

        void DataGridMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcTotal();
        }
        #endregion

        private void CalcTotal()
        {
            int sold = vwLand.lstData.Where(x => x.status == "مباع").Count();
            int remain = vwLand.lstData.Where(x => x.status == "متاح").Count();
            int reserv = vwLand.lstData.Where(x => x.status == "محجوز").Count();

            //decimal amountin = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amountin"]);
            //decimal amountout = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amountout"]);
            LblSold.Text = string.Format("المباع {0:" + DataGUIAttribute.QtyFormat + "}", sold);
            LblRemain.Text = string.Format("المتبقي {0:" + DataGUIAttribute.QtyFormat + "}", remain);
            LblReseve.Text = string.Format("محجوز {0:" + DataGUIAttribute.QtyFormat + "}", reserv);
        }

        private decimal CalcColumnTotal(DataGridView datagrid, DataGridViewColumn dgvcolumn)
        {
            decimal total = 0;
            foreach (DataGridViewRow dr in datagrid.Rows)
            {
                if (dr.Visible)
                {
                    decimal val = 0;
                    decimal.TryParse(dr.Cells[dgvcolumn.Name].Value.ToString(), out val);
                    total += val;
                }
            }
            return total;

        }

        #region Custom View
        void SetColumnsFilter(DataGridView datagridview)
        {
            foreach (DataGridViewColumn datacolumn in DataGridMain.Columns)
            {
                if (datacolumn.ValueType.Equals(typeof(Int32)))
                    dgvManager[datacolumn.Name] = new DgvNumRangeColumnFilter();

                if (datacolumn.ValueType.Equals(typeof(Double)))
                    dgvManager[datacolumn.Name] = new DgvNumRangeColumnFilter();

                if (datacolumn.ValueType.Equals(typeof(DateTime)))
                    dgvManager[datacolumn.Name] = new DgvDateRangeColumnFilter();

                if (datacolumn.ValueType.Equals(typeof(String)))
                    dgvManager[datacolumn.Name] = new DgvTextBoxColumnFilter();
            }
        }

        private void MenuExportToExcel_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanPrint)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ExcelXLSX.ExportToExcel(DataGridMain);
        }

        private void MenuCustomView_Click(object sender, EventArgs e)
        {
            dgvManager.ActivateAllFilters(false);

            FrmCustomView frmcustomview = new FrmCustomView(ReportTitle, DataGridMain);
            if (frmcustomview.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                DataGridColumns.SetCustomView(DataGridMain, ReportTitle);
            else
                this.Close();
        }
        #endregion

        #region search Field
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SearchGrid(TxtSearch.Text);
            else if (e.KeyData == Keys.Delete)
            {
                TxtSearch.Text = string.Empty;
                SearchGrid(string.Empty);
            }
        }

        void SearchGrid(string SearchValue)
        {
            foreach (DataGridViewRow row in DataGridMain.Rows)
            {
                row.Visible = true;
            }

            if (SearchValue.Trim().Length <= 0)
            {
                CalcTotal();
                return;
            }

            foreach (DataGridViewRow row in DataGridMain.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (DataGridMain.Columns[cell.ColumnIndex].Visible)
                    {
                        string cellvalue = cell.Value.ToString();
                        if (cellvalue.Trim().ToLower().Contains(SearchValue.Trim().ToLower()))
                        {
                            row.Visible = true;
                            break;
                        }
                        else
                        {
                            CurrencyManager cm = (CurrencyManager)BindingContext[DataGridMain.DataSource];
                            cm.SuspendBinding();
                            row.Visible = false;
                            cm.ResumeBinding();
                        }
                    }
                }
            }
            CalcTotal();
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
            SearchGrid(string.Empty);
        }
        #endregion

        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            // Reports.GenerateReport(ReportTitle, DataGridMain, dgvManager.mBoundDataView.ToTable());

            Reports.InitReport(rpt, "landrpt.frx", false);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.RegisterData(dgvManager.mBoundDataView.ToTable(), "data");

            return true;
        }

        private void MenuDesign_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                Reports.DesignReport(report);
        }

        private void MenuPreview_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                report.Show();
        }

        private void MenuPrint_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                report.Print();
        }

        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {

            DataGridColumns.SetCustomView(DataGridMain, ReportTitle);
        }

        private void CmbLandStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLandStatus.Focused)
                FillGrid();
        }

        private void ColorGrid()
        {
            for (int iRow = 0; iRow < DataGridMain.RowCount; iRow++)
            {
                string status = DataGridMain["status", iRow].Value.ToString();

                if (status.Equals("مباع"))
                {
                    DataGridMain.Rows[iRow].DefaultCellStyle.BackColor = Color.Pink;

                }
                else if (status.Equals("متاح"))
                {
                    DataGridMain.Rows[iRow].DefaultCellStyle.BackColor = Color.White;

                }
                else if (status.Equals("محجوز"))
                {
                    DataGridMain.Rows[iRow].DefaultCellStyle.BackColor = Color.Yellow;

                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("هل أنت متأكد من حذف الأصناف المحددة، سوف يتم تجاهل الأصناف المستخدمة في العقود بشكل تلقائي ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            List<Guid> lstGuid = new List<Guid>();
            for (int i = 0; i < DataGridMain.SelectedRows.Count; i++)
            {
                Guid landguid = new Guid(DataGridMain.SelectedRows[i].Cells["guid"].Value.ToString());
                lstGuid.Add(landguid);
            }

            foreach (Guid item in lstGuid)
            {
                if (!tbBillBody.IsExist("LandGuid", item))
                {
                    tbLand land = new tbLand();
                    DBConnect.StartTransAction();
                    land.DeleteBy("guid", item);
                    DBConnect.CommitTransAction();
                }
            }

            FrmConfirm frm = new FrmConfirm();
            frm.ShowDialog();

            this.Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
