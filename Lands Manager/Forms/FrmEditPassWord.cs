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
    public partial class FrmEditPassWord : KryptonForm
    {
        Guid guid;

        bool LogIn;
        public FrmEditPassWord(Guid guid, bool LogIn)
        {
            InitializeComponent();
            this.LogIn = LogIn;

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            tbEditPassword.Fill();
            if (tbEditPassword.lstData.Count <= 0)
            {
                tbEditPassword va = new tbEditPassword();
                va.guid = Guid.NewGuid();
                va.password = string.Empty;
                DBConnect.StartTransAction();
                va.Insert();
                DBConnect.CommitTransAction();
                tbEditPassword.Fill();
            }

            this.guid = guid;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (LogIn && keyData == Keys.Enter)
            {
                BtnSave.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();
        }


        #region Binding
        private void InitBinding()
        {
            tbEditPassword.Fill();

            if (!LogIn)
                FillForm();
            else
            {
                this.Text = "أدخل كلمة مرور التعديل";
                BtnSave.Text = "موافق";
                TxtConfirm.Visible = LblConfirm.Visible = false;
            }

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            tbEditPassword.Fill();

            tbEditPassword rentnotify = tbEditPassword.lstData[0];

            DataGUIAttribute.AssignFormValues<tbEditPassword>(this, rentnotify);

            TxtPassword.Text = TxtConfirm.Text = rentnotify.password;


        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbEditPassword>(this, new tbEditPassword());
            DataGUIAttribute.ClearFormControls<tbEditPassword>(this, new tbEditPassword());


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
            if (LogIn)
            {
                if (!TxtPassword.Text.Equals(tbEditPassword.lstData[0].password))
                {
                    MessageBox.Show("كلمة المرور غير صحيحة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPassword.Text = string.Empty;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }


            }
            else
            {
                tbEditPassword rentnotify = new tbEditPassword();

                rentnotify.guid = Guid.NewGuid();
                if (!TxtPassword.Text.Equals(TxtConfirm.Text))
                {
                    MessageBox.Show("تأكيد كلمة المرور غير مطابق", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataGUIAttribute.AssignObjectValues<tbEditPassword>(this, rentnotify);
                rentnotify.password = TxtPassword.Text;

                if (MessageBox.Show("هل أنت متأكد من الحفظ ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                DBConnect.StartTransAction();

                rentnotify.DeleteALL();
                rentnotify.Insert();

                if (DBConnect.CommitTransAction())
                {

                    ShowConfirm();
                    this.Close();

                }
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
            //CmbType.Items.AddRange(tbEditPassword.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }

        private void LblHint_Click(object sender, EventArgs e)
        {

        }
    }
}
