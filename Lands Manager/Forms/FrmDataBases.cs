using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace DoctorERP
{
    public partial class FrmDataBases : KryptonForm
    {
        bool ShowAll = false;
        private int _widthLeftRight;
        bool OpenDefDB = false;
        string SelectedDataBase = string.Empty;

        public FrmDataBases(string SelectedDataBase, bool OpenDefDB)
        {
            InitializeComponent();

            this.OpenDefDB = OpenDefDB;
            this.SelectedDataBase = SelectedDataBase;

            listView1.MultiSelect = false;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillDataBases(ShowAll);



            UpdateDataBaseInfo();

            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
                listView1.Select();
            }


            UpdateDataBaseInfo();

        }


        void UpdateDataBaseInfo()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DataBase db = (DataBase)listView1.SelectedItems[0].Tag;

                TxtServer.Text = AppSetting.ServerName;
                TxtDatabaseName.Text = listView1.SelectedItems[0].Name;
                TxtFileLocation.Text = ((DataBase)listView1.SelectedItems[0].Tag).FileLocation;
                if (db.IsDef)
                {
                    BtnSetAsDefault.Text = "إزالة كإفتراضية";
                    MenuSetAsDefault.Text = "إزالة كإفتراضية";
                }
                else
                {
                    BtnSetAsDefault.Text = "تعيين كإفتراضية";
                    MenuSetAsDefault.Text = "تعيين كإفتراضية";
                }
            }
            else
            {
                TxtServer.Text = AppSetting.ServerName;
                TxtDatabaseName.Text = string.Empty;
                TxtFileLocation.Text = string.Empty;
            }
        }

        void FillDataBases(bool ShowAll)
        {
            listView1.Items.Clear();
            List<DataBase> lstDatabase = DBConnect.GetPocPalDesktopDatabase(ShowAll);

            string DefDataBaseName = string.Empty;
            if (File.Exists(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile))
            {
                DefDataBaseName = File.ReadAllText(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile);
            }
            foreach (DataBase db in lstDatabase)
            {
                if (db.Description.Equals(string.Empty))
                    db.Description = db.SqlName;

                ListViewItem item = new ListViewItem(db.Description);

                item.Name = db.SqlName;
                item.Tag = db;


                if (db.SqlName.Equals(DefDataBaseName))
                    item.ImageIndex = 1;
                else
                    item.ImageIndex = 0;

                listView1.Items.Add(item);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                BtnOk.PerformClick();
            }
            else if (keyData == Keys.Escape)
            {
                BtnCancel.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MenuCreateNewDatabase_Click(object sender, EventArgs e)
        {
            FrmCreateNewFile frm = new FrmCreateNewFile();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FillDataBases(ShowAll);
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            BtnOk_Click(sender, e);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("يجب إختيار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ListViewItem lstItem = listView1.SelectedItems[0];
            AppSetting.DataBase = lstItem.Name.ToString();

            try
            {
                ConnectToDatabase();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void ConnectToDatabase()
        {

            DBConnect connection;
            if (AppSetting.SqlType == 0)
            {
                connection = new DBConnect(AppSetting.ServerName, AppSetting.DataBase, string.Empty, true, false);
            }
            else if (AppSetting.SqlType == 1)
            {
                if (AppSetting.SqlAuth)
                    connection = new DBConnect(AppSetting.ServerName, AppSetting.DataBase, AppSetting.UserName, AppSetting.Password);
                else
                    connection = new DBConnect(AppSetting.ServerName, AppSetting.DataBase, string.Empty, false, false);
            }

            DBConnect.DBConnection.Open();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                UpdateDataBaseInfo();
                return;
            }

            ListViewItem lstItem = listView1.SelectedItems[0];
            UpdateDataBaseInfo();
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void MenuRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("يجب إختيار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("هل أنت متأكد من إزالة قاعدة البيانات المحددة ؟" + Environment.NewLine + "لن يتم حذف قاعدة البيانات من المخدم بل سيتم إخفاءها فقط", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            ListViewItem lstItem = listView1.SelectedItems[0];

            DBConnect.DBConnection.ChangeDatabase(lstItem.Name);

            DBConnect.ExeStoredProcedure("sp_dropextendedproperty", "name", DBConnect.DataBaseTypeName);
            try
            {
                DBConnect.ExeStoredProcedure("sp_dropextendedproperty", "Name", "DefDB");
            }
            catch
            {

            }

            try
            {

                if (File.Exists(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile))
                {
                    if (File.ReadAllText(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile).Equals(lstItem.Name))
                        File.Delete(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile);

                    UpdateDataBaseInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            DBConnect.DBConnection.ChangeDatabase("Master");

            FillDataBases(ShowAll);

        }

        private void MenuShowAllDatabases_Click(object sender, EventArgs e)
        {
            ShowAll = MenuShowAllDatabases.Checked;
            FillDataBases(ShowAll);
        }

        private void MenuUpdateasArcDatabase_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("يجب إختيار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ListViewItem lstItem = listView1.SelectedItems[0];

            FrmUpdateDatabaseasArcDB frm = new FrmUpdateDatabaseasArcDB(lstItem.Name, lstItem.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FillDataBases(ShowAll);
            }

        }

        private void MenuConnectionSettings_Click(object sender, EventArgs e)
        {
            FrmConnection frmcon = new FrmConnection();
            if (frmcon.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("لتطبيق إعدادات الإتصال الجديدة بنجاح", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataBases(ShowAll);
                UpdateDataBaseInfo();
            }

        }

        private void TxtDatabaseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtFileLocation_TextChanged(object sender, EventArgs e)
        {
            TxtFileLocation.Height += TxtFileLocation.GetPositionFromCharIndex(TxtFileLocation.Text.Length - 1).Y + 10 + TxtFileLocation.Font.Height - TxtFileLocation.ClientSize.Height;
        }

        private void ButtonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            // Suspend layout changes until all splitter properties have been updated
            kryptonSplitContainer1.SuspendLayout();

            // Is the left header group currently expanded?
            if (kryptonSplitContainer1.FixedPanel == FixedPanel.None)
            {
                // Make the left panel of the splitter fixed in size
                kryptonSplitContainer1.FixedPanel = FixedPanel.Panel1;
                kryptonSplitContainer1.IsSplitterFixed = true;

                // Remember the current height of the header group
                _widthLeftRight = kryptonHeaderGroup1.Width;

                // We have not changed the orientation of the header yet, so the width of 
                // the splitter panel is going to be the height of the collapsed header group
                int newWidth = kryptonHeaderGroup1.PreferredSize.Height;

                // Make the header group fixed just as the new height
                kryptonSplitContainer1.Panel1MinSize = newWidth;
                kryptonSplitContainer1.SplitterDistance = newWidth;

                // Change header to be vertical and button to near edge
                kryptonHeaderGroup1.HeaderPositionPrimary = VisualOrientation.Right;
                kryptonHeaderGroup1.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Near;
            }
            else
            {
                // Make the bottom panel not-fixed in size anymore
                kryptonSplitContainer1.FixedPanel = FixedPanel.None;
                kryptonSplitContainer1.IsSplitterFixed = false;

                // Put back the minimise size to the original
                kryptonSplitContainer1.Panel1MinSize = 100;

                // Calculate the correct splitter we want to put back
                kryptonSplitContainer1.SplitterDistance = _widthLeftRight;

                // Change header to be horizontal and button to far edge
                kryptonHeaderGroup1.HeaderPositionPrimary = VisualOrientation.Top;
                kryptonHeaderGroup1.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Far;
            }

            kryptonSplitContainer1.ResumeLayout();
        }

        private void KryptonHeaderGroup1_Click(object sender, EventArgs e)
        {
            buttonSpecHeaderGroup1.PerformClick();
        }

        private void FrmDataBases_Load(object sender, EventArgs e)
        {
            if (OpenDefDB)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    DataBase db = (DataBase)item.Tag;
                    if (db.IsDef)
                    {
                        try
                        {
                            AppSetting.DataBase = db.SqlName;
                            ConnectToDatabase();
                            this.DialogResult = DialogResult.OK;
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        }
                    }
                }
            }

            buttonSpecHeaderGroup1.PerformClick();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            MenuRemove.PerformClick();
        }

        private void BtnNewDatabase_Click(object sender, EventArgs e)
        {
            MenuCreateNewDatabase.PerformClick();
        }

        private void BtnDescription_Click(object sender, EventArgs e)
        {
            MenuUpdateasArcDatabase.PerformClick();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            MenuBackupDB.PerformClick();
        }



        private void MenuBackupDB_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("يجب إختيار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ListViewItem lstItem = listView1.SelectedItems[0];
            FrmBackupRestore frmbk = new FrmBackupRestore(FrmBackupRestore.BackupRestore.backup, lstItem.Name);
            frmbk.ShowDialog();

        }

        private void تدويرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("يجب إختيار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ListViewItem lstItem = listView1.SelectedItems[0];
            //FrmNewYear fr = new FrmNewYear(lstItem.Name, lstItem.Text);

            //if (fr.ShowDialog() == DialogResult.OK)
            //    FillDataBases(ShowAll);
        }

        private void MenuDBDescription_Click(object sender, EventArgs e)
        {
            MenuUpdateasArcDatabase.PerformClick();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BtnSetAsDefault_Click(object sender, EventArgs e)
        {
            MenuSetAsDefault.PerformClick();
        }

        private void MenuSetAsDefault_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("يجب إختيار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            ListViewItem c = listView1.SelectedItems[0];
            DataBase db = (DataBase)listView1.SelectedItems[0].Tag;

            if (!db.IsDef)
            {

                if (MessageBox.Show("سوف يتم الدخول مباشرة إلى قاعدة البيانات الإفتراضية، و يمكن تغيير ذلك من الإعدادات، هل تريد تعيين قاعدة البيانات المحددة على أنها إفتراضية ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;


                File.WriteAllText(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile, db.SqlName);

                foreach (ListViewItem item in listView1.Items)
                {
                    item.ImageIndex = 0;
                }

                foreach (ListViewItem item in listView1.Items)
                {
                    if (db.SqlName.Equals(item.Name))
                        item.ImageIndex = 1;
                    else
                        item.ImageIndex = 0;
                }


                foreach (ListViewItem item in listView1.Items)
                {
                    try
                    {
                        DataBase dbItem = (DataBase)item.Tag;
                        DBConnect.DBConnection.ChangeDatabase(item.Name);
                        DBConnect.ExeStoredProcedure("sp_dropextendedproperty", "Name", "DefDB");
                        dbItem.IsDef = false;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    DBConnect.DBConnection.ChangeDatabase(listView1.Name);
                    DBConnect.ExeStoredProcedure("sp_addextendedproperty", "name", "DefDB", "value", "True");


                    db.IsDef = true;
                    UpdateDataBaseInfo();
                }
                catch
                {

                }

                if (!OpenDefDB)
                {
                    if (SelectedDataBase.Trim().Length > 0)
                    {
                        DBConnect.DBConnection.ChangeDatabase(SelectedDataBase);
                    }
                }
                else
                {
                    DBConnect.DBConnection.ChangeDatabase("Master");
                }
            }
            else
            {
                if (MessageBox.Show("سوف يتم إظهار نافذة إختيار قواعدة البيانات في كل مرة يتم فيها تشغيل البرنامج، و يمكن تغيير ذلك من خلال تعيين أحد قواعد البيانات كقاعدة إفتراضية، هل تريد المتابعة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;

                try
                {
                    DBConnect.DBConnection.ChangeDatabase(db.SqlName);
                    DBConnect.ExeStoredProcedure("sp_dropextendedproperty", "name", "DefDB");
                    db.IsDef = false;
                    //lstItem.ImageIndex = 0;
                }
                catch
                {

                }
                try
                {
                    File.Delete(AppSetting.GetAppPath() + "defDatabase");

                    UpdateDataBaseInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
    }
}
