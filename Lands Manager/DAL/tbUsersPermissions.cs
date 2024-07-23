using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbUsersPermissions
{

    public static List<tbUsersPermissions> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "UserGuid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid UserGuid { get; set; }
    [DataGUIAttribute(GUIName = "PermissionName", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtPermissionName")]
    public string PermissionName { get; set; }
    [DataGUIAttribute(GUIName = "PermissionValue", Formatting = "", Visibility = true, Width = 100, ControlName = "ChkPermissionValue")]
    public bool PermissionValue { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbUsersPermissions VALUES (@Guid, @UserGuid, @PermissionName, @PermissionValue)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@UserGuid", UserGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@PermissionName", PermissionName);
        DBConnect.DBCommand.Parameters.AddWithValue("@PermissionValue", PermissionValue);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbUsersPermissions SET UserGuid = @UserGuid, PermissionName = @PermissionName, PermissionValue = @PermissionValue WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@UserGuid", UserGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@PermissionName", PermissionName);
        DBConnect.DBCommand.Parameters.AddWithValue("@PermissionValue", PermissionValue);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbUsersPermissions WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbUsersPermissions  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbUsersPermissions";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbUsersPermissions>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbUsersPermissions", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsersPermissions userspermissions = new tbUsersPermissions();

            userspermissions.Guid = new Guid(dr["Guid"].ToString());
            userspermissions.UserGuid = new Guid(dr["UserGuid"].ToString());
            userspermissions.PermissionName = (string)dr["PermissionName"];
            userspermissions.PermissionValue = (bool)dr["PermissionValue"];

            lstData.Add(userspermissions);
        }
    }

    public static void Fill(Guid guid)
    {
        lstData = new List<tbUsersPermissions>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbUsersPermissions WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsersPermissions userspermissions = new tbUsersPermissions();

            userspermissions.Guid = new Guid(dr["Guid"].ToString());
            userspermissions.UserGuid = new Guid(dr["UserGuid"].ToString());
            userspermissions.PermissionName = (string)dr["PermissionName"];
            userspermissions.PermissionValue = (bool)dr["PermissionValue"];

            lstData.Add(userspermissions);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbUsersPermissions>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsersPermissions WHERE {0} = @val",  dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsersPermissions userspermissions = new tbUsersPermissions();

            userspermissions.Guid = new Guid(dr["Guid"].ToString());
            userspermissions.UserGuid = new Guid(dr["UserGuid"].ToString());
            userspermissions.PermissionName = (string)dr["PermissionName"];
            userspermissions.PermissionValue = (bool)dr["PermissionValue"];

            lstData.Add(userspermissions);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbUsersPermissions>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsersPermissions WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsersPermissions userspermissions = new tbUsersPermissions();

            userspermissions.Guid = new Guid(dr["Guid"].ToString());
            userspermissions.UserGuid = new Guid(dr["UserGuid"].ToString());
            userspermissions.PermissionName = (string)dr["PermissionName"];
            userspermissions.PermissionValue = (bool)dr["PermissionValue"];

            lstData.Add(userspermissions);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbUsersPermissions FindBy(string dbcolumn, object val , string Permissions)
    {
        tbUsersPermissions userspermissions = new tbUsersPermissions();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsersPermissions  WHERE {0} = {1} AND PermissionName = @PermissionName", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.Parameters.AddWithValue("@PermissionName", Permissions);

        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            userspermissions.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            userspermissions.UserGuid = new Guid(DBConnect.DBReader["UserGuid"].ToString());
            userspermissions.PermissionName = (string)DBConnect.DBReader["PermissionName"];
            userspermissions.PermissionValue = (bool)DBConnect.DBReader["PermissionValue"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return userspermissions;
    }

    public static tbUsersPermissions FindBy(string dbcolumn, object val)
    {
        tbUsersPermissions userspermissions = new tbUsersPermissions();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsersPermissions WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            userspermissions.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            userspermissions.UserGuid = new Guid(DBConnect.DBReader["UserGuid"].ToString());
            userspermissions.PermissionName = (string)DBConnect.DBReader["PermissionName"];
            userspermissions.PermissionValue = (bool)DBConnect.DBReader["PermissionValue"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return userspermissions;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbUsersPermissions WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbUsersPermissions", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbUsersPermissions", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbUsersPermissions", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbUsersPermissions WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbUsersPermissions", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtPermissionName
ChkPermissionValue


*/
