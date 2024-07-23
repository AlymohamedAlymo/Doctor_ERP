using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwPaycontractbody
{

    public static List<vwPaycontractbody> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "contractno", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "code", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "land", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "agent", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "amount", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamount")]
    public decimal amount { get; set; }
    [DataGUIAttribute(GUIName = "totalnet", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "remain", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO vwPaycontractbody VALUES (@guid, @parentguid, @number, @contractno, @code, @land, @agent, @amount, @totalnet, @remain, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
        DBConnect.DBCommand.Parameters.AddWithValue("@land", land);
        DBConnect.DBCommand.Parameters.AddWithValue("@agent", agent);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@remain", remain);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE vwPaycontractbody SET parentguid = @parentguid, number = @number, contractno = @contractno, code = @code, land = @land, agent = @agent, amount = @amount, totalnet = @totalnet, remain = @remain, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
        DBConnect.DBCommand.Parameters.AddWithValue("@land", land);
        DBConnect.DBCommand.Parameters.AddWithValue("@agent", agent);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@remain", remain);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwPaycontractbody WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM vwPaycontractbody  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwPaycontractbody";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<vwPaycontractbody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwPaycontractbody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaycontractbody Paycontractbody = new vwPaycontractbody();

            Paycontractbody.guid = new Guid(dr["guid"].ToString());
            Paycontractbody.parentguid = new Guid(dr["parentguid"].ToString());
            Paycontractbody.number = (int)dr["number"];
            Paycontractbody.contractno = (int)dr["contractno"];
            Paycontractbody.code = (int)dr["code"];
            Paycontractbody.land = (string)dr["land"];
            Paycontractbody.agent = (string)dr["agent"];
            Paycontractbody.amount = decimal.Parse(dr["amount"].ToString());
            Paycontractbody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Paycontractbody.remain = decimal.Parse(dr["remain"].ToString());
            Paycontractbody.note = (string)dr["note"];

            lstData.Add(Paycontractbody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwPaycontractbody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwPaycontractbody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaycontractbody Paycontractbody = new vwPaycontractbody();

            Paycontractbody.guid = new Guid(dr["guid"].ToString());
            Paycontractbody.parentguid = new Guid(dr["parentguid"].ToString());
            Paycontractbody.number = (int)dr["number"];
            Paycontractbody.contractno = (int)dr["contractno"];
            Paycontractbody.code = (int)dr["code"];
            Paycontractbody.land = (string)dr["land"];
            Paycontractbody.agent = (string)dr["agent"];
            Paycontractbody.amount = decimal.Parse(dr["amount"].ToString());
            Paycontractbody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Paycontractbody.remain = decimal.Parse(dr["remain"].ToString());
            Paycontractbody.note = (string)dr["note"];

            lstData.Add(Paycontractbody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwPaycontractbody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPaycontractbody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaycontractbody Paycontractbody = new vwPaycontractbody();

            Paycontractbody.guid = new Guid(dr["guid"].ToString());
            Paycontractbody.parentguid = new Guid(dr["parentguid"].ToString());
            Paycontractbody.number = (int)dr["number"];
            Paycontractbody.contractno = (int)dr["contractno"];
            Paycontractbody.code = (int)dr["code"];
            Paycontractbody.land = (string)dr["land"];
            Paycontractbody.agent = (string)dr["agent"];
            Paycontractbody.amount = decimal.Parse(dr["amount"].ToString());
            Paycontractbody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Paycontractbody.remain = decimal.Parse(dr["remain"].ToString());
            Paycontractbody.note = (string)dr["note"];

            lstData.Add(Paycontractbody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val, DataTable privatebillBody)
    {
        lstData = new List<vwPaycontractbody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPaycontractbody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(privatebillBody);
        foreach (DataRow dr in privatebillBody.Rows)
        {
            vwPaycontractbody Paycontractbody = new vwPaycontractbody();

            Paycontractbody.guid = new Guid(dr["guid"].ToString());
            Paycontractbody.parentguid = new Guid(dr["parentguid"].ToString());
            Paycontractbody.number = (int)dr["number"];
            Paycontractbody.contractno = (int)dr["contractno"];
            Paycontractbody.code = (int)dr["code"];
            Paycontractbody.land = (string)dr["land"];
            Paycontractbody.agent = (string)dr["agent"];
            Paycontractbody.amount = decimal.Parse(dr["amount"].ToString());
            Paycontractbody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Paycontractbody.remain = decimal.Parse(dr["remain"].ToString());
            Paycontractbody.note = (string)dr["note"];

            lstData.Add(Paycontractbody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwPaycontractbody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPaycontractbody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPaycontractbody Paycontractbody = new vwPaycontractbody();

            Paycontractbody.guid = new Guid(dr["guid"].ToString());
            Paycontractbody.parentguid = new Guid(dr["parentguid"].ToString());
            Paycontractbody.number = (int)dr["number"];
            Paycontractbody.contractno = (int)dr["contractno"];
            Paycontractbody.code = (int)dr["code"];
            Paycontractbody.land = (string)dr["land"];
            Paycontractbody.agent = (string)dr["agent"];
            Paycontractbody.amount = decimal.Parse(dr["amount"].ToString());
            Paycontractbody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Paycontractbody.remain = decimal.Parse(dr["remain"].ToString());
            Paycontractbody.note = (string)dr["note"];

            lstData.Add(Paycontractbody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwPaycontractbody FindBy(string dbcolumn, object val)
    {
        vwPaycontractbody Paycontractbody = new vwPaycontractbody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPaycontractbody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Paycontractbody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Paycontractbody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            Paycontractbody.number = (int)DBConnect.DBReader["number"];
            Paycontractbody.contractno = (int)DBConnect.DBReader["contractno"];
            Paycontractbody.code = (int)DBConnect.DBReader["code"];
            Paycontractbody.land = (string)DBConnect.DBReader["land"];
            Paycontractbody.agent = (string)DBConnect.DBReader["agent"];
            Paycontractbody.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            Paycontractbody.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            Paycontractbody.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            Paycontractbody.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Paycontractbody;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwPaycontractbody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwPaycontractbody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwPaycontractbody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwPaycontractbody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwPaycontractbody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwPaycontractbody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcontractno
Txtcode
Txtland
Txtagent
Txtamount
Txttotalnet
Txtremain
Txtnote


*/
