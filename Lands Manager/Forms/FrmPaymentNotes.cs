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
    public partial class FrmPaymentNotes : KryptonForm
    {
        Guid guid;


        public FrmPaymentNotes(Guid guid)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            tbPaymentsNotes.Fill();
            if (tbPaymentsNotes.lstData.Count <= 0)
            {
                tbPaymentsNotes va = new tbPaymentsNotes();
                va.guid = Guid.NewGuid();
                va.landpricenotes = string.Empty;
                va.workfeenotes = string.Empty;
                va.vatnotes = string.Empty;
                va.discountnotes = string.Empty;

                DBConnect.StartTransAction();
                va.Insert();
                DBConnect.CommitTransAction();
                tbPaymentsNotes.Fill();
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
            tbPaymentsNotes.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            tbPaymentsNotes.Fill();

            tbPaymentsNotes rentnotify = tbPaymentsNotes.lstData[0];

            DataGUIAttribute.AssignFormValues<tbPaymentsNotes>(this, rentnotify);



        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbPaymentsNotes>(this, new tbPaymentsNotes());
            DataGUIAttribute.ClearFormControls<tbPaymentsNotes>(this, new tbPaymentsNotes());


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
            tbPaymentsNotes rentnotify = new tbPaymentsNotes();

            rentnotify.guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbPaymentsNotes>(this, rentnotify);

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
            //CmbType.Items.AddRange(tbPaymentsNotes.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }

        private void LblHint_Click(object sender, EventArgs e)
        {

        }
    }
}
