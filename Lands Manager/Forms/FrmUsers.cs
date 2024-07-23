using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace DoctorERP
{
    public partial class FrmUsers : KryptonForm
    {
        BindingSource bs;
        Guid guid;

        public FrmUsers(Guid guid)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.guid = guid;

            FillCmb();

            for (int i = 0; i < checkListRules.Items.Count; i++)
            {
                checkListRules.Items[i] = checkListRules.Items[i].ToString();
            }
        }

        #region Binding
        private void InitBinding()
        {
            tbUsers.Fill();
            bs = new BindingSource(tbUsers.lstData, "");
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbUsers.lstData.FindIndex(delegate (tbUsers tbuser) { return tbuser.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            if (bs.Count > 0)
            {
                tbUsers tbuser = (tbUsers)bs.Current;
                TxtName.Text = tbuser.name;
                TxtConfirm.Text = TxtPassword.Text = tbuser.password;
                CheckBoxIsAdmin.Checked = tbuser.IsAdmin;


                if (tbuser.CanAdd)
                    checkListRules.SetItemCheckState(0, CheckState.Checked);
                else
                    checkListRules.SetItemCheckState(0, CheckState.Unchecked);

                if (tbuser.CanEdit)
                    checkListRules.SetItemCheckState(1, CheckState.Checked);
                else
                    checkListRules.SetItemCheckState(1, CheckState.Unchecked);

                if (tbuser.CanDelete)
                    checkListRules.SetItemCheckState(2, CheckState.Checked);
                else
                    checkListRules.SetItemCheckState(2, CheckState.Unchecked);

                if (tbuser.CanPrint)
                    checkListRules.SetItemCheckState(3, CheckState.Checked);
                else
                    checkListRules.SetItemCheckState(3, CheckState.Unchecked);

                FillPermissions(tbuser.guid);


                BtnEdit.Enabled = BtnDelete.Enabled = true;
            }
            else
            {
                NewFill();
                BtnEdit.Enabled = BtnDelete.Enabled = false;
            }

        }

        private void NewFill()
        {
            TxtName.Text = string.Empty;
            TxtConfirm.Text = TxtPassword.Text = string.Empty;
          
            CheckBoxIsAdmin.Checked = false;
            for (int i = 0; i < checkListRules.Items.Count; i++)
                checkListRules.SetItemCheckState(i, CheckState.Unchecked);

            FillPermissions(Guid.Empty);

        }
        #endregion

        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewFill();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            tbUsers tbuser = new tbUsers();

            if (TxtName.Text.Equals(string.Empty))
            {
                MessageBox.Show("يجب إدخال اسم المستخدم", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (tbUsers.IsExist("name", TxtName.Text))
            {
                MessageBox.Show("اسم المستخدم معرف مسبقا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            if (TxtConfirm.Text != TxtPassword.Text)
            {
                MessageBox.Show("كلمة مرور التأكيد غير متطابقة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            tbuser.guid = Guid.NewGuid();
            tbuser.name = TxtName.Text;
            tbuser.password = TxtPassword.Text;
            tbuser.IsAdmin = CheckBoxIsAdmin.Checked;
            
            if (checkListRules.GetItemCheckState(0) == CheckState.Checked)
                tbuser.CanAdd = true;
            else
                tbuser.CanAdd = false;

            if (checkListRules.GetItemCheckState(1) == CheckState.Checked)
                tbuser.CanEdit = true;
            else
                tbuser.CanEdit = false;

            if (checkListRules.GetItemCheckState(2) == CheckState.Checked)
                tbuser.CanDelete = true;
            else
                tbuser.CanDelete = false;

            if (checkListRules.GetItemCheckState(3) == CheckState.Checked)
                tbuser.CanPrint = true;
            else
                tbuser.CanPrint = false;


            DBConnect.StartTransAction();
            AddPermissions(tbuser.guid);
            tbuser.Insert();

            if (DBConnect.CommitTransAction())
            {
                bs.Add(tbuser);
                ShowConfirm();
                bs.MoveLast();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            tbUsers tbuser = (tbUsers)bs.Current;

            if (TxtName.Text.Equals(string.Empty))
            {
                MessageBox.Show("يجب إدخال اسم المستخدم", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (tbUsers.IsExist("name", TxtName.Text) && TxtName.Text != tbuser.name)
            {
                MessageBox.Show("اسم المستخدم معرف مسبقا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        

            if (tbUsers.GetCount("IsAdmin", 1) <= 1 && tbuser.IsAdmin && !CheckBoxIsAdmin.Checked)
            {
                MessageBox.Show("لا يمكن إزالة صلاحية المسؤول لهذا المستخدم لأنه المسؤول الوحيد المتبقي", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (TxtConfirm.Text != TxtPassword.Text)
            {
                MessageBox.Show("كلمة مرور التأكيد غير متطابقة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            tbuser.name = TxtName.Text;
            tbuser.password = TxtPassword.Text;
            tbuser.IsAdmin = CheckBoxIsAdmin.Checked;

            if (checkListRules.GetItemCheckState(0) == CheckState.Checked)
                tbuser.CanAdd = true;
            else
                tbuser.CanAdd = false;

            if (checkListRules.GetItemCheckState(1) == CheckState.Checked)
                tbuser.CanEdit = true;
            else
                tbuser.CanEdit = false;

            if (checkListRules.GetItemCheckState(2) == CheckState.Checked)
                tbuser.CanDelete = true;
            else
                tbuser.CanDelete = false;

            if (checkListRules.GetItemCheckState(3) == CheckState.Checked)
                tbuser.CanPrint = true;
            else
                tbuser.CanPrint = false;



            DBConnect.StartTransAction();
            AddPermissions(tbuser.guid);
            tbuser.Update();

            if (DBConnect.CommitTransAction())
            {
                ShowConfirm();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            tbUsers tbuser = (tbUsers)bs.Current;

            if (tbUsers.GetCount("IsAdmin", 1) <= 1 && tbuser.IsAdmin)
            {
                MessageBox.Show("لا يمكن حذف هذا المستخدم لأنه مسؤول البرنامج الوحيد", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbUsersPermissions permessions = new tbUsersPermissions();

            DBConnect.StartTransAction();

            permessions.DeleteBy("UserGuid", tbuser.guid);
            tbuser.Delete();

            if (DBConnect.CommitTransAction())
            {
                bs.RemoveCurrent();

                ShowConfirm();
                bs.MoveLast();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        void FillCmb()
        {
            
        }

        private void ShowConfirm()
        {
            FrmConfirm frmconfirm = new FrmConfirm();
            frmconfirm.ShowDialog();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            InitBinding();
        }


        private void CheckBoxIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            checkListRules.Enabled = !CheckBoxIsAdmin.Checked;
        }

        void AddPermissions(Guid userguid)
        {
            tbUsersPermissions permessions = new tbUsersPermissions();
            permessions.DeleteBy("UserGuid", userguid);


            for (int i = 0; i < ChkLstPermissions.Items.Count; i++)
            {
                tbUsersPermissions userper = new tbUsersPermissions();
                userper.Guid = Guid.NewGuid();
                userper.PermissionName = ChkLstPermissions.Items[i].ToString();
                if (ChkLstPermissions.GetItemCheckState(i) == CheckState.Checked)
                {
                    userper.PermissionValue = true;
                }
                else
                {
                    userper.PermissionValue = false;
                }
                userper.UserGuid = userguid;
                userper.Insert();
            }
        }


        void FillPermissions(Guid userguid)
        {
            tbUsersPermissions.Fill("UserGuid", userguid);

            for (int i = 0; i < ChkLstPermissions.Items.Count; i++)
            {
                tbUsersPermissions userper = tbUsersPermissions.FindBy("UserGuid", userguid, ChkLstPermissions.Items[i].ToString());
                if (userper.PermissionValue)
                    ChkLstPermissions.SetItemCheckState(i, CheckState.Checked);
                else
                    ChkLstPermissions.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void ChkLstPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkLstPermissions.Items.Count; i++)
            {
                ChkLstPermissions.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void BtnSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkLstPermissions.Items.Count; i++)
            {
                ChkLstPermissions.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
