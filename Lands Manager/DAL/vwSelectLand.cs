using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwSelectLand
{

    public static List<vwSelectLand> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "النوع", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlandtype")]
    public string landtype { get; set; }
    [DataGUIAttribute(GUIName = "رقم الصك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdeednumber")]
    public string deednumber { get; set; }
    [DataGUIAttribute(GUIName = "الإجمالي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtdeednumber")]
    public string status { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwSelectLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSelectLand", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSelectLand SelectLand = new vwSelectLand();

            SelectLand.guid = new Guid(dr["guid"].ToString());
            SelectLand.code = (int)dr["code"];
            SelectLand.number = (int)dr["number"];
            SelectLand.blocknumber = (string)dr["blocknumber"];
            SelectLand.land = (string)dr["land"];
            SelectLand.landtype = (string)dr["landtype"];
            SelectLand.deednumber = (string)dr["deednumber"];
            SelectLand.total = decimal.Parse(dr["total"].ToString());
            SelectLand.status = (string)dr["status"];

            lstData.Add(SelectLand);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwSelectLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSelectLand WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSelectLand SelectLand = new vwSelectLand();

            SelectLand.guid = new Guid(dr["guid"].ToString());
            SelectLand.code = (int)dr["code"];
            SelectLand.number = (int)dr["number"];
            SelectLand.blocknumber = (string)dr["blocknumber"];
            SelectLand.land = (string)dr["land"];
            SelectLand.landtype = (string)dr["landtype"];
            SelectLand.deednumber = (string)dr["deednumber"];
            SelectLand.total = decimal.Parse(dr["total"].ToString());
            SelectLand.status = (string)dr["status"];

            lstData.Add(SelectLand);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwSelectLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSelectLand WHERE CAST({0} as varchar(255)) = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSelectLand SelectLand = new vwSelectLand();

            SelectLand.guid = new Guid(dr["guid"].ToString());
            SelectLand.code = (int)dr["code"];
            SelectLand.number = (int)dr["number"];
            SelectLand.blocknumber = (string)dr["blocknumber"];
            SelectLand.land = (string)dr["land"];
            SelectLand.landtype = (string)dr["landtype"];
            SelectLand.deednumber = (string)dr["deednumber"];
            SelectLand.total = decimal.Parse(dr["total"].ToString());
            SelectLand.status = (string)dr["status"];

            lstData.Add(SelectLand);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwSelectLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSelectLand WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSelectLand SelectLand = new vwSelectLand();

            SelectLand.guid = new Guid(dr["guid"].ToString());
            SelectLand.code = (int)dr["code"];
            SelectLand.number = (int)dr["number"];
            SelectLand.blocknumber = (string)dr["blocknumber"];
            SelectLand.land = (string)dr["land"];
            SelectLand.landtype = (string)dr["landtype"];
            SelectLand.deednumber = (string)dr["deednumber"];
            SelectLand.total = decimal.Parse(dr["total"].ToString());
            SelectLand.status = (string)dr["status"];

            lstData.Add(SelectLand);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword, string status)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwSelectLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSelectLand WHERE {0} LIKE '%{1}%' AND status = @status", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSelectLand SelectLand = new vwSelectLand();

            SelectLand.guid = new Guid(dr["guid"].ToString());
            SelectLand.code = (int)dr["code"];
            SelectLand.number = (int)dr["number"];
            SelectLand.blocknumber = (string)dr["blocknumber"];
            SelectLand.land = (string)dr["land"];
            SelectLand.landtype = (string)dr["landtype"];
            SelectLand.deednumber = (string)dr["deednumber"];
            SelectLand.total = decimal.Parse(dr["total"].ToString());
            SelectLand.status = (string)dr["status"];

            lstData.Add(SelectLand);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, object keyword, string status)
    {

        lstData = new List<vwSelectLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSelectLand WHERE {0} = @val AND status = @status", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", keyword);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSelectLand SelectLand = new vwSelectLand();

            SelectLand.guid = new Guid(dr["guid"].ToString());
            SelectLand.code = (int)dr["code"];
            SelectLand.number = (int)dr["number"];
            SelectLand.blocknumber = (string)dr["blocknumber"];
            SelectLand.land = (string)dr["land"];
            SelectLand.landtype = (string)dr["landtype"];
            SelectLand.deednumber = (string)dr["deednumber"];
            SelectLand.total = decimal.Parse(dr["total"].ToString());
            SelectLand.status = (string)dr["status"];

            lstData.Add(SelectLand);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static vwSelectLand FindBy(string dbcolumn, object val)
    {
        vwSelectLand SelectLand = new vwSelectLand();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSelectLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            SelectLand.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            SelectLand.code = (int)DBConnect.DBReader["code"];
            SelectLand.number = (int)DBConnect.DBReader["number"];
            SelectLand.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            SelectLand.land = (string)DBConnect.DBReader["land"];
            SelectLand.landtype = (string)DBConnect.DBReader["landtype"];
            SelectLand.deednumber = (string)DBConnect.DBReader["deednumber"];
            SelectLand.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            SelectLand.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return SelectLand;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwSelectLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwSelectLand", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwSelectLand", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwSelectLand", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwSelectLand WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwSelectLand", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtcode
Txtnumber
Txtblocknumber
Txtland
Txtlandtype
Txtdeednumber
Txttotal


*/