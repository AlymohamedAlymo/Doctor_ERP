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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;


namespace DoctorERP
{
    public partial class FrmTaxAndDiscount : KryptonForm
    {
        Guid guid;


        public FrmTaxAndDiscount(Guid guid)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();
            tbTaxDiscount.Fill();
            if (tbTaxDiscount.lstData.Count <= 0)
            {
                tbTaxDiscount taxdiscount = new tbTaxDiscount();
                taxdiscount.guid = Guid.NewGuid();
                taxdiscount.isbuildingfee = false;
                taxdiscount.buildingfee = 0;
                taxdiscount.issalefee = false;
                taxdiscount.salesfee = 0;
                taxdiscount.isworkfee = false;
                taxdiscount.workfee = 0;
                taxdiscount.isvat = false;
                taxdiscount.vat = 0;
                taxdiscount.isdiscounttotal = false;
                taxdiscount.discounttotal = 0;
                taxdiscount.discounttotalvalue = 0;
                taxdiscount.isdiscountfee = false;
                taxdiscount.discountfee = 0;
                taxdiscount.discountfeevalue = 0;

                DBConnect.StartTransAction();
                taxdiscount.Insert();
                DBConnect.CommitTransAction();
            }

            this.guid = guid;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();
        }


        #region Binding
        private void InitBinding()
        {
            tbTaxDiscount.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {

            tbTaxDiscount taxdiscount = tbTaxDiscount.lstData[0];

            DataGUIAttribute.AssignFormValues<tbTaxDiscount>(this, taxdiscount);

            Txtvat.Enabled = taxdiscount.isvat;
            Txtworkfee.Enabled = taxdiscount.isworkfee;

            Txtsalesfee.Enabled = taxdiscount.issalefee;
            Txtbuildingfee.Enabled = taxdiscount.isbuildingfee;

            Txtdiscountfee.Enabled = taxdiscount.isdiscountfee;
            Txtdiscountfeevalue.Enabled = taxdiscount.isdiscountfee;

            Txtdiscounttotal.Enabled = taxdiscount.isdiscounttotal;
            Txtdiscounttotalvalue.Enabled = taxdiscount.isdiscounttotal;






        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbTaxDiscount>(this, new tbTaxDiscount());
            DataGUIAttribute.ClearFormControls<tbTaxDiscount>(this, new tbTaxDiscount());


            FillCmb();
        }
        #endregion

        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewFill();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            tbTaxDiscount taxdiscount = new tbTaxDiscount();

            taxdiscount.guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbTaxDiscount>(this, taxdiscount);

            if (MessageBox.Show("هل أنت متأكد من الحفظ ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            tbLand.Fill();

            DBConnect.StartTransAction();

            foreach (var item in tbLand.lstData)
            {
                item.isbuildingfee = taxdiscount.isbuildingfee;
                item.buildingfee = taxdiscount.buildingfee;

                item.isdiscountfee = taxdiscount.isdiscountfee;
                item.discountfee = taxdiscount.discountfee;
                item.discountfeevalue = taxdiscount.discountfeevalue;

                item.isdiscounttotal = taxdiscount.isdiscounttotal;
                item.discounttotal = taxdiscount.discounttotal;
                item.discounttotalvalue = taxdiscount.discounttotalvalue;

                item.isvat = taxdiscount.isvat;
                item.vat = taxdiscount.vat;

                item.isworkfee = taxdiscount.isworkfee;
                item.workfee = taxdiscount.workfee;

                item.issalefee = taxdiscount.issalefee;
                item.salesfee = taxdiscount.salesfee;
                item.total = CalcTotal(item.amount, item.salesfee, item.buildingfee, item.workfee, item.vat);
                item.Update();

            }
            taxdiscount.DeleteALL();
            taxdiscount.Insert();

            if (DBConnect.CommitTransAction())
            {

                ShowConfirm();


            }
        }

        decimal CalcTotal(decimal amount, decimal salesfee, decimal buildingfee, decimal workfee, decimal vatfee)
        {

            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            return total;

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

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

        void FillCmb()
        {
            //CmbType.Items.Clear();
            //CmbType.Items.AddRange(tbSMSSettings.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }

        private void LblHint_Click(object sender, EventArgs e)
        {

        }

        private void Chkissalefee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkissalefee.Focused)
            {
                if (Chkissalefee.Checked)
                {
                    Txtsalesfee.Enabled = true;
                }
                else
                {
                    Txtsalesfee.Text = string.Empty;

                    Txtsalesfee.Enabled = false;
                }
            }
        }

        private void Chkisbuildingfee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisbuildingfee.Focused)
            {
                if (Chkisbuildingfee.Checked)
                {
                    Txtbuildingfee.Enabled = true;
                }
                else
                {
                    Txtbuildingfee.Text = string.Empty;

                    Txtbuildingfee.Enabled = false;
                }

            }
        }

        private void Chkisworkfee_CheckedChanged(object sender, EventArgs e)
        {

            if (Chkisworkfee.Focused)
            {
                if (Chkisworkfee.Checked)
                {
                    Txtworkfee.Enabled = true;
                }
                else
                {
                    Txtworkfee.Text = string.Empty;
                    Txtworkfee.Enabled = false;
                }

            }
        }

        private void Chkisvat_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisvat.Focused)
            {
                if (Chkisvat.Checked)
                {
                    Txtvat.Enabled = true;
                }
                else
                {
                    Txtvat.Text = string.Empty;
                    Txtvat.Enabled = false;
                }

            }
        }

        private void Chkisdiscounttotal_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisdiscounttotal.Focused)
            {
                if (Chkisdiscounttotal.Checked)
                {
                    Txtdiscounttotal.Enabled = true;
                    Txtdiscounttotalvalue.Enabled = true;
                }
                else
                {
                    Txtdiscounttotal.Text = string.Empty;
                    Txtdiscounttotal.Enabled = false;
                    Txtdiscounttotalvalue.Text = string.Empty;
                    Txtdiscounttotalvalue.Enabled = false;
                }

            }
        }

        private void Chkisdiscountfee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisdiscountfee.Focused)
            {
                if (Chkisdiscountfee.Checked)
                {
                    Txtdiscountfee.Enabled = true;
                    Txtdiscountfeevalue.Enabled = true;
                }
                else
                {
                    Txtdiscountfee.Text = string.Empty;
                    Txtdiscountfee.Enabled = false;

                    Txtdiscountfeevalue.Text = string.Empty;
                    Txtdiscountfeevalue.Enabled = false;

                }

            }
        }

        private void Txtdiscounttotal_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscounttotal.Focused)
            {
                decimal discounttotal;
                decimal.TryParse(Txtdiscounttotal.Text, out discounttotal);

                if (discounttotal > 0)
                {
                    Txtdiscounttotalvalue.Text = string.Empty;
                }

            }
        }

        private void Txtdiscounttotalvalue_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscounttotalvalue.Focused)
            {
                decimal discounttotalvalue;
                decimal.TryParse(Txtdiscounttotalvalue.Text, out discounttotalvalue);

                if (discounttotalvalue > 0)
                {
                    Txtdiscounttotal.Text = string.Empty;
                }

            }
        }

        private void Txtdiscountfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscountfee.Focused)
            {
                decimal discountfee;
                decimal.TryParse(Txtdiscountfee.Text, out discountfee);

                if (discountfee > 0)
                {
                    Txtdiscountfeevalue.Text = string.Empty;
                }

            }
        }

        private void Txtdiscountfeevalue_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscountfeevalue.Focused)
            {
                decimal discountfeevalue;
                decimal.TryParse(Txtdiscountfeevalue.Text, out discountfeevalue);

                if (discountfeevalue > 0)
                {
                    Txtdiscountfee.Text = string.Empty;
                }

            }
        }
    }
}
