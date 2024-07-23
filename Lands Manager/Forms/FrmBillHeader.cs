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
    public partial class FrmBillHeader : XtraForm
    {

        BindingSource bs;
        Guid guid;

        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool isNew;


        int billtype;
        tbAgent DefOwner = new tbAgent();
        List<tbLand> SellLand;

        public FrmBillHeader(Guid guid, bool isNew, int billtype, List<tbLand> SellLand)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.SellLand = SellLand;

            dirtytracker = new WinformsDirtyTracking.DirtyTracker(this);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.guid = guid;

            BtnEdit.Visible = true;
            BtnAdd.Visible = false;

            this.isNew = isNew;

            this.billtype = billtype;

            tbAgent.Fill("AgentType", 0);
            DefOwner = tbAgent.lstData[0];

            TxtSelectBuyer.Tag = new tbAgent();
            TxtSelectOwner.Tag = DefOwner;

            if (billtype == 0)
            {
                 this.Text = "عقد بيع";
                LblHint.Text = "عقد بيع أرض";
            }
            else if (billtype == 1)
            {
                this.Text = "مرتجع بيع";
                LblHint.Text = "عقد مرتجع بيع أرض";
            }
            else if (billtype == 2)
            {
                LblAgent.Text = "المشتري";
                LblOwner.Text = "البائع";
                CmbBuyerData.Visible = CmbOwnerData.Visible = false;
                this.Text = "عقد بيع خارجي (صوري)";
                LblHint.Text = "عقد بيع خارجي (صوري)";
            }

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

            if (SellLand.Count > 0)
            {
                BtnAddFromBlock.PerformClick();
            }

            dirtytracker.MarkAsClean();
        }

        #region Binding
        private void InitBinding()
        {
            tbBillheader.Fill("billtype", billtype);
            bs = new BindingSource(tbBillheader.lstData, string.Empty);
            dataNavigator1.DataSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();



            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbBillheader.lstData.FindIndex(delegate (tbBillheader obj) { return obj.guid == guid; });
            }



        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                tbBillheader obj = (tbBillheader)bs.Current;

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
                CheckAllow(new tbBillheader());
                dirtytracker.MarkAsClean();
            }
        }

        private void FillForm()
        {
            if (bs.Count > 0)
            {
                tbBillheader obj = (tbBillheader)bs.Current;


                TxtNote.Text = obj.note;

                tbAgent owner = tbAgent.FindBy("Guid", obj.ownerguid);
                tbAgent buyer = tbAgent.FindBy("Guid", obj.buyerguid);

                TxtSelectBuyer.Tag = buyer;
                TxtSelectOwner.Tag = owner;


                if (obj.buyerdata == "الوكيل")
                {
                    CmbBuyerData.SelectedIndex = 1;
                }
                else
                {
                    CmbBuyerData.SelectedIndex = 0;

                }

                if (obj.ownerdata == "الوكيل")
                {
                    CmbOwnerData.SelectedIndex = 1;
                }
                else if (obj.ownerdata == "المكتب")
                {
                    CmbOwnerData.SelectedIndex = 2;
                }
                else
                {
                    CmbOwnerData.SelectedIndex = 0;

                }

                if (CmbBuyerData.SelectedIndex == 0)
                {
                    TxtSelectBuyer.Text = buyer.name;
                }
                else if (CmbBuyerData.SelectedIndex == 1)
                {
                    TxtSelectBuyer.Text = buyer.agentname;
                }

                if (CmbOwnerData.SelectedIndex == 0)
                {
                    TxtSelectOwner.Text = owner.name;
                }
                else if (CmbOwnerData.SelectedIndex == 1)
                {
                    TxtSelectOwner.Text = owner.agentname;
                }

                Txtlastaction.Text = obj.lastaction;

                FillGrid(obj.guid);
                dtRegDate.DateTime = obj.regdate;

                if (obj is null || obj.guid.Equals(Guid.Empty))
                {
                    TxtSelectBuyer.Tag = new tbAgent();

                    if (billtype == 0)
                    {
                        TxtSelectOwner.Tag = DefOwner;
                        TxtSelectOwner.Text = DefOwner.name;
                    }
                    else if (billtype == 2)
                    {
                        TxtSelectOwner.Tag = new tbAgent();
                        TxtSelectOwner.Text = string.Empty;
                    }

                    TxtSelectBuyer.Text = string.Empty;
                    CmbOwnerData.SelectedIndex = 0;
                    CmbBuyerData.SelectedIndex = 0;
                    BtnDelete.Enabled = false;
                    BtnEdit.Visible = false;
                    Txtlastaction.Text = string.Empty;

                    BtnAdd.Visible = true;
                    dtRegDate.DateTime = DateTime.Now;
                }
                else
                {
                    BtnDelete.Enabled = true;
                    BtnEdit.Visible = true;
                    BtnAdd.Visible = false;


                }

                CheckAllow(obj);
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
            DataGUIAttribute.AssignFormValues<tbBillheader>(this, new tbBillheader());
            DataGUIAttribute.ClearFormControls<tbBillheader>(this, new tbBillheader());

            TxtSelectBuyer.Tag = new tbAgent();
            TxtSelectBuyer.Text = string.Empty;

            if (billtype == 0)
            {
                TxtSelectOwner.Tag = DefOwner;
                TxtSelectOwner.Text = DefOwner.name;
            }
            else if (billtype == 2)
            {
                TxtSelectOwner.Tag = new tbAgent();
                TxtSelectOwner.Text = string.Empty;
            }

            CalcBillBody();


            dirtytracker.MarkAsClean();

            CheckAllow(new tbBillheader());


        }

        void Clear()
        {
            for (int i = 0; i < bs.Count; i++)
            {
                tbBillheader obj = (tbBillheader)bs[i];
                if (obj.guid.Equals(Guid.Empty))
                {
                    bs.Remove(obj);
                }
            }

        }
        #endregion



        void CheckAllow(tbBillheader bill)
        {
            bool Enable;

            if (FrmMain.AllowEdit || bill.guid.Equals(Guid.Empty))
                Enable = true;
            else
                Enable = false;


            if (Enable)
            {
                BtnAddBuyer.Enabled = BtnAddOwner.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                BtnSearchBuyer.Enabled = BtnSearchOwner.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            }
            else
            {
                BtnAddBuyer.Enabled = BtnAddOwner.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                BtnSearchBuyer.Enabled = BtnSearchOwner.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            }

            TxtSelectOwner.Enabled = TxtSelectBuyer.ReadOnly = !Enable;

            TxtNote.ReadOnly = !Enable;
            GridView1.OptionsBehavior.Editable = Enable;

            dtRegDate.Enabled = Enable;
            BtnAddFromBlock.Enabled = Enable;
            CmbBuyerData.Enabled = Enable;
            CmbOwnerData.Enabled = Enable;
            BtnEdit.Enabled = Enable;
            BtnDelete.Enabled = Enable;


        }

        #region grid

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            FindControl findControl = MainGridReadyItems.Controls.OfType<FindControl>().FirstOrDefault();
            if (billtype == 0)
                findControl.BackColor = Color.LightSteelBlue;
            else if (billtype == 1)
                findControl.BackColor = Color.LightPink;
            else if (billtype == 2)
                findControl.BackColor = Color.LightGreen;
        }

        GridFormatRule FormatRuleDuplicate = new GridFormatRule();
        FormatConditionRuleUniqueDuplicate formatConditionRule;

        GridFormatRule FormatRuleValue = new GridFormatRule();
        //FormatConditionRuleExpression formatConditionValue;

        void InitReadyGrid()
        {
            GridLocalizer.Active = new MyGridLocalizer();
            DevExpress.Utils.Paint.TextRendererHelper.UseScriptAnalyse = false;
            GridView1.OptionsFind.AllowFindPanel = false;
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

            foreach (GridBand item in GridView1.Bands)
            {
                item.AppearanceHeader.ForeColor = Color.Black;
                item.AppearanceHeader.Font = new Font(item.AppearanceHeader.Font.FontFamily, 9.75F, FontStyle.Bold);
                item.AppearanceHeader.FontStyleDelta = FontStyle.Bold;
            }

            foreach (GridColumn item in GridView1.Columns)
            {


                if (item.FieldName.Equals("price") ||
                item.FieldName.Equals("total") || item.FieldName.Equals("totalnet") || item.FieldName.Equals("vatvalue") ||
                item.FieldName.Equals("workfeevalue") || item.FieldName.Equals("discounttotalvalue") || item.FieldName.Equals("buildingfeevalue") ||
                item.FieldName.Equals("discountfeevalue") || item.FieldName.Equals("discounttotal") || item.FieldName.Equals("discountfee") ||
                item.FieldName.Equals("networkfee") || item.FieldName.Equals("vatworkfee") || item.FieldName.Equals("netprice"))
                {
                    item.DisplayFormat.FormatType = FormatType.Numeric;
                    item.DisplayFormat.FormatString = "N2";
                    item.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                    RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                    editor.Mask.MaskType = MaskType.Numeric;
                    editor.Mask.EditMask = "N2";
                    item.ColumnEdit = editor;
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

            if (billtype == 0)
            {


                if (view.FocusedColumn.FieldName == "price" && !AllowEditPrice)
                {
                    e.Cancel = true;
                }


                if (view.FocusedColumn.FieldName == "number" || view.FocusedColumn.FieldName == "contractno" || view.FocusedColumn.FieldName == "code" || view.FocusedColumn.FieldName == "total" || view.FocusedColumn.FieldName == "buildingfeevalue" ||
                    view.FocusedColumn.FieldName == "networkfee" || view.FocusedColumn.FieldName == "netprice" || view.FocusedColumn.FieldName == "vatvalue" || view.FocusedColumn.FieldName == "totalnet")
                {
                    e.Cancel = true;
                }
                else
                {


                }
            }
            else
            {
                if (view.FocusedColumn.FieldName == "number" || view.FocusedColumn.FieldName == "code" || view.FocusedColumn.FieldName == "total" || view.FocusedColumn.FieldName == "buildingfeevalue" ||
                        view.FocusedColumn.FieldName == "networkfee" || view.FocusedColumn.FieldName == "netprice" || view.FocusedColumn.FieldName == "vatvalue" || view.FocusedColumn.FieldName == "totalnet" || view.FocusedColumn.FieldName == "workfeevalue")
                {
                    e.Cancel = true;
                }
                else
                {


                }
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

                else if (GridView1.FocusedColumn == ColDiscountFeeText)
                {


                }
                else if (GridView1.FocusedColumn == ColDiscountTotalText)
                {


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
                    int contractno;
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColContractNo).ToString(), out contractno);
                    string status = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColStatus).ToString();

                    if (billtype == 0)
                    {
                        if (contractno > 0)
                        {
                            if (FrmMain.currentuser.IsAdmin)
                            {
                                if (status.Equals("مرتجع"))
                                {
                                    if (MessageBox.Show("هل أنت متأكد من حذف العقد ؟ إن حذفه قد يؤدي إلى إخفاءه من النظام بشكل كامل", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    {
                                        e.Handled = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("هل أنت متأكد من حذف العقد ؟ إن حذفه قد يؤدي إلى إخفاءه من النظام بشكل كامل ، يفضل تحويله إلى مرتجع بضغط زر الفأرة الأيمن على العقد بدل حذفه", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    {
                                        e.Handled = true;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("لا يمكن حذف العقد المحفوظ إلا من قبل مدير النظام", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Handled = true;
                                return;
                            }
                        }
                    }


                    GridView1.DeleteSelectedRows();

                    if (GridView1.RowCount <= 0)
                        AddNewRow();

                    if (GridView1.RowCount > 0)
                    {
                        if (billtype == 1)
                        {
                            Guid firstlandguid = new Guid(GridView1.GetRowCellValue(0, ColLandGuid).ToString());
                            if (firstlandguid != Guid.Empty)
                            {
                                tbBillBody billbody = tbBillBody.FindBy("LandGuid", firstlandguid, "مباع");
                                tbBillheader bill = tbBillheader.FindBy("Guid", billbody.parentguid);
                                tbAgent agent = tbAgent.FindBy("Guid", bill.buyerguid);
                                TxtSelectBuyer.Text = agent.name;
                                TxtSelectBuyer.Tag = agent;
                            }
                            else
                            {
                                TxtSelectBuyer.Text = string.Empty;
                                TxtSelectBuyer.Tag = new tbAgent();
                            }
                        }
                    }

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
                            0, // Contract NO 
                            0, // Code
                            string.Empty, // Land
                            DBNull.Value, // Price
                            string.Empty, // Discount Total Text
                            DBNull.Value, // Discount Total 
                            DBNull.Value, // Discount Total Value
                            DBNull.Value, // BuildingFeeValue
                            DBNull.Value, // WorkFeeValue
                            DBNull.Value, // VATValue
                             string.Empty, // Discount Fee Text
                             DBNull.Value, // DiscountFee 
                            DBNull.Value, // DiscountFeeValue
                             DBNull.Value, // Net Price
                              DBNull.Value, // Net WorkFee
                                DBNull.Value, // VAT WorkFee
                            DBNull.Value, // Total
                            DBNull.Value, // Totalnet
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

            tbBillheader billheader = tbBillheader.FindBy("guid", guid);
            privatebillBody = new DataTable();
            vwBillBody.Fill("parentguid", billheader.guid, privatebillBody);
            MainGridReadyItems.DataSource = privatebillBody;
            if (privatebillBody.Rows.Count <= 0)
            {
                privatebillBody.Rows.Add(
                            Guid.Empty, // Guid
                            Guid.Empty, // ParentGuid
                            Guid.Empty, // LandGuid 
                            0, //Number
                            0, // Contract NO 
                            0, // Code
                            string.Empty, // Land
                            DBNull.Value, // Price
                            string.Empty, // Discount Total Text
                            DBNull.Value, // Discount Total 
                            DBNull.Value, // Discount Total Value
                            DBNull.Value, // BuildingFeeValue
                            DBNull.Value, // WorkFeeValue
                            DBNull.Value, // VATValue
                            string.Empty, // Discount Fee Text
                            DBNull.Value, // DiscountFee 
                            DBNull.Value, // DiscountFeeValue
                            DBNull.Value, // Net Price
                            DBNull.Value, // Net WorkFee
                            DBNull.Value, // Vat WorkFee
                            DBNull.Value, // Total
                            DBNull.Value, // Totalnet
                            string.Empty,  // Note
                            string.Empty); // status

                GridView1.FocusedColumn = ColLand;
            }
            CalcBillBody();
        }

        void FillCmb()
        {
            CmbOwnerData.SelectedIndex = 0;
            CmbBuyerData.SelectedIndex = 0;

        }

        #region Select Mat 
        private void SelectMat(string keyword, int row)
        {
            vwSelectLand selectland = new vwSelectLand();

            int rowhandle = row;

            if (billtype == 0)
                vwSelectLand.Fill("code", (object)keyword, "متاح");
            else if (billtype == 1)
                vwSelectLand.Fill("code", (object)keyword, "مباع");
            else if (billtype == 2)
                vwSelectLand.Fill("code", keyword);

            if (vwSelectLand.dtData.Rows.Count == 1)
            {
                selectland = vwSelectLand.FindBy("guid", new Guid(vwSelectLand.dtData.Rows[0]["guid"].ToString()));
            }
            else
            {
                if (billtype == 0)
                    vwSelectLand.Fill("code", " ", "متاح");
                else if (billtype == 1)
                    vwSelectLand.Fill("code", " ", "مباع");
                else if (billtype == 2)
                    vwSelectLand.Fill("code", " ");

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

                CalcRowPrices(rowhandle, land, false, 0, false);

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

                SelectMat(buttonEdit.Text, GridView1.FocusedRowHandle);
            }
        }


        private void SelectItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;

            SelectMat(buttonEdit.Text, GridView1.FocusedRowHandle);
        }

        void FillLandInfo(int rowhandle, tbLand land)
        {

            GridView1.SetRowCellValue(rowhandle, ColLand, "الأرض رقم " + land.number);
            GridView1.SetRowCellValue(rowhandle, ColLandGuid, land.guid);

            GridView1.SetRowCellValue(rowhandle, ColPrice, land.amount);
            GridView1.SetRowCellValue(rowhandle, ColCode, land.code);

            decimal workfeevalue;
            workfeevalue = land.amount * land.workfee / 100;
            GridView1.SetRowCellValue(rowhandle, ColWorkFeeValue, workfeevalue);

            decimal buildingvalue;
            buildingvalue = land.amount * land.buildingfee / 100;
            GridView1.SetRowCellValue(rowhandle, ColBuildingFeeValue, buildingvalue);

            decimal vatvalue;
            vatvalue = workfeevalue * land.vat / 100;
            GridView1.SetRowCellValue(rowhandle, ColVatValue, vatvalue);

            GridView1.SetRowCellValue(rowhandle, ColDiscountTotal, 0);
            GridView1.SetRowCellValue(rowhandle, ColDiscountTotalValue, 0);
            GridView1.SetRowCellValue(rowhandle, ColDiscountTotalText, string.Empty);

            GridView1.SetRowCellValue(rowhandle, ColDiscountFee, 0);
            GridView1.SetRowCellValue(rowhandle, ColDiscountFeeValue, 0);
            GridView1.SetRowCellValue(rowhandle, ColDiscountFeeText, string.Empty);

            GridView1.SetRowCellValue(rowhandle, ColNetWorkFee, workfeevalue);
            GridView1.SetRowCellValue(rowhandle, ColNetPrice, land.amount);


            GridView1.SetRowCellValue(rowhandle, ColTotal, workfeevalue + vatvalue + buildingvalue + land.amount);

            if (billtype == 1)
            {
                tbBillBody billbody = tbBillBody.FindBy("LandGuid", land.guid, "مباع");
                tbBillheader bill = tbBillheader.FindBy("Guid", billbody.parentguid);
                tbAgent agent = tbAgent.FindBy("Guid", bill.buyerguid);
                TxtSelectBuyer.Text = agent.name;
                TxtSelectBuyer.Tag = agent;
            }

        }
        #endregion

        void AddBillBody(Guid parentguid, bool updatemode)
        {
            DataTable tbOldBillBody = new DataTable();

            vwBillBody.Fill("ParentGuid", parentguid, tbOldBillBody, true);

            if (billtype == 2)
            {

                tbBillBody itemsbodydelete = new tbBillBody();
                itemsbodydelete.DeleteBy("ParentGuid", parentguid);
            }

            int idx = 1;
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid guid = new Guid(GridView1.GetRowCellValue(i, ColGuid).ToString());
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                //Guid manguid = new Guid(GridView1.GetRowCellValue(i, ColManFactorGuid).ToString());
                decimal bodytotal;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColTotal).ToString(), out bodytotal);

                decimal bodytotalnet;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColTotalNet).ToString(), out bodytotalnet);

                int contractno;
                int.TryParse(GridView1.GetRowCellValue(i, ColContractNo).ToString(), out contractno);


                decimal bodydiscounttotalvalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountTotalValue).ToString(), out bodydiscounttotalvalue);

                decimal bodydiscountfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountFeeValue).ToString(), out bodydiscountfeevalue);

                decimal bodydiscounttotal;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountTotal).ToString(), out bodydiscounttotal);

                decimal bodydiscountfee;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountFee).ToString(), out bodydiscountfee);


                decimal bodyvatfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColVatValue).ToString(), out bodyvatfeevalue);

                decimal bodybuildingfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColBuildingFeeValue).ToString(), out bodybuildingfeevalue);

                decimal bodyworkfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColWorkFeeValue).ToString(), out bodyworkfeevalue);

                decimal bodyprice;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColPrice).ToString(), out bodyprice);

                string discounttotaltext = GridView1.GetRowCellValue(i, ColDiscountTotalText).ToString();
                string discountfeetext = GridView1.GetRowCellValue(i, ColDiscountFeeText).ToString();
                string note = GridView1.GetRowCellValue(i, ColNote).ToString();
                string status = GridView1.GetRowCellValue(i, ColStatus).ToString();

                if (!landguid.Equals(Guid.Empty))
                {
                    tbBillBody billbody = new tbBillBody();

                    billbody.PlanGuid = FrmMain.PlanGuid;
                    billbody.parentguid = parentguid;
                    billbody.landguid = landguid;
                    billbody.number = idx;
                    billbody.price = bodyprice;
                    billbody.discounttotaltext = discounttotaltext;
                    billbody.discounttotal = bodydiscounttotal;
                    billbody.discounttotalvalue = bodydiscounttotalvalue;
                    billbody.buildingfeevalue = bodybuildingfeevalue;
                    billbody.workfeevalue = bodyworkfeevalue;
                    billbody.vatvalue = bodyvatfeevalue;
                    billbody.discountfeetext = discountfeetext;
                    billbody.discountfee = bodydiscountfee;
                    billbody.discountfeevalue = bodydiscountfeevalue;
                    billbody.total = bodytotal;
                    billbody.totalnet = bodytotalnet;
                    billbody.note = note;

                    tbLand land = tbLand.FindByTrans("Guid", billbody.landguid);
                    if (billtype == 0)
                    {
                        billbody.status = status;

                        if (billbody.status.Trim().Length.Equals(string.Empty))
                        {
                            billbody.status = "مباع";
                        }

                        land.status = "مباع";
                        land.Update();
                    }
                    else if (billtype == 1)
                    {
                        billbody.status = "متاح";
                    }
                    else if (billtype == 2)
                    {
                        billbody.status = "عقد خارجي";
                    }

                    if (billtype == 0)
                    {
                        if (guid.Equals(Guid.Empty) && contractno <= 0)
                        {
                            billbody.guid = Guid.NewGuid();
                            if (billtype == 0)
                            {
                                billbody.contractno = tbBillBody.GetMaxNumberTrans("ContractNo", 0) + 1;
                            }
                            else
                            {

                                billbody.contractno = contractno;
                            }

                            billbody.status = "مباع";
                            billbody.Insert();
                        }
                        else if (contractno > 0 && !guid.Equals(Guid.Empty))
                        {
                            billbody.guid = guid;
                            billbody.contractno = contractno;
                            billbody.Update();
                        }
                    }
                    else if (billtype == 2)
                    {
                        //billbody.guid = Guid.NewGuid();
                        //billbody.contractno = contractno;
                        //billbody.Insert();

                        if (guid.Equals(Guid.Empty) && contractno <= 0)
                        {
                            billbody.guid = Guid.NewGuid();

                            billbody.contractno = tbBillBody.GetMaxNumberTrans("ContractNo", 2) + 1;



                            billbody.Insert();
                        }
                        else if (contractno > 0 && !guid.Equals(Guid.Empty))
                        {
                            billbody.guid = guid;
                            billbody.contractno = contractno;
                            billbody.Update();
                        }
                    }


                    //tbLand.updatelandstatus(billbody.landguid);

                    idx++;
                }

            }

            if (updatemode)
            {
                foreach (DataRow item in tbOldBillBody.Rows)
                {
                    Guid landguid = new Guid(item["landguid"].ToString());
                    string status = item["status"].ToString();
                    if (!IsRowExist(landguid, status))
                    {
                        Guid delguid = new Guid(item["guid"].ToString());
                        tbBillBody billde = new tbBillBody();
                        billde.DeleteBy("Guid", delguid);

                        tbLand.updatelandstatus(landguid);
                    }
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
                if (billtype == 0)
                {
                    FrmPrintDialog frm = new FrmPrintDialog();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.printtype == 0)
                        {
                            BtnPrint.PerformClick();
                        }
                        else if (frm.printtype == 1)
                        {
                            MenuPrintOnebyOne.PerformClick();
                        }
                    }
                }
                dirtytracker.MarkAsClean();
            }

        }

        bool Add()
        {
            tbBillheader billheader = new tbBillheader();

            tbAgent owner = (tbAgent)TxtSelectOwner.Tag;
            if (owner.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار المالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            tbAgent buyer = (tbAgent)TxtSelectBuyer.Tag;
            if (buyer.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار العميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



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

            if (billtype != 0)
            {
                //bool IsThereEmptyContract = false;
                //for (int i = 0; i < GridView1.RowCount; i++)
                //{
                //    Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                //    int contractno;
                //    int.TryParse(GridView1.GetRowCellValue(i, ColContractNo).ToString(), out contractno);

                //    if (!landguid.Equals(Guid.Empty) && contractno <= 0)
                //        IsThereEmptyContract = true;
                //}

                //if (IsThereEmptyContract)
                //{
                //    if (MessageBox.Show("بعض أرقام العقود غير مدخلة عل أنت متأكد من المتابعة", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                //        return false;
                //}
            }

            billheader.guid = Guid.NewGuid();
            billheader.number = tbBillheader.GetMaxNumber("number", billtype) + 1;
            billheader.ownerdata = CmbOwnerData.Text;
            billheader.buyerdata = CmbBuyerData.Text;
            billheader.ownerguid = owner.guid;
            billheader.buyerguid = buyer.guid;
            billheader.billtype = billtype;
            billheader.regdate = dtRegDate.DateTime;
            billheader.note = TxtNote.Text;

            CalcBillBody();

            decimal total;
            decimal.TryParse(TxtTotal.Text, out total);
            billheader.total = total;

            decimal totalnet;
            decimal.TryParse(TxtTotalNet.Text, out totalnet);
            billheader.totalnet = totalnet;


            decimal totalbuidlingfee;
            decimal.TryParse(Txttotalbuidlingfee.Text, out totalbuidlingfee);
            billheader.totalbuidlingfee = totalbuidlingfee;

            decimal totaldiscountfee;
            decimal.TryParse(Txttotaldiscountfee.Text, out totaldiscountfee);
            billheader.totaldiscountfee = totaldiscountfee;

            decimal totaldiscounttotal;
            decimal.TryParse(Txttotaldiscounttotal.Text, out totaldiscounttotal);
            billheader.totaldiscounttotal = totaldiscounttotal;


            decimal totalworkfee;
            decimal.TryParse(Txttotalworkfee.Text, out totalworkfee);
            billheader.totalworkfee = totalworkfee;

            decimal totalvat;
            decimal.TryParse(TxtTotalVat.Text, out totalvat);
            billheader.totalvat = totalvat;


            billheader.lastaction = "إضافة" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;


            if (MessageBox.Show("هل أنت متأكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return false;

            DBConnect.StartTransAction();
            billheader.Insert();

            tbLog.AddLog("إضافة", this.Text, billheader.number.ToString());
            AddBillBody(billheader.guid, false);
            if (billtype == 1)
            {
                //if (tbLand.IsAgentDiffTrans(billheader.guid))
                //{
                //    MessageBox.Show("لا يمكن الحفظ الأصناف المضافة لا تتبع لمشتري واحد", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    DBConnect.RollBackTransAction();
                //    return false;
                //}
            }

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
            tbBillheader billheader = (tbBillheader)bs.Current;



            tbAgent owner = (tbAgent)TxtSelectOwner.Tag;
            if (owner.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار المالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            tbAgent buyer = (tbAgent)TxtSelectBuyer.Tag;
            if (buyer.guid.Equals(Guid.Empty))
            {
                MessageBox.Show("يجب إختيار العميل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

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

            //if (billtype != 0)
            //{
            //    bool IsThereEmptyContract = false;
            //    for (int i = 0; i < GridView1.RowCount; i++)
            //    {
            //        Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
            //        int contractno;
            //        int.TryParse(GridView1.GetRowCellValue(i, ColContractNo).ToString(), out contractno);

            //        if (!landguid.Equals(Guid.Empty) && contractno <= 0)
            //            IsThereEmptyContract = true;
            //    }

            //    if (IsThereEmptyContract)
            //    {
            //        if (MessageBox.Show("بعض أرقام العقود غير مدخلة عل أنت متأكد من المتابعة", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //            return false;
            //    }
            //}


            billheader.ownerdata = CmbOwnerData.Text;
            billheader.buyerdata = CmbBuyerData.Text;
            billheader.ownerguid = owner.guid;
            billheader.buyerguid = buyer.guid;
            billheader.billtype = billtype;
            billheader.regdate = dtRegDate.DateTime;
            billheader.note = TxtNote.Text;
            CalcBillBody();

            decimal total;
            decimal.TryParse(TxtTotal.Text, out total);
            billheader.total = total;

            decimal totalnet;
            decimal.TryParse(TxtTotalNet.Text, out totalnet);
            billheader.totalnet = totalnet;


            decimal totalbuidlingfee;
            decimal.TryParse(Txttotalbuidlingfee.Text, out totalbuidlingfee);
            billheader.totalbuidlingfee = totalbuidlingfee;

            decimal totaldiscountfee;
            decimal.TryParse(Txttotaldiscountfee.Text, out totaldiscountfee);
            billheader.totaldiscountfee = totaldiscountfee;

            decimal totaldiscounttotal;
            decimal.TryParse(Txttotaldiscounttotal.Text, out totaldiscounttotal);
            billheader.totaldiscounttotal = totaldiscounttotal;


            decimal totalworkfee;
            decimal.TryParse(Txttotalworkfee.Text, out totalworkfee);
            billheader.totalworkfee = totalworkfee;

            decimal totalvat;
            decimal.TryParse(TxtTotalVat.Text, out totalvat);
            billheader.totalvat = totalvat;

            billheader.lastaction = "تعديل" + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " " + FrmMain.currentuser.name;

            if (MessageBox.Show("هل أنت متأكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return false;

            if (billtype == 0 && tbEditPassword.lstData[0].password.Trim().Length > 0)
            {
                FrmEditPassWord frm = new FrmEditPassWord(Guid.Empty, true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("لم يتم التعديل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                }
            }


            DBConnect.StartTransAction();

            billheader.Update();

            tbLog.AddLog("تعديل", this.Text, billheader.number.ToString());
            AddBillBody(billheader.guid, true);



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
            tbBillheader billheader = (tbBillheader)bs.Current;

            bool IsFound = false;

            for (int i = 0; i < GridView1.RowCount; i++)
            {
                int contract;

                int.TryParse(GridView1.GetRowCellValue(i, ColContractNo).ToString(), out contract);

                tbPayContract pay = tbPayContract.FindBy("contractno", contract);
                if (!pay.guid.Equals(Guid.Empty))
                {
                    IsFound = true;
                }
            }

            if (IsFound)
            {
                MessageBox.Show("لا يمكن حذف العقد لأنه مستخدم في سندات القبض", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbBillBody.Fill();


            tbBillBody billbody = new tbBillBody();


            if (billtype == 0 && tbEditPassword.lstData[0].password.Trim().Length > 0)
            {
                FrmEditPassWord frm = new FrmEditPassWord(Guid.Empty, true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("لم يتم الحذف", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }

            DBConnect.StartTransAction();
            billbody.DeleteBy("ParentGuid", billheader.guid);
            billheader.Delete();
            tbLog.AddLog("حذف", this.Text, billheader.number.ToString());
            foreach (var item in tbBillBody.lstData)
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



                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, string.Empty);
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, 0);
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, 0);

                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, string.Empty);
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, 0);
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, 0);



                        decimal amount;
                        decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColPrice).ToString(), out amount);

                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue, amount * land.workfee / 100);

                        CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, false);

                    }
                    break;
                case "colworkfeevalue":
                    {

                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, string.Empty);
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, 0);
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, 0);

                        //GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, string.Empty);
                        //GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, 0);
                        //GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, 0);
                        decimal tmpworkfee;
                        decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue).ToString(), out tmpworkfee);

                        CalcRowPrices(GridView1.FocusedRowHandle, land, true, tmpworkfee, true);

                    }
                    break;
                case "coldiscountfeetext":
                    {
                        decimal discountfeetextvalue;
                        string discounttext = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText).ToString();

                        if (discounttext.Contains("%"))
                        {
                            discounttext = discounttext.Replace("%", "");
                            decimal.TryParse(discounttext, out discountfeetextvalue);
                            discounttext = discountfeetextvalue.ToString(DataGUIAttribute.CurrencyFormat) + " %";
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, discounttext);
                        }
                        else
                        {
                            decimal.TryParse(discounttext, out discountfeetextvalue);
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, discountfeetextvalue.ToString(DataGUIAttribute.CurrencyFormat));
                        }

                        if (discountfeetextvalue > 0)
                        {
                            decimal workfee;
                            decimal discount;
                            decimal discountvalue;

                            decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue).ToString(), out workfee);


                            if (discounttext.Contains("%"))
                            {
                                discount = discountfeetextvalue;
                                discountvalue = workfee * discountfeetextvalue / 100;
                            }
                            else
                            {
                                if (workfee > 0)
                                {
                                    discountvalue = discountfeetextvalue;
                                    discount = (workfee - discountvalue) / workfee * 100;
                                }
                                else
                                {
                                    discountvalue = 0;
                                    discount = 0;
                                }
                            }

                            if (land.isdiscountfee)
                            {
                                if (land.discountfeevalue > 0 && discountvalue > land.discountfeevalue)
                                {
                                    MessageBox.Show("الحسم أكبر من القيمة المسموح بها" + Environment.NewLine + "القيمة المسموح بها " + land.discountfeevalue.ToString(DataGUIAttribute.CurrencyFormat), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, string.Empty);
                                    CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, true);
                                    GridView1.CellValueChanged += gridView1_CellValueChanged;
                                    return;
                                }
                                else if (land.discountfee > 0 && discount > land.discountfee)
                                {
                                    MessageBox.Show("الحسم أكبر من النسبة المسموح بها" + Environment.NewLine + "النسبة المسموح بها " + land.discountfee.ToString(DataGUIAttribute.CurrencyFormat), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, string.Empty);
                                    CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, true);
                                    GridView1.CellValueChanged += gridView1_CellValueChanged;
                                    return;
                                }
                            }

                            if (discountvalue > workfee)
                            {
                                MessageBox.Show("لا يمكن أن يكون الحسم أكبر من قيمة العمولة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, 0);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, 0);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeText, string.Empty);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColVatWorkFee, 0);

                                CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, true);
                                GridView1.CellValueChanged += gridView1_CellValueChanged;
                                return;
                            }

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, Math.Round(discount, 2));
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, discountvalue);
                        }
                        else
                        {

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFee, 0);
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountFeeValue, 0);
                        }

                        decimal tmpworkfee;
                        decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue).ToString(), out tmpworkfee);


                        CalcRowPrices(GridView1.FocusedRowHandle, land, true, tmpworkfee, true);
                    }
                    break;

                case "coldiscounttotaltext":
                    {
                        decimal discounttotaltextvalue;
                        string discounttext = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText).ToString();

                        if (discounttext.Contains("%"))
                        {
                            discounttext = discounttext.Replace("%", "");
                            decimal.TryParse(discounttext, out discounttotaltextvalue);
                            discounttext = discounttotaltextvalue.ToString(DataGUIAttribute.CurrencyFormat) + " %";

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, discounttext);

                        }
                        else
                        {
                            decimal.TryParse(discounttext, out discounttotaltextvalue);

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, discounttotaltextvalue.ToString(DataGUIAttribute.CurrencyFormat));

                        }

                        if (discounttotaltextvalue > 0)
                        {
                            decimal price;
                            decimal discount;
                            decimal discountvalue;

                            decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColPrice).ToString(), out price);
                            if (discounttext.Contains("%"))
                            {
                                discount = discounttotaltextvalue;
                                discountvalue = price * discounttotaltextvalue / 100;
                            }
                            else
                            {

                                discountvalue = discounttotaltextvalue;
                                discount = (price - discountvalue) / price * 100;
                            }

                            if (land.isdiscounttotal)
                            {
                                if (land.discounttotalvalue > 0 && discountvalue > land.discounttotalvalue)
                                {
                                    MessageBox.Show("الحسم أكبر من القيمة المسموح بها" + Environment.NewLine + "القيمة المسموح بها " + land.discounttotalvalue.ToString(DataGUIAttribute.CurrencyFormat), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, string.Empty);
                                    CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, false);
                                    GridView1.CellValueChanged += gridView1_CellValueChanged;
                                    return;
                                }
                                else if (land.discounttotal > 0 && discount > land.discounttotal)
                                {
                                    MessageBox.Show("الحسم أكبر من النسبة المسموح بها" + Environment.NewLine + "النسبة المسموح بها " + land.discounttotal.ToString(DataGUIAttribute.CurrencyFormat), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, 0);
                                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, string.Empty);
                                    CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, false);
                                    GridView1.CellValueChanged += gridView1_CellValueChanged;
                                    return;
                                }
                            }

                            if (discountvalue > price)
                            {
                                MessageBox.Show("لا يمكن أن يكون الحسم أكبر من قيمة الأرض", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, 0);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, 0);
                                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalText, string.Empty);
                                CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, false);
                                GridView1.CellValueChanged += gridView1_CellValueChanged;
                                return;
                            }

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, Math.Round(discount, 2));
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, discountvalue);

                            decimal newamount = price - discountvalue;


                            decimal newworkfeevalue = newamount * land.workfee / 100;
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue, newworkfeevalue);

                            //decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue).ToString(), out workfeevalue);

                        }
                        else
                        {


                            decimal amount;
                            decimal.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColPrice).ToString(), out amount);

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColWorkFeeValue, amount * land.workfee / 100);

                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotal, 0);
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDiscountTotalValue, 0);
                        }

                        CalcRowPrices(GridView1.FocusedRowHandle, land, false, 0, false);
                    }
                    break;

                default:
                    break;
            }
            GridView1.CellValueChanged += gridView1_CellValueChanged;

            CalcBillBody();
        }

        void CalcRowPrices(int rowhandle, tbLand land, bool newworkfee, decimal custworkfee, bool ReCalcNetWorkFee)
        {
            decimal amount;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColPrice).ToString(), out amount);

            decimal discountotal;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountTotal).ToString(), out discountotal);

            decimal discountotalvalue;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountTotalValue).ToString(), out discountotalvalue);

            decimal discountfee;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountFee).ToString(), out discountfee);

            decimal discountfeevalue;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountFeeValue).ToString(), out discountfeevalue);

            decimal workfeevalue;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColWorkFeeValue).ToString(), out workfeevalue);

            if ((amount - discountotalvalue) <= 0)
            {
                land.workfee = 0;
                land.vat = 0;
                custworkfee = 0;
            }
            else
            {
                custworkfee = custworkfee / (amount - discountotalvalue) * 100;
            }

            decimal networkfeevalue;

            bool isDiscountFeePercent;

            string DiscountFeePercentText = GridView1.GetRowCellValue(rowhandle, ColDiscountFeeText).ToString();

            if (DiscountFeePercentText.Contains("%"))
                isDiscountFeePercent = true;
            else
                isDiscountFeePercent = false;

            if (ReCalcNetWorkFee)
            {
                if (isDiscountFeePercent)
                {
                    //discount = (workfee - discountvalue) / workfee * 100;
                    if (newworkfee)
                        networkfeevalue = ((amount - discountotalvalue) * custworkfee / 100);
                    else
                        networkfeevalue = ((amount - discountotalvalue) * land.workfee / 100);

                    discountfeevalue = networkfeevalue * discountfee / 100;

                    networkfeevalue = networkfeevalue - discountfeevalue;


                    GridView1.SetRowCellValue(rowhandle, ColNetWorkFee, networkfeevalue);

                    GridView1.SetRowCellValue(rowhandle, ColDiscountFeeValue, discountfeevalue);
                }
                else
                {

                    decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountFeeValue).ToString(), out discountfeevalue);

                    if (discountfeevalue == 0)
                    {
                        if (newworkfee)
                            networkfeevalue = ((amount - discountotalvalue) * custworkfee / 100);
                        else
                            networkfeevalue = ((amount - discountotalvalue) * land.workfee / 100);
                    }
                    else
                    {
                        networkfeevalue = (workfeevalue - discountfeevalue);
                    }
                    GridView1.SetRowCellValue(rowhandle, ColNetWorkFee, networkfeevalue);
                }

                // GridView1.SetRowCellValue(rowhandle, ColVatValue, (networkfeevalue) * land.vat / 100);

            }
            else
            {
                GridView1.SetRowCellValue(rowhandle, ColNetPrice, amount - discountotalvalue);
                GridView1.SetRowCellValue(rowhandle, ColBuildingFeeValue, (amount - discountotalvalue) * land.buildingfee / 100);
                if (newworkfee)
                    GridView1.SetRowCellValue(rowhandle, ColWorkFeeValue, (amount - discountotalvalue) * custworkfee / 100);
                else
                    GridView1.SetRowCellValue(rowhandle, ColWorkFeeValue, (amount - discountotalvalue) * land.workfee / 100);

                if (isDiscountFeePercent)
                {
                    if (newworkfee)
                        networkfeevalue = ((amount - discountotalvalue) * custworkfee / 100);
                    else
                        networkfeevalue = ((amount - discountotalvalue) * land.workfee / 100);

                    discountfeevalue = networkfeevalue * discountfee / 100;

                    networkfeevalue = networkfeevalue - discountfeevalue;


                    GridView1.SetRowCellValue(rowhandle, ColDiscountFeeValue, discountfeevalue);
                }
                else
                {
                    decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColDiscountFeeValue).ToString(), out discountfeevalue);

                    if (newworkfee)
                        networkfeevalue = ((amount - discountotalvalue) * custworkfee / 100) - discountfeevalue;
                    else
                        networkfeevalue = ((amount - discountotalvalue) * land.workfee / 100) - discountfeevalue;


                }


                GridView1.SetRowCellValue(rowhandle, ColNetWorkFee, networkfeevalue);
            }


            GridView1.SetRowCellValue(rowhandle, ColVatValue, networkfeevalue * land.vat / 100);

            decimal netamount;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColNetPrice).ToString(), out netamount);


            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColNetWorkFee).ToString(), out networkfeevalue);

            decimal buildingfeevalue;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColBuildingFeeValue).ToString(), out buildingfeevalue);

            //GridView1.SetRowCellValue(rowhandle, ColVatValue, networkfeevalue * land.vat / 100);

            decimal vatvalue;
            decimal.TryParse(GridView1.GetRowCellValue(rowhandle, ColVatValue).ToString(), out vatvalue);


            GridView1.SetRowCellValue(rowhandle, ColVatWorkFee, networkfeevalue + vatvalue);


            decimal total;
            total = amount;

            decimal totalnet;
            totalnet = total + workfeevalue + vatvalue - (discountfeevalue + discountotalvalue);

            GridView1.SetRowCellValue(rowhandle, ColTotal, total);
            GridView1.SetRowCellValue(rowhandle, ColTotalNet, totalnet);

            CalcBillBody();


        }

        decimal total;
        decimal totalnet;
        decimal discounttotalvalue;
        decimal discountfeevalue;
        decimal vatfeevalue;
        decimal buildingfeevalue;
        decimal workfeevalue;
        decimal networkfeevalue;
        decimal pricetotal;
        decimal workfeediscount;

        void CalcBillBody()
        {
            total = 0;
            totalnet = 0;
            discounttotalvalue = 0;
            discountfeevalue = 0;
            vatfeevalue = 0;
            buildingfeevalue = 0;
            workfeevalue = 0;
            networkfeevalue = 0;
            pricetotal = 0;
            workfeediscount = 0;

            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid landguid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());


                decimal bodytotal;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColTotal).ToString(), out bodytotal);

                decimal bodynettotal;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColTotalNet).ToString(), out bodynettotal);


                decimal bodydiscounttotalvalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountTotalValue).ToString(), out bodydiscounttotalvalue);

                decimal bodydiscountfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColDiscountFeeValue).ToString(), out bodydiscountfeevalue);

                decimal bodyvatfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColVatValue).ToString(), out bodyvatfeevalue);

                decimal bodybuildingfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColBuildingFeeValue).ToString(), out bodybuildingfeevalue);

                decimal bodyworkfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColWorkFeeValue).ToString(), out bodyworkfeevalue);

                decimal bodynetworkfeevalue;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColNetWorkFee).ToString(), out bodynetworkfeevalue);

                decimal bodypricetotal;
                decimal.TryParse(GridView1.GetRowCellValue(i, ColPrice).ToString(), out bodypricetotal);


                string status = GridView1.GetRowCellValue(i, ColStatus).ToString();
                if (!landguid.Equals(Guid.Empty) && !status.Equals("مرتجع"))
                {
                    total += bodytotal;
                    totalnet += bodynettotal;
                    discounttotalvalue += bodydiscounttotalvalue;
                    discountfeevalue += bodydiscountfeevalue;
                    vatfeevalue += bodyvatfeevalue;
                    buildingfeevalue += bodybuildingfeevalue;
                    workfeevalue += bodyworkfeevalue;
                    networkfeevalue += bodynetworkfeevalue;
                    workfeediscount += bodydiscountfeevalue;
                    pricetotal += bodypricetotal;
                }
            }

            TxtPrice.Text = pricetotal.ToString(DataGUIAttribute.CurrencyFormat);
            TxtNetPrice.Text = (pricetotal - discounttotalvalue).ToString(DataGUIAttribute.CurrencyFormat);
            TxtNetPrice2.Text = (pricetotal - discounttotalvalue).ToString(DataGUIAttribute.CurrencyFormat);
            TxtTotal.Text = total.ToString(DataGUIAttribute.CurrencyFormat);
            Txttotaldiscounttotal.Text = discounttotalvalue.ToString(DataGUIAttribute.CurrencyFormat);
            TxtotalworkfeeDiscount.Text = workfeediscount.ToString(DataGUIAttribute.CurrencyFormat);

            Txttotaldiscountfee.Text = (networkfeevalue).ToString(DataGUIAttribute.CurrencyFormat);
            TxtTotalVat.Text = vatfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txttotalbuidlingfee.Text = buildingfeevalue.ToString(DataGUIAttribute.CurrencyFormat);
            Txttotalworkfee.Text = (workfeevalue).ToString(DataGUIAttribute.CurrencyFormat);
            TxtTotalNet.Text = totalnet.ToString(DataGUIAttribute.CurrencyFormat);

            TxtNetPiceNetWorkFee.Text = ((pricetotal - discounttotalvalue) + networkfeevalue).ToString(DataGUIAttribute.CurrencyFormat);
            TxtNetPiceNetWorkFeeVAT.Text = ((pricetotal - discounttotalvalue) + (networkfeevalue + vatfeevalue)).ToString(DataGUIAttribute.CurrencyFormat);

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

        #region Select Owner
        private void TxtSelectOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (billtype == 2)
                {
                    tbAgent.Fill("name", TxtSelectOwner.Text);
                }
                else
                {
                    tbAgent.Fill("name", TxtSelectOwner.Text, 0);
                }

                if (tbAgent.dtData.Rows.Count == 1)
                {
                    tbAgent selectedobject = tbAgent.FindBy("guid", new Guid(tbAgent.dtData.Rows[0]["guid"].ToString()));
                    TxtSelectOwner.Tag = selectedobject;
                    TxtSelectOwner.Text = selectedobject.name;

                    if (CmbOwnerData.SelectedIndex == 0)
                    {
                        TxtSelectOwner.Tag = selectedobject;
                        TxtSelectOwner.Text = selectedobject.name;
                    }
                    else if (CmbOwnerData.SelectedIndex == 1)
                    {
                        TxtSelectOwner.Tag = selectedobject;
                        TxtSelectOwner.Text = selectedobject.agentname;
                        if (selectedobject.agentname.Equals(string.Empty))
                        {
                            MessageBox.Show("لم يتم إدخال معلومات الوكيل للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CmbOwnerData.Text = "المالك";
                            TxtSelectOwner.Text = selectedobject.name;
                        }
                    }
                    else if (CmbOwnerData.SelectedIndex == 2)
                    {
                        TxtSelectOwner.Tag = selectedobject;
                        TxtSelectOwner.Text = selectedobject.officename;
                        if (selectedobject.officename.Equals(string.Empty))
                        {
                            MessageBox.Show("لم يتم إدخال معلومات المكتب للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CmbOwnerData.Text = "المالك";
                            TxtSelectOwner.Text = selectedobject.name;
                        }
                    }
                }
                else if (tbAgent.dtData.Rows.Count == 0)
                {
                    if (billtype == 2)
                    {
                        tbAgent.Fill("name", " ");
                    }
                    else
                    {
                        tbAgent.Fill("name", " ", 0);
                    }

                    ShowSelectOwner();
                }
                else
                {
                    ShowSelectOwner();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelectOwner.Tag = new tbAgent();
                TxtSelectOwner.Text = string.Empty;
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

                if (CmbOwnerData.SelectedIndex == 0)
                {
                    TxtSelectOwner.Tag = selectedobject;
                    TxtSelectOwner.Text = selectedobject.name;
                }
                else if (CmbOwnerData.SelectedIndex == 1)
                {
                    TxtSelectOwner.Tag = selectedobject;
                    TxtSelectOwner.Text = selectedobject.agentname;
                    if (selectedobject.agentname.Equals(string.Empty))
                    {
                        MessageBox.Show("لم يتم إدخال معلومات الوكيل للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CmbOwnerData.Text = "المالك";
                        TxtSelectOwner.Text = selectedobject.name;
                    }
                }
                else if (CmbOwnerData.SelectedIndex == 2)
                {
                    TxtSelectOwner.Tag = selectedobject;
                    TxtSelectOwner.Text = selectedobject.officename;

                    if (selectedobject.officename.Equals(string.Empty))
                    {
                        MessageBox.Show("لم يتم إدخال معلومات المكتب للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CmbOwnerData.Text = "المالك";
                        TxtSelectOwner.Text = selectedobject.name;
                    }
                }
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
                selectedobject = tbAgent.FindBy("Guid", selectedobject.guid);
                TxtSelectOwner.Tag = selectedobject;
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

                if (CmbOwnerData.SelectedIndex == 0)
                {
                    TxtSelectOwner.Tag = frm.AddedAgents;
                    TxtSelectOwner.Text = frm.AddedAgents.name;
                }
                else if (CmbOwnerData.SelectedIndex == 1)
                {
                    TxtSelectOwner.Tag = frm.AddedAgents;
                    TxtSelectOwner.Text = frm.AddedAgents.agentname;
                    if (frm.AddedAgents.agentname.Equals(string.Empty))
                    {
                        MessageBox.Show("لم يتم إدخال معلومات الوكيل للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CmbOwnerData.Text = "المالك";
                        TxtSelectOwner.Text = frm.AddedAgents.name;
                    }
                }
                else if (CmbOwnerData.SelectedIndex == 2)
                {
                    TxtSelectOwner.Tag = frm.AddedAgents;
                    TxtSelectOwner.Text = frm.AddedAgents.officename;

                    if (frm.AddedAgents.officename.Equals(string.Empty))
                    {
                        MessageBox.Show("لم يتم إدخال معلومات المكتب للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CmbOwnerData.Text = "المالك";
                        TxtSelectOwner.Text = frm.AddedAgents.name;
                    }
                }
            }
        }



        #endregion

        private void CmbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbOwnerData.Focused)
            {
                tbAgent agent = (tbAgent)TxtSelectOwner.Tag;
                if (CmbOwnerData.SelectedIndex == 0)
                {
                    if (!agent.guid.Equals(Guid.Empty))

                        TxtSelectOwner.Text = agent.name;
                }
                else if (CmbOwnerData.SelectedIndex == 1)
                {
                    if (!agent.guid.Equals(Guid.Empty))
                        if (agent.agentname.Equals(string.Empty))
                        {
                            MessageBox.Show("لم يتم إدخال معلومات الوكيل للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CmbOwnerData.Text = "المالك";
                        }
                        else
                        {
                            TxtSelectOwner.Text = agent.agentname;
                        }
                }
                else if (CmbOwnerData.SelectedIndex == 2)
                {
                    if (!agent.guid.Equals(Guid.Empty))
                        if (agent.officename.Equals(string.Empty))
                        {
                            MessageBox.Show("لم يتم إدخال معلومات المكتب للمالك", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CmbOwnerData.Text = "المالك";
                        }
                        else
                        {
                            TxtSelectOwner.Text = agent.officename;
                        }
                }


            }
        }

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
            tbBillheader bill = (tbBillheader)bs.Current;

            if (bill is null || bill.guid.Equals(Guid.Empty))
            {

                MessageBox.Show("يجب حفظ العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            tbBillheader billheader = (tbBillheader)bs.Current;

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "tbPlanInfo");

            //
            Reports.InitReport(rpt, "ContractOne.frx", false);
            tbBillheader.Fill(billheader.guid);

            tbBillheader.Fill("Guid", billheader.guid);
            tbBillBody.Fill("ParentGuid", billheader.guid, "مباع");
            vwBillBody.Fill("ParentGuid", billheader.guid, "مباع");

            tbAgent.Fill("Guid", billheader.ownerguid);
            rpt.RegisterData(tbAgent.dtData, "vwOwnerData");

            tbAgent.Fill("Guid", billheader.buyerguid);
            rpt.RegisterData(tbAgent.dtData, "vwBuyerData");

            rpt.RegisterData(tbBillheader.dtData, "billheader");
            rpt.RegisterData(tbBillBody.dtData, "tbBillBody");
            rpt.RegisterData(vwBillBody.dtData, "vwBillBody");



            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);
            rpt.SetParameterValue("HijriDate", DateTimeHelper.ConvertDateCalendar(billheader.regdate, "Hijri", "en-US"));


            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(totalnet, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;

            rpt.SetParameterValue("TotalNetText", toWord.ConvertToArabic());


            toWord = new ToWord(tbBillBody.lstData[0].workfeevalue - tbBillBody.lstData[0].discountfeevalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].workfeevalue - tbBillBody.lstData[0].discountfeevalue;
            rpt.SetParameterValue("workfeevalueText", toWord.ConvertToArabic());


            toWord = new ToWord(tbBillBody.lstData[0].vatvalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].vatvalue;
            rpt.SetParameterValue("vatvalueText", toWord.ConvertToArabic());

            toWord = new ToWord(tbBillBody.lstData[0].vatvalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].price;
            rpt.SetParameterValue("priceText", toWord.ConvertToArabic());

            toWord = new ToWord(tbBillBody.lstData[0].vatvalue - tbBillBody.lstData[0].discounttotalvalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].price - tbBillBody.lstData[0].discounttotalvalue;
            rpt.SetParameterValue("netpriceText", toWord.ConvertToArabic());

            string qrcode = Fatora.QRCode.GenertareCode(tbVATSettings.lstData[0].CompanyName, tbVATSettings.lstData[0].VATID, billheader.regdate.ToString("yyyy-MM-dd HH:mm:ss"), billheader.totalnet.ToString("F2"), billheader.totalvat.ToString("F2"));
            rpt.SetParameterValue("qrcode", qrcode);


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

            try
            {
                ReportPage page = rpt.Pages.OfType<ReportPage>().First();
                FastReport.DataBand DataOwnerAgent = (FastReport.DataBand)rpt.FindObject("DataOwnerAgent");
                FastReport.DataBand DataOwnerOffice = (FastReport.DataBand)rpt.FindObject("DataOwnerOffice");

                if (bill.ownerdata == "الوكيل")
                {
                    DataOwnerAgent.Visible = true;
                    DataOwnerOffice.Visible = false;
                }
                else if (bill.ownerdata == "المكتب")
                {
                    DataOwnerAgent.Visible = false;
                    DataOwnerOffice.Visible = true;
                }
                else
                {
                    DataOwnerAgent.Visible = false;
                    DataOwnerOffice.Visible = false;
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


        private void ReadyreportOneByOne(FastReport.Report rpt, Guid BillBodyGuid)
        {
            tbBillheader bill = (tbBillheader)bs.Current;

            if (bill is null || bill.guid.Equals(Guid.Empty))
            {

                MessageBox.Show("يجب حفظ العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbBillheader billheader = (tbBillheader)bs.Current;

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "tbPlanInfo");

            Reports.InitReport(rpt, "Contract.frx", false);
            tbBillheader.Fill(billheader.guid);

            tbBillheader.Fill("Guid", billheader.guid);


            tbAgent.Fill("Guid", billheader.ownerguid);
            rpt.RegisterData(tbAgent.dtData, "vwOwnerData");

            tbAgent.Fill("Guid", billheader.buyerguid);
            rpt.RegisterData(tbAgent.dtData, "vwBuyerData");


            tbBillBody.Fill("Guid", BillBodyGuid);
            vwBillBody.Fill("Guid", BillBodyGuid);

            rpt.RegisterData(tbBillheader.dtData, "billheader");
            rpt.RegisterData(tbBillBody.dtData, "tbBillBody");
            rpt.RegisterData(vwBillBody.dtData, "vwBillBody");

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.SetParameterValue("HijriDate", DateTimeHelper.ConvertDateCalendar(billheader.regdate, "Hijri", "en-US"));

            NumberToWord.CurrencyInfo currency = new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia);

            ToWord toWord = new ToWord(tbBillBody.lstData[0].totalnet, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].totalnet;
            rpt.SetParameterValue("TotalNetText", toWord.ConvertToArabic());


            toWord = new ToWord(tbBillBody.lstData[0].workfeevalue - tbBillBody.lstData[0].discountfeevalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].workfeevalue - tbBillBody.lstData[0].discountfeevalue;
            rpt.SetParameterValue("workfeevalueText", toWord.ConvertToArabic());


            toWord = new ToWord(tbBillBody.lstData[0].vatvalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].vatvalue;
            rpt.SetParameterValue("vatvalueText", toWord.ConvertToArabic());


            toWord = new ToWord(tbBillBody.lstData[0].price, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].price;
            rpt.SetParameterValue("priceText", toWord.ConvertToArabic());

            toWord = new ToWord(tbBillBody.lstData[0].price - tbBillBody.lstData[0].discounttotalvalue, currency);

            toWord.ArabicPrefixText = string.Empty;
            toWord.EnglishSuffixText = string.Empty;
            toWord.Number = tbBillBody.lstData[0].price - tbBillBody.lstData[0].discounttotalvalue;
            rpt.SetParameterValue("netpriceText", toWord.ConvertToArabic());

            string qrcode = Fatora.QRCode.GenertareCode(tbVATSettings.lstData[0].CompanyName, tbVATSettings.lstData[0].VATID, billheader.regdate.ToString("yyyy-MM-dd HH:mm:ss"), tbBillBody.lstData[0].totalnet.ToString("F2"), tbBillBody.lstData[0].vatvalue.ToString("F2"));
            rpt.SetParameterValue("qrcode", qrcode);


            try
            {
                ReportPage page = rpt.Pages.OfType<ReportPage>().First();
                if (tbBillBody.lstData[0].status == "مرتجع")
                {

                    page.Watermark.Enabled = true;
                }
                else
                {
                    page.Watermark.Enabled = false;

                }
            }
            catch
            {

            }



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

            try
            {
                ReportPage page = rpt.Pages.OfType<ReportPage>().First();
                FastReport.DataBand DataOwnerAgent = (FastReport.DataBand)rpt.FindObject("DataOwnerAgent");
                FastReport.DataBand DataOwnerOffice = (FastReport.DataBand)rpt.FindObject("DataOwnerOffice");

                if (bill.ownerdata == "الوكيل")
                {
                    DataOwnerAgent.Visible = true;
                    DataOwnerOffice.Visible = false;
                }
                else if (bill.ownerdata == "المكتب")
                {
                    DataOwnerAgent.Visible = false;
                    DataOwnerOffice.Visible = true;
                }
                else
                {
                    DataOwnerAgent.Visible = false;
                    DataOwnerOffice.Visible = false;
                }
            }
            catch
            {

            }

            rpt.Prepare(true);
        }


        private void MenuPreviewOneByOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FastReport.Report report = new FastReport.Report();

            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid guid = new Guid(GridView1.GetRowCellValue(i, ColGuid).ToString());

                if (!guid.Equals(Guid.Empty))
                    ReadyreportOneByOne(report, guid);

            }


            report.ShowPrepared();
        }

        private void MenuDesignOneByOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FastReport.Report report = new FastReport.Report();


            Guid guid = new Guid(GridView1.GetRowCellValue(0, ColGuid).ToString());

            if (!guid.Equals(Guid.Empty))
            {
                ReadyreportOneByOne(report, guid);
                Reports.DesignReport(report);
            }
        }

        private void MenuPrintOnebyOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            for (int i = 0; i < GridView1.RowCount; i++)
            {
                Guid guid = new Guid(GridView1.GetRowCellValue(i, ColGuid).ToString());

                if (!guid.Equals(Guid.Empty))
                    ReadyreportOneByOne(report, guid);

            }
            report.PrintPrepared();
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



                if (billtype == 0 && status != "مرتجع")
                {

                    MenuConvertToReturn.Caption = "تحويل إلى مرتجع";

                }
                else
                {
                    MenuConvertToReturn.Caption = "تحويل إلى مباع";
                }

                if (!landguid.Equals(Guid.Empty))
                {
                    MenuGrid.ShowPopup(Control.MousePosition);
                }
            }
        }

        private void MenuLand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid landguid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColLandGuid).ToString());

            FrmLand frm = new FrmLand(landguid, false, string.Empty);
            frm.Show(this);
        }

        private void MenuConvertToReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tbBillheader bill = (tbBillheader)bs.Current;

            if (bill is null || bill.guid.Equals(Guid.Empty))
            {

                MessageBox.Show("يجب حفظ العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            int contractno;
            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColContractNo).ToString(), out contractno);

            string status;
            status = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColStatus).ToString();

            Guid guid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColGuid).ToString());
            if (!tbBillBody.IsExist("Guid", guid))
            {
                MessageBox.Show("يجب حفظ بيانات العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (tbBillBody.IsExist("contractno", contractno))
            {
                if (!status.Equals("مرتجع"))
                {
                    if (MessageBox.Show(string.Format("هل أنت متأكد من تحويل العقد رقم {0} المحدد إلى مرتجع ؟", contractno), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;

                    Guid landguid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColLandGuid).ToString());

                    vwGetBillBodyStatus billbodystate = vwGetBillBodyStatus.FindBy("contractno", contractno, 0);
                    tbBillBody billbodyreturn = tbBillBody.FindBy("Guid", billbodystate.guid);
                    billbodyreturn.status = "مرتجع";
                    DBConnect.StartTransAction();
                    billbodyreturn.Update();
                    tbLand.updatelandstatus(landguid);
                    if (DBConnect.CommitTransAction())
                    {

                        ShowConfirm();
                        FillGrid(bill.guid);
                        BtnNew.PerformClick();
                    }
                }
                else
                {
                    if (MessageBox.Show(string.Format("هل أنت متأكد من تحويل العقد رقم {0} المحدد إلى مباع ؟", contractno), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;

                    Guid landguid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColLandGuid).ToString());

                    vwGetBillBodyStatus billbodystate = vwGetBillBodyStatus.FindBy("contractno", contractno, 0);
                    tbBillBody billbodyreturn = tbBillBody.FindBy("Guid", billbodystate.guid);
                    billbodyreturn.status = "مباع";
                    DBConnect.StartTransAction();
                    billbodyreturn.Update();
                    tbLand.updatelandstatus(landguid);
                    if (DBConnect.CommitTransAction())
                    {
                        ShowConfirm();
                        FillGrid(bill.guid);
                        dirtytracker.MarkAsClean();
                    }
                }
            }
            else
            {
                MessageBox.Show("يجب حفظ العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MenuPreviewOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FastReport.Report report = new FastReport.Report();


            Guid guid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColGuid).ToString());
            if (!tbBillBody.IsExist("Guid", guid))
            {
                MessageBox.Show("يجب حفظ بيانات العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (!guid.Equals(Guid.Empty))
                ReadyreportOneByOne(report, guid);


            report.ShowPrepared();
        }

        private void MenuPrintOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FastReport.Report report = new FastReport.Report();


            Guid guid = new Guid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, ColGuid).ToString());
            if (!tbBillBody.IsExist("Guid", guid))
            {
                MessageBox.Show("يجب حفظ بيانات العقد أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (!guid.Equals(Guid.Empty))
                ReadyreportOneByOne(report, guid);


            report.Print();
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


            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");
            rpt.RegisterData(tbAgent.dtData, "ownerdata");

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
            if (SellLand.Count <= 0)
            {
                vwSelectLand selectland = new vwSelectLand();

                if (billtype == 0)
                    vwSelectLand.Fill("code", " ", "متاح");
                else if (billtype == 2)
                    vwSelectLand.Fill("code", " ");


                FrmSelect frmselect = new FrmSelect("إختيار بلوك", typeof(vwSelectLand), vwSelectLand.dtData);

                if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectland = vwSelectLand.FindBy("guid", frmselect.guid);
                    if (billtype == 0)
                    {
                        if (MessageBox.Show(string.Format("هل أنت متأكد من إدراج كافة الأراضي الغير مباعة التابعة للبلوك رقم {0} في العقد ؟", selectland.blocknumber), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                    else
                    {
                        if (MessageBox.Show(string.Format("هل أنت متأكد من إدراج كافة الأراضي التابعة للبلوك رقم {0} في العقد ؟", selectland.blocknumber), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }

                    if (billtype == 0)
                        tbLand.FillByBlockState("BlockNumber", selectland.blocknumber.ToString(), "متاح");
                    else
                        tbLand.Fill("BlockNumber", (object)selectland.blocknumber);

                    int startidx = privatebillBody.Rows.Count;

                    for (int i = 0; i < tbLand.lstData.Count; i++)
                    {
                        tbLand land = tbLand.lstData[i];
                        privatebillBody.Rows.Add(
                              Guid.Empty, // Guid
                              Guid.Empty, // ParentGuid
                              land.guid, // LandGuid 
                              0, //Number
                              0, // Contract NO 
                              0, // Code
                              string.Empty, // Land
                              DBNull.Value, // Price
                              string.Empty, // Discount Total Text
                              DBNull.Value, // Discount Total 
                              DBNull.Value, // Discount Total Value
                              DBNull.Value, // BuildingFeeValue
                              DBNull.Value, // WorkFeeValue
                              DBNull.Value, // VATValue
                              string.Empty, // Discount Fee Text
                              DBNull.Value, // DiscountFee 
                              DBNull.Value, // DiscountFeeValue
                              DBNull.Value, // Net Price
                              DBNull.Value, // Net WorkFee
                              DBNull.Value, // Vat WorkFee
                              DBNull.Value, // Total
                              DBNull.Value, // Totalnet
                              string.Empty,  // Note
                              string.Empty); // status

                    }

                    for (int i = startidx; i < GridView1.RowCount; i++)
                    {
                        Guid guid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                        tbLand land = tbLand.FindBy("Guid", guid);
                        FillLandInfo(i, land);
                        CalcRowPrices(i, land, false, 0, true);
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
            else
            {
                foreach (tbLand item in SellLand)
                {


                    tbLand.Fill("guid", item.guid);

                    int startidx = privatebillBody.Rows.Count;

                    for (int i = 0; i < tbLand.lstData.Count; i++)
                    {
                        tbLand land = tbLand.lstData[i];
                        privatebillBody.Rows.Add(
                              Guid.Empty, // Guid
                              Guid.Empty, // ParentGuid
                              land.guid, // LandGuid 
                              0, //Number
                              0, // Contract NO 
                              0, // Code
                              string.Empty, // Land
                              DBNull.Value, // Price
                              string.Empty, // Discount Total Text
                              DBNull.Value, // Discount Total 
                              DBNull.Value, // Discount Total Value
                              DBNull.Value, // BuildingFeeValue
                              DBNull.Value, // WorkFeeValue
                              DBNull.Value, // VATValue
                              string.Empty, // Discount Fee Text
                              DBNull.Value, // DiscountFee 
                              DBNull.Value, // DiscountFeeValue
                              DBNull.Value, // Net Price
                              DBNull.Value, // Net WorkFee
                              DBNull.Value, // Vat WorkFee
                              DBNull.Value, // Total
                              DBNull.Value, // Totalnet
                              string.Empty,  // Note
                              string.Empty); // status

                    }

                    for (int i = startidx; i < GridView1.RowCount; i++)
                    {
                        Guid guid = new Guid(GridView1.GetRowCellValue(i, ColLandGuid).ToString());
                        tbLand land = tbLand.FindBy("Guid", guid);
                        FillLandInfo(i, land);
                        CalcRowPrices(i, land, false, 0, true);
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


        }

        bool AllowEditPrice = false;
        private void MenuAllowEditPrice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (billtype == 0 && tbEditPassword.lstData[0].password.Trim().Length > 0)
            {
                FrmEditPassWord frm = new FrmEditPassWord(Guid.Empty, true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AllowEditPrice = true;

                }
                else
                {
                    AllowEditPrice = false;
                }
            }
        }
    }
}
