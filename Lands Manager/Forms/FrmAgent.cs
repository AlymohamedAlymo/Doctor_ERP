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
using SmartArabXLSX.Wordprocessing;
using DevExpress.XtraPrinting.Export.Pdf;
using System.Reflection;

namespace DoctorERP
{
    public partial class FrmAgent : KryptonForm
    {
        Guid guid;
        BindingSource bs;

        bool isNew;
        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool ShowConfirmMSG = true;
        int agenttype;

        public tbAgent AddedAgents = new tbAgent();
        bool AddFromSelect;
        public FrmAgent(Guid guid, bool isNew, int agenttype, bool AddFromSelect)
        {
            InitializeComponent();

            dirtytracker = new WinformsDirtyTracking.DirtyTracker(this);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            this.guid = guid;
            this.agenttype = agenttype;
            if (agenttype == 0)
            {
                this.Text = "تعريف المالك";
                BtnNew.Visible = false;
                BtnAdd.Visible = false;
                BtnEdit.Enabled = true;
                BtnEdit.Text = "حفظ";
                bindingNavigator1.Enabled = false;
                BtnDelete.Visible = false;
            }
            else
            {
                this.Text = "بطاقة عميل";
                grpOffice.Visible = false;
            }
            this.AddFromSelect = AddFromSelect;
            BtnEdit.Visible = true;
            BtnAdd.Visible = false;

            if (AddFromSelect)
            {
                bindingNavigator1.Enabled = false;


            }

            this.isNew = isNew;


        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();

            if (isNew)
            {
                BtnNew.PerformClick();

                if (agenttype == 1)
                {
                    BtnAdd.Visible = true;
                    BtnEdit.Visible = false;
                }
            }

            dirtytracker.MarkAsClean();
        }


        #region Binding
        private void InitBinding()
        {
            tbAgent.Fill("agenttype", agenttype);
            bs = new BindingSource(tbAgent.lstData, string.Empty);
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbAgent.lstData.FindIndex(delegate (tbAgent agent) { return agent.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbAgent obj = (tbAgent)bs.Current;

                if (obj.guid.Equals(Guid.Empty))
                {
                    ClearAttachmentsGrid();

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
                tbAgent agent = (tbAgent)bs.Current;

                DataGUIAttribute.AssignFormValues<tbAgent>(this, agent);
                FillDataGridAttachments(agent.guid);

                if (agent is null || agent.guid.Equals(Guid.Empty))
                {
                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    BtnAdd.Visible = true;
                }
                else
                {
                    BtnDelete.Enabled = true;
                    BtnEdit.Visible = true;
                    BtnAdd.Visible = false;
                }
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
            DataGUIAttribute.AssignFormValues<tbAgent>(this, new tbAgent());
            DataGUIAttribute.ClearFormControls<tbAgent>(this, new tbAgent());

            ClearAttachmentsGrid();
            dirtytracker.MarkAsClean();
        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbAgent obj = (tbAgent)bs[i];
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
            isNew = true;

            BtnAdd.Visible = true;
            BtnEdit.Visible = false;
            BtnDelete.Enabled = false;

            FillCmb();
            Clear();

            bs.AddNew();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanAdd)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Add())
                if (AddFromSelect)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    BtnNew.PerformClick();

            dirtytracker.MarkAsClean();
        }

        bool Add()
        {


            tbAgent agent = new tbAgent();

            DataGUIAttribute.AssignObjectValues<tbAgent>(this, agent);

            agent.guid = Guid.NewGuid();

            if (TxtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("اسم العميل غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }





            if (ShowConfirmMSG)
            {
                if (MessageBox.Show("هل أنت متاكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }

            agent.number = tbAgent.GetMaxNumber("Number") + 1;
            agent.agenttype = agenttype;

            agent.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            DBConnect.StartTransAction();
            AddAttachments(agent.guid);
            agent.Insert();
            tbLog.AddLog("إضافة", "بطاقة عميل", agent.name.ToString());

            if (DBConnect.CommitTransAction())
            {
                bs.Add(agent);
                ShowConfirm();
                AddedAgents = agent;
                Clear();
                bs.MoveLast();
            }

            BtnAdd.Visible = false;
            BtnEdit.Visible = true;

            dirtytracker.MarkAsClean();
            isNew = false;
            return true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanEdit)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Edit();
        }

        bool Edit()
        {
            tbAgent agent = (tbAgent)bs.Current;



            if (TxtName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("الاسم غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }






            DataGUIAttribute.AssignObjectValues<tbAgent>(this, agent);




            if (ShowConfirmMSG)
            {
                if (MessageBox.Show("هل أنت متاكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }

            agent.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            DBConnect.StartTransAction();
            AddAttachments(agent.guid);
            tbLog.AddLog("تعديل", "بطاقة عميل", agent.name.ToString());
            agent.Update();

            if (DBConnect.CommitTransAction())
            {

                ShowConfirm();
                dirtytracker.MarkAsClean();
                isNew = false;

            }

            return true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbAgent agent = (tbAgent)bs.Current;


            if (tbBillheader.IsExist("ownerguid", agent.guid))
            {
                MessageBox.Show("لا يمكن حذف الحساب لأنه مستخدم في العقود", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (tbBillheader.IsExist("buyerguid", agent.guid))
            {
                MessageBox.Show("لا يمكن حذف الحساب لأنه مستخدم في العقود", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            tbAttachment attach = new tbAttachment();



            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            DBConnect.StartTransAction();


            attach.DeleteBy("ParentGuid", agent.guid);
            agent.Delete();
            tbLog.AddLog("حذف", this.Text, agent.name.ToString());
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
            //CmbAuth.Items.Clear();
            //CmbAuth.Items.AddRange(tbAgent.GetUniqueList("Auth").ToArray());

            //CmbCountry.Items.Clear();
            //CmbCountry.Items.AddRange(tbAgent.GetUniqueList("Country").ToArray());

            //CmbStoreLocation.Items.Clear();
            //CmbStoreLocation.Items.AddRange(tbAgent.GetUniqueList("StoreLocation").ToArray());

            //CmbItemType.Items.Clear();
            //CmbItemType.Items.AddRange(tbAgent.GetUniqueList("ItemType").ToArray());

            //CmbState.SelectedIndex = 1;
        }

        private void FrmPay_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool estate = SimulatExit();
            e.Cancel = estate;
        }

        bool SimulatExit()
        {
            //if (dirtytracker.IsDirty)
            //{
            //    DialogResult msgboxres = MessageBox.Show("هل تريد حفظ التغيرات", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (msgboxres == DialogResult.Yes)
            //    {
            //        ShowConfirmMSG = false;
            //        if (BtnAdd.Visible)
            //        {
            //            if (!Add())
            //            {
            //                return true;
            //            }
            //        }
            //        else if (BtnEdit.Visible)
            //        {
            //            if (!Edit())
            //            {

            //                return true;
            //            }
            //        }
            //    }
            //    else if (msgboxres == DialogResult.Cancel)
            //    {
            //        return true;
            //    }
            //}

            return false;
        }






        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            if (bs.Current == null)
            {
                MessageBox.Show("يجب حفظ البطاقة أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            tbAgent agent = (tbAgent)bs.Current;

            if (agenttype == 0)
                Reports.InitReport(rpt, "ownercard.frx", false);
            else
                Reports.InitReport(rpt, "agentcard.frx", false);

            tbAgent.Fill(agent.guid);

            tbAgent.Fill("agenttype", 0);

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");

          

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.RegisterData(tbAgent.dtData, "data");

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

        #region Attach
        private void ClearAttachmentsGrid()
        {
            tbAttachment.Fill(Guid.Empty);
            DataGridAttachments.DataSource = tbAttachment.dtData;
        }


        private void FillDataGridAttachments(Guid parentguid)
        {
            tbAttachment.Fill("ParentGuid", parentguid);
            DataGridAttachments.DataSource = tbAttachment.dtData;


        }

        private void AddAttachments(Guid parentguid)
        {
            foreach (DataGridViewRow dr in DataGridAttachments.Rows)
            {
                tbAttachment tbAttach = new tbAttachment();
                tbAttach.Guid = new Guid(dr.Cells[colguid.Name].Value.ToString());
                if (!tbAttachment.IsExistTrans(tbAttach.Guid, parentguid))
                {
                    dr.Cells[colguid.Name].Value = tbAttach.Guid = Guid.NewGuid();
                    tbAttach.ParentGuid = parentguid;
                    tbAttach.Name = dr.Cells[colname.Name].Value.ToString();
                    tbAttach.FileName = dr.Cells[colfilename.Name].Value.ToString();
                    tbAttach.FileSize = dr.Cells[colfilesize.Name].Value.ToString();
                    tbAttach.FileData = (byte[])dr.Cells[colfiledata.Name].Value;

                    tbAttach.Insert();
                }
            }

            UpdateAttachments(parentguid);
        }


        private void UpdateAttachments(Guid parentguid)
        {
            tbAttachment.FillTrans(parentguid);
            foreach (tbAttachment attach in tbAttachment.lstData)
            {
                if (!IsAttachExist(attach.Guid))
                {
                    tbAttachment tbAttach = new tbAttachment();
                    tbAttach.DeleteBy("Guid", attach.Guid);
                }

            }
        }

        bool IsAttachExist(Guid guid)
        {
            foreach (DataGridViewRow dr in DataGridAttachments.Rows)
            {
                Guid AttachGuid = new Guid(dr.Cells[colguid.Name].Value.ToString());
                if (AttachGuid.Equals(guid))
                    return true;
            }
            return false;
        }

        private void BtnAddAttachment_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.RestoreDirectory = true;
            opf.Filter = "All Files (*.*)|*.*";

            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                tbAttachment tbattach = new tbAttachment();
                tbattach.Guid = Guid.NewGuid();
                tbattach.ParentGuid = Guid.Empty;
                tbattach.Name = Path.GetFileName(opf.FileName);
                tbattach.FileName = tbattach.Name;
                tbattach.FileData = FileHelper.FileToByteArray(opf.FileName);
                if (tbattach.FileData.Length > 10000000)
                {
                    MessageBox.Show("لا يمكن إضافة مرفق بحجم أكبر من 10 ميغا بايت", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;


                tbattach.FileSize = string.Format(new FileSizeFormatProvider(), "{0:fs}", tbattach.FileData.Length);
                tbAttachment.dtData.Rows.Add(tbattach.Guid, tbattach.ParentGuid, tbattach.Name, tbattach.FileName, tbattach.FileSize, tbattach.FileData);
                DataGridAttachments.DataSource = tbAttachment.dtData;
                this.Cursor = Cursors.Arrow;


            }
        }

        private void DataGridAttachment_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridView.HitTestInfo hit = DataGridAttachments.HitTest(e.X, e.Y);
                    DataGridAttachments.CurrentCell = DataGridAttachments[hit.ColumnIndex, hit.RowIndex];
                    DataGridAttachments.ContextMenuStrip = ConMenuAttachments;

                }
            }
            catch
            {
                DataGridAttachments.ContextMenuStrip = null;

            }
        }

        private void MenuPreviewAttach_Click(object sender, EventArgs e)
        {
            byte[] bfiles = (byte[])DataGridAttachments[colfiledata.Name, DataGridAttachments.CurrentRow.Index].Value;
            Guid guid = new Guid(DataGridAttachments[colguid.Name, DataGridAttachments.CurrentRow.Index].Value.ToString());
            string filename = (string)DataGridAttachments[colfilename.Name, DataGridAttachments.CurrentRow.Index].Value;



            tbAttachment attach = tbAttachment.FindByFull("guid", guid);

            if (bfiles.Length <= 1)
                FileHelper.RunFile(attach.FileName, attach.FileData);
            else
                FileHelper.RunFile(filename, bfiles);


        }

        private void MenuExtractAttachment_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.IsAdmin)
            {
                if (!FrmMain.currentuser.CanPrint)
                {
                    MessageBox.Show("ليس لديك صلاحية للقيام بهذا الإجراء", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.RestoreDirectory = true;
            sfd.Filter = "All Files (*.*)|*.*";

            byte[] bfiles = (byte[])DataGridAttachments[colfiledata.Name, DataGridAttachments.CurrentRow.Index].Value;
            Guid guid = new Guid(DataGridAttachments[colguid.Name, DataGridAttachments.CurrentRow.Index].Value.ToString());
            tbAttachment attach = tbAttachment.FindByFull("guid", guid);
            sfd.FileName = attach.Name;


            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (bfiles.Length <= 1)
                        FileHelper.ByteArraytoFile(attach.FileData, sfd.FileName);
                    else
                        FileHelper.ByteArraytoFile(bfiles, sfd.FileName);
                    ShowConfirm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuDeleteAttachment_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataGridAttachments.Rows.RemoveAt(DataGridAttachments.CurrentRow.Index);


        }

        private void BtnScanner_Click(object sender, EventArgs e)
        {

            FrmScanImage2 frmscan = new FrmScanImage2();
            if (frmscan.ShowDialog() == DialogResult.OK)
            {
                if (frmscan.imgSc.fbytes.Length <= 0)
                {
                    MessageBox.Show("الملف غير صالح، لم يتم إضافة المرفق", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                tbAttachment tbattach = new tbAttachment();
                tbattach.Guid = Guid.NewGuid();
                tbattach.ParentGuid = Guid.Empty;
                tbattach.Name = Path.GetFileName(frmscan.imgSc.filename);
                tbattach.FileName = tbattach.Name;

                tbattach.FileData = frmscan.imgSc.fbytes;
                tbattach.FileSize = string.Format(new FileSizeFormatProvider(), "{0:fs}", tbattach.FileData.Length);
                tbAttachment.dtData.Rows.Add(tbattach.Guid, tbattach.ParentGuid, tbattach.Name, tbattach.FileName, tbattach.FileSize, tbattach.FileData);
                DataGridAttachments.DataSource = tbAttachment.dtData;
            }
            else
            {
                MessageBox.Show("لم يتم إضافة المرفق", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion


    }
}
