using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

public class vwAccountBalance
{

    public static List<vwAccountBalance> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الحساب", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "المقبوضات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamountin")]
    public decimal amountin { get; set; }
    [DataGUIAttribute(GUIName = "المدفوعات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamountout")]
    public decimal amountout { get; set; }
    [DataGUIAttribute(GUIName = "الرصيد", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbalance")]
    public decimal balance { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwAccountBalance>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM [dbo].[fnAccountBalance] (NULL , NULL)", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountBalance AccountBalance = new vwAccountBalance();

            AccountBalance.guid = new Guid(dr["guid"].ToString());
            AccountBalance.number = (int)dr["number"];
            AccountBalance.name = (string)dr["name"];
            AccountBalance.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountBalance.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountBalance.balance  = decimal.Parse(dr["balance"].ToString());

            lstData.Add(AccountBalance);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwAccountBalance>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM [dbo].[fnAccountBalance] (NULL , NULL) WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountBalance AccountBalance = new vwAccountBalance();

            AccountBalance.guid = new Guid(dr["guid"].ToString());
            AccountBalance.number = (int)dr["number"];
            AccountBalance.name = (string)dr["name"];
            AccountBalance.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountBalance.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountBalance.balance = decimal.Parse(dr["balance"].ToString());

            lstData.Add(AccountBalance);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwAccountBalance>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM [dbo].[fnAccountBalance] (@StartDate , @EndDate)", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountBalance AccountBalance = new vwAccountBalance();

            AccountBalance.guid = new Guid(dr["guid"].ToString());
            AccountBalance.number = (int)dr["number"];
            AccountBalance.name = (string)dr["name"];
            AccountBalance.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountBalance.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountBalance.balance = decimal.Parse(dr["balance"].ToString());

            lstData.Add(AccountBalance);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }



    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwAccountBalance>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM [dbo].[fnAccountBalance] (NULL , NULL) WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountBalance AccountBalance = new vwAccountBalance();

            AccountBalance.guid = new Guid(dr["guid"].ToString());
            AccountBalance.number = (int)dr["number"];
            AccountBalance.name = (string)dr["name"];
            AccountBalance.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountBalance.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountBalance.balance = decimal.Parse(dr["balance"].ToString());

            lstData.Add(AccountBalance);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwAccountBalance>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM [dbo].[fnAccountBalance] (NULL , NULL) WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountBalance AccountBalance = new vwAccountBalance();

            AccountBalance.guid = new Guid(dr["guid"].ToString());
            AccountBalance.number = (int)dr["number"];
            AccountBalance.name = (string)dr["name"];
            AccountBalance.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountBalance.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountBalance.balance = decimal.Parse(dr["balance"].ToString());

            lstData.Add(AccountBalance);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwAccountBalance FindBy(string dbcolumn, object val)
    {
        vwAccountBalance AccountBalance = new vwAccountBalance();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM [dbo].[fnAccountBalance] (NULL , NULL) WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            AccountBalance.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            AccountBalance.number = (int)DBConnect.DBReader["number"];
            AccountBalance.name = (string)DBConnect.DBReader["name"];
            AccountBalance.amountin = decimal.Parse(DBConnect.DBReader["amountin"].ToString());
            AccountBalance.amountout = decimal.Parse(DBConnect.DBReader["amountout"].ToString());
            AccountBalance.balance = decimal.Parse(DBConnect.DBReader["balance"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return AccountBalance;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM [dbo].[fnAccountBalance] (NULL , NULL) WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM [dbo].[fnAccountBalance] (NULL , NULL)", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM [dbo].[fnAccountBalance] (NULL , NULL)", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM [dbo].[fnAccountBalance] (NULL , NULL)", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwAccountBalance WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAccountBalance", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtname
Txtamountin
Txtamountout
Txtbalance


*/