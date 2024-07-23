using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwBillBody
{

    public static List<vwBillBody> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "contractno", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "code", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "land", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "price", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "discounttotaltext", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdiscounttotaltext")]
    public string discounttotaltext { get; set; }
    [DataGUIAttribute(GUIName = "discounttotal", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotal")]
    public decimal discounttotal { get; set; }
    [DataGUIAttribute(GUIName = "discounttotalvalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotalvalue")]
    public decimal discounttotalvalue { get; set; }
    [DataGUIAttribute(GUIName = "buildingfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfeevalue")]
    public decimal buildingfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "workfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "vatvalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvatvalue")]
    public decimal vatvalue { get; set; }
    [DataGUIAttribute(GUIName = "discountfeetext", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdiscountfeetext")]
    public string discountfeetext { get; set; }
    [DataGUIAttribute(GUIName = "discountfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfee")]
    public decimal discountfee { get; set; }
    [DataGUIAttribute(GUIName = "discountfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfeevalue")]
    public decimal discountfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "netprice", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal netprice { get; set; }
    [DataGUIAttribute(GUIName = "networkfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal networkfee { get; set; }
    [DataGUIAttribute(GUIName = "vatworkfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal vatworkfee { get; set; }
    [DataGUIAttribute(GUIName = "total", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "totalnet", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }


    #endregion


    public static void Fill()
    {
        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBillBody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBillBody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBillBody WHERE {0} = @val ", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val , string status)
    {
        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBillBody WHERE {0} = @val AND status = @status", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBillBody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, object val, DataTable privatebillBody)
    {
        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBillBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(privatebillBody);
        foreach (DataRow dr in privatebillBody.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val, DataTable privatebillBody, bool IsTrans)
    {
        lstData = new List<vwBillBody>();
        dtData = new DataTable();
        
        if (!IsTrans)
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBillBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        else
            DBConnect.DBCommand.CommandText = string.Format("SELECT * FROM vwBillBody WHERE {0} = @val", dbcolumn);

        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(privatebillBody);
        foreach (DataRow dr in privatebillBody.Rows)
        {
            vwBillBody BillBody = new vwBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.code = (int)dr["code"];
            BillBody.land = (string)dr["land"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(dr["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(dr["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(dr["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static vwBillBody FindBy(string dbcolumn, object val)
    {
        vwBillBody BillBody = new vwBillBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBillBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            BillBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            BillBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            BillBody.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            BillBody.number = (int)DBConnect.DBReader["number"];
            BillBody.contractno = (int)DBConnect.DBReader["contractno"];
            BillBody.code = (int)DBConnect.DBReader["code"];
            BillBody.land = (string)DBConnect.DBReader["land"];
            BillBody.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            BillBody.discounttotaltext = (string)DBConnect.DBReader["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(DBConnect.DBReader["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            BillBody.discountfeetext = (string)DBConnect.DBReader["discountfeetext"];
            BillBody.discountfee = decimal.Parse(DBConnect.DBReader["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());
            BillBody.netprice = decimal.Parse(DBConnect.DBReader["netprice"].ToString());
            BillBody.networkfee = decimal.Parse(DBConnect.DBReader["networkfee"].ToString());
            BillBody.vatworkfee = decimal.Parse(DBConnect.DBReader["vatworkfee"].ToString());
            BillBody.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            BillBody.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            BillBody.note = (string)DBConnect.DBReader["note"];
            BillBody.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return BillBody;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwBillBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwBillBody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwBillBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwBillBody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwBillBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwBillBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcontractno
Txtcode
Txtland
Txtprice
Txtdiscounttotaltext
Txtdiscounttotal
Txtdiscounttotalvalue
Txtbuildingfeevalue
Txtworkfeevalue
Txtvatvalue
Txtdiscountfeetext
Txtdiscountfee
Txtdiscountfeevalue
Txttotal
Txtnote


*/
