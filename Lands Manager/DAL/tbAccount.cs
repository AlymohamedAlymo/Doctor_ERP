using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbAccount
{

    public static List<tbAccount> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الاسم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "آخر عملية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlastaction")]
    public string lastaction { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbAccount VALUES (@guid, @number, @name, @note , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbAccount SET number = @number, name = @name, note = @note , lastaction= @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAccount WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbAccount  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAccount";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbAccount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAccount", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAccount Account = new tbAccount();

            Account.guid = new Guid(dr["guid"].ToString());
            Account.number = (int)dr["number"];
            Account.name = (string)dr["name"];
            Account.note = (string)dr["note"];
            Account.lastaction = (string)dr["lastaction"];

            lstData.Add(Account);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbAccount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAccount WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAccount Account = new tbAccount();

            Account.guid = new Guid(dr["guid"].ToString());
            Account.number = (int)dr["number"];
            Account.name = (string)dr["name"];
            Account.note = (string)dr["note"];
            Account.lastaction = (string)dr["lastaction"];

            lstData.Add(Account);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbAccount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAccount WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAccount Account = new tbAccount();

            Account.guid = new Guid(dr["guid"].ToString());
            Account.number = (int)dr["number"];
            Account.name = (string)dr["name"];
            Account.note = (string)dr["note"];
            Account.lastaction = (string)dr["lastaction"];

            lstData.Add(Account);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbAccount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAccount WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAccount Account = new tbAccount();

            Account.guid = new Guid(dr["guid"].ToString());
            Account.number = (int)dr["number"];
            Account.name = (string)dr["name"];
            Account.note = (string)dr["note"];
            Account.lastaction = (string)dr["lastaction"];

            lstData.Add(Account);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbAccount FindBy(string dbcolumn, object val)
    {
        tbAccount Account = new tbAccount();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAccount WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Account.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Account.number = (int)DBConnect.DBReader["number"];
            Account.name = (string)DBConnect.DBReader["name"];
            Account.note = (string)DBConnect.DBReader["note"];
            Account.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Account;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbAccount WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbAccount", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAccount", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbAccount", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbAccount WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAccount", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtname
Txtnote


*/