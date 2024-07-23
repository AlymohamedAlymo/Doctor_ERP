using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwGeneralAccountLandSales
{

    public static List<vwGeneralAccountLandSales> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "عدد القطع", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtc")]
    public int c { get; set; }
    [DataGUIAttribute(GUIName = "البيان", Formatting = "", Visibility = true, Width = 100, ControlName = "Txttitle")]
    public string title { get; set; }
    [DataGUIAttribute(GUIName = "نوع الدفعة", Formatting = "", Visibility = true, Width = 100, ControlName = "Txttitle")]
    public string paytype { get; set; }

    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "المدفوع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayments")]
    public decimal payments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwGeneralAccountLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralAccountLandSales", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountLandSales GeneralAccountLandSales = new vwGeneralAccountLandSales();

            GeneralAccountLandSales.guid = new Guid(dr["guid"].ToString());
            GeneralAccountLandSales.c = (int)dr["c"];
            GeneralAccountLandSales.title = (string)dr["title"];
            GeneralAccountLandSales.paytype = (string)dr["paytype"];
            GeneralAccountLandSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralAccountLandSales.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountLandSales.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountLandSales);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwGeneralAccountLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralAccountLandSales WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountLandSales GeneralAccountLandSales = new vwGeneralAccountLandSales();

            GeneralAccountLandSales.guid = new Guid(dr["guid"].ToString());
            GeneralAccountLandSales.c = (int)dr["c"];
            GeneralAccountLandSales.title = (string)dr["title"];
            GeneralAccountLandSales.paytype = (string)dr["paytype"];
            GeneralAccountLandSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralAccountLandSales.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountLandSales.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountLandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwGeneralAccountLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralAccountLandSales WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountLandSales GeneralAccountLandSales = new vwGeneralAccountLandSales();

            GeneralAccountLandSales.guid = new Guid(dr["guid"].ToString());
            GeneralAccountLandSales.c = (int)dr["c"];
            GeneralAccountLandSales.title = (string)dr["title"];
            GeneralAccountLandSales.paytype = (string)dr["paytype"];
            GeneralAccountLandSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralAccountLandSales.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountLandSales.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountLandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwGeneralAccountLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralAccountLandSales WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralAccountLandSales GeneralAccountLandSales = new vwGeneralAccountLandSales();

            GeneralAccountLandSales.guid = new Guid(dr["guid"].ToString());
            GeneralAccountLandSales.c = (int)dr["c"];
            GeneralAccountLandSales.title = (string)dr["title"];
            GeneralAccountLandSales.paytype = (string)dr["paytype"];
            GeneralAccountLandSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralAccountLandSales.payments = decimal.Parse(dr["payments"].ToString());
            GeneralAccountLandSales.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(GeneralAccountLandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwGeneralAccountLandSales FindBy(string dbcolumn, object val)
    {
        vwGeneralAccountLandSales GeneralAccountLandSales = new vwGeneralAccountLandSales();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralAccountLandSales WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            GeneralAccountLandSales.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            GeneralAccountLandSales.c = (int)DBConnect.DBReader["c"];
            GeneralAccountLandSales.title = (string)DBConnect.DBReader["title"];
            GeneralAccountLandSales.paytype = (string)DBConnect.DBReader["paytype"];
            GeneralAccountLandSales.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            GeneralAccountLandSales.payments = decimal.Parse(DBConnect.DBReader["payments"].ToString());
            GeneralAccountLandSales.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return GeneralAccountLandSales;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwGeneralAccountLandSales WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwGeneralAccountLandSales", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGeneralAccountLandSales", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwGeneralAccountLandSales", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwGeneralAccountLandSales WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGeneralAccountLandSales", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtc
Txttitle
Txttotalnet
Txtpayments
Txtremain


*/