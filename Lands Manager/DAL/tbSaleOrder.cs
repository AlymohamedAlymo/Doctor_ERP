using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbSaleOrder
{

    public static List<tbSaleOrder> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "buyerguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid buyerguid { get; set; }
    [DataGUIAttribute(GUIName = "buyerdata", Formatting = "", Visibility = true, Width = 100, ControlName = "Cmbbuyerdata")]
    public string buyerdata { get; set; }
    [DataGUIAttribute(GUIName = "total", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
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
        DBConnect.DBCommand.CommandText = "INSERT INTO tbSaleOrder VALUES (@guid, @regdate, @number, @buyerguid, @buyerdata, @total, @totalnet, @note , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerguid", buyerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerdata", buyerdata);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbSaleOrder SET regdate = @regdate, number = @number, buyerguid = @buyerguid, buyerdata = @buyerdata, total = @total, totalnet = @totalnet, note = @note , lastaction = @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerguid", buyerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@buyerdata", buyerdata);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbSaleOrder WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbSaleOrder  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbSaleOrder";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbSaleOrder>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbSaleOrder", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrder SaleOrder = new tbSaleOrder();

            SaleOrder.guid = new Guid(dr["guid"].ToString());
            SaleOrder.regdate = (DateTime)dr["regdate"];
            SaleOrder.number = (int)dr["number"];
            SaleOrder.buyerguid = new Guid(dr["buyerguid"].ToString());
            SaleOrder.buyerdata = (string)dr["buyerdata"];
            SaleOrder.total = decimal.Parse(dr["total"].ToString());
            SaleOrder.totalnet = decimal.Parse(dr["totalnet"].ToString());
            SaleOrder.note = (string)dr["note"];
            SaleOrder.lastaction = (string)dr["lastaction"];

            lstData.Add(SaleOrder);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbSaleOrder>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbSaleOrder WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrder SaleOrder = new tbSaleOrder();

            SaleOrder.guid = new Guid(dr["guid"].ToString());
            SaleOrder.regdate = (DateTime)dr["regdate"];
            SaleOrder.number = (int)dr["number"];
            SaleOrder.buyerguid = new Guid(dr["buyerguid"].ToString());
            SaleOrder.buyerdata = (string)dr["buyerdata"];
            SaleOrder.total = decimal.Parse(dr["total"].ToString());
            SaleOrder.totalnet = decimal.Parse(dr["totalnet"].ToString());
            SaleOrder.note = (string)dr["note"];
            SaleOrder.lastaction = (string)dr["lastaction"];

            lstData.Add(SaleOrder);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbSaleOrder>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSaleOrder WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrder SaleOrder = new tbSaleOrder();

            SaleOrder.guid = new Guid(dr["guid"].ToString());
            SaleOrder.regdate = (DateTime)dr["regdate"];
            SaleOrder.number = (int)dr["number"];
            SaleOrder.buyerguid = new Guid(dr["buyerguid"].ToString());
            SaleOrder.buyerdata = (string)dr["buyerdata"];
            SaleOrder.total = decimal.Parse(dr["total"].ToString());
            SaleOrder.totalnet = decimal.Parse(dr["totalnet"].ToString());
            SaleOrder.note = (string)dr["note"];
            SaleOrder.lastaction = (string)dr["lastaction"];

            lstData.Add(SaleOrder);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbSaleOrder>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSaleOrder WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrder SaleOrder = new tbSaleOrder();

            SaleOrder.guid = new Guid(dr["guid"].ToString());
            SaleOrder.regdate = (DateTime)dr["regdate"];
            SaleOrder.number = (int)dr["number"];
            SaleOrder.buyerguid = new Guid(dr["buyerguid"].ToString());
            SaleOrder.buyerdata = (string)dr["buyerdata"];
            SaleOrder.total = decimal.Parse(dr["total"].ToString());
            SaleOrder.totalnet = decimal.Parse(dr["totalnet"].ToString());
            SaleOrder.note = (string)dr["note"];
            SaleOrder.lastaction = (string)dr["lastaction"];

            lstData.Add(SaleOrder);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbSaleOrder FindBy(string dbcolumn, object val)
    {
        tbSaleOrder SaleOrder = new tbSaleOrder();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSaleOrder WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            SaleOrder.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            SaleOrder.regdate = (DateTime)DBConnect.DBReader["regdate"];
            SaleOrder.number = (int)DBConnect.DBReader["number"];
            SaleOrder.buyerguid = new Guid(DBConnect.DBReader["buyerguid"].ToString());
            SaleOrder.buyerdata = (string)DBConnect.DBReader["buyerdata"];
            SaleOrder.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            SaleOrder.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            SaleOrder.note = (string)DBConnect.DBReader["note"];
            SaleOrder.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return SaleOrder;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbSaleOrder WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbSaleOrder", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbSaleOrder", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbSaleOrder", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbSaleOrder WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbSaleOrder", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

dtregdate
Txtnumber
Txtbuyerdata
Txttotal
Txttotalnet
Txtnote


*/