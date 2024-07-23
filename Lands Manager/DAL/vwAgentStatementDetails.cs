using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwAgentStatementDetails
{

    public static List<vwAgentStatementDetails> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "رقم العملية", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "agent", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "المبيعات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayin")]
    public decimal payin { get; set; }
    [DataGUIAttribute(GUIName = "المقبوضات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayout")]
    public decimal payout { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtagent")]
    public string note { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwAgentStatementDetails>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatementDetails", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();

            AgentStatementDetails.guid = new Guid(dr["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)dr["regdate"];
            AgentStatementDetails.code = (int)dr["code"];
            AgentStatementDetails.land = (string)dr["land"];
            AgentStatementDetails.contractno = (int)dr["contractno"];
            AgentStatementDetails.agent = (string)dr["agent"];
            AgentStatementDetails.payin = decimal.Parse(dr["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(dr["payout"].ToString());
            AgentStatementDetails.note = (string)dr["note"];

            lstData.Add(AgentStatementDetails);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwAgentStatementDetails>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatementDetails WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();

            AgentStatementDetails.guid = new Guid(dr["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)dr["regdate"];
            AgentStatementDetails.code = (int)dr["code"];
            AgentStatementDetails.land = (string)dr["land"];
            AgentStatementDetails.contractno = (int)dr["contractno"];
            AgentStatementDetails.agent = (string)dr["agent"];
            AgentStatementDetails.payin = decimal.Parse(dr["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(dr["payout"].ToString());
            AgentStatementDetails.note = (string)dr["note"];

            lstData.Add(AgentStatementDetails);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwAgentStatementDetails>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatementDetails WHERE {0} = @val order by regdate", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();

            AgentStatementDetails.guid = new Guid(dr["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)dr["regdate"];
            AgentStatementDetails.code = (int)dr["code"];
            AgentStatementDetails.land = (string)dr["land"];
            AgentStatementDetails.contractno = (int)dr["contractno"];
            AgentStatementDetails.agent = (string)dr["agent"];
            AgentStatementDetails.payin = decimal.Parse(dr["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(dr["payout"].ToString());
            AgentStatementDetails.note = (string)dr["note"];

            lstData.Add(AgentStatementDetails);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(Guid buyerguid, DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwAgentStatementDetails>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatementDetails WHERE buyerguid = @guid AND regdate >= @StartDate AND regdate <= @EndDate order by regdate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", buyerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();

            AgentStatementDetails.guid = new Guid(dr["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)dr["regdate"];
            AgentStatementDetails.code = (int)dr["code"];
            AgentStatementDetails.land = (string)dr["land"];
            AgentStatementDetails.contractno = (int)dr["contractno"];
            AgentStatementDetails.agent = (string)dr["agent"];
            AgentStatementDetails.payin = decimal.Parse(dr["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(dr["payout"].ToString());
            AgentStatementDetails.note = (string)dr["note"];

            lstData.Add(AgentStatementDetails);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(DateTime StartDate, DateTime EndDate)
    {
        lstData = new List<vwAgentStatementDetails>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentStatementDetails WHERE  regdate >= @StartDate AND regdate <= @EndDate order by regdate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();

            AgentStatementDetails.guid = new Guid(dr["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)dr["regdate"];
            AgentStatementDetails.code = (int)dr["code"];
            AgentStatementDetails.land = (string)dr["land"];
            AgentStatementDetails.contractno = (int)dr["contractno"];
            AgentStatementDetails.agent = (string)dr["agent"];
            AgentStatementDetails.payin = decimal.Parse(dr["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(dr["payout"].ToString());
            AgentStatementDetails.note = (string)dr["note"];

            lstData.Add(AgentStatementDetails);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwAgentStatementDetails>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatementDetails WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();

            AgentStatementDetails.guid = new Guid(dr["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(dr["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)dr["regdate"];
            AgentStatementDetails.code = (int)dr["code"];
            AgentStatementDetails.land = (string)dr["land"];
            AgentStatementDetails.contractno = (int)dr["contractno"];
            AgentStatementDetails.agent = (string)dr["agent"];
            AgentStatementDetails.payin = decimal.Parse(dr["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(dr["payout"].ToString());

            lstData.Add(AgentStatementDetails);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwAgentStatementDetails FindBy(string dbcolumn, object val)
    {
        vwAgentStatementDetails AgentStatementDetails = new vwAgentStatementDetails();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentStatementDetails WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            AgentStatementDetails.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            AgentStatementDetails.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            AgentStatementDetails.regdate = (DateTime)DBConnect.DBReader["regdate"];
            AgentStatementDetails.code = (int)DBConnect.DBReader["code"];
            AgentStatementDetails.land = (string)DBConnect.DBReader["land"];
            AgentStatementDetails.contractno = (int)DBConnect.DBReader["contractno"];
            AgentStatementDetails.agent = (string)DBConnect.DBReader["agent"];
            AgentStatementDetails.payin = decimal.Parse(DBConnect.DBReader["payin"].ToString());
            AgentStatementDetails.payout = decimal.Parse(DBConnect.DBReader["payout"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return AgentStatementDetails;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwAgentStatementDetails WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwAgentStatementDetails", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAgentStatementDetails", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwAgentStatementDetails", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwAgentStatementDetails WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAgentStatementDetails", DBConnect.DBConnection);
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
Txtpayin
Txtpayout


*/