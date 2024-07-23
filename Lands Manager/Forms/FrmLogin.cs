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
using Microsoft.SqlServer.Management.Smo;

namespace DoctorERP
{
    public partial class FrmLogin : KryptonForm
    {
        public tbUsers user;
        public FrmLogin()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            user = (tbUsers)CmbUsers.SelectedItem;
            if (!TxtPassword.Text.Equals(user.password))
            {
                MessageBox.Show("كلمة المرور غير صحيحة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FrmMain.PlanGuid = checkBox1.Checked ? Guid.Empty : (Guid)comboBox1.SelectedValue;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Application.Exit();
            }
            else if (keyData == Keys.Enter)
            {
                BtnOk_Click(new object(), new EventArgs());
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (!DBConnect.TryToConnect(AppSetting.DataBase))
            {
                FrmConnection connection = new FrmConnection();
                if (connection.ShowDialog() == DialogResult.OK)
                    MessageBox.Show(("يرجى إعادة تشغيل البرنامج ليتم تطبيق إعدادات الإتصال الجديدة"), Application.ProductName, MessageBoxButtons.OK);

                Application.Exit();
            }

            tbUsers.Fill();
            CmbUsers.DataSource = tbUsers.lstData;
            CmbUsers.DisplayMember = "name";

            tbPlanInfo choose = new tbPlanInfo { name = "-- أختر المخطط --" , guid = Guid.Empty};
            tbPlanInfo.Fill();

            tbPlanInfo.lstData.Add(choose);

            comboBox1.DataSource = tbPlanInfo.lstData;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "guid";
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            checkBox1.Checked = true;

        }

        private void LblPassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            tbUsers user = (tbUsers)CmbUsers.SelectedItem;
            if (user.password.Equals(string.Empty))
            {
                LblPasswordHint.Visible = true;
            }
            else
            {
                LblPasswordHint.Visible = false;
            }
        }
    }
}
