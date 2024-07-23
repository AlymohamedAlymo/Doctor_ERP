using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbPay
{

    public static List<tbPay> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "accountguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid accountguid { get; set; }
    [DataGUIAttribute(GUIName = "paytype", Formatting = "N0", Visibility = true, Width = 100, ControlName = "")]
    public int paytype { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "paydate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtpaydate")]
    public DateTime paydate { get; set; }
    [DataGUIAttribute(GUIName = "amount", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamount")]
    public decimal amount { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "lastaction", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlastaction")]
    public string lastaction { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbPay VALUES (@guid, @accountguid, @paytype, @number, @paydate, @amount, @note , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@accountguid", accountguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@paytype", paytype);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@paydate", paydate);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbPay SET accountguid = @accountguid, paytype = @paytype, number = @number, paydate = @paydate, amount = @amount, note = @note , lastaction = @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@accountguid", accountguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@paytype", paytype);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@paydate", paydate);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPay WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbPay  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPay";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbPay>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPay", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPay Pay = new tbPay();

            Pay.guid = new Guid(dr["guid"].ToString());
            Pay.accountguid = new Guid(dr["accountguid"].ToString());
            Pay.paytype = (int)dr["paytype"];
            Pay.number = (int)dr["number"];
            Pay.paydate = (DateTime)dr["paydate"];
            Pay.amount = decimal.Parse(dr["amount"].ToString());
            Pay.note = (string)dr["note"];
            Pay.lastaction = (string)dr["lastaction"];

            lstData.Add(Pay);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbPay>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPay WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPay Pay = new tbPay();

            Pay.guid = new Guid(dr["guid"].ToString());
            Pay.accountguid = new Guid(dr["accountguid"].ToString());
            Pay.paytype = (int)dr["paytype"];
            Pay.number = (int)dr["number"];
            Pay.paydate = (DateTime)dr["paydate"];
            Pay.amount = decimal.Parse(dr["amount"].ToString());
            Pay.note = (string)dr["note"];
            Pay.lastaction = (string)dr["lastaction"];

            lstData.Add(Pay);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbPay>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPay WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPay Pay = new tbPay();

            Pay.guid = new Guid(dr["guid"].ToString());
            Pay.accountguid = new Guid(dr["accountguid"].ToString());
            Pay.paytype = (int)dr["paytype"];
            Pay.number = (int)dr["number"];
            Pay.paydate = (DateTime)dr["paydate"];
            Pay.amount = decimal.Parse(dr["amount"].ToString());
            Pay.note = (string)dr["note"];
            Pay.lastaction = (string)dr["lastaction"];

            lstData.Add(Pay);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbPay>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPay WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPay Pay = new tbPay();

            Pay.guid = new Guid(dr["guid"].ToString());
            Pay.accountguid = new Guid(dr["accountguid"].ToString());
            Pay.paytype = (int)dr["paytype"];
            Pay.number = (int)dr["number"];
            Pay.paydate = (DateTime)dr["paydate"];
            Pay.amount = decimal.Parse(dr["amount"].ToString());
            Pay.note = (string)dr["note"];
            Pay.lastaction = (string)dr["lastaction"];

            lstData.Add(Pay);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbPay FindBy(string dbcolumn, object val)
    {
        tbPay Pay = new tbPay();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPay WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Pay.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Pay.accountguid = new Guid(DBConnect.DBReader["accountguid"].ToString());
            Pay.paytype = (int)DBConnect.DBReader["paytype"];
            Pay.number = (int)DBConnect.DBReader["number"];
            Pay.paydate = (DateTime)DBConnect.DBReader["paydate"];
            Pay.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            Pay.note = (string)DBConnect.DBReader["note"];
            Pay.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Pay;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbPay WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbPay", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPay", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPay", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbPay WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPay", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }

    public static int GetMaxNumber(string dbcolumn, int paytype)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPay WHERE paytype = @paytype", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@paytype", paytype);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPay WHERE paytype = @paytype", dbcolumn), DBConnect.DBConnection);
            DBConnect.DBCommand.Parameters.AddWithValue("@paytype", paytype);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }
}

/*

Txtpaytype
Txtnumber
dtpaydate
Txtamount
Txtnote


*/
 
