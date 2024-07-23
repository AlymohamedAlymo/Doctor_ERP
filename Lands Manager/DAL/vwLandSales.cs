using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwLandSales
{

    public static List<vwLandSales> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "القيمة الدفترية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "صافي القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal netprice { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "المدفوع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayments")]
    public decimal payments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "العميل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandSales", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandSales LandSales = new vwLandSales();

            LandSales.guid = new Guid(dr["guid"].ToString());
            LandSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            LandSales.regdate = (DateTime)dr["regdate"];
            LandSales.code = (int)dr["code"];
            LandSales.blocknumber = (string)dr["blocknumber"];
            LandSales.number = (int)dr["number"];
            LandSales.land = (string)dr["land"];
            LandSales.price = decimal.Parse(dr["price"].ToString());
            LandSales.netprice = decimal.Parse(dr["netprice"].ToString());
            LandSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandSales.payments = decimal.Parse(dr["payments"].ToString());
            LandSales.remain = decimal.Parse(dr["remain"].ToString());
            LandSales.agent = (string)dr["agent"];
            LandSales.mobile = (string)dr["mobile"];

            lstData.Add(LandSales);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandSales WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandSales LandSales = new vwLandSales();

            LandSales.guid = new Guid(dr["guid"].ToString());
            LandSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            LandSales.regdate = (DateTime)dr["regdate"];
            LandSales.code = (int)dr["code"];
            LandSales.blocknumber = (string)dr["blocknumber"];
            LandSales.number = (int)dr["number"];
            LandSales.land = (string)dr["land"];
            LandSales.price = decimal.Parse(dr["price"].ToString());
            LandSales.netprice = decimal.Parse(dr["netprice"].ToString());
            LandSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandSales.payments = decimal.Parse(dr["payments"].ToString());
            LandSales.remain = decimal.Parse(dr["remain"].ToString());
            LandSales.agent = (string)dr["agent"];
            LandSales.mobile = (string)dr["mobile"];

            lstData.Add(LandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandSales WHERE regdate >= @StartDate AND regdate <= @EndDate order by number", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandSales LandSales = new vwLandSales();

            LandSales.guid = new Guid(dr["guid"].ToString());
            LandSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            LandSales.regdate = (DateTime)dr["regdate"];
            LandSales.code = (int)dr["code"];
            LandSales.blocknumber = (string)dr["blocknumber"];
            LandSales.number = (int)dr["number"];
            LandSales.land = (string)dr["land"];
            LandSales.price = decimal.Parse(dr["price"].ToString());
            LandSales.netprice = decimal.Parse(dr["netprice"].ToString());
            LandSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandSales.payments = decimal.Parse(dr["payments"].ToString());
            LandSales.remain = decimal.Parse(dr["remain"].ToString());
            LandSales.agent = (string)dr["agent"];
            LandSales.mobile = (string)dr["mobile"];

            lstData.Add(LandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandSales WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandSales LandSales = new vwLandSales();

            LandSales.guid = new Guid(dr["guid"].ToString());
            LandSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            LandSales.regdate = (DateTime)dr["regdate"];
            LandSales.code = (int)dr["code"];
            LandSales.blocknumber = (string)dr["blocknumber"];
            LandSales.number = (int)dr["number"];
            LandSales.land = (string)dr["land"];
            LandSales.price = decimal.Parse(dr["price"].ToString());
            LandSales.netprice = decimal.Parse(dr["netprice"].ToString());
            LandSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandSales.payments = decimal.Parse(dr["payments"].ToString());
            LandSales.remain = decimal.Parse(dr["remain"].ToString());
            LandSales.agent = (string)dr["agent"];
            LandSales.mobile = (string)dr["mobile"];

            lstData.Add(LandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLandSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandSales WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandSales LandSales = new vwLandSales();

            LandSales.guid = new Guid(dr["guid"].ToString());
            LandSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            LandSales.regdate = (DateTime)dr["regdate"];
            LandSales.code = (int)dr["code"];
            LandSales.blocknumber = (string)dr["blocknumber"];
            LandSales.number = (int)dr["number"];
            LandSales.land = (string)dr["land"];
            LandSales.price = decimal.Parse(dr["price"].ToString());
            LandSales.netprice = decimal.Parse(dr["netprice"].ToString());
            LandSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandSales.payments = decimal.Parse(dr["payments"].ToString());
            LandSales.remain = decimal.Parse(dr["remain"].ToString());
            LandSales.agent = (string)dr["agent"];
            LandSales.mobile = (string)dr["mobile"];

            lstData.Add(LandSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwLandSales FindBy(string dbcolumn, object val)
    {
        vwLandSales LandSales = new vwLandSales();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandSales WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandSales.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandSales.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            LandSales.regdate = (DateTime)DBConnect.DBReader["regdate"];
            LandSales.code = (int)DBConnect.DBReader["code"];
            LandSales.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            LandSales.number = (int)DBConnect.DBReader["number"];
            LandSales.land = (string)DBConnect.DBReader["land"];
            LandSales.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            LandSales.netprice = decimal.Parse(DBConnect.DBReader["netprice"].ToString());
            LandSales.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            LandSales.payments = decimal.Parse(DBConnect.DBReader["payments"].ToString());
            LandSales.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            LandSales.agent = (string)DBConnect.DBReader["agent"];
            LandSales.mobile = (string)DBConnect.DBReader["mobile"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandSales;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwLandSales WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwLandSales", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandSales", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwLandSales", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwLandSales WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandSales", DBConnect.DBConnection);
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
Txtpayments
Txtremain
Txtagent
Txtmobile


*/