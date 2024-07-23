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
    public partial class FrmAppInfo : KryptonForm
    {
        public FrmAppInfo()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            tbAppInfo.Fill();
            tbAppInfo appinfo = tbAppInfo.lstData[0];

            TxtAppTitle.Text = appinfo.AppTitle;
            chkBackupOnExit.Checked = appinfo.BackupOnExit;
            TxtBackupPath.Text = appinfo.BackupPath;
            CmbQtyFormat.Text = appinfo.QtyFormat;
            CmbCurrencyFormat.Text = appinfo.CurrecnyFormat;
            ChkShowConfirmMSG.Checked = appinfo.ShowConfirmMSG;
            TxtColumnCount.Text = appinfo.ColumnCount.ToString();
            if (appinfo.background.Length > 0)
                PicBK.Image = FileHelper.ByteArrayToImage(appinfo.background);
            else
                PicBK.Image = null;


            if (appinfo.Logo.Length > 0)
                PicLogo.Image = FileHelper.ByteArrayToImage(appinfo.Logo);
            else
                PicLogo.Image = null;

            CmbStyle.SelectedIndex = appinfo.KMStyle;
            UpdateFormat();

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            tbAppInfo tbapp = new tbAppInfo();
            tbapp.Guid = Guid.NewGuid();
            tbapp.AppTitle = TxtAppTitle.Text;
            tbapp.BackupOnExit = chkBackupOnExit.Checked;
            tbapp.CurrecnyFormat = CmbCurrencyFormat.Text;
            tbapp.QtyFormat = CmbQtyFormat.Text;
            tbapp.ShowConfirmMSG = ChkShowConfirmMSG.Checked;

            int ColCount;
            int.TryParse(TxtColumnCount.Text, out ColCount);

            tbapp.ColumnCount = ColCount;


            if (!TxtBackupPath.Text.EndsWith("\\"))
                TxtBackupPath.Text = TxtBackupPath.Text + "\\";

            tbapp.BackupPath = TxtBackupPath.Text;
            tbapp.KMStyle = CmbStyle.SelectedIndex;

            if (PicBK.Image != null)
                tbapp.background = FileHelper.ImageToByteArray(PicBK.Image);
            else
                tbapp.background = new byte[0x0];


            if (PicLogo.Image != null)
                tbapp.Logo = FileHelper.ImageToByteArray(PicLogo.Image);
            else
                tbapp.Logo = new byte[0x0];

            DBConnect.StartTransAction();

            tbapp.DeleteALL();
            tbapp.Insert();

            if (DBConnect.CommitTransAction())
            {
                FrmConfirm frmcon = new FrmConfirm();
                frmcon.ShowDialog();
                this.Close();
            }
        }


        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.RestoreDirectory = true;
            opf.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg;*.png";

            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PicBK.Image = Image.FromFile(opf.FileName);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            PicBK.Image = null;
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtBackupPath.Text = fbd.SelectedPath;
            }
        }

        private void CmbQtyFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateFormat();
        }
           

        private void BtnRefreshQtyFormat_Click(object sender, EventArgs e)
        {
            UpdateFormat();
        }

        void UpdateFormat()
        {
            float qty = 0;
            float.TryParse(TxtQtyFormatPreview.Text, out qty);
            TxtQtyFormatPreview.Text = string.Format("{0:" + CmbQtyFormat.Text + "}", qty);

            float number = 0;
            float.TryParse(TxtCurrencyPreview.Text, out number);
            TxtCurrencyPreview.Text = string.Format("{0:" + CmbCurrencyFormat.Text + "}", number);
        }

        private void BtnLogo_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.RestoreDirectory = true;
            opf.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg;*.png";

            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PicLogo.Image = Image.FromFile(opf.FileName);
            }
        }

        private void BtnRemoveLogo_Click(object sender, EventArgs e)
        {
            PicLogo.Image = null;
        }
    }
}
