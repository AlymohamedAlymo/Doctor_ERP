using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbAppInfo
{

    public static List<tbAppInfo> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "AppTitle", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtAppTitle")]
    public string AppTitle { get; set; }
    [DataGUIAttribute(GUIName = "ColumnCount", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtColumnCount")]
    public int ColumnCount { get; set; }

    [DataGUIAttribute(GUIName = "BackupOnExit", Formatting = "", Visibility = true, Width = 100, ControlName = "ChkBackupOnExit")]
    public bool BackupOnExit { get; set; }
    [DataGUIAttribute(GUIName = "BackupPath", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtBackupPath")]
    public string BackupPath { get; set; }
    [DataGUIAttribute(GUIName = "background", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtbackground")]
    public Byte[] background { get; set; }
    [DataGUIAttribute(GUIName = "KMStyle", Formatting = "N0", Visibility = true, Width = 100, ControlName = "TxtKMStyle")]
    public int KMStyle { get; set; }
    [DataGUIAttribute(GUIName = "QtyFormat", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtQtyFormat")]
    public string QtyFormat { get; set; }
    [DataGUIAttribute(GUIName = "CurrecnyFormat", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtCurrecnyFormat")]
    public string CurrecnyFormat { get; set; }
    [DataGUIAttribute(GUIName = "Logo", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtLogo")]
    public Byte[] Logo { get; set; }
    [DataGUIAttribute(GUIName = "ShowConfirmMSG", Formatting = "", Visibility = true, Width = 100, ControlName = "ChkShowConfirmMSG")]
    public bool ShowConfirmMSG { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbAppInfo VALUES (@Guid, @AppTitle, @ColumnCount , @BackupOnExit, @BackupPath, @background, @KMStyle, @QtyFormat, @CurrecnyFormat, @Logo , @ShowConfirmMSG)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@AppTitle", AppTitle);
        DBConnect.DBCommand.Parameters.AddWithValue("@ColumnCount", ColumnCount);
        DBConnect.DBCommand.Parameters.AddWithValue("@BackupOnExit", BackupOnExit);
        DBConnect.DBCommand.Parameters.AddWithValue("@BackupPath", BackupPath);
        DBConnect.DBCommand.Parameters.AddWithValue("@background", background);
        DBConnect.DBCommand.Parameters.AddWithValue("@KMStyle", KMStyle);
        DBConnect.DBCommand.Parameters.AddWithValue("@QtyFormat", QtyFormat);
        DBConnect.DBCommand.Parameters.AddWithValue("@CurrecnyFormat", CurrecnyFormat);
        DBConnect.DBCommand.Parameters.AddWithValue("@Logo", Logo);
        DBConnect.DBCommand.Parameters.AddWithValue("@ShowConfirmMSG", ShowConfirmMSG);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbAppInfo SET AppTitle = @AppTitle,ColumnCount = @ColumnCount , BackupOnExit = @BackupOnExit, BackupPath = @BackupPath, background = @background, KMStyle = @KMStyle, QtyFormat = @QtyFormat, CurrecnyFormat = @CurrecnyFormat, Logo = @Logo, ShowConfirmMSG = @ShowConfirmMSG  WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@AppTitle", AppTitle);
        DBConnect.DBCommand.Parameters.AddWithValue("@ColumnCount", ColumnCount);
        DBConnect.DBCommand.Parameters.AddWithValue("@BackupOnExit", BackupOnExit);
        DBConnect.DBCommand.Parameters.AddWithValue("@BackupPath", BackupPath);
        DBConnect.DBCommand.Parameters.AddWithValue("@background", background);
        DBConnect.DBCommand.Parameters.AddWithValue("@KMStyle", KMStyle);
        DBConnect.DBCommand.Parameters.AddWithValue("@QtyFormat", QtyFormat);
        DBConnect.DBCommand.Parameters.AddWithValue("@CurrecnyFormat", CurrecnyFormat);
        DBConnect.DBCommand.Parameters.AddWithValue("@Logo", Logo);
        DBConnect.DBCommand.Parameters.AddWithValue("@ShowConfirmMSG", ShowConfirmMSG);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAppInfo WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbAppInfo  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAppInfo";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbAppInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAppInfo", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAppInfo appinfo = new tbAppInfo();

            appinfo.Guid = new Guid(dr["Guid"].ToString());
            appinfo.AppTitle = (string)dr["AppTitle"];
            appinfo.ColumnCount = int.Parse(dr["ColumnCount"].ToString());
            appinfo.BackupOnExit = (bool)dr["BackupOnExit"];
            appinfo.BackupPath = (string)dr["BackupPath"];
            appinfo.background = (Byte[])dr["background"];
            appinfo.KMStyle = (int)dr["KMStyle"];
            appinfo.QtyFormat = (string)dr["QtyFormat"];
            appinfo.CurrecnyFormat = (string)dr["CurrecnyFormat"];
            appinfo.Logo = (Byte[])dr["Logo"];
            appinfo.ShowConfirmMSG = (bool)dr["ShowConfirmMSG"];

            lstData.Add(appinfo);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbAppInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAppInfo WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAppInfo appinfo = new tbAppInfo();

            appinfo.Guid = new Guid(dr["Guid"].ToString());
            appinfo.AppTitle = (string)dr["AppTitle"];
            appinfo.ColumnCount = int.Parse(dr["ColumnCount"].ToString());
            appinfo.BackupOnExit = (bool)dr["BackupOnExit"];
            appinfo.BackupPath = (string)dr["BackupPath"];
            appinfo.background = (Byte[])dr["background"];
            appinfo.KMStyle = (int)dr["KMStyle"];
            appinfo.QtyFormat = (string)dr["QtyFormat"];
            appinfo.CurrecnyFormat = (string)dr["CurrecnyFormat"];
            appinfo.Logo = (Byte[])dr["Logo"];
            appinfo.ShowConfirmMSG = (bool)dr["ShowConfirmMSG"];

            lstData.Add(appinfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbAppInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAppInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAppInfo appinfo = new tbAppInfo();

            appinfo.Guid = new Guid(dr["Guid"].ToString());
            appinfo.AppTitle = (string)dr["AppTitle"];
            appinfo.ColumnCount = int.Parse(dr["ColumnCount"].ToString());
            appinfo.BackupOnExit = (bool)dr["BackupOnExit"];
            appinfo.BackupPath = (string)dr["BackupPath"];
            appinfo.background = (Byte[])dr["background"];
            appinfo.KMStyle = (int)dr["KMStyle"];
            appinfo.QtyFormat = (string)dr["QtyFormat"];
            appinfo.CurrecnyFormat = (string)dr["CurrecnyFormat"];
            appinfo.Logo = (Byte[])dr["Logo"];
            appinfo.ShowConfirmMSG = (bool)dr["ShowConfirmMSG"];

            lstData.Add(appinfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbAppInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAppInfo WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAppInfo appinfo = new tbAppInfo();

            appinfo.Guid = new Guid(dr["Guid"].ToString());
            appinfo.AppTitle = (string)dr["AppTitle"];
            appinfo.ColumnCount = int.Parse(dr["ColumnCount"].ToString());
            appinfo.BackupOnExit = (bool)dr["BackupOnExit"];
            appinfo.BackupPath = (string)dr["BackupPath"];
            appinfo.background = (Byte[])dr["background"];
            appinfo.KMStyle = (int)dr["KMStyle"];
            appinfo.QtyFormat = (string)dr["QtyFormat"];
            appinfo.CurrecnyFormat = (string)dr["CurrecnyFormat"];
            appinfo.Logo = (Byte[])dr["Logo"];
            appinfo.ShowConfirmMSG = (bool)dr["ShowConfirmMSG"];

            lstData.Add(appinfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbAppInfo FindBy(string dbcolumn, object val)
    {
        tbAppInfo appinfo = new tbAppInfo();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAppInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            appinfo.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            appinfo.AppTitle = (string)DBConnect.DBReader["AppTitle"];
            appinfo.ColumnCount = int.Parse(DBConnect.DBReader["ColumnCount"].ToString());
            appinfo.BackupOnExit = (bool)DBConnect.DBReader["BackupOnExit"];
            appinfo.BackupPath = (string)DBConnect.DBReader["BackupPath"];
            appinfo.background = (Byte[])DBConnect.DBReader["background"];
            appinfo.KMStyle = (int)DBConnect.DBReader["KMStyle"];
            appinfo.QtyFormat = (string)DBConnect.DBReader["QtyFormat"];
            appinfo.CurrecnyFormat = (string)DBConnect.DBReader["CurrecnyFormat"];
            appinfo.Logo = (Byte[])DBConnect.DBReader["Logo"];
            appinfo.ShowConfirmMSG = (bool)DBConnect.DBReader["ShowConfirmMSG"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return appinfo;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbAppInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbAppInfo", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            lstUnique.Add((string)DBConnect.DBReader[dbcolumn.ToString()]);
        }
        DBConnect.DBReader.Close();
        return lstUnique;
    }

    public static int GetMaxNumber(string dbcolumn)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAppInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbAppInfo", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbAppInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAppInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtAppTitle
ChkBackupOnExit
TxtBackupPath
Txtbackground
TxtKMStyle
TxtQtyFormat
TxtCurrecnyFormat
TxtLogo


*/
