using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwBuildingFee
{

    public static List<vwBuildingFee> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = false, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
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
    [DataGUIAttribute(GUIName = "ضريبة التصرفات العقارية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfeevalue")]
    public decimal buildingfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "العميل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "الرقم الضريبي", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtvatid")]
    public string vatid { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwBuildingFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBuildingFee", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFee BuildingFee = new vwBuildingFee();

            BuildingFee.guid = new Guid(dr["guid"].ToString());
            BuildingFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFee.regdate = (DateTime)dr["regdate"];
            BuildingFee.code = (int)dr["code"];
            BuildingFee.blocknumber = (string)dr["blocknumber"];
            BuildingFee.number = (int)dr["number"];
            BuildingFee.land = (string)dr["land"];
            BuildingFee.price = decimal.Parse(dr["price"].ToString());
            BuildingFee.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFee.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFee.agent = (string)dr["agent"];
            BuildingFee.mobile = (string)dr["mobile"];
            BuildingFee.vatid = (string)dr["vatid"];

            lstData.Add(BuildingFee);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwBuildingFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBuildingFee WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFee BuildingFee = new vwBuildingFee();

            BuildingFee.guid = new Guid(dr["guid"].ToString());
            BuildingFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFee.regdate = (DateTime)dr["regdate"];
            BuildingFee.code = (int)dr["code"];
            BuildingFee.blocknumber = (string)dr["blocknumber"];
            BuildingFee.number = (int)dr["number"];
            BuildingFee.land = (string)dr["land"];
            BuildingFee.price = decimal.Parse(dr["price"].ToString());
            BuildingFee.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFee.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFee.agent = (string)dr["agent"];
            BuildingFee.mobile = (string)dr["mobile"];
            BuildingFee.vatid = (string)dr["vatid"];

            lstData.Add(BuildingFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(DateTime StartDate , DateTime EndDate )
    {
        lstData = new List<vwBuildingFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBuildingFee WHERE regdate >= @StartDate AND regdate <= @EndDate order by number", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFee BuildingFee = new vwBuildingFee();

            BuildingFee.guid = new Guid(dr["guid"].ToString());
            BuildingFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFee.regdate = (DateTime)dr["regdate"];
            BuildingFee.code = (int)dr["code"];
            BuildingFee.blocknumber = (string)dr["blocknumber"];
            BuildingFee.number = (int)dr["number"];
            BuildingFee.land = (string)dr["land"];
            BuildingFee.price = decimal.Parse(dr["price"].ToString());
            BuildingFee.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFee.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFee.agent = (string)dr["agent"];
            BuildingFee.mobile = (string)dr["mobile"];
            BuildingFee.vatid = (string)dr["vatid"];

            lstData.Add(BuildingFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwBuildingFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBuildingFee WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFee BuildingFee = new vwBuildingFee();

            BuildingFee.guid = new Guid(dr["guid"].ToString());
            BuildingFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFee.regdate = (DateTime)dr["regdate"];
            BuildingFee.code = (int)dr["code"];
            BuildingFee.blocknumber = (string)dr["blocknumber"];
            BuildingFee.number = (int)dr["number"];
            BuildingFee.land = (string)dr["land"];
            BuildingFee.price = decimal.Parse(dr["price"].ToString());
            BuildingFee.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFee.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFee.agent = (string)dr["agent"];
            BuildingFee.mobile = (string)dr["mobile"];
            BuildingFee.vatid = (string)dr["vatid"];

            lstData.Add(BuildingFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwBuildingFee>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBuildingFee WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFee BuildingFee = new vwBuildingFee();

            BuildingFee.guid = new Guid(dr["guid"].ToString());
            BuildingFee.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFee.regdate = (DateTime)dr["regdate"];
            BuildingFee.code = (int)dr["code"];
            BuildingFee.blocknumber = (string)dr["blocknumber"];
            BuildingFee.number = (int)dr["number"];
            BuildingFee.land = (string)dr["land"];
            BuildingFee.price = decimal.Parse(dr["price"].ToString());
            BuildingFee.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFee.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFee.agent = (string)dr["agent"];
            BuildingFee.mobile = (string)dr["mobile"];
            BuildingFee.vatid = (string)dr["vatid"];

            lstData.Add(BuildingFee);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwBuildingFee FindBy(string dbcolumn, object val)
    {
        vwBuildingFee BuildingFee = new vwBuildingFee();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBuildingFee WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            BuildingFee.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            BuildingFee.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            BuildingFee.regdate = (DateTime)DBConnect.DBReader["regdate"];
            BuildingFee.code = (int)DBConnect.DBReader["code"];
            BuildingFee.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            BuildingFee.number = (int)DBConnect.DBReader["number"];
            BuildingFee.land = (string)DBConnect.DBReader["land"];
            BuildingFee.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            BuildingFee.netprice = decimal.Parse(DBConnect.DBReader["netprice"].ToString());
            BuildingFee.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            BuildingFee.agent = (string)DBConnect.DBReader["agent"];
            BuildingFee.mobile = (string)DBConnect.DBReader["mobile"];
            BuildingFee.vatid = (string)DBConnect.DBReader["vatid"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return BuildingFee;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwBuildingFee WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwBuildingFee", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwBuildingFee", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwBuildingFee", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwBuildingFee WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwBuildingFee", DBConnect.DBConnection);
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
Txtbuildingfeevalue
Txtagent
Txtmobile
Txtvatid


*/