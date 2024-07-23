using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwSalesOrderRpt
{

    public static List<vwSalesOrderRpt> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtlandnumber")]
    public int landnumber { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "صافي القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwSalesOrderRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSalesOrderRpt", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSalesOrderRpt SalesOrderRpt = new vwSalesOrderRpt();

            SalesOrderRpt.guid = new Guid(dr["guid"].ToString());
            SalesOrderRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            SalesOrderRpt.number = (int)dr["number"];
            SalesOrderRpt.regdate = (DateTime)dr["regdate"];
            SalesOrderRpt.code = (int)dr["code"];
            SalesOrderRpt.blocknumber = (string)dr["blocknumber"];
            SalesOrderRpt.landnumber = (int)dr["landnumber"];
            SalesOrderRpt.land = (string)dr["land"];
            SalesOrderRpt.price = decimal.Parse(dr["price"].ToString());
            SalesOrderRpt.total = decimal.Parse(dr["total"].ToString());
            SalesOrderRpt.agent = (string)dr["agent"];
            SalesOrderRpt.note = (string)dr["note"];

            lstData.Add(SalesOrderRpt);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwSalesOrderRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSalesOrderRpt WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSalesOrderRpt SalesOrderRpt = new vwSalesOrderRpt();

            SalesOrderRpt.guid = new Guid(dr["guid"].ToString());
            SalesOrderRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            SalesOrderRpt.number = (int)dr["number"];
            SalesOrderRpt.regdate = (DateTime)dr["regdate"];
            SalesOrderRpt.code = (int)dr["code"];
            SalesOrderRpt.blocknumber = (string)dr["blocknumber"];
            SalesOrderRpt.landnumber = (int)dr["landnumber"];
            SalesOrderRpt.land = (string)dr["land"];
            SalesOrderRpt.price = decimal.Parse(dr["price"].ToString());
            SalesOrderRpt.total = decimal.Parse(dr["total"].ToString());
            SalesOrderRpt.agent = (string)dr["agent"];
            SalesOrderRpt.note = (string)dr["note"];

            lstData.Add(SalesOrderRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwSalesOrderRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSalesOrderRpt WHERE RegDate >= @StartDate AND RegDate <= @EndDate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSalesOrderRpt SalesOrderRpt = new vwSalesOrderRpt();

            SalesOrderRpt.guid = new Guid(dr["guid"].ToString());
            SalesOrderRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            SalesOrderRpt.number = (int)dr["number"];
            SalesOrderRpt.regdate = (DateTime)dr["regdate"];
            SalesOrderRpt.code = (int)dr["code"];
            SalesOrderRpt.blocknumber = (string)dr["blocknumber"];
            SalesOrderRpt.landnumber = (int)dr["landnumber"];
            SalesOrderRpt.land = (string)dr["land"];
            SalesOrderRpt.price = decimal.Parse(dr["price"].ToString());
            SalesOrderRpt.total = decimal.Parse(dr["total"].ToString());
            SalesOrderRpt.agent = (string)dr["agent"];
            SalesOrderRpt.note = (string)dr["note"];

            lstData.Add(SalesOrderRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwSalesOrderRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSalesOrderRpt WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSalesOrderRpt SalesOrderRpt = new vwSalesOrderRpt();

            SalesOrderRpt.guid = new Guid(dr["guid"].ToString());
            SalesOrderRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            SalesOrderRpt.number = (int)dr["number"];
            SalesOrderRpt.regdate = (DateTime)dr["regdate"];
            SalesOrderRpt.code = (int)dr["code"];
            SalesOrderRpt.blocknumber = (string)dr["blocknumber"];
            SalesOrderRpt.landnumber = (int)dr["landnumber"];
            SalesOrderRpt.land = (string)dr["land"];
            SalesOrderRpt.price = decimal.Parse(dr["price"].ToString());
            SalesOrderRpt.total = decimal.Parse(dr["total"].ToString());
            SalesOrderRpt.agent = (string)dr["agent"];
            SalesOrderRpt.note = (string)dr["note"];

            lstData.Add(SalesOrderRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwSalesOrderRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSalesOrderRpt WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSalesOrderRpt SalesOrderRpt = new vwSalesOrderRpt();

            SalesOrderRpt.guid = new Guid(dr["guid"].ToString());
            SalesOrderRpt.buyerguid = new Guid(dr["buyerguid"].ToString());
            SalesOrderRpt.number = (int)dr["number"];
            SalesOrderRpt.regdate = (DateTime)dr["regdate"];
            SalesOrderRpt.code = (int)dr["code"];
            SalesOrderRpt.blocknumber = (string)dr["blocknumber"];
            SalesOrderRpt.landnumber = (int)dr["landnumber"];
            SalesOrderRpt.land = (string)dr["land"];
            SalesOrderRpt.price = decimal.Parse(dr["price"].ToString());
            SalesOrderRpt.total = decimal.Parse(dr["total"].ToString());
            SalesOrderRpt.agent = (string)dr["agent"];
            SalesOrderRpt.note = (string)dr["note"];

            lstData.Add(SalesOrderRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwSalesOrderRpt FindBy(string dbcolumn, object val)
    {
        vwSalesOrderRpt SalesOrderRpt = new vwSalesOrderRpt();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSalesOrderRpt WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            SalesOrderRpt.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            SalesOrderRpt.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            SalesOrderRpt.number = (int)DBConnect.DBReader["number"];
            SalesOrderRpt.regdate = (DateTime)DBConnect.DBReader["regdate"];
            SalesOrderRpt.code = (int)DBConnect.DBReader["code"];
            SalesOrderRpt.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            SalesOrderRpt.landnumber = (int)DBConnect.DBReader["landnumber"];
            SalesOrderRpt.land = (string)DBConnect.DBReader["land"];
            SalesOrderRpt.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            SalesOrderRpt.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            SalesOrderRpt.agent = (string)DBConnect.DBReader["agent"];
            SalesOrderRpt.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return SalesOrderRpt;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwSalesOrderRpt WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwSalesOrderRpt", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwSalesOrderRpt", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwSalesOrderRpt", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwSalesOrderRpt WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwSalesOrderRpt", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }

    public static int GetSalesOrderRemainCount()
    {
        DBConnect.DBCommand = new SqlCommand("select count(*) as salesorderscount from tbSaleOrderBody JOIN tbLand ON tbLand.guid = tbSaleOrderBody.landguid LEFT JOIN tbBillBody ON tbBillBody.landguid = tbSaleOrderBody.landguid LEFT JOIN tbBillheader ON tbBillheader.guid = tbBillBody.parentguid  WHERE tbLand.status <> 'مباع' AND  (tbBillBody.Guid IS NULL OR tbBillBody.status = 'مرتجع' )", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
dtregdate
Txtcode
Txtblocknumber
Txtlandnumber
Txtland
Txtprice
Txttotal
Txtagent
Txtnote


*/