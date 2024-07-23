using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwContractInfo
{

    public static List<vwContractInfo> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
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
    [DataGUIAttribute(GUIName = "القيمة الدفترية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtlandprice")]
    public decimal landprice { get; set; }
    [DataGUIAttribute(GUIName = "landpriceremain", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtlandpriceremain")]
    public decimal landpriceremain { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "workfeevalueremain", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtworkfeevalueremain")]
    public decimal workfeevalueremain { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvatvalue")]
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
        lstData = new List<vwContractInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwContractInfo", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractInfo ContractInfo = new vwContractInfo();

            ContractInfo.guid = new Guid(dr["guid"].ToString());
            ContractInfo.landguid = new Guid(dr["landguid"].ToString());
            ContractInfo.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractInfo.regdate = (DateTime)dr["regdate"];
            ContractInfo.contractno = (int)dr["contractno"];
            ContractInfo.code = (int)dr["code"];
            ContractInfo.land = (string)dr["land"];
            ContractInfo.agent = (string)dr["agent"];
            ContractInfo.mobile = (string)dr["mobile"];
            ContractInfo.civilid = (string)dr["civilid"];
            ContractInfo.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractInfo.remain = decimal.Parse(dr["remain"].ToString());
            ContractInfo.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractInfo.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractInfo.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractInfo.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractInfo.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractInfo.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractInfo.status = (string)dr["status"];
            ContractInfo.billtype = (int)dr["billtype"];

            lstData.Add(ContractInfo);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwContractInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwContractInfo WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractInfo ContractInfo = new vwContractInfo();

            ContractInfo.guid = new Guid(dr["guid"].ToString());
            ContractInfo.landguid = new Guid(dr["landguid"].ToString());
            ContractInfo.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractInfo.regdate = (DateTime)dr["regdate"];

            ContractInfo.contractno = (int)dr["contractno"];
            ContractInfo.code = (int)dr["code"];
            ContractInfo.land = (string)dr["land"];
            ContractInfo.agent = (string)dr["agent"];
            ContractInfo.mobile = (string)dr["mobile"];
            ContractInfo.civilid = (string)dr["civilid"];
            ContractInfo.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractInfo.remain = decimal.Parse(dr["remain"].ToString());
            ContractInfo.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractInfo.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractInfo.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractInfo.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractInfo.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractInfo.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractInfo.status = (string)dr["status"];
            ContractInfo.billtype = (int)dr["billtype"];

            lstData.Add(ContractInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwContractInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractInfo ContractInfo = new vwContractInfo();

            ContractInfo.guid = new Guid(dr["guid"].ToString());
            ContractInfo.landguid = new Guid(dr["landguid"].ToString());
            ContractInfo.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractInfo.regdate = (DateTime)dr["regdate"];

            ContractInfo.contractno = (int)dr["contractno"];
            ContractInfo.code = (int)dr["code"];
            ContractInfo.land = (string)dr["land"];
            ContractInfo.agent = (string)dr["agent"];
            ContractInfo.mobile = (string)dr["mobile"];
            ContractInfo.civilid = (string)dr["civilid"];
            ContractInfo.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractInfo.remain = decimal.Parse(dr["remain"].ToString());
            ContractInfo.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractInfo.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractInfo.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractInfo.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractInfo.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractInfo.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractInfo.status = (string)dr["status"];
            ContractInfo.billtype = (int)dr["billtype"];

            lstData.Add(ContractInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }




    public static void Fill(string keyword, string status)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwContractInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractInfo WHERE status = @status AND (agent LIKE '%{0}%' OR mobile = '{0}' OR  civilid = '{0}' OR CAST(contractno as varchar(255)) = '{0}' OR land LIKE '%{0}%')", keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwContractInfo ContractInfo = new vwContractInfo();

            ContractInfo.guid = new Guid(dr["guid"].ToString());
            ContractInfo.landguid = new Guid(dr["landguid"].ToString());
            ContractInfo.buyerguid = new Guid(dr["buyerguid"].ToString());
            ContractInfo.regdate = (DateTime)dr["regdate"];

            ContractInfo.contractno = (int)dr["contractno"];
            ContractInfo.code = (int)dr["code"];
            ContractInfo.land = (string)dr["land"];
            ContractInfo.agent = (string)dr["agent"];
            ContractInfo.mobile = (string)dr["mobile"];
            ContractInfo.civilid = (string)dr["civilid"];
            ContractInfo.totalnet = decimal.Parse(dr["totalnet"].ToString());
            ContractInfo.remain = decimal.Parse(dr["remain"].ToString());
            ContractInfo.landprice = decimal.Parse(dr["landprice"].ToString());
            ContractInfo.landpriceremain = decimal.Parse(dr["landpriceremain"].ToString());
            ContractInfo.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            ContractInfo.workfeevalueremain = decimal.Parse(dr["workfeevalueremain"].ToString());
            ContractInfo.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            ContractInfo.vatvalueremain = decimal.Parse(dr["vatvalueremain"].ToString());
            ContractInfo.status = (string)dr["status"];
            ContractInfo.billtype = (int)dr["billtype"];

            lstData.Add(ContractInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static vwContractInfo FindBy(string dbcolumn, object val)
    {
        vwContractInfo ContractInfo = new vwContractInfo();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            ContractInfo.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            ContractInfo.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            ContractInfo.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            ContractInfo.regdate = (DateTime)DBConnect.DBReader["regdate"];

            ContractInfo.contractno = (int)DBConnect.DBReader["contractno"];
            ContractInfo.code = (int)DBConnect.DBReader["code"];
            ContractInfo.land = (string)DBConnect.DBReader["land"];
            ContractInfo.agent = (string)DBConnect.DBReader["agent"];
            ContractInfo.mobile = (string)DBConnect.DBReader["mobile"];
            ContractInfo.civilid = (string)DBConnect.DBReader["civilid"];
            ContractInfo.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            ContractInfo.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            ContractInfo.landprice = decimal.Parse(DBConnect.DBReader["landprice"].ToString());
            ContractInfo.landpriceremain = decimal.Parse(DBConnect.DBReader["landpriceremain"].ToString());
            ContractInfo.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            ContractInfo.workfeevalueremain = decimal.Parse(DBConnect.DBReader["workfeevalueremain"].ToString());
            ContractInfo.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            ContractInfo.vatvalueremain = decimal.Parse(DBConnect.DBReader["vatvalueremain"].ToString());
            ContractInfo.status = (string)DBConnect.DBReader["status"];
            ContractInfo.billtype = (int)DBConnect.DBReader["billtype"];
        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return ContractInfo;
    }

    public static vwContractInfo FindBy(string dbcolumn, object val, int billtype)
    {
        vwContractInfo ContractInfo = new vwContractInfo();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwContractInfo WHERE {0} = {1} AND billtype = @billtype", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            ContractInfo.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            ContractInfo.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            ContractInfo.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            ContractInfo.regdate = (DateTime)DBConnect.DBReader["regdate"];

            ContractInfo.contractno = (int)DBConnect.DBReader["contractno"];
            ContractInfo.code = (int)DBConnect.DBReader["code"];
            ContractInfo.land = (string)DBConnect.DBReader["land"];
            ContractInfo.agent = (string)DBConnect.DBReader["agent"];
            ContractInfo.mobile = (string)DBConnect.DBReader["mobile"];
            ContractInfo.civilid = (string)DBConnect.DBReader["civilid"];
            ContractInfo.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            ContractInfo.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            ContractInfo.landprice = decimal.Parse(DBConnect.DBReader["landprice"].ToString());
            ContractInfo.landpriceremain = decimal.Parse(DBConnect.DBReader["landpriceremain"].ToString());
            ContractInfo.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            ContractInfo.workfeevalueremain = decimal.Parse(DBConnect.DBReader["workfeevalueremain"].ToString());
            ContractInfo.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            ContractInfo.vatvalueremain = decimal.Parse(DBConnect.DBReader["vatvalueremain"].ToString());
            ContractInfo.status = (string)DBConnect.DBReader["status"];
            ContractInfo.billtype = (int)DBConnect.DBReader["billtype"];
        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return ContractInfo;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwContractInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwContractInfo", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwContractInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwContractInfo", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwContractInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwContractInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtcontractno
Txtagent
Txtcode
Txttotalnet
Txtremain


*/