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
using System.Runtime.CompilerServices;
using SmartArabXLSX.Wordprocessing;
using Org.BouncyCastle.Utilities.Collections;
using DevExpress.Utils.DPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using DevExpress.Utils.Gesture;
using OfficeOpenXml.FormulaParsing.Utilities;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using NumberToWord;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.SqlServer.Management.Smo;

namespace DoctorERP
{
    public partial class FrmLand : KryptonForm
    {
        Guid guid;
        BindingSource bs;

        bool isNew;
        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool ShowConfirmMSG = true;
        string BlockNumber;
        public FrmLand(Guid guid, bool isNew, string BlockNumber)
        {
            InitializeComponent();
            dirtytracker = new WinformsDirtyTracking.DirtyTracker(this);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();
            tbPlanInfo.Fill();
            tbTaxDiscount.Fill();

            this.guid = guid;
            this.BlockNumber = BlockNumber;
            BtnEdit.Visible = true;
            BtnAdd.Visible = false;

            this.isNew = isNew;
        }

        void FillGridLog(Guid landGuid)
        {
            tbPriceLog.Fill("ParentGuid", landGuid);
            DataGridPriceLog.DataSource = tbPriceLog.dtData;
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

            if (!BlockNumber.Equals(string.Empty))
            {
                Txtblocknumber.Text = BlockNumber;

                //Txtcode.Text = (tbLand.GetMaxNumber("Code", BlockNumber) + 1).ToString();
                Txtcode.Text = Txtnumber.Text = (tbLand.GetMaxNumber("Number") + 1).ToString();
                Txtname.Focus();
            }

            dirtytracker.MarkAsClean();
        }


        #region Binding
        private void InitBinding()
        {


            if (FrmMain.PlanGuid != Guid.Empty)
            {
                tbLand.Fill("PlanGuid", FrmMain.PlanGuid);
            }
            else if (FrmMain.PlanGuid == Guid.Empty)
            {
                tbLand.Fill();
            }

            bs = new BindingSource(tbLand.lstData, string.Empty);
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbLand.lstData.FindIndex(delegate (tbLand land) { return land.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (bs.Current == null) { return; }
                tbLand obj = (tbLand)bs.Current;

                if (obj.guid.Equals(Guid.Empty))
                {
                    CalcTotal();
                    BtnReservation.Text = "حجز";
                    Txtstatus.Text = "متاح";
                    Txtname.Text = string.Empty;
                    Txtplanname.Text = tbPlanInfo.lstData[0].name;
                    Txtplannumber.Text = tbPlanInfo.lstData[0].number;
                    Txtname.Text = string.Format("رقم الأرض {0}", string.Empty);
                    Txtnumber.Text = string.Empty;
                    TxtTotal.Text = string.Empty;
                    TxtTotalText.Text = string.Empty;
                    TxtReserveReason.Visible = Lblreservereason.Visible = false;

                    FillGridLog(obj.guid);


                    //Txtvat.Enabled = Chkisvat.Checked;
                    //Txtworkfee.Enabled = Chkisworkfee.Checked;

                    //Txtsalesfee.Enabled = Chkissalefee.Checked;
                    //Txtbuildingfee.Enabled = Chkisbuildingfee.Checked;

                    //Txtdiscountfee.Enabled = Chkisdiscountfee.Checked;
                    //Txtdiscountfeevalue.Enabled = Chkisdiscountfee.Checked;

                    //Txtdiscounttotal.Enabled = Chkisdiscounttotal.Checked;
                    //Txtdiscounttotalvalue.Enabled = Chkisdiscounttotal.Checked;

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
                CheckAllow(new tbLand());
                dirtytracker.MarkAsClean();
            }
        }

        void CheckAllow(tbLand land)
        {
            bool Enable;

            if (FrmMain.AllowEdit || land.guid.Equals(Guid.Empty))
                Enable = true;
            else
            {
                if (tbBillBody.IsExist("LandGuid", land.guid) || tbSaleOrderBody.IsExist("LandGuid", land.guid))
                {
                    Enable = false;
                }
                else
                {
                    Enable = true;
                }
            }

            foreach (KryptonTextBox item in DataGUIAttribute.GetAll(this, typeof(KryptonTextBox)))
            {
                item.ReadOnly = !Enable;
            }

        }



        private void FillForm()
        {
            if (bs.Count > 0)
            {
                tbLand land = (tbLand)bs.Current;

                DataGUIAttribute.AssignFormValues<tbLand>(this, land);


                if (land.status == "محجوز")
                    BtnReservation.Text = "إلغاء الحجز";
                else
                    BtnReservation.Text = "حجز";

                CalcTotal();

                Txtplanname.Text = tbPlanInfo.lstData[0].name;
                Txtplannumber.Text = tbPlanInfo.lstData[0].number;
                Txtname.Text = string.Format("رقم الأرض {0}", land.number);

                Txtvat.Enabled = land.isvat;
                Txtworkfee.Enabled = land.isworkfee;

                Txtsalesfee.Enabled = land.issalefee;
                Txtbuildingfee.Enabled = land.isbuildingfee;

                Txtdiscountfee.Enabled = land.isdiscountfee;
                Txtdiscountfeevalue.Enabled = land.isdiscountfee;

                Txtdiscounttotal.Enabled = land.isdiscounttotal;
                Txtdiscounttotalvalue.Enabled = land.isdiscounttotal;

                FillDataGridAttachments(land.guid);
                FillGridLog(land.guid);

                if (land is null || land.guid.Equals(Guid.Empty))
                {
                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    BtnAdd.Visible = true;
                    TxtReserveReason.Visible = Lblreservereason.Visible = false;
                    if (tbTaxDiscount.lstData.Count > 0)
                    {
                        tbTaxDiscount taxdiscount = tbTaxDiscount.lstData[0];

                        Chkisbuildingfee.Checked = taxdiscount.isbuildingfee;
                        Txtbuildingfee.Text = taxdiscount.buildingfee.ToString();
                        Chkisdiscountfee.Checked = taxdiscount.isdiscountfee;
                        Txtdiscountfee.Text = taxdiscount.discountfee.ToString();
                        Txtdiscountfeevalue.Text = taxdiscount.discountfeevalue.ToString();
                        Chkisdiscounttotal.Checked = taxdiscount.isdiscounttotal;
                        Txtdiscounttotal.Text = taxdiscount.discounttotal.ToString();
                        Txtdiscounttotalvalue.Text = taxdiscount.discounttotalvalue.ToString();
                        Chkisvat.Checked = taxdiscount.isvat;
                        Txtvat.Text = taxdiscount.vat.ToString();
                        Chkisworkfee.Checked = taxdiscount.isworkfee;
                        Txtworkfee.Text = taxdiscount.workfee.ToString(); ;
                        Chkissalefee.Checked = taxdiscount.issalefee;
                        Txtsalesfee.Text = taxdiscount.salesfee.ToString(); ;

                    }
                }
                else
                {
                    if (land.status == "محجوز")
                        TxtReserveReason.Visible = Lblreservereason.Visible = true;
                    else
                        TxtReserveReason.Visible = Lblreservereason.Visible = false;

                    BtnDelete.Enabled = true;
                    BtnEdit.Visible = true;
                    BtnAdd.Visible = false;
                }

                CheckAllow(land);
            }
            else
            {
                NewFill();

                BtnDelete.Enabled = false;
                BtnEdit.Visible = false;
                BtnAdd.Visible = true;
                TxtReserveReason.Visible = Lblreservereason.Visible = false;

                isNew = true;
            }
        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbLand>(this, new tbLand());
            DataGUIAttribute.ClearFormControls<tbLand>(this, new tbLand());
            BtnReservation.Text = "حجز";
            Txtstatus.Text = "متاح";
            Txtname.Text = string.Format("رقم الأرض {0}", string.Empty);

            Txtplanname.Text = tbPlanInfo.lstData[0].name;
            Txtplannumber.Text = tbPlanInfo.lstData[0].number;
            Txtnumber.Text = string.Empty;
            FillGridLog(Guid.Empty);

            if (tbTaxDiscount.lstData.Count > 0)
            {
                tbTaxDiscount taxdiscount = tbTaxDiscount.lstData[0];

                Chkisbuildingfee.Checked = taxdiscount.isbuildingfee;
                Txtbuildingfee.Text = taxdiscount.buildingfee.ToString();
                Chkisdiscountfee.Checked = taxdiscount.isdiscountfee;
                Txtdiscountfee.Text = taxdiscount.discountfee.ToString();
                Txtdiscountfeevalue.Text = taxdiscount.discountfeevalue.ToString();
                Chkisdiscounttotal.Checked = taxdiscount.isdiscounttotal;
                Txtdiscounttotal.Text = taxdiscount.discounttotal.ToString();
                Txtdiscounttotalvalue.Text = taxdiscount.discounttotalvalue.ToString();
                Chkisvat.Checked = taxdiscount.isvat;
                Txtvat.Text = taxdiscount.vat.ToString();
                Chkisworkfee.Checked = taxdiscount.isworkfee;
                Txtworkfee.Text = taxdiscount.workfee.ToString(); ;
                Chkissalefee.Checked = taxdiscount.issalefee;
                Txtsalesfee.Text = taxdiscount.salesfee.ToString(); ;

            }
            CheckAllow(new tbLand());
            CalcTotal();
            ClearAttachmentsGrid();
            dirtytracker.MarkAsClean();
        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbLand obj = (tbLand)bs[i];
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
            {
                BtnNew.PerformClick();

                dirtytracker.MarkAsClean();

                DialogResult = DialogResult.OK;

            }
        }

        bool Add()
        {
            tbLand land = new tbLand();


            CalcTotal();
            DataGUIAttribute.AssignObjectValues<tbLand>(this, land);

            land.guid = Guid.NewGuid();


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


            if (ShowConfirmMSG)
            {
                if (MessageBox.Show("هل أنت متاكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }

            tbTaxDiscount.Fill();


            if (tbTaxDiscount.lstData.Count > 0)
            {
                tbTaxDiscount taxdiscount = tbTaxDiscount.lstData[0];
                land.planguid = FrmMain.PlanGuid;

                land.isbuildingfee = taxdiscount.isbuildingfee;
                land.buildingfee = taxdiscount.buildingfee;
                land.isdiscountfee = taxdiscount.isdiscountfee;
                land.discountfee = taxdiscount.discountfee;
                land.discountfeevalue = taxdiscount.discountfeevalue;
                land.isdiscounttotal = taxdiscount.isdiscounttotal;
                land.discounttotal = taxdiscount.discounttotal;
                land.discounttotalvalue = taxdiscount.discounttotalvalue;
                land.isvat = taxdiscount.isvat;
                land.vat = taxdiscount.vat;
                land.isworkfee = taxdiscount.isworkfee;
                land.workfee = taxdiscount.workfee;
                land.issalefee = taxdiscount.issalefee;
                land.salesfee = taxdiscount.salesfee;

            }

            tbPriceLog log = new tbPriceLog();


            log.guid = Guid.NewGuid();
            log.username = FrmMain.currentuser.name;
            log.actdate = DateTime.Now.Date;
            log.oldprice = log.newprice = land.amount;
            log.actno = 1;
            log.changedate = DateTime.Now.Date;
            log.parentguid = land.guid;


            land.number = tbLand.GetMaxNumber("Number") + 1;
            land.code = land.number;

            land.status = "متاح";
            land.lastaction = "إضافة"  + " "+ DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;
            DBConnect.StartTransAction();

            tbLog.AddLog("إضافة", this.Text, land.code.ToString());

            AddAttachments(land.guid);
            land.Insert();
            log.Insert();


            if (DBConnect.CommitTransAction())
            {
                bs.Add(land);
                ShowConfirm();

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

            if (Edit())
            {
                DialogResult = DialogResult.OK;
            }
        }

        bool Edit()
        {
            tbLand land = (tbLand)bs.Current;

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

            ////if (tbLand.IsExist("code", Txtcode.Text) && Txtcode.Text != land.code.ToString())
            ////{
            ////    MessageBox.Show("كود الصنف مكرر", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////    return false;
            ////}



            //if (tbLand.IsExist("deednumber", Txtdeednumber.Text) && Txtdeednumber.Text != land.deednumber.ToString())
            //{
            //    MessageBox.Show("رقم الصك مكرر", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            CalcTotal();


            if (ShowConfirmMSG)
            {
                if (MessageBox.Show("هل أنت متاكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }

            decimal amount;
            decimal.TryParse(TxtAmount.Text, out amount);

            if (land.amount != amount)
            {
                FrmPriceLog frm = new FrmPriceLog(Guid.Empty, land.guid, land.amount, amount);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    return false;
                }
            }

            DataGUIAttribute.AssignObjectValues<tbLand>(this, land);






            land.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            DBConnect.StartTransAction();
            AddAttachments(land.guid);
            land.Update();
            tbLog.AddLog("تعديل", this.Text, land.code.ToString());
            if (DBConnect.CommitTransAction())
            {
                FillGridLog(land.guid);
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

            tbLand land = (tbLand)bs.Current;

            tbAttachment attach = new tbAttachment();

            if (tbBillBody.IsExist("LandGuid", land.guid))
            {
                MessageBox.Show("لا يمكن حذف الصنف لأنه مستخدم في العقود", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (tbSaleOrderBody.IsExist("LandGuid", land.guid))
            {
                MessageBox.Show("لا يمكن حذف الصنف لأنه مستخدم في أوامر البيع", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            tbPriceLog pricelog = new tbPriceLog();



            DBConnect.StartTransAction();

            tbLog.AddLog("حذف", this.Text, land.code.ToString());
            attach.DeleteBy("ParentGuid", land.guid);
            land.Delete();
            pricelog.DeleteBy("ParentGuid", land.guid);

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
            //CmbLandType.SelectedIndex = 0;
            //CmbAuth.Items.Clear();
            //CmbAuth.Items.AddRange(tbLand.GetUniqueList("Auth").ToArray());

            //CmbCountry.Items.Clear();
            //CmbCountry.Items.AddRange(tbLand.GetUniqueList("Country").ToArray());

            //CmbStoreLocation.Items.Clear();
            //CmbStoreLocation.Items.AddRange(tbLand.GetUniqueList("StoreLocation").ToArray());

            //CmbLandType.Items.Clear();
            //CmbLandType.Items.AddRange(tbLand.GetUniqueList("LandType").ToArray());


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
            tbLand land = (tbLand)bs.Current;

            if (land is null || land.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب حفظ البطاقة أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            Reports.InitReport(rpt, "land.frx", false);
            tbLand.Fill(land.guid);


            tbAgent.Fill("agenttype", 0);

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");

            rpt.SetParameterValue("TotalText", TxtTotalText.Text);

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.RegisterData(tbLand.dtData, "data");
            rpt.RegisterData(tbPlanInfo.dtData, "tbPlanInfo");

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









        private void BtnReservation_Click(object sender, EventArgs e)
        {
            if (bs.Current == null)
            {
                MessageBox.Show("يجب حفظ البطاقة أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbLand land = (tbLand)bs.Current;

            if (land is null || land.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب حفظ البطاقة أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (land.status.Equals("متاح"))
            {
                if (MessageBox.Show("هل أنت متأكد من حجز هذا الصنف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;

                FrmReservereason frm = new FrmReservereason(TxtReserveReason.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    DBConnect.StartTransAction();
                    Txtstatus.Text = land.status = "محجوز";
                    BtnReservation.Text = "إلغاء الحجز";
                    Lblreservereason.Visible = TxtReserveReason.Visible = true;
                    land.reservereason = frm.reservereason;
                    TxtReserveReason.Text = frm.reservereason;
                    land.Update();
                    if (DBConnect.CommitTransAction())
                    {
                        ShowConfirm();
                    }
                }
                else
                {

                }
            }
            else if (land.status.Equals("مباع"))
            {
                MessageBox.Show("لا يمكن حجز الصنف المباع", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (land.status.Equals("أمر بيع"))
            {
                MessageBox.Show("لا يمكن حجز الصنف مضاف لأمر البيع", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (land.status.Equals("محجوز"))
            {
                if (MessageBox.Show("هل أنت متأكد من إلغاء حجز هذا الصنف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;

                DBConnect.StartTransAction();
                Txtstatus.Text = land.status = "متاح";
                BtnReservation.Text = "حجز";
                land.reservereason = string.Empty;
                Lblreservereason.Visible = TxtReserveReason.Visible = false;
                land.Update();
                if (DBConnect.CommitTransAction())
                {
                    ShowConfirm();
                }
            }
        }

        private void Chkissalefee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkissalefee.Focused)
            {
                if (Chkissalefee.Checked)
                {
                    Txtsalesfee.Enabled = true;
                }
                else
                {
                    Txtsalesfee.Text = string.Empty;

                    Txtsalesfee.Enabled = false;
                }
                CalcTotal();
            }
        }

        private void Chkisbuildingfee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisbuildingfee.Focused)
            {
                if (Chkisbuildingfee.Checked)
                {
                    Txtbuildingfee.Enabled = true;
                }
                else
                {
                    Txtbuildingfee.Text = string.Empty;

                    Txtbuildingfee.Enabled = false;
                }
                CalcTotal();
            }
        }

        private void Chkisworkfee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisworkfee.Focused)
            {
                if (Chkisworkfee.Checked)
                {
                    Txtworkfee.Enabled = true;
                }
                else
                {
                    Txtworkfee.Text = string.Empty;
                    Txtworkfee.Enabled = false;
                }
                CalcTotal();
            }
        }

        private void Chkisvat_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisvat.Focused)
            {
                if (Chkisvat.Checked)
                {
                    Txtvat.Enabled = true;
                }
                else
                {
                    Txtvat.Text = string.Empty;
                    Txtvat.Enabled = false;
                }
                CalcTotal();
            }

        }

        private void Chkisdiscounttotal_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisdiscounttotal.Focused)
            {
                if (Chkisdiscounttotal.Checked)
                {
                    Txtdiscounttotal.Enabled = true;
                    Txtdiscounttotalvalue.Enabled = true;
                }
                else
                {
                    Txtdiscounttotal.Text = string.Empty;
                    Txtdiscounttotal.Enabled = false;
                    Txtdiscounttotalvalue.Text = string.Empty;
                    Txtdiscounttotalvalue.Enabled = false;
                }

            }
        }

        private void Chkisdiscountfee_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkisdiscountfee.Focused)
            {
                if (Chkisdiscountfee.Checked)
                {
                    Txtdiscountfee.Enabled = true;
                    Txtdiscountfeevalue.Enabled = true;
                }
                else
                {
                    Txtdiscountfee.Text = string.Empty;
                    Txtdiscountfee.Enabled = false;

                    Txtdiscountfeevalue.Text = string.Empty;
                    Txtdiscountfeevalue.Enabled = false;

                }

            }
        }

        private void Txtdiscounttotal_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscounttotal.Focused)
            {
                decimal discounttotal;
                decimal.TryParse(Txtdiscounttotal.Text, out discounttotal);

                if (discounttotal > 0)
                {
                    Txtdiscounttotalvalue.Text = string.Empty;
                }

            }
        }

        private void Txtdiscounttotalvalue_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscounttotalvalue.Focused)
            {
                decimal discounttotalvalue;
                decimal.TryParse(Txtdiscounttotalvalue.Text, out discounttotalvalue);

                if (discounttotalvalue > 0)
                {
                    Txtdiscounttotal.Text = string.Empty;
                }

            }
        }

        private void Txtdiscountfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscountfee.Focused)
            {
                decimal discountfee;
                decimal.TryParse(Txtdiscountfee.Text, out discountfee);

                if (discountfee > 0)
                {
                    Txtdiscountfeevalue.Text = string.Empty;
                }

            }
        }

        private void Txtdiscountfeevalue_TextChanged(object sender, EventArgs e)
        {
            if (Txtdiscountfeevalue.Focused)
            {
                decimal discountfeevalue;
                decimal.TryParse(Txtdiscountfeevalue.Text, out discountfeevalue);

                if (discountfeevalue > 0)
                {
                    Txtdiscountfee.Text = string.Empty;
                }

            }
        }

        void CalcTotal(decimal amount, decimal salesfee, decimal buildingfee, decimal workfee, decimal vatfee)
        {

            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            TxtTotal.Text = total.ToString(DataGUIAttribute.CurrencyFormat);


            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(total, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;

            toWord.Number = total;

            TxtTotalText.Text = toWord.ConvertToArabic();

        }

        void CalcTotal()
        {

            decimal amount;
            decimal.TryParse(TxtAmount.Text, out amount);

            decimal salesfee;
            decimal.TryParse(Txtsalesfee.Text, out salesfee);

            decimal buildingfee;
            decimal.TryParse(Txtbuildingfee.Text, out buildingfee);

            decimal workfee;
            decimal.TryParse(Txtworkfee.Text, out workfee);

            decimal vatfee;
            decimal.TryParse(Txtvat.Text, out vatfee);


            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            TxtTotal.Text = total.ToString(DataGUIAttribute.CurrencyFormat);

            TxtVatFeePercent.Text = vatfee.ToString(DataGUIAttribute.CurrencyFormat);
            TxtWorkFeePercent.Text = workfee.ToString(DataGUIAttribute.CurrencyFormat);
            TxtBuidlingFeePercent.Text = buildingfee.ToString(DataGUIAttribute.CurrencyFormat);

            TxtWorkFeeValue.Text = (amount * workfee / 100).ToString(DataGUIAttribute.CurrencyFormat);
            TxtBuildingFeeValue.Text = (amount * buildingfee / 100).ToString(DataGUIAttribute.CurrencyFormat);
            TxtVatFee.Text = ((amount * workfee / 100) * vatfee / 100).ToString(DataGUIAttribute.CurrencyFormat);
            TxtWorkFeeWithVat.Text = ((amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100)).ToString(DataGUIAttribute.CurrencyFormat);
            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(total, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;

            TxtTotalText.Text = toWord.ConvertToArabic();

        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            if (TxtAmount.Focused)
                CalcTotal();
        }

        private void Txtsalesfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtsalesfee.Focused)
                CalcTotal();
        }

        private void Txtbuildingfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtbuildingfee.Focused)
                CalcTotal();
        }

        private void Txtworkfee_TextChanged(object sender, EventArgs e)
        {
            if (Txtworkfee.Focused)
                CalcTotal();
        }

        private void Txtvat_TextChanged(object sender, EventArgs e)
        {
            if (Txtvat.Focused)
                CalcTotal();
        }

        private void Txtnumber_TextChanged(object sender, EventArgs e)
        {
            if (Txtnumber.Focused)
                Txtname.Text = string.Format("رقم الأرض {0}", string.Empty);
        }

        private void DataGridPriceLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                tbLand land = (tbLand)bs.Current;

                if (land is null || land.guid.Equals(Guid.Empty))
                {
                    return;
                }

                Guid guid = (Guid)DataGridPriceLog[ColLogGuid.Name, DataGridPriceLog.CurrentRow.Index].Value;
                tbPriceLog pricel = tbPriceLog.FindBy("Guid", guid);
                FrmPriceLog frmtable = new FrmPriceLog(guid, land.guid, pricel.oldprice, pricel.newprice);
                frmtable.ShowDialog();
                FillGridLog(land.guid);
            }
            catch
            {

            }
        }

        private void Txtblocknumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtblocknumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BtnContract_Click(object sender, EventArgs e)
        {
            tbLand land = (tbLand)bs.Current;

            if (land is null || land.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب حفظ البطاقة أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (land.status.Equals("مباع"))
            {
                MessageBox.Show("الأرض مباعة مسبقاً", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            if (land.status.Equals("محجوز"))
            {
                MessageBox.Show("الأرض محجوزة مسبقاً، يجب فك الحجز قبل بيعها", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            List<tbLand> lst = new List<tbLand>();
            lst.Add(land);
            FrmBillHeader frm = new FrmBillHeader(Guid.Empty, true, 0, lst);
            frm.Show();

        }
    }
}
