using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DevExpress.Utils.Extensions;

public class vwPayRpt
{

    public static List<vwPayRpt> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "رقم السند", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الرقم اليدوي", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int refnumber { get; set; }
    [DataGUIAttribute(GUIName = "العملية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpaymenttype")]
    public string paymenttype { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtpaydate")]
    public DateTime paydate { get; set; }
    [DataGUIAttribute(GUIName = "رقم العقد", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "الصنف", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "نوع الدفعة", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtAmountFor")]
    public string AmountFor { get; set; }
    [DataGUIAttribute(GUIName = "طريقة الدفع", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpaytype")]
    public string paytype { get; set; }
    [DataGUIAttribute(GUIName = "البنك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtbank")]
    public string bank { get; set; }
    [DataGUIAttribute(GUIName = "رقم الشيك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcheckno")]
    public string checkno { get; set; }
    [DataGUIAttribute(GUIName = "المبلغ", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamount")]
    public decimal amount { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "الحالة", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtnote")]
    public string status { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwPayRpt", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());
            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
    }


    public static void Fill(DateTime StartDate, DateTime EndDate, string status)
    {
        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwPayRpt WHERE (PayDate >= @StartDate AND PayDate <= @EndDate)  AND status = @status", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());

            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
    }


    public static void Fill(DateTime StartDate, DateTime EndDate, string status , string AmountFor)
    {
        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwPayRpt WHERE (PayDate >= @StartDate AND PayDate <= @EndDate)  AND AmountFor = @AmountFor AND status = @status", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@StartDate", StartDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@EndDate", EndDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@AmountFor", AmountFor);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());

            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwPayRpt WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());

            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPayRpt WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());

            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, object val , string AmountFor)
    {
        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPayRpt WHERE {0} = @val AND AmountFor = @AmountFor", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBCommand.Parameters.AddWithValue("@AmountFor", AmountFor);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());

            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwPayRpt>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPayRpt WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwPayRpt PayRpt = new vwPayRpt();

            PayRpt.Guid = new Guid(dr["Guid"].ToString());
            PayRpt.paymenttype = (string)dr["paymenttype"];
            PayRpt.number = int.Parse(dr["number"].ToString());
            PayRpt.refnumber = int.Parse(dr["refnumber"].ToString());

            PayRpt.paydate = (DateTime)dr["paydate"];
            PayRpt.contractno = (int)dr["contractno"];
            PayRpt.land = (string)dr["land"];
            PayRpt.agent = (string)dr["agent"];
            PayRpt.AmountFor = (string)dr["AmountFor"];
            PayRpt.paytype = (string)dr["paytype"];
            PayRpt.bank = (string)dr["bank"];
            PayRpt.checkno = (string)dr["checkno"];
            PayRpt.amount = decimal.Parse(dr["amount"].ToString());
            PayRpt.note = (string)dr["note"];
            PayRpt.status = (string)dr["status"];

            lstData.Add(PayRpt);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwPayRpt FindBy(string dbcolumn, object val)
    {
        vwPayRpt PayRpt = new vwPayRpt();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwPayRpt WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PayRpt.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            PayRpt.paymenttype = (string)DBConnect.DBReader["paymenttype"];
            PayRpt.number = int.Parse(DBConnect.DBReader["number"].ToString());
            PayRpt.refnumber = int.Parse(DBConnect.DBReader["refnumber"].ToString());

            PayRpt.paydate = (DateTime)DBConnect.DBReader["paydate"];
            PayRpt.contractno = (int)DBConnect.DBReader["contractno"];
            PayRpt.land = (string)DBConnect.DBReader["land"];
            PayRpt.agent = (string)DBConnect.DBReader["agent"];
            PayRpt.AmountFor = (string)DBConnect.DBReader["AmountFor"];
            PayRpt.paytype = (string)DBConnect.DBReader["paytype"];
            PayRpt.bank = (string)DBConnect.DBReader["bank"];
            PayRpt.checkno = (string)DBConnect.DBReader["checkno"];
            PayRpt.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            PayRpt.note = (string)DBConnect.DBReader["note"];
            PayRpt.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PayRpt;
    }


   


    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwPayRpt WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwPayRpt", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwPayRpt", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwPayRpt", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwPayRpt WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwPayRpt", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtpaymenttype
dtpaydate
Txtcontractno
Txtland
Txtagent
TxtAmountFor
Txtpaytype
Txtbank
Txtcheckno
Txtamount
Txtnote


*/