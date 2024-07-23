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

namespace DoctorERP
{
    public partial class FrmCashRpt : KryptonForm
    {
        DgvFilterManager dgvManager;
        string ReportTitle = string.Empty;


        public FrmCashRpt(string ReportTitle)
        {
            InitializeComponent();


            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;

            dtStartDate.Value = dtStartDate.Value.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay);

            dtEndDate.Value = dtEndDate.Value.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);

            CmbChangeDate.SelectedIndex = 0;


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
            // DataGridMain.AutoGenerateColumns = false;

            if (CmbChangeDate.SelectedIndex == 0)

                vwPaysGrouped.Fill();

            else if (CmbChangeDate.SelectedIndex != 0)


                vwPaysGrouped.Fill(dtStartDate.Value, dtEndDate.Value);


            DataGridMain.DataSource = vwPaysGrouped.dtData;


            SetColumnsFilter(DataGridMain);
        }

        void InitGrid()
        {
            vwPaysGrouped.Fill("Guid", Guid.Empty);
            DataGridMain.DataSource = vwPaysGrouped.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwPaysGrouped));


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

                //tbPayContract pay = tbPayContract.FindBy("Guid", guid);

                //FrmPayContractOne frm = new FrmPayContractOne(pay.guid, false, pay.paymenttype);

                //frm.Show();

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
                    DataGridMain.ContextMenuStrip = null;
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
            decimal general = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "بدون تحديد");
            decimal price = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "قيمة الأرض");
            decimal workfee = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "سعي عمولة الأرض");
            decimal vat = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "ضريبة عمولة السعي");
            decimal discount = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "خصم إستثنائي");

            decimal cash = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "نقدي");
            decimal network = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "شبكة");
            decimal check = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "شيك");
            decimal bank = CalcColumnTotal(DataGridMain, DataGridMain.Columns["amount"], "paytype", "تحويل بنكي");

            ////decimal remain = CalcColumnTotal(DataGridMain, DataGridMain.Columns["remain"]);

            //decimal amountin = CalcColumnTotal(DataGridMain, DataGridMain.Columns["payments"]);
            //decimal remain = CalcColumnTotal(DataGridMain, DataGridMain.Columns["remain"]);
            LblBank.Text = string.Format("البنك {0:" + DataGUIAttribute.CurrencyFormat + "}", bank);
            LblCash.Text = string.Format("النقدي {0:" + DataGUIAttribute.CurrencyFormat + "}", cash);
            LblCheck.Text = string.Format("شيك {0:" + DataGUIAttribute.CurrencyFormat + "}", check);
            LblNetWork.Text = string.Format("شبكة {0:" + DataGUIAttribute.CurrencyFormat + "}", network);


            LblTotal.Text = string.Format("الإجمالي في الصندوق {0:" + DataGUIAttribute.CurrencyFormat + "}", price + general + workfee + vat - discount);
            LblVat.Text = string.Format("ضريبة عمولة السعي {0:" + DataGUIAttribute.CurrencyFormat + "}", vat);
            LblWorkFee.Text = string.Format("سعي عمولة الأرض {0:" + DataGUIAttribute.CurrencyFormat + "}", workfee);
            LblDiscount.Text = string.Format("سند صرف ( خصم إستثنائي ) {0:" + DataGUIAttribute.CurrencyFormat + "}", discount);
            LblGeneral.Text = string.Format("بدون تحديد {0:" + DataGUIAttribute.CurrencyFormat + "}", general);

            //LblBalance.Text = string.Format("المتبقي {0:" + DataGUIAttribute.CurrencyFormat + "}", remain);
        }

        private decimal CalcColumnTotal(DataGridView datagrid, DataGridViewColumn dgvcolumn, string colname, string filter)
        {
            decimal total = 0;
            foreach (DataGridViewRow dr in datagrid.Rows)
            {

                if (dr.Visible)
                {
                    decimal val = 0;
                    decimal.TryParse(dr.Cells[dgvcolumn.Name].Value.ToString(), out val);
                    if (filter.Trim().Length > 0)
                    {
                        if (dr.Cells[colname].Value.ToString().Equals(filter))
                        {
                            total += val;
                        }
                    }
                    else
                    {
                        total += val;
                    }

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


            Reports.InitReport(rpt, "cashrpt.frx", false);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);
            rpt.SetParameterValue("StartDate", dtStartDate.Value);
            rpt.SetParameterValue("EndDate", dtEndDate.Value);

            rpt.RegisterData(dgvManager.mBoundDataView.ToTable(), "data");

            tbAgent.Fill("agenttype", 0);

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");


            //rpt.SetParameterValue("totaltext", ArabicFigures.GetArabicFigure((long)(bank + cash), ArabicFigures.Con));




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

        }

        private void CmbRentState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
