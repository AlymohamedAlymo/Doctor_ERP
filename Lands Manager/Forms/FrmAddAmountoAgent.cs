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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Diagnostics.Contracts;
using FastReport;
using NumberToWord;

namespace DoctorERP
{
    public partial class FrmAddAmountoAgent : KryptonForm
    {
        DgvFilterManager dgvManager;
        string ReportTitle = string.Empty;


        public FrmAddAmountoAgent(string ReportTitle)
        {
            InitializeComponent();

            tbPaymentsNotes.Fill();

            TxtSelect.Tag = new tbAgent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;

            CmbPayType.SelectedIndex = 0;

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

            tbAgent acc = (tbAgent)TxtSelect.Tag;


            vwAddAmountToAgentStatement.Fill("buyerguid", acc.guid);

            DataGridMain.DataSource = vwAddAmountToAgentStatement.dtData;


            SetColumnsFilter(DataGridMain);
        }

        void InitGrid()
        {
            vwAddAmountToAgentStatement.Fill("Guid", Guid.Empty);
            DataGridMain.DataSource = vwAddAmountToAgentStatement.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwAddAmountToAgentStatement));


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

                FrmBillHeader frm = new FrmBillHeader(Guid.Empty, false, 0 , new  List<tbLand>());

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

        decimal totalnet;
        decimal payments;
        decimal remain;
        private void CalcTotal()
        {

            totalnet = CalcColumnTotal(DataGridMain, DataGridMain.Columns["totalnet"]);
            payments = CalcColumnTotal(DataGridMain, DataGridMain.Columns["payments"]);
            remain = CalcColumnTotal(DataGridMain, DataGridMain.Columns["remain"]);

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


        #region report and print
        private void Readyreport(Guid PayGuid, FastReport.Report rpt)
        {
            tbPayContract pay = tbPayContract.FindBy("Guid", PayGuid);

            Reports.InitReport(rpt, "paycontract.frx", false);
            tbPayContract.Fill(pay.guid);


            DataTable tbCash = new DataTable();
            tbCash.Columns.Add("name", typeof(string));
            tbCash.Columns.Add("val", typeof(bool));

            DataTable tbBank = new DataTable();
            tbBank.Columns.Add("name", typeof(string));
            tbBank.Columns.Add("val", typeof(bool));

            DataTable tbTrans = new DataTable();
            tbTrans.Columns.Add("name", typeof(string));
            tbTrans.Columns.Add("val", typeof(bool));


            bool IsCash = false;
            bool IsBank = false;
            bool IsTrans = false;

            if (pay.paytype == "نقدي" || pay.paytype == "شبكة")
                IsCash = true;

            if (pay.paytype == "شيك")
                IsBank = true;

            if (pay.paytype == "حوالة بنكية")
                IsTrans = true;

            tbCash.Rows.Add("نقدي", IsCash);
            tbBank.Rows.Add("شيك", IsBank);
            tbTrans.Rows.Add("حوالة بنكية", IsTrans);

            rpt.RegisterData(tbCash, "tbCash");
            rpt.RegisterData(tbBank, "tbBank");
            rpt.RegisterData(tbTrans, "tbTrans");

            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(pay.amount, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;

            rpt.SetParameterValue("Tafkeet", toWord.ConvertToArabic());

            rpt.SetParameterValue("HijriDate", DateTimeHelper.ConvertDateCalendar(pay.paydate, "Hijri", "en-US"));

            decimal itotal = Math.Floor(pay.amount);
            decimal ifraction = pay.amount - itotal;

            rpt.SetParameterValue("itotal", itotal);
            rpt.SetParameterValue("ifraction", ifraction);


            vwGetBillBodyStatus billitem = vwGetBillBodyStatus.FindBy("contractno", pay.contractno, 0);
            if (!billitem.guid.Equals(Guid.Empty))
            {

                tbBillheader.Fill("Guid", billitem.parentguid);
                tbLand.Fill("Guid", billitem.landguid);

                if (tbBillheader.lstData.Count > 0)
                {
                    tbAgent.Fill("Guid", tbBillheader.lstData[0].buyerguid);
                }

                try
                {
                    ReportPage page = rpt.Pages.OfType<ReportPage>().First();
                    if (billitem.status == "مرتجع")
                    {

                        page.Watermark.Enabled = true;
                    }
                    else
                    {
                        page.Watermark.Enabled = false;

                    }
                }
                catch
                {

                }
            }

            tbBillBody.Fill("Guid", billitem.guid);
            // tbAccount.Fill("Guid", pay.accountguid);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);
            rpt.RegisterData(tbAgent.dtData, "accdata");
            rpt.RegisterData(tbBillBody.dtData, "billbodydata");
            rpt.RegisterData(tbBillheader.dtData, "billheaderdata");
            rpt.RegisterData(tbLand.dtData, "landdata");

            rpt.RegisterData(tbPayContract.dtData, "data");

            rpt.Prepare(true);
        }

        private void MenuDesign_Click(object sender, EventArgs e)
        {
            //FastReport.Report report = new FastReport.Report();
            //if (Readyreport(report))
            //    Reports.DesignReport(report);
        }

        private void MenuPreview_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            for (int i = 0; i < DataGridMain.RowCount; i++)
            {
                Guid guid = new Guid(DataGridMain.Rows[i].Cells["guid"].Value.ToString());
                decimal addpayments;
                decimal.TryParse(DataGridMain.Rows[i].Cells["addpay"].Value.ToString(), out addpayments);

                tbPayContract pay = tbPayContract.FindBy("Guid", guid);
                if (addpayments > 0 && !pay.guid.Equals(Guid.Empty))
                {
                    Readyreport(guid, report);
                }


            }

            report.ShowPrepared();

        }

        private void MenuPrint_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            for (int i = 0; i < DataGridMain.RowCount; i++)
            {
                Guid guid = new Guid(DataGridMain.Rows[i].Cells["guid"].Value.ToString());
                decimal addpayments;
                decimal.TryParse(DataGridMain.Rows[i].Cells["addpay"].Value.ToString(), out addpayments);

                tbPayContract pay = tbPayContract.FindBy("Guid", guid);
                if(addpayments > 0 && !pay.guid.Equals(Guid.Empty))
                {
                    Readyreport(guid, report);
                }

              

            }
            report.PrintPrepared();
        }

        #endregion



        private void CmbChangeDate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void MenuRetrunBill_Click(object sender, EventArgs e)
        {

        }

        private void CmbRentState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #region Select Acc
        private void TxtSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAgent.Fill("Name", TxtSelect.Text, 1);
                if (tbAgent.dtData.Rows.Count == 1)
                {
                    tbAgent selectedobject = tbAgent.FindBy("guid", (Guid)tbAgent.dtData.Rows[0]["guid"]);
                    TxtSelect.Tag = selectedobject;
                    TxtSelect.Text = selectedobject.name;
                    FillAgentInfo(selectedobject);
                }
                else if (tbAgent.dtData.Rows.Count == 0)
                {
                    tbAgent.Fill("Name", " ", 1);
                    ShowSelect();
                }
                else
                {
                    ShowSelect();
                }
                FillGrid();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelect.Tag = new tbAgent();
                TxtSelect.Text = string.Empty;
                FillAgentInfo(new tbAgent());
                FillGrid();
            }
        }

        private void ShowSelect()
        {
            FrmSelect frmselect = new FrmSelect("إختيار عميل", typeof(tbAgent), tbAgent.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbAgent selectedobject = tbAgent.FindBy("guid", frmselect.guid);
                TxtSelect.Tag = selectedobject;
                TxtSelect.Text = selectedobject.name;
                FillAgentInfo(selectedobject);
            }
            else
            {
                TxtSelect.Tag = new tbAgent();
                TxtSelect.Text = string.Empty;
                FillAgentInfo(new tbAgent());

            }
        }


        private void BtnShowCard_Click(object sender, EventArgs e)
        {
            tbAgent selectedobject = (tbAgent)TxtSelect.Tag;
            if (!selectedobject.guid.Equals(Guid.Empty))
            {
                FrmAccount frmtable = new FrmAccount(selectedobject.guid, false, false);
                frmtable.ShowDialog();
            }
        }

        private void BtnSeacrh_Click(object sender, EventArgs e)
        {
            TxtSelect_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        #endregion

        void FillAgentInfo(tbAgent agent)
        {

            vwAddAmountToAgentStatement.Fill("BuyerGuid", agent.guid);
            TxtAgentBalance.Text = vwAgentStatement.GetAgentBalance(agent.guid).ToString(DataGUIAttribute.CurrencyFormat);
            TxtContractTotal.Text = vwAddAmountToAgentStatement.lstData.Sum(x => x.totalnet).ToString(DataGUIAttribute.CurrencyFormat);


            CalcTotal();

        }

        private void CmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPayType.Focused)

                if (CmbPayType.SelectedIndex == 0 || CmbPayType.SelectedIndex == 1)
                {
                    CmbBank.Enabled = false;
                    TxtCheckNo.Enabled = false;
                    TxtCheckNo.Text = string.Empty;
                    CmbBank.Text = string.Empty;
                    LblCheck.Text = "رقم الشيك";

                }
                else if (CmbPayType.SelectedIndex == 2 || CmbPayType.SelectedIndex == 3)
                {
                    CmbBank.Enabled = true;
                    TxtCheckNo.Enabled = true;
                    if (CmbPayType.SelectedIndex == 3)
                    {
                        LblCheck.Text = "رقم الحوالة";
                    }
                    else
                    {
                        LblCheck.Text = "رقم الشيك";
                    }

                }
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            decimal balance;
            decimal.TryParse(TxtAgentBalance.Text, out balance);

            decimal amount;
            decimal.TryParse(TxtAmount.Text, out amount);

            TxtRemainAfterPay.Text = (balance - amount).ToString(DataGUIAttribute.CurrencyFormat);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SavePays(false);
        }

        void SavePays(bool Preview)
        {

            if (MessageBox.Show("هل أنت متأكد من توزيع المبلغ على العقود الغير مسددة كلياً، لن يمكنك التراجع عن هذه الخطوة بشكل آلي، هل تريد المتابعة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            for (int i = 0; i < DataGridMain.Rows.Count; i++)
            {
                decimal totalnet;
                decimal.TryParse(DataGridMain.Rows[i].Cells["totalnet"].Value.ToString(), out totalnet);


                decimal payments;
                decimal.TryParse(DataGridMain.Rows[i].Cells["payments"].Value.ToString(), out payments);

                DataGridMain.Rows[i].Cells["addpay"].Value = 0;
                DataGridMain.Rows[i].Cells["remainafterpay"].Value = totalnet - payments;
            }


            tbAgent acc = (tbAgent)TxtSelect.Tag;

            decimal manualamount;
            decimal.TryParse(TxtAmount.Text, out manualamount);

            decimal remain;
            decimal.TryParse(TxtRemainAfterPay.Text, out remain);

            if (remain < 0)
            {
                MessageBox.Show("يجب أن يكون المبلغ المدفوع أصغر أو يساوي قيمة رصيد العميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            if (!Preview)
            {
                DBConnect.StartTransAction();
            }

            for (int i = 0; i < DataGridMain.Rows.Count; i++)
            {
                decimal totalnet;
                decimal.TryParse(DataGridMain.Rows[i].Cells["totalnet"].Value.ToString(), out totalnet);

                decimal contractremain;
                decimal.TryParse(DataGridMain.Rows[i].Cells["remain"].Value.ToString(), out contractremain);

                decimal payments;
                decimal.TryParse(DataGridMain.Rows[i].Cells["payments"].Value.ToString(), out payments);

                int contractno;
                int.TryParse(DataGridMain.Rows[i].Cells["contractno"].Value.ToString(), out contractno);

                string code = DataGridMain.Rows[i].Cells["code"].Value.ToString();

                string note = string.Empty;

                decimal addpay = totalnet - payments;

                if (addpay > manualamount)
                {
                    addpay = manualamount;
                }


                if (manualamount > 0)
                {
                    DataGridMain.Rows[i].Cells["addpay"].Value = addpay;
                    DataGridMain.Rows[i].Cells["remainafterpay"].Value = totalnet - (payments + addpay);

                    if (!Preview)
                    {
                        Guid guid = AddNewPay(contractno, code, addpay, note);
                        DataGridMain.Rows[i].Cells["guid"].Value = guid;
                    }

                    manualamount -= addpay;
                }



            }

            if (!Preview)
            {
                if (DBConnect.CommitTransAction())
                {

                }
            }

            FrmConfirm frm = new FrmConfirm();
            frm.ShowDialog();
            CalcTotal();

        }

        Guid AddNewPay(int contractno, string code, decimal amount, string note)
        {


            tbPayContract pay = new tbPayContract();
            pay.guid = Guid.NewGuid();
            pay.bank = CmbBank.Text;

            pay.number = tbPayContract.GetMaxNumberTrans("number", 0) + 1;
            pay.contractno = contractno;
            pay.paymenttype = 0;
            pay.paydate = DateTime.Now.Date;
            pay.paytype = CmbPayType.Text;
            pay.checkno = string.Empty;
            pay.amount = amount;
            pay.note = note;
            pay.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            if (amount > 0)
                pay.Insert();

            DBConnect.CommitTransAction();

            return pay.guid;

        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            SavePays(true);
        }
    }
}
