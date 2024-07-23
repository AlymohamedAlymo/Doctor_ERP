using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwBuildingFeeNumbers
{

    public static List<vwBuildingFeeNumbers> lstData;
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
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الصنف", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "قيمة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "صافي قيمة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtnetprice")]
    public decimal netprice { get; set; }
    [DataGUIAttribute(GUIName = "رقم ضريبة التصرفات العقارية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtbuildingnumber")]
    public string buildingnumber { get; set; }
    [DataGUIAttribute(GUIName = "قيمة ضريبة التصرفات العقارية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfeevalue")]
    public decimal buildingfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "رقم الجوال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwBuildingFeeNumbers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBuildingFeeNumbers", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFeeNumbers BuildingFeeNumbers = new vwBuildingFeeNumbers();

            BuildingFeeNumbers.guid = new Guid(dr["guid"].ToString());
            BuildingFeeNumbers.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFeeNumbers.regdate = (DateTime)dr["regdate"];
            BuildingFeeNumbers.contractno = (int)dr["contractno"];
            BuildingFeeNumbers.blocknumber = (string)dr["blocknumber"];
            BuildingFeeNumbers.number = (int)dr["number"];
            BuildingFeeNumbers.land = (string)dr["land"];
            BuildingFeeNumbers.price = decimal.Parse(dr["price"].ToString());
            BuildingFeeNumbers.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFeeNumbers.buildingnumber = (string)dr["buildingnumber"];
            BuildingFeeNumbers.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFeeNumbers.agent = (string)dr["agent"];
            BuildingFeeNumbers.mobile = (string)dr["mobile"];

            lstData.Add(BuildingFeeNumbers);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwBuildingFeeNumbers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBuildingFeeNumbers WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFeeNumbers BuildingFeeNumbers = new vwBuildingFeeNumbers();

            BuildingFeeNumbers.guid = new Guid(dr["guid"].ToString());
            BuildingFeeNumbers.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFeeNumbers.regdate = (DateTime)dr["regdate"];
            BuildingFeeNumbers.contractno = (int)dr["contractno"];
            BuildingFeeNumbers.blocknumber = (string)dr["blocknumber"];
            BuildingFeeNumbers.number = (int)dr["number"];
            BuildingFeeNumbers.land = (string)dr["land"];
            BuildingFeeNumbers.price = decimal.Parse(dr["price"].ToString());
            BuildingFeeNumbers.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFeeNumbers.buildingnumber = (string)dr["buildingnumber"];
            BuildingFeeNumbers.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFeeNumbers.agent = (string)dr["agent"];
            BuildingFeeNumbers.mobile = (string)dr["mobile"];

            lstData.Add(BuildingFeeNumbers);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwBuildingFeeNumbers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwBuildingFeeNumbers WHERE regdate >= @StartDate AND regdate <= @EndDate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFeeNumbers BuildingFeeNumbers = new vwBuildingFeeNumbers();

            BuildingFeeNumbers.guid = new Guid(dr["guid"].ToString());
            BuildingFeeNumbers.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFeeNumbers.regdate = (DateTime)dr["regdate"];
            BuildingFeeNumbers.contractno = (int)dr["contractno"];
            BuildingFeeNumbers.blocknumber = (string)dr["blocknumber"];
            BuildingFeeNumbers.number = (int)dr["number"];
            BuildingFeeNumbers.land = (string)dr["land"];
            BuildingFeeNumbers.price = decimal.Parse(dr["price"].ToString());
            BuildingFeeNumbers.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFeeNumbers.buildingnumber = (string)dr["buildingnumber"];
            BuildingFeeNumbers.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFeeNumbers.agent = (string)dr["agent"];
            BuildingFeeNumbers.mobile = (string)dr["mobile"];

            lstData.Add(BuildingFeeNumbers);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwBuildingFeeNumbers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBuildingFeeNumbers WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFeeNumbers BuildingFeeNumbers = new vwBuildingFeeNumbers();

            BuildingFeeNumbers.guid = new Guid(dr["guid"].ToString());
            BuildingFeeNumbers.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFeeNumbers.regdate = (DateTime)dr["regdate"];
            BuildingFeeNumbers.contractno = (int)dr["contractno"];
            BuildingFeeNumbers.blocknumber = (string)dr["blocknumber"];
            BuildingFeeNumbers.number = (int)dr["number"];
            BuildingFeeNumbers.land = (string)dr["land"];
            BuildingFeeNumbers.price = decimal.Parse(dr["price"].ToString());
            BuildingFeeNumbers.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFeeNumbers.buildingnumber = (string)dr["buildingnumber"];
            BuildingFeeNumbers.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFeeNumbers.agent = (string)dr["agent"];
            BuildingFeeNumbers.mobile = (string)dr["mobile"];

            lstData.Add(BuildingFeeNumbers);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwBuildingFeeNumbers>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBuildingFeeNumbers WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwBuildingFeeNumbers BuildingFeeNumbers = new vwBuildingFeeNumbers();

            BuildingFeeNumbers.guid = new Guid(dr["guid"].ToString());
            BuildingFeeNumbers.buyerguid = new Guid(dr["buyerguid"].ToString());
            BuildingFeeNumbers.regdate = (DateTime)dr["regdate"];
            BuildingFeeNumbers.contractno = (int)dr["contractno"];
            BuildingFeeNumbers.blocknumber = (string)dr["blocknumber"];
            BuildingFeeNumbers.number = (int)dr["number"];
            BuildingFeeNumbers.land = (string)dr["land"];
            BuildingFeeNumbers.price = decimal.Parse(dr["price"].ToString());
            BuildingFeeNumbers.netprice = decimal.Parse(dr["netprice"].ToString());
            BuildingFeeNumbers.buildingnumber = (string)dr["buildingnumber"];
            BuildingFeeNumbers.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BuildingFeeNumbers.agent = (string)dr["agent"];
            BuildingFeeNumbers.mobile = (string)dr["mobile"];

            lstData.Add(BuildingFeeNumbers);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwBuildingFeeNumbers FindBy(string dbcolumn, object val)
    {
        vwBuildingFeeNumbers BuildingFeeNumbers = new vwBuildingFeeNumbers();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwBuildingFeeNumbers WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            BuildingFeeNumbers.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            BuildingFeeNumbers.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            BuildingFeeNumbers.regdate = (DateTime)DBConnect.DBReader["regdate"];
            BuildingFeeNumbers.contractno = (int)DBConnect.DBReader["contractno"];
            BuildingFeeNumbers.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            BuildingFeeNumbers.number = (int)DBConnect.DBReader["number"];
            BuildingFeeNumbers.land = (string)DBConnect.DBReader["land"];
            BuildingFeeNumbers.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            BuildingFeeNumbers.netprice = decimal.Parse(DBConnect.DBReader["netprice"].ToString());
            BuildingFeeNumbers.buildingnumber = (string)DBConnect.DBReader["buildingnumber"];
            BuildingFeeNumbers.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            BuildingFeeNumbers.agent = (string)DBConnect.DBReader["agent"];
            BuildingFeeNumbers.mobile = (string)DBConnect.DBReader["mobile"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return BuildingFeeNumbers;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwBuildingFeeNumbers WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwBuildingFeeNumbers", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwBuildingFeeNumbers", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwBuildingFeeNumbers", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwBuildingFeeNumbers WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwBuildingFeeNumbers", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtcontractno
Txtblocknumber
Txtnumber
Txtland
Txtprice
Txtnetprice
Txtbuildingnumber
Txtbuildingfeevalue
Txtagent
Txtmobile


*/