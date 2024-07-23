using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwContractRpt
{

    public static List<vwContractRpt> lstData;
    public static DataTable dtData;


    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "العميل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "رقم الهوية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string civilid { get; set; }
    [DataGUIAttribute(GUIName = "الإجمالي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "القيمة الدفترية", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtlandprice")]
    public decimal landprice { get; set; }
    [DataGUIAttribute(GUIName = "landpriceremain", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtlandpriceremain")]
    public decimal landpriceremain { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "workfeevalueremain", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtworkfeevalueremain")]
    public decimal workfeevalueremain { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة عمولة السعي", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtvatvalue")]
    public decimal vatvalue { get; set; }
    [DataGUIAttribute(GUIName = "vatvalueremain", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtvatvalueremain")]
    public decimal vatvalueremain { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }
    [DataGUIAttribute(GUIName = "billtype", Formatting = "N0", Visibility = false, Width = 100, ControlName = "Txtbilltype")]
    public int billtype { get; set; }
    #endregion


    public static void Fill()
    {
        lstData = new List<vwContractRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwContractRpt", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractRpt ContractRpt = new vwContractRpt();

            ContractRpt.guid = new Guid(dr["guid"].ToString());
            ContractRpt.landguid = new Guid(dr["landguid"].ToString());
            ContractRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractRpt.regdate = (DateTime)dr["regdate"];
            ContractRpt.contractno = (int)dr["contractno"];
            ContractRpt.code = (int)dr["code"];
            ContractRpt.land = (string)dr["land"];
            ContractRpt.agent = (string)dr["agent"];
            ContractRpt.mobile = (string)dr["mobile"];
            ContractRpt.civilid = (string)dr["civilid"];
            ContractRpt.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractRpt.remain = decimal.Parse(dr["remain"].ToString());
            ContractRpt.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractRpt.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractRpt.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractRpt.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractRpt.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractRpt.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractRpt.status = (string)dr["status"];
            ContractRpt.billtype = (int)dr["billtype"];

            lstData.Add(ContractRpt);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwContractRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwContractRpt WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractRpt ContractRpt = new vwContractRpt();

            ContractRpt.guid = new Guid(dr["guid"].ToString());
            ContractRpt.landguid = new Guid(dr["landguid"].ToString());
            ContractRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractRpt.regdate = (DateTime)dr["regdate"];
            ContractRpt.contractno = (int)dr["contractno"];
            ContractRpt.code = (int)dr["code"];
            ContractRpt.land = (string)dr["land"];
            ContractRpt.agent = (string)dr["agent"];
            ContractRpt.mobile = (string)dr["mobile"];
            ContractRpt.civilid = (string)dr["civilid"];
            ContractRpt.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractRpt.remain = decimal.Parse(dr["remain"].ToString());
            ContractRpt.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractRpt.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractRpt.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractRpt.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractRpt.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractRpt.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractRpt.status = (string)dr["status"];
            ContractRpt.billtype = (int)dr["billtype"];

            lstData.Add(ContractRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }



    public static void Fill(DateTime StartDate, DateTime EndDate, string status)
    {
        lstData = new List<vwContractRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwContractRpt WHERE (regdate >= @StartDate AND regdate <= @EndDate) AND status = @status order by contractno", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractRpt ContractRpt = new vwContractRpt();

            ContractRpt.guid = new Guid(dr["guid"].ToString());
            ContractRpt.landguid = new Guid(dr["landguid"].ToString());
            ContractRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractRpt.regdate = (DateTime)dr["regdate"];
            ContractRpt.contractno = (int)dr["contractno"];
            ContractRpt.code = (int)dr["code"];
            ContractRpt.land = (string)dr["land"];
            ContractRpt.agent = (string)dr["agent"];
            ContractRpt.mobile = (string)dr["mobile"];
            ContractRpt.civilid = (string)dr["civilid"];
            ContractRpt.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractRpt.remain = decimal.Parse(dr["remain"].ToString());
            ContractRpt.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractRpt.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractRpt.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractRpt.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractRpt.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractRpt.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractRpt.status = (string)dr["status"];
            ContractRpt.billtype = (int)dr["billtype"];

            lstData.Add(ContractRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwContractRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractRpt WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractRpt ContractRpt = new vwContractRpt();

            ContractRpt.guid = new Guid(dr["guid"].ToString());
            ContractRpt.landguid = new Guid(dr["landguid"].ToString());
            ContractRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractRpt.regdate = (DateTime)dr["regdate"];
            ContractRpt.contractno = (int)dr["contractno"];
            ContractRpt.code = (int)dr["code"];
            ContractRpt.land = (string)dr["land"];
            ContractRpt.agent = (string)dr["agent"];
            ContractRpt.mobile = (string)dr["mobile"];
            ContractRpt.civilid = (string)dr["civilid"];
            ContractRpt.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractRpt.remain = decimal.Parse(dr["remain"].ToString());
            ContractRpt.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractRpt.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractRpt.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractRpt.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractRpt.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractRpt.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractRpt.status = (string)dr["status"];
            ContractRpt.billtype = (int)dr["billtype"];

            lstData.Add(ContractRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwContractRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractRpt WHERE {0} LIKE '%{1}%' order by contractno", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractRpt ContractRpt = new vwContractRpt();

            ContractRpt.guid = new Guid(dr["guid"].ToString());
            ContractRpt.landguid = new Guid(dr["landguid"].ToString());
            ContractRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractRpt.regdate = (DateTime)dr["regdate"];
            ContractRpt.contractno = (int)dr["contractno"];
            ContractRpt.code = (int)dr["code"];
            ContractRpt.land = (string)dr["land"];
            ContractRpt.agent = (string)dr["agent"];
            ContractRpt.mobile = (string)dr["mobile"];
            ContractRpt.civilid = (string)dr["civilid"];
            ContractRpt.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractRpt.remain = decimal.Parse(dr["remain"].ToString());
            ContractRpt.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractRpt.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractRpt.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractRpt.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractRpt.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractRpt.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractRpt.status = (string)dr["status"];
            ContractRpt.billtype = (int)dr["billtype"];

            lstData.Add(ContractRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwContractRpt FindBy(string dbcolumn, object val)
    {
        vwContractRpt ContractRpt = new vwContractRpt();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractRpt WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            ContractRpt.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            ContractRpt.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            ContractRpt.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            ContractRpt.regdate = (DateTime)DBConnect.DBReader["regdate"];
            ContractRpt.contractno = (int)DBConnect.DBReader["contractno"];
            ContractRpt.code = (int)DBConnect.DBReader["code"];
            ContractRpt.land = (string)DBConnect.DBReader["land"];
            ContractRpt.agent = (string)DBConnect.DBReader["agent"];
            ContractRpt.mobile = (string)DBConnect.DBReader["mobile"];
            ContractRpt.civilid = (string)DBConnect.DBReader["civilid"];
            ContractRpt.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            ContractRpt.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            ContractRpt.landprice = decimal.Parse(DBConnect.DBReader["landprice"].ToString());
            ContractRpt.landpriceremain = decimal.Parse(DBConnect.DBReader["landpriceremain"].ToString());
            ContractRpt.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            ContractRpt.workfeevalueremain = decimal.Parse(DBConnect.DBReader["workfeevalueremain"].ToString());
            ContractRpt.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            ContractRpt.vatvalueremain = decimal.Parse(DBConnect.DBReader["vatvalueremain"].ToString());
            ContractRpt.status = (string)DBConnect.DBReader["status"];
            ContractRpt.billtype = (int)DBConnect.DBReader["billtype"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return ContractRpt;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwContractRpt WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwContractRpt", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwContractRpt", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwContractRpt", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwContractRpt WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwContractRpt", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtcontractno
Txtcode
Txtland
Txtagent
Txtmobile
Txtcivilid
Txttotalnet
Txtremain
Txtlandprice
Txtlandpriceremain
Txtworkfeevalue
Txtworkfeevalueremain
Txtvatvalue
Txtvatvalueremain
Txtstatus
Txtbilltype


*/