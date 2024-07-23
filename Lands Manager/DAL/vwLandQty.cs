using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwLandQty
{

    public static List<vwLandQty> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "الكمية", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtqty")]
    public int qty { get; set; }
    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "نسبة عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal workfee { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "الحالة", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwLandQty>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandQty", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandQty LandQty = new vwLandQty();

            LandQty.Guid = new Guid(dr["Guid"].ToString());
            LandQty.code = (int)dr["code"];
            LandQty.blocknumber = (string)dr["blocknumber"];
            LandQty.land = (string)dr["land"];
            LandQty.qty = (int)dr["qty"];
            LandQty.total = decimal.Parse(dr["total"].ToString());
            LandQty.workfee = decimal.Parse(dr["workfee"].ToString());
            LandQty.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandQty.status = (string)dr["status"];

            lstData.Add(LandQty);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwLandQty>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandQty WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandQty LandQty = new vwLandQty();

            LandQty.Guid = new Guid(dr["Guid"].ToString());
            LandQty.code = (int)dr["code"];
            LandQty.blocknumber = (string)dr["blocknumber"];
            LandQty.land = (string)dr["land"];
            LandQty.qty = (int)dr["qty"];
            LandQty.total = decimal.Parse(dr["total"].ToString());
            LandQty.workfee = decimal.Parse(dr["workfee"].ToString());
            LandQty.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandQty.status = (string)dr["status"];

            lstData.Add(LandQty);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void FillInStore()
    {
        lstData = new List<vwLandQty>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandQty WHERE status <> 'مباع'", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandQty LandQty = new vwLandQty();

            LandQty.Guid = new Guid(dr["Guid"].ToString());
            LandQty.code = (int)dr["code"];
            LandQty.blocknumber = (string)dr["blocknumber"];
            LandQty.land = (string)dr["land"];
            LandQty.qty = (int)dr["qty"];
            LandQty.total = decimal.Parse(dr["total"].ToString());
            LandQty.workfee = decimal.Parse(dr["workfee"].ToString());
            LandQty.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandQty.status = (string)dr["status"];

            lstData.Add(LandQty);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwLandQty>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandQty WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandQty LandQty = new vwLandQty();

            LandQty.Guid = new Guid(dr["Guid"].ToString());
            LandQty.code = (int)dr["code"];
            LandQty.blocknumber = (string)dr["blocknumber"];
            LandQty.land = (string)dr["land"];
            LandQty.qty = (int)dr["qty"];
            LandQty.total = decimal.Parse(dr["total"].ToString());
            LandQty.workfee = decimal.Parse(dr["workfee"].ToString());
            LandQty.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandQty.status = (string)dr["status"];

            lstData.Add(LandQty);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLandQty>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandQty WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandQty LandQty = new vwLandQty();

            LandQty.Guid = new Guid(dr["Guid"].ToString());
            LandQty.code = (int)dr["code"];
            LandQty.blocknumber = (string)dr["blocknumber"];
            LandQty.land = (string)dr["land"];
            LandQty.qty = (int)dr["qty"];
            LandQty.total = decimal.Parse(dr["total"].ToString());
            LandQty.workfee = decimal.Parse(dr["workfee"].ToString());
            LandQty.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            LandQty.status = (string)dr["status"];

            lstData.Add(LandQty);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwLandQty FindBy(string dbcolumn, object val)
    {
        vwLandQty LandQty = new vwLandQty();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandQty WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandQty.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            LandQty.code = (int)DBConnect.DBReader["code"];
            LandQty.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            LandQty.land = (string)DBConnect.DBReader["land"];
            LandQty.qty = (int)DBConnect.DBReader["qty"];
            LandQty.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            LandQty.workfee = decimal.Parse(DBConnect.DBReader["workfee"].ToString());
            LandQty.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            LandQty.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandQty;
    }



    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwLandQty WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwLandQty", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandQty", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwLandQty", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwLandQty WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandQty", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtcode
Txtblocknumber
Txtland
Txtqty
Txtstatus


*/