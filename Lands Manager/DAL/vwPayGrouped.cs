using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwPaysGrouped
{

    public static List<vwPaysGrouped> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "طريقة الدفع", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpaytype")]
    public string paytype { get; set; }
    [DataGUIAttribute(GUIName = "المبلغ", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtAmount")]
    public decimal Amount { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwPaysGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM [fnPaysGrouped] (NULL , NULL )", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaysGrouped PaysGrouped = new vwPaysGrouped();

            PaysGrouped.guid = new Guid(dr["guid"].ToString());
            PaysGrouped.paytype = (string)dr["paytype"];
            PaysGrouped.Amount = decimal.Parse(dr["Amount"].ToString());

            lstData.Add(PaysGrouped);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwPaysGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM [fnPaysGrouped] (NULL , NULL ) WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaysGrouped PaysGrouped = new vwPaysGrouped();

            PaysGrouped.guid = new Guid(dr["guid"].ToString());
            PaysGrouped.paytype = (string)dr["paytype"];
            PaysGrouped.Amount = decimal.Parse(dr["Amount"].ToString());

            lstData.Add(PaysGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwPaysGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM [fnPaysGrouped] (@StartDate , @EndDate )", DBConnect.DBConnection);
        
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);

        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaysGrouped PaysGrouped = new vwPaysGrouped();

            PaysGrouped.guid = new Guid(dr["guid"].ToString());
            PaysGrouped.paytype = (string)dr["paytype"];
            PaysGrouped.Amount = decimal.Parse(dr["Amount"].ToString());

            lstData.Add(PaysGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwPaysGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM [fnPaysGrouped] (NULL , NULL ) WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaysGrouped PaysGrouped = new vwPaysGrouped();

            PaysGrouped.guid = new Guid(dr["guid"].ToString());
            PaysGrouped.paytype = (string)dr["paytype"];
            PaysGrouped.Amount = decimal.Parse(dr["Amount"].ToString());

            lstData.Add(PaysGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwPaysGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM [fnPaysGrouped] (NULL , NULL ) WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaysGrouped PaysGrouped = new vwPaysGrouped();

            PaysGrouped.guid = new Guid(dr["guid"].ToString());
            PaysGrouped.paytype = (string)dr["paytype"];
            PaysGrouped.Amount = decimal.Parse(dr["Amount"].ToString());

            lstData.Add(PaysGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwPaysGrouped FindBy(string dbcolumn, object val)
    {
        vwPaysGrouped PaysGrouped = new vwPaysGrouped();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM [fnPaysGrouped] (NULL , NULL ) WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PaysGrouped.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            PaysGrouped.paytype = (string)DBConnect.DBReader["paytype"];
            PaysGrouped.Amount = decimal.Parse(DBConnect.DBReader["Amount"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PaysGrouped;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwPaysGrouped WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwPaysGrouped", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwPaysGrouped", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwPaysGrouped", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwPaysGrouped WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwPaysGrouped", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtpaytype
TxtAmount


*/