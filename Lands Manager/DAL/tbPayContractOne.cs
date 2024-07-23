using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbPayContract
{

    public static List<tbPayContract> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "paymenttype", Formatting = "N0", Visibility = true, Width = 100, ControlName = "")]
    public int paymenttype { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "paydate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtpaydate")]
    public DateTime paydate { get; set; }
    [DataGUIAttribute(GUIName = "refnumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtrefnumber")]
    public int refnumber { get; set; }
    [DataGUIAttribute(GUIName = "contractno", Formatting = "N0", Visibility = true, Width = 100, ControlName = "")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "amountfor", Formatting = "", Visibility = true, Width = 100, ControlName = "Cmbamountfor")]
    public string amountfor { get; set; }
    [DataGUIAttribute(GUIName = "paytype", Formatting = "", Visibility = true, Width = 100, ControlName = "Cmbpaytype")]
    public string paytype { get; set; }
    [DataGUIAttribute(GUIName = "bank", Formatting = "", Visibility = true, Width = 100, ControlName = "Cmbbank")]
    public string bank { get; set; }
    [DataGUIAttribute(GUIName = "checkno", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcheckno")]
    public string checkno { get; set; }
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
        DBConnect.DBCommand.CommandText = "INSERT INTO tbPayContract VALUES (@guid, @paymenttype, @number,  @paydate, @refnumber , @contractno, @amountfor , @paytype, @bank, @checkno, @amount, @note , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@paymenttype", paymenttype);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@paydate", paydate);
        DBConnect.DBCommand.Parameters.AddWithValue("@refnumber", refnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@amountfor", amountfor);
        DBConnect.DBCommand.Parameters.AddWithValue("@paytype", paytype);
        DBConnect.DBCommand.Parameters.AddWithValue("@bank", bank);
        DBConnect.DBCommand.Parameters.AddWithValue("@checkno", checkno);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbPayContract SET paymenttype = @paymenttype, number = @number, refnumber = @refnumber , paydate = @paydate, contractno = @contractno, amountfor = @amountfor , paytype = @paytype, bank = @bank, checkno = @checkno, amount = @amount, note = @note , lastaction = @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@paymenttype", paymenttype);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@paydate", paydate);
        DBConnect.DBCommand.Parameters.AddWithValue("@refnumber", refnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@amountfor", amountfor);
        DBConnect.DBCommand.Parameters.AddWithValue("@paytype", paytype);
        DBConnect.DBCommand.Parameters.AddWithValue("@bank", bank);
        DBConnect.DBCommand.Parameters.AddWithValue("@checkno", checkno);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPayContract WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbPayContract  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPayContract";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbPayContract>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPayContract", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContract PayContract = new tbPayContract();

            PayContract.guid = new Guid(dr["guid"].ToString());
            PayContract.paymenttype = (int)dr["paymenttype"];
            PayContract.number = (int)dr["number"];
            PayContract.refnumber = (int)dr["refnumber"];
            PayContract.paydate = (DateTime)dr["paydate"];
            PayContract.contractno = (int)dr["contractno"];
            PayContract.amountfor = (string)dr["amountfor"];
            PayContract.paytype = (string)dr["paytype"];
            PayContract.bank = (string)dr["bank"];
            PayContract.checkno = (string)dr["checkno"];
            PayContract.amount = decimal.Parse(dr["amount"].ToString());
            PayContract.note = (string)dr["note"];
            PayContract.lastaction = (string)dr["lastaction"];

            lstData.Add(PayContract);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbPayContract>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPayContract WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContract PayContract = new tbPayContract();

            PayContract.guid = new Guid(dr["guid"].ToString());
            PayContract.paymenttype = (int)dr["paymenttype"];
            PayContract.number = (int)dr["number"];
            PayContract.paydate = (DateTime)dr["paydate"];
            PayContract.refnumber = (int)dr["refnumber"];
            PayContract.contractno = (int)dr["contractno"];
            PayContract.amountfor = (string)dr["amountfor"];
            PayContract.paytype = (string)dr["paytype"];
            PayContract.bank = (string)dr["bank"];
            PayContract.checkno = (string)dr["checkno"];
            PayContract.amount = decimal.Parse(dr["amount"].ToString());
            PayContract.note = (string)dr["note"];
            PayContract.lastaction = (string)dr["lastaction"];

            lstData.Add(PayContract);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbPayContract>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPayContract WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContract PayContract = new tbPayContract();

            PayContract.guid = new Guid(dr["guid"].ToString());
            PayContract.paymenttype = (int)dr["paymenttype"];
            PayContract.number = (int)dr["number"];
            PayContract.paydate = (DateTime)dr["paydate"];
            PayContract.refnumber = (int)dr["refnumber"];
            PayContract.contractno = (int)dr["contractno"];
            PayContract.amountfor = (string)dr["amountfor"];
            PayContract.paytype = (string)dr["paytype"];
            PayContract.bank = (string)dr["bank"];
            PayContract.checkno = (string)dr["checkno"];
            PayContract.amount = decimal.Parse(dr["amount"].ToString());
            PayContract.note = (string)dr["note"];
            PayContract.lastaction = (string)dr["lastaction"];

            lstData.Add(PayContract);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbPayContract>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPayContract WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPayContract PayContract = new tbPayContract();

            PayContract.guid = new Guid(dr["guid"].ToString());
            PayContract.paymenttype = (int)dr["paymenttype"];
            PayContract.number = (int)dr["number"];
            PayContract.paydate = (DateTime)dr["paydate"];
            PayContract.refnumber = (int)dr["refnumber"];
            PayContract.contractno = (int)dr["contractno"];
            PayContract.amountfor = (string)dr["amountfor"];
            PayContract.paytype = (string)dr["paytype"];
            PayContract.bank = (string)dr["bank"];
            PayContract.checkno = (string)dr["checkno"];
            PayContract.amount = decimal.Parse(dr["amount"].ToString());
            PayContract.note = (string)dr["note"];
            PayContract.lastaction = (string)dr["lastaction"];

            lstData.Add(PayContract);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbPayContract FindBy(string dbcolumn, object val)
    {
        tbPayContract PayContract = new tbPayContract();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPayContract WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PayContract.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            PayContract.paymenttype = (int)DBConnect.DBReader["paymenttype"];

            PayContract.number = (int)DBConnect.DBReader["number"];
            PayContract.paydate = (DateTime)DBConnect.DBReader["paydate"];
            PayContract.refnumber = (int)DBConnect.DBReader["refnumber"];

            PayContract.contractno = (int)DBConnect.DBReader["contractno"];
            PayContract.amountfor = (string)DBConnect.DBReader["amountfor"];
            PayContract.paytype = (string)DBConnect.DBReader["paytype"];
            PayContract.bank = (string)DBConnect.DBReader["bank"];
            PayContract.checkno = (string)DBConnect.DBReader["checkno"];
            PayContract.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            PayContract.note = (string)DBConnect.DBReader["note"];
            PayContract.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PayContract;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbPayContract WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbPayContract", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPayContract", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPayContract", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetMaxNumber(string dbcolumn , int paymenttype )
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPayContract WHERE paymenttype = @paymenttype", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@paymenttype", paymenttype);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();

        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPayContract WHERE paymenttype = @paymenttype", dbcolumn), DBConnect.DBConnection);
            DBConnect.DBCommand.Parameters.AddWithValue("@paymenttype", paymenttype);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetMaxNumberTrans(string dbcolumn, int paymenttype)
    {
        DBConnect.DBCommand.CommandText = "SELECT COUNT(*) FROM tbPayContract WHERE paymenttype = @paymenttype";
        DBConnect.DBCommand.Parameters.AddWithValue("@paymenttype", paymenttype);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();

        if (icount >= 1)
        {
            DBConnect.DBCommand.CommandText = string.Format("SELECT MAX({0}) FROM tbPayContract WHERE paymenttype = @paymenttype", dbcolumn);
            DBConnect.DBCommand.Parameters.AddWithValue("@paymenttype", paymenttype);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbPayContract WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPayContract", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
dtpaydate
Txtcontractno
Txtpaytype
Txtbank
Txtcheckno
Txtamount
Txtnote


*/