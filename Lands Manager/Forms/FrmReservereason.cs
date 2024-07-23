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
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace DoctorERP
{
    public partial class FrmReservereason : KryptonForm
    {

        public string reservereason;


        public FrmReservereason(string reservereason)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            this.reservereason = reservereason;


        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();


        }


        #region Binding
        private void InitBinding()
        {
            tbPriceLog.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {








        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbPriceLog>(this, new tbPriceLog());
            DataGUIAttribute.ClearFormControls<tbPriceLog>(this, new tbPriceLog());


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
            if (TxtReserveReason.Text.Trim().Length > 0)
            {
                reservereason = TxtReserveReason.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("أدخل سبب الحجز", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

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


    }
}
