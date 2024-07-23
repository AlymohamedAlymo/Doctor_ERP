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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoctorERP
{
    public partial class FrmAgentStatment : KryptonForm
    {
        DgvFilterManager dgvManager;
        string ReportTitle = string.Empty;


        public FrmAgentStatment(string ReportTitle)
        {
            InitializeComponent();

            TxtSelect.Tag = new vwContractInfo();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;

            dtEndDate.Value = dtEndDate.Value.Date.Add(DateTimeHelper.GetEndTimeOfDay().TimeOfDay);
            dtStartDate.Value = dtStartDate.Value.Date.Add(DateTimeHelper.GetFirstTimeOfDay().TimeOfDay);

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

            vwContractInfo acc = (vwContractInfo)TxtSelect.Tag;

            if (CmbChangeDate.SelectedIndex == 0 && acc.buyerguid.Equals(Guid.Empty))
                vwAgentStatement.Fill();
            else if (CmbChangeDate.SelectedIndex == 0 && !acc.buyerguid.Equals(Guid.Empty))
                vwAgentStatement.Fill("buyerguid", acc.buyerguid);
            else if (CmbChangeDate.SelectedIndex != 0 && acc.buyerguid.Equals(Guid.Empty))
                vwAgentStatement.Fill(dtStartDate.Value, dtEndDate.Value);
            else if (CmbChangeDate.SelectedIndex != 0 && !acc.buyerguid.Equals(Guid.Empty))
                vwAgentStatement.Fill(acc.buyerguid, dtStartDate.Value, dtEndDate.Value);
            DataGridMain.DataSource = vwAgentStatement.dtData;


            SetColumnsFilter(DataGridMain);
        }

        void InitGrid()
        {
            vwAgentStatement.Fill("Guid", Guid.Empty);
            DataGridMain.DataSource = vwAgentStatement.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwAgentStatement));


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

                FrmBillHeader frm = new FrmBillHeader(guid, false, 0, new List<tbLand>());

                frm.Show();

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

            decimal totalnet = CalcColumnTotal(DataGridMain, DataGridMain.Columns["totalnet"]);
            decimal payments = CalcColumnTotal(DataGridMain, DataGridMain.Columns["payments"]);
            decimal remain = CalcColumnTotal(DataGridMain, DataGridMain.Columns["remain"]);

            LblAmountIn.Text = string.Format("القيمة {0:" + DataGUIAttribute.CurrencyFormat + "}", totalnet);
            LblAmountOut.Text = string.Format("المدفوع {0:" + DataGUIAttribute.CurrencyFormat + "}", payments);
            LblBalance.Text = string.Format("المتبقي {0:" + DataGUIAttribute.CurrencyFormat + "}", remain);
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

            vwContractInfo acc = (vwContractInfo)TxtSelect.Tag;

            tbAgent.Fill("Guid", acc.buyerguid);

            Reports.InitReport(rpt, "agentpayments.frx", false);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);
            rpt.SetParameterValue("StartDate", dtStartDate.Value);
            rpt.SetParameterValue("EndDate", dtEndDate.Value);

            tbAgent.Fill("Guid", acc.guid);
            rpt.RegisterData(tbAgent.dtData, "agentdata");

            tbAgent.Fill("agenttype", 0);

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");

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


        #region Select
        private void TxtSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vwContractInfo selectedobject = new vwContractInfo();


                vwContractInfo.Fill(TxtSelect.Text, "مباع");
                if (vwContractInfo.dtData.Rows.Count == 1)
                {
                    selectedobject = vwContractInfo.FindBy("guid", (Guid)vwContractInfo.dtData.Rows[0]["guid"]);
                    TxtSelect.Tag = selectedobject;
                    TxtSelect.Text = selectedobject.contractno.ToString() + "-" + selectedobject.land;
                    FillGrid();
                }
                else if (vwContractInfo.dtData.Rows.Count == 0)
                {
                    vwContractInfo.Fill(" ", "مباع");
                    ShowSelect();
                }
                else
                {
                    ShowSelect();
                }


                if (selectedobject.status == "مرتجع")
                {
                    MessageBox.Show("لا يمكن عمل دفع على العقد المرتجع", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtSelect.Text = string.Empty;
                    TxtSelect.Tag = new vwContractInfo();
                    return;
                }

            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelect.Tag = new vwContractInfo();
                TxtSelect.Text = string.Empty;
                FillGrid();
            }
        }

        private void ShowSelect()
        {
            FrmSelect frmselect = new FrmSelect("إختيار عقد", typeof(vwContractInfo), vwContractInfo.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vwContractInfo selectedobject = vwContractInfo.FindBy("guid", frmselect.guid);
                TxtSelect.Tag = selectedobject;
                TxtSelect.Text = selectedobject.contractno.ToString() + "-" + selectedobject.land;
                FillGrid();

            }
            else
            {
                TxtSelect.Tag = new vwContractInfo();
                TxtSelect.Text = string.Empty;
                FillGrid();
            }
        }


        private void BtnShowCard_Click(object sender, EventArgs e)
        {
            //tbAccount selectedobject = (tbAccount)TxtSelect.Tag;
            //if (!selectedobject.guid.Equals(Guid.Empty))
            //{
            //    FrmAccount frmtable = new FrmAccount(selectedobject.guid, false, false);
            //    frmtable.ShowDialog();
            //}
        }

        private void BtnSeacrh_Click(object sender, EventArgs e)
        {
            TxtSelect_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }


        #endregion

        //#region Select Acc
        //private void TxtSelect_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        tbAgent.Fill("Name", TxtSelect.Text, 1);
        //        if (tbAgent.dtData.Rows.Count == 1)
        //        {
        //            tbAgent selectedobject = tbAgent.FindBy("guid", (Guid)tbAgent.dtData.Rows[0]["guid"]);
        //            TxtSelect.Tag = selectedobject;
        //            TxtSelect.Text = selectedobject.name;
        //        }
        //        else if (tbAgent.dtData.Rows.Count == 0)
        //        {
        //            tbAgent.Fill("Name", " ", 1);
        //            ShowSelect();
        //        }
        //        else
        //        {
        //            ShowSelect();
        //        }
        //        FillGrid();
        //    }
        //    else if (e.KeyCode == Keys.Delete)
        //    {
        //        TxtSelect.Tag = new tbAgent();
        //        TxtSelect.Text = string.Empty;
        //        FillGrid();
        //    }
        //}

        //private void ShowSelect()
        //{
        //    FrmSelect frmselect = new FrmSelect("إختيار عميل", typeof(tbAgent), tbAgent.dtData);

        //    if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        tbAgent selectedobject = tbAgent.FindBy("guid", frmselect.guid);
        //        TxtSelect.Tag = selectedobject;
        //        TxtSelect.Text = selectedobject.name;
        //    }
        //    else
        //    {
        //        TxtSelect.Tag = new tbAgent();
        //        TxtSelect.Text = string.Empty;

        //    }
        //}


        //private void BtnShowCard_Click(object sender, EventArgs e)
        //{
        //    tbAgent selectedobject = (tbAgent)TxtSelect.Tag;
        //    if (!selectedobject.guid.Equals(Guid.Empty))
        //    {
        //        FrmAccount frmtable = new FrmAccount(selectedobject.guid, false, false);
        //        frmtable.ShowDialog();
        //    }
        //}

        //private void BtnSeacrh_Click(object sender, EventArgs e)
        //{
        //    TxtSelect_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        //}
        //#endregion


    }
}
