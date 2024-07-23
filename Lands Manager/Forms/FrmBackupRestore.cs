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
using Microsoft.SqlServer.Management.Common;

namespace DoctorERP
{
    public partial class FrmBackupRestore : KryptonForm
    {
        public enum BackupRestore
        {
            backup,
            restore
        }

        bool AutoClose = false;
        BackupRestore bktype;
        string Database = DBConnect.DBConnection.Database;

        public FrmBackupRestore(BackupRestore bktype, string Database)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            AppSetting.ReadSetting();
            this.Database = DBConnect.DBConnection.Database;
            TxtDataBase.Text = DBConnect.DBConnection.Database;
            this.bktype = bktype;
            if (bktype == BackupRestore.backup)
            {
                this.Text = "عمل نسخة إحتياطية عن قاعدة البيانات";
            }
            else if (bktype == BackupRestore.restore)
            {
                LblRestoreHint.Visible = true;
                this.Text = "إسترجاع ملف نسخة إحتياطية";
            }

            
        }
        #region Backup and Restore

        #region Backup 
        private void StartBackup()
        {
            Server dbServer = new Server();
            if (!AppSetting.SqlAuth)
            {
                dbServer = new Server(new ServerConnection(AppSetting.ServerName));
            }
            else
            {
                dbServer = new Server(new ServerConnection(AppSetting.ServerName, AppSetting.UserName, AppSetting.Password));
            }

            try
            {
                Backup dbBackup = new Backup();

                dbBackup.Action = BackupActionType.Database;
                dbBackup.Incremental = false;
                dbBackup.Restart = true;
                dbBackup.Initialize = true;

                dbBackup.Database = TxtDataBase.Text;

                dbBackup.Devices.AddDevice(TxtBackupPath.Text, DeviceType.File);
                dbBackup.BackupSetName = string.Empty;
                dbBackup.BackupSetDescription = DBConnect.GetServerTime().ToString("dd/MM/yyyy HH:mm");
                dbBackup.PercentComplete += DbBackupRestore_PercentComplete;
                dbBackup.Complete += DbBackupRestore_Complete;
                dbBackup.Information += DbBackupRestore_Information;

                dbBackup.SqlBackupAsync(dbServer);
            }
            catch (Exception err)
            {
                MessageBox.Show("حدث خطأ أثناء عمل النسخة الإحتياطية" + Environment.NewLine + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                BtnStart.Enabled = true;
                Progress1.Visible = LblProgress.Visible = ProgSpin.Visible = false;

            }
        }


        #endregion

        #region Resotor
        private void StartRestore()
        {
            Server dbServer = new Server();
            if (!AppSetting.SqlAuth)
            {
                dbServer = new Server(new ServerConnection(AppSetting.ServerName));
            }
            else
            {
                dbServer = new Server(new ServerConnection(AppSetting.ServerName, AppSetting.UserName, AppSetting.Password));
            }
            try
            {
                Restore dbRestore = new Restore();
                dbRestore.Database = TxtDataBase.Text;
                dbRestore.Action = RestoreActionType.Database;
                dbRestore.Devices.AddDevice(TxtBackupPath.Text, DeviceType.File);
                dbRestore.ReplaceDatabase = true;

                RelocateFile DataFile = new RelocateFile();
                string MDF = dbRestore.ReadFileList(dbServer).Rows[0][1].ToString();
                DataFile.LogicalFileName = dbRestore.ReadFileList(dbServer).Rows[0][0].ToString();
                DataFile.PhysicalFileName = dbServer.Databases[TxtDataBase.Text].FileGroups[0].Files[0].FileName;

                RelocateFile LogFile = new RelocateFile();
                string LDF = dbRestore.ReadFileList(dbServer).Rows[1][1].ToString();
                LogFile.LogicalFileName = dbRestore.ReadFileList(dbServer).Rows[1][0].ToString();
                LogFile.PhysicalFileName = dbServer.Databases[TxtDataBase.Text].LogFiles[0].FileName;

                dbRestore.RelocateFiles.Add(DataFile);
                dbRestore.RelocateFiles.Add(LogFile);

                dbServer.KillAllProcesses(TxtDataBase.Text);


                dbRestore.PercentComplete += DbBackupRestore_PercentComplete;
                dbRestore.Complete += DbBackupRestore_Complete;

                dbRestore.Information += DbBackupRestore_Information;


                dbRestore.SqlRestoreAsync(dbServer);
            }
            catch (Exception err)
            {
                MessageBox.Show("حدث خطأ أثناء عملية استعادة النسخة الإحتياطية" + Environment.NewLine + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                BtnStart.Enabled = true;
                Progress1.Visible = LblProgress.Visible = ProgSpin.Visible = false;
            }
        }

        #endregion

        private void DbBackupRestore_Information(object sender, ServerMessageEventArgs e)
        {
            TxtLog.Text += e.Error + Environment.NewLine;
            this.Cursor = Cursors.Default;
            BtnStart.Enabled = true;
            Progress1.Visible = LblProgress.Visible = ProgSpin.Visible = false;
        }

        private void DbBackupRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            AutoClose = true;
            if (bktype == BackupRestore.backup)
            {
                MessageBox.Show("تمت عملية النسخ الإحتياطي بنجاح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (bktype == BackupRestore.restore)
            {
                DBConnect.TryToConnect(string.Empty);

                MessageBox.Show("تمت عملية استعادة النسخة الإحتياطية بنجاح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("سيتم إغلاق البرنامج، يرجى إعادة تشغيله", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBConnect.DBConnection.ChangeDatabase(Database);

                if (DBConnect.GetDatabaseDescription(Database) == Database)
                {

                    try
                    {
                        DBConnect.ExeStoredProcedure("sp_addextendedproperty", "name", DBConnect.DataBaseTypeName, "value", Database);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

                Application.Exit();
            }
        }

        private void DbBackupRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            LblProgress.Text = string.Format("{0} / {1} {2}", 100, e.Percent, "نسبة الإكمال");
            Progress1.Value = e.Percent;
        }

        #endregion

        private void BtnPath_Click(object sender, EventArgs e)
        {
            if (bktype == BackupRestore.backup)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Backup database";
                sfd.Filter = "Backup File(*.bak)|*.bak";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TxtBackupPath.Text = sfd.FileName;
                }
            }
            else if (bktype == BackupRestore.restore)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Backup database";
                ofd.Filter = "Backup File(*.bak)|*.bak";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TxtBackupPath.Text = ofd.FileName;
                }
            }
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (TxtBackupPath.Text.Trim().Length <= 0)
            {
                MessageBox.Show("يجب إختيار ملف النسخ الإحتياطي", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (bktype == BackupRestore.restore)
            {
                if (!System.IO.File.Exists(TxtBackupPath.Text))
                {
                    MessageBox.Show("ملف النسخ الإحتياطي غير موجود", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.Cursor = Cursors.WaitCursor;
            BtnStart.Enabled = false;
            Progress1.Visible = LblProgress.Visible = ProgSpin.Visible = true;
            TxtLog.Text = string.Empty;
            if (bktype == BackupRestore.backup)
            {
                StartBackup();
            }
            else
            {

                string Description = DBConnect.GetBackupDescription(TxtBackupPath.Text);
                if (MessageBox.Show("هل أنت متأكد من إستعادة النسخة الإحتياطية ؟" + Environment.NewLine + Description, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                    return;
                StartRestore();

            }
            this.Cursor = Cursors.Default;
        }

        private void FrmBackupRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AutoClose)
            {
                if (MessageBox.Show("هل أنت متأكد من إغلاق النافذة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
