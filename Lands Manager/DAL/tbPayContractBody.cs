using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbPayContractBody
{

    public static List<tbPayContractBody> lstData;
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
    [DataGUIAttribute(GUIName = "amount", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamount")]
    public decimal amount { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbPayContractBody VALUES (@guid, @parentguid, @number, @contractno, @amount, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbPayContractBody SET parentguid = @parentguid, number = @number, contractno = @contractno, amount = @amount, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPayContractBody WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbPayContractBody  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPayContractBody";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbPayContractBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPayContractBody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContractBody PayContractBody = new tbPayContractBody();

            PayContractBody.guid = new Guid(dr["guid"].ToString());
            PayContractBody.parentguid = new Guid(dr["parentguid"].ToString());
            PayContractBody.number = (int)dr["number"];
            PayContractBody.contractno = (int)dr["contractno"];
            PayContractBody.amount = decimal.Parse(dr["amount"].ToString());
            PayContractBody.note = (string)dr["note"];

            lstData.Add(PayContractBody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbPayContractBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPayContractBody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContractBody PayContractBody = new tbPayContractBody();

            PayContractBody.guid = new Guid(dr["guid"].ToString());
            PayContractBody.parentguid = new Guid(dr["parentguid"].ToString());
            PayContractBody.number = (int)dr["number"];
            PayContractBody.contractno = (int)dr["contractno"];
            PayContractBody.amount = decimal.Parse(dr["amount"].ToString());
            PayContractBody.note = (string)dr["note"];

            lstData.Add(PayContractBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbPayContractBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPayContractBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContractBody PayContractBody = new tbPayContractBody();

            PayContractBody.guid = new Guid(dr["guid"].ToString());
            PayContractBody.parentguid = new Guid(dr["parentguid"].ToString());
            PayContractBody.number = (int)dr["number"];
            PayContractBody.contractno = (int)dr["contractno"];
            PayContractBody.amount = decimal.Parse(dr["amount"].ToString());
            PayContractBody.note = (string)dr["note"];

            lstData.Add(PayContractBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbPayContractBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPayContractBody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContractBody PayContractBody = new tbPayContractBody();

            PayContractBody.guid = new Guid(dr["guid"].ToString());
            PayContractBody.parentguid = new Guid(dr["parentguid"].ToString());
            PayContractBody.number = (int)dr["number"];
            PayContractBody.contractno = (int)dr["contractno"];
            PayContractBody.amount = decimal.Parse(dr["amount"].ToString());
            PayContractBody.note = (string)dr["note"];

            lstData.Add(PayContractBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbPayContractBody FindBy(string dbcolumn, object val)
    {
        tbPayContractBody PayContractBody = new tbPayContractBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPayContractBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PayContractBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            PayContractBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            PayContractBody.number = (int)DBConnect.DBReader["number"];
            PayContractBody.contractno = (int)DBConnect.DBReader["contractno"];
            PayContractBody.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            PayContractBody.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PayContractBody;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbPayContractBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbPayContractBody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPayContractBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPayContractBody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbPayContractBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPayContractBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcontractno
Txtamount
Txtnote


*/