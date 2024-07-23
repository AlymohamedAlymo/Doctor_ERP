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
using System.Reflection.Emit;

namespace DoctorERP
{
    public partial class FrmSelect : KryptonForm
    {
        public Guid guid;
        Type type;
        DataTable sourcetable;

        public FrmSelect(string FormTitle, Type type, DataTable sourcetable)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Text = FormTitle;
            this.type = type;
            this.sourcetable = sourcetable;
        }

        private void FrmSelect_Load(object sender, EventArgs e)
        {
            DataGridMain.DataSource = sourcetable;

            DataGUIAttribute.FillGrid(DataGridMain, type);
        }

        private void DataGridMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                guid = (Guid)DataGridMain["guid", DataGridMain.CurrentRow.Index].Value;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        if (DataGridMain.RowCount > 0)
                        {
                            guid = (Guid)DataGridMain["guid", DataGridMain.CurrentRow.Index].Value;
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                    }
                    break;
                case Keys.Escape:
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
