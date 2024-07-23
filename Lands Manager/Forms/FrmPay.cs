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
using FastReport;

namespace DoctorERP
{
    public partial class FrmPay : KryptonForm
    {
        Guid guid;
        BindingSource bs;
        int paytype;
        bool isNew;
        public FrmPay(Guid guid, int paytype, bool isNew)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            TxtSelect.Tag = new tbAccount();

            this.guid = guid;
            this.paytype = paytype;
            if (paytype == 0)
            {
                this.Text = "سند قبض";
            }
            else
            {

                this.Text = "سند صرف";

            }
            BtnEdit.Visible = true;
            BtnAdd.Visible = false;

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
            tbPay.Fill("paytype", paytype);
            bs = new BindingSource(tbPay.lstData, string.Empty);
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbPay.lstData.FindIndex(delegate (tbPay pay) { return pay.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbPay obj = (tbPay)bs.Current;

                if (obj.guid.Equals(Guid.Empty))
                {
                    BtnAdd.Visible = true;
                    BtnEdit.Visible = false;
                    BtnDelete.Enabled = false;

                }

                FillForm();

            }
            catch
            {

            }
        }

        private void FillForm()
        {
            if (bs.Count > 0)
            {
                tbPay pay = (tbPay)bs.Current;

                DataGUIAttribute.AssignFormValues<tbPay>(this, pay);
                tbAccount account = tbAccount.FindBy("guid", pay.accountguid);
                TxtSelect.Text = account.name;
                TxtSelect.Tag = account;

                TxtNumber.Text = pay.number.ToString();


                if (pay is null || pay.guid.Equals(Guid.Empty))
                {
                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    BtnAdd.Visible = true;
                }
                else
                {
                    BtnDelete.Enabled = true;
                    BtnEdit.Visible = true;
                    BtnAdd.Visible = false;
                }
            }
            else
            {
                NewFill();

                BtnDelete.Enabled = false;
                BtnEdit.Visible = false;
                BtnAdd.Visible = true;

                isNew = true;
            }
        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbPay>(this, new tbPay());
            DataGUIAttribute.ClearFormControls<tbPay>(this, new tbPay());
            TxtSelect.Tag = new tbAccount();
            TxtSelect.Text = string.Empty;
            TxtNumber.Text = string.Empty;
            dtPayDate.Value = dtPayDate.Value.Date;

        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbPay obj = (tbPay)bs[i];
                if (obj.guid.Equals(Guid.Empty))
                {
                    bs.Remove(obj);
                }
            }
        }
        #endregion

        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            BtnAdd.Visible = true;
            BtnEdit.Visible = false;
            BtnDelete.Enabled = false;

            //FillCmb();
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
            tbPay pay = new tbPay();


            tbAccount account = (tbAccount)TxtSelect.Tag;
            if (account.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار حساب", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            pay.guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbPay>(this, pay);
            pay.number = tbPay.GetMaxNumber("number", paytype) + 1;
            pay.accountguid = account.guid;
            pay.paytype = paytype;

            if (MessageBox.Show("هل أنت متأكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;

            pay.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            DBConnect.StartTransAction();
            tbLog.AddLog("إضافة", this.Text, account.name + "/" + pay.amount.ToString("N2"));
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

            tbPay pay = (tbPay)bs.Current;



            tbAccount account = (tbAccount)TxtSelect.Tag;
            if (account.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار حساب", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DataGUIAttribute.AssignObjectValues<tbPay>(this, pay);
            pay.accountguid = account.guid;
            pay.paytype = paytype;

            if (MessageBox.Show("هل أنت متأكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;

            pay.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            DBConnect.StartTransAction();
            tbLog.AddLog("تعديل", this.Text, account.name + "/" + pay.amount.ToString("N2"));

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

            tbPay pay = (tbPay)bs.Current;
            tbAccount account = tbAccount.FindBy("Guid", pay.accountguid);

            DBConnect.StartTransAction();
            tbLog.AddLog("حذف", this.Text, account.name + "/" + pay.amount.ToString("N2"));
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



        #region Select
        private void TxtSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAccount.Fill("name", TxtSelect.Text);
                if (tbAccount.dtData.Rows.Count == 1)
                {
                    tbAccount selectedobject = tbAccount.FindBy("guid", (Guid)tbAccount.dtData.Rows[0]["guid"]);
                    TxtSelect.Tag = selectedobject;
                    TxtSelect.Text = selectedobject.name;
                }
                else if (tbAccount.dtData.Rows.Count == 0)
                {
                    tbAccount.Fill("name", " ");
                    ShowSelect();
                }
                else
                {
                    ShowSelect();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelect.Tag = new tbAccount();
                TxtSelect.Text = string.Empty;
            }
        }

        private void ShowSelect()
        {
            FrmSelect frmselect = new FrmSelect("إختيار حساب", typeof(tbAccount), tbAccount.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbAccount selectedobject = tbAccount.FindBy("guid", frmselect.guid);
                TxtSelect.Tag = selectedobject;
                TxtSelect.Text = selectedobject.name;
            }
            else
            {
                TxtSelect.Tag = new tbAccount();
                TxtSelect.Text = string.Empty;
            }
        }


        private void BtnShowCard_Click(object sender, EventArgs e)
        {
            tbAccount selectedobject = (tbAccount)TxtSelect.Tag;
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

        private void BtnAddAgent_Click(object sender, EventArgs e)
        {
            FrmAccount frm = new FrmAccount(Guid.Empty, true, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TxtSelect.Tag = frm.AddedAgents;
                TxtSelect.Text = frm.AddedAgents.name;
            }
        }
        #endregion


        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            tbPay pay = (tbPay)bs.Current;

            if (pay is null || pay.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب حفظ السند أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            Reports.InitReport(rpt, "pay.frx", false);
            tbPay.Fill(pay.guid);

            tbAccount.Fill("Guid", pay.accountguid);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);
            rpt.RegisterData(tbAccount.dtData, "accdata");

            rpt.RegisterData(tbPay.dtData, "data");

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
    }
}
