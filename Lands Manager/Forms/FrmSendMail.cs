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
using System.Threading;
using System.IO;

namespace DoctorERP
{
    public partial class FrmSendMail : KryptonForm
    {
        Thread threadMailSender;
        public bool isDone;

        DynamicAttachement DynamicAttach;
        tbEmailSettings emailsettings;

        public FrmSendMail(tbEmailSettings emailsettings, DynamicAttachement DynamicAttach)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            isDone = false;

            TxtAttachment.Tag = new tbAttachment();

            TxtCCEmail.Text = emailsettings.CCEmail;
            TxtSubject.Text = emailsettings.Subject;
            TxtMessageBody.Text = emailsettings.MessageBody;
            this.emailsettings = emailsettings;
            this.DynamicAttach = DynamicAttach;
            LblViewAttachment.Visible = DynamicAttach.attachData.Length > 0 ? true : false;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if(!SendEmail.IsEmailValid(TxtCCEmail.Text))
            {
                MessageBox.Show("الإيميل المستقبل غير صحيح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            BtnSend.Enabled = false;

            ProgEmail.Visible = true;
            Lblsending.Visible = true;

            threadMailSender = new Thread(new ThreadStart(Sendemail));
            threadMailSender.Start();
        }


        private void ShowComfirm()
        {
            FrmConfirm frmcon = new FrmConfirm();
            frmcon.ShowDialog();
        }

        private void Sendemail()
        {
            try
            {
                tbAttachment custattach = (tbAttachment)TxtAttachment.Tag;

                SendEmail.SendMail(emailsettings.CCEmail, TxtSubject.Text, TxtMessageBody.Text, DynamicAttach, custattach, emailsettings.SenderEmail, emailsettings.SenderEmail, emailsettings.Password, emailsettings.SMTPServer, emailsettings.Port, emailsettings.UseSSL);

                MessageBox.Show("تم إرسال الإيميل بنجاح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                isDone = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إرسال الإيميل \r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isDone = false;
                this.Close();
            }
            finally
            {
                ProgEmail.Visible = false;
                BtnSend.Enabled = true;
                Lblsending.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }


        private void FrmSendMail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!isDone)
                    threadMailSender.Abort();
            }
            catch
            {

            }
        }

        private void FrmSendMail_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        #region Attachment
        private void BtnBrowseAttach_Click(object sender, EventArgs e)
        {
            string filename = FileHelper.OpenAndGetFileName();
            if (filename.Equals(string.Empty))
                return;

            tbAttachment attach = new tbAttachment();
            attach.Guid = Guid.NewGuid();
            attach.ParentGuid = Guid.Empty;
            attach.Name = FileHelper.GetFileNameWithOutPath(filename);
            attach.FileData = FileHelper.FileToByteArray(filename);
            attach.FileName = attach.Name;
            attach.FileSize = string.Empty;

            TxtAttachment.Tag = attach;
            TxtAttachment.Text = FileHelper.GetFileNameWithOutPath(filename);
        }

        private void BtnSaveAttach_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttachment.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;
            try
            {
                if (FileHelper.SaveFile(attach.FileName, attach.FileData))
                    MessageBox.Show("تم حفظ الملف‌", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteAttach_Click(object sender, EventArgs e)
        {
            TxtAttachment.Tag = new tbAttachment();
            TxtAttachment.Text = string.Empty;
        }

        private void BtnPreviewAttach_Click(object sender, EventArgs e)
        {
            tbAttachment attach = (tbAttachment)TxtAttachment.Tag;
            if (attach.Guid.Equals(Guid.Empty))
                return;

            FileHelper.RunFile(attach.FileName, attach.FileData);
        }

        private void AddAttachments(Guid ParentGuid)
        {
            tbAttachment attachmentdelete = new tbAttachment();
            attachmentdelete.DeleteBy("ParentGuid", ParentGuid);

            tbAttachment attachment = (tbAttachment)TxtAttachment.Tag;

            if (attachment.Guid.Equals(Guid.Empty))
            {
                attachment.FileData = new Byte[0];
            }
        }

        #endregion

        private void LblViewAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FileHelper.RunFile(DynamicAttach.attachFileName, FileHelper.MemStreamtoByetArray(DynamicAttach.attachData));
        }
    }
}
