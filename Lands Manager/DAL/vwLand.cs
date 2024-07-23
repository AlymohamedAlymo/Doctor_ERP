using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwLand
{

    public static List<vwLand> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "PlanGuid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid PlanGuid { get; set; }

    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "نوع الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "CmbLandType")]
    public string landtype { get; set; }
    [DataGUIAttribute(GUIName = "المساحة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtarea")]
    public decimal area { get; set; }
    [DataGUIAttribute(GUIName = "رقم الصك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdeednumber")]
    public string deednumber { get; set; }
    [DataGUIAttribute(GUIName = "القيمة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamount")]
    public decimal amount { get; set; }
    [DataGUIAttribute(GUIName = "isworkfee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisworkfee")]
    public bool isworkfee { get; set; }
    [DataGUIAttribute(GUIName = "عمولة السعي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtworkfee")]
    public decimal workfee { get; set; }
    [DataGUIAttribute(GUIName = "issalefee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkissalefee")]
    public bool issalefee { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة المبيعات", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtsalesfee")]
    public decimal salesfee { get; set; }
    [DataGUIAttribute(GUIName = "isbuildingfee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisbuildingfee")]
    public bool isbuildingfee { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة التصرفات العقارية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfee")]
    public decimal buildingfee { get; set; }
    [DataGUIAttribute(GUIName = "isvat", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisvat")]
    public bool isvat { get; set; }
    [DataGUIAttribute(GUIName = "ضريبة مضافة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtvat")]
    public decimal vat { get; set; }
    [DataGUIAttribute(GUIName = "isdiscounttotal", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisdiscounttotal")]
    public bool isdiscounttotal { get; set; }
    [DataGUIAttribute(GUIName = "خصم نسبة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotal")]
    public decimal discounttotal { get; set; }
    [DataGUIAttribute(GUIName = "خصم قيمة الأرض", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscounttotalvalue")]
    public decimal discounttotalvalue { get; set; }
    [DataGUIAttribute(GUIName = "isdiscountfee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisdiscountfee")]
    public bool isdiscountfee { get; set; }
    [DataGUIAttribute(GUIName = "خصم نسبة العمولة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfee")]
    public decimal discountfee { get; set; }
    [DataGUIAttribute(GUIName = "خصم قيمة العمولة", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtdiscountfeevalue")]
    public decimal discountfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "الإجمالي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "جنوب", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtsouth")]
    public string south { get; set; }
    [DataGUIAttribute(GUIName = "جنوب وصف", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtsouthdesc")]
    public string southdesc { get; set; }
    [DataGUIAttribute(GUIName = "شمال", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnorth")]
    public string north { get; set; }
    [DataGUIAttribute(GUIName = "شمال وصف", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnorthdesc")]
    public string northdesc { get; set; }
    [DataGUIAttribute(GUIName = "شرق", Formatting = "", Visibility = true, Width = 100, ControlName = "Txteast")]
    public string east { get; set; }
    [DataGUIAttribute(GUIName = "شرق وصف", Formatting = "", Visibility = true, Width = 100, ControlName = "Txteastdesc")]
    public string eastdesc { get; set; }
    [DataGUIAttribute(GUIName = "غرب", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtwest")]
    public string west { get; set; }
    [DataGUIAttribute(GUIName = "غرب وصف", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtwestdesc")]
    public string westdesc { get; set; }
    [DataGUIAttribute(GUIName = "الحالة", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }
    [DataGUIAttribute(GUIName = "سبب الحجز", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtreservereason")]
    public string reservereason { get; set; }

    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "أخر عملية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlastaction")]
    public string lastaction { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLand", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLand Land = new vwLand();

            Land.PlanGuid = new Guid(dr["PlanGuid"].ToString());
            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = int.Parse(dr["code"].ToString());
            Land.blocknumber = (string)dr["blocknumber"];
            Land.landtype = (string)dr["landtype"];
            Land.area = decimal.Parse(dr["area"].ToString());
            Land.deednumber = (string)dr["deednumber"];
            Land.amount = decimal.Parse(dr["amount"].ToString());
            Land.isworkfee = (bool)dr["isworkfee"];
            Land.workfee = decimal.Parse(dr["workfee"].ToString());
            Land.issalefee = (bool)dr["issalefee"];
            Land.salesfee = decimal.Parse(dr["salesfee"].ToString());
            Land.isbuildingfee = (bool)dr["isbuildingfee"];
            Land.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            Land.isvat = (bool)dr["isvat"];
            Land.vat = decimal.Parse(dr["vat"].ToString());
            Land.isdiscounttotal = (bool)dr["isdiscounttotal"];
            Land.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            Land.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            Land.isdiscountfee = (bool)dr["isdiscountfee"];
            Land.discountfee = decimal.Parse(dr["discountfee"].ToString());
            Land.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            Land.total = decimal.Parse(dr["total"].ToString());
            Land.south = (string)dr["south"];
            Land.southdesc = (string)dr["southdesc"];
            Land.north = (string)dr["north"];
            Land.northdesc = (string)dr["northdesc"];
            Land.east = (string)dr["east"];
            Land.eastdesc = (string)dr["eastdesc"];
            Land.west = (string)dr["west"];
            Land.westdesc = (string)dr["westdesc"];
            Land.status = (string)dr["status"];
            Land.reservereason = (string)dr["reservereason"];
            Land.note = (string)dr["note"];

            lstData.Add(Land);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLand WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLand Land = new vwLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = (string)dr["blocknumber"];
            Land.landtype = (string)dr["landtype"];
            Land.area = decimal.Parse(dr["area"].ToString());
            Land.deednumber = (string)dr["deednumber"];
            Land.amount = decimal.Parse(dr["amount"].ToString());
            Land.isworkfee = (bool)dr["isworkfee"];
            Land.workfee = decimal.Parse(dr["workfee"].ToString());
            Land.issalefee = (bool)dr["issalefee"];
            Land.salesfee = decimal.Parse(dr["salesfee"].ToString());
            Land.isbuildingfee = (bool)dr["isbuildingfee"];
            Land.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            Land.isvat = (bool)dr["isvat"];
            Land.vat = decimal.Parse(dr["vat"].ToString());
            Land.isdiscounttotal = (bool)dr["isdiscounttotal"];
            Land.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            Land.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            Land.isdiscountfee = (bool)dr["isdiscountfee"];
            Land.discountfee = decimal.Parse(dr["discountfee"].ToString());
            Land.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            Land.total = decimal.Parse(dr["total"].ToString());
            Land.south = (string)dr["south"];
            Land.southdesc = (string)dr["southdesc"];
            Land.north = (string)dr["north"];
            Land.northdesc = (string)dr["northdesc"];
            Land.east = (string)dr["east"];
            Land.eastdesc = (string)dr["eastdesc"];
            Land.west = (string)dr["west"];
            Land.westdesc = (string)dr["westdesc"];
            Land.status = (string)dr["status"];
            Land.reservereason = (string)dr["reservereason"];

            Land.note = (string)dr["note"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLand WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLand Land = new vwLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = (string)dr["blocknumber"];
            Land.landtype = (string)dr["landtype"];
            Land.area = decimal.Parse(dr["area"].ToString());
            Land.deednumber = (string)dr["deednumber"];
            Land.amount = decimal.Parse(dr["amount"].ToString());
            Land.isworkfee = (bool)dr["isworkfee"];
            Land.workfee = decimal.Parse(dr["workfee"].ToString());
            Land.issalefee = (bool)dr["issalefee"];
            Land.salesfee = decimal.Parse(dr["salesfee"].ToString());
            Land.isbuildingfee = (bool)dr["isbuildingfee"];
            Land.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            Land.isvat = (bool)dr["isvat"];
            Land.vat = decimal.Parse(dr["vat"].ToString());
            Land.isdiscounttotal = (bool)dr["isdiscounttotal"];
            Land.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            Land.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            Land.isdiscountfee = (bool)dr["isdiscountfee"];
            Land.discountfee = decimal.Parse(dr["discountfee"].ToString());
            Land.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            Land.total = decimal.Parse(dr["total"].ToString());
            Land.south = (string)dr["south"];
            Land.southdesc = (string)dr["southdesc"];
            Land.north = (string)dr["north"];
            Land.northdesc = (string)dr["northdesc"];
            Land.east = (string)dr["east"];
            Land.eastdesc = (string)dr["eastdesc"];
            Land.west = (string)dr["west"];
            Land.westdesc = (string)dr["westdesc"];
            Land.status = (string)dr["status"];
            Land.reservereason = (string)dr["reservereason"];

            Land.note = (string)dr["note"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLand WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLand Land = new vwLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = (string)dr["blocknumber"];
            Land.landtype = (string)dr["landtype"];
            Land.area = decimal.Parse(dr["area"].ToString());
            Land.deednumber = (string)dr["deednumber"];
            Land.amount = decimal.Parse(dr["amount"].ToString());
            Land.isworkfee = (bool)dr["isworkfee"];
            Land.workfee = decimal.Parse(dr["workfee"].ToString());
            Land.issalefee = (bool)dr["issalefee"];
            Land.salesfee = decimal.Parse(dr["salesfee"].ToString());
            Land.isbuildingfee = (bool)dr["isbuildingfee"];
            Land.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            Land.isvat = (bool)dr["isvat"];
            Land.vat = decimal.Parse(dr["vat"].ToString());
            Land.isdiscounttotal = (bool)dr["isdiscounttotal"];
            Land.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            Land.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            Land.isdiscountfee = (bool)dr["isdiscountfee"];
            Land.discountfee = decimal.Parse(dr["discountfee"].ToString());
            Land.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            Land.total = decimal.Parse(dr["total"].ToString());
            Land.south = (string)dr["south"];
            Land.southdesc = (string)dr["southdesc"];
            Land.north = (string)dr["north"];
            Land.northdesc = (string)dr["northdesc"];
            Land.east = (string)dr["east"];
            Land.eastdesc = (string)dr["eastdesc"];
            Land.west = (string)dr["west"];
            Land.westdesc = (string)dr["westdesc"];
            Land.status = (string)dr["status"];
            Land.reservereason = (string)dr["reservereason"];

            Land.note = (string)dr["note"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void FillOrderByBlock(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLand WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLand Land = new vwLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = (string)dr["blocknumber"];
            Land.landtype = (string)dr["landtype"];
            Land.area = decimal.Parse(dr["area"].ToString());
            Land.deednumber = (string)dr["deednumber"];
            Land.amount = decimal.Parse(dr["amount"].ToString());
            Land.isworkfee = (bool)dr["isworkfee"];
            Land.workfee = decimal.Parse(dr["workfee"].ToString());
            Land.issalefee = (bool)dr["issalefee"];
            Land.salesfee = decimal.Parse(dr["salesfee"].ToString());
            Land.isbuildingfee = (bool)dr["isbuildingfee"];
            Land.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            Land.isvat = (bool)dr["isvat"];
            Land.vat = decimal.Parse(dr["vat"].ToString());
            Land.isdiscounttotal = (bool)dr["isdiscounttotal"];
            Land.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            Land.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            Land.isdiscountfee = (bool)dr["isdiscountfee"];
            Land.discountfee = decimal.Parse(dr["discountfee"].ToString());
            Land.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            Land.total = decimal.Parse(dr["total"].ToString());
            Land.south = (string)dr["south"];
            Land.southdesc = (string)dr["southdesc"];
            Land.north = (string)dr["north"];
            Land.northdesc = (string)dr["northdesc"];
            Land.east = (string)dr["east"];
            Land.eastdesc = (string)dr["eastdesc"];
            Land.west = (string)dr["west"];
            Land.westdesc = (string)dr["westdesc"];
            Land.status = (string)dr["status"];
            Land.reservereason = (string)dr["reservereason"];

            Land.note = (string)dr["note"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwLand FindBy(string dbcolumn, object val)
    {
        vwLand Land = new vwLand();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Land.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Land.number = (int)DBConnect.DBReader["number"];
            Land.code = (int)DBConnect.DBReader["code"];
            Land.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            Land.landtype = (string)DBConnect.DBReader["landtype"];
            Land.area = decimal.Parse(DBConnect.DBReader["area"].ToString());
            Land.deednumber = (string)DBConnect.DBReader["deednumber"];
            Land.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            Land.isworkfee = (bool)DBConnect.DBReader["isworkfee"];
            Land.workfee = decimal.Parse(DBConnect.DBReader["workfee"].ToString());
            Land.issalefee = (bool)DBConnect.DBReader["issalefee"];
            Land.salesfee = decimal.Parse(DBConnect.DBReader["salesfee"].ToString());
            Land.isbuildingfee = (bool)DBConnect.DBReader["isbuildingfee"];
            Land.buildingfee = decimal.Parse(DBConnect.DBReader["buildingfee"].ToString());
            Land.isvat = (bool)DBConnect.DBReader["isvat"];
            Land.vat = decimal.Parse(DBConnect.DBReader["vat"].ToString());
            Land.isdiscounttotal = (bool)DBConnect.DBReader["isdiscounttotal"];
            Land.discounttotal = decimal.Parse(DBConnect.DBReader["discounttotal"].ToString());
            Land.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            Land.isdiscountfee = (bool)DBConnect.DBReader["isdiscountfee"];
            Land.discountfee = decimal.Parse(DBConnect.DBReader["discountfee"].ToString());
            Land.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());
            Land.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            Land.south = (string)DBConnect.DBReader["south"];
            Land.southdesc = (string)DBConnect.DBReader["southdesc"];
            Land.north = (string)DBConnect.DBReader["north"];
            Land.northdesc = (string)DBConnect.DBReader["northdesc"];
            Land.east = (string)DBConnect.DBReader["east"];
            Land.eastdesc = (string)DBConnect.DBReader["eastdesc"];
            Land.west = (string)DBConnect.DBReader["west"];
            Land.westdesc = (string)DBConnect.DBReader["westdesc"];
            Land.status = (string)DBConnect.DBReader["status"];
            Land.reservereason = (string)DBConnect.DBReader["reservereason"];

            Land.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Land;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwLand", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLand", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwLand", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwLand WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLand", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtcode
Txtblocknumber
Txtarea
Txtdeednumber
Txtamount
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
Txttotal
Txtsouth
Txtsouthdesc
Txtnorth
Txtnorthdesc
Txteast
Txteastdesc
Txtwest
Txtwestdesc
Txtstatus
Txtnote


*/