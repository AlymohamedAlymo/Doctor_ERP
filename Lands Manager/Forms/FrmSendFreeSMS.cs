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
    public partial class FrmSendFreeSMS : KryptonForm
    {
        string Mobile = string.Empty;

        public FrmSendFreeSMS(string Mobile, string MSG)
        {
            InitializeComponent();
            this.Mobile = Mobile;
            TxtSubject.Text = Mobile;
            TxtMessageBody.Text = MSG;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (TxtSubject.Text.Trim().Length <= 0)
            {
                MessageBox.Show("لا يوجد رقم هاتف", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (TxtMessageBody.Text.Trim().Length <= 0)
            {
                MessageBox.Show("لا يوجد نص للرسالة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("هل ترغب في إرسال رسالة إلى الجوال ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            tbSMSsettings.Fill();

            tbSMSsettings smssettings = tbSMSsettings.lstData[0];


            string msg = TxtMessageBody.Text;



            string res = SendSMS.SendMessage(TxtSubject.Text, msg);
           
            if (!res.Equals("3"))
            {
                MessageBox.Show(SendSMS.TestResult(res));
            }
            else
            {
                FrmConfirm frmcon = new FrmConfirm();
                frmcon.ShowDialog();
            }
        }
    }
}
