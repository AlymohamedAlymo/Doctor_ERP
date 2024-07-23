using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbTaxDiscount
{

    public static List<tbTaxDiscount> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "isworkfee", Formatting = "", Visibility = true, Width = 100, ControlName = "Chkisworkfee")]
    public bool isworkfee { get; set; }
    [DataGUIAttribute(GUIName = "workfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfee")]
    public decimal workfee { get; set; }
    [DataGUIAttribute(GUIName = "issalefee", Formatting = "", Visibility = true, Width = 100, ControlName = "Chkissalefee")]
    public bool issalefee { get; set; }
    [DataGUIAttribute(GUIName = "salesfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtsalesfee")]
    public decimal salesfee { get; set; }
    [DataGUIAttribute(GUIName = "isbuildingfee", Formatting = "", Visibility = true, Width = 100, ControlName = "Chkisbuildingfee")]
    public bool isbuildingfee { get; set; }
    [DataGUIAttribute(GUIName = "buildingfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfee")]
    public decimal buildingfee { get; set; }
    [DataGUIAttribute(GUIName = "isvat", Formatting = "", Visibility = true, Width = 100, ControlName = "Chkisvat")]
    public bool isvat { get; set; }
    [DataGUIAttribute(GUIName = "vat", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvat")]
    public decimal vat { get; set; }
    [DataGUIAttribute(GUIName = "isdiscounttotal", Formatting = "", Visibility = true, Width = 100, ControlName = "Chkisdiscounttotal")]
    public bool isdiscounttotal { get; set; }
    [DataGUIAttribute(GUIName = "discounttotal", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotal")]
    public decimal discounttotal { get; set; }
    [DataGUIAttribute(GUIName = "discounttotalvalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotalvalue")]
    public decimal discounttotalvalue { get; set; }
    [DataGUIAttribute(GUIName = "isdiscountfee", Formatting = "", Visibility = true, Width = 100, ControlName = "Chkisdiscountfee")]
    public bool isdiscountfee { get; set; }
    [DataGUIAttribute(GUIName = "discountfee", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfee")]
    public decimal discountfee { get; set; }
    [DataGUIAttribute(GUIName = "discountfeevalue", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfeevalue")]
    public decimal discountfeevalue { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbTaxDiscount VALUES (@guid, @isworkfee, @workfee, @issalefee, @salesfee, @isbuildingfee, @buildingfee, @isvat, @vat, @isdiscounttotal, @discounttotal, @discounttotalvalue, @isdiscountfee, @discountfee, @discountfeevalue)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@isworkfee", isworkfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@workfee", workfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@issalefee", issalefee);
        DBConnect.DBCommand.Parameters.AddWithValue("@salesfee", salesfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@isbuildingfee", isbuildingfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@buildingfee", buildingfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@isvat", isvat);
        DBConnect.DBCommand.Parameters.AddWithValue("@vat", vat);
        DBConnect.DBCommand.Parameters.AddWithValue("@isdiscounttotal", isdiscounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotal", discounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotalvalue", discounttotalvalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@isdiscountfee", isdiscountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfee", discountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfeevalue", discountfeevalue);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbTaxDiscount SET isworkfee = @isworkfee, workfee = @workfee, issalefee = @issalefee, salesfee = @salesfee, isbuildingfee = @isbuildingfee, buildingfee = @buildingfee, isvat = @isvat, vat = @vat, isdiscounttotal = @isdiscounttotal, discounttotal = @discounttotal, discounttotalvalue = @discounttotalvalue, isdiscountfee = @isdiscountfee, discountfee = @discountfee, discountfeevalue = @discountfeevalue WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@isworkfee", isworkfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@workfee", workfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@issalefee", issalefee);
        DBConnect.DBCommand.Parameters.AddWithValue("@salesfee", salesfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@isbuildingfee", isbuildingfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@buildingfee", buildingfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@isvat", isvat);
        DBConnect.DBCommand.Parameters.AddWithValue("@vat", vat);
        DBConnect.DBCommand.Parameters.AddWithValue("@isdiscounttotal", isdiscounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotal", discounttotal);
        DBConnect.DBCommand.Parameters.AddWithValue("@discounttotalvalue", discounttotalvalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@isdiscountfee", isdiscountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfee", discountfee);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountfeevalue", discountfeevalue);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbTaxDiscount WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbTaxDiscount  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbTaxDiscount";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbTaxDiscount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbTaxDiscount", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTaxDiscount TaxDiscount = new tbTaxDiscount();

            TaxDiscount.guid = new Guid(dr["guid"].ToString());
            TaxDiscount.isworkfee = (bool)dr["isworkfee"];
            TaxDiscount.workfee = decimal.Parse(dr["workfee"].ToString());
            TaxDiscount.issalefee = (bool)dr["issalefee"];
            TaxDiscount.salesfee = decimal.Parse(dr["salesfee"].ToString());
            TaxDiscount.isbuildingfee = (bool)dr["isbuildingfee"];
            TaxDiscount.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            TaxDiscount.isvat = (bool)dr["isvat"];
            TaxDiscount.vat = decimal.Parse(dr["vat"].ToString());
            TaxDiscount.isdiscounttotal = (bool)dr["isdiscounttotal"];
            TaxDiscount.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            TaxDiscount.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            TaxDiscount.isdiscountfee = (bool)dr["isdiscountfee"];
            TaxDiscount.discountfee = decimal.Parse(dr["discountfee"].ToString());
            TaxDiscount.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());

            lstData.Add(TaxDiscount);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbTaxDiscount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbTaxDiscount WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTaxDiscount TaxDiscount = new tbTaxDiscount();

            TaxDiscount.guid = new Guid(dr["guid"].ToString());
            TaxDiscount.isworkfee = (bool)dr["isworkfee"];
            TaxDiscount.workfee = decimal.Parse(dr["workfee"].ToString());
            TaxDiscount.issalefee = (bool)dr["issalefee"];
            TaxDiscount.salesfee = decimal.Parse(dr["salesfee"].ToString());
            TaxDiscount.isbuildingfee = (bool)dr["isbuildingfee"];
            TaxDiscount.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            TaxDiscount.isvat = (bool)dr["isvat"];
            TaxDiscount.vat = decimal.Parse(dr["vat"].ToString());
            TaxDiscount.isdiscounttotal = (bool)dr["isdiscounttotal"];
            TaxDiscount.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            TaxDiscount.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            TaxDiscount.isdiscountfee = (bool)dr["isdiscountfee"];
            TaxDiscount.discountfee = decimal.Parse(dr["discountfee"].ToString());
            TaxDiscount.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());

            lstData.Add(TaxDiscount);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbTaxDiscount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTaxDiscount WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTaxDiscount TaxDiscount = new tbTaxDiscount();

            TaxDiscount.guid = new Guid(dr["guid"].ToString());
            TaxDiscount.isworkfee = (bool)dr["isworkfee"];
            TaxDiscount.workfee = decimal.Parse(dr["workfee"].ToString());
            TaxDiscount.issalefee = (bool)dr["issalefee"];
            TaxDiscount.salesfee = decimal.Parse(dr["salesfee"].ToString());
            TaxDiscount.isbuildingfee = (bool)dr["isbuildingfee"];
            TaxDiscount.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            TaxDiscount.isvat = (bool)dr["isvat"];
            TaxDiscount.vat = decimal.Parse(dr["vat"].ToString());
            TaxDiscount.isdiscounttotal = (bool)dr["isdiscounttotal"];
            TaxDiscount.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            TaxDiscount.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            TaxDiscount.isdiscountfee = (bool)dr["isdiscountfee"];
            TaxDiscount.discountfee = decimal.Parse(dr["discountfee"].ToString());
            TaxDiscount.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());

            lstData.Add(TaxDiscount);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbTaxDiscount>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTaxDiscount WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbTaxDiscount TaxDiscount = new tbTaxDiscount();

            TaxDiscount.guid = new Guid(dr["guid"].ToString());
            TaxDiscount.isworkfee = (bool)dr["isworkfee"];
            TaxDiscount.workfee = decimal.Parse(dr["workfee"].ToString());
            TaxDiscount.issalefee = (bool)dr["issalefee"];
            TaxDiscount.salesfee = decimal.Parse(dr["salesfee"].ToString());
            TaxDiscount.isbuildingfee = (bool)dr["isbuildingfee"];
            TaxDiscount.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            TaxDiscount.isvat = (bool)dr["isvat"];
            TaxDiscount.vat = decimal.Parse(dr["vat"].ToString());
            TaxDiscount.isdiscounttotal = (bool)dr["isdiscounttotal"];
            TaxDiscount.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            TaxDiscount.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            TaxDiscount.isdiscountfee = (bool)dr["isdiscountfee"];
            TaxDiscount.discountfee = decimal.Parse(dr["discountfee"].ToString());
            TaxDiscount.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());

            lstData.Add(TaxDiscount);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbTaxDiscount FindBy(string dbcolumn, object val)
    {
        tbTaxDiscount TaxDiscount = new tbTaxDiscount();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbTaxDiscount WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            TaxDiscount.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            TaxDiscount.isworkfee = (bool)DBConnect.DBReader["isworkfee"];
            TaxDiscount.workfee = decimal.Parse(DBConnect.DBReader["workfee"].ToString());
            TaxDiscount.issalefee = (bool)DBConnect.DBReader["issalefee"];
            TaxDiscount.salesfee = decimal.Parse(DBConnect.DBReader["salesfee"].ToString());
            TaxDiscount.isbuildingfee = (bool)DBConnect.DBReader["isbuildingfee"];
            TaxDiscount.buildingfee = decimal.Parse(DBConnect.DBReader["buildingfee"].ToString());
            TaxDiscount.isvat = (bool)DBConnect.DBReader["isvat"];
            TaxDiscount.vat = decimal.Parse(DBConnect.DBReader["vat"].ToString());
            TaxDiscount.isdiscounttotal = (bool)DBConnect.DBReader["isdiscounttotal"];
            TaxDiscount.discounttotal = decimal.Parse(DBConnect.DBReader["discounttotal"].ToString());
            TaxDiscount.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            TaxDiscount.isdiscountfee = (bool)DBConnect.DBReader["isdiscountfee"];
            TaxDiscount.discountfee = decimal.Parse(DBConnect.DBReader["discountfee"].ToString());
            TaxDiscount.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return TaxDiscount;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbTaxDiscount WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbTaxDiscount", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbTaxDiscount", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbTaxDiscount", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbTaxDiscount WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbTaxDiscount", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Chkisworkfee
Txtworkfee
Chkissalefee
Txtsalesfee
Chkisbuildingfee
Txtbuildingfee
Chkisvat
Txtvat
Chkisdiscounttotal
Txtdiscounttotal
Txtdiscounttotalvalue
Chkisdiscountfee
Txtdiscountfee
Txtdiscountfeevalue


*/