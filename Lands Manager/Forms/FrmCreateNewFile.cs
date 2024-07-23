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
using System.Text.RegularExpressions;

namespace DoctorERP
{
    public partial class FrmCreateNewFile : KryptonForm
    {

        public FrmCreateNewFile()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (DBConnect.CreateNewDataBase(TxtDBName.Text, TxtDescription.Text))
            {
                MessageBox.Show("تم إنشاء قاعدة البيانات بنجاح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
