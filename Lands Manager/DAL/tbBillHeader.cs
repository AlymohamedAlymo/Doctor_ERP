using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbBillheader
{

    public static List<tbBillheader> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "ownerguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid ownerguid { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "billtype", Formatting = "N0", Visibility = true, Width = 100, ControlName = "")]
    public int billtype { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "ownerdata", Formatting = "", Visibility = true, Width = 100, ControlName = "Cmbownerdata")]
    public string ownerdata { get; set; }
    [DataGUIAttribute(GUIName = "buyerdata", Formatting = "", Visibility = true, Width = 100, ControlName = "Cmbbuyerdata")]
    public string buyerdata { get; set; }
    [DataGUIAttribute(GUIName = "total", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "totaldiscounttotal", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotaldiscounttotal")]
    public decimal totaldiscounttotal { get; set; }
    [DataGUIAttribute(GUIName = "totalbuidlingfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalbuidlingfee")]
    public decimal totalbuidlingfee { get; set; }
    [DataGUIAttribute(GUIName = "totalworkfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalworkfee")]
    public decimal totalworkfee { get; set; }
    [DataGUIAttribute(GUIName = "totalvat", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalvat")]
    public decimal totalvat { get; set; }
    [DataGUIAttribute(GUIName = "totaldiscountfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotaldiscountfee")]
    public decimal totaldiscountfee { get; set; }
    [DataGUIAttribute(GUIName = "totalnet", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "lastaction", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlastaction")]
    public string lastaction { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbBillheader VALUES (@guid, @ownerguid, @buyerguid, @billtype, @number, @regdate, @ownerdata, @buyerdata, @total, @totaldiscounttotal, @totalbuidlingfee, @totalworkfee, @totalvat, @totaldiscountfee, @totalnet, @note , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@ownerguid", ownerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerguid", buyerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@ownerdata", ownerdata);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerdata", buyerdata);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@totaldiscounttotal", totaldiscounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalbuidlingfee", totalbuidlingfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalworkfee", totalworkfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalvat", totalvat);
        DBConnect.DBCommand.Parameters.AddWithValue("@totaldiscountfee", totaldiscountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbBillheader SET ownerguid = @ownerguid, buyerguid = @buyerguid, billtype = @billtype, number = @number, regdate = @regdate, ownerdata = @ownerdata, buyerdata = @buyerdata, total = @total, totaldiscounttotal = @totaldiscounttotal, totalbuidlingfee = @totalbuidlingfee, totalworkfee = @totalworkfee, totalvat = @totalvat, totaldiscountfee = @totaldiscountfee, totalnet = @totalnet, note = @note , lastaction = @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@ownerguid", ownerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerguid", buyerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@ownerdata", ownerdata);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerdata", buyerdata);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@totaldiscounttotal", totaldiscounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalbuidlingfee", totalbuidlingfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalworkfee", totalworkfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalvat", totalvat);
        DBConnect.DBCommand.Parameters.AddWithValue("@totaldiscountfee", totaldiscountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbBillheader WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbBillheader  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbBillheader";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbBillheader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbBillheader", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillheader Billheader = new tbBillheader();

            Billheader.guid = new Guid(dr["guid"].ToString());
            Billheader.ownerguid = new Guid(dr["ownerguid"].ToString());
            Billheader.buyerguid = new Guid(dr["buyerguid"].ToString());
            Billheader.billtype = (int)dr["billtype"];
            Billheader.number = (int)dr["number"];
            Billheader.regdate = (DateTime)dr["regdate"];
            Billheader.ownerdata = (string)dr["ownerdata"];
            Billheader.buyerdata = (string)dr["buyerdata"];
            Billheader.total = decimal.Parse(dr["total"].ToString());
            Billheader.totaldiscounttotal = decimal.Parse(dr["totaldiscounttotal"].ToString());
            Billheader.totalbuidlingfee = decimal.Parse(dr["totalbuidlingfee"].ToString());
            Billheader.totalworkfee = decimal.Parse(dr["totalworkfee"].ToString());
            Billheader.totalvat = decimal.Parse(dr["totalvat"].ToString());
            Billheader.totaldiscountfee = decimal.Parse(dr["totaldiscountfee"].ToString());
            Billheader.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Billheader.note = (string)dr["note"];
            Billheader.lastaction = (string)dr["lastaction"];

            lstData.Add(Billheader);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbBillheader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbBillheader WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillheader Billheader = new tbBillheader();

            Billheader.guid = new Guid(dr["guid"].ToString());
            Billheader.ownerguid = new Guid(dr["ownerguid"].ToString());
            Billheader.buyerguid = new Guid(dr["buyerguid"].ToString());
            Billheader.billtype = (int)dr["billtype"];
            Billheader.number = (int)dr["number"];
            Billheader.regdate = (DateTime)dr["regdate"];
            Billheader.ownerdata = (string)dr["ownerdata"];
            Billheader.buyerdata = (string)dr["buyerdata"];
            Billheader.total = decimal.Parse(dr["total"].ToString());
            Billheader.totaldiscounttotal = decimal.Parse(dr["totaldiscounttotal"].ToString());
            Billheader.totalbuidlingfee = decimal.Parse(dr["totalbuidlingfee"].ToString());
            Billheader.totalworkfee = decimal.Parse(dr["totalworkfee"].ToString());
            Billheader.totalvat = decimal.Parse(dr["totalvat"].ToString());
            Billheader.totaldiscountfee = decimal.Parse(dr["totaldiscountfee"].ToString());
            Billheader.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Billheader.note = (string)dr["note"];
            Billheader.lastaction = (string)dr["lastaction"];

            lstData.Add(Billheader);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbBillheader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillheader WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillheader Billheader = new tbBillheader();

            Billheader.guid = new Guid(dr["guid"].ToString());
            Billheader.ownerguid = new Guid(dr["ownerguid"].ToString());
            Billheader.buyerguid = new Guid(dr["buyerguid"].ToString());
            Billheader.billtype = (int)dr["billtype"];
            Billheader.number = (int)dr["number"];
            Billheader.regdate = (DateTime)dr["regdate"];
            Billheader.ownerdata = (string)dr["ownerdata"];
            Billheader.buyerdata = (string)dr["buyerdata"];
            Billheader.total = decimal.Parse(dr["total"].ToString());
            Billheader.totaldiscounttotal = decimal.Parse(dr["totaldiscounttotal"].ToString());
            Billheader.totalbuidlingfee = decimal.Parse(dr["totalbuidlingfee"].ToString());
            Billheader.totalworkfee = decimal.Parse(dr["totalworkfee"].ToString());
            Billheader.totalvat = decimal.Parse(dr["totalvat"].ToString());
            Billheader.totaldiscountfee = decimal.Parse(dr["totaldiscountfee"].ToString());
            Billheader.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Billheader.note = (string)dr["note"];
            Billheader.lastaction = (string)dr["lastaction"];

            lstData.Add(Billheader);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbBillheader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillheader WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillheader Billheader = new tbBillheader();

            Billheader.guid = new Guid(dr["guid"].ToString());
            Billheader.ownerguid = new Guid(dr["ownerguid"].ToString());
            Billheader.buyerguid = new Guid(dr["buyerguid"].ToString());
            Billheader.billtype = (int)dr["billtype"];
            Billheader.number = (int)dr["number"];
            Billheader.regdate = (DateTime)dr["regdate"];
            Billheader.ownerdata = (string)dr["ownerdata"];
            Billheader.buyerdata = (string)dr["buyerdata"];
            Billheader.total = decimal.Parse(dr["total"].ToString());
            Billheader.totaldiscounttotal = decimal.Parse(dr["totaldiscounttotal"].ToString());
            Billheader.totalbuidlingfee = decimal.Parse(dr["totalbuidlingfee"].ToString());
            Billheader.totalworkfee = decimal.Parse(dr["totalworkfee"].ToString());
            Billheader.totalvat = decimal.Parse(dr["totalvat"].ToString());
            Billheader.totaldiscountfee = decimal.Parse(dr["totaldiscountfee"].ToString());
            Billheader.totalnet = decimal.Parse(dr["totalnet"].ToString());
            Billheader.note = (string)dr["note"];
            Billheader.lastaction = (string)dr["lastaction"];

            lstData.Add(Billheader);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbBillheader FindBy(string dbcolumn, object val)
    {
        tbBillheader Billheader = new tbBillheader();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillheader WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Billheader.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Billheader.ownerguid = new Guid(DBConnect.DBReader["ownerguid"].ToString());
            Billheader.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            Billheader.billtype = (int)DBConnect.DBReader["billtype"];
            Billheader.number = (int)DBConnect.DBReader["number"];
            Billheader.regdate = (DateTime)DBConnect.DBReader["regdate"];
            Billheader.ownerdata = (string)DBConnect.DBReader["ownerdata"];
            Billheader.buyerdata = (string)DBConnect.DBReader["buyerdata"];
            Billheader.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            Billheader.totaldiscounttotal = decimal.Parse(DBConnect.DBReader["totaldiscounttotal"].ToString());
            Billheader.totalbuidlingfee = decimal.Parse(DBConnect.DBReader["totalbuidlingfee"].ToString());
            Billheader.totalworkfee = decimal.Parse(DBConnect.DBReader["totalworkfee"].ToString());
            Billheader.totalvat = decimal.Parse(DBConnect.DBReader["totalvat"].ToString());
            Billheader.totaldiscountfee = decimal.Parse(DBConnect.DBReader["totaldiscountfee"].ToString());
            Billheader.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            Billheader.note = (string)DBConnect.DBReader["note"];
            Billheader.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Billheader;
    }

    public static tbBillheader FindByLast(string dbcolumn, object val)
    {
        tbBillheader Billheader = new tbBillheader();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillheader WHERE {0} = {1} ORDER BY regdate", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Billheader.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Billheader.ownerguid = new Guid(DBConnect.DBReader["ownerguid"].ToString());
            Billheader.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            Billheader.billtype = (int)DBConnect.DBReader["billtype"];
            Billheader.number = (int)DBConnect.DBReader["number"];
            Billheader.regdate = (DateTime)DBConnect.DBReader["regdate"];
            Billheader.ownerdata = (string)DBConnect.DBReader["ownerdata"];
            Billheader.buyerdata = (string)DBConnect.DBReader["buyerdata"];
            Billheader.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            Billheader.totaldiscounttotal = decimal.Parse(DBConnect.DBReader["totaldiscounttotal"].ToString());
            Billheader.totalbuidlingfee = decimal.Parse(DBConnect.DBReader["totalbuidlingfee"].ToString());
            Billheader.totalworkfee = decimal.Parse(DBConnect.DBReader["totalworkfee"].ToString());
            Billheader.totalvat = decimal.Parse(DBConnect.DBReader["totalvat"].ToString());
            Billheader.totaldiscountfee = decimal.Parse(DBConnect.DBReader["totaldiscountfee"].ToString());
            Billheader.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            Billheader.note = (string)DBConnect.DBReader["note"];
            Billheader.lastaction = (string)DBConnect.DBReader["lastaction"];
        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Billheader;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbBillheader WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbBillheader", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbBillheader", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbBillheader", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetMaxNumber(string dbcolumn , int billtype)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbBillheader WHERE billtype = @billtype", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbBillheader WHERE billtype = @billtype", dbcolumn), DBConnect.DBConnection);
            DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbBillheader WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbBillheader", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtbilltype
Txtnumber
dtregdate
Txtownerdata
Txtbuyerdata
Txttotal
Txttotaldiscounttotal
Txttotalbuidlingfee
Txttotalworkfee
Txttotalvat
Txttotaldiscountfee
Txttotalnet
Txtnote


*/