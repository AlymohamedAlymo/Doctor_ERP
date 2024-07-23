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
    public partial class FrmVATSettings : KryptonForm
    {
        Guid guid;


        public FrmVATSettings(Guid guid)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            tbVATSettings.Fill();
            if (tbVATSettings.lstData.Count <= 0)
            {
                tbVATSettings va = new tbVATSettings();
                va.Guid = Guid.NewGuid();
                va.VATID = string.Empty;
                va.CompanyName = string.Empty;
                DBConnect.StartTransAction();
                va.Insert();
                DBConnect.CommitTransAction();
                tbVATSettings.Fill();
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
            tbVATSettings.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            tbVATSettings.Fill();

            tbVATSettings rentnotify = tbVATSettings.lstData[0];

            DataGUIAttribute.AssignFormValues<tbVATSettings>(this, rentnotify);



        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbVATSettings>(this, new tbVATSettings());
            DataGUIAttribute.ClearFormControls<tbVATSettings>(this, new tbVATSettings());


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
            tbVATSettings rentnotify = new tbVATSettings();

            rentnotify.Guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbVATSettings>(this, rentnotify);

            if (MessageBox.Show("هل أنت متأكد من الحفظ ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            DBConnect.StartTransAction();

            rentnotify.DeleteALL();
            rentnotify.Insert();

            if (DBConnect.CommitTransAction())
            {

                ShowConfirm();


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
            //CmbType.Items.AddRange(tbVATSettings.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }

        private void LblHint_Click(object sender, EventArgs e)
        {

        }
    }
}
