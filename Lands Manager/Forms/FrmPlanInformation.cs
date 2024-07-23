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
using WinformsDirtyTracking;


namespace DoctorERP
{
    public partial class FrmPlanInformation : KryptonForm
    {
        Guid guid;


        public FrmPlanInformation(Guid guid)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            tbAgent.Fill("AgentType", 0);
            FillCmb();
            tbPlanInfo.Fill();
            tbLand.Fill();
            if (tbPlanInfo.lstData.Count <= 0)
            {
                tbPlanInfo plan = new tbPlanInfo();
                plan.guid = Guid.NewGuid();
                plan.name = string.Empty;
                plan.ownerguid = tbAgent.lstData[0].guid;
                plan.location = string.Empty;
                plan.number = string.Empty;
                DBConnect.StartTransAction();
                plan.Insert();
                DBConnect.CommitTransAction();
            }

            this.guid = guid;

            if (!FrmMain.currentuser.IsAdmin)
            {
                TxtName.ReadOnly = true;
                TxtName.StateCommon.Back.Color1 = SystemColors.Control;

                TxtCity.ReadOnly = true;
                TxtCity.StateCommon.Back.Color1 = SystemColors.Control;

                Txtlocation.ReadOnly = true;
                Txtlocation.StateCommon.Back.Color1 = SystemColors.Control;

                Txtnumber.ReadOnly = true;
                Txtnumber.StateCommon.Back.Color1 = SystemColors.Control;

                TxtAttachment.ReadOnly = true;
                TxtAttachment.StateCommon.Back.Color1 = SystemColors.Control;

                TxtAttachment2.ReadOnly = true;
                TxtAttachment2.StateCommon.Back.Color1 = SystemColors.Control;


                TxtAttach3.ReadOnly = true;
                TxtAttach3.StateCommon.Back.Color1 = SystemColors.Control;
                TxtAttach4.ReadOnly = true;
                TxtAttach4.StateCommon.Back.Color1 = SystemColors.Control;


                BtnDelete4.Visible = BtnBrowse4.Visible = BtnDeleteAttach3.Visible = BtnBrowse3.Visible = BtnDeleteAttach.Visible = BtnDeleteAttachment2.Visible = BtnBrowse2.Visible = BtnBrowseAttach.Visible = false;

                BtnSave.Visible = false;
            }

            vwLandsType.Fill();
            DataGridMain.DataSource = vwLandsType.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwLandsType));

            DataGridMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TxtLandsCount.Text = tbLand.lstData.Count.ToString();
            TxtLandReserve.Text = tbLand.lstData.Where(x => x.status == "محجوز").Count().ToString();
            TxtLandSold.Text = tbLand.lstData.Where(x => x.status == "مباع").Count().ToString();
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();
        }


        #region Binding
        private void InitBinding()
        {
            tbPlanInfo.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {

            tbPlanInfo planinfo = tbPlanInfo.lstData[0];

            DataGUIAttribute.AssignFormValues<tbPlanInfo>(this, planinfo);

            tbAgent agent = tbAgent.FindBy("Guid", tbAgent.lstData[0].guid);
            TxtSelectOwner.Text = agent.name;
            TxtSelectOwner.Tag = agent;

            tbAttachment attach = tbAttachment.FindByFull("ParentGuid", planinfo.guid, "map");
            TxtAttachment.Tag = attach;
            TxtAttachment.Text = attach.FileName;


            tbAttachment attach2 = tbAttachment.FindByFull("ParentGuid", planinfo.guid, "area");
            TxtAttachment2.Tag = attach2;
            TxtAttachment2.Text = attach2.FileName;


            tbAttachment attach3 = tbAttachment.FindByFull("ParentGuid", planinfo.guid, "prices");
            TxtAttach3.Tag = attach3;
            TxtAttach3.Text = attach3.FileName;

            tbAttachment attach4 = tbAttachment.FindByFull("ParentGuid", planinfo.guid, "other");
            TxtAttach4.Tag = attach4;
            TxtAttach4.Text = attach4.FileName;


            tbLand.Fill();




        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbPlanInfo>(this, new tbPlanInfo());
            DataGUIAttribute.ClearFormControls<tbPlanInfo>(this, new tbPlanInfo());


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
            tbPlanInfo planinfo = tbPlanInfo.lstData[0];



            DataGUIAttribute.AssignObjectValues<tbPlanInfo>(this, planinfo);

            if (MessageBox.Show("هل أنت متأكد من الحفظ ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbAgent agent = (tbAgent)TxtSelectOwner.Tag;
            planinfo.ownerguid = agent.guid;

            DBConnect.StartTransAction();

            planinfo.DeleteALL();
            planinfo.Insert();

            AddAttachments(planinfo.guid);
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

        #region Attachment
        private void BtnBrowseAttach_Click(object sender, EventArgs e)
        {
            string filename = FileHelper.OpenAndGetFileName();
            if (filename.Equals(string.Empty))
                return;

            tbAttachment attach = new tbAttachment();
            attach.Guid = Guid.NewGuid();
            attach.ParentGuid = Guid.Empty;
            attach.Name = "map";
            attach.FileData = FileHelper.FileToByteArray(filename);
            attach.FileName = FileHelper.GetFileNameWithOutPath(filename);
            attach.FileSize = string.Empty;

            TxtAttachment.Tag = attach;
            TxtAttachment.Text = FileHelper.GetFileNameWithOutPath(filename);
        }

        private void BtnSaveAttach_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttachment.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;
            try
            {
                if (FileHelper.SaveFile(attach.FileName, attach.FileData))
                    MessageBox.Show("تم حفظ الملف‌", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteAttach_Click(object sender, EventArgs e)
        {
            TxtAttachment.Tag = new tbAttachment();
            TxtAttachment.Text = string.Empty;
        }

        private void BtnPreviewAttach_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttachment.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;

            FileHelper.RunFile(attach.FileName, attach.FileData);
        }

        private void BtnBrowseAttach2_Click(object sender, EventArgs e)
        {
            string filename = FileHelper.OpenAndGetFileName();
            if (filename.Equals(string.Empty))
                return;

            tbAttachment attach = new tbAttachment();
            attach.Guid = Guid.NewGuid();
            attach.ParentGuid = Guid.Empty;
            attach.Name = "area";
            attach.FileData = FileHelper.FileToByteArray(filename);
            attach.FileName = FileHelper.GetFileNameWithOutPath(filename);
            attach.FileSize = string.Empty;

            TxtAttachment2.Tag = attach;
            TxtAttachment2.Text = FileHelper.GetFileNameWithOutPath(filename);
        }

        private void BtnSaveAttach2_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttachment2.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;
            try
            {
                if (FileHelper.SaveFile(attach.FileName, attach.FileData))
                    MessageBox.Show("تم حفظ الملف‌", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete2Attach_Click(object sender, EventArgs e)
        {
            TxtAttachment2.Tag = new tbAttachment();
            TxtAttachment2.Text = string.Empty;
        }

        private void BtnPreview2Attach_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttachment2.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;

            FileHelper.RunFile(attach.FileName, attach.FileData);
        }

        private void BtnBrowseAttach3_Click(object sender, EventArgs e)
        {
            string filename = FileHelper.OpenAndGetFileName();
            if (filename.Equals(string.Empty))
                return;

            tbAttachment attach = new tbAttachment();
            attach.Guid = Guid.NewGuid();
            attach.ParentGuid = Guid.Empty;
            attach.Name = "prices";
            attach.FileData = FileHelper.FileToByteArray(filename);
            attach.FileName = FileHelper.GetFileNameWithOutPath(filename);
            attach.FileSize = string.Empty;

            TxtAttach3.Tag = attach;
            TxtAttach3.Text = FileHelper.GetFileNameWithOutPath(filename);
        }

        private void BtnSaveAttach3_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeleteAttach3_Click(object sender, EventArgs e)
        {
            TxtAttach3.Tag = new tbAttachment();
            TxtAttach3.Text = string.Empty;
        }

        private void BtnPreviewAttach3_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttach3.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;

            FileHelper.RunFile(attach.FileName, attach.FileData);
        }


        private void BtnBrowseAttach4_Click(object sender, EventArgs e)
        {
            string filename = FileHelper.OpenAndGetFileName();
            if (filename.Equals(string.Empty))
                return;

            tbAttachment attach = new tbAttachment();
            attach.Guid = Guid.NewGuid();
            attach.ParentGuid = Guid.Empty;
            attach.Name = "other";
            attach.FileData = FileHelper.FileToByteArray(filename);
            attach.FileName = FileHelper.GetFileNameWithOutPath(filename);
            attach.FileSize = string.Empty;

            TxtAttach4.Tag = attach;
            TxtAttach4.Text = FileHelper.GetFileNameWithOutPath(filename);
        }

        private void BtnSaveAttach4_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttach4.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;
            try
            {
                if (FileHelper.SaveFile(attach.FileName, attach.FileData))
                    MessageBox.Show("تم حفظ الملف‌", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteAttach4_Click(object sender, EventArgs e)
        {
            TxtAttach4.Tag = new tbAttachment();
            TxtAttach4.Text = string.Empty;
        }

        private void BtnPreviewAttach4_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttach4.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;

            FileHelper.RunFile(attach.FileName, attach.FileData);
        }

        private void AddAttachments(Guid ParentGuid)
        {
            tbAttachment attachmentdelete = new tbAttachment();
            attachmentdelete.DeleteBy("ParentGuid", ParentGuid);

            tbAttachment attachment = (tbAttachment)TxtAttachment.Tag;
            attachment.ParentGuid = ParentGuid;
            if (attachment.Guid.Equals(Guid.Empty))
            {
                attachment.FileData = new Byte[0];
            }
            else
            {
                attachment.Insert();
            }


            tbAttachment attachment2 = (tbAttachment)TxtAttachment2.Tag;
            attachment2.ParentGuid = ParentGuid;
            if (attachment2.Guid.Equals(Guid.Empty))
            {
                attachment2.FileData = new Byte[0];
            }
            else
            {
                attachment2.Insert();
            }

            tbAttachment attachment3 = (tbAttachment)TxtAttach3.Tag;
            attachment3.ParentGuid = ParentGuid;
            if (attachment3.Guid.Equals(Guid.Empty))
            {
                attachment3.FileData = new Byte[0];
            }
            else
            {
                attachment3.Insert();
            }

            tbAttachment attachment4 = (tbAttachment)TxtAttach4.Tag;
            attachment4.ParentGuid = ParentGuid;
            if (attachment4.Guid.Equals(Guid.Empty))
            {
                attachment4.FileData = new Byte[0];
            }
            else
            {
                attachment4.Insert();
            }
        }

        #endregion

        #region Select Owner
        private void TxtSelectOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAgent.Fill("name", TxtSelectOwner.Text, 0);
                if (tbAgent.dtData.Rows.Count == 1)
                {
                    tbAgent selectedobject = tbAgent.FindBy("guid", new Guid(tbAgent.dtData.Rows[0]["guid"].ToString()));
                    TxtSelectOwner.Tag = selectedobject;
                    TxtSelectOwner.Text = selectedobject.name;


                    TxtSelectOwner.Tag = selectedobject;
                    TxtSelectOwner.Text = selectedobject.name;

                }
                else if (tbAgent.dtData.Rows.Count == 0)
                {
                    tbAgent.Fill("name", " ", 0);
                    ShowSelectOwner();
                }
                else
                {
                    ShowSelectOwner();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                //TxtSelectOwner.Tag = new tbAgent();
                //TxtSelectOwner.Text = string.Empty;
            }
        }

        private void ShowSelectOwner()
        {
            FrmSelect frmselect = new FrmSelect("إختيار مالك", typeof(tbAgent), tbAgent.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbAgent selectedobject = tbAgent.FindBy("guid", frmselect.guid);
                TxtSelectOwner.Tag = selectedobject;
                TxtSelectOwner.Text = selectedobject.name;


                TxtSelectOwner.Tag = selectedobject;
                TxtSelectOwner.Text = selectedobject.name;

            }
            else
            {
                TxtSelectOwner.Tag = new tbAgent();
                TxtSelectOwner.Text = string.Empty;
            }
        }


        private void BtnShowOwnerCard_Click(object sender, EventArgs e)
        {
            tbAgent selectedobject = (tbAgent)TxtSelectOwner.Tag;
            if (!selectedobject.guid.Equals(Guid.Empty))
            {
                FrmAgent frmtable = new FrmAgent(selectedobject.guid, false, selectedobject.agenttype, false);
                frmtable.ShowDialog();
                FillForm();
            }
            else
            {
                MessageBox.Show("يجب إختيار مالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnSeacrhOwner_Click(object sender, EventArgs e)
        {
            TxtSelectOwner_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void BtnAddOwner_Click(object sender, EventArgs e)
        {
            FrmAgent frm = new FrmAgent(Guid.Empty, true, 0, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TxtSelectOwner.Tag = frm.AddedAgents;
                TxtSelectOwner.Text = frm.AddedAgents.name;
            }
        }
        #endregion


        BindingSource bs;


        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            if (!FrmMain.currentuser.CanAdd)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbPlanInfo.Fill();
            bs = new BindingSource(tbPlanInfo.lstData, string.Empty);

            bs.AddNew();

            if (Add())
            {



                DialogResult = DialogResult.OK;

            }


        }
        bool Add()
        {
            tbPlanInfo land = new tbPlanInfo();
            DataGUIAttribute.AssignObjectValues<tbPlanInfo>(this, land);

            land.guid = Guid.NewGuid();
            land.name = TxtName.Text;


            //if (Txtcode.Text.Trim().Equals(string.Empty))
            //{
            //    MessageBox.Show("كود الصنف غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}



            //if (Txtblocknumber.Text.Trim().Equals(string.Empty))
            //{
            //    MessageBox.Show("رقم البلوك غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (Txtdeednumber.Text.Trim().Equals(string.Empty))
            //{
            //    MessageBox.Show("رقم الصك غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (tbLand.IsExist("deednumber", Txtdeednumber.Text))
            //{
            //    MessageBox.Show("رقم الصك مكرر", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}


            //if (ShowConfirmMSG)
            //{
            //    if (MessageBox.Show("هل أنت متاكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            //        return false;
            //}


            DBConnect.StartTransAction();


            AddAttachments(land.guid);
            land.Insert();


            if (DBConnect.CommitTransAction())
            {
                bs.Add(land);
                ShowConfirm();

                bs.MoveLast();
            }

            return true;

        }


    }
}
