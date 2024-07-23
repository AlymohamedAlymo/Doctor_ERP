using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbPriceLog
{

    public static List<tbPriceLog> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "username", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtusername")]
    public string username { get; set; }
    [DataGUIAttribute(GUIName = "changedate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtchangedate")]
    public DateTime changedate { get; set; }
    [DataGUIAttribute(GUIName = "oldprice", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtoldprice")]
    public decimal oldprice { get; set; }
    [DataGUIAttribute(GUIName = "newprice", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnewprice")]
    public decimal newprice { get; set; }
    [DataGUIAttribute(GUIName = "actno", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtactno")]
    public int actno { get; set; }
    [DataGUIAttribute(GUIName = "actdate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtactdate")]
    public DateTime actdate { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbPriceLog VALUES (@guid, @parentguid, @username, @changedate, @oldprice, @newprice, @actno, @actdate)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@username", username);
        DBConnect.DBCommand.Parameters.AddWithValue("@changedate", changedate);
        DBConnect.DBCommand.Parameters.AddWithValue("@oldprice", oldprice);
        DBConnect.DBCommand.Parameters.AddWithValue("@newprice", newprice);
        DBConnect.DBCommand.Parameters.AddWithValue("@actno", actno);
        DBConnect.DBCommand.Parameters.AddWithValue("@actdate", actdate);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbPriceLog SET parentguid = @parentguid, username = @username, changedate = @changedate, oldprice = @oldprice, newprice = @newprice, actno = @actno, actdate = @actdate WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@username", username);
        DBConnect.DBCommand.Parameters.AddWithValue("@changedate", changedate);
        DBConnect.DBCommand.Parameters.AddWithValue("@oldprice", oldprice);
        DBConnect.DBCommand.Parameters.AddWithValue("@newprice", newprice);
        DBConnect.DBCommand.Parameters.AddWithValue("@actno", actno);
        DBConnect.DBCommand.Parameters.AddWithValue("@actdate", actdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPriceLog WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbPriceLog  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPriceLog";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbPriceLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPriceLog", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPriceLog PriceLog = new tbPriceLog();

            PriceLog.guid = new Guid(dr["guid"].ToString());
            PriceLog.parentguid = new Guid(dr["parentguid"].ToString());
            PriceLog.username = (string)dr["username"];
            PriceLog.changedate = (DateTime)dr["changedate"];
            PriceLog.oldprice = decimal.Parse(dr["oldprice"].ToString());
            PriceLog.newprice = decimal.Parse(dr["newprice"].ToString());
            PriceLog.actno = int.Parse(dr["actno"].ToString());
            PriceLog.actdate = (DateTime)dr["actdate"];

            lstData.Add(PriceLog);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbPriceLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPriceLog WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPriceLog PriceLog = new tbPriceLog();

            PriceLog.guid = new Guid(dr["guid"].ToString());
            PriceLog.parentguid = new Guid(dr["parentguid"].ToString());
            PriceLog.username = (string)dr["username"];
            PriceLog.changedate = (DateTime)dr["changedate"];
            PriceLog.oldprice = decimal.Parse(dr["oldprice"].ToString());
            PriceLog.newprice = decimal.Parse(dr["newprice"].ToString());
            PriceLog.actno = int.Parse(dr["actno"].ToString());
            PriceLog.actdate = (DateTime)dr["actdate"];

            lstData.Add(PriceLog);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbPriceLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPriceLog WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPriceLog PriceLog = new tbPriceLog();

            PriceLog.guid = new Guid(dr["guid"].ToString());
            PriceLog.parentguid = new Guid(dr["parentguid"].ToString());
            PriceLog.username = (string)dr["username"];
            PriceLog.changedate = (DateTime)dr["changedate"];
            PriceLog.oldprice = decimal.Parse(dr["oldprice"].ToString());
            PriceLog.newprice = decimal.Parse(dr["newprice"].ToString());
            PriceLog.actno = int.Parse(dr["actno"].ToString());
            PriceLog.actdate = (DateTime)dr["actdate"];

            lstData.Add(PriceLog);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbPriceLog>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPriceLog WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPriceLog PriceLog = new tbPriceLog();

            PriceLog.guid = new Guid(dr["guid"].ToString());
            PriceLog.parentguid = new Guid(dr["parentguid"].ToString());
            PriceLog.username = (string)dr["username"];
            PriceLog.changedate = (DateTime)dr["changedate"];
            PriceLog.oldprice = decimal.Parse(dr["oldprice"].ToString());
            PriceLog.newprice = decimal.Parse(dr["newprice"].ToString());
            PriceLog.actno = int.Parse(dr["actno"].ToString());
            PriceLog.actdate = (DateTime)dr["actdate"];

            lstData.Add(PriceLog);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbPriceLog FindBy(string dbcolumn, object val)
    {
        tbPriceLog PriceLog = new tbPriceLog();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPriceLog WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PriceLog.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            PriceLog.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            PriceLog.username = (string)DBConnect.DBReader["username"];
            PriceLog.changedate = (DateTime)DBConnect.DBReader["changedate"];
            PriceLog.oldprice = decimal.Parse(DBConnect.DBReader["oldprice"].ToString());
            PriceLog.newprice = decimal.Parse(DBConnect.DBReader["newprice"].ToString());
            PriceLog.actno = int.Parse(DBConnect.DBReader["actno"].ToString());
            PriceLog.actdate = (DateTime)DBConnect.DBReader["actdate"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PriceLog;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbPriceLog WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbPriceLog", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPriceLog", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPriceLog", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbPriceLog WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPriceLog", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtusername
dtchangedate
Txtoldprice
Txtnewprice
Txtactno
dtactdate


*/