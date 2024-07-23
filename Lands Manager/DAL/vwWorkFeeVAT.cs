using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwWorkFeeVat
{

    public static List<vwWorkFeeVat> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = false, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "قيمة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvatvalue")]
    public decimal vatvalue { get; set; }
    [DataGUIAttribute(GUIName = "Payments", Formatting = "N2", Visibility = false, Width = 100, ControlName = "TxtPayments")]
    public decimal Payments { get; set; }
    [DataGUIAttribute(GUIName = "remain", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "الرقم الضريبي", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtvatid")]
    public string vatid { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwWorkFeeVat>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwWorkFeeVat", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFeeVat WorkFeeVat = new vwWorkFeeVat();

            WorkFeeVat.guid = new Guid(dr["guid"].ToString());
            WorkFeeVat.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFeeVat.regdate = (DateTime)dr["regdate"];
            WorkFeeVat.code = (int)dr["code"];
            WorkFeeVat.blocknumber = (string)dr["blocknumber"];
            WorkFeeVat.number = (int)dr["number"];
            WorkFeeVat.land = (string)dr["land"];
            WorkFeeVat.price = decimal.Parse(dr["price"].ToString());
            WorkFeeVat.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFeeVat.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            WorkFeeVat.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFeeVat.remain = decimal.Parse(dr["remain"].ToString());
            WorkFeeVat.agent = (string)dr["agent"];
            WorkFeeVat.mobile = (string)dr["mobile"];
            WorkFeeVat.vatid = (string)dr["vatid"];

            lstData.Add(WorkFeeVat);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwWorkFeeVat>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwWorkFeeVat WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFeeVat WorkFeeVat = new vwWorkFeeVat();

            WorkFeeVat.guid = new Guid(dr["guid"].ToString());
            WorkFeeVat.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFeeVat.regdate = (DateTime)dr["regdate"];
            WorkFeeVat.code = (int)dr["code"];
            WorkFeeVat.blocknumber = (string)dr["blocknumber"];
            WorkFeeVat.number = (int)dr["number"];
            WorkFeeVat.land = (string)dr["land"];
            WorkFeeVat.price = decimal.Parse(dr["price"].ToString());
            WorkFeeVat.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFeeVat.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            WorkFeeVat.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFeeVat.remain = decimal.Parse(dr["remain"].ToString());
            WorkFeeVat.agent = (string)dr["agent"];
            WorkFeeVat.mobile = (string)dr["mobile"];
            WorkFeeVat.vatid = (string)dr["vatid"];

            lstData.Add(WorkFeeVat);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(DateTime StartDate , DateTime EndDate)
    {
        lstData = new List<vwWorkFeeVat>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwWorkFeeVat WHERE regdate >= @StartDate AND regdate <= @EndDate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFeeVat WorkFeeVat = new vwWorkFeeVat();

            WorkFeeVat.guid = new Guid(dr["guid"].ToString());
            WorkFeeVat.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFeeVat.regdate = (DateTime)dr["regdate"];
            WorkFeeVat.code = (int)dr["code"];
            WorkFeeVat.blocknumber = (string)dr["blocknumber"];
            WorkFeeVat.number = (int)dr["number"];
            WorkFeeVat.land = (string)dr["land"];
            WorkFeeVat.price = decimal.Parse(dr["price"].ToString());
            WorkFeeVat.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFeeVat.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            WorkFeeVat.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFeeVat.remain = decimal.Parse(dr["remain"].ToString());
            WorkFeeVat.agent = (string)dr["agent"];
            WorkFeeVat.mobile = (string)dr["mobile"];
            WorkFeeVat.vatid = (string)dr["vatid"];

            lstData.Add(WorkFeeVat);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwWorkFeeVat>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwWorkFeeVat WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFeeVat WorkFeeVat = new vwWorkFeeVat();

            WorkFeeVat.guid = new Guid(dr["guid"].ToString());
            WorkFeeVat.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFeeVat.regdate = (DateTime)dr["regdate"];
            WorkFeeVat.code = (int)dr["code"];
            WorkFeeVat.blocknumber = (string)dr["blocknumber"];
            WorkFeeVat.number = (int)dr["number"];
            WorkFeeVat.land = (string)dr["land"];
            WorkFeeVat.price = decimal.Parse(dr["price"].ToString());
            WorkFeeVat.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFeeVat.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            WorkFeeVat.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFeeVat.remain = decimal.Parse(dr["remain"].ToString());
            WorkFeeVat.agent = (string)dr["agent"];
            WorkFeeVat.mobile = (string)dr["mobile"];
            WorkFeeVat.vatid = (string)dr["vatid"];

            lstData.Add(WorkFeeVat);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwWorkFeeVat>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwWorkFeeVat WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwWorkFeeVat WorkFeeVat = new vwWorkFeeVat();

            WorkFeeVat.guid = new Guid(dr["guid"].ToString());
            WorkFeeVat.buyerguid = new Guid(dr["buyerguid"].ToString());
            WorkFeeVat.regdate = (DateTime)dr["regdate"];
            WorkFeeVat.code = (int)dr["code"];
            WorkFeeVat.blocknumber = (string)dr["blocknumber"];
            WorkFeeVat.number = (int)dr["number"];
            WorkFeeVat.land = (string)dr["land"];
            WorkFeeVat.price = decimal.Parse(dr["price"].ToString());
            WorkFeeVat.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            WorkFeeVat.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            WorkFeeVat.Payments = decimal.Parse(dr["Payments"].ToString());
            WorkFeeVat.remain = decimal.Parse(dr["remain"].ToString());
            WorkFeeVat.agent = (string)dr["agent"];
            WorkFeeVat.mobile = (string)dr["mobile"];
            WorkFeeVat.vatid = (string)dr["vatid"];

            lstData.Add(WorkFeeVat);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwWorkFeeVat FindBy(string dbcolumn, object val)
    {
        vwWorkFeeVat WorkFeeVat = new vwWorkFeeVat();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwWorkFeeVat WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            WorkFeeVat.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            WorkFeeVat.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            WorkFeeVat.regdate = (DateTime)DBConnect.DBReader["regdate"];
            WorkFeeVat.code = (int)DBConnect.DBReader["code"];
            WorkFeeVat.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            WorkFeeVat.number = (int)DBConnect.DBReader["number"];
            WorkFeeVat.land = (string)DBConnect.DBReader["land"];
            WorkFeeVat.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            WorkFeeVat.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            WorkFeeVat.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            WorkFeeVat.Payments = decimal.Parse(DBConnect.DBReader["Payments"].ToString());
            WorkFeeVat.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            WorkFeeVat.agent = (string)DBConnect.DBReader["agent"];
            WorkFeeVat.mobile = (string)DBConnect.DBReader["mobile"];
            WorkFeeVat.vatid = (string)DBConnect.DBReader["vatid"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return WorkFeeVat;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwWorkFeeVat WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwWorkFeeVat", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwWorkFeeVat", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwWorkFeeVat", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwWorkFeeVat WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwWorkFeeVat", DBConnect.DBConnection);
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
Txtvatvalue
TxtPayments
Txtremain
Txtagent
Txtmobile
Txtvatid


*/