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


namespace DoctorERP
{
    public partial class FrmGeneralAccount : KryptonForm
    {
        public FrmGeneralAccount()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();

            if (FrmMain.PlanGuid != Guid.Empty)
            {
                tbLand.Fill("PlanGuid", FrmMain.PlanGuid);
                vwGeneralAccountInfo.Fill("PlanGuid", FrmMain.PlanGuid);
                vwGeneralAccountLandSales.Fill("PlanGuid", FrmMain.PlanGuid);

            }
            else if (FrmMain.PlanGuid == Guid.Empty)
            {
                tbLand.Fill();
                vwGeneralAccountInfo.Fill();
                vwGeneralAccountLandSales.Fill();

            }

            if (vwGeneralAccountInfo.lstData.Count > 0)
            {
                TxtPayements.Text = vwGeneralAccountInfo.lstData[0].payments.ToString(DataGUIAttribute.CurrencyFormat);
                TxtTotalSales.Text = vwGeneralAccountInfo.lstData[0].totalsales.ToString(DataGUIAttribute.CurrencyFormat);
                TxtRemain.Text = vwGeneralAccountInfo.lstData[0].remain.ToString(DataGUIAttribute.CurrencyFormat);
            }
            else
            {
                TxtPayements.Text = 0.ToString(DataGUIAttribute.CurrencyFormat);
                TxtTotalSales.Text = 0.ToString(DataGUIAttribute.CurrencyFormat);
                TxtRemain.Text = 0.ToString(DataGUIAttribute.CurrencyFormat);

            }

            int totalland = tbLand.lstData.Count;
            int salesland = tbLand.lstData.Where(x => x.status == "مباع").Count();
            int reserveland = tbLand.lstData.Where(x => x.status == "محجوز").Count();
            int remainlands = tbLand.lstData.Where(x => x.status == "متاح").Count();

            TxtTotalLands.Text = totalland.ToString("N0");
            TxtSalesLand.Text = salesland.ToString("N0");
            TxtRemainLands.Text = remainlands.ToString("N0");
            TxtReserveLands.Text = reserveland.ToString("N0");


            DataGridMain.DataSource = vwGeneralAccountLandSales.dtData;

        }


        #region Binding
        private void InitBinding()
        {

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {

        }

        private void FillForm()
        {

        }

        private void NewFill()
        {


        }


        #endregion

        #region Buttons


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





        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {

            Reports.InitReport(rpt, "generalacc.frx", false);


            tbPlanInfo.Fill();
            tbAgent.Fill("Guid", tbPlanInfo.lstData[0].ownerguid);

            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");


            vwGeneralAccountLandSales.Fill();

            rpt.RegisterData(vwGeneralAccountLandSales.dtData, "vwGeneralAccountLandSales");


            tbLand.Fill();

            vwGeneralAccountInfo.Fill();

            if (vwGeneralAccountInfo.lstData.Count > 0)
            {
                decimal payments = vwGeneralAccountInfo.lstData[0].payments;
                decimal totalsales = vwGeneralAccountInfo.lstData[0].totalsales;
                decimal remain = vwGeneralAccountInfo.lstData[0].remain;

                rpt.SetParameterValue("payments", payments);
                rpt.SetParameterValue("totalsales", totalsales);
                rpt.SetParameterValue("remain", remain);

            }
            else
            {

                rpt.SetParameterValue("payments", 0);
                rpt.SetParameterValue("totalsales", 0);
                rpt.SetParameterValue("remain", 0);

            }

            int totalland = tbLand.lstData.Count;
            int salesland = tbLand.lstData.Where(x => x.status == "مباع").Count();
            int reserveland = tbLand.lstData.Where(x => x.status == "محجوز").Count();
            int remainlands = tbLand.lstData.Where(x => x.status == "متاح").Count();

            rpt.SetParameterValue("totalland", totalland);
            rpt.SetParameterValue("salesland", salesland);
            rpt.SetParameterValue("reserveland", reserveland);
            rpt.SetParameterValue("remainlands", remainlands);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);


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
