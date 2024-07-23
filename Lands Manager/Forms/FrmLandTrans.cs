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
using FastReport.Utils;
using SmartArabXLSX.Drawing.Spreadsheet;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using DevExpress.Utils;
using DevExpress.XtraEditors.Frames;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using Org.BouncyCastle.Asn1.X509;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraExport.Helpers;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Management.Smo;
using DgvFilterPopup;

namespace DoctorERP
{
    public partial class FrmLandTrans : KryptonForm
    {
        Guid guid;


        public WinformsDirtyTracking.DirtyTracker dirtytracker;
        bool ShowConfirmMSG = true;



        public FrmLandTrans(Guid guid, bool isNew)
        {
            InitializeComponent();
            dirtytracker = new WinformsDirtyTracking.DirtyTracker(this);


            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);




            this.guid = guid;

            gridView1.ShowingEditor += gridView1_ShowingEditor;
            gridControl1.ProcessGridKey += MainGridReadyItems_ProcessGridKey;
            gridView1.RowUpdated += gridView1_RowUpdated;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.RowCellStyle += GridView1_RowCellStyle;



            InitReadyGrid();




            repositoryItemDateEdit1.Buttons[1].Click += FrmLandTrans_Click;


            FillBillBody();

            FillTransedLand();
        }

        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column == view.Columns[coldeednumber.Name])

            {
                e.Appearance.BackColor = Color.Red;
            }
        }




        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.Name.ToLower())
            {
                case "coldeednumber":
                    {
                        //gridView1.FocusedColumn = colbuildingnumber;
                    }
                    break;
                case "colbuildingnumber":
                    {
                        //gridView1.FocusedColumn = Colnote;
                    }
                    break;
                default:
                    break;
            }

        }



        private void FrmLandTrans_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, colregdate, DBNull.Value);
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {


            dirtytracker.MarkAsClean();
        }


        #region Binding





        #endregion

        #region Buttons

        bool Add()
        {
            if (!FrmMain.currentuser.CanAdd)
            {
                MessageBox.Show(("لا تملك صلاحية للقيام بهذا العمل"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            if (ShowConfirmMSG)
            {
                if (MessageBox.Show(("هل أنت متأكد من الحفظ ؟"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return false;
            }

            DBConnect.StartTransAction();

            tbLog.AddLog("إضافة", this.Text, string.Empty);


            AddBillBody();

            if (DBConnect.CommitTransAction())
            {


                ShowConfirm();



            }



            dirtytracker.MarkAsClean();

            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();


            FillTransedLand();
            FillBillBody();

        }




        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        void FillTransedLand()
        {

            vwLandTrans.FillTrans();
            DataGridMain.DataSource = vwLandTrans.dtData;

            DataGUIAttribute.FillGrid(DataGridMain, typeof(vwLandTrans));




            DataGridColumns.SetCustomView(DataGridMain, "الأراضي المفرغة");

            DataGridMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


        #region BillBody
        private void FillBillBody()
        {
            vwLandTrans.FillNotTrans();
            //int end = vwLandBodyTrans.dtData.Rows.Count;
            ////int start = 1;
            ////for (int i = start; i <= end; i++)
            ////{
            ////    vwLandBodyTrans.dtData.Rows.Add(Guid.Empty, Guid.Empty, Guid.Empty, i + 1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            ////}

            gridControl1.DataSource = vwLandTrans.dtData;
            //CalcBillBody();

            ReNumberGrid();
        }




        private void AddBillBody()
        {


            tbLandTrans tbbillbody = new tbLandTrans();

            tbbillbody.DeleteALLNoTrans();
            int idx = 1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Guid landguid = new Guid(gridView1.GetRowCellValue(i, collandguid).ToString());
                string deednumber = gridView1.GetRowCellValue(i, coldeednumber).ToString();
                string buildingnumber = gridView1.GetRowCellValue(i, colbuildingnumber).ToString();
                string note = gridView1.GetRowCellValue(i, Colnote).ToString();

                tbbillbody.guid = Guid.NewGuid();
                tbbillbody.number = idx;
                tbbillbody.landguid = landguid;
                tbbillbody.deednumber = deednumber;
                tbbillbody.buildingnumber = buildingnumber;
                tbbillbody.note = note;

                DateTime RegDate = DateTime.Now;

                try
                {
                    RegDate = (DateTime)gridView1.GetRowCellValue(i, colregdate);
                }
                catch
                {
                    RegDate = new DateTime(1900, 1, 1);
                }

                tbbillbody.regdate = RegDate;

                idx++;
                tbbillbody.Insert();
            }
        }
        #endregion

        #region DataGrid Keys

        void InitReadyGrid()
        {
            GridLocalizer.Active = new MyGridLocalizer();
            DevExpress.Utils.Paint.TextRendererHelper.UseScriptAnalyse = false;
            gridView1.OptionsFind.AllowFindPanel = true;
            gridView1.OptionsFind.FindNullPrompt = "أدخل كلمة للبحث";
            gridView1.OptionsFind.Behavior = FindPanelBehavior.Filter;
            gridView1.OptionsFind.AlwaysVisible = true;

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsCustomization.AllowFilter = false;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsCustomization.AllowSort = false;

            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            gridView1.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True;
            gridView1.RowHeight = 35;

            gridView1.OptionsNavigation.EnterMoveNextColumn = true;

            foreach (GridColumn item in gridView1.Columns)
            {

                if (item.FieldName.Equals("remain") || item.FieldName.Equals("buildingfeevalue"))
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

                item.AppearanceHeader.FontStyleDelta = FontStyle.Bold;
            }




        }




        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;


            if (view.FocusedColumn.FieldName == "number" || view.FocusedColumn.FieldName == "land" || view.FocusedColumn.FieldName == "agent" || view.FocusedColumn.FieldName == "buildingfeevalue" || view.FocusedColumn.FieldName == "remain")
            {
                e.Cancel = true;
            }

        }



        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gridView1.IsNewItemRow(e.RowHandle))
            {
                BeginInvoke(new Action(() =>
                {
                    gridView1.FocusedColumn = ColLand;
                    ReNumberGrid();
                    //GridView1.ShowEditor();
                }));
            }
        }




        void ReNumberGrid()
        {
            for (int i = 0; i <= gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, colnumber, i + 1);
            }
        }



        private void MainGridReadyItems_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            //{
            //    //if (gridView1.FocusedColumn == colnumber)
            //    //{
            //    //    gridView1.FocusedColumn = ColLand;
            //    //}
            //    //else if(gridView1.FocusedColumn == ColLand)
            //    //{
            //    //    gridView1.FocusedColumn = colagent;
            //    //}
            //    //else if (gridView1.FocusedColumn == colagent)
            //    //{
            //    //    gridView1.FocusedColumn = colregdate;
            //    //}
            //    //else if (gridView1.FocusedColumn == colregdate)
            //    //{
            //    //    gridView1.FocusedColumn = coldeednumber;
            //    //}
            //    //else if(gridView1.FocusedColumn == coldeednumber)
            //    //{
            //    //    gridView1.FocusedColumn = colbuildingnumber;
            //    //}
            //    //else if (gridView1.FocusedColumn == colbuildingnumber)
            //    //{
            //    //    gridView1.FocusedColumn = Colnote;
            //    //}
            //    //else
            //    //{

            //    //}
            //}
            //else if (e.KeyCode == Keys.Down)
            //{

            //}
            //else if (e.KeyCode == Keys.Escape)
            //{
            //    e.Handled = true;
            //    return;
            //}
            //else if (e.KeyCode == Keys.Delete)
            //{


            //    //e.Handled = true;

            //}
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


        private void FrmMat_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {

            vwLandTrans.Fill();

            Reports.InitReport(rpt, "sellbill.frx", false);

            tbPlanInfo.Fill();
            rpt.RegisterData(tbPlanInfo.dtData, "planinfodata");

            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.RegisterData(vwLandTrans.dtData, "billdata");

            tbAgent.Fill("agenttype", 0);
            rpt.RegisterData(tbAgent.dtData, "ownerdata");


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





        bool IsPermissionGranted(string PermissionName)
        {
            if (FrmMain.currentuser.IsAdmin)
                return true;


            tbUsersPermissions userper = tbUsersPermissions.FindBy("UserGuid", FrmMain.currentuser.guid, PermissionName);
            return userper.PermissionValue;
        }

        private void BtnAddAgent_Click(object sender, EventArgs e)
        {

        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void repositoryItemDateEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void DataGridMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridView.HitTestInfo hit = DataGridMain.HitTest(e.X, e.Y);
                    DataGridMain.CurrentCell = DataGridMain[hit.ColumnIndex, hit.RowIndex];
                    DataGridMain.ContextMenuStrip = contextMenuStrip1;
                }
            }
            catch
            {
                DataGridMain.ContextMenuStrip = null;
            }
        }

        private void MenuRemove_Click(object sender, EventArgs e)
        {
            Guid guid = new Guid(DataGridMain["guid", DataGridMain.CurrentRow.Index].Value.ToString());
            if (!guid.Equals(Guid.Empty))
            {

                if (MessageBox.Show("هل أنت متأكد من حذف الأرض من الإفراغات، سوف يتم إزالة رقم الصك  و نقل الأرض إلى الأراضي الغير مفرغة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                tbLandTrans land = tbLandTrans.FindBy("Guid", guid);
                land.deednumber = string.Empty;
                land.buildingnumber = string.Empty;
                land.regdate = new DateTime(1900, 1, 1);
                DBConnect.StartTransAction();
                land.Update();
                DBConnect.CommitTransAction();
                FillBillBody();
                FillTransedLand();

                

            }
        }
    }
}
