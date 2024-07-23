using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using DoctorERP;

public class tbLog
{

    public static List<tbLog> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "username", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtusername")]
    public string username { get; set; }
    [DataGUIAttribute(GUIName = "actiontype", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtactiontype")]
    public string actiontype { get; set; }
    [DataGUIAttribute(GUIName = "action", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtaction")]
    public string action { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbLog VALUES (@guid, @regdate, @username, @actiontype, @action, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@username", username);
        DBConnect.DBCommand.Parameters.AddWithValue("@actiontype", actiontype);
        DBConnect.DBCommand.Parameters.AddWithValue("@action", action);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbLog SET regdate = @regdate, username = @username, actiontype = @actiontype, action = @action, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@username", username);
        DBConnect.DBCommand.Parameters.AddWithValue("@actiontype", actiontype);
        DBConnect.DBCommand.Parameters.AddWithValue("@action", action);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLog WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbLog  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLog";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLog", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLog Log = new tbLog();

            Log.guid = new Guid(dr["guid"].ToString());
            Log.regdate = (DateTime)dr["regdate"];
            Log.username = (string)dr["username"];
            Log.actiontype = (string)dr["actiontype"];
            Log.action = (string)dr["action"];
            Log.note = (string)dr["note"];

            lstData.Add(Log);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLog WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLog Log = new tbLog();

            Log.guid = new Guid(dr["guid"].ToString());
            Log.regdate = (DateTime)dr["regdate"];
            Log.username = (string)dr["username"];
            Log.actiontype = (string)dr["actiontype"];
            Log.action = (string)dr["action"];
            Log.note = (string)dr["note"];

            lstData.Add(Log);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLog WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLog Log = new tbLog();

            Log.guid = new Guid(dr["guid"].ToString());
            Log.regdate = (DateTime)dr["regdate"];
            Log.username = (string)dr["username"];
            Log.actiontype = (string)dr["actiontype"];
            Log.action = (string)dr["action"];
            Log.note = (string)dr["note"];

            lstData.Add(Log);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLog WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLog Log = new tbLog();

            Log.guid = new Guid(dr["guid"].ToString());
            Log.regdate = (DateTime)dr["regdate"];
            Log.username = (string)dr["username"];
            Log.actiontype = (string)dr["actiontype"];
            Log.action = (string)dr["action"];
            Log.note = (string)dr["note"];

            lstData.Add(Log);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbLog FindBy(string dbcolumn, object val)
    {
        tbLog Log = new tbLog();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLog WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Log.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Log.regdate = (DateTime)DBConnect.DBReader["regdate"];
            Log.username = (string)DBConnect.DBReader["username"];
            Log.actiontype = (string)DBConnect.DBReader["actiontype"];
            Log.action = (string)DBConnect.DBReader["action"];
            Log.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Log;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbLog WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbLog", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLog", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbLog", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbLog WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLog", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }

    public static void AddLog(string actiontype, string action, string note)
    {
        tbLog lo = new tbLog();
        lo.guid = Guid.NewGuid();
        lo.actiontype = actiontype;
        lo.action = action;
        lo.regdate = DateTime.Now;
        lo.username = FrmMain.currentuser.name;
        lo.note = note;
        lo.Insert();
    }
}

/*

dtregdate
Txtusername
Txtactiontype
Txtaction
Txtnote


*/