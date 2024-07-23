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
    public partial class FrmListManager : KryptonForm
    {
        public FrmListManager()
        {
            InitializeComponent();
            FillGrid();
        }

        void FillGrid()
        {
            tbBanks.Fill();
            int end = 50 - tbBanks.dtData.Rows.Count;
            int start = 50 - end;
            for (int i = start; i <= 50; i++)
            {
                tbBanks.dtData.Rows.Add(Guid.Empty, string.Empty);
            }


            DataGridMain.DataSource = tbBanks.dtData;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            DBConnect.StartTransAction();
            AddBillBody(Guid.Empty);
            if (DBConnect.CommitTransAction())
            {
                FrmConfirm f = new FrmConfirm();
                f.ShowDialog();
            }
            this.Close();
        }



        private void AddBillBody(Guid parentguid)
        {
            tbBanks tbbillbodydelete = new tbBanks();
            tbbillbodydelete.DeleteALL();

            foreach (DataGridViewRow dr in DataGridMain.Rows)
            {
             

                string item = (string)dr.Cells[ColName.Name].Value;

                tbBanks tbbillbody = new tbBanks();

                tbbillbody.guid = Guid.NewGuid();
                tbbillbody.bankname = item.Trim();
              

                if (!item.Trim().Equals(string.Empty))
                {
                    tbbillbody.Insert();
                }


            }
        }

        private void FrmListManager_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void ClearDataGridRow(int rowindex)
        {
            tbBanks.dtData.Rows.RemoveAt(rowindex);

            tbBanks.dtData.Rows.Add(Guid.Empty, string.Empty);


        }

        private void DataGridMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string col = DataGridMain.Columns[e.ColumnIndex].DataPropertyName.ToLower();
            switch (col)
            {
                
                case "bankname":
                    {
                        DataGridMain.MoveToNextRow();

                    }
                    break;
               
                default:
                    break;
            }


        }

        private void DataGridMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DataGridMain.MoveToNextRow();
            }

            if (e.KeyData == Keys.Delete)
            {
                ClearDataGridRow(DataGridMain.CurrentRow.Index);
            }
        }

        private void CmbMainType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
