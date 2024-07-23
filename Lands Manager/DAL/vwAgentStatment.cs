using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwAgentStatement
{

    public static List<vwAgentStatement> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "العميل", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "المدفوع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayments")]
    public decimal payments { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatement order by regdate", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatement WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(Guid buyerguid, DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatement WHERE buyerguid = @guid AND regdate >= @StartDate AND regdate <= @EndDate order by regdate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", buyerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }



    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatement WHERE regdate >= @StartDate AND regdate <= @EndDate order by regdate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatement WHERE {0} = @val order by regdate", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void FillNoRemain(string dbcolumn, object val)
    {
        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatement WHERE  {0} = @val AND remain > 0 order by regdate", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatement WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatement AgentStatement = new vwAgentStatement();

            AgentStatement.guid = new Guid(dr["guid"].ToString());
            AgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)dr["regdate"];
            AgentStatement.code = (int)dr["code"];
            AgentStatement.land = (string)dr["land"];
            AgentStatement.contractno = (int)dr["contractno"];
            AgentStatement.agent = (string)dr["agent"];
            AgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AgentStatement.remain = decimal.Parse(dr["remain"].ToString());

            lstData.Add(AgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwAgentStatement FindBy(string dbcolumn, object val)
    {
        vwAgentStatement AgentStatement = new vwAgentStatement();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatement WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            AgentStatement.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            AgentStatement.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            AgentStatement.regdate = (DateTime)DBConnect.DBReader["regdate"];
            AgentStatement.code = (int)DBConnect.DBReader["code"];
            AgentStatement.land = (string)DBConnect.DBReader["land"];
            AgentStatement.contractno = (int)DBConnect.DBReader["contractno"];
            AgentStatement.agent = (string)DBConnect.DBReader["agent"];
            AgentStatement.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            AgentStatement.payments = decimal.Parse(DBConnect.DBReader["payments"].ToString());
            AgentStatement.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return AgentStatement;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwAgentStatement WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwAgentStatement", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAgentStatement", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwAgentStatement", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static decimal GetAgentBalance(Guid AgentGuid)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT ISNULL(CAST(SUM(remain) as decimal(18,4)),0) as remain FROM vwAgentStatement where buyerguid = @buyerguid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerguid", AgentGuid);
        decimal balance = decimal.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return balance;
    }

    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwAgentStatement WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAgentStatement", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtcode
Txtland
Txtcontractno
Txtagent
Txttotalnet
Txtpayments
Txtremain


*/