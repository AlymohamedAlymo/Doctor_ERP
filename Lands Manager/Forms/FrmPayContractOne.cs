using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Diagnostics;
using SmartArabXLSX.Packaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FastReport;
using FastReport.Data;
using NumberToWord;

namespace DoctorERP
{
    public partial class FrmPayContractOne : KryptonForm
    {
        Guid guid;
        BindingSource bs;

        bool isNew;
        int paymenttype;
        string status = string.Empty;
        public FrmPayContractOne(Guid guid, bool isNew, int paymenttype)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            tbBanks.Fill();
            tbPaymentsNotes.Fill();
            TxtSelect.Tag = new vwContractInfo();

            this.guid = guid;
            this.paymenttype = paymenttype;
            BtnEdit.Visible = true;
            BtnAdd.Visible = false;
            if (paymenttype == 0)
            {
                this.Text = "سند قبض لعقد بيع";
                status = "مباع";

            }
            else if (paymenttype == 1)
            {
                this.Text = "سند قبض لعقد بيع خارجي";
                status = "عقد خارجي";
                TxtAgentBalance.Visible = TxtContractRemain.Visible = false;
                LblRemain.Visible = LblBalance.Visible = false;
            }
            
            if (paymenttype == 2)
            {
                this.Text = "سند صرف ( خصم إستثنائي )";
                status = "مباع";
                CmbAmountFor.SelectedIndex = 4;
                CmbAmountFor.Enabled = false;
                CmbPayType.Enabled = false;
            }
            this.isNew = isNew;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();


            if (isNew)
            {
                BtnNew.PerformClick();


                BtnAdd.Visible = true;
                BtnEdit.Visible = false;
            }
        }


        #region Binding
        private void InitBinding()
        {
            tbPayContract.Fill("paymenttype", paymenttype);
            bs = new BindingSource(tbPayContract.lstData, string.Empty);
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbPayContract.lstData.FindIndex(delegate (tbPayContract pay) { return pay.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbPayContract obj = (tbPayContract)bs.Current;

                if (obj.guid.Equals(Guid.Empty))
                {
                    BtnAdd.Visible = true;
                    BtnEdit.Visible = false;
                    BtnDelete.Enabled = false;
                    TxtNumber.Text = string.Empty;
                    if (CmbPayType.SelectedIndex != 0)
                    {
                        CmbBank.Enabled = true;
                        TxtCheckNo.Enabled = true;

                    }
                    else
                    {
                        CmbBank.Enabled = false;
                        TxtCheckNo.Enabled = false;
                        TxtCheckNo.Text = string.Empty;
                        CmbBank.Text = string.Empty;


                    }

                }

                FillForm();

            }
            catch
            {
                CheckAllow(new tbPayContract());
                TxtNumber.Text = string.Empty;
            }
        }

        private void FillForm()
        {
            if (bs.Count > 0)
            {
                tbPayContract pay = (tbPayContract)bs.Current;

                DataGUIAttribute.AssignFormValues<tbPayContract>(this, pay);
                vwContractInfo selectedobject = vwContractInfo.FindBy("contractno", pay.contractno);
                if (selectedobject.guid.Equals(Guid.Empty))
                {
                    TxtSelect.Text = string.Empty;
                    LblCheck.Text = "رقم الشيك";
                }
                else
                {
                    TxtSelect.Text = selectedobject.contractno.ToString() + "-" + selectedobject.land;
                    FillContractInfo(selectedobject);
                    if (pay.paytype == "تحويل بنكي")
                    {
                        LblCheck.Text = "رقم الحوالة";
                    }
                    else
                    {
                        LblCheck.Text = "رقم الشيك";
                    }
                }

                if (CmbPayType.SelectedIndex != 0)
                {
                    CmbBank.Enabled = true;
                    TxtCheckNo.Enabled = true;

                }
                else
                {
                    CmbBank.Enabled = false;
                    TxtCheckNo.Enabled = false;
                    TxtCheckNo.Text = string.Empty;
                    CmbBank.Text = string.Empty;
                    LblCheck.Text = "رقم الشيك";

                }

                TxtSelect.Tag = selectedobject;

                TxtNumber.Text = pay.number.ToString();


                if (pay is null || pay.guid.Equals(Guid.Empty))
                {
                    FillContractInfo(new vwContractInfo());
                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    BtnAdd.Visible = true;
                    LblCheck.Text = "رقم الشيك";
                    TxtNumber.Text = string.Empty;
                }
                else
                {
                    BtnDelete.Enabled = true;
                    BtnEdit.Visible = true;
                    BtnAdd.Visible = false;
                }

                CheckAllow(pay);
            }
            else
            {
                NewFill();
                TxtNumber.Text = string.Empty;
                BtnDelete.Enabled = false;
                BtnEdit.Visible = false;
                BtnAdd.Visible = true;
                LblCheck.Text = "رقم الشيك";
                isNew = true;
            }
        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbPayContract>(this, new tbPayContract());
            DataGUIAttribute.ClearFormControls<tbPayContract>(this, new tbPayContract());

            TxtSelect.Tag = new vwContractInfo();
            TxtSelect.Text = string.Empty;
            TxtNumber.Text = string.Empty;
            dtPayDate.Value = dtPayDate.Value.Date;

            if (CmbPayType.SelectedIndex != 0)
            {
                CmbBank.Enabled = true;
                TxtCheckNo.Enabled = true;

            }
            else
            {
                CmbBank.Enabled = false;
                TxtCheckNo.Enabled = false;
                TxtCheckNo.Text = string.Empty;
                CmbBank.Text = string.Empty;


            }

            CheckAllow(new tbPayContract());

        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbPayContract obj = (tbPayContract)bs[i];
                if (obj.guid.Equals(Guid.Empty))
                {
                    bs.Remove(obj);
                }
            }
        }
        #endregion


        void CheckAllow(tbPayContract pay)
        {
            bool Enable;

            if (FrmMain.AllowEdit || pay.guid.Equals(Guid.Empty))
                Enable = true;
            else
                Enable = false;


            foreach (KryptonTextBox item in DataGUIAttribute.GetAll(this, typeof(KryptonTextBox)))
            {
                item.ReadOnly = !Enable;
            }

            if (Enable)
                BtnSearch.Enabled = ButtonEnabled.True;
            else
                BtnSearch.Enabled = ButtonEnabled.False;

            dtPayDate.Enabled = Enable;
            if (paymenttype == 2)
                CmbAmountFor.Enabled = false;
            else
                CmbAmountFor.Enabled = Enable;

            CmbBank.Enabled = Enable;
            if (paymenttype == 2)
            {
                CmbPayType.Enabled = false;
                CmbBank.Enabled = false;
            }
            else
                CmbPayType.Enabled = Enable;
            BtnEdit.Enabled = Enable;
           // BtnDelete.Enabled = Enable;


        }

        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            BtnAdd.Visible = true;
            BtnEdit.Visible = false;
            BtnDelete.Enabled = false;
            FillContractInfo(new vwContractInfo());

            FillCmb();
            Clear();

            bs.AddNew();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Add())
                BtnNew.PerformClick();

        }

        bool Add()
        {
            if (!FrmMain.currentuser.CanAdd)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            tbPayContract pay = new tbPayContract();



            //int number;
            //int.TryParse(TxtNumber.Text, out number);
            //if (number <= 0)
            //{
            //    MessageBox.Show("يجب إدخال رقم السند", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (tbPayContract.IsExist("number", TxtNumber.Text))
            //{
            //    MessageBox.Show(("رقم السند مكرر"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            vwContractInfo account = (vwContractInfo)TxtSelect.Tag;
            if (account.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار عقد", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            pay.guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbPayContract>(this, pay);



            pay.number = tbPayContract.GetMaxNumber("number") + 1;

            pay.contractno = account.contractno;
            pay.paymenttype = paymenttype;
            if (MessageBox.Show("هل أنت متأكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;


            pay.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;


            DBConnect.StartTransAction();
            tbLog.AddLog("إضافة", this.Text, account.contractno + "/" + pay.amount.ToString("N2"));
            pay.Insert();

            if (DBConnect.CommitTransAction())
            {
                bs.Add(pay);
                ShowConfirm();

                Clear();
                bs.MoveLast();
            }

            BtnAdd.Visible = false;
            BtnEdit.Visible = true;

            isNew = false;
            return true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanEdit)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Edit();
        }

        bool Edit()
        {

            tbPayContract pay = (tbPayContract)bs.Current;


            //int number;
            //int.TryParse(TxtNumber.Text, out number);
            //if (number <= 0)
            //{
            //    MessageBox.Show("يجب إدخال رقم السند", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (tbPayContract.IsExist("number", TxtNumber.Text) && TxtNumber.Text != pay.number.ToString())
            //{
            //    MessageBox.Show(("رقم السند مكرر"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}


            vwContractInfo account = (vwContractInfo)TxtSelect.Tag;
            if (account.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار عقد", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            DataGUIAttribute.AssignObjectValues<tbPayContract>(this, pay);

            pay.contractno = account.contractno;
            pay.paymenttype = paymenttype;
            if (MessageBox.Show("هل أنت متأكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;


            pay.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;


            DBConnect.StartTransAction();
            tbLog.AddLog("تعديل", this.Text, account.contractno + "/" + pay.amount.ToString("N2"));
            pay.Update();

            if (DBConnect.CommitTransAction())
            {

                ShowConfirm();

                isNew = false;

            }

            return true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            tbPayContract pay = (tbPayContract)bs.Current;
            vwContractInfo account = vwContractInfo.FindBy("Guid", pay.contractno);

            DBConnect.StartTransAction();
            tbLog.AddLog("حذف", this.Text, account.contractno + "/" + pay.amount.ToString("N2"));
            pay.Delete();

            if (DBConnect.CommitTransAction())
            {
                bs.RemoveCurrent();
                bs.MoveLast();
                ShowConfirm();
                Clear();
                BtnNew.PerformClick();

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void ShowConfirm()
        {
            FrmConfirm frmconfirm = new FrmConfirm();
            frmconfirm.ShowDialog();
        }


        void FillContractInfo(vwContractInfo contract)
        {
            tbPayContract pay = (tbPayContract)bs.Current;

            tbAgent agent = tbAgent.FindBy("Guid", contract.buyerguid);

            decimal balance = vwAgentStatement.GetAgentBalance(contract.buyerguid);

            TxtAgentBalance.Text = balance.ToString(DataGUIAttribute.CurrencyFormat);

            if (contract.guid.Equals(Guid.Empty))
            {
                TxtBuyer.Text = string.Empty;
                TxtCode.Text = string.Empty;
                TxtLand.Text = string.Empty;
                TxtContractTotal.Text = string.Empty;
                TxtContractRemain.Text = string.Empty;
                TxtAgentBalance.Text = string.Empty;
                TxtNote.Text = string.Empty;
                TxtRemainFrom.Text = string.Empty;
                TxtAmountFor.Text = string.Empty;
            }
            else
            {
                TxtBuyer.Text = contract.agent;
                TxtCode.Text = contract.code.ToString();
                TxtLand.Text = "الأرض رقم " + contract.code;
                TxtContractTotal.Text = contract.totalnet.ToString(DataGUIAttribute.CurrencyFormat);
                TxtContractRemain.Text = contract.remain.ToString(DataGUIAttribute.CurrencyFormat);
                if (CmbAmountFor.SelectedIndex == 0)
                {
                    LblAmountFor.Visible = false;
                    TxtAmountFor.Visible = false;
                    LblRemainFrom.Visible = false;
                    TxtRemainFrom.Visible = false;

                }
                if (CmbAmountFor.SelectedIndex == 1)
                {
                    LblAmountFor.Visible = true;
                    TxtAmountFor.Visible = true;
                    LblRemainFrom.Visible = true;
                    TxtRemainFrom.Visible = true;

                    LblAmountFor.Text = "قيمة الأرض الدفترية";
                    TxtAmountFor.Text = contract.landprice.ToString(DataGUIAttribute.CurrencyFormat);
                    TxtRemainFrom.Text = contract.landpriceremain.ToString(DataGUIAttribute.CurrencyFormat);

                }
                else if (CmbAmountFor.SelectedIndex == 2)
                {
                    LblAmountFor.Visible = true;
                    TxtAmountFor.Visible = true;
                    LblRemainFrom.Visible = true;
                    TxtRemainFrom.Visible = true;

                    LblAmountFor.Text = "قيمة عمولة السعي";
                    TxtAmountFor.Text = contract.workfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
                    TxtRemainFrom.Text = contract.workfeevalueremain.ToString(DataGUIAttribute.CurrencyFormat);

                }
                else if (CmbAmountFor.SelectedIndex == 3)
                {
                    LblAmountFor.Visible = true;
                    TxtAmountFor.Visible = true;
                    LblRemainFrom.Visible = true;
                    TxtRemainFrom.Visible = true;

                    LblAmountFor.Text = "قيمة ضريبة عمولة السعي";
                    TxtAmountFor.Text = contract.vatvalue.ToString(DataGUIAttribute.CurrencyFormat);
                    TxtRemainFrom.Text = contract.vatvalueremain.ToString(DataGUIAttribute.CurrencyFormat);
                }
                else if (CmbAmountFor.SelectedIndex == 4)
                {
                    LblAmountFor.Visible = false;
                    TxtAmountFor.Visible = false;
                    LblRemainFrom.Visible = false;
                    TxtRemainFrom.Visible = false;

                    LblAmountFor.Text = "خصم إستثنائي";
                    TxtAmountFor.Text = contract.vatvalue.ToString(DataGUIAttribute.CurrencyFormat);
                    TxtRemainFrom.Text = contract.vatvalueremain.ToString(DataGUIAttribute.CurrencyFormat);

                    if (pay is null || pay.guid.Equals(Guid.Empty))
                    {
                        TxtAmount.Text = balance.ToString(DataGUIAttribute.CurrencyFormat);
                    }


                }


                string amfor;
                if (CmbAmountFor.SelectedIndex == 0)
                {
                    amfor = string.Empty;
                }
                else
                {
                    amfor = CmbAmountFor.Text;
                }

                if (pay is null || pay.guid.Equals(Guid.Empty))
                {
                    if (CmbAmountFor.SelectedIndex == 1)
                    {
                        TxtNote.Text = tbPaymentsNotes.lstData[0].landpricenotes.Replace("%نوع الدفعة%", amfor).Replace("%العميل%", agent.name).Replace("%الأرض%", "الأرض رقم " + contract.code.ToString()).Replace("%العقد%", contract.contractno.ToString());
                    }
                    else if (CmbAmountFor.SelectedIndex == 2)
                    {
                        TxtNote.Text = tbPaymentsNotes.lstData[0].workfeenotes.Replace("%نوع الدفعة%", amfor).Replace("%العميل%", agent.name).Replace("%الأرض%", "الأرض رقم " + contract.code.ToString()).Replace("%العقد%", contract.contractno.ToString());
                    }
                    else if (CmbAmountFor.SelectedIndex == 3)
                    {
                        TxtNote.Text = tbPaymentsNotes.lstData[0].vatnotes.Replace("%نوع الدفعة%", amfor).Replace("%العميل%", agent.name).Replace("%الأرض%", "الأرض رقم " + contract.code.ToString()).Replace("%العقد%", contract.contractno.ToString());
                    }
                    else if (CmbAmountFor.SelectedIndex == 4)
                    {
                        TxtNote.Text = tbPaymentsNotes.lstData[0].discountnotes.Replace("%نوع الدفعة%", amfor).Replace("%العميل%", agent.name).Replace("%الأرض%", "الأرض رقم " + contract.code.ToString()).Replace("%العقد%", contract.contractno.ToString());
                    }
                    else
                    {
                        TxtNote.Text = string.Empty;
                    }
                }
            }

            CalcTotal();

        }

        #region Select
        private void TxtSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vwContractInfo selectedobject = new vwContractInfo();


                vwContractInfo.Fill(TxtSelect.Text, status);
                if (vwContractInfo.dtData.Rows.Count == 1)
                {
                    selectedobject = vwContractInfo.FindBy("guid", (Guid)vwContractInfo.dtData.Rows[0]["guid"]);
                    TxtSelect.Tag = selectedobject;
                    TxtSelect.Text = selectedobject.contractno.ToString() + "-" + selectedobject.land;
                    FillContractInfo(selectedobject);
                }
                else if (vwContractInfo.dtData.Rows.Count == 0)
                {
                    vwContractInfo.Fill(" ", status);
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
                    FillContractInfo(new vwContractInfo());
                    return;
                }

            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelect.Tag = new vwContractInfo();
                TxtSelect.Text = string.Empty;
                FillContractInfo(new vwContractInfo());
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
                FillContractInfo(selectedobject);
            }
            else
            {
                TxtSelect.Tag = new vwContractInfo();
                TxtSelect.Text = string.Empty;
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


        #endregion


        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            if (bs.Current == null)
            {
                MessageBox.Show("يجب حفظ السند أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            tbPayContract pay = (tbPayContract)bs.Current;

            if (pay is null || pay.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب حفظ السند أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                report.Print();
        }
        #endregion

        private void CmbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPayType.Focused)
            {
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
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            if (TxtAmount.Focused)
            {
                CalcTotal();
            }
        }

        void FillCmb()
        {
            CmbBank.Items.Clear();
            CmbBank.Items.Add(string.Empty);
            CmbBank.Items.AddRange(tbBanks.GetUniqueList("BankName").ToArray());
            CmbBank.SelectedIndex = 0;

            if (paymenttype == 2)
            {
                CmbAmountFor.SelectedIndex = 4;
            }
            else
            {
                CmbAmountFor.SelectedIndex = 0;
            }


            CmbPayType.SelectedIndex = 0;
        }

        void CalcTotal()
        {
            decimal amount;
            decimal.TryParse(TxtAmount.Text, out amount);

            decimal total;
            decimal.TryParse(TxtContractTotal.Text, out total);

            //TxtAgentRemain.Text = (total - amount).ToString(DataGUIAttribute.CurrencyFormat);
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void CmbAmountFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbAmountFor.Focused)
            {
                vwContractInfo contract = (vwContractInfo)TxtSelect.Tag;

                FillContractInfo(contract);
            }
        }
    }
}
