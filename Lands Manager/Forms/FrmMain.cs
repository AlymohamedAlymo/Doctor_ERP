using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Collections.Generic;
using DevExpress.Utils.Paint;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using DevExpress.XtraExport.Helpers;
using DevExpress.LookAndFeel;
using System.Drawing.Drawing2D;
using DevExpress.Utils;
using DevExpress.XtraPrinting.Native.Lines;
using System.Globalization;
using Telerik.WinControls.Analytics;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Org.BouncyCastle.Asn1.X509;
using SmartArabXLSX.InkML;
using Telerik.WinControls.UI.Calculator;

namespace DoctorERP
{
    public partial class FrmMain : Telerik.WinControls.UI.RadToolbarForm
    {
        public static string formatting;
        public static tbUsers currentuser;
        public static tbAppInfo appinfo;
        public static Dongle dngl;

        public static string DataBaseDescription = string.Empty;
        int boxsize = 0;

        bool IsViewScreen = false;

        private CultureInfo CultureAR = new CultureInfo("ar-EG");
        DataTable tbBuilding = new DataTable();

        public static bool AllowEdit = false;


        public static Guid PlanGuid;

        public FrmMain()
        {
            InitializeComponent();
            currentuser = new tbUsers();
            appinfo = new tbAppInfo();
            dngl = new Dongle();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            if (File.Exists(AppSetting.GetAppPath() + "settings.txt"))
            {

                IsViewScreen = true;
            }


            ///* THeme Change Event ///////////////////////////////////////

            RadDropDownListElement themesDropDown = new RadDropDownListElement();
            themesDropDown.MinSize = new System.Drawing.Size(200, 40);
            themesDropDown.EnableElementShadow = false;
            themesDropDown.FindDescendant<FillPrimitive>().BackColor = System.Drawing.Color.Transparent;
            themesDropDown.DropDownStyle = RadDropDownStyle.DropDownList;
            themesDropDown.Items.AddRange(new RadListDataItem[]
            {
                new RadListDataItem("Material") { Image =   Properties.Resources.default_small },
                new RadListDataItem("MaterialPink") { Image = Properties.Resources.pink_blue_small },
                new RadListDataItem("MaterialTeal") { Image = Properties.Resources.teal_red_small },
                new RadListDataItem("MaterialBlueGrey") { Image = Properties.Resources.blue_grey_green_small }
            });
            themesDropDown.SelectedIndex = 0;
            themesDropDown.SelectedIndexChanged += delegate (object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
            {
                if (e.Position > -1)
                {
                    ThemeResolutionService.ApplicationThemeName = themesDropDown.Items[e.Position].Text;
                    if (ControlTraceMonitor.AnalyticsMonitor != null)
                    {
                        ControlTraceMonitor.AnalyticsMonitor.TrackAtomicFeature("ThemeChanged." + ThemeResolutionService.ApplicationThemeName);
                    }
                }
            };
            ////////////////////////////////////////////////////////////


            //MainMenu.FarItems.Add(themesDropDown);


            ThemeResolutionService.ApplicationThemeName = themesDropDown.SelectedItem.Text;
            if (ControlTraceMonitor.AnalyticsMonitor != null)
            {
                ControlTraceMonitor.AnalyticsMonitor.TrackAtomicFeature("ThemeChanged." + ThemeResolutionService.ApplicationThemeName);
            }




            CultureAR.DateTimeFormat.DayNames = new string[7]
            {
                "السبت",
                "الأحد",
                "الاثنين",
                "الثلاثاء",
                "الاربعاء",
                "الخميس",
                "الجمعة"
            };

            RadPageViewStripItem item = this.radPageViewPage1.Item as RadPageViewStripItem;
            item.ButtonsPanel.CloseButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            item.ButtonsPanel.PinButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            this.overviewRoomsView.ShowGroups = false;
            this.overviewRoomsView.EnableGrouping = true;

            this.overviewRoomsView.ViewType = ListViewType.IconsView;
            this.overviewRoomsView.ItemSize = new Size(50, 50);

            this.overviewRoomsView.ItemSpacing = 8;
            this.overviewRoomsView.AllowEdit = false;
            this.overviewRoomsView.EnableFiltering = true;
            this.overviewRoomsView.HotTracking = true;

            this.overviewRoomsView.RootElement.BackColor = System.Drawing.Color.Transparent;
            this.overviewRoomsView.BackColor = System.Drawing.Color.Transparent;
            this.overviewRoomsView.ListViewElement.DrawFill = false;
            this.overviewRoomsView.ListViewElement.ViewElement.BackColor = System.Drawing.Color.Transparent;
            this.overviewRoomsView.ListViewElement.Padding = new System.Windows.Forms.Padding(15, 8, 8, 8);

            this.overviewRoomsView.RootElement.EnableElementShadow = false;
            this.overviewMainContainer.BackgroundImage = Properties.Resources.Background;
            this.overviewMainContainer.BackgroundImageLayout = ImageLayout.Stretch;
            this.overviewMainContainer.PanelElement.PanelFill.Visibility = ElementVisibility.Collapsed;
            this.overviewRoomsView.GroupItemSize = new Size(0, 25);

            foreach (var Bubbleitem in bubbleBar1.Items)
            {
                Bubbleitem.Click -= BubbleBar_ButtonClick;

                Bubbleitem.Click += BubbleBar_ButtonClick;
            }

            SplitButtonUSER.Items["MenuItemExit"].Click -= MenuExit_Click;
            SplitButtonUSER.Items["MenuItemChangeUser"].Click -= MenuLogOut_Click_1;
            SplitButtonUSER.Items["MenuButtonUserMangment"].Click -= MenuUsersManagement_Click;
            SplitButtonUSER.Items["MenuButtonUsers"].Click -= MenuLogRpt_Click;

            SplitButtonUSER.Items["MenuItemExit"].Click += MenuExit_Click;
            SplitButtonUSER.Items["MenuItemChangeUser"].Click += MenuLogOut_Click_1;
            SplitButtonUSER.Items["MenuButtonUserMangment"].Click += MenuUsersManagement_Click;
            SplitButtonUSER.Items["MenuButtonUsers"].Click += MenuLogRpt_Click;


        }


        #region Main Events
        public void FrmMain_Load(object sender, EventArgs e)
        {
            if (!DBConnect.TryToConnect(AppSetting.DataBase))
            {
                FrmConnection connection = new FrmConnection();
                if (connection.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("يرجى إعادة تشغيل البرنامج ليتم تطبيق إعدادات الإتصال الجديدة", Application.ProductName, MessageBoxButtons.OK);

                Application.Exit();
            }

            if (ChangeDataBase(true))
            {
                this.Visible = true;
            }
            else
            {
                Application.Exit();
            }

        }

        private void LoadLandData()
        {

            overviewRoomsView.DataSource = null;

            if (PlanGuid != Guid.Empty)
            {
                tbLand.Fill("PlanGuid", PlanGuid);
            }
            else if (PlanGuid == Guid.Empty)
            {
                tbLand.Fill();
            }


            this.overviewRoomsView.DataSource = tbLand.lstData.OrderBy(u => u.blocknumber).ToList();

            this.overviewRoomsView.DisplayMember = "blocknumber";
            this.overviewRoomsView.ValueMember = "guid";

        }

        public void BubbleBar_ButtonClick(object sender, EventArgs e) 
        {
            var control = sender as RadButtonElement;
            if (control.Name == "BtnAgentCard")
            {
                MenuAgentBuyCard.PerformClick();

            }
            else if (control.Name == "BtnAgentCard")
            {
                MenuSellBill.PerformClick();

            }
            else if(control.Name == "BtnPayContract")
            {
                MenuPayContract.PerformClick();

            }
            else if(control.Name == "BtnCalc")
            {
                MenuCalc.PerformClick();

            }
            else if (control.Name == "BtnPlanInfoMap")
            {
                tbAttachment attach = tbAttachment.FindByFull("ParentGuid", tbPlanInfo.lstData[0].guid, "map");
                if (attach.Guid.Equals(Guid.Empty))
                {
                    MessageBox.Show("لم يتم إضافة ملف مرفق في معلومات المخطط", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                FileHelper.RunFile(attach.FileName, attach.FileData);

            }
            else if (control.Name == "BtnPlanInfoArea")
            {
                tbAttachment attach = tbAttachment.FindByFull("ParentGuid", tbPlanInfo.lstData[0].guid, "area");
                if (attach.Guid.Equals(Guid.Empty))
                {
                    MessageBox.Show("لم يتم إضافة ملف مرفق في معلومات المخطط", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                FileHelper.RunFile(attach.FileName, attach.FileData);

            }
            else if (control.Name == "BtnPlnInfoPrices")
            {
                tbAttachment attach = tbAttachment.FindByFull("ParentGuid", tbPlanInfo.lstData[0].guid, "prices");
                if (attach.Guid.Equals(Guid.Empty))
                {
                    MessageBox.Show("لم يتم إضافة ملف مرفق في معلومات المخطط", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                FileHelper.RunFile(attach.FileName, attach.FileData);

            }
            else if (control.Name == "BtnOther")
            {
                tbAttachment attach = tbAttachment.FindByFull("ParentGuid", tbPlanInfo.lstData[0].guid, "other");
                if (attach.Guid.Equals(Guid.Empty))
                {
                    MessageBox.Show("لم يتم إضافة ملف مرفق في معلومات المخطط", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }

                FileHelper.RunFile(attach.FileName, attach.FileData);

            }
            else if (control.Name == "BtnSalesOrder")
            {
                MenuSaleOrder.PerformClick();

            }
            else if (control.Name == "BtnLogOut")
            {
                MenuLogOut.PerformClick();

            }
            else if (control.Name == "btnExit")
            {
                MenuExit.PerformClick();

            }


        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {


            try
            {
                string strTempPath = Settings.GetAppPath();
                strTempPath += "temp";
                Directory.CreateDirectory(strTempPath);
                strTempPath += "\\";
                DirectoryInfo directory = new DirectoryInfo(strTempPath);

                Empty(directory);
            }
            catch
            {

            }
        }

        public void Empty(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles())
                file.Delete();
        }


        private bool ChangeDataBase(bool OpenDef)
        {

            string defDatabase = string.Empty;

            if (File.Exists(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile) && OpenDef)
            {
                defDatabase = File.ReadAllText(AppSetting.GetAppPath() + DBConnect.DataBaseDefFile);
                AppSetting.DataBase = defDatabase;

                if (IsViewScreen)
                {
                    DBConnect.TryToConnect(AppSetting.DataBase);
                    tbUsers.Fill();
                    currentuser = tbUsers.lstData[0];
                    LoadSettings();

                    MainMenu.Visible = false;
                    bubbleBar1.Visible = false;
                    return true;
                }

                FrmLogin frmlog = new FrmLogin();
                if (frmlog.ShowDialog() == DialogResult.OK)
                {
                    currentuser = frmlog.user;
                    LoadSettings();

                    return true;
                }
                else
                    return false;

            }
            else
            {

                FrmDataBases frmdb = new FrmDataBases(AppSetting.DataBase, OpenDef);
                if (frmdb.ShowDialog() == DialogResult.OK)
                {
                    FrmLogin frmlog = new FrmLogin();
                    if (frmlog.ShowDialog() == DialogResult.OK)
                    {
                        currentuser = frmlog.user;
                        LoadSettings();

                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (OpenDef)
                    {
                        Application.Exit();
                        return false;
                    }
                    return false;
                }
            }

        }

        private void LoadSettings()
        {
            tbAppInfo.Fill();
            appinfo = tbAppInfo.lstData[0];

            this.Text = appinfo.AppTitle + " - " + currentuser.name;

            DataGUIAttribute.CurrencyFormat = appinfo.CurrecnyFormat;
            DataGUIAttribute.QtyFormat = appinfo.QtyFormat;



            //if (appinfo.background.Length > 0)
            //    PnlMain.BackgroundImage = FileHelper.ByteArrayToImage(appinfo.background);
            //else
            //    PnlMain.BackgroundImage = null;

            if (appinfo.Logo.Length > 0)
                PicLogo.Image = FileHelper.ByteArrayToImage(appinfo.Logo);
            else
                PicLogo.Image = null;


            tbPlanInfo.Fill();
            tbVATSettings.Fill();
            tbEditPassword.Fill();

            CompanyNameLabel.Text = tbVATSettings.lstData[0].CompanyName;
            SplitButtonUSER.Text = FrmMain.currentuser.name;
            LabelDataBase.Text = "قاعدة البيانات: " + DBConnect.DBConnection.Database;
            LabelServer.Text = "المخدم: " + DBConnect.DBConnection.DataSource;
            MenuHeaderCurrentUser.Text = "المستخدم الحالي: " + FrmMain.currentuser.name;


            TmrStatic.Enabled = true;
            FillStatic();

            LoadLandData();
            MenuStripItems h = new MenuStripItems();

           RadItemOwnerCollection tt = MainMenu.NearItems;


            List<RadMenuItem> lst = h.GetAllMenuStripItems(MainMenu.NearItems);
            string[] arrExMenu = { MenuFile.Name, MenuCards.Name, MenuActions.Name, MenuPay.Name, MenuReports.Name, MenuTools.Name };
            foreach (var item in lst)
            {
                if (!IsPermissionGranted(item.Text) && !arrExMenu.Contains(item.Name))
                {
                    item.Visibility = ElementVisibility.Hidden;
                }
            }



        }

        bool IsPermissionGranted(string PermissionName)
        {
            if (FrmMain.currentuser.IsAdmin)
                return true;

            tbUsersPermissions userper = tbUsersPermissions.FindBy("UserGuid", FrmMain.currentuser.guid, PermissionName);
            return userper.PermissionValue;
        }

        private void TmrStatic_Tick(object sender, EventArgs e)
        {
            FillStatic();

        }

        void FillStatic()
        {
            int totalorders = vwSalesOrderRpt.GetSalesOrderRemainCount();
            BtnSalesOrder.Text = string.Format("أمر بيع ({0})", totalorders);

            if (totalorders <= 0)
                BtnSalesOrder.Image = global::DoctorERP.Properties.Resources.NoSalesOrder;
            else
                BtnSalesOrder.Image = global::DoctorERP.Properties.Resources.SalesOrder1;

          //  LoadLandData();

        }


        #endregion


        #region Main Menu
        private void overviewRoomsView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {

            if (e.VisualItem is IconListViewVisualItem)
            {
                e.VisualItem = new LandIconListViewVisualItem();
            }
            else if (e.VisualItem is IconListViewGroupVisualItem)
            {
                e.DataItem.Text = "بلوك رقم : " + e.DataItem.Text;
            }

        }

        private void radRadioButton1_CheckStateChanged(object sender, EventArgs e)
        {
            if (radRadioButton1.CheckState == CheckState.Checked)
            {
                this.overviewRoomsView.ShowGroups = true;

            }
            if (radRadioButton1.CheckState == CheckState.Unchecked)
            {
                this.overviewRoomsView.ShowGroups = false;

            }

        }

        private void radPageView1_PageRemoving(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if (radPageView1.Pages.Count == 1)
            {
                e.Cancel = true;
                return;
            }

        }


        private void TileElementLandsCards_Click(object sender, EventArgs e)
        {
            RadPageViewPage radPageViewPage = new RadPageViewPage();
            radPageViewPage.Text = "بطاقات الأراضي";
            DoctorERP.User_Controls.UCLandsCars uCLandsCars = new User_Controls.UCLandsCars();
            uCLandsCars.Dock = DockStyle.Fill;
            radPageViewPage.Controls.Add(uCLandsCars);
            radPageView1.Pages.Add(radPageViewPage);
            radPageView1.SelectedPage = radPageViewPage;
        }


        private void MenuLogOut_Click(object sender, EventArgs e)
        {



            FrmLogin frmlog = new FrmLogin();
            if (frmlog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentuser = frmlog.user;
                LoadSettings();
            }
            else
            {
                Application.Exit();
            }
        }

        private void MenuBackupToFile_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TmrStatic.Enabled = false;
            FrmBackupRestore frmbak = new FrmBackupRestore(FrmBackupRestore.BackupRestore.backup, AppSetting.DataBase);
            frmbak.ShowDialog();
            TmrStatic.Enabled = true;
        }

        private void MenuRestore_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TmrStatic.Enabled = false;
            FrmBackupRestore frmbak = new FrmBackupRestore(FrmBackupRestore.BackupRestore.restore, AppSetting.DataBase);
            frmbak.ShowDialog();
            TmrStatic.Enabled = true;

        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuAppInfoSettings_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAppInfo frmappinfo = new FrmAppInfo();
            frmappinfo.ShowDialog();
            LoadSettings();
        }

        private void MenuFrmTable_Click(object sender, EventArgs e)
        {
            FrmTable frmtable = new FrmTable(Guid.Empty);
            frmtable.Owner = this;
            frmtable.Show();
        }

        private void MenuSearch_Click(object sender, EventArgs e)
        {
            FrmReport frmreport = new FrmReport("تقرير");
            frmreport.Owner = this;
            frmreport.Show();
        }


        private void MenuEmailSettings_Click(object sender, EventArgs e)
        {
            FrmEmailSettings frmemail = new FrmEmailSettings();
            frmemail.ShowDialog();
        }

        private void MenuUsersManagement_Click(object sender, EventArgs e)
        {
            RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmUsers frmuser = new FrmUsers(Guid.Empty);
            frmuser.ShowDialog();
        }

        private void MenuOpenFile_Click(object sender, EventArgs e)
        {
            ChangeDataBase(true);
        }


        private void MenuSendEmail_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FastReport.Report rpt = new FastReport.Report();
            Reports.InitReport(rpt, "hello.frx", false);

            rpt.Prepare();
            FastReport.Export.Pdf.PDFExport pdfex = new FastReport.Export.Pdf.PDFExport();
            pdfex.Author = "";
            pdfex.Creator = "";
            pdfex.EmbeddingFonts = true;
            pdfex.HasMultipleFiles = false;
            pdfex.Producer = string.Empty;

            DynamicAttachement dynamicattach = new DynamicAttachement();
            dynamicattach.attachFileName = "attach.pdf";
            dynamicattach.attachData = new MemoryStream();

            pdfex.Export(rpt, dynamicattach.attachData);

            tbEmailSettings.Fill();
            tbEmailSettings emailsettings = tbEmailSettings.lstData[0];

            FrmSendMail frmsendemail = new FrmSendMail(emailsettings, dynamicattach);
            frmsendemail.ShowDialog();
        }

        private void MenuArchiveCard_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            MenuBackupToFile.PerformClick();
        }

        private void MenuArchiveOut_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void MenuArchiveOutRpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void MenuConnectionSettings_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmConnection frmcon = new FrmConnection();
            frmcon.ShowDialog();
        }

        private void MenuSendSMS_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            tbSMSsettings.Fill();
            FrmSendFreeSMS frmsms = new FrmSendFreeSMS(tbSMSsettings.lstData[0].Mobile, tbSMSsettings.lstData[0].MessageBody);
            frmsms.ShowDialog();
        }

        private void MenuTreeDoc_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmActivate frmact = new FrmActivate();
            if (frmact.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void MenuChangeDatabase_Click(object sender, EventArgs e)
        {
            TmrStatic.Enabled = false;
            if (ChangeDataBase(false))
            {

            }
        }

        private void MenuMobileSettings_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmSMSSettings frmsms = new FrmSMSSettings(Guid.Empty);
            frmsms.ShowDialog();
        }

        private void MenuAgentBuyCard_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAgent agent = new FrmAgent(Guid.Empty, true, 1, false);
            agent.Owner = this;
            agent.Show();
        }


        private void MenuLandTree_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandTree frm = new FrmLandTree("شجرة الأصناف");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuLandCard_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLand frm = new FrmLand(Guid.Empty, true, string.Empty);
            frm.Owner = this;
            frm.Show();

        }

        private void MenuPlanInfo_Click(object sender, EventArgs e)
        {
            RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmPlanInformation frmplan = new FrmPlanInformation(Guid.Empty);
            frmplan.Owner = this;
            frmplan.Show();
        }

        private void MenuPayIn_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmPay frm = new FrmPay(Guid.Empty, 0, true);
            frm.Owner = this;
            frm.Show();
        }

        private void MenuPayOut_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmPay frm = new FrmPay(Guid.Empty, 1, true);
            frm.Owner = this;
            frm.Show();
        }

        private void MenuSellBill_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmBillHeader frm = new FrmBillHeader(Guid.Empty, true, 0, new List<tbLand>());
            frm.Show(this);
        }

        private void MenuImportBuyer_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmBuyerImport frm = new FrmBuyerImport();
            frm.ShowDialog();
        }

        private void MenuImportLand_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandImport frm = new FrmLandImport();
            frm.ShowDialog();
        }

        private void MenuReturnBill_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmBillHeader frm = new FrmBillHeader(Guid.Empty, true, 1, new List<tbLand>());
            frm.Show(this);
        }

        private void MenuDelayBill_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmBillHeader frm = new FrmBillHeader(Guid.Empty, true, 2, new List<tbLand>());
            frm.Show(this);
        }
        private void MenuAgentStatement_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAgentStatment frmagent = new FrmAgentStatment("كشف حساب عميل");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuOwnerCard_Click(object sender, EventArgs e)
        {
            RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAgent agent = new FrmAgent(Guid.Empty, true, 0, false);
            agent.Owner = this;
            agent.Show();
        }

        private void MenuCalc_Click(object sender, EventArgs e)
        {
            FrmCalc frm = new FrmCalc(new vwSelectLand());
            frm.Show(this);
        }

        private void MenuTaxandDiscountSettings_Click(object sender, EventArgs e)
        {
            FrmTaxAndDiscount frm = new FrmTaxAndDiscount(Guid.Empty);
            frm.ShowDialog();
        }

        private void MenuWorkFeeeRpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmWorkFeeRpt frm = new FrmWorkFeeRpt("عمولة السعي");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuPayContract_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmPayContractOne frm = new FrmPayContractOne(Guid.Empty, true, 0);
            frm.Show(this);
        }

        private void MenuAgentSearch_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAgentReport frmagent = new FrmAgentReport("بحث عن عميل");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuLandRpt_Click_1(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandReport frmagent = new FrmLandReport("بحث عن صنف");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuDailySales_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmDailySellRpt frmagent = new FrmDailySellRpt("مبيعات يومية");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuDialySalesGrouped_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmDailySellGrouped frmagent = new FrmDailySellGrouped("مبيعات يومية تجميعي");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuLandQty_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandSalesRpt frm = new FrmLandSalesRpt("جرد المبيعات");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuLandQtyRpt_Click_1(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandQtyRpt frm = new FrmLandQtyRpt("جرد حسب الكمية");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuLandQtyAllRpt_Click_1(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandQtyRpt frm = new FrmLandQtyRpt("جرد جميع الأصناف");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuBuidlingFeeRpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmBuildingFeeRpt frmagent = new FrmBuildingFeeRpt("ضريبة التصرفات العقارية");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuLandQtyInStore_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandQtyInStore frm = new FrmLandQtyInStore("الأًصناف المتبقية");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuAccountCard_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAccount frm = new FrmAccount(Guid.Empty, true, false);
            frm.Owner = this;
            frm.Show();
        }

        private void MenuPayContractDelay_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmPayContractOne frm = new FrmPayContractOne(Guid.Empty, true, 1);
            frm.Show(this);
        }

        private void MenuWorkFeeVATRpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmWorkFeeVATRpt frm = new FrmWorkFeeVATRpt("ضريبة عمولة السعي");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuLandTransRpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmLandTrans frm = new FrmLandTrans(Guid.Empty, true);
            frm.Show(this);
        }

        private void MeuAccBalance_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAccBalance frm = new FrmAccBalance("أرصدة الحسابات");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuAccStatementPay_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAccountStatment frm = new FrmAccountStatment("كشف حساب");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuGeneralAccountStatic_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmGeneralAccount frmac = new FrmGeneralAccount();
            frmac.Show(this);
        }

        private void MenuDailyReutrnSalesGrouped_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmDailyReturnSellGrouped frmagent = new FrmDailyReturnSellGrouped("مرتجع مبيعات يومية تجميعي");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuDailyReturnSellRpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmDailyReturnSellRpt frmagent = new FrmDailyReturnSellRpt("مرتجع مبيعات يومية");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuVatSettings_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmVATSettings frm = new FrmVATSettings(Guid.Empty);
            frm.ShowDialog();
            tbVATSettings.Fill();
        }

        private void BtnMatCard_Click(object sender, EventArgs e)
        {
            MenuLandCard.PerformClick();
        }

        private void BtnDelyBill_Click(object sender, EventArgs e)
        {
            MenuDelayBill.PerformClick();
        }

        private void MenuArea_Click(object sender, EventArgs e)
        {
            //ToolStripMenuItem toolmenu = (ToolStripMenuItem)sender;
            //if (!IsPermissionGranted(toolmenu.Text))
            //{
            //    MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            tbAttachment attach = tbAttachment.FindByFull("ParentGuid", tbPlanInfo.lstData[0].guid, "area");
            if (attach.Guid.Equals(Guid.Empty))
            {
                MessageBox.Show("لم يتم إضافة ملف مرفق في معلومات المخطط", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            FileHelper.RunFile(attach.FileName, attach.FileData);
        }

        private void MenuBankManager_Click(object sender, EventArgs e)
        {
            FrmListManager frm = new FrmListManager();
            frm.ShowDialog();
            tbBanks.Fill();
        }

        private void MenuPaymentsNotes_Click(object sender, EventArgs e)
        {
            FrmPaymentNotes frm = new FrmPaymentNotes(Guid.Empty);
            frm.ShowDialog();
            tbPaymentsNotes.Fill();
        }

        private void MenuAgetnStatementDetails_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAgentStatementDetails frmagent = new FrmAgentStatementDetails("كشف حساب عميل");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuGeneralSalesReport_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmGeneralSalesReport frmagent = new FrmGeneralSalesReport("تقرير المبيعات العام");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuSetPasswordFromEdit_Click(object sender, EventArgs e)
        {
            FrmEditPassWord frm = new FrmEditPassWord(Guid.Empty, false);
            frm.ShowDialog();
            tbEditPassword.Fill();
        }

        private void MenuAddAmounttoAgentBalance_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmAddAmountoAgent frmagent = new FrmAddAmountoAgent("توزيع مبلغ على عقود عميل");
            frmagent.Owner = this;
            frmagent.Show();
        }


        private void MenuSaleOrder_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmSaleOrder frm = new FrmSaleOrder(Guid.Empty, true);
            frm.Show(this);
        }

        private void MenuSalesOrderrpt_Click(object sender, EventArgs e)
        {
                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmSaleOrderRpt frmagent = new FrmSaleOrderRpt("أوامر البيع");
            frmagent.Owner = this;
            frmagent.Show();
        }

        private void MenuPayRpt_Click(object sender, EventArgs e)
        {
            FrmPayRpt frm = new FrmPayRpt("حركة السندات");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuContractRpt_Click(object sender, EventArgs e)
        {
            FrmContractRpt frm = new FrmContractRpt("حركة العقود");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuBuildingFeeNumbersRpt_Click(object sender, EventArgs e)
        {
            FrmBuildingFeeNumberRpt frm = new FrmBuildingFeeNumberRpt("أرقام ضريبة التصرفات العقارية");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuCash_Click(object sender, EventArgs e)
        {
            FrmCashRpt frm = new FrmCashRpt("الصندوق");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuLandNetPrice_Click(object sender, EventArgs e)
        {
            FrmOwnerLandNetPrice frm = new FrmOwnerLandNetPrice("صافي قيمة الأرض الدفترية");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuPriceFeeDiscount_Click(object sender, EventArgs e)
        {
            FrmOfficeRptPriceFeeDiscount frm = new FrmOfficeRptPriceFeeDiscount("قيمة دفترية و عمولات و خصم");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuNetPriceVatRpt_Click(object sender, EventArgs e)
        {
            FrmOfficeRptNetPriceVAT frm = new FrmOfficeRptNetPriceVAT("صافي القيمة و العمولة و الضريبة");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuOwnerNetPriceAndRemain_Click(object sender, EventArgs e)
        {
            FrmOwnerLandNetPriceandPayments frm = new FrmOwnerLandNetPriceandPayments("صافي القيمة الدفترية و الواصل و المتبقي");
            frm.Owner = this;
            frm.Show();
        }

        private void menuOfficeNetPrice_Click(object sender, EventArgs e)
        {
            FrmOwnerLandNetPriceandPayments frm = new FrmOwnerLandNetPriceandPayments("صافي القيمة الدفترية");
            frm.Owner = this;
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmOfficeRptFees frm = new FrmOfficeRptFees("تقرير عمولة السعي");
            frm.Owner = this;
            frm.Show();
        }

        private void MenuOfficeRptFeeVatPayRemains_Click(object sender, EventArgs e)
        {
            FrmOfficeRptNetVatFeePayRemain frm = new FrmOfficeRptNetVatFeePayRemain("صافي العمولة و الضريبة");
            frm.Owner = this;
            frm.Show();
        }

        private void صافيالعمولةبدونالحسموالضريبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOfficeRptNetVatFeePayRemainNoDis frm = new FrmOfficeRptNetVatFeePayRemainNoDis("صافي العمولة بدون حسم و الضريبة");
            frm.Owner = this;
            frm.Show();
        }


        private void MenuAllowEdit_Click(object sender, EventArgs e)
        {
            //if (MenuAllowEdit.Checked)
            //{
                FrmEditPassWord frm = new FrmEditPassWord(Guid.Empty, true);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {


            //        MenuAllowEdit.Checked = true;

            //    }
            //    else
            //    {
            //        MenuAllowEdit.Checked = false;

            //    }
            //}

            //AllowEdit = MenuAllowEdit.Checked;
        }

        private void MenuLogOut_Click_1(object sender, EventArgs e)
        {
            AppSetting.DataBase = DBConnect.DBConnection.Database;

            FrmLogin frmlog = new FrmLogin();
            if (frmlog.ShowDialog(this) == DialogResult.OK)
            {
                currentuser = frmlog.user;
                LoadSettings();

                return;
            }
            else
                return;
        }

        private void MenuFreeze_Click(object sender, EventArgs e)
        {

            AppSetting.DataBase = DBConnect.DBConnection.Database;
            FrmLogin frmlog = new FrmLogin();
            if (frmlog.ShowDialog() == DialogResult.OK)
            {
                currentuser = frmlog.user;
                LoadSettings();

                return;
            }
            else
                return;
        }

        private void MenuPayContractOut_Click(object sender, EventArgs e)
        {

                       RadMenuItem toolmenu = (RadMenuItem)sender;
            if (!IsPermissionGranted(toolmenu.Text))
            {
                MessageBox.Show("لا تملك صلاحية للقيام بهذا العمل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmPayContractOne frm = new FrmPayContractOne(Guid.Empty, true, 2);
            frm.Show(this);
        }

        private void MenuLogRpt_Click(object sender, EventArgs e)
        {
            FrmLogRpt frm = new FrmLogRpt("سجل المستخدمين");
            frm.Owner = this;
            frm.Show();
        }

        #endregion

    }
}
