using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwAccountStatement
{

    public static List<vwAccountStatement> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "accountguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid accountguid { get; set; }
    [DataGUIAttribute(GUIName = "تاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtpaydate")]
    public DateTime paydate { get; set; }
    [DataGUIAttribute(GUIName = "رقم العملية", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الحساب", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "المقبوضات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamountin")]
    public decimal amountin { get; set; }
    [DataGUIAttribute(GUIName = "المدفوعات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamountout")]
    public decimal amountout { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwAccountStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAccountStatement order by paydate", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountStatement AccountStatement = new vwAccountStatement();

            AccountStatement.guid = new Guid(dr["guid"].ToString());
            AccountStatement.accountguid = new Guid(dr["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)dr["paydate"];
            AccountStatement.number = (int)dr["number"];
            AccountStatement.name = (string)dr["name"];
            AccountStatement.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountStatement.note = (string)dr["note"];

            lstData.Add(AccountStatement);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwAccountStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAccountStatement WHERE guid = @guid ", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountStatement AccountStatement = new vwAccountStatement();

            AccountStatement.guid = new Guid(dr["guid"].ToString());
            AccountStatement.accountguid = new Guid(dr["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)dr["paydate"];
            AccountStatement.number = (int)dr["number"];
            AccountStatement.name = (string)dr["name"];
            AccountStatement.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountStatement.note = (string)dr["note"];

            lstData.Add(AccountStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwAccountStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAccountStatement WHERE {0} = @val order by paydate", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountStatement AccountStatement = new vwAccountStatement();

            AccountStatement.guid = new Guid(dr["guid"].ToString());
            AccountStatement.accountguid = new Guid(dr["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)dr["paydate"];
            AccountStatement.number = (int)dr["number"];
            AccountStatement.name = (string)dr["name"];
            AccountStatement.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountStatement.note = (string)dr["note"];

            lstData.Add(AccountStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(DateTime startdate, DateTime enddate)
    {
        lstData = new List<vwAccountStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAccountStatement WHERE paydate >= @startdate AND paydate <= @enddate order by paydate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@startdate", startdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@enddate", enddate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountStatement AccountStatement = new vwAccountStatement();

            AccountStatement.guid = new Guid(dr["guid"].ToString());
            AccountStatement.accountguid = new Guid(dr["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)dr["paydate"];
            AccountStatement.number = (int)dr["number"];
            AccountStatement.name = (string)dr["name"];
            AccountStatement.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountStatement.note = (string)dr["note"];

            lstData.Add(AccountStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(Guid accountguid, DateTime startdate, DateTime enddate)
    {
        lstData = new List<vwAccountStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAccountStatement WHERE accountguid = @accountguid AND paydate >= @startdate AND paydate <= @enddate order by paydate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@accountguid", accountguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@startdate", startdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@enddate", enddate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountStatement AccountStatement = new vwAccountStatement();

            AccountStatement.guid = new Guid(dr["guid"].ToString());
            AccountStatement.accountguid = new Guid(dr["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)dr["paydate"];
            AccountStatement.number = (int)dr["number"];
            AccountStatement.name = (string)dr["name"];
            AccountStatement.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountStatement.note = (string)dr["note"];

            lstData.Add(AccountStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwAccountStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAccountStatement WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAccountStatement AccountStatement = new vwAccountStatement();

            AccountStatement.guid = new Guid(dr["guid"].ToString());
            AccountStatement.accountguid = new Guid(dr["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)dr["paydate"];
            AccountStatement.number = (int)dr["number"];
            AccountStatement.name = (string)dr["name"];
            AccountStatement.amountin = decimal.Parse(dr["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(dr["amountout"].ToString());
            AccountStatement.note = (string)dr["note"];

            lstData.Add(AccountStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwAccountStatement FindBy(string dbcolumn, object val)
    {
        vwAccountStatement AccountStatement = new vwAccountStatement();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAccountStatement WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            AccountStatement.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            AccountStatement.accountguid = new Guid(DBConnect.DBReader["accountguid"].ToString());
            AccountStatement.paydate = (DateTime)DBConnect.DBReader["paydate"];
            AccountStatement.number = (int)DBConnect.DBReader["number"];
            AccountStatement.name = (string)DBConnect.DBReader["name"];
            AccountStatement.amountin = decimal.Parse(DBConnect.DBReader["amountin"].ToString());
            AccountStatement.amountout = decimal.Parse(DBConnect.DBReader["amountout"].ToString());
            AccountStatement.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return AccountStatement;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwAccountStatement WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwAccountStatement", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAccountStatement", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwAccountStatement", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwAccountStatement WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAccountStatement", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtpaydate
Txtnumber
Txtname
Txtamountin
Txtamountout
Txtnote


*/