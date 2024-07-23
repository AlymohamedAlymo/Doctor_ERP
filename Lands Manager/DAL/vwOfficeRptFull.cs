using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwOfficeRptFull
{

    public static List<vwOfficeRptFull> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "code", Formatting = "N0", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = false, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "القيمة الدفترية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "الحسم", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotalvalue")]
    public decimal discounttotalvalue { get; set; }
    [DataGUIAttribute(GUIName = "صافي القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnetprice")]
    public decimal netprice { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "حسم العمولة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfeevalue")]
    public decimal discountfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "صافي عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnetworkfeevalue")]
    public decimal networkfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "الواصل", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPayments")]
    public decimal Payments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "الواصل من قيمة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPayments")]
    public decimal LandPayments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي من قيمة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal Landremain { get; set; }
    [DataGUIAttribute(GUIName = "الواصل من سعي عمولة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPayments")]
    public decimal feePayments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي من سعي عمولة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal feeremain { get; set; }
    [DataGUIAttribute(GUIName = "الواصل من ضريبة عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPayments")]
    public decimal vatPayments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي من ضريبة عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal vatremain { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvatvalue")]
    public decimal vatvalue { get; set; }
    [DataGUIAttribute(GUIName = "اسم العميل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwOfficeRptFull>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwOfficeRptFull", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwOfficeRptFull OfficeRptFull = new vwOfficeRptFull();

            OfficeRptFull.guid = new Guid(dr["guid"].ToString());
            OfficeRptFull.buyerguid = new Guid(dr["buyerguid"].ToString());
            OfficeRptFull.regdate = (DateTime)dr["regdate"];
            OfficeRptFull.contractno = (int)dr["contractno"];
            OfficeRptFull.code = (int)dr["code"];
            OfficeRptFull.number = (int)dr["number"];
            OfficeRptFull.land = (string)dr["land"];
            OfficeRptFull.price = decimal.Parse(dr["price"].ToString());
            OfficeRptFull.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            OfficeRptFull.netprice = decimal.Parse(dr["netprice"].ToString());
            OfficeRptFull.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            OfficeRptFull.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            OfficeRptFull.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            OfficeRptFull.Payments = decimal.Parse(dr["Payments"].ToString());
            OfficeRptFull.remain = decimal.Parse(dr["remain"].ToString());
            OfficeRptFull.LandPayments = decimal.Parse(dr["LandPayments"].ToString());
            OfficeRptFull.Landremain = decimal.Parse(dr["Landremain"].ToString());
            OfficeRptFull.feePayments = decimal.Parse(dr["feePayments"].ToString());
            OfficeRptFull.feeremain = decimal.Parse(dr["feeremain"].ToString());
            OfficeRptFull.vatPayments = decimal.Parse(dr["vatPayments"].ToString());
            OfficeRptFull.vatremain = decimal.Parse(dr["vatremain"].ToString());
            OfficeRptFull.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            OfficeRptFull.agent = (string)dr["agent"];
            OfficeRptFull.mobile = (string)dr["mobile"];

            lstData.Add(OfficeRptFull);
        }
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwOfficeRptFull>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwOfficeRptFull WHERE regdate >= @StartDate AND regdate <= @EndDate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwOfficeRptFull OfficeRptFull = new vwOfficeRptFull();

            OfficeRptFull.guid = new Guid(dr["guid"].ToString());
            OfficeRptFull.buyerguid = new Guid(dr["buyerguid"].ToString());
            OfficeRptFull.regdate = (DateTime)dr["regdate"];
            OfficeRptFull.contractno = (int)dr["contractno"];
            OfficeRptFull.code = (int)dr["code"];
            OfficeRptFull.number = (int)dr["number"];
            OfficeRptFull.land = (string)dr["land"];
            OfficeRptFull.price = decimal.Parse(dr["price"].ToString());
            OfficeRptFull.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            OfficeRptFull.netprice = decimal.Parse(dr["netprice"].ToString());
            OfficeRptFull.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            OfficeRptFull.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            OfficeRptFull.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            OfficeRptFull.Payments = decimal.Parse(dr["Payments"].ToString());
            OfficeRptFull.remain = decimal.Parse(dr["remain"].ToString());
            OfficeRptFull.LandPayments = decimal.Parse(dr["LandPayments"].ToString());
            OfficeRptFull.Landremain = decimal.Parse(dr["Landremain"].ToString());
            OfficeRptFull.feePayments = decimal.Parse(dr["feePayments"].ToString());
            OfficeRptFull.feeremain = decimal.Parse(dr["feeremain"].ToString());
            OfficeRptFull.vatPayments = decimal.Parse(dr["vatPayments"].ToString());
            OfficeRptFull.vatremain = decimal.Parse(dr["vatremain"].ToString());
            OfficeRptFull.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            OfficeRptFull.agent = (string)dr["agent"];
            OfficeRptFull.mobile = (string)dr["mobile"];

            lstData.Add(OfficeRptFull);
        }

        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwOfficeRptFull>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwOfficeRptFull WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwOfficeRptFull OfficeRptFull = new vwOfficeRptFull();

            OfficeRptFull.guid = new Guid(dr["guid"].ToString());
            OfficeRptFull.buyerguid = new Guid(dr["buyerguid"].ToString());
            OfficeRptFull.regdate = (DateTime)dr["regdate"];
            OfficeRptFull.contractno = (int)dr["contractno"];
            OfficeRptFull.code = (int)dr["code"];
            OfficeRptFull.number = (int)dr["number"];
            OfficeRptFull.land = (string)dr["land"];
            OfficeRptFull.price = decimal.Parse(dr["price"].ToString());
            OfficeRptFull.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            OfficeRptFull.netprice = decimal.Parse(dr["netprice"].ToString());
            OfficeRptFull.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            OfficeRptFull.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            OfficeRptFull.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            OfficeRptFull.Payments = decimal.Parse(dr["Payments"].ToString());
            OfficeRptFull.remain = decimal.Parse(dr["remain"].ToString());
            OfficeRptFull.LandPayments = decimal.Parse(dr["LandPayments"].ToString());
            OfficeRptFull.Landremain = decimal.Parse(dr["Landremain"].ToString());
            OfficeRptFull.feePayments = decimal.Parse(dr["feePayments"].ToString());
            OfficeRptFull.feeremain = decimal.Parse(dr["feeremain"].ToString());
            OfficeRptFull.vatPayments = decimal.Parse(dr["vatPayments"].ToString());
            OfficeRptFull.vatremain = decimal.Parse(dr["vatremain"].ToString());
            OfficeRptFull.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            OfficeRptFull.agent = (string)dr["agent"];
            OfficeRptFull.mobile = (string)dr["mobile"];

            lstData.Add(OfficeRptFull);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwOfficeRptFull>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwOfficeRptFull WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwOfficeRptFull OfficeRptFull = new vwOfficeRptFull();

            OfficeRptFull.guid = new Guid(dr["guid"].ToString());
            OfficeRptFull.buyerguid = new Guid(dr["buyerguid"].ToString());
            OfficeRptFull.regdate = (DateTime)dr["regdate"];
            OfficeRptFull.contractno = (int)dr["contractno"];
            OfficeRptFull.code = (int)dr["code"];
            OfficeRptFull.number = (int)dr["number"];
            OfficeRptFull.land = (string)dr["land"];
            OfficeRptFull.price = decimal.Parse(dr["price"].ToString());
            OfficeRptFull.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            OfficeRptFull.netprice = decimal.Parse(dr["netprice"].ToString());
            OfficeRptFull.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            OfficeRptFull.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            OfficeRptFull.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            OfficeRptFull.Payments = decimal.Parse(dr["Payments"].ToString());
            OfficeRptFull.remain = decimal.Parse(dr["remain"].ToString());
            OfficeRptFull.LandPayments = decimal.Parse(dr["LandPayments"].ToString());
            OfficeRptFull.Landremain = decimal.Parse(dr["Landremain"].ToString());
            OfficeRptFull.feePayments = decimal.Parse(dr["feePayments"].ToString());
            OfficeRptFull.feeremain = decimal.Parse(dr["feeremain"].ToString());
            OfficeRptFull.vatPayments = decimal.Parse(dr["vatPayments"].ToString());
            OfficeRptFull.vatremain = decimal.Parse(dr["vatremain"].ToString());
            OfficeRptFull.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            OfficeRptFull.agent = (string)dr["agent"];
            OfficeRptFull.mobile = (string)dr["mobile"];

            lstData.Add(OfficeRptFull);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwOfficeRptFull>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwOfficeRptFull WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwOfficeRptFull OfficeRptFull = new vwOfficeRptFull();

            OfficeRptFull.guid = new Guid(dr["guid"].ToString());
            OfficeRptFull.buyerguid = new Guid(dr["buyerguid"].ToString());
            OfficeRptFull.regdate = (DateTime)dr["regdate"];
            OfficeRptFull.contractno = (int)dr["contractno"];
            OfficeRptFull.code = (int)dr["code"];
            OfficeRptFull.number = (int)dr["number"];
            OfficeRptFull.land = (string)dr["land"];
            OfficeRptFull.price = decimal.Parse(dr["price"].ToString());
            OfficeRptFull.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            OfficeRptFull.netprice = decimal.Parse(dr["netprice"].ToString());
            OfficeRptFull.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            OfficeRptFull.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            OfficeRptFull.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            OfficeRptFull.Payments = decimal.Parse(dr["Payments"].ToString());
            OfficeRptFull.remain = decimal.Parse(dr["remain"].ToString());
            OfficeRptFull.LandPayments = decimal.Parse(dr["LandPayments"].ToString());
            OfficeRptFull.Landremain = decimal.Parse(dr["Landremain"].ToString());
            OfficeRptFull.feePayments = decimal.Parse(dr["feePayments"].ToString());
            OfficeRptFull.feeremain = decimal.Parse(dr["feeremain"].ToString());
            OfficeRptFull.vatPayments = decimal.Parse(dr["vatPayments"].ToString());
            OfficeRptFull.vatremain = decimal.Parse(dr["vatremain"].ToString());
            OfficeRptFull.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            OfficeRptFull.agent = (string)dr["agent"];
            OfficeRptFull.mobile = (string)dr["mobile"];

            lstData.Add(OfficeRptFull);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwOfficeRptFull FindBy(string dbcolumn, object val)
    {
        vwOfficeRptFull OfficeRptFull = new vwOfficeRptFull();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwOfficeRptFull WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            OfficeRptFull.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            OfficeRptFull.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            OfficeRptFull.regdate = (DateTime)DBConnect.DBReader["regdate"];
            OfficeRptFull.contractno = (int)DBConnect.DBReader["contractno"];
            OfficeRptFull.code = (int)DBConnect.DBReader["code"];
            OfficeRptFull.number = (int)DBConnect.DBReader["number"];
            OfficeRptFull.land = (string)DBConnect.DBReader["land"];
            OfficeRptFull.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            OfficeRptFull.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            OfficeRptFull.netprice = decimal.Parse(DBConnect.DBReader["netprice"].ToString());
            OfficeRptFull.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            OfficeRptFull.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());
            OfficeRptFull.networkfeevalue = decimal.Parse(DBConnect.DBReader["networkfeevalue"].ToString());
            OfficeRptFull.Payments = decimal.Parse(DBConnect.DBReader["Payments"].ToString());
            OfficeRptFull.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            OfficeRptFull.LandPayments = decimal.Parse(DBConnect.DBReader["LandPayments"].ToString());
            OfficeRptFull.Landremain = decimal.Parse(DBConnect.DBReader["Landremain"].ToString());
            OfficeRptFull.feePayments = decimal.Parse(DBConnect.DBReader["feePayments"].ToString());
            OfficeRptFull.feeremain = decimal.Parse(DBConnect.DBReader["feeremain"].ToString());
            OfficeRptFull.vatPayments = decimal.Parse(DBConnect.DBReader["vatPayments"].ToString());
            OfficeRptFull.vatremain = decimal.Parse(DBConnect.DBReader["vatremain"].ToString());
            OfficeRptFull.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            OfficeRptFull.agent = (string)DBConnect.DBReader["agent"];
            OfficeRptFull.mobile = (string)DBConnect.DBReader["mobile"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return OfficeRptFull;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwOfficeRptFull WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwOfficeRptFull", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwOfficeRptFull", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwOfficeRptFull", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwOfficeRptFull WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwOfficeRptFull", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtcontractno
Txtcode
Txtnumber
Txtland
Txtprice
Txtdiscounttotalvalue
Txtnetprice
Txtworkfeevalue
Txtdiscountfeevalue
Txtnetworkfeevalue
TxtPayments
Txtremain
Txtvatvalue
Txtagent
Txtmobile


*/