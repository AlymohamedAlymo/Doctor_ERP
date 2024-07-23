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
    public partial class FrmSMSSettings : KryptonForm
    {
        Guid guid;


        public FrmSMSSettings(Guid guid)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();


            this.guid = guid;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();
        }


        #region Binding
        private void InitBinding()
        {
            tbSMSsettings.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {

            tbSMSsettings smssettings = tbSMSsettings.lstData[0];

            DataGUIAttribute.AssignFormValues<tbSMSsettings>(this, smssettings);



        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbSMSsettings>(this, new tbSMSsettings());
            DataGUIAttribute.ClearFormControls<tbSMSsettings>(this, new tbSMSsettings());


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
            tbSMSsettings smssettings = new tbSMSsettings();

            smssettings.guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbSMSsettings>(this, smssettings);

            if (MessageBox.Show("هل أنت متأكد من الحفظ ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            DBConnect.StartTransAction();

            smssettings.DeleteALL();
            smssettings.Insert();

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
            //CmbType.Items.AddRange(tbSMSSettings.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }

        private void LblHint_Click(object sender, EventArgs e)
        {

        }
    }
}
