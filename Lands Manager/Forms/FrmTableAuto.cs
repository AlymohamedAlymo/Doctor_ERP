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
    public partial class FrmTableAuto : KryptonForm
    {
        Guid guid;
        BindingSource bs;

        public FrmTableAuto(Guid guid)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();

            TxtSelect.Tag = new tbSelectObject();


            this.guid = guid;
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();
        }


        #region Binding
        private void InitBinding()
        {
            tbTable.Fill();
            bs = new BindingSource(tbTable.lstData, string.Empty);
            bindingNavigator1.BindingSource = bs;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            FillForm();
            bs.MoveLast();

            if (!guid.Equals(Guid.Empty))
            {
                bs.Position = tbTable.lstData.FindIndex(delegate (tbTable table) { return table.Guid == guid; });
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
                tbTable table = (tbTable)bs.Current;

                DataGUIAttribute.AssignFormValues<tbTable>(this, table);

                tbSelectObject selectedobject = tbSelectObject.FindBy("guid", table.Guid);
                TxtSelect.Text = selectedobject.Number + "-" + selectedobject.Name;
                TxtSelect.Tag = selectedobject;

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
            DataGUIAttribute.AssignFormValues<tbTable>(this, new tbTable());
            DataGUIAttribute.ClearFormControls<tbTable>(this, new tbTable());

            TxtSelect.Tag = new tbSelectObject();
            TxtSelect.Text = string.Empty;

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
            if (!FrmMain.currentuser.CanAdd)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            tbTable table = new tbTable();

           

            table.Guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbTable>(this, table);

            if (MessageBox.Show("هل أنت متأكد من الإضافة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            DBConnect.StartTransAction();

            table.Insert();

            if (DBConnect.CommitTransAction())
            {
                bs.Add(table);
                ShowConfirm();
                bs.MoveLast();

            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanEdit)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbTable table = (tbTable)bs.Current;

          
            DataGUIAttribute.AssignObjectValues<tbTable>(this, table);


            if (MessageBox.Show("هل أنت متأكد من التعديل ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            DBConnect.StartTransAction();

            table.Update();

            if (DBConnect.CommitTransAction())
            {
                ShowConfirm();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            tbTable table = (tbTable)bs.Current;

            DBConnect.StartTransAction();

            table.Delete();

            if (DBConnect.CommitTransAction())
            {
                bs.RemoveCurrent();
                bs.MoveLast();
                ShowConfirm();
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
            //CmbType.Items.Clear();
            //CmbType.Items.AddRange(tbTable.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }



        #region Select
        private void TxtSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbSelectObject.Fill("name", TxtSelect.Text);
                if (tbSelectObject.dtData.Rows.Count == 1)
                {
                    tbSelectObject selectedobject = tbSelectObject.FindBy("guid", (Guid)tbSelectObject.dtData.Rows[0]["guid"]);
                    TxtSelect.Tag = selectedobject;
                    TxtSelect.Text = selectedobject.Number + "-" + selectedobject.Name;
                }
                else if (tbSelectObject.dtData.Rows.Count == 0)
                {
                    tbSelectObject.Fill("name", " ");
                    ShowSelect();
                }
                else
                {
                    ShowSelect();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                TxtSelect.Tag = new tbSelectObject();
                TxtSelect.Text = string.Empty;
            }
        }

        private void ShowSelect()
        {
            FrmSelect frmselect = new FrmSelect("Select Object", typeof(tbSelectObject), tbSelectObject.dtData);

            if (frmselect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbSelectObject selectedobject = tbSelectObject.FindBy("guid", frmselect.guid);
                TxtSelect.Tag = selectedobject;
                TxtSelect.Text = selectedobject.Number + "-" + selectedobject.Name;
            }
            else
            {
                TxtSelect.Tag = new tbSelectObject();
                TxtSelect.Text = string.Empty;
            }
        }


        private void BtnShowCard_Click(object sender, EventArgs e)
        {
            tbSelectObject selectedobject = (tbSelectObject)TxtSelect.Tag;
            if (!selectedobject.Guid.Equals(Guid.Empty))
            {
                FrmTable frmtable = new FrmTable(selectedobject.Guid);
                frmtable.ShowDialog();
            }
        }

        private void BtnSeacrh_Click(object sender, EventArgs e)
        {
            TxtSelect_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }
        #endregion

        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            if (bs.Current == null)
            {
                MessageBox.Show("يجب حفظ البطاقة أولا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            tbTable table = (tbTable)bs.Current;

            Reports.InitReport(rpt, "report.frx", false);
            tbTable.Fill(table.Guid);


            rpt.SetParameterValue("UserName", FrmMain.currentuser.name);

            rpt.RegisterData(tbTable.dtData, "فاتورة");

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

    }
}
