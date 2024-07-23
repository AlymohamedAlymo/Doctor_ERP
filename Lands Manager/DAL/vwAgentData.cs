using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwAgentData
{

    public static List<vwAgentData> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "name", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "civilid", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcivilid")]
    public string civilid { get; set; }
    [DataGUIAttribute(GUIName = "mobile", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtmobile")]
    public string mobile { get; set; }
    [DataGUIAttribute(GUIName = "email", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtemail")]
    public string email { get; set; }
    [DataGUIAttribute(GUIName = "vatid", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtvatid")]
    public string vatid { get; set; }
    [DataGUIAttribute(GUIName = "agencynumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagencynumber")]
    public string agencynumber { get; set; }
    [DataGUIAttribute(GUIName = "publicnumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpublicnumber")]
    public string publicnumber { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwAgentData>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAgentData", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentData AgentData = new vwAgentData();

            AgentData.guid = new Guid(dr["guid"].ToString());
            AgentData.number = (int)dr["number"];
            AgentData.name = (string)dr["name"];
            AgentData.civilid = (string)dr["civilid"];
            AgentData.mobile = (string)dr["mobile"];
            AgentData.email = (string)dr["email"];
            AgentData.vatid = (string)dr["vatid"];
            AgentData.agencynumber = (string)dr["agencynumber"];
            AgentData.publicnumber = (string)dr["publicnumber"];

            lstData.Add(AgentData);
        }
    }


    public static void Fill(Guid guid, int agenttype, string ownerdata)
    {
        lstData = new List<vwAgentData>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM fnGetAgentData (@agenttype , @ownerdata)  WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@agenttype", agenttype);
        DBConnect.DBCommand.Parameters.AddWithValue("@ownerdata", ownerdata);

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentData AgentData = new vwAgentData();

            AgentData.guid = new Guid(dr["guid"].ToString());
            AgentData.number = (int)dr["number"];
            AgentData.name = (string)dr["name"];
            AgentData.civilid = (string)dr["civilid"];
            AgentData.mobile = (string)dr["mobile"];
            AgentData.email = (string)dr["email"];
            AgentData.vatid = (string)dr["vatid"];
            AgentData.agencynumber = (string)dr["agencynumber"];
            AgentData.publicnumber = (string)dr["publicnumber"];

            lstData.Add(AgentData);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwAgentData>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentData WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentData AgentData = new vwAgentData();

            AgentData.guid = new Guid(dr["guid"].ToString());
            AgentData.number = (int)dr["number"];
            AgentData.name = (string)dr["name"];
            AgentData.civilid = (string)dr["civilid"];
            AgentData.mobile = (string)dr["mobile"];
            AgentData.email = (string)dr["email"];
            AgentData.vatid = (string)dr["vatid"];
            AgentData.agencynumber = (string)dr["agencynumber"];
            AgentData.publicnumber = (string)dr["publicnumber"];

            lstData.Add(AgentData);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwAgentData>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentData WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAgentData AgentData = new vwAgentData();

            AgentData.guid = new Guid(dr["guid"].ToString());
            AgentData.number = (int)dr["number"];
            AgentData.name = (string)dr["name"];
            AgentData.civilid = (string)dr["civilid"];
            AgentData.mobile = (string)dr["mobile"];
            AgentData.email = (string)dr["email"];
            AgentData.vatid = (string)dr["vatid"];
            AgentData.agencynumber = (string)dr["agencynumber"];
            AgentData.publicnumber = (string)dr["publicnumber"];

            lstData.Add(AgentData);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwAgentData FindBy(string dbcolumn, object val)
    {
        vwAgentData AgentData = new vwAgentData();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAgentData WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            AgentData.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            AgentData.number = (int)DBConnect.DBReader["number"];
            AgentData.name = (string)DBConnect.DBReader["name"];
            AgentData.civilid = (string)DBConnect.DBReader["civilid"];
            AgentData.mobile = (string)DBConnect.DBReader["mobile"];
            AgentData.email = (string)DBConnect.DBReader["email"];
            AgentData.vatid = (string)DBConnect.DBReader["vatid"];
            AgentData.agencynumber = (string)DBConnect.DBReader["agencynumber"];
            AgentData.publicnumber = (string)DBConnect.DBReader["publicnumber"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return AgentData;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwAgentData WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwAgentData", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAgentData", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwAgentData", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwAgentData WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAgentData", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcode
Txtname
Txtcivilid
Txtmobile
Txtemail
Txtvatid
Txtagencynumber
Txtpublicnumber


*/