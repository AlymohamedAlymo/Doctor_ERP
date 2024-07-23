using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Xml.Serialization;
using System.IO;

namespace DoctorERP
{
    public partial class FrmCustomView : KryptonForm
    {
        string reportName = string.Empty;
        KryptonDataGridView datagridview = new KryptonDataGridView();

        public FrmCustomView(string reportName, KryptonDataGridView datagridview)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.reportName = reportName;
            this.datagridview = datagridview;

            ClearList();
            FillList();

        }

        #region List Functions
        void FillList()
        {
            tbReportCustomView rptView = tbReportCustomView.FindBy("name", reportName);

            if (rptView.guid.Equals(Guid.Empty))
            {
                foreach (DataGridViewColumn column in datagridview.Columns)
                {
                    try
                    {
                        if (!column.ValueType.Equals(typeof(Guid)) && column.Visible == true)
                            ListColumns.Items.Add(column.HeaderText);
                    }
                    catch
                    {

                    }
                }

                for (int i = 0; i < ListColumns.Items.Count; i++)
                    SetItemChecked(ListColumns.Items[i].ToString(), true);
            }
            else
            {
                DataGridColumns result = DataGridColumns.ReadDataColumnSettings(rptView.ColumnView);

                for (int i = 0; i < result.lstCols.Count; i++)
                {
                    ListColumns.Items.Add(result.lstCols[i].ColumnHeader);
                    ListColumns.SetItemChecked(result.lstCols[i].ColumnIndex, result.lstCols[i].Visible);
                }
            }
            chkAutoFill.Checked = rptView.AutoFillColumn;
        }

        private void ClearList()
        {
            for (int i = 0; i < ListColumns.Items.Count; i++)
                ListColumns.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void SetItemChecked(string item, bool state)
        {
            int index = GetItemIndex(item);

            if (index < 0) return;

            ListColumns.SetItemChecked(index, state);
        }

        private int GetItemIndex(string item)
        {
            int index = 0;

            foreach (object o in ListColumns.Items)
            {
                if (item == o.ToString())
                {
                    return index;
                }

                index++;
            }
            return -1;
        }

        void MoveUp(KryptonCheckedListBox myListBox)
        {
            int selectedIndex = myListBox.SelectedIndex;
            if (selectedIndex > 0 & selectedIndex != -1)
            {
                myListBox.Items.Insert(selectedIndex - 1, myListBox.Items[selectedIndex]);
                myListBox.Items.RemoveAt(selectedIndex + 1);
                myListBox.SelectedIndex = selectedIndex - 1;
                myListBox.SetItemChecked(myListBox.SelectedIndex, true);
            }
        }

        void MoveDown(KryptonCheckedListBox myListBox)
        {
            int selectedIndex = myListBox.SelectedIndex;
            if (selectedIndex < myListBox.Items.Count - 1 & selectedIndex != -1)
            {
                myListBox.Items.Insert(selectedIndex + 2, myListBox.Items[selectedIndex]);
                myListBox.Items.RemoveAt(selectedIndex);
                myListBox.SelectedIndex = selectedIndex + 1;
                myListBox.SetItemChecked(myListBox.SelectedIndex, true);
            }
        }
        #endregion

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DataGridColumns datacolumnssettings = new DataGridColumns();
            datacolumnssettings.lstCols = new List<DataGridColumns>();

            for (int i = 0; i < ListColumns.Items.Count; i++)
            {
                DataGridColumns col = new DataGridColumns();

                col.ColumnIndex = col.DisplayIndex = i;
                col.ColumnHeader = ListColumns.Items[i].ToString();
                col.Visible = ListColumns.GetItemChecked(i);


                datacolumnssettings.lstCols.Add(col);
            }

            tbReportCustomView reportcustomview = new tbReportCustomView();

            reportcustomview.guid = Guid.NewGuid();
            reportcustomview.name = reportName;
            reportcustomview.ColumnView = DataGridColumns.GenerateXMLSettings(datacolumnssettings);
            reportcustomview.AutoFillColumn = chkAutoFill.Checked;

            DBConnect.StartTransAction();

            reportcustomview.DeleteBy("Name" , reportcustomview.name);
            reportcustomview.Insert();

            if (DBConnect.CommitTransAction())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            tbReportCustomView rptView = new tbReportCustomView();

            DBConnect.StartTransAction();
            rptView.DeleteBy("Name" , reportName);
            if (DBConnect.CommitTransAction())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            MoveUp(ListColumns);
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            MoveDown(ListColumns);
        }
    }
}
