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
using System.IO;

namespace DoctorERP
{
    public partial class FrmUpdateDatabaseasArcDB : KryptonForm
    {
        string Database = string.Empty;
        string description = string.Empty;
        public FrmUpdateDatabaseasArcDB(string Database, string description)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Database = Database;
            this.description = description;
            TxtDescription.Text = description;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string description = TxtDescription.Text.Trim();

            if (description.Equals(string.Empty))
            {
                MessageBox.Show("يجب إدخال وصف لقاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            try
            {
                DBConnect.DBConnection.ChangeDatabase(Database);

                DBConnect.ExeStoredProcedure("sp_dropextendedproperty", "name", DBConnect.DataBaseTypeName);
            }
            catch
            {

            }
            try
            {
                DBConnect.ExeStoredProcedure("sp_addextendedproperty", "name", DBConnect.DataBaseTypeName, "value", description);
                MessageBox.Show("تم تعيين وصف لقاعدة البيانات بنجاح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBConnect.DBConnection.ChangeDatabase("Master");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DBConnect.DBConnection.ChangeDatabase("Master");
                MessageBox.Show("حدث خطأ أثناء تعيين وصف لقاعدة البيانات" + "\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
