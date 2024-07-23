using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbSaleOrderBody
{

    public static List<tbSaleOrderBody> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
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
        DBConnect.DBCommand.CommandText = "INSERT INTO tbSaleOrderBody VALUES (@guid, @parentguid, @number, @landguid, @price, @total, @note, @status)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@price", price);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbSaleOrderBody SET parentguid = @parentguid, number = @number, landguid = @landguid, price = @price, total = @total, note = @note, status = @status WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
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
        DBConnect.DBCommand.CommandText = "DELETE FROM tbSaleOrderBody WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbSaleOrderBody  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbSaleOrderBody";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbSaleOrderBody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrderBody SaleOrderBody = new tbSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.landguid = new Guid(dr["landguid"].ToString());
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbSaleOrderBody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrderBody SaleOrderBody = new tbSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.landguid = new Guid(dr["landguid"].ToString());
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
        lstData = new List<tbSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSaleOrderBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrderBody SaleOrderBody = new tbSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.landguid = new Guid(dr["landguid"].ToString());
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

        lstData = new List<tbSaleOrderBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSaleOrderBody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSaleOrderBody SaleOrderBody = new tbSaleOrderBody();

            SaleOrderBody.guid = new Guid(dr["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(dr["parentguid"].ToString());
            SaleOrderBody.number = (int)dr["number"];
            SaleOrderBody.landguid = new Guid(dr["landguid"].ToString());
            SaleOrderBody.price = decimal.Parse(dr["price"].ToString());
            SaleOrderBody.total = decimal.Parse(dr["total"].ToString());
            SaleOrderBody.note = (string)dr["note"];
            SaleOrderBody.status = (string)dr["status"];

            lstData.Add(SaleOrderBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbSaleOrderBody FindBy(string dbcolumn, object val)
    {
        tbSaleOrderBody SaleOrderBody = new tbSaleOrderBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSaleOrderBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            SaleOrderBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            SaleOrderBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            SaleOrderBody.number = (int)DBConnect.DBReader["number"];
            SaleOrderBody.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
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
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbSaleOrderBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbSaleOrderBody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbSaleOrderBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbSaleOrderBody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbSaleOrderBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbSaleOrderBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtprice
Txttotal
Txtnote
Txtstatus


*/