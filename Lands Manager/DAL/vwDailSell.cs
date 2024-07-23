using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwDailSells
{

    public static List<vwDailSells> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "payguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid payguid { get; set; }
    [DataGUIAttribute(GUIName = "تاريخ العقد", Formatting = "dd/MM/yyyy", Visibility = false, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "النقدي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtcash")]
    public decimal cash { get; set; }
    [DataGUIAttribute(GUIName = "شبكة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbank")]
    public decimal network { get; set; }
    [DataGUIAttribute(GUIName = "شيكة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbank")]
    public decimal chick { get; set; }
    [DataGUIAttribute(GUIName = "تحويل بنكي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbank")]
    public decimal bank { get; set; }
    [DataGUIAttribute(GUIName = "اسم البنك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtbankname")]
    public string bankname { get; set; }
    [DataGUIAttribute(GUIName = "رقم الشيك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcheckno")]
    public string checkno { get; set; }
    [DataGUIAttribute(GUIName = "رقم السند", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpaynumber")]
    public int paynumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم يدوي", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpaynumber")]
    public int payrefnumber { get; set; }
    [DataGUIAttribute(GUIName = "تاريخ السند", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpaydate")]
    public string paydate { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtpaydate")]
    public string status { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwDailSells>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwDailSells order by regdate", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailSells DailSells = new vwDailSells();

            DailSells.guid = new Guid(dr["guid"].ToString());
            DailSells.payguid = new Guid(dr["payguid"].ToString());
            DailSells.regdate = (DateTime)dr["regdate"];
            DailSells.code = (int)dr["code"];
            DailSells.land = (string)dr["land"];
            DailSells.contractno = (int)dr["contractno"];
            DailSells.cash = decimal.Parse(dr["cash"].ToString());
            DailSells.network = decimal.Parse(dr["network"].ToString());
            DailSells.chick = decimal.Parse(dr["chick"].ToString());
            DailSells.bank = decimal.Parse(dr["bank"].ToString());
            DailSells.bankname = (string)dr["bankname"];
            DailSells.checkno = (string)dr["checkno"];
            DailSells.paynumber = (int)dr["paynumber"];
            DailSells.payrefnumber = (int)dr["payrefnumber"];
            DailSells.paydate = (string)dr["paydate"];
            DailSells.status = (string)dr["status"];

            lstData.Add(DailSells);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwDailSells>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwDailSells WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailSells DailSells = new vwDailSells();

            DailSells.guid = new Guid(dr["guid"].ToString());
            DailSells.payguid = new Guid(dr["payguid"].ToString());

            DailSells.regdate = (DateTime)dr["regdate"];
            DailSells.code = (int)dr["code"];
            DailSells.land = (string)dr["land"];
            DailSells.contractno = (int)dr["contractno"];
            DailSells.cash = decimal.Parse(dr["cash"].ToString());
            DailSells.network = decimal.Parse(dr["network"].ToString());
            DailSells.chick = decimal.Parse(dr["chick"].ToString());
            DailSells.bank = decimal.Parse(dr["bank"].ToString());
            DailSells.bankname = (string)dr["bankname"];
            DailSells.checkno = (string)dr["checkno"];
            DailSells.paynumber = (int)dr["paynumber"];
            DailSells.payrefnumber = (int)dr["payrefnumber"];
            DailSells.paydate = (string)dr["paydate"];
            DailSells.status = (string)dr["status"];

            lstData.Add(DailSells);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }



    public static void Fill(string status , DateTime StartDate , DateTime EndDate )
    {
        lstData = new List<vwDailSells>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwDailSells WHERE status = @status AND (paydate >= @StartDate AND paydate <= @EndDate) order by regdate", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailSells DailSells = new vwDailSells();

            DailSells.guid = new Guid(dr["guid"].ToString());
            DailSells.payguid = new Guid(dr["payguid"].ToString());

            DailSells.regdate = (DateTime)dr["regdate"];
            DailSells.code = (int)dr["code"];
            DailSells.land = (string)dr["land"];
            DailSells.contractno = (int)dr["contractno"];
            DailSells.cash = decimal.Parse(dr["cash"].ToString());
            DailSells.network = decimal.Parse(dr["network"].ToString());
            DailSells.chick = decimal.Parse(dr["chick"].ToString());
            DailSells.bank = decimal.Parse(dr["bank"].ToString());
            DailSells.bankname = (string)dr["bankname"];
            DailSells.checkno = (string)dr["checkno"];
            DailSells.paynumber = (int)dr["paynumber"];
            DailSells.payrefnumber = (int)dr["payrefnumber"];
            DailSells.paydate = (string)dr["paydate"];
            DailSells.status = (string)dr["status"];

            lstData.Add(DailSells);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwDailSells>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwDailSells WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailSells DailSells = new vwDailSells();

            DailSells.guid = new Guid(dr["guid"].ToString());
            DailSells.payguid = new Guid(dr["payguid"].ToString());

            DailSells.regdate = (DateTime)dr["regdate"];
            DailSells.code = (int)dr["code"];
            DailSells.land = (string)dr["land"];
            DailSells.contractno = (int)dr["contractno"];
            DailSells.cash = decimal.Parse(dr["cash"].ToString());
            DailSells.network = decimal.Parse(dr["network"].ToString());
            DailSells.chick = decimal.Parse(dr["chick"].ToString());
            DailSells.bank = decimal.Parse(dr["bank"].ToString());
            DailSells.bankname = (string)dr["bankname"];
            DailSells.checkno = (string)dr["checkno"];
            DailSells.paynumber = (int)dr["paynumber"];
            DailSells.payrefnumber = (int)dr["payrefnumber"];
            DailSells.paydate = (string)dr["paydate"];
            DailSells.status = (string)dr["status"];

            lstData.Add(DailSells);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwDailSells>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwDailSells WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwDailSells DailSells = new vwDailSells();

            DailSells.guid = new Guid(dr["guid"].ToString());
            DailSells.payguid = new Guid(dr["payguid"].ToString());

            DailSells.regdate = (DateTime)dr["regdate"];
            DailSells.code = (int)dr["code"];
            DailSells.land = (string)dr["land"];
            DailSells.contractno = (int)dr["contractno"];
            DailSells.cash = decimal.Parse(dr["cash"].ToString());
            DailSells.network = decimal.Parse(dr["network"].ToString());
            DailSells.chick = decimal.Parse(dr["chick"].ToString());
            DailSells.bank = decimal.Parse(dr["bank"].ToString());
            DailSells.bankname = (string)dr["bankname"];
            DailSells.checkno = (string)dr["checkno"];
            DailSells.paynumber = (int)dr["paynumber"];
            DailSells.payrefnumber = (int)dr["payrefnumber"];
            DailSells.paydate = (string)dr["paydate"];
            DailSells.status = (string)dr["status"];

            lstData.Add(DailSells);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwDailSells FindBy(string dbcolumn, object val)
    {
        vwDailSells DailSells = new vwDailSells();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwDailSells WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            DailSells.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            DailSells.payguid = new Guid(DBConnect.DBReader["payguid"].ToString());

            DailSells.regdate = (DateTime)DBConnect.DBReader["regdate"];
            DailSells.code = (int)DBConnect.DBReader["code"];
            DailSells.land = (string)DBConnect.DBReader["land"];
            DailSells.contractno = (int)DBConnect.DBReader["contractno"];
            DailSells.cash = decimal.Parse(DBConnect.DBReader["cash"].ToString());
            DailSells.network = decimal.Parse(DBConnect.DBReader["network"].ToString());
            DailSells.chick = decimal.Parse(DBConnect.DBReader["chick"].ToString());
            DailSells.bank = decimal.Parse(DBConnect.DBReader["bank"].ToString());
            DailSells.bankname = (string)DBConnect.DBReader["bankname"];
            DailSells.checkno = (string)DBConnect.DBReader["checkno"];
            DailSells.paynumber = (int)DBConnect.DBReader["paynumber"];
            DailSells.payrefnumber = (int)DBConnect.DBReader["payrefnumber"];
            DailSells.paydate = (string)DBConnect.DBReader["paydate"];
            DailSells.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return DailSells;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwDailSells WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwDailSells", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwDailSells", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwDailSells", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwDailSells WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwDailSells", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtcode
Txtland
Txtcontractno
Txtcash
Txtbank
Txtbankname
Txtcheckno
Txtpaynumber
Txtpaydate


*/