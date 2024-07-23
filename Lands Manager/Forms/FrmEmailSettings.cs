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
    public partial class FrmEmailSettings : KryptonForm
    {
        public FrmEmailSettings()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void FrmEmailSettings_Load(object sender, EventArgs e)
        {
            tbEmailSettings.Fill();
            tbEmailSettings emailsettings = tbEmailSettings.lstData[0];

            DataGUIAttribute.AssignFormValues<tbEmailSettings>(this, emailsettings);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            tbEmailSettings emailsettings = new tbEmailSettings();
            emailsettings.Guid = Guid.NewGuid();

            DataGUIAttribute.AssignObjectValues<tbEmailSettings>(this, emailsettings);

            if (!TxtSenderEmail.Text.Equals(string.Empty))
            {
                if (!SendEmail.IsEmailValid(TxtSenderEmail.Text))
                {
                    MessageBox.Show("بريدك الإلكتروني غير صحيح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            if (!TxtCCEmail.Text.Equals(string.Empty))
            {
                if (!SendEmail.IsEmailValid(TxtCCEmail.Text))
                {
                    MessageBox.Show("الإيميل المستقبل غير صحيح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DBConnect.StartTransAction();
            emailsettings.DeleteALL();
            emailsettings.Insert();
            if (DBConnect.CommitTransAction())
            {
                FrmConfirm frmcon = new FrmConfirm();
                frmcon.ShowDialog();
                this.Close();
            }
        }
    }
}
