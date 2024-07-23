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
using FastReport.Data;
using NumberToWord;

namespace DoctorERP
{
    public partial class FrmDailyReturnSellGrouped : KryptonForm
    {
        DgvFilterManager dgvManager;
        string ReportTitle = string.Empty;


        public FrmDailyReturnSellGrouped(string ReportTitle)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;

            dtEndDate.Value = dtEndDate.Value.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
            dtStartDate.Value = dtStartDate.Value.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay);

            CmbChangeDate.SelectedIndex = 0;
            //  CmbRentState.SelectedIndex = 0;

            DataGridMain.MouseDoubleClick += DataGridMain_MouseDoubleClick;
            DataGridMain.MouseDown += DataGridMain_MouseDown;

            DataGridMain.RowsAdded += DataGridMain_RowsAdded;
            DataGridMain.RowsRemoved += DataGridMain_RowsRemoved;

        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            InitGrid();
            FillGrid();
        }


        void FillGrid()
        {
            dgvManager.ActivateAllFilters(false);
            //DataGridMain.AutoGenerateColumns = false;

            if (CmbChangeDate.SelectedIndex == 0)
                vwDailySalesGrouped.Fill("مرتجع");
            else
                vwDailySalesGrouped.Fill("مرتجع", dtStartDate.Value, dtEndDate.Value);
            DataGridMain.DataSource = vwDailySalesGrouped.dtData;


            SetColumnsFilter(DataGridMain);
        }

        void InitGrid()
        {
            vwDailySalesGrouped.Fill("مرتجع", new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));
            DataGridMain.DataSource = vwDailySalesGrouped.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwDailySalesGrouped));


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
                //Guid guid = (Guid)DataGridMain["guid", DataGridMain.CurrentRow.Index].Value;
                //tbSellBill mat = tbSellBill.FindBy("Guid", guid);
                //FrmSellBill frm = new FrmSellBill(guid, false);
                //frm.ShowDialog();
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
                    //DataGridMain.ContextMenuStrip = contextMenuStrip1;
                }
            }
            catch
            {
                DataGridMain.ContextMenuStrip = null;
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
            decimal bank = CalcColumnTotal(DataGridMain, DataGridMain.Columns["bank"]);
            decimal cash = CalcColumnTotal(DataGridMain, DataGridMain.Columns["cash"]);
            LblTotal.Text = string.Format("الإجمالي {0:" + DataGUIAttribute.CurrencyFormat + "}", bank + cash);
            LblBank.Text = string.Format("البنك {0:" + DataGUIAttribute.CurrencyFormat + "}", bank);
            LblCash.Text = string.Format("النقدي {0:" + DataGUIAttribute.CurrencyFormat + "}", cash);

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
            //Reports.GenerateReport(ReportTitle, DataGridMain, dgvManager.mBoundDataView.ToTable());

            Reports.InitReport(rpt, "dailyreturnsellgrouped.frx", false);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.SetParameterValue("StartDate", dtStartDate.Value);
            rpt.SetParameterValue("EndDate", dtEndDate.Value);

            tbAgent.Fill("agenttype", 0);

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");

            decimal bank = CalcColumnTotal(DataGridMain, DataGridMain.Columns["bank"]);
            decimal cash = CalcColumnTotal(DataGridMain, DataGridMain.Columns["cash"]);


            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord((bank + cash), currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = (bank + cash);

            rpt.SetParameterValue("totaltext", toWord.ConvertToArabic());


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

        private void CmbChangeDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CmbChangeDate.Focused)
                return;

            dtStartDate.Value = DateTime.Now.Date;
            if (CmbChangeDate.SelectedIndex == 0)
            {
                dtStartDate.Enabled = dtEndDate.Enabled = false;
            }
            if (CmbChangeDate.SelectedIndex == 1)
            {
                dtEndDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
                dtStartDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay);
                dtStartDate.Enabled = dtEndDate.Enabled = true;

            }
            else if (CmbChangeDate.SelectedIndex == 2)
            {
                dtEndDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
                dtStartDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay).AddDays(-7);
                dtStartDate.Enabled = dtEndDate.Enabled = true;

            }
            else if (CmbChangeDate.SelectedIndex == 3)
            {
                dtEndDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
                dtStartDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay).AddMonths(-1);
                dtStartDate.Enabled = dtEndDate.Enabled = true;

            }
            else if (CmbChangeDate.SelectedIndex == 4)
            {
                dtEndDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
                dtStartDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay).AddMonths(-3);
                dtStartDate.Enabled = dtEndDate.Enabled = true;

            }
            else if (CmbChangeDate.SelectedIndex == 5)
            {
                dtEndDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
                dtStartDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay).AddMonths(-6);
                dtStartDate.Enabled = dtEndDate.Enabled = true;
            }
            else if (CmbChangeDate.SelectedIndex == 6)
            {
                dtEndDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
                dtStartDate.Value = DateTime.Now.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay).AddYears(-1);
                dtStartDate.Enabled = dtEndDate.Enabled = true;

            }

            FillGrid();
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtStartDate.Focused)
                FillGrid();
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtEndDate.Focused)
                FillGrid();
        }

        private void MenuRetrunBill_Click(object sender, EventArgs e)
        {
            Guid guid = (Guid)DataGridMain["guid", DataGridMain.CurrentRow.Index].Value;
            tbBillheader bill = tbBillheader.FindBy("Guid", guid);
            FrmBillHeader frm = new FrmBillHeader(guid, false, bill.billtype, new List<tbLand>());
            frm.Show();
        }

        private void CmbRentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(CmbRentState.Focused)
            //{
            //    FillGrid();
            //}
        }

        private void MenuPay_Click(object sender, EventArgs e)
        {
            Guid guid = (Guid)DataGridMain["payguid", DataGridMain.CurrentRow.Index].Value;
            tbPayContract bill = tbPayContract.FindBy("Guid", guid);
            if (bill.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("لا يوجد سندات قبض للعقد المحدد", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                FrmPayContractOne frm = new FrmPayContractOne(guid, false, bill.paymenttype);
                frm.Show();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
