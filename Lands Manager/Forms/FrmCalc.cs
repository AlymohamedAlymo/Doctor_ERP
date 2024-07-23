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
using System.IO;
using SmartArabXLSX.VariantTypes;
using SmartArabXLSX.Spreadsheet;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using SmartArabXLSX.Wordprocessing;
using Org.BouncyCastle.Utilities.Collections;
using DevExpress.Utils.DPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using NumberToWord;
using DevExpress.XtraEditors;
using System.Reflection.Emit;
using System.Windows.Forms.VisualStyles;
using Org.BouncyCastle.Crypto;

namespace DoctorERP
{
    public partial class FrmCalc : KryptonForm
    {




        public WinformsDirtyTracking.DirtyTracker dirtytracker;


        vwSelectLand land;
        public FrmCalc(vwSelectLand land)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCalcSettings();

            this.land = vwSelectLand.FindBy("Guid", land.guid);
            tbLand lan = tbLand.FindBy("Guid", land.guid);
            FillLandInfo(lan);

            TxtSelect.Tag = land;

            if (!lan.guid.Equals(Guid.Empty))
                TxtSelect.Text = "الأرض رقم " + lan.code.ToString();
            else
                TxtSelect.Text = string.Empty;

        }

        void FillCalcSettings()
        {
            tbTaxDiscount.Fill();

            Chkisbuildingfee.Checked = tbTaxDiscount.lstData[0].isbuildingfee;
            if (Chkisbuildingfee.Checked)
            {
                Txtbuildingfee.Enabled = true;
            }

            Chkissalefee.Checked = tbTaxDiscount.lstData[0].issalefee;
            if (Chkissalefee.Checked)
            {
                Txtsalesfee.Enabled = true;
            }
            Chkisvat.Checked = tbTaxDiscount.lstData[0].isvat;
            if (Chkisvat.Checked)
            {
                Txtvat.Enabled = true;
            }

            Chkisworkfee.Checked = tbTaxDiscount.lstData[0].isworkfee;
            if (Chkisworkfee.Checked)
            {
                Txtworkfee.Enabled = true;
            }

            Txtbuildingfee.Text = tbTaxDiscount.lstData[0].buildingfee.ToString(DataGUIAttribute.CurrencyFormat);
            Txtvat.Text = tbTaxDiscount.lstData[0].vat.ToString(DataGUIAttribute.CurrencyFormat);
            Txtworkfee.Text = tbTaxDiscount.lstData[0].workfee.ToString(DataGUIAttribute.CurrencyFormat);
            Txtsalesfee.Text = tbTaxDiscount.lstData[0].salesfee.ToString(DataGUIAttribute.CurrencyFormat);

        }

        private void FrmTable_Load(object sender, EventArgs e)
        {

        }

        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            Reports.InitReport(rpt, "calc.frx", false);

            vwSelectLand lan = (vwSelectLand)TxtSelect.Tag;

            vwSelectLand.Fill(lan.guid);
            rpt.RegisterData(vwSelectLand.dtData,"landdata");

            decimal amount;
            decimal.TryParse(TxtAmount.Text, out amount);

            decimal salesfee;
            decimal.TryParse(Txtsalesfee.Text, out salesfee);

            decimal salesfeevalue;
            decimal.TryParse(Txtsalesfeevalue.Text, out salesfeevalue);

            decimal vat;
            decimal.TryParse(Txtvat.Text, out vat);

            decimal vatvalue;
            decimal.TryParse(Txtvatvalue.Text, out vatvalue);

            decimal workfee;
            decimal.TryParse(Txtworkfee.Text, out workfee);

            decimal workfeevalue;
            decimal.TryParse(Txtworkfeevalue.Text, out workfeevalue);

            decimal buildingfee;
            decimal.TryParse(Txtbuildingfee.Text, out buildingfee);

            decimal buildingfeevalue;
            decimal.TryParse(Txtbuildingfeevalue.Text, out buildingfeevalue);

            decimal total;
            decimal.TryParse(TxtTotal.Text, out total);


            decimal workfeewithvat;
            decimal.TryParse(TxtWorkFeeWithVat.Text, out workfeewithvat);


            rpt.SetParameterValue("amount", amount);

            rpt.SetParameterValue("salesfee", salesfee);
            rpt.SetParameterValue("salesfeevalue", salesfeevalue);
            rpt.SetParameterValue("vat", vat);
            rpt.SetParameterValue("vatvalue", vatvalue);
            rpt.SetParameterValue("workfee", workfee);
            rpt.SetParameterValue("workfeevalue", workfeevalue);
            rpt.SetParameterValue("buildingfee", buildingfee);
            rpt.SetParameterValue("buildingfeevalue", buildingfeevalue);
            rpt.SetParameterValue("workfeewithvat", workfeewithvat);

            rpt.SetParameterValue("total", total);
            rpt.SetParameterValue("totaltext", TxtTotalText.Text);

            rpt.SetParameterValue("isbuildingfee", Chkisbuildingfee.Checked);
            rpt.SetParameterValue("issalefee", Chkissalefee.Checked);
            rpt.SetParameterValue("isvat", Chkisvat.Checked);
            rpt.SetParameterValue("isworkfee", Chkisworkfee.Checked);



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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void ShowConfirm()
        {
            FrmConfirm frmconfirm = new FrmConfirm();
            frmconfirm.ShowDialog();
        }



        private void FrmPay_FormClosing(object sender, FormClosingEventArgs e)
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
                    Txtsalesfee.Text = tbTaxDiscount.lstData[0].salesfee.ToString(DataGUIAttribute.CurrencyFormat);

                    Txtsalesfee.Enabled = false;
                }
                CalcTotal();
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
                    Txtbuildingfee.Text = tbTaxDiscount.lstData[0].buildingfee.ToString(DataGUIAttribute.CurrencyFormat);

                    Txtbuildingfee.Enabled = false;
                }
                CalcTotal();
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
                    Txtworkfee.Text = tbTaxDiscount.lstData[0].workfee.ToString(DataGUIAttribute.CurrencyFormat);
                    Txtworkfee.Enabled = false;
                }
                CalcTotal();
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
                    Txtvat.Text = tbTaxDiscount.lstData[0].vat.ToString(DataGUIAttribute.CurrencyFormat);
                    Txtvat.Enabled = false;
                }
                CalcTotal();
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {

            }
            else if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        void CalcTotal()
        {

            decimal amount;
            decimal.TryParse(TxtAmount.Text, out amount);

            decimal salesfee;
            decimal.TryParse(Txtsalesfee.Text, out salesfee);

            decimal buildingfee;
            decimal.TryParse(Txtbuildingfee.Text, out buildingfee);

            decimal workfee;
            decimal.TryParse(Txtworkfee.Text, out workfee);

            decimal vatfee;
            decimal.TryParse(Txtvat.Text, out vatfee);

            decimal salesfeevalue;
            salesfeevalue = (amount * salesfee / 100);

            decimal buildingfeevalue;
            buildingfeevalue = (amount * buildingfee / 100);

            decimal workfeevalue;
            workfeevalue = (amount * workfee / 100);

            decimal vatvalue;
            vatvalue = ((amount * workfee / 100) * vatfee / 100);


            decimal total = amount + salesfeevalue + buildingfeevalue + workfeevalue + vatvalue;

            Txtsalesfeevalue.Text = salesfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txtbuildingfeevalue.Text = buildingfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txtworkfeevalue.Text = workfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txtvatvalue.Text = vatvalue.ToString(DataGUIAttribute.CurrencyFormat);
            TxtTotal.Text = total.ToString(DataGUIAttribute.CurrencyFormat);
            TxtWorkFeeWithVat.Text = (workfeevalue + vatvalue).ToString(DataGUIAttribute.CurrencyFormat);

            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(total, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = total;

            TxtTotalText.Text = toWord.ConvertToArabic();


        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            if (TxtAmount.Focused)
                CalcTotal();
        }

        private void Txtsalesfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtsalesfee.Focused)
                CalcTotal();
        }

        private void Txtbuildingfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtbuildingfee.Focused)
                CalcTotal();
        }

        private void Txtworkfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtworkfee.Focused)
                CalcTotal();
        }

        private void Txtvat_TextChanged(object sender, EventArgs e)
        {
            if (Txtvat.Focused)
                CalcTotal();
        }


        #region Select Mat 
        private void SelectMat(string keyword)
        {
            vwSelectLand selectland = new vwSelectLand();

            vwSelectLand.Fill("code", (object)keyword);

            if (vwSelectLand.dtData.Rows.Count == 1)
            {
                selectland = vwSelectLand.FindBy("guid", new Guid(vwSelectLand.dtData.Rows[0]["guid"].ToString()));
                TxtSelect.Text = "الأرض رقم " + selectland.code.ToString();
            }
            else
            {

                vwSelectLand.Fill("code", " ");


                FrmSelect frmselect = new FrmSelect("إختيار صنف", typeof(vwSelectLand), vwSelectLand.dtData);

                if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectland = vwSelectLand.FindBy("guid", frmselect.guid);
                    TxtSelect.Text = "الأرض رقم " + selectland.code.ToString();
                }
            }

            if (!selectland.guid.Equals(Guid.Empty))
            {

                tbLand land = tbLand.FindBy("Guid", selectland.guid);
                TxtSelect.Text = "الأرض رقم " + selectland.code.ToString();
                FillLandInfo(land);

            }
            else
            {
                tbLand land = new tbLand();
                TxtSelect.Text = string.Empty;
                FillLandInfo(land);
            }

        }

        private void SelectItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectMat(TxtSelect.Text);
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SelectMat(TxtSelect.Text);
        }


        void FillLandInfo(tbLand land)
        {
            if (land.guid.Equals(Guid.Empty))
            {
                TxtAmount.Text = string.Empty;
                Txtsalesfee.Text = string.Empty;
                Txtsalesfeevalue.Text = string.Empty;
                Txtbuildingfee.Text = string.Empty;
                Txtbuildingfeevalue.Text = string.Empty;
                Txtworkfee.Text = string.Empty;
                Txtworkfeevalue.Text = string.Empty;

                Txtvat.Text = string.Empty;
                Txtvatvalue.Text = string.Empty;

                TxtWorkFeeWithVat.Text = string.Empty;
                TxtTotal.Text = string.Empty;
                TxtTotalText.Text = string.Empty;

                Chkissalefee.Checked = false;
                Chkisvat.Checked = false;
                Chkisworkfee.Checked = false;
                Chkisbuildingfee.Checked = false;

                FillCalcSettings();

            }
            else
            {
                TxtAmount.Text = land.amount.ToString(DataGUIAttribute.CurrencyFormat);
                Txtsalesfee.Text = land.salesfee.ToString(DataGUIAttribute.CurrencyFormat);

                Txtbuildingfee.Text = land.buildingfee.ToString(DataGUIAttribute.CurrencyFormat);

                Txtworkfee.Text = land.workfee.ToString(DataGUIAttribute.CurrencyFormat);


                Txtvat.Text = land.vat.ToString(DataGUIAttribute.CurrencyFormat);





                Chkissalefee.Checked = land.issalefee;
                Chkisvat.Checked = land.isvat;
                Chkisworkfee.Checked = land.isworkfee;
                Chkisbuildingfee.Checked = land.isbuildingfee;
            }
            CalcTotal();

        }

        #endregion


    }
}
