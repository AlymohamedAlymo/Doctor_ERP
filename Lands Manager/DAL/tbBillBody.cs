using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;

public class tbBillBody
{

    public static List<tbBillBody> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "PlanGuid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid PlanGuid { get; set; }

    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "contractno", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcontractno")]
    public int contractno { get; set; }
    [DataGUIAttribute(GUIName = "price", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtprice")]
    public decimal price { get; set; }
    [DataGUIAttribute(GUIName = "discounttotaltext", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdiscounttotaltext")]
    public string discounttotaltext { get; set; }
    [DataGUIAttribute(GUIName = "discounttotal", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotal")]
    public decimal discounttotal { get; set; }
    [DataGUIAttribute(GUIName = "discounttotalvalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotalvalue")]
    public decimal discounttotalvalue { get; set; }
    [DataGUIAttribute(GUIName = "buildingfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfeevalue")]
    public decimal buildingfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "workfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfeevalue")]
    public decimal workfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "vatvalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvatvalue")]
    public decimal vatvalue { get; set; }
    [DataGUIAttribute(GUIName = "discountfeetext", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdiscountfeetext")]
    public string discountfeetext { get; set; }
    [DataGUIAttribute(GUIName = "discountfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfee")]
    public decimal discountfee { get; set; }
    [DataGUIAttribute(GUIName = "discountfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfeevalue")]
    public decimal discountfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "total", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "totalnet", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotalnet")]
    public decimal totalnet { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbBillBody VALUES (@PlanGuid, @guid, @parentguid, @landguid, @number, @contractno, @price, @discounttotaltext, @discounttotal, @discounttotalvalue, @buildingfeevalue, @workfeevalue, @vatvalue, @discountfeetext, @discountfee, @discountfeevalue, @total, @totalnet, @note, @status)";

        DBConnect.DBCommand.Parameters.AddWithValue("@PlanGuid", PlanGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@price", price);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotaltext", discounttotaltext);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotal", discounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotalvalue", discounttotalvalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@buildingfeevalue", buildingfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@workfeevalue", workfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@vatvalue", vatvalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfeetext", discountfeetext);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfee", discountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfeevalue", discountfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbBillBody SET parentguid = @parentguid, landguid = @landguid, number = @number, contractno = @contractno, price = @price, discounttotaltext = @discounttotaltext, discounttotal = @discounttotal, discounttotalvalue = @discounttotalvalue, buildingfeevalue = @buildingfeevalue, workfeevalue = @workfeevalue, vatvalue = @vatvalue, discountfeetext = @discountfeetext, discountfee = @discountfee, discountfeevalue = @discountfeevalue, total = @total, totalnet = @totalnet, note = @note , status = @status WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@contractno", contractno);
        DBConnect.DBCommand.Parameters.AddWithValue("@price", price);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotaltext", discounttotaltext);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotal", discounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotalvalue", discounttotalvalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@buildingfeevalue", buildingfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@workfeevalue", workfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@vatvalue", vatvalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfeetext", discountfeetext);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfee", discountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfeevalue", discountfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@totalnet", totalnet);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbBillBody WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbBillBody  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbBillBody";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbBillBody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillBody BillBody = new tbBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbBillBody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillBody BillBody = new tbBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillBody BillBody = new tbBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val , string status)
    {
        lstData = new List<tbBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillBody WHERE {0} = @val AND status = @status", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillBody BillBody = new tbBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbBillBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillBody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbBillBody BillBody = new tbBillBody();

            BillBody.guid = new Guid(dr["guid"].ToString());
            BillBody.parentguid = new Guid(dr["parentguid"].ToString());
            BillBody.landguid = new Guid(dr["landguid"].ToString());
            BillBody.number = (int)dr["number"];
            BillBody.contractno = (int)dr["contractno"];
            BillBody.price = decimal.Parse(dr["price"].ToString());
            BillBody.discounttotaltext = (string)dr["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(dr["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(dr["vatvalue"].ToString());
            BillBody.discountfeetext = (string)dr["discountfeetext"];
            BillBody.discountfee = decimal.Parse(dr["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(dr["total"].ToString());
            BillBody.totalnet = decimal.Parse(dr["totalnet"].ToString());
            BillBody.note = (string)dr["note"];
            BillBody.status = (string)dr["status"];

            lstData.Add(BillBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbBillBody FindBy(string dbcolumn, object val)
    {
        tbBillBody BillBody = new tbBillBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            BillBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            BillBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            BillBody.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            BillBody.number = (int)DBConnect.DBReader["number"];
            BillBody.contractno = (int)DBConnect.DBReader["contractno"];
            BillBody.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            BillBody.discounttotaltext = (string)DBConnect.DBReader["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(DBConnect.DBReader["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            BillBody.discountfeetext = (string)DBConnect.DBReader["discountfeetext"];
            BillBody.discountfee = decimal.Parse(DBConnect.DBReader["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            BillBody.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            BillBody.note = (string)DBConnect.DBReader["note"];
            BillBody.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return BillBody;
    }



    public static tbBillBody FindBy(string dbcolumn, object val, string status)
    {
        tbBillBody BillBody = new tbBillBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbBillBody WHERE {0} = {1} AND status = @status", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            BillBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            BillBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            BillBody.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            BillBody.number = (int)DBConnect.DBReader["number"];
            BillBody.contractno = (int)DBConnect.DBReader["contractno"];
            BillBody.price = decimal.Parse(DBConnect.DBReader["price"].ToString());
            BillBody.discounttotaltext = (string)DBConnect.DBReader["discounttotaltext"];
            BillBody.discounttotal = decimal.Parse(DBConnect.DBReader["discounttotal"].ToString());
            BillBody.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            BillBody.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            BillBody.workfeevalue = decimal.Parse(DBConnect.DBReader["workfeevalue"].ToString());
            BillBody.vatvalue = decimal.Parse(DBConnect.DBReader["vatvalue"].ToString());
            BillBody.discountfeetext = (string)DBConnect.DBReader["discountfeetext"];
            BillBody.discountfee = decimal.Parse(DBConnect.DBReader["discountfee"].ToString());
            BillBody.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());
            BillBody.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            BillBody.totalnet = decimal.Parse(DBConnect.DBReader["totalnet"].ToString());
            BillBody.note = (string)DBConnect.DBReader["note"];
            BillBody.status = (string)DBConnect.DBReader["status"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return BillBody;
    }

    


    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbBillBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbBillBody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbBillBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbBillBody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetMaxNumberTrans(string dbcolumn)
    {
        DBConnect.DBCommand.CommandText = "SELECT COUNT(*) FROM tbBillBody";
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand.CommandText = string.Format("SELECT MAX({0}) FROM tbBillBody", dbcolumn);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetMaxNumberTrans(string dbcolumn , int billtype)
    {
        DBConnect.DBCommand.CommandText = "SELECT COUNT(*) from tbBillBody JOIN tbBillheader ON tbBillBody.parentguid = tbBillheader.guid WHERE tbBillheader.billtype  = @billtype";
        DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        if (icount >= 1)
        {
            DBConnect.DBCommand.CommandText = string.Format("SELECT MAX({0}) from tbBillBody JOIN tbBillheader ON tbBillBody.parentguid = tbBillheader.guid WHERE tbBillheader.billtype  = @billtype", dbcolumn);
            DBConnect.DBCommand.Parameters.AddWithValue("@billtype", billtype);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbBillBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbBillBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtcontractno
Txtprice
Txtdiscounttotaltext
Txtdiscounttotal
Txtdiscounttotalvalue
Txtbuildingfeevalue
Txtworkfeevalue
Txtvatvalue
Txtdiscountfeetext
Txtdiscountfee
Txtdiscountfeevalue
Txttotal
Txttotalnet
Txtnote


*/