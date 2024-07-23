using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwSaleOrderBody
{

    public static List<vwSaleOrderBody> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "code", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "land", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "price", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "total", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO vwSaleOrderBody VALUES (@guid, @parentguid, @number, @code, @land, @price, @total, @note, @status)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
        DBConnect.DBCommand.Parameters.AddWithValue("@land", land);
        DBConnect.DBCommand.Parameters.AddWithValue("@price", price);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE vwSaleOrderBody SET parentguid = @parentguid, number = @number, code = @code, land = @land, price = @price, total = @total, note = @note, status = @status WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
        DBConnect.DBCommand.Parameters.AddWithValue("@land", land);
        DBConnect.DBCommand.Parameters.AddWithValue("@price", price);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwSaleOrderBody WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM vwSaleOrderBody  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwSaleOrderBody";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<vwSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSaleOrderBody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSaleOrderBody SaleOrderBody = new vwSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.code = (int)dr["code"];
            SaleOrderBody.land = (string)dr["land"];
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwSaleOrderBody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSaleOrderBody SaleOrderBody = new vwSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.code = (int)dr["code"];
            SaleOrderBody.land = (string)dr["land"];
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val, DataTable privatebillBody)
    {
        lstData = new List<vwSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSaleOrderBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(privatebillBody);
        foreach (DataRow dr in privatebillBody.Rows)
        {


            vwSaleOrderBody SaleOrderBody = new vwSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.code = (int)dr["code"];
            SaleOrderBody.land = (string)dr["land"];
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSaleOrderBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSaleOrderBody SaleOrderBody = new vwSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.code = (int)dr["code"];
            SaleOrderBody.land = (string)dr["land"];
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSaleOrderBody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwSaleOrderBody SaleOrderBody = new vwSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.code = (int)dr["code"];
            SaleOrderBody.land = (string)dr["land"];
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwSaleOrderBody FindBy(string dbcolumn, object val)
    {
        vwSaleOrderBody SaleOrderBody = new vwSaleOrderBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwSaleOrderBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            SaleOrderBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            SaleOrderBody.number = (int)DBConnect.DBReader["number"];
            SaleOrderBody.code = (int)DBConnect.DBReader["code"];
            SaleOrderBody.land = (string)DBConnect.DBReader["land"];
            SaleOrderBody.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            SaleOrderBody.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            SaleOrderBody.note = (string)DBConnect.DBReader["note"];
            SaleOrderBody.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return SaleOrderBody;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwSaleOrderBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwSaleOrderBody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwSaleOrderBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwSaleOrderBody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwSaleOrderBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwSaleOrderBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcode
Txtland
Txtprice
Txttotal
Txtnote
Txtstatus


*/