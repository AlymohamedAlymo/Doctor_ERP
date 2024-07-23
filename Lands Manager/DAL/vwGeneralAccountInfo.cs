using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwGeneralAccountInfo
{

    public static List<vwGeneralAccountInfo> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "totalsales", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalsales")]
    public decimal totalsales { get; set; }
    [DataGUIAttribute(GUIName = "payments", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayments")]
    public decimal payments { get; set; }
    [DataGUIAttribute(GUIName = "remain", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwGeneralAccountInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralAccountInfo", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        vwGeneralAccountInfo GeneralAccountInfo = new vwGeneralAccountInfo();

        foreach (DataRow dr in dtData.Rows)
        {

            GeneralAccountInfo.totalsales += decimal.Parse(dr["totalsales"].ToString());
            GeneralAccountInfo.payments += decimal.Parse(dr["payments"].ToString());
            GeneralAccountInfo.remain += decimal.Parse(dr["remain"].ToString());

        }
        lstData.Add(GeneralAccountInfo);

    }
    public static void Fill(Guid guid)
    {
        lstData = new List<vwGeneralAccountInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralAccountInfo WHERE totalsales = @totalsales", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountInfo GeneralAccountInfo = new vwGeneralAccountInfo();

            GeneralAccountInfo.totalsales = decimal.Parse(dr["totalsales"].ToString());
            GeneralAccountInfo.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountInfo.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwGeneralAccountInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralAccountInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountInfo GeneralAccountInfo = new vwGeneralAccountInfo();

            GeneralAccountInfo.totalsales = decimal.Parse(dr["totalsales"].ToString());
            GeneralAccountInfo.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountInfo.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwGeneralAccountInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralAccountInfo WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountInfo GeneralAccountInfo = new vwGeneralAccountInfo();

            GeneralAccountInfo.totalsales = decimal.Parse(dr["totalsales"].ToString());
            GeneralAccountInfo.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountInfo.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwGeneralAccountInfo FindBy(string dbcolumn, object val)
    {
        vwGeneralAccountInfo GeneralAccountInfo = new vwGeneralAccountInfo();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralAccountInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            GeneralAccountInfo.totalsales = decimal.Parse(DBConnect.DBReader["totalsales"].ToString());
            GeneralAccountInfo.payments = decimal.Parse(DBConnect.DBReader["payments"].ToString());
            GeneralAccountInfo.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return GeneralAccountInfo;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwGeneralAccountInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwGeneralAccountInfo", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGeneralAccountInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwGeneralAccountInfo", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwGeneralAccountInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGeneralAccountInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txttotalsales
Txtpayments
Txtremain


*/