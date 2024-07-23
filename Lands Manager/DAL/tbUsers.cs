using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbUsers
{

    public static List<tbUsers> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "الاسم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "password", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtpassword")]
    public string password { get; set; }
    [DataGUIAttribute(GUIName = "IsAdmin", Formatting = "", Visibility = false, Width = 100, ControlName = "ChkIsAdmin")]
    public bool IsAdmin { get; set; }
    [DataGUIAttribute(GUIName = "CanAdd", Formatting = "", Visibility = false, Width = 100, ControlName = "ChkCanAdd")]
    public bool CanAdd { get; set; }
    [DataGUIAttribute(GUIName = "CanEdit", Formatting = "", Visibility = false, Width = 100, ControlName = "ChkCanEdit")]
    public bool CanEdit { get; set; }
    [DataGUIAttribute(GUIName = "CanDelete", Formatting = "", Visibility = false, Width = 100, ControlName = "ChkCanDelete")]
    public bool CanDelete { get; set; }
    [DataGUIAttribute(GUIName = "CanPrint", Formatting = "", Visibility = false, Width = 100, ControlName = "ChkCanPrint")]
    public bool CanPrint { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbUsers VALUES (@guid, @name, @password, @IsAdmin, @CanAdd, @CanEdit, @CanDelete, @CanPrint)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@password", password);
        DBConnect.DBCommand.Parameters.AddWithValue("@IsAdmin", IsAdmin);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanAdd", CanAdd);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanEdit", CanEdit);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanDelete", CanDelete);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanPrint", CanPrint);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbUsers SET name = @name, password = @password,  IsAdmin = @IsAdmin, CanAdd = @CanAdd, CanEdit = @CanEdit, CanDelete = @CanDelete, CanPrint = @CanPrint WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@password", password);
        DBConnect.DBCommand.Parameters.AddWithValue("@IsAdmin", IsAdmin);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanAdd", CanAdd);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanEdit", CanEdit);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanDelete", CanDelete);
        DBConnect.DBCommand.Parameters.AddWithValue("@CanPrint", CanPrint);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbUsers WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbUsers  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbUsers";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbUsers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbUsers", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsers Users = new tbUsers();

            Users.guid = new Guid(dr["guid"].ToString());
            Users.name = (string)dr["name"];
            Users.password = (string)dr["password"];
            Users.IsAdmin = (bool)dr["IsAdmin"];
            Users.CanAdd = (bool)dr["CanAdd"];
            Users.CanEdit = (bool)dr["CanEdit"];
            Users.CanDelete = (bool)dr["CanDelete"];
            Users.CanPrint = (bool)dr["CanPrint"];

            lstData.Add(Users);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbUsers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbUsers WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsers Users = new tbUsers();

            Users.guid = new Guid(dr["guid"].ToString());
            Users.name = (string)dr["name"];
            Users.password = (string)dr["password"];
            Users.IsAdmin = (bool)dr["IsAdmin"];
            Users.CanAdd = (bool)dr["CanAdd"];
            Users.CanEdit = (bool)dr["CanEdit"];
            Users.CanDelete = (bool)dr["CanDelete"];
            Users.CanPrint = (bool)dr["CanPrint"];

            lstData.Add(Users);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbUsers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsers WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsers Users = new tbUsers();

            Users.guid = new Guid(dr["guid"].ToString());
            Users.name = (string)dr["name"];
            Users.password = (string)dr["password"];
            Users.IsAdmin = (bool)dr["IsAdmin"];
            Users.CanAdd = (bool)dr["CanAdd"];
            Users.CanEdit = (bool)dr["CanEdit"];
            Users.CanDelete = (bool)dr["CanDelete"];
            Users.CanPrint = (bool)dr["CanPrint"];

            lstData.Add(Users);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbUsers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsers WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbUsers Users = new tbUsers();

            Users.guid = new Guid(dr["guid"].ToString());
            Users.name = (string)dr["name"];
            Users.password = (string)dr["password"];
            Users.IsAdmin = (bool)dr["IsAdmin"];
            Users.CanAdd = (bool)dr["CanAdd"];
            Users.CanEdit = (bool)dr["CanEdit"];
            Users.CanDelete = (bool)dr["CanDelete"];
            Users.CanPrint = (bool)dr["CanPrint"];

            lstData.Add(Users);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbUsers FindBy(string dbcolumn, object val)
    {
        tbUsers Users = new tbUsers();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbUsers WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Users.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Users.name = (string)DBConnect.DBReader["name"];
            Users.password = (string)DBConnect.DBReader["password"];
            Users.IsAdmin = (bool)DBConnect.DBReader["IsAdmin"];
            Users.CanAdd = (bool)DBConnect.DBReader["CanAdd"];
            Users.CanEdit = (bool)DBConnect.DBReader["CanEdit"];
            Users.CanDelete = (bool)DBConnect.DBReader["CanDelete"];
            Users.CanPrint = (bool)DBConnect.DBReader["CanPrint"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Users;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbUsers WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbUsers", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbUsers", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbUsers", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbUsers WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbUsers", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtname
Txtpassword
Txtdepart
ChkIsAdmin
ChkCanAdd
ChkCanEdit
ChkCanDelete
ChkCanPrint


*/
