using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwDailySalesGrouped
{

    public static List<vwDailySalesGrouped> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtPayDate")]
    public DateTime PayDate { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtPayDate")]
    public string Land { get; set; }
    [DataGUIAttribute(GUIName = "إجمالي النقدي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtcash")]
    public decimal cash { get; set; }
    [DataGUIAttribute(GUIName = "إجمالي الشبكة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtcash")]
    public decimal network { get; set; }
    [DataGUIAttribute(GUIName = "إجمالي الشيكات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtcash")]
    public decimal chick { get; set; }
    [DataGUIAttribute(GUIName = "إجمالي البنوك", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbank")]
    public decimal bank { get; set; }
    [DataGUIAttribute(GUIName = "الإجمالي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtTotal")]
    public decimal Total { get; set; }

    #endregion


    public static void Fill(string status)
    {
        lstData = new List<vwDailySalesGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM dbo.[fnDailySalesGrouped] ( NULL , NULL , @status ) order by paydate ", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);

        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailySalesGrouped DailySalesGrouped = new vwDailySalesGrouped();

            DailySalesGrouped.PayDate = (DateTime)dr["PayDate"];
            DailySalesGrouped.Land = (string)dr["Land"];
            DailySalesGrouped.cash = decimal.Parse(dr["cash"].ToString());
            DailySalesGrouped.network = decimal.Parse(dr["network"].ToString());
            DailySalesGrouped.chick = decimal.Parse(dr["chick"].ToString());

            DailySalesGrouped.bank = decimal.Parse(dr["bank"].ToString());
            DailySalesGrouped.Total = decimal.Parse(dr["Total"].ToString());

            lstData.Add(DailySalesGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string status, DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwDailySalesGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM dbo.[fnDailySalesGrouped] ( @StartDate , @EndDate , @status ) order by paydate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailySalesGrouped DailySalesGrouped = new vwDailySalesGrouped();

            DailySalesGrouped.PayDate = (DateTime)dr["PayDate"];
            DailySalesGrouped.Land = (string)dr["Land"];
            DailySalesGrouped.cash = decimal.Parse(dr["cash"].ToString());
            DailySalesGrouped.network = decimal.Parse(dr["network"].ToString());
            DailySalesGrouped.chick = decimal.Parse(dr["chick"].ToString());
             DailySalesGrouped.bank = decimal.Parse(dr["bank"].ToString());
            DailySalesGrouped.Total = decimal.Parse(dr["Total"].ToString());


            lstData.Add(DailySalesGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwDailySalesGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwDailySalesGrouped WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailySalesGrouped DailySalesGrouped = new vwDailySalesGrouped();

            DailySalesGrouped.PayDate = (DateTime)dr["PayDate"];
            DailySalesGrouped.Land = (string)dr["Land"];

            DailySalesGrouped.cash = decimal.Parse(dr["cash"].ToString());
            DailySalesGrouped.network = decimal.Parse(dr["network"].ToString());
            DailySalesGrouped.chick = decimal.Parse(dr["chick"].ToString());
            DailySalesGrouped.bank = decimal.Parse(dr["bank"].ToString());
            DailySalesGrouped.Total = decimal.Parse(dr["Total"].ToString());


            lstData.Add(DailySalesGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwDailySalesGrouped>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwDailySalesGrouped WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailySalesGrouped DailySalesGrouped = new vwDailySalesGrouped();

            DailySalesGrouped.PayDate = (DateTime)dr["PayDate"];
            DailySalesGrouped.Land = (string)dr["Land"];
            DailySalesGrouped.cash = decimal.Parse(dr["cash"].ToString());
            DailySalesGrouped.network = decimal.Parse(dr["network"].ToString());
            DailySalesGrouped.chick = decimal.Parse(dr["chick"].ToString());
            DailySalesGrouped.bank = decimal.Parse(dr["bank"].ToString());
            DailySalesGrouped.Total = decimal.Parse(dr["Total"].ToString());


            lstData.Add(DailySalesGrouped);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwDailySalesGrouped FindBy(string dbcolumn, object val)
    {
        vwDailySalesGrouped DailySalesGrouped = new vwDailySalesGrouped();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwDailySalesGrouped WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            DailySalesGrouped.PayDate = (DateTime)DBConnect.DBReader["PayDate"];
            DailySalesGrouped.Land = (string)DBConnect.DBReader["Land"];
            DailySalesGrouped.cash = decimal.Parse(DBConnect.DBReader["cash"].ToString());
            DailySalesGrouped.network = decimal.Parse(DBConnect.DBReader["network"].ToString());
            DailySalesGrouped.chick = decimal.Parse(DBConnect.DBReader["chick"].ToString());
            DailySalesGrouped.bank = decimal.Parse(DBConnect.DBReader["bank"].ToString());
            DailySalesGrouped.Total = decimal.Parse(DBConnect.DBReader["Total"].ToString());


        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return DailySalesGrouped;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwDailySalesGrouped WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwDailySalesGrouped", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwDailySalesGrouped", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwDailySalesGrouped", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwDailySalesGrouped WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwDailySalesGrouped", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtPayDate
Txtcash
Txtbank
TxtTotal


*/