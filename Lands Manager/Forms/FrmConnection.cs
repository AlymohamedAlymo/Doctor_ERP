using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

public partial class FrmConnection : KryptonForm
{
    public FrmConnection()
    {
        InitializeComponent();
        AppSetting.ReadSetting();
        CmbSqlType.SelectedIndex = AppSetting.SqlType;
        CmbServer.Text = AppSetting.ServerName;
        CheckBoxWin.Checked = !AppSetting.SqlAuth;
        TxtUserName.Text = AppSetting.UserName;
        TxtPassword.Text = AppSetting.Password;

        TxtDatabasePath.Text = AppSetting.DataBasePath;

         
    }

    private void CheckBoxWin_CheckedChanged(object sender, EventArgs e)
    {
        TxtUserName.Enabled = TxtPassword.Enabled = !CheckBoxWin.Checked;
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {
        //bool Attach = false;

        if (CmbSqlType.SelectedIndex == 0)
        {
            if (TxtDatabasePath.Text.Trim().Length <= 0)
            {
                MessageBox.Show("يجب ادخال مسار قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (File.Exists(TxtDatabasePath.Text))
            {
                if (MessageBox.Show("قاعدة البيانات موجودة مسبقا ، هل تود إستخدامها بدل إنشاء واحدة جديدة ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                   // Attach = false;
                }
                else
                {
                   // Attach = true;
                }
            }
        }


        try
        {
            if (CmbSqlType.SelectedIndex == 0)
            {
                RunCMD.ReturnCMDOutPut("sqllocaldb.exe", "create AccountDB");
                RunCMD.ReturnCMDOutPut("sqllocaldb.exe", "start AccountDB");
            }

            DBConnect connection;
           
            if (CmbSqlType.SelectedIndex == 0)
            {
                connection = new DBConnect(CmbServer.Text, string.Empty, string.Empty, true, false);
            }
            else if (CmbSqlType.SelectedIndex == 1)
            {
                if (CheckBoxWin.Checked)
                {
                    connection = new DBConnect(CmbServer.Text, string.Empty, string.Empty, false, false);
                }
                else
                {
                    connection = new DBConnect(CmbServer.Text, string.Empty, TxtUserName.Text, TxtPassword.Text);
                }
            }

            DBConnect.DBConnection.Open();

            //List<string> lstDB = DBConnect.GetDataBases();

            //if (!lstDB.Contains(TxtDataBase.Text.ToLower()))
            //    InitSchema.CreateDataBase(TxtDataBase.Text, TxtDatabasePath.Text);

            //InitSchema.InitSchemaScript(TxtDataBase.Text, TxtDataBase.Text);

            AppSetting.SqlType = CmbSqlType.SelectedIndex;
            AppSetting.ServerName = CmbServer.Text;
            AppSetting.SqlAuth = !CheckBoxWin.Checked;
            AppSetting.UserName = TxtUserName.Text;
            AppSetting.Password = TxtPassword.Text;
            AppSetting.DataBasePath = TxtDatabasePath.Text;
            AppSetting.DataBase = string.Empty;

            AppSetting.SaveSetting();


            this.DialogResult = DialogResult.OK;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void CmbSqlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CmbSqlType.Focused)
        {
            if (CmbSqlType.SelectedIndex == 0)
            {
                CmbServer.Text = "(LocalDb)\\AccountDB";
                CheckBoxWin.Checked = true;
                CheckBoxWin.Enabled = false;
                TxtUserName.Text = "sa";
                TxtPassword.Text = string.Empty;

                TxtDatabasePath.Text = @"D:\SQL Database\";
                TxtDatabasePath.Enabled = true;
                LblLocalHints.Visible = true;
            }
            else
            {
                CmbServer.Text = "(Local)";
                CheckBoxWin.Enabled = true;
                TxtDatabasePath.Enabled = false;
                TxtDatabasePath.Text = string.Empty;
                LblLocalHints.Visible = false;
            }
        }
    }

    private void BtnDataBasePath_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dbd = new FolderBrowserDialog();
        if (dbd.ShowDialog() == DialogResult.OK)
        {
            if (!dbd.SelectedPath.EndsWith("\\"))
                dbd.SelectedPath += "\\";

            TxtDatabasePath.Text = dbd.SelectedPath;
        }
    }

    public bool IsEnglish(string inputstring)
    {
        Regex regex = new Regex(@"[A-Za-z0-9 .,-=+(){}\[\]\\]");
        MatchCollection matches = regex.Matches(inputstring);

        if (matches.Count.Equals(inputstring.Length))
            return true;
        else
            return false;
    }

   
}
