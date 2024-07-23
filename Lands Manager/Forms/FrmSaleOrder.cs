using DoctorERP;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Data;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.BandedGrid;
using SmartArabXLSX.Drawing.Diagrams;
using DevExpress.Printing.Core.PdfExport.Metafile;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraEditors.Repository;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using DevExpress.XtraEditors.Frames;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.Management.Smo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.Utils.Menu;
using SmartArabXLSX.Office2010.CustomUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FastReport;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using NumberToWord;


namespace DoctorERP
{
    public partial class FrmSaleOrder : XtraForm
    {

        BindingSource bs;
        Guid guid;

        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool isNew;



        public FrmSaleOrder(Guid guid, bool isNew)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            dirtytracker = new WinformsDirtyTracking.DirtyTracker(this);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.guid = guid;

            BtnEdit.Visible = true;
            BtnAdd.Visible = false;

            this.isNew = isNew;






            InitReadyGrid();

            FillCmb();



        }


        private void FrmReadyItems_Load(object sender, EventArgs e)
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
            tbSaleOrder.Fill();
            bs = new BindingSource(tbSaleOrder.lstData, string.Empty);
            dataNavigator1.DataSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbSaleOrder.lstData.FindIndex(delegate (tbSaleOrder obj) { return obj.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbSaleOrder obj = (tbSaleOrder)bs.Current;

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
                tbSaleOrder obj = (tbSaleOrder)bs.Current;


                TxtNote.Text = obj.note;


                tbAgent buyer = tbAgent.FindBy("Guid", obj.buyerguid);

                TxtSelectBuyer.Tag = buyer;


                if (obj.buyerdata == "الوكيل")
                {
                    CmbBuyerData.SelectedIndex = 1;
                }
                else
                {
                    CmbBuyerData.SelectedIndex = 0;

                }


                if (CmbBuyerData.SelectedIndex == 0)
                {
                    TxtSelectBuyer.Text = buyer.name;
                }
                else if (CmbBuyerData.SelectedIndex == 1)
                {
                    TxtSelectBuyer.Text = buyer.agentname;
                }




                FillGrid(obj.guid);
                dtRegDate.DateTime = obj.regdate;

                if (obj is null || obj.guid.Equals(Guid.Empty))
                {
                    TxtSelectBuyer.Tag = new tbAgent();



                    TxtSelectBuyer.Text = string.Empty;
                    CmbBuyerData.SelectedIndex = 0;

                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    BtnAdd.Visible = true;
                    dtRegDate.DateTime = DateTime.Now;
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
            DataGUIAttribute.AssignFormValues<tbSaleOrder>(this, new tbSaleOrder());
            DataGUIAttribute.ClearFormControls<tbSaleOrder>(this, new tbSaleOrder());

            TxtSelectBuyer.Tag = new tbAgent();
            TxtSelectBuyer.Text = string.Empty;



            CalcBillBody();
            dirtytracker.MarkAsClean();

        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbSaleOrder obj = (tbSaleOrder)bs[i];
                if (obj.guid.Equals(Guid.Empty))
                {
                    bs.Remove(obj);
                }
            }

        }
        #endregion

        #region grid

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            FindControl findControl = MainGridReadyItems.Controls.OfType<FindControl>().FirstOrDefault();



            findControl.BackColor = Color.LightYellow;
        }

        GridFormatRule FormatRuleDuplicate = new GridFormatRule();
        FormatConditionRuleUniqueDuplicate formatConditionRule;

        GridFormatRule FormatRuleValue = new GridFormatRule();
        //FormatConditionRuleExpression formatConditionValue;

        void InitReadyGrid()
        {
            GridLocalizer.Active = new MyGridLocalizer();
            DevExpress.Utils.Paint.TextRendererHelper.UseScriptAnalyse = false;
            GridView1.OptionsFind.AllowFindPanel = true;
            GridView1.OptionsFind.FindNullPrompt = "أدخل كلمة للبحث";
            GridView1.OptionsFind.Behavior = FindPanelBehavior.Filter;
            GridView1.OptionsFind.AlwaysVisible = true;

            GridView1.OptionsView.ShowGroupPanel = false;
            GridView1.OptionsCustomization.AllowFilter = false;
            GridView1.OptionsCustomization.AllowColumnMoving = false;
            GridView1.OptionsMenu.EnableColumnMenu = false;
            GridView1.OptionsCustomization.AllowSort = false;

            GridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            GridView1.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            GridView1.OptionsView.ShowFooter = true;
            GridView1.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True;
            GridView1.RowHeight = 35;

            GridView1.Appearance.Row.Font = new Font(GridView1.Appearance.Row.Font.FontFamily, 12F, FontStyle.Regular);

            foreach (GridColumn item in GridView1.Columns)
            {

                if (item.FieldName.Equals("price") || item.FieldName.Equals("total") || item.FieldName.Equals("totalnet"))
                {
                    item.DisplayFormat.FormatType = FormatType.Numeric;
                    item.DisplayFormat.FormatString = "N2";
                    item.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                    RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                    editor.Mask.MaskType = MaskType.Numeric;
                    editor.Mask.EditMask = "N2";
                    item.ColumnEdit = editor;
                }

                else
                {

                    item.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                }

                item.AppearanceHeader.ForeColor = Color.Black;
                item.AppearanceHeader.Font = new Font(item.AppearanceHeader.Font.FontFamily, 9.75F, FontStyle.Bold);
                item.AppearanceHeader.FontStyleDelta = FontStyle.Bold;
            }



            FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
            FormatRuleValue.Column = ColStatus;
            FormatRuleValue.ApplyToRow = true;
            FormatRuleValue.Name = "Format1";
            formatConditionRuleExpression.Appearance.Font = new Font(this.Font, FontStyle.Strikeout);
            formatConditionRuleExpression.Expression = "[status] = 'مرتجع'";
            FormatRuleValue.Rule = formatConditionRuleExpression;
            GridView1.FormatRules.Add(FormatRuleValue);

            formatConditionRule = new FormatConditionRuleUniqueDuplicate();




            FormatRuleDuplicate.Column = ColLandGuid;
            FormatRuleDuplicate.ColumnApplyTo = ColLand;
            FormatRuleDuplicate.Name = "Format0";
            formatConditionRule.Appearance.BackColor = Color.LightPink;
            formatConditionRule.Appearance.Options.UseBackColor = true;

            FormatRuleDuplicate.Rule = formatConditionRule;

            GridView1.FormatRules.Add(FormatRuleDuplicate);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;


            if (view.FocusedColumn.FieldName == "number" || view.FocusedColumn.FieldName == "code" || view.FocusedColumn.FieldName == "total" || view.FocusedColumn.FieldName == "totalnet")
            {
                e.Cancel = true;
            }

        }



        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (GridView1.IsNewItemRow(e.RowHandle))
            {
                BeginInvoke(new Action(() =>
                {
                    GridView1.FocusedColumn = ColLand;
                    ReNumberGrid();
                    //GridView1.ShowEditor();
                }));
            }
        }

        void ReNumberGrid()
        {
            for (int i = 0; i <= GridView1.RowCount; i++)
            {
                GridView1.SetRowCellValue(i, ColNumber, i + 1);
            }
        }

        private void MainGridReadyItems_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (GridView1.FocusedColumn == ColNote)
                {
                    AddNewRow();
                }


            }
            else if (e.KeyCode == Keys.Down)
            {
                if (GridView1.FocusedColumn == ColLand)
                {
                    AddNewRow();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (GridView1.FocusedColumn == ColLand)
                {
                    string status = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColStatus).ToString();


                    GridView1.DeleteSelectedRows();

                    if (GridView1.RowCount <= 0)
                        AddNewRow();



                    ReNumberGrid();
                    CalcBillBody();
                }
                else
                {
                    e.Handled = true;
                }
            }
        }


        void AddNewRow()
        {
            Guid LasRowGuid = Guid.Empty;

            try
            {
                if (privatebillBody.Rows.Count == 0 || privatebillBody.Rows[privatebillBody.Rows.Count - 1].RowState == DataRowState.Deleted)
                {

                    LasRowGuid = Guid.NewGuid();
                }
                else
                {
                    LasRowGuid = new Guid(privatebillBody.Rows[privatebillBody.Rows.Count - 1]["landguid"].ToString());
                }
            }
            catch
            {

            }


            if (!LasRowGuid.Equals(Guid.Empty))
            {
                privatebillBody.Rows.Add(
                           Guid.Empty, // Guid
                            Guid.Empty, // ParentGuid
                            Guid.Empty, // LandGuid 
                            0, //Number

                            0, // Code
                            string.Empty, // Land
                            DBNull.Value, // Price



                            DBNull.Value, // Total 
                            string.Empty,  // Note
                            string.Empty); // status

                GridView1.UpdateCurrentRow();
                GridView1.MoveNext();
                GridView1.FocusedColumn = ColLand;
                ReNumberGrid();
            }

        }
        //private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        //{
        //    // e.ExceptionMode = ExceptionMode.NoAction;
        //}
        //private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        //{
        //    // e.ExceptionMode = ExceptionMode.NoAction;
        //}

        //private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        //{

        //}

        //private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        //{


        //}
        #endregion


        DataTable privatebillBody = new DataTable();
        void FillGrid(Guid guid)
        {

            tbSaleOrder billheader = tbSaleOrder.FindBy("guid", guid);
            privatebillBody = new DataTable();
            vwSaleOrderBody.Fill("parentguid", billheader.guid, privatebillBody);
            MainGridReadyItems.DataSource = privatebillBody;
            if (privatebillBody.Rows.Count <= 0)
            {
                privatebillBody.Rows.Add(
                            Guid.Empty, // Guid
                            Guid.Empty, // ParentGuid
                            Guid.Empty, // LandGuid 
                            0, //Number

                            0, // Code
                            string.Empty, // Land
                            DBNull.Value, // Price



                            DBNull.Value, // Total 
                            string.Empty,  // Note
                            string.Empty); // status

                GridView1.FocusedColumn = ColLand;
            }
            CalcBillBody();
        }

        void FillCmb()
        {
            CmbBuyerData.SelectedIndex = 0;

        }

        #region Select Mat 
        private void SelectMat(string keyword)
        {
            vwSelectLand selectland = new vwSelectLand();

            int rowhandle = GridView1.FocusedRowHandle;


            vwSelectLand.Fill("code", keyword, "متاح");


            if (vwSelectLand.dtData.Rows.Count == 1)
            {
                selectland = vwSelectLand.FindBy("guid", new Guid(vwSelectLand.dtData.Rows[0]["guid"].ToString()));
            }
            else
            {

                vwSelectLand.Fill("code", " ", "متاح");


                //tbLand.Fill(" ");
                FrmSelect frmselect = new FrmSelect("إختيار صنف", typeof(vwSelectLand), vwSelectLand.dtData);

                if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectland = vwSelectLand.FindBy("guid", frmselect.guid);
                }
            }

            if (!selectland.guid.Equals(Guid.Empty))
            {
                GridView1.CellValueChanged -= gridView1_CellValueChanged;

                tbLand land = tbLand.FindBy("Guid", selectland.guid);
                FillLandInfo(rowhandle, land);

                CalcRowPrices(rowhandle, land);

                //if (FormatRuleDuplicate.IsFit())
                //{
                //    MessageBox.Show("إنتبه الصنف المحدد مكرر", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

                GridView1.CloseEditor();

                GridView1.CellValueChanged += gridView1_CellValueChanged;
                AddNewRow();


                //GridView1.FocusedColumn = ColSellQty;
            }
            else
            {
                Guid matguid = new Guid(GridView1.GetRowCellValue(rowhandle, ColLandGuid).ToString());

                if (!matguid.Equals(Guid.Empty))
                {
                    vwSelectLand imat = vwSelectLand.FindBy("Guid", matguid);
                    GridView1.SetRowCellValue(rowhandle, ColLand, "الأرض رقم " + imat.code);


                }
            }


        }

        private void SelectItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ButtonEdit buttonEdit = sender as ButtonEdit;

                SelectMat(buttonEdit.Text);
            }
        }


        private void SelectItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;

            SelectMat(buttonEdit.Text);
        }

        void FillLandInfo(int rowhandle, tbLand land)
        {

            GridView1.SetRowCellValue(rowhandle, ColLand, "الأرض رقم " + land.number);
            GridView1.SetRowCellValue(rowhandle, ColLandGuid, land.guid);

            GridView1.SetRowCellValue(rowhandle, ColPrice, land.amount);
            GridView1.SetRowCellValue(rowhandle, ColCode, land.code);




        }
        #endregion

        void AddBillBody(Guid parentguid)
        {
            tbSaleOrderBody itemsbodydelete = new tbSaleOrderBody();
            itemsbodydelete.DeleteBy("ParentGuid", parentguid);


            int idx = 1;
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                //Guid manguid = new Guid(GridView1.GetRowCellValue(i, ColManFactorGuid).ToString());

                decimal price;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColPrice).ToString(), out price);


                decimal bodytotalnet;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColTotal).ToString(), out bodytotalnet);



                string note = GridView1.GetRowCellValue(i, ColNote).ToString();

                if (!landguid.Equals(Guid.Empty))
                {
                    tbSaleOrderBody billbody = new tbSaleOrderBody();

                    billbody.parentguid = parentguid;
                    billbody.landguid = landguid;
                    billbody.number = idx;
                    billbody.price = price;
                    billbody.total = bodytotalnet;
                    
                    billbody.note = note;
                    billbody.status = "أمر بيع";


                    billbody.guid = Guid.NewGuid();
                    billbody.Insert();

                    idx++;
                }

            }


        }

        bool IsRowExist(Guid guid, string status)
        {
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, "landguid").ToString());
                string state = GridView1.GetRowCellValue(i, ColStatus).ToString();

                if (landguid.Equals(guid) && status == state)
                    return true;
            }

            return false;
        }

        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            BtnAdd.Visible = true;
            BtnEdit.Visible = false;
            BtnDelete.Enabled = false;



            TxtNote.Text = string.Empty;


            dtRegDate.EditValue = DateTime.Now;

            FillCmb();
            FillGrid(Guid.Empty);

            Clear();

            bs.AddNew();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Add())
            {

                //BtnNew.PerformClick();

                dirtytracker.MarkAsClean();
            }

        }

        bool Add()
        {
            tbSaleOrder billheader = new tbSaleOrder();


            tbAgent buyer = (tbAgent)TxtSelectBuyer.Tag;
            //if (buyer.guid.Equals(Guid.Empty))
            //{
            //    MessageBox.Show("يجب إختيار العميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}



            bool IsDuplicateFound = false;
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                string status = GridView1.GetRowCellValue(i, ColStatus).ToString();

                if (!landguid.Equals(Guid.Empty) && !status.Equals("مرتجع"))
                    IsDuplicateFound = IsDuplicate(landguid);
            }

            if (IsDuplicateFound)
            {
                MessageBox.Show("لا يمكن الحفظ يوجد أصناف مكررة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            billheader.guid = Guid.NewGuid();
            billheader.number = tbSaleOrder.GetMaxNumber("number") + 1;
            billheader.buyerdata = CmbBuyerData.Text;
            billheader.buyerguid = buyer.guid;
            billheader.regdate = dtRegDate.DateTime;
            billheader.note = TxtNote.Text;

            CalcBillBody();

            decimal total;
            decimal.TryParse(TxtTotal.Text, out total);
            billheader.total = total;

            decimal totalnet;
            decimal.TryParse(TxtTotalNet.Text, out totalnet);
            billheader.totalnet = totalnet;




            if (MessageBox.Show("هل أنت متأكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return false;

            billheader.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;


            DBConnect.StartTransAction();
            billheader.Insert();

            tbLog.AddLog("إضافة", this.Text, billheader.number + "/" + billheader.totalnet.ToString("N2"));

            AddBillBody(billheader.guid);

            if (DBConnect.CommitTransAction())
            {
                bs.Add(billheader);
                ShowConfirm();

                Clear();
                bs.MoveLast();
                FillCmb();

                FillGrid(billheader.guid);
            }

            BtnAdd.Visible = false;
            BtnEdit.Visible = true;



            dirtytracker.MarkAsClean();
            isNew = false;
            return true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        bool Edit()
        {
            tbSaleOrder billheader = (tbSaleOrder)bs.Current;




            tbAgent buyer = (tbAgent)TxtSelectBuyer.Tag;
            //if (buyer.guid.Equals(Guid.Empty))
            //{
            //    MessageBox.Show("يجب إختيار العميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            bool IsDuplicateFound = false;
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                string status = GridView1.GetRowCellValue(i, ColStatus).ToString();

                if (!landguid.Equals(Guid.Empty) && status.Equals("مباع"))
                    IsDuplicateFound = IsDuplicate(landguid);
            }

            if (IsDuplicateFound)
            {
                MessageBox.Show("لا يمكن الحفظ يوجد أصناف مكررة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            billheader.buyerdata = CmbBuyerData.Text;
            billheader.buyerguid = buyer.guid;
            billheader.regdate = dtRegDate.DateTime;
            billheader.note = TxtNote.Text;
            CalcBillBody();

            decimal total;
            decimal.TryParse(TxtTotal.Text, out total);
            billheader.total = total;

            decimal totalnet;
            decimal.TryParse(TxtTotalNet.Text, out totalnet);
            billheader.totalnet = totalnet;



            if (MessageBox.Show("هل أنت متأكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return false;


            billheader.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;


            DBConnect.StartTransAction();
            tbLog.AddLog("تعديل", this.Text, billheader.number + "/" + billheader.totalnet.ToString("N2"));
            billheader.Update();
            AddBillBody(billheader.guid);



            if (DBConnect.CommitTransAction())
            {

                ShowConfirm();
                dirtytracker.MarkAsClean();
                isNew = false;
                FillGrid(billheader.guid);

            }


            return true;
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            tbSaleOrder billheader = (tbSaleOrder)bs.Current;

            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbSaleOrderBody.Fill();


            tbSaleOrderBody billbody = new tbSaleOrderBody();


            DBConnect.StartTransAction();

            tbLog.AddLog("حذف", this.Text, billheader.number + "/" + billheader.totalnet.ToString("N2"));

            billbody.DeleteBy("ParentGuid", billheader.guid);
            billheader.Delete();

            foreach (var item in tbSaleOrderBody.lstData)
            {
                tbLand.updatelandstatus(item.landguid);
            }

            if (DBConnect.CommitTransAction())
            {
                bs.RemoveCurrent();
                bs.MoveLast();
                ShowConfirm();
                Clear();

                CalcBillBody();

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



        private void FrmReadyItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool estate = SimulatExit();
            e.Cancel = estate;
        }

        bool SimulatExit()
        {
            if (dirtytracker.IsDirty)
            {
                DialogResult msgboxres = MessageBox.Show("هل تريد حفظ التغيرات ؟", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (msgboxres == DialogResult.Yes)
                {

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

        private void BtnImportFromByMonth_Click(object sender, EventArgs e)
        {

        }





        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            Guid landguid = Guid.Empty;
            if (GridView1.GetRowCellValue(e.RowHandle, ColLandGuid) is null)
            {

            }
            else
            {
                landguid = new Guid(GridView1.GetRowCellValue(e.RowHandle, ColLandGuid).ToString());
            }


            tbLand land = new tbLand();

            if (landguid.Equals(Guid.Empty))
            {
                return;
            }
            else
                land = tbLand.FindBy("Guid", landguid);

            GridView1.CellValueChanged -= gridView1_CellValueChanged;

            switch (e.Column.Name.ToLower())
            {
                case "colprice":
                    {


                        decimal amount;
                        decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColPrice).ToString(), out amount);


                        CalcRowPrices(GridView1.FocusedRowHandle, land);

                    }
                    break;


                default:
                    break;
            }
            GridView1.CellValueChanged += gridView1_CellValueChanged;

            CalcBillBody();
        }

        void CalcRowPrices(int rowhandle, tbLand land)
        {
            decimal amount;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColPrice).ToString(), out amount);


            decimal workfeevalue;
            workfeevalue = amount * land.workfee / 100;

            //decimal buildingvalue;
            //buildingvalue = land.amount * land.buildingfee / 100;

            decimal vatvalue;
            vatvalue = workfeevalue * land.vat / 100;


            GridView1.SetRowCellValue(rowhandle, ColTotal, amount + workfeevalue + vatvalue);

            //GridView1.SetRowCellValue(rowhandle, ColTotal, amount);
            CalcBillBody();


        }

        decimal total;
        decimal totalnet;
        decimal vatfeevalue;
        decimal buildingfeevalue;
        decimal workfeevalue;

        void CalcBillBody()
        {
            total = 0;
            totalnet = 0;

            vatfeevalue = 0;
            buildingfeevalue = 0;
            workfeevalue = 0;


            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());

                decimal bodyprice;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColPrice).ToString(), out bodyprice);

                decimal bodytotal;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColTotal).ToString(), out bodytotal);

                tbLand land = tbLand.FindBy("Guid", landguid);


                if (!landguid.Equals(Guid.Empty))
                {
                    total += bodyprice;
                    totalnet += bodytotal;
                    workfeevalue += (bodyprice * land.workfee / 100);
                    vatfeevalue += workfeevalue * land.vat / 100;
                    buildingfeevalue += (bodyprice * land.buildingfee / 100);
                }
            }


            TxtTotal.Text = total.ToString(DataGUIAttribute.CurrencyFormat);
            TxtTotalNet.Text = totalnet.ToString(DataGUIAttribute.CurrencyFormat);

            TxtTotalVat.Text = vatfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txttotalbuidlingfee.Text = buildingfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txttotalworkfee.Text = (workfeevalue).ToString(DataGUIAttribute.CurrencyFormat);
        }


        decimal CalcTotal(decimal amount, decimal salesfee, decimal buildingfee, decimal workfee, decimal vatfee, decimal discountotal, decimal discountfee)
        {

            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            return total;


        }

        #region Select Buyer
        private void TxtSelectBuyer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbAgent.Fill("name", TxtSelectBuyer.Text, 1);
                if (tbAgent.dtData.Rows.Count == 1)
                {
                    tbAgent selectedobject = tbAgent.FindBy("guid", new Guid(tbAgent.dtData.Rows[0]["guid"].ToString()));
                    TxtSelectBuyer.Tag = selectedobject;
                    TxtSelectBuyer.Text = selectedobject.name;
                    if (CmbBuyerData.SelectedIndex == 0)
                    {
                        TxtSelectBuyer.Tag = selectedobject;
                        TxtSelectBuyer.Text = selectedobject.name;
                    }
                    else if (CmbBuyerData.SelectedIndex == 1)
                    {
                        TxtSelectBuyer.Tag = selectedobject;
                        TxtSelectBuyer.Text = selectedobject.agentname;
                        if (selectedobject.agentname.Equals(string.Empty))
                        {
                            MessageBox.Show("لم يتم إدخال معلومات الوكيل للعميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CmbBuyerData.Text = "العميل";
                            TxtSelectBuyer.Text = selectedobject.name;
                        }
                    }
                }
                else if (tbAgent.dtData.Rows.Count == 0)
                {
                    tbAgent.Fill("name", " ", 1);
                    ShowSelectBuyer();
                }
                else
                {
                    ShowSelectBuyer();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelectBuyer.Tag = new tbAgent();
                TxtSelectBuyer.Text = string.Empty;
            }
        }

        private void ShowSelectBuyer()
        {
            FrmSelect frmselect = new FrmSelect("إختيار عميل", typeof(tbAgent), tbAgent.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbAgent selectedobject = tbAgent.FindBy("guid", frmselect.guid);
                TxtSelectBuyer.Tag = selectedobject;
                TxtSelectBuyer.Text = selectedobject.name;

                if (CmbBuyerData.SelectedIndex == 0)
                {
                    TxtSelectBuyer.Tag = selectedobject;
                    TxtSelectBuyer.Text = selectedobject.name;
                }
                else if (CmbBuyerData.SelectedIndex == 1)
                {
                    TxtSelectBuyer.Tag = selectedobject;
                    TxtSelectBuyer.Text = selectedobject.agentname;
                    if (selectedobject.agentname.Equals(string.Empty))
                    {
                        MessageBox.Show("لم يتم إدخال معلومات الوكيل للعميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CmbBuyerData.Text = "العميل";
                        TxtSelectBuyer.Text = selectedobject.name;
                    }
                }
            }
            else
            {
                TxtSelectBuyer.Tag = new tbAgent();
                TxtSelectBuyer.Text = string.Empty;
            }
        }


        private void BtnShowBuyerCard_Click(object sender, EventArgs e)
        {
            tbAgent selectedobject = (tbAgent)TxtSelectBuyer.Tag;
            if (!selectedobject.guid.Equals(Guid.Empty))
            {
                FrmAgent frmtable = new FrmAgent(selectedobject.guid, false, selectedobject.agenttype, false);
                frmtable.ShowDialog();
                selectedobject = tbAgent.FindBy("Guid", selectedobject.guid);
                TxtSelectBuyer.Tag = selectedobject;

            }
            else
            {
                MessageBox.Show("يجب إختيار عميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnSeacrhBuyer_Click(object sender, EventArgs e)
        {
            TxtSelectBuyer_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void BtnAddBuyer_Click(object sender, EventArgs e)
        {
            FrmAgent frm = new FrmAgent(Guid.Empty, true, 1, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TxtSelectBuyer.Tag = frm.AddedAgents;
                TxtSelectBuyer.Text = frm.AddedAgents.name;

                if (CmbBuyerData.SelectedIndex == 0)
                {
                    TxtSelectBuyer.Tag = frm.AddedAgents;
                    TxtSelectBuyer.Text = frm.AddedAgents.name;
                }
                else if (CmbBuyerData.SelectedIndex == 1)
                {
                    TxtSelectBuyer.Tag = frm.AddedAgents;
                    TxtSelectBuyer.Text = frm.AddedAgents.agentname;

                    if (frm.AddedAgents.agentname.Equals(string.Empty))
                    {
                        MessageBox.Show("لم يتم إدخال معلومات الوكيل للعميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CmbBuyerData.Text = "العميل";
                        TxtSelectBuyer.Text = frm.AddedAgents.name;
                    }
                }
            }
        }
        #endregion



        private void CmbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbBuyerData.Focused)
            {
                tbAgent agent = (tbAgent)TxtSelectBuyer.Tag;
                if (CmbBuyerData.SelectedIndex == 0)
                {
                    if (!agent.guid.Equals(Guid.Empty))
                        TxtSelectBuyer.Text = agent.name;
                }
                else if (CmbBuyerData.SelectedIndex == 1)
                {
                    if (!agent.guid.Equals(Guid.Empty))
                        if (agent.agentname.Equals(string.Empty))
                        {
                            MessageBox.Show("لم يتم إدخال معلومات الوكيل للعميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CmbBuyerData.Text = "العميل";
                        }
                        else
                        {
                            TxtSelectBuyer.Text = agent.agentname;
                        }

                }

            }
        }

        bool IsDuplicate(Guid currlandguid)
        {
            int idx = 0;
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                if (landguid.Equals(currlandguid))
                {
                    idx++;
                }

            }

            if (idx > 1)
                return true;
            else
                return false;
        }


        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            tbSaleOrder bill = (tbSaleOrder)bs.Current;

            if (bill is null || bill.guid.Equals(Guid.Empty))
            {

                MessageBox.Show("يجب حفظ أمر البيع أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            tbSaleOrder billheader = (tbSaleOrder)bs.Current;

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "tbPlanInfo");


            Reports.InitReport(rpt, "SaleOrder.frx", false);
            tbSaleOrder.Fill(billheader.guid);

            tbSaleOrder.Fill("Guid", billheader.guid);
            tbSaleOrderBody.Fill("ParentGuid", billheader.guid);
            vwSaleOrderBody.Fill("ParentGuid", billheader.guid);


            tbAgent.Fill("Guid", billheader.buyerguid);
            rpt.RegisterData(tbAgent.dtData, "vwBuyerData");

            rpt.RegisterData(tbSaleOrder.dtData, "billheader");
            rpt.RegisterData(tbSaleOrderBody.dtData, "tbSaleOrderBody");

            rpt.RegisterData(vwSaleOrderBody.dtData, "vwSaleOrderBody");

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);
            rpt.SetParameterValue("HijriDate", DateTimeHelper.ConvertDateCalendar(billheader.regdate, "Hijri", "en-US"));


            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(totalnet, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;

            rpt.SetParameterValue("TotalNetText", toWord.ConvertToArabic());


            try
            {
                ReportPage page = rpt.Pages.OfType<ReportPage>().First();
                FastReport.DataBand DataBuyerAgent = (FastReport.DataBand)rpt.FindObject("DataBuyerAgent");

                if (bill.buyerdata == "الوكيل")
                {
                    DataBuyerAgent.Visible = true;

                }
                else
                {
                    DataBuyerAgent.Visible = false;

                }

            }
            catch
            {

            }



            return true;
        }

        private void MenuDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                Reports.DesignReport(report);
        }

        private void MenuPreView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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



        private void GridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                Guid landguid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColLandGuid).ToString());

                string status = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColStatus).ToString();
                 
                if (!landguid.Equals(Guid.Empty))
                {
                    MenuGrid.ShowPopup(System.Windows.Forms.Control.MousePosition);
                }
            }
        }

        private void MenuLand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid landguid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColLandGuid).ToString());

            FrmLand frm = new FrmLand(landguid, false, string.Empty);
            frm.Show(this);
        }

       
 

        private void MenuPrintLandInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid landguid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColLandGuid).ToString());
            tbLand land = tbLand.FindBy("Guid", landguid);

            if (land is null || land.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختار الأرض أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FastReport.Report rpt = new Report();

            Reports.InitReport(rpt, "land.frx", false);
            tbLand.Fill(land.guid);
            tbPlanInfo.Fill();

            tbAgent.Fill("agenttype", 0);


            rpt.RegisterData(tbAgent.dtData, "ownerdata");

            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");

            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(total, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = land.total;

            rpt.SetParameterValue("TotalText", toWord.ConvertToArabic());


            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.RegisterData(tbLand.dtData, "data");
            rpt.RegisterData(tbPlanInfo.dtData, "tbPlanInfo");

            rpt.Show();
        }

        private void BtnAddFromBlock_Click(object sender, EventArgs e)
        {
            vwSelectLand selectland = new vwSelectLand();


            vwSelectLand.Fill("code", " ", "متاح");

            FrmSelect frmselect = new FrmSelect("إختيار بلوك", typeof(vwSelectLand), vwSelectLand.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectland = vwSelectLand.FindBy("guid", frmselect.guid);

                if (MessageBox.Show(string.Format("هل أنت متأكد من إدراج كافة الأراضي الغير مباعة التابعة للبلوك رقم {0} في أمر البيع ؟", selectland.blocknumber), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                tbLand.FillByBlockState("BlockNumber", selectland.blocknumber.ToString(), "متاح");

                int startidx = privatebillBody.Rows.Count;

                for (int i = 0; i < tbLand.lstData.Count; i++)
                {
                    tbLand land = tbLand.lstData[i];
                    privatebillBody.Rows.Add(
                        Guid.Empty, // Guid
                            Guid.Empty, // ParentGuid
                            land.guid, // LandGuid 
                            0, //Number

                            0, // Code
                            string.Empty, // Land
                            land.amount, // Price



                            DBNull.Value, // Total 
                            string.Empty,  // Note
                            string.Empty); // status

                }

                for (int i = startidx; i < GridView1.RowCount; i++)
                {
                    Guid guid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                    tbLand land = tbLand.FindBy("Guid", guid);
                    FillLandInfo(i, land);
                    CalcRowPrices(i, land);
                }


                for (int i = 0; i < GridView1.RowCount; i++)
                {
                    Guid guid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                    if (guid.Equals(Guid.Empty))
                    {
                        privatebillBody.Rows[i].Delete();
                    }
                }
                AddNewRow();
                ReNumberGrid();
                CalcBillBody();
            }


        }

        private void BtnConvertToContract_Click(object sender, EventArgs e)
        {
            tbSaleOrder bill = (tbSaleOrder)bs.Current;

            if (bill is null || bill.guid.Equals(Guid.Empty))
            {

                MessageBox.Show("يجب حفظ أمر البيع أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ;
            }


            List<tbLand> lstland = new List<tbLand>();
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid guid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                tbLand land = tbLand.FindBy("Guid", guid);
                lstland.Add(land);
            }
            FrmBillHeader frm = new FrmBillHeader(Guid.Empty, true, 0, lstland);
            frm.Show(this);
        }
    }
}
