using DataBaseTemplate;
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
using static DevExpress.Utils.Svg.CommonSvgImages;
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
using FastReport.Dialog;
using DevExpress.XtraGrid.Controls;

namespace DataBaseTemplate
{
    public partial class FrmPayContract : XtraForm
    {

        BindingSource bs;
        Guid guid;

        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool isNew;



        public FrmPayContract(Guid guid, bool isNew)
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
            tbPayContractHeader.Fill();
            bs = new BindingSource(tbPayContractHeader.lstData, string.Empty);
            dataNavigator1.DataSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbPayContractHeader.lstData.FindIndex(delegate (tbPayContractHeader obj) { return obj.guid == guid; });
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbPayContractHeader obj = (tbPayContractHeader)bs.Current;

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
                tbPayContractHeader obj = (tbPayContractHeader)bs.Current;


                TxtNote.Text = obj.note;




                FillGrid(obj.guid);
                dtPayDate.DateTime = obj.paydate;

                if (obj is null || obj.guid.Equals(Guid.Empty))
                {


                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    BtnAdd.Visible = true;
                    dtPayDate.DateTime = DateTime.Now;
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
            DataGUIAttribute.AssignFormValues<tbPayContractHeader>(this, new tbPayContractHeader());
            DataGUIAttribute.ClearFormControls<tbPayContractHeader>(this, new tbPayContractHeader());

            CalcBillBody();
            dirtytracker.MarkAsClean();

        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbPayContractHeader obj = (tbPayContractHeader)bs[i];
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

            //FindControl findControl = MainGridReadyItems.Controls.OfType<FindControl>().FirstOrDefault();

            //    findControl.BackColor = Color.LightSteelBlue;

        }

        GridFormatRule FormatRuleDuplicate = new GridFormatRule();
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



            foreach (GridColumn item in GridView1.Columns)
            {

                if (item.FieldName.Equals("amount") ||
                item.FieldName.Equals("totalnet") || item.FieldName.Equals("remain"))
                {
                    item.DisplayFormat.FormatType = FormatType.Numeric;
                    item.DisplayFormat.FormatString = "N2";
                    item.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                }
                else if (item.FieldName.Equals("contractno"))
                {
                    item.DisplayFormat.FormatType = FormatType.Numeric;
                    item.DisplayFormat.FormatString = "N0";
                    item.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                }
                else
                {

                    item.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                }

                item.AppearanceHeader.FontStyleDelta = FontStyle.Bold;
            }

            //FormatConditionRuleUniqueDuplicate formatConditionRule = new FormatConditionRuleUniqueDuplicate();

            //FormatRuleDuplicate.Column = ColLandGuid;
            //FormatRuleDuplicate.ColumnApplyTo = ColLand;
            //FormatRuleDuplicate.Name = "Format0";
            //formatConditionRule.Appearance.BackColor = Color.LightPink;
            //formatConditionRule.Appearance.Options.UseBackColor = true;

            //FormatRuleDuplicate.Rule = formatConditionRule;

            //GridView1.FormatRules.Add(FormatRuleDuplicate);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "number" || view.FocusedColumn.FieldName == "code" || view.FocusedColumn.FieldName == "land" ||
                 view.FocusedColumn.FieldName == "remain" || view.FocusedColumn.FieldName == "totalnet" || view.FocusedColumn.FieldName == "agent")

                e.Cancel = true;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (GridView1.IsNewItemRow(e.RowHandle))
            {
                BeginInvoke(new Action(() =>
                {
                    GridView1.FocusedColumn = ColContractNo;
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

                else if (GridView1.FocusedColumn == ColContractNo)
                {
                    GridView1.FocusedColumn = ColAmount;

                }
                //else if (GridView1.FocusedColumn == ColDiscountTotalText)
                //{


                //}

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (GridView1.FocusedColumn == ColAmount)
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
                if (GridView1.FocusedColumn == ColContractNo)
                {
                    GridView1.DeleteSelectedRows();
                    if (GridView1.RowCount <= 0)
                        AddNewRow();

                    ReNumberGrid();

                    //if (privatebillBody.Rows.Count == 0)
                    //{
                    //    privatebillBody.Rows.Add(
                    //        Guid.Empty, // Guid
                    //        Guid.Empty, // ParentGuid
                    //        Guid.Empty, // LandGuid 
                    //        0, //Number
                    //        0, // Contract NO 
                    //        string.Empty, // Code
                    //        string.Empty, // Land
                    //        DBNull.Value, // Price
                    //        string.Empty, // Discount Total Text
                    //        DBNull.Value, // Discount Total 
                    //        DBNull.Value, // Discount Total Value
                    //        DBNull.Value, // BuildingFeeValue
                    //        DBNull.Value, // WorkFeeValue
                    //        DBNull.Value, // VATValue
                    //         string.Empty, // Discount Fee Text
                    //         DBNull.Value, // DiscountFee 
                    //        DBNull.Value, // DiscountFeeValue
                    //        DBNull.Value, // Total
                    //        DBNull.Value, // Totalnet
                    //        string.Empty); // Note
                    //}
                }

                else
                {
                    e.Handled = true;
                    //GridView1.SetFocusedValue(string.Empty);
                }
            }

        }


        void AddNewRow()
        {
            Guid LasRowGuid = Guid.Empty;
            string strlandguid = string.Empty;
            try
            {
                if (privatebillBody.Rows[privatebillBody.Rows.Count - 1].RowState == DataRowState.Deleted)
                {
                    LasRowGuid = Guid.NewGuid();
                }
                else
                {
                    LasRowGuid = new Guid(privatebillBody.Rows[privatebillBody.Rows.Count - 1]["guid"].ToString());
                }
            }
            catch
            {
                LasRowGuid = Guid.NewGuid();
            }


            if (!LasRowGuid.Equals(Guid.Empty))
            {
                privatebillBody.Rows.Add(
                            Guid.Empty, // Guid
                            Guid.Empty, // ParentGuid
                            0, //Number
                            0, // Contract NO 
                            string.Empty, // Code
                            string.Empty, // Land
                             string.Empty, // agent
                            DBNull.Value, // amount

                            DBNull.Value, // Total  net
                             DBNull.Value, // Remain
                            string.Empty); // Note

                GridView1.UpdateCurrentRow();
                GridView1.MoveNext();
                GridView1.FocusedColumn = ColContractNo;
                ReNumberGrid();
            }

        }
        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            // e.ExceptionMode = ExceptionMode.NoAction;
        }
        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            // e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {

        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {


        }
        #endregion


        DataTable privatebillBody = new DataTable();
        void FillGrid(Guid guid)
        {
            tbPayContractHeader billheader = tbPayContractHeader.FindBy("guid", guid);
            privatebillBody = new DataTable();
            vwPaycontractbody.Fill("parentguid", billheader.guid, privatebillBody);
            MainGridReadyItems.DataSource = privatebillBody;
            if (privatebillBody.Rows.Count <= 0)
            {
                privatebillBody.Rows.Add(
                         Guid.Empty, // Guid
                            Guid.Empty, // ParentGuid
                            0, //Number
                            0, // Contract NO 
                            string.Empty, // Code
                            string.Empty, // Land
                             string.Empty, // agent
                            DBNull.Value, // amount

                            DBNull.Value, // Total  net
                             DBNull.Value, // remain
                            string.Empty); // Note


                GridView1.FocusedColumn = ColContractNo;
            }
            CalcBillBody();
        }

        void FillCmb()
        {


        }





        #region Select Mat 
        private void SelectMat(string keyword)
        {

            int rowhandle = GridView1.FocusedRowHandle;

            tbBillBody billcontract = tbBillBody.FindBy("contractno", keyword);

            if (!billcontract.guid.Equals(Guid.Empty))
            {
                //land = tbLand.FindBy("guid", new Guid(tbLand.dtData.Rows[0]["guid"].ToString()));
            }
            else
            {
                //tbLand.Fill("code", " ", "متاح");

                ////tbLand.Fill(" ");
                //FrmSelect frmselect = new FrmSelect("إختيار صنف", typeof(tbLand), tbLand.dtData);

                //if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    land = tbLand.FindBy("guid", frmselect.guid);
                //}
            }

            if (billcontract is null || billcontract.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("لم يتم العثور على العقد رقم " + keyword, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!billcontract.guid.Equals(Guid.Empty))
            {

                FillContractIno(rowhandle, billcontract.contractno);

                CalcRowPrices(rowhandle);



                GridView1.CloseEditor();
                //GridView1.FocusedColumn = ColSellQty;
            }
            else
            {
                string strContract = GridView1.GetRowCellValue(rowhandle, ColContractNo).ToString();

                if (!strContract.Equals(string.Empty))
                {
                    //tbLand imat = tbLand.FindBy("Guid", matguid);
                    //GridView1.SetRowCellValue(rowhandle, ColLand, "الأرض رقم " + imat.code);
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

        void FillContractIno(int rowhandle, int ContractNo)
        {
            tbBillBody billbody = tbBillBody.FindBy("ContractNo", ContractNo);
            tbBillheader billheader = tbBillheader.FindBy("Guid", billbody.parentguid);
            tbAgent buyer = tbAgent.FindBy("Guid", billheader.buyerguid);
            tbLand land = tbLand.FindBy("Guid", billbody.landguid);

            GridView1.SetRowCellValue(rowhandle, ColGuid, Guid.NewGuid());

            GridView1.SetRowCellValue(rowhandle, ColLand, "الأرض رقم " + land.code);
            GridView1.SetRowCellValue(rowhandle, ColCode, land.code);
            GridView1.SetRowCellValue(rowhandle, ColAgent, buyer.name);
            GridView1.SetRowCellValue(rowhandle, ColTotalNet, billbody.totalnet);
            GridView1.SetRowCellValue(rowhandle, ColRemain, billbody.totalnet);

            //GridView1.SetRowCellValue(rowhandle, ColCode, land.code);

            //  GridView1.SetRowCellValue(rowhandle, ColDiscountValue, discountvalue);

        }
        #endregion

        void AddBillBody(Guid parentguid)
        {
            tbPayContractBody itemsbodydelete = new tbPayContractBody();
            itemsbodydelete.DeleteBy("ParentGuid", parentguid);

            int idx = 1;
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                int ContractNo;

                int.TryParse(GridView1.GetRowCellValue(i, ColContractNo).ToString(), out ContractNo);


                decimal amount;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColAmount).ToString(), out amount);

                string note = GridView1.GetRowCellValue(i, ColNote).ToString();

                if (!ContractNo.Equals(0))
                {
                    tbPayContractBody billbody = new tbPayContractBody();
                    billbody.guid = Guid.NewGuid();
                    billbody.parentguid = parentguid;
                    billbody.number = idx;
                    billbody.contractno = ContractNo;
                    billbody.amount = amount;
                    billbody.note = note;

                    billbody.Insert();
                    idx++;
                }

            }
        }


        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;

            BtnAdd.Visible = true;
            BtnEdit.Visible = false;
            BtnDelete.Enabled = false;



            TxtNote.Text = string.Empty;


            dtPayDate.EditValue = DateTime.Now;

            FillCmb();
            FillGrid(Guid.Empty);

            Clear();

            bs.AddNew();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Add())
                BtnNew.PerformClick();

            dirtytracker.MarkAsClean();

        }

        bool Add()
        {
            tbPayContractHeader billheader = new tbPayContractHeader();

            billheader.guid = Guid.NewGuid();
            billheader.number = tbPayContractHeader.GetMaxNumber("number") + 1;

            billheader.paydate = dtPayDate.DateTime;
            billheader.note = TxtNote.Text;

            if (MessageBox.Show("هل أنت متأكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return false;


            DBConnect.StartTransAction();
            billheader.Insert();
            AddBillBody(billheader.guid);

            if (DBConnect.CommitTransAction())
            {
                bs.Add(billheader);
                ShowConfirm();

                Clear();
                bs.MoveLast();
                FillCmb();
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
            tbPayContractHeader billheader = (tbPayContractHeader)bs.Current;







            billheader.paydate = dtPayDate.DateTime;
            billheader.note = TxtNote.Text;


            if (MessageBox.Show("هل أنت متأكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return false;


            DBConnect.StartTransAction();

            billheader.Update();
            AddBillBody(billheader.guid);



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
            tbPayContractHeader billheader = (tbPayContractHeader)bs.Current;

            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbPayContractBody billbody = new tbPayContractBody();


            DBConnect.StartTransAction();
            billbody.DeleteBy("ParentGuid", billheader.guid);
            billheader.Delete();



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




        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //Guid landguid = Guid.Empty;
            //if (GridView1.GetRowCellValue(e.RowHandle, ColLandGuid) is null)
            //{

            //}
            //else
            //{
            //    landguid = new Guid(GridView1.GetRowCellValue(e.RowHandle, ColLandGuid).ToString());
            //}
            //tbLand land = new tbLand();

            //if (landguid.Equals(Guid.Empty))
            //{
            //    return;
            //}
            //else
            //    land = tbLand.FindBy("Guid", landguid);


            switch (e.Column.Name.ToLower())
            {
                case "colamount":
                    {
                        decimal amount;
                        decimal.TryParse(GridView1.GetRowCellValue(e.RowHandle, ColAmount).ToString(), out amount);

                        decimal totalnet;
                        decimal.TryParse(GridView1.GetRowCellValue(e.RowHandle, ColTotalNet).ToString(), out totalnet);

                        string contractno = GridView1.GetRowCellValue(e.RowHandle, ColContractNo).ToString();

                        //tbPayContractBody.Fill("ContractNo", (object)contractno);
                        //decimal prevbalance = tbPayContractBody.lstData.Sum(x => x.amount);

                        //decimal gridamount = 0;
                        //for (int i = 0; i < GridView1.RowCount; i++)
                        //{
                        //    decimal gridamountbody;
                        //    Guid parentguid = new Guid(GridView1.GetRowCellValue(i, ColParentGuid).ToString());
                        //    if (parentguid.Equals(Guid.Empty))
                        //    {
                        //        decimal.TryParse(GridView1.GetRowCellValue(i, ColAmount).ToString(), out gridamountbody);

                        //        gridamount += gridamountbody;
                        //    }
                        //}


                        //GridView1.SetRowCellValue(e.RowHandle, ColRemain, totalnet - (amount + prevbalance));

                        GridView1.FocusedColumn = ColNote;
                    }
                    break;


                default:
                    break;
            }

            CalcBillBody();
        }

        void CalcRowPrices(int rowhandle)
        {
            //Guid landguid = new Guid(GridView1.GetRowCellValue(rowhandle, ColLandGuid).ToString());

            //decimal amount;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColAmount).ToString(), out amount);

            //decimal workfeevalue;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColWorkFeeValue).ToString(), out workfeevalue);

            //decimal buildingfeevalue;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColBuildingFeeValue).ToString(), out buildingfeevalue);

            //decimal vatvalue;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColRemain).ToString(), out vatvalue);

            //decimal discountotal;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountTotal).ToString(), out discountotal);

            //decimal discountotalvalue;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountTotalValue).ToString(), out discountotalvalue);

            //decimal discountfee;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColTotalNet).ToString(), out discountfee);

            //decimal discountfeevalue;
            //decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountFeeValue).ToString(), out discountfeevalue);

            //if (ChangeVat && !landguid.Equals(Guid.Empty))
            //{
            //    tbLand land = tbLand.FindBy("Guid", landguid);
            //    vatvalue = (workfeevalue - discountfeevalue) * land.vat / 100;

            //    GridView1.SetRowCellValue(rowhandle, ColRemain, vatvalue);
            //}

            //decimal total;
            //total = amount + workfeevalue + buildingfeevalue + vatvalue;

            //decimal totalnet;
            //totalnet = total - (discountfeevalue + discountotalvalue);


            //if (!landguid.Equals(Guid.Empty))
            //{
            //    GridView1.SetRowCellValue(rowhandle, ColTotal, total);
            //    GridView1.SetRowCellValue(rowhandle, ColTotalNet, totalnet);

            //    CalcBillBody();
            //}
            //else
            //{


            //}

        }

        //decimal total;
        //decimal totalnet;
        //decimal discounttotalvalue;
        //decimal discountfeevalue;
        //decimal vatfeevalue;
        //decimal buildingfeevalue;
        //decimal workfeevalue;


        void CalcBillBody()
        {
            //total = 0;
            //totalnet = 0;
            //discounttotalvalue = 0;
            //discountfeevalue = 0;
            //vatfeevalue = 0;
            //buildingfeevalue = 0;
            //workfeevalue = 0;


            //for (int i = 0; i < GridView1.RowCount; i++)
            //{
            //    Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());

            //    decimal bodytotal;
            //    decimal.TryParse(GridView1.GetRowCellValue(i, ColTotal).ToString(), out bodytotal);

            //    decimal bodydiscounttotalvalue;
            //    decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountTotalValue).ToString(), out bodydiscounttotalvalue);

            //    decimal bodydiscountfeevalue;
            //    decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountFeeValue).ToString(), out bodydiscountfeevalue);

            //    decimal bodyvatfeevalue;
            //    decimal.TryParse(GridView1.GetRowCellValue(i, ColRemain).ToString(), out bodyvatfeevalue);

            //    decimal bodybuildingfeevalue;
            //    decimal.TryParse(GridView1.GetRowCellValue(i, ColBuildingFeeValue).ToString(), out bodybuildingfeevalue);

            //    decimal bodyworkfeevalue;
            //    decimal.TryParse(GridView1.GetRowCellValue(i, ColWorkFeeValue).ToString(), out bodyworkfeevalue);


            //    if (!landguid.Equals(Guid.Empty))
            //    {
            //        total += bodytotal;
            //        discounttotalvalue += bodydiscounttotalvalue;
            //        discountfeevalue += bodydiscountfeevalue;
            //        vatfeevalue += bodyvatfeevalue;
            //        buildingfeevalue += bodybuildingfeevalue;
            //        workfeevalue += bodyworkfeevalue;
            //    }
            //}

            //TxtTotal.Text = total.ToString(DataGUIAttribute.CurrencyFormat);
            //Txttotaldiscounttotal.Text = discounttotalvalue.ToString(DataGUIAttribute.CurrencyFormat);
            //Txttotaldiscountfee.Text = discountfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            //TxtTotalVat.Text = vatfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            //Txttotalbuidlingfee.Text = buildingfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            //Txttotalworkfee.Text = workfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            //TxtTotalNet.Text = (total + vatfeevalue + buildingfeevalue + workfeevalue - (discountfeevalue + discounttotalvalue)).ToString(DataGUIAttribute.CurrencyFormat);
        }


        decimal CalcTotal(decimal amount, decimal salesfee, decimal buildingfee, decimal workfee, decimal vatfee, decimal discountotal, decimal discountfee)
        {

            decimal total = amount + (amount * salesfee / 100) + (amount * buildingfee / 100) +
                (amount * workfee / 100) + ((amount * workfee / 100) * vatfee / 100);

            return total;


        }


    }
}
