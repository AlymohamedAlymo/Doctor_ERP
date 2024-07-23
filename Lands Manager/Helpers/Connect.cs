using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

class DBConnect
{
    public const string DataBaseTypeName = "LandManageDataBaseName";
    public const string DataBaseDefFile = "defDatabase";

    #region public vars
    public static SqlConnection DBConnection;
    public static SqlConnectionStringBuilder DBConnectionStringBuilder;

    public static SqlCommand DBCommand;
    public static SqlDataAdapter DBAdapter;
    public static SqlDataReader DBReader;

    public static SqlTransaction DBTrans;
    #endregion

    #region Windows Authentication
    public DBConnect(string ServerName, string DataBaseName, string DataBasePath, bool Localdb, bool Attach)
    {
        DBConnectionStringBuilder = new SqlConnectionStringBuilder();

        if (Attach)
            DBConnectionStringBuilder.Add("AttachDbFilename", DataBasePath);

        DBConnectionStringBuilder.MultipleActiveResultSets = true;

        DBConnectionStringBuilder.DataSource = ServerName;
        DBConnectionStringBuilder.Add("Initial Catalog", DataBaseName);
        DBConnectionStringBuilder.Add("Integrated Security", "SSPI");
        DBConnectionStringBuilder.Add("APP", "");

        DBConnection = new SqlConnection(DBConnectionStringBuilder.ToString());

    }
    #endregion

    #region SQL Authentication
    public DBConnect(string ServerName, string DataBaseName, string UserName, string Password)
    {
        DBConnectionStringBuilder = new SqlConnectionStringBuilder();

        //DBConnectionStringBuilder.Provider = "SQLOLEDB";

        DBConnectionStringBuilder.DataSource = ServerName;

        DBConnectionStringBuilder.MultipleActiveResultSets = true;

        DBConnectionStringBuilder.PersistSecurityInfo = false;
        DBConnectionStringBuilder.Add("User ID", UserName);
        DBConnectionStringBuilder.Add("password", Password);

        DBConnectionStringBuilder.Add("Initial Catalog", DataBaseName);


        DBConnectionStringBuilder.Add("APP", "");

        DBConnection = new SqlConnection(DBConnectionStringBuilder.ToString());
    }
    #endregion

    #region TransAction
    public static void StartTransAction()
    {
        DBConnect.DBTrans = DBConnect.DBConnection.BeginTransaction();
        DBConnect.DBCommand = DBConnect.DBConnection.CreateCommand();
        DBConnect.DBCommand.Transaction = DBConnect.DBTrans;
    }

    public static bool CommitTransAction()
    {
        try
        {
            DBConnect.DBTrans.Commit();
            return true;
        }
        catch
        {

            // DBConnect.DBTrans.Rollback();
            return false;
        }
    }

    public static bool RollBackTransAction()
    {
        try
        {
            DBConnect.DBTrans.Rollback();
            return true;
        }
        catch
        {
            //Console.WriteLine(ex.Message);
            // DBConnect.DBTrans.Rollback();
            return false;
        }
    }
    #endregion

    #region DataBases
    public static List<string> GetDataBases()
    {
        List<string> lstDataBases = new List<string>();

        DBConnect.DBCommand = new SqlCommand("SELECT name FROM sysdatabases", DBConnect.DBConnection);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();

        while (DBConnect.DBReader.Read())
        {
            lstDataBases.Add(DBConnect.DBReader["name"].ToString().ToLower());
        }

        DBConnect.DBReader.Close();

        return lstDataBases;
    }


    #endregion

    #region Connection form
    public static bool TryToConnect(string Database)
    {
        if (AppSetting.ReadSetting())
        {
            DBConnect connection;
            if (!AppSetting.SqlAuth)
            {
                connection = new DBConnect(AppSetting.ServerName, Database, string.Empty, true, false);
            }
            else
                connection = new DBConnect(AppSetting.ServerName, Database, AppSetting.UserName, AppSetting.Password);

            try
            {
                DBConnect.DBConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("open database") && System.IO.File.Exists(AppSetting.GetAppPath() + DataBaseDefFile))
                {
                    if (MessageBox.Show("لم يتمكن البرنامج من الإتصال بقاعدة البيانات الإفتراضية، هل تريد إظهار كافة قواعد البيانات و إختيار قاعدة للإتصال بها ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            System.IO.File.Delete(AppSetting.GetAppPath() + DataBaseDefFile);
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;

            }
        }
        else
        {
            FrmConnection frmCon = new FrmConnection();
            if (frmCon.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    public static bool CreateNewDataBase(string dbName, string dbDescription)
    {
        dbName = FileHelper.RemoveInvalidChars(dbName).Replace("'", "");

        dbName = dbName.Trim().ToLower();

        if (!FileHelper.IsEnglish(dbName))
        {
            MessageBox.Show("يجب أن يكون اسم قاعدة البيانات باللغة الإنكليزية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        if (dbName.Equals(string.Empty))
        {
            MessageBox.Show("يجب إدخال اسم قاعدة البيانات", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        try
        {
            List<string> lstDB = DBConnect.GetDataBases();

            if (!lstDB.Contains(dbName.ToLower()))
            {
                if (AppSetting.SqlType == 0)
                    InitSchema.CreateDataBase(dbName, AppSetting.DataBasePath + dbName + ".mdf");
                else if (AppSetting.SqlType == 1)
                    InitSchema.CreateDataBase(dbName, string.Empty);
            }
            else
            {
                MessageBox.Show("يوجد قاعدة بيانات سابقة بنفس الاسم" + Environment.NewLine + dbName + Environment.NewLine + "يرجى إختيار اسم آخر", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (dbDescription.Trim().Length > 0)
                InitSchema.InitSchemaScript(dbName, dbDescription);
            else
                InitSchema.InitSchemaScript(dbName, dbName);


            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("حدث خطأ أثناء إنشاء قاعدة البيانات الجديدة" + "\r\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
    }

    public static DateTime GetServerTime()
    {
        DBCommand.CommandText = "SELECT GETDATE()";

        return (DateTime)DBCommand.ExecuteScalar();
    }


    public static string GetDatabaseDescription(string Database)
    {
        string Desc = string.Empty;
        try
        {
            DBCommand = new SqlCommand(string.Format("SELECT value FROM {0}.sys.extended_properties WHERE name = 'LandManageDataBaseName'", Database), DBConnect.DBConnection);
            Desc = DBConnect.DBCommand.ExecuteScalar().ToString();
        }
        catch
        {

        }

        if (Desc.Trim().Length <= 0)
            return Database;
        else
            return Desc;

    }


    public static List<DataBase> GetPocPalDesktopDatabase(bool ShowAll)
    {
        List<DataBase> LstDB = new List<DataBase>();
        string DefDatabase = string.Empty;

        if (ShowAll)
        {
            DBCommand = new SqlCommand("Select name , FileName From sysdatabases WHERE name <> 'master' AND name <> 'tempdb' AND name <> 'model' AND name <> 'msdb'", DBConnect.DBConnection);
            DBCommand.ExecuteNonQuery();

            DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
            while (DBConnect.DBReader.Read())
            {
                DataBase db = new DataBase();
                db.SqlName = DBReader["Name"].ToString();
                db.Description = string.Empty;
                db.FileLocation = DBReader["FileName"].ToString();
                db.IsDef = false;
                LstDB.Add(db);
            }
            DBConnect.DBReader.Close();

            foreach (DataBase item in LstDB)
            {
                try
                {
                    DBCommand = new SqlCommand(string.Format("SELECT value FROM {0}.sys.extended_properties WHERE Name = 'LandManageDataBaseName'", item.SqlName), DBConnect.DBConnection);
                    item.Description = DBConnect.DBCommand.ExecuteScalar().ToString();
                }
                catch
                {

                }


            }
        }
        else
        {
            List<DataBase> lstDBTemp = new List<DataBase>();
            DBCommand = new SqlCommand("Select name , FileName From sysdatabases WHERE name <> 'master' AND name <> 'tempdb' AND name <> 'model' AND name <> 'msdb'", DBConnect.DBConnection);
            DBCommand.ExecuteNonQuery();
            DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
            while (DBConnect.DBReader.Read())
            {
                DataBase db = new DataBase();
                db.SqlName = DBReader["Name"].ToString();
                db.Description = string.Empty;
                db.FileLocation = DBReader["FileName"].ToString();
                db.IsDef = false;
                lstDBTemp.Add(db);
            }

            DBConnect.DBReader.Close();

            foreach (DataBase item in lstDBTemp)
            {
                try
                {
                    DBCommand = new SqlCommand(string.Format("SELECT value FROM {0}.sys.extended_properties WHERE name = 'LandManageDataBaseName'", item.SqlName), DBConnect.DBConnection);
                    //item.Description = DBConnect.DBCommand.ExecuteScalar().ToString();
                    LstDB.Add(item);
                }
                catch
                {

                }
            }

        }


        return LstDB;
    }

    #region Execute Stored Procedure
    public static void ExeStoredProcedure(string StoredProcedureName, params object[] oleParamName_Values)
    {

        DBCommand = new SqlCommand(StoredProcedureName, DBConnect.DBConnection);
        DBCommand.CommandType = System.Data.CommandType.StoredProcedure;

        for (int i = 0; i < oleParamName_Values.Length; i += 2)
        {
            DBCommand.Parameters.AddWithValue("@" + oleParamName_Values[i], oleParamName_Values[i + 1]);
        }

        DBCommand.ExecuteNonQuery();

        DBCommand.Parameters.Clear();

    }
    #endregion

    #region Backup and Restore
    public static void Backup(string BackupFile, string Description)
    {
        DBConnect.DBCommand = new SqlCommand("BACKUP DATABASE @DataBase TO DISK = @BackupFile WITH INIT , DESCRIPTION = @Description", DBConnect.DBConnection);
        DBCommand.Parameters.AddWithValue("@DataBase", DBConnect.DBConnection.Database);
        DBCommand.Parameters.AddWithValue("@BackupFile", BackupFile);
        DBCommand.Parameters.AddWithValue("@Description", Description);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBCommand.Parameters.Clear();
    }

    public static void Restore(string BackupFile)
    {
        string DataBaseName = DBConnect.DBConnection.Database;

        string RestoreScript = string.Empty;// global::DoctorERP.Properties.Resources.Restore;

        RestoreScript = RestoreScript.Replace("%DBName%", DataBaseName).Replace("%BackupPath%", BackupFile);
        DBConnect.DBCommand = new SqlCommand(RestoreScript, DBConnect.DBConnection);
        DBConnect.DBCommand.ExecuteNonQuery();

        DBConnect.DBCommand = new SqlCommand("USE " + DataBaseName, DBConnect.DBConnection);
        DBConnect.DBCommand.ExecuteNonQuery();
    }


    public static string GetBackupDescription(string Backupfile)
    {
        if (Backupfile.Equals(string.Empty))
            return string.Empty;

        DataTable datatable = new DataTable();
        DBConnect.DBCommand = new SqlCommand("RESTORE HEADERONLY FROM DISK = @Backupfile", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Backupfile", Backupfile);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(datatable);

        if (datatable.Rows.Count > 0)
            return datatable.Rows[0]["BackupDescription"].ToString();
        else
            return string.Empty;
    }
    #endregion
}

