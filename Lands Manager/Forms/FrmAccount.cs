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

namespace DoctorERP
{
    public partial class FrmAccount : KryptonForm
    {
        Guid guid;
        BindingSource bs;
        bool isNew;
        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool ShowConfirmMSG = true;


        public tbAccount AddedAgents = new tbAccount();
        bool AddFromSelect;

        public FrmAccount(Guid guid, bool isNew, bool AddFromSelect)
        {
            InitializeComponent();
            dirtytracker = new WinformsDirtyTracking.DirtyTracker(this);


            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            this.guid = guid;
            this.AddFromSelect = AddFromSelect;
            BtnEdit.Visible = true;
            BtnAdd.Visible = false;

            this.isNew = isNew;


            if (AddFromSelect)
            {
                bindingNavigator1.Enabled = false;


            }

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

            dirtytracker.MarkAsClean();
        }


        #region Binding
        private void InitBinding()
        {
            tbAccount.Fill();
            bs = new BindingSource(tbAccount.lstData, string.Empty);
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbAccount.lstData.FindIndex(delegate (tbAccount mat) { return mat.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbAccount obj = (tbAccount)bs.Current;

                if (obj.guid.Equals(Guid.Empty))
                {


                    BtnAdd.Visible = true;
                    BtnEdit.Visible = false;
                    BtnDelete.Enabled = false;

                }
                FillForm();
                dirtytracker.MarkAsClean();
            }
            catch
            {



                dirtytracker.MarkAsClean();

            }
        }

        private void FillForm()
        {
            if (bs.Count > 0)
            {
                tbAccount mat = (tbAccount)bs.Current;

                DataGUIAttribute.AssignFormValues<tbAccount>(this, mat);




                BtnDelete.Enabled = true;
                BtnEdit.Visible = true;
                BtnAdd.Visible = false;
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
            DataGUIAttribute.AssignFormValues<tbAccount>(this, new tbAccount());
            DataGUIAttribute.ClearFormControls<tbAccount>(this, new tbAccount());


            FillCmb();

            dirtytracker.MarkAsClean();
        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbAccount obj = (tbAccount)bs[i];
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
            NewFill();

            BtnAdd.Visible = true;
            BtnEdit.Visible = false;
            isNew = true;
            BtnDelete.Enabled = false;


            Clear();
            bs.AddNew();
            bindingNavigatorPositionItem.Text = string.Empty;


        }

        bool Add()
        {
            if (!FrmMain.currentuser.CanAdd)
            {
                MessageBox.Show(("لا تملك صلاحية للقيام بهذا العمل"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            tbAccount mat = new tbAccount();


            if (TxtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("الاسم غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //if (TxtMobile.Text.Trim().Equals(string.Empty))
            //{
            //    MessageBox.Show("رقم الجوال غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (tbAccount.IsExist("Mobile", TxtMobile.Text) && TxtMobile.Text != string.Empty)
            //{
            //    MessageBox.Show(("رقم الجوال مكرر"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}



            mat.guid = Guid.NewGuid();



            DataGUIAttribute.AssignObjectValues<tbAccount>(this, mat);

            mat.number = tbAccount.GetMaxNumber("Number") + 1;






            if (ShowConfirmMSG)
            {
                if (MessageBox.Show(("هل أنت متأكد من الإضافة ؟"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }
            mat.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;



            DBConnect.StartTransAction();
            tbLog.AddLog("إضافة", "بطاقة مالك", TxtName.Text);

            mat.Insert();

            if (DBConnect.CommitTransAction())
            {
                bs.Add(mat);
                ShowConfirm();

                AddedAgents = mat;

                Clear();

                bs.MoveLast();
            }

            BtnAdd.Visible = false;
            BtnEdit.Visible = true;
            dirtytracker.MarkAsClean();
            isNew = false;
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Add())
            {
                if (AddFromSelect)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    BtnNew.PerformClick();
            }

            dirtytracker.MarkAsClean();

        }

        bool Edit()
        {
            if (!FrmMain.currentuser.CanEdit)
            {
                MessageBox.Show(("لا تملك صلاحية للقيام بهذا العمل"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            tbAccount mat = (tbAccount)bs.Current;

            if (TxtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("الاسم غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //if (TxtMobile.Text.Trim().Equals(string.Empty))
            //{
            //    MessageBox.Show("رقم الجوال غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (TxtMobile.Text != string.Empty)
            //{
            //    if (tbAccount.IsExist("mobile", TxtMobile.Text) && TxtMobile.Text != mat.Mobile.ToString())
            //    {
            //        MessageBox.Show(("رقم الجوال مكرر"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //}



            if (ShowConfirmMSG)
            {
                if (MessageBox.Show(("هل أنت متأكد من التعديل ؟"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }

            DataGUIAttribute.AssignObjectValues<tbAccount>(this, mat);




            mat.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            DBConnect.StartTransAction();
            tbLog.AddLog("تعديل", "بطاقة مالك", TxtName.Text);
            mat.Update();

            if (DBConnect.CommitTransAction())
            {
                ShowConfirm();

                dirtytracker.MarkAsClean();
                isNew = false;
            }
            return true;
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show(("لا تملك صلاحية للقيام بهذا العمل"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            tbAccount mat = (tbAccount)bs.Current;

            if (tbPay.IsExist("accoutguid", mat.guid))
            {
                MessageBox.Show("لا يمكن حذف الحساب لأنه مستخدم في السندات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }



            if (MessageBox.Show(("هل أنت متأكد من الحذف ؟"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;







            DBConnect.StartTransAction();
            tbLog.AddLog("حذف", this.Text, mat.name.ToString());
            mat.Delete();

            if (DBConnect.CommitTransAction())
            {
                bs.RemoveCurrent();
                bs.MoveLast();
                ShowConfirm();
                Clear();
                BtnNew.PerformClick();
                dirtytracker.MarkAsClean();
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



        void FillCmb()
        {

        }


        bool SimulatExit()
        {
            if (dirtytracker.IsDirty)
            {
                DialogResult msgboxres = MessageBox.Show(("هل تريد حفظ التغيرات ؟"), Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (msgboxres == DialogResult.Yes)
                {
                    ShowConfirmMSG = false;
                    if (BtnAdd.Visible)
                    {
                        if (!Add())
                        {
                            return true;
                        }
                    }
                    else if (BtnEdit.Visible)
                    {
                        if (!Edit())
                        {
                            return true;
                        }
                    }
                }
                else if (msgboxres == DialogResult.Cancel)
                {
                    return true;
                }
            }

            return false;
        }

        private void FrmMat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AddFromSelect)
            {
                bool estate = SimulatExit();
                e.Cancel = estate;
            }

        }




        bool IsPermissionGranted(string PermissionName)
        {
            if (FrmMain.currentuser.IsAdmin)
                return true;


            tbUsersPermissions userper = tbUsersPermissions.FindBy("UserGuid", FrmMain.currentuser.guid, PermissionName);
            return userper.PermissionValue;
        }




    }
}
