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
    public partial class FrmActivate : KryptonForm
    {

        Dongle dngl;

        public FrmActivate()
        {
            InitializeComponent();
             
        }

        private void Act()
        {
            string newcode = dngl.EncryptInformation(dngl.EncryptInformation(TxtVersion.Text.ToUpper()));
            if (!TxtCode.Text.Equals(newcode))
            {
                MessageBox.Show(("كود التفعيل غير صحيح"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show(("تم تفعيل البرنامج بنجاح يرجى إعادة تشغيل البرنامج"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dngl.CreateLicFile(newcode);
                Application.Exit();
            }


        }

        private void BtnActivate_Click(object sender, EventArgs e)
        {
            Act();
        }

        private void FrmActivate_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            dngl = new Dongle();

            TxtVersion.Text = dngl.LstDongles[0].ToUpper().Substring(0, 7);

        }

        private void LblWebSite_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(LblWebSite.Text);
            }
            catch
            {
            }
        }

        private void LblEmail1_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:" + LblEmail1.Text);
            }
            catch
            {
            }
        }

        private void LblEmail2_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:" + LblEmail1.Text);
            }
            catch
            {
            }
        }
    }
}
