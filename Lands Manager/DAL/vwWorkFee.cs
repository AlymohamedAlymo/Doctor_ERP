using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwWorkFee
{

    public static List<vwWorkFee> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "code", Formatting = "N0", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "blocknumber", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = false, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "المدفوع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPayments")]
    public decimal Payments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "vatid", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtvatid")]
    public string vatid { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwWorkFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwWorkFee", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFee WorkFee = new vwWorkFee();

            WorkFee.guid = new Guid(dr["guid"].ToString());
            WorkFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFee.regdate = (DateTime)dr["regdate"];
            WorkFee.code = (int)dr["code"];
            WorkFee.blocknumber = (string)dr["blocknumber"];
            WorkFee.number = (int)dr["number"];
            WorkFee.land = (string)dr["land"];
            WorkFee.price = decimal.Parse(dr["price"].ToString());
            WorkFee.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFee.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFee.remain = decimal.Parse(dr["remain"].ToString());
            WorkFee.agent = (string)dr["agent"];
            WorkFee.mobile = (string)dr["mobile"];
            WorkFee.vatid = (string)dr["vatid"];

            lstData.Add(WorkFee);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwWorkFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwWorkFee WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFee WorkFee = new vwWorkFee();

            WorkFee.guid = new Guid(dr["guid"].ToString());
            WorkFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFee.regdate = (DateTime)dr["regdate"];
            WorkFee.code = (int)dr["code"];
            WorkFee.blocknumber = (string)dr["blocknumber"];
            WorkFee.number = (int)dr["number"];
            WorkFee.land = (string)dr["land"];
            WorkFee.price = decimal.Parse(dr["price"].ToString());
            WorkFee.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFee.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFee.remain = decimal.Parse(dr["remain"].ToString());
            WorkFee.agent = (string)dr["agent"];
            WorkFee.mobile = (string)dr["mobile"];
            WorkFee.vatid = (string)dr["vatid"];

            lstData.Add(WorkFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwWorkFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwWorkFee WHERE regdate >= @StartDate AND regdate <= @EndDate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFee WorkFee = new vwWorkFee();

            WorkFee.guid = new Guid(dr["guid"].ToString());
            WorkFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFee.regdate = (DateTime)dr["regdate"];
            WorkFee.code = (int)dr["code"];
            WorkFee.blocknumber = (string)dr["blocknumber"];
            WorkFee.number = (int)dr["number"];
            WorkFee.land = (string)dr["land"];
            WorkFee.price = decimal.Parse(dr["price"].ToString());
            WorkFee.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFee.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFee.remain = decimal.Parse(dr["remain"].ToString());
            WorkFee.agent = (string)dr["agent"];
            WorkFee.mobile = (string)dr["mobile"];
            WorkFee.vatid = (string)dr["vatid"];

            lstData.Add(WorkFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwWorkFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwWorkFee WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFee WorkFee = new vwWorkFee();

            WorkFee.guid = new Guid(dr["guid"].ToString());
            WorkFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFee.regdate = (DateTime)dr["regdate"];
            WorkFee.code = (int)dr["code"];
            WorkFee.blocknumber = (string)dr["blocknumber"];
            WorkFee.number = (int)dr["number"];
            WorkFee.land = (string)dr["land"];
            WorkFee.price = decimal.Parse(dr["price"].ToString());
            WorkFee.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFee.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFee.remain = decimal.Parse(dr["remain"].ToString());
            WorkFee.agent = (string)dr["agent"];
            WorkFee.mobile = (string)dr["mobile"];
            WorkFee.vatid = (string)dr["vatid"];

            lstData.Add(WorkFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwWorkFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwWorkFee WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFee WorkFee = new vwWorkFee();

            WorkFee.guid = new Guid(dr["guid"].ToString());
            WorkFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFee.regdate = (DateTime)dr["regdate"];
            WorkFee.code = (int)dr["code"];
            WorkFee.blocknumber = (string)dr["blocknumber"];
            WorkFee.number = (int)dr["number"];
            WorkFee.land = (string)dr["land"];
            WorkFee.price = decimal.Parse(dr["price"].ToString());
            WorkFee.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFee.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFee.remain = decimal.Parse(dr["remain"].ToString());
            WorkFee.agent = (string)dr["agent"];
            WorkFee.mobile = (string)dr["mobile"];
            WorkFee.vatid = (string)dr["vatid"];

            lstData.Add(WorkFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwWorkFee FindBy(string dbcolumn, object val)
    {
        vwWorkFee WorkFee = new vwWorkFee();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwWorkFee WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            WorkFee.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            WorkFee.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            WorkFee.regdate = (DateTime)DBConnect.DBReader["regdate"];
            WorkFee.code = (int)DBConnect.DBReader["code"];
            WorkFee.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            WorkFee.number = (int)DBConnect.DBReader["number"];
            WorkFee.land = (string)DBConnect.DBReader["land"];
            WorkFee.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            WorkFee.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            WorkFee.Payments = decimal.Parse(DBConnect.DBReader["Payments"].ToString());
            WorkFee.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            WorkFee.agent = (string)DBConnect.DBReader["agent"];
            WorkFee.mobile = (string)DBConnect.DBReader["mobile"];
            WorkFee.vatid = (string)DBConnect.DBReader["vatid"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return WorkFee;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwWorkFee WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwWorkFee", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwWorkFee", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwWorkFee", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwWorkFee WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwWorkFee", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtcode
Txtblocknumber
Txtnumber
Txtland
Txtprice
Txtworkfeevalue
TxtPayments
Txtremain
Txtagent
Txtmobile
Txtvatid


*/