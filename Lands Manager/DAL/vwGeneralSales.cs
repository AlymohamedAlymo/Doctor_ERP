using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwGeneralSales
{

    public static List<vwGeneralSales> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "القيمة الدفترية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "صافي القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnetprice")]
    public decimal netprice { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة التصرفات العقارية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfeevalue")]
    public decimal buildingfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "صافي عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnetworkfeevalue")]
    public decimal networkfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvatvalue")]
    public decimal vatvalue { get; set; }
    [DataGUIAttribute(GUIName = "صافي عمولة السعي مع الضريبة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnetworkfeevaluewithvat")]
    public decimal networkfeevaluewithvat { get; set; }
    [DataGUIAttribute(GUIName = "الإجمالي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "لمدفوع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "TxtPayments")]
    public decimal Payments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "الرقم الضريبي", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtvatid")]
    public string vatid { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwGeneralSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralSales", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralSales GeneralSales = new vwGeneralSales();

            GeneralSales.guid = new Guid(dr["guid"].ToString());
            GeneralSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            GeneralSales.regdate = (DateTime)dr["regdate"];
            GeneralSales.contractno = (int)dr["contractno"];
            GeneralSales.code = (int)dr["code"];
            GeneralSales.blocknumber = (string)dr["blocknumber"];
            GeneralSales.number = (int)dr["number"];
            GeneralSales.land = (string)dr["land"];
            GeneralSales.price = decimal.Parse(dr["price"].ToString());
            GeneralSales.netprice = decimal.Parse(dr["netprice"].ToString());
            GeneralSales.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            GeneralSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            GeneralSales.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            GeneralSales.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            GeneralSales.networkfeevaluewithvat = decimal.Parse(dr["networkfeevaluewithvat"].ToString());
            GeneralSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralSales.Payments = decimal.Parse(dr["Payments"].ToString());
            GeneralSales.remain = decimal.Parse(dr["remain"].ToString());
            GeneralSales.agent = (string)dr["agent"];
            GeneralSales.mobile = (string)dr["mobile"];
            GeneralSales.vatid = (string)dr["vatid"];

            lstData.Add(GeneralSales);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwGeneralSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralSales WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralSales GeneralSales = new vwGeneralSales();

            GeneralSales.guid = new Guid(dr["guid"].ToString());
            GeneralSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            GeneralSales.regdate = (DateTime)dr["regdate"];
            GeneralSales.contractno = (int)dr["contractno"];
            GeneralSales.code = (int)dr["code"];
            GeneralSales.blocknumber = (string)dr["blocknumber"];
            GeneralSales.number = (int)dr["number"];
            GeneralSales.land = (string)dr["land"];
            GeneralSales.price = decimal.Parse(dr["price"].ToString());
            GeneralSales.netprice = decimal.Parse(dr["netprice"].ToString());
            GeneralSales.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            GeneralSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            GeneralSales.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            GeneralSales.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            GeneralSales.networkfeevaluewithvat = decimal.Parse(dr["networkfeevaluewithvat"].ToString());
            GeneralSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralSales.Payments = decimal.Parse(dr["Payments"].ToString());
            GeneralSales.remain = decimal.Parse(dr["remain"].ToString());
            GeneralSales.agent = (string)dr["agent"];
            GeneralSales.mobile = (string)dr["mobile"];
            GeneralSales.vatid = (string)dr["vatid"];

            lstData.Add(GeneralSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwGeneralSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGeneralSales WHERE regdate >= @StartDate AND regdate <= @EndDate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralSales GeneralSales = new vwGeneralSales();

            GeneralSales.guid = new Guid(dr["guid"].ToString());
            GeneralSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            GeneralSales.regdate = (DateTime)dr["regdate"];
            GeneralSales.contractno = (int)dr["contractno"];
            GeneralSales.code = (int)dr["code"];
            GeneralSales.blocknumber = (string)dr["blocknumber"];
            GeneralSales.number = (int)dr["number"];
            GeneralSales.land = (string)dr["land"];
            GeneralSales.price = decimal.Parse(dr["price"].ToString());
            GeneralSales.netprice = decimal.Parse(dr["netprice"].ToString());
            GeneralSales.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            GeneralSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            GeneralSales.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            GeneralSales.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            GeneralSales.networkfeevaluewithvat = decimal.Parse(dr["networkfeevaluewithvat"].ToString());
            GeneralSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralSales.Payments = decimal.Parse(dr["Payments"].ToString());
            GeneralSales.remain = decimal.Parse(dr["remain"].ToString());
            GeneralSales.agent = (string)dr["agent"];
            GeneralSales.mobile = (string)dr["mobile"];
            GeneralSales.vatid = (string)dr["vatid"];

            lstData.Add(GeneralSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwGeneralSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralSales WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralSales GeneralSales = new vwGeneralSales();

            GeneralSales.guid = new Guid(dr["guid"].ToString());
            GeneralSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            GeneralSales.regdate = (DateTime)dr["regdate"];
            GeneralSales.contractno = (int)dr["contractno"];
            GeneralSales.code = (int)dr["code"];
            GeneralSales.blocknumber = (string)dr["blocknumber"];
            GeneralSales.number = (int)dr["number"];
            GeneralSales.land = (string)dr["land"];
            GeneralSales.price = decimal.Parse(dr["price"].ToString());
            GeneralSales.netprice = decimal.Parse(dr["netprice"].ToString());
            GeneralSales.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            GeneralSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            GeneralSales.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            GeneralSales.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            GeneralSales.networkfeevaluewithvat = decimal.Parse(dr["networkfeevaluewithvat"].ToString());
            GeneralSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralSales.Payments = decimal.Parse(dr["Payments"].ToString());
            GeneralSales.remain = decimal.Parse(dr["remain"].ToString());
            GeneralSales.agent = (string)dr["agent"];
            GeneralSales.mobile = (string)dr["mobile"];
            GeneralSales.vatid = (string)dr["vatid"];

            lstData.Add(GeneralSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwGeneralSales>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralSales WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGeneralSales GeneralSales = new vwGeneralSales();

            GeneralSales.guid = new Guid(dr["guid"].ToString());
            GeneralSales.buyerguid = new Guid(dr["buyerguid"].ToString());
            GeneralSales.regdate = (DateTime)dr["regdate"];
            GeneralSales.contractno = (int)dr["contractno"];
            GeneralSales.code = (int)dr["code"];
            GeneralSales.blocknumber = (string)dr["blocknumber"];
            GeneralSales.number = (int)dr["number"];
            GeneralSales.land = (string)dr["land"];
            GeneralSales.price = decimal.Parse(dr["price"].ToString());
            GeneralSales.netprice = decimal.Parse(dr["netprice"].ToString());
            GeneralSales.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            GeneralSales.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            GeneralSales.networkfeevalue = decimal.Parse(dr["networkfeevalue"].ToString());
            GeneralSales.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            GeneralSales.networkfeevaluewithvat = decimal.Parse(dr["networkfeevaluewithvat"].ToString());
            GeneralSales.totalnet = decimal.Parse(dr["totalnet"].ToString());
            GeneralSales.Payments = decimal.Parse(dr["Payments"].ToString());
            GeneralSales.remain = decimal.Parse(dr["remain"].ToString());
            GeneralSales.agent = (string)dr["agent"];
            GeneralSales.mobile = (string)dr["mobile"];
            GeneralSales.vatid = (string)dr["vatid"];

            lstData.Add(GeneralSales);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwGeneralSales FindBy(string dbcolumn, object val)
    {
        vwGeneralSales GeneralSales = new vwGeneralSales();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGeneralSales WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            GeneralSales.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            GeneralSales.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            GeneralSales.regdate = (DateTime)DBConnect.DBReader["regdate"];
            GeneralSales.contractno = (int)DBConnect.DBReader["contractno"];
            GeneralSales.code = (int)DBConnect.DBReader["code"];
            GeneralSales.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            GeneralSales.number = (int)DBConnect.DBReader["number"];
            GeneralSales.land = (string)DBConnect.DBReader["land"];
            GeneralSales.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            GeneralSales.netprice = decimal.Parse(DBConnect.DBReader["netprice"].ToString());
            GeneralSales.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            GeneralSales.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            GeneralSales.networkfeevalue = decimal.Parse(DBConnect.DBReader["networkfeevalue"].ToString());
            GeneralSales.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            GeneralSales.networkfeevaluewithvat = decimal.Parse(DBConnect.DBReader["networkfeevaluewithvat"].ToString());
            GeneralSales.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            GeneralSales.Payments = decimal.Parse(DBConnect.DBReader["Payments"].ToString());
            GeneralSales.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            GeneralSales.agent = (string)DBConnect.DBReader["agent"];
            GeneralSales.mobile = (string)DBConnect.DBReader["mobile"];
            GeneralSales.vatid = (string)DBConnect.DBReader["vatid"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return GeneralSales;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwGeneralSales WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwGeneralSales", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGeneralSales", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwGeneralSales", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwGeneralSales WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGeneralSales", DBConnect.DBConnection);
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
Txtnetprice
Txtbuildingfeevalue
Txtworkfeevalue
Txtnetworkfeevalue
Txtvatvalue
Txtnetworkfeevaluewithvat
Txttotalnet
TxtPayments
Txtremain
Txtagent
Txtmobile
Txtvatid


*/