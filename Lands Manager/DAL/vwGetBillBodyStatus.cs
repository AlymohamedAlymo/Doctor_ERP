using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwGetBillBodyStatus
{

    public static List<vwGetBillBodyStatus> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "billtype", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtbilltype")]
    public int billtype { get; set; }
    [DataGUIAttribute(GUIName = "contractno", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtbilltype")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwGetBillBodyStatus>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGetBillBodyStatus", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGetBillBodyStatus GetBillBodyStatus = new vwGetBillBodyStatus();

            GetBillBodyStatus.guid = new Guid(dr["guid"].ToString());
            GetBillBodyStatus.landguid = new Guid(dr["landguid"].ToString());
            GetBillBodyStatus.parentguid = new Guid(dr["parentguid"].ToString());
            GetBillBodyStatus.billtype   = int.Parse(dr["billtype"].ToString());
            GetBillBodyStatus.contractno = int.Parse(dr["contractno"].ToString());
            GetBillBodyStatus.status = (string)dr["status"];

            lstData.Add(GetBillBodyStatus);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwGetBillBodyStatus>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwGetBillBodyStatus WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGetBillBodyStatus GetBillBodyStatus = new vwGetBillBodyStatus();

            GetBillBodyStatus.guid = new Guid(dr["guid"].ToString());
            GetBillBodyStatus.landguid = new Guid(dr["landguid"].ToString());
            GetBillBodyStatus.parentguid = new Guid(dr["parentguid"].ToString());
            GetBillBodyStatus.billtype = int.Parse(dr["billtype"].ToString());
            GetBillBodyStatus.contractno = int.Parse(dr["contractno"].ToString());
            GetBillBodyStatus.status = (string)dr["status"];

            lstData.Add(GetBillBodyStatus);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwGetBillBodyStatus>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGetBillBodyStatus WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGetBillBodyStatus GetBillBodyStatus = new vwGetBillBodyStatus();

            GetBillBodyStatus.guid = new Guid(dr["guid"].ToString());
            GetBillBodyStatus.landguid = new Guid(dr["landguid"].ToString());
            GetBillBodyStatus.parentguid = new Guid(dr["parentguid"].ToString());
            GetBillBodyStatus.billtype = int.Parse(dr["billtype"].ToString());
            GetBillBodyStatus.contractno = int.Parse(dr["contractno"].ToString());
            GetBillBodyStatus.status = (string)dr["status"];

            lstData.Add(GetBillBodyStatus);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwGetBillBodyStatus>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGetBillBodyStatus WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwGetBillBodyStatus GetBillBodyStatus = new vwGetBillBodyStatus();

            GetBillBodyStatus.guid = new Guid(dr["guid"].ToString());
            GetBillBodyStatus.landguid = new Guid(dr["landguid"].ToString());
            GetBillBodyStatus.parentguid = new Guid(dr["parentguid"].ToString());
            GetBillBodyStatus.billtype = int.Parse(dr["billtype"].ToString());
            GetBillBodyStatus.contractno = int.Parse(dr["contractno"].ToString());
            GetBillBodyStatus.status = (string)dr["status"];

            lstData.Add(GetBillBodyStatus);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwGetBillBodyStatus FindBy(string dbcolumn, object val)
    {
        vwGetBillBodyStatus GetBillBodyStatus = new vwGetBillBodyStatus();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGetBillBodyStatus WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            GetBillBodyStatus.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            GetBillBodyStatus.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            GetBillBodyStatus.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            GetBillBodyStatus.billtype = int.Parse(DBConnect.DBReader["billtype"].ToString());
            GetBillBodyStatus.contractno = int.Parse(DBConnect.DBReader["contractno"].ToString());
            GetBillBodyStatus.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return GetBillBodyStatus;
    }

    public static vwGetBillBodyStatus FindBy(string dbcolumn, object val, int billtype)
    {
        vwGetBillBodyStatus GetBillBodyStatus = new vwGetBillBodyStatus();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwGetBillBodyStatus WHERE {0} = {1} AND billtype = @billtype", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            GetBillBodyStatus.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            GetBillBodyStatus.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            GetBillBodyStatus.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            GetBillBodyStatus.billtype = int.Parse(DBConnect.DBReader["billtype"].ToString());
            GetBillBodyStatus.contractno = int.Parse(DBConnect.DBReader["contractno"].ToString());
            GetBillBodyStatus.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return GetBillBodyStatus;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwGetBillBodyStatus WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwGetBillBodyStatus", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGetBillBodyStatus", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwGetBillBodyStatus", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwGetBillBodyStatus WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwGetBillBodyStatus", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtbilltype
Txtstatus


*/

