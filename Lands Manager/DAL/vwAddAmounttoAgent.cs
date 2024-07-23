using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwAddAmountToAgentStatement
{

    public static List<vwAddAmountToAgentStatement> lstData;
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
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "agent", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "المدفوع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtpayments")]
    public decimal payments { get; set; }
    [DataGUIAttribute(GUIName = "الدفعة المضافة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtaddpay")]
    public decimal addpay { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي بعد الدفع", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremainafterpay")]
    public decimal remainafterpay { get; set; }

    #endregion

 
    public static void Fill()
    {
        lstData = new List<vwAddAmountToAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAddAmountToAgentStatement", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAddAmountToAgentStatement AddAmountToAgentStatement = new vwAddAmountToAgentStatement();

            AddAmountToAgentStatement.guid = new Guid(dr["guid"].ToString());
            AddAmountToAgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AddAmountToAgentStatement.regdate = (DateTime)dr["regdate"];
            AddAmountToAgentStatement.code = (int)dr["code"];
            AddAmountToAgentStatement.land = (string)dr["land"];
            AddAmountToAgentStatement.contractno = (int)dr["contractno"];
            AddAmountToAgentStatement.agent = (string)dr["agent"];
            AddAmountToAgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AddAmountToAgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AddAmountToAgentStatement.addpay = decimal.Parse(dr["addpay"].ToString());
            AddAmountToAgentStatement.remain = decimal.Parse(dr["remain"].ToString());
            AddAmountToAgentStatement.remainafterpay = decimal.Parse(dr["remainafterpay"].ToString());

            lstData.Add(AddAmountToAgentStatement);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwAddAmountToAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwAddAmountToAgentStatement WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAddAmountToAgentStatement AddAmountToAgentStatement = new vwAddAmountToAgentStatement();

            AddAmountToAgentStatement.guid = new Guid(dr["guid"].ToString());
            AddAmountToAgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AddAmountToAgentStatement.regdate = (DateTime)dr["regdate"];
            AddAmountToAgentStatement.code = (int)dr["code"];
            AddAmountToAgentStatement.land = (string)dr["land"];
            AddAmountToAgentStatement.contractno = (int)dr["contractno"];
            AddAmountToAgentStatement.agent = (string)dr["agent"];
            AddAmountToAgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AddAmountToAgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AddAmountToAgentStatement.addpay = decimal.Parse(dr["addpay"].ToString());
            AddAmountToAgentStatement.remain = decimal.Parse(dr["remain"].ToString());
            AddAmountToAgentStatement.remainafterpay = decimal.Parse(dr["remainafterpay"].ToString());

            lstData.Add(AddAmountToAgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwAddAmountToAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAddAmountToAgentStatement WHERE {0} = @val AND remain > 0", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAddAmountToAgentStatement AddAmountToAgentStatement = new vwAddAmountToAgentStatement();

            AddAmountToAgentStatement.guid = new Guid(dr["guid"].ToString());
            AddAmountToAgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AddAmountToAgentStatement.regdate = (DateTime)dr["regdate"];
            AddAmountToAgentStatement.code = (int)dr["code"];
            AddAmountToAgentStatement.land = (string)dr["land"];
            AddAmountToAgentStatement.contractno = (int)dr["contractno"];
            AddAmountToAgentStatement.agent = (string)dr["agent"];
            AddAmountToAgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AddAmountToAgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AddAmountToAgentStatement.addpay = decimal.Parse(dr["addpay"].ToString());
            AddAmountToAgentStatement.remain = decimal.Parse(dr["remain"].ToString());
            AddAmountToAgentStatement.remainafterpay = decimal.Parse(dr["remainafterpay"].ToString());

            lstData.Add(AddAmountToAgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwAddAmountToAgentStatement>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAddAmountToAgentStatement WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwAddAmountToAgentStatement AddAmountToAgentStatement = new vwAddAmountToAgentStatement();

            AddAmountToAgentStatement.guid = new Guid(dr["guid"].ToString());
            AddAmountToAgentStatement.buyerguid = new Guid(dr["buyerguid"].ToString());
            AddAmountToAgentStatement.regdate = (DateTime)dr["regdate"];
            AddAmountToAgentStatement.code = (int)dr["code"];
            AddAmountToAgentStatement.land = (string)dr["land"];
            AddAmountToAgentStatement.contractno = (int)dr["contractno"];
            AddAmountToAgentStatement.agent = (string)dr["agent"];
            AddAmountToAgentStatement.totalnet = decimal.Parse(dr["totalnet"].ToString());
            AddAmountToAgentStatement.payments = decimal.Parse(dr["payments"].ToString());
            AddAmountToAgentStatement.addpay = decimal.Parse(dr["addpay"].ToString());
            AddAmountToAgentStatement.remain = decimal.Parse(dr["remain"].ToString());
            AddAmountToAgentStatement.remainafterpay = decimal.Parse(dr["remainafterpay"].ToString());

            lstData.Add(AddAmountToAgentStatement);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwAddAmountToAgentStatement FindBy(string dbcolumn, object val)
    {
        vwAddAmountToAgentStatement AddAmountToAgentStatement = new vwAddAmountToAgentStatement();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwAddAmountToAgentStatement WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            AddAmountToAgentStatement.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            AddAmountToAgentStatement.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            AddAmountToAgentStatement.regdate = (DateTime)DBConnect.DBReader["regdate"];
            AddAmountToAgentStatement.code = (int)DBConnect.DBReader["code"];
            AddAmountToAgentStatement.land = (string)DBConnect.DBReader["land"];
            AddAmountToAgentStatement.contractno = (int)DBConnect.DBReader["contractno"];
            AddAmountToAgentStatement.agent = (string)DBConnect.DBReader["agent"];
            AddAmountToAgentStatement.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            AddAmountToAgentStatement.payments = decimal.Parse(DBConnect.DBReader["payments"].ToString());
            AddAmountToAgentStatement.addpay = decimal.Parse(DBConnect.DBReader["addpay"].ToString());
            AddAmountToAgentStatement.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            AddAmountToAgentStatement.remainafterpay = decimal.Parse(DBConnect.DBReader["remainafterpay"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return AddAmountToAgentStatement;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwAddAmountToAgentStatement WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwAddAmountToAgentStatement", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAddAmountToAgentStatement", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwAddAmountToAgentStatement", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwAddAmountToAgentStatement WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwAddAmountToAgentStatement", DBConnect.DBConnection);
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
Txtaddpay
Txtremain
Txtremainafterpay


*/