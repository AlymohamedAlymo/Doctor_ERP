using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwLandMainFiller
{

    public static List<vwLandMainFiller> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "code", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "blocknumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public string blocknumber { get; set; }
    [DataGUIAttribute(GUIName = "landtype", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlandtype")]
    public string landtype { get; set; }
    [DataGUIAttribute(GUIName = "area", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtarea")]
    public decimal area { get; set; }
    [DataGUIAttribute(GUIName = "deednumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdeednumber")]
    public string deednumber { get; set; }
    [DataGUIAttribute(GUIName = "amount", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtamount")]
    public decimal amount { get; set; }
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
    [DataGUIAttribute(GUIName = "total", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "south", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtsouth")]
    public string south { get; set; }
    [DataGUIAttribute(GUIName = "southdesc", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtsouthdesc")]
    public string southdesc { get; set; }
    [DataGUIAttribute(GUIName = "north", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnorth")]
    public string north { get; set; }
    [DataGUIAttribute(GUIName = "northdesc", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnorthdesc")]
    public string northdesc { get; set; }
    [DataGUIAttribute(GUIName = "east", Formatting = "", Visibility = true, Width = 100, ControlName = "Txteast")]
    public string east { get; set; }
    [DataGUIAttribute(GUIName = "eastdesc", Formatting = "", Visibility = true, Width = 100, ControlName = "Txteastdesc")]
    public string eastdesc { get; set; }
    [DataGUIAttribute(GUIName = "west", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtwest")]
    public string west { get; set; }
    [DataGUIAttribute(GUIName = "westdesc", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtwestdesc")]
    public string westdesc { get; set; }
    [DataGUIAttribute(GUIName = "status", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }
    [DataGUIAttribute(GUIName = "reservereason", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtreservereason")]
    public string reservereason { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO vwLandMainFiller VALUES (@guid, @code, @number, @blocknumber, @landtype, @area, @deednumber, @amount, @isworkfee, @workfee, @issalefee, @salesfee, @isbuildingfee, @buildingfee, @isvat, @vat, @isdiscounttotal, @discounttotal, @discounttotalvalue, @isdiscountfee, @discountfee, @discountfeevalue, @total, @south, @southdesc, @north, @northdesc, @east, @eastdesc, @west, @westdesc, @status, @reservereason, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@blocknumber", blocknumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@landtype", landtype);
        DBConnect.DBCommand.Parameters.AddWithValue("@area", area);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
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
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@south", south);
        DBConnect.DBCommand.Parameters.AddWithValue("@southdesc", southdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@north", north);
        DBConnect.DBCommand.Parameters.AddWithValue("@northdesc", northdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@east", east);
        DBConnect.DBCommand.Parameters.AddWithValue("@eastdesc", eastdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@west", west);
        DBConnect.DBCommand.Parameters.AddWithValue("@westdesc", westdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBCommand.Parameters.AddWithValue("@reservereason", reservereason);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE vwLandMainFiller SET code = @code, number = @number, blocknumber = @blocknumber, landtype = @landtype, area = @area, deednumber = @deednumber, amount = @amount, isworkfee = @isworkfee, workfee = @workfee, issalefee = @issalefee, salesfee = @salesfee, isbuildingfee = @isbuildingfee, buildingfee = @buildingfee, isvat = @isvat, vat = @vat, isdiscounttotal = @isdiscounttotal, discounttotal = @discounttotal, discounttotalvalue = @discounttotalvalue, isdiscountfee = @isdiscountfee, discountfee = @discountfee, discountfeevalue = @discountfeevalue, total = @total, south = @south, southdesc = @southdesc, north = @north, northdesc = @northdesc, east = @east, eastdesc = @eastdesc, west = @west, westdesc = @westdesc, status = @status, reservereason = @reservereason, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@blocknumber", blocknumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@landtype", landtype);
        DBConnect.DBCommand.Parameters.AddWithValue("@area", area);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@amount", amount);
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
        DBConnect.DBCommand.Parameters.AddWithValue("@total", total);
        DBConnect.DBCommand.Parameters.AddWithValue("@south", south);
        DBConnect.DBCommand.Parameters.AddWithValue("@southdesc", southdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@north", north);
        DBConnect.DBCommand.Parameters.AddWithValue("@northdesc", northdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@east", east);
        DBConnect.DBCommand.Parameters.AddWithValue("@eastdesc", eastdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@west", west);
        DBConnect.DBCommand.Parameters.AddWithValue("@westdesc", westdesc);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBCommand.Parameters.AddWithValue("@reservereason", reservereason);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwLandMainFiller WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM vwLandMainFiller  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwLandMainFiller";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<vwLandMainFiller>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandMainFiller ", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandMainFiller LandMainFiller = new vwLandMainFiller();

            LandMainFiller.guid = new Guid(dr["guid"].ToString());
            LandMainFiller.code = (int)dr["code"];
            LandMainFiller.number = (int)dr["number"];
            LandMainFiller.blocknumber = (string)dr["blocknumber"];
            LandMainFiller.landtype = (string)dr["landtype"];
            LandMainFiller.area = decimal.Parse(dr["area"].ToString());
            LandMainFiller.deednumber = (string)dr["deednumber"];
            LandMainFiller.amount = decimal.Parse(dr["amount"].ToString());
            LandMainFiller.isworkfee = (bool)dr["isworkfee"];
            LandMainFiller.workfee = decimal.Parse(dr["workfee"].ToString());
            LandMainFiller.issalefee = (bool)dr["issalefee"];
            LandMainFiller.salesfee = decimal.Parse(dr["salesfee"].ToString());
            LandMainFiller.isbuildingfee = (bool)dr["isbuildingfee"];
            LandMainFiller.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            LandMainFiller.isvat = (bool)dr["isvat"];
            LandMainFiller.vat = decimal.Parse(dr["vat"].ToString());
            LandMainFiller.isdiscounttotal = (bool)dr["isdiscounttotal"];
            LandMainFiller.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            LandMainFiller.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            LandMainFiller.isdiscountfee = (bool)dr["isdiscountfee"];
            LandMainFiller.discountfee = decimal.Parse(dr["discountfee"].ToString());
            LandMainFiller.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            LandMainFiller.total = decimal.Parse(dr["total"].ToString());
            LandMainFiller.south = (string)dr["south"];
            LandMainFiller.southdesc = (string)dr["southdesc"];
            LandMainFiller.north = (string)dr["north"];
            LandMainFiller.northdesc = (string)dr["northdesc"];
            LandMainFiller.east = (string)dr["east"];
            LandMainFiller.eastdesc = (string)dr["eastdesc"];
            LandMainFiller.west = (string)dr["west"];
            LandMainFiller.westdesc = (string)dr["westdesc"];
            LandMainFiller.status = (string)dr["status"];
            LandMainFiller.reservereason = (string)dr["reservereason"];
            LandMainFiller.note = (string)dr["note"];

            lstData.Add(LandMainFiller);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwLandMainFiller>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandMainFiller WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandMainFiller LandMainFiller = new vwLandMainFiller();

            LandMainFiller.guid = new Guid(dr["guid"].ToString());
            LandMainFiller.code = (int)dr["code"];
            LandMainFiller.number = (int)dr["number"];
            LandMainFiller.blocknumber = (string)dr["blocknumber"];
            LandMainFiller.landtype = (string)dr["landtype"];
            LandMainFiller.area = decimal.Parse(dr["area"].ToString());
            LandMainFiller.deednumber = (string)dr["deednumber"];
            LandMainFiller.amount = decimal.Parse(dr["amount"].ToString());
            LandMainFiller.isworkfee = (bool)dr["isworkfee"];
            LandMainFiller.workfee = decimal.Parse(dr["workfee"].ToString());
            LandMainFiller.issalefee = (bool)dr["issalefee"];
            LandMainFiller.salesfee = decimal.Parse(dr["salesfee"].ToString());
            LandMainFiller.isbuildingfee = (bool)dr["isbuildingfee"];
            LandMainFiller.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            LandMainFiller.isvat = (bool)dr["isvat"];
            LandMainFiller.vat = decimal.Parse(dr["vat"].ToString());
            LandMainFiller.isdiscounttotal = (bool)dr["isdiscounttotal"];
            LandMainFiller.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            LandMainFiller.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            LandMainFiller.isdiscountfee = (bool)dr["isdiscountfee"];
            LandMainFiller.discountfee = decimal.Parse(dr["discountfee"].ToString());
            LandMainFiller.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            LandMainFiller.total = decimal.Parse(dr["total"].ToString());
            LandMainFiller.south = (string)dr["south"];
            LandMainFiller.southdesc = (string)dr["southdesc"];
            LandMainFiller.north = (string)dr["north"];
            LandMainFiller.northdesc = (string)dr["northdesc"];
            LandMainFiller.east = (string)dr["east"];
            LandMainFiller.eastdesc = (string)dr["eastdesc"];
            LandMainFiller.west = (string)dr["west"];
            LandMainFiller.westdesc = (string)dr["westdesc"];
            LandMainFiller.status = (string)dr["status"];
            LandMainFiller.reservereason = (string)dr["reservereason"];
            LandMainFiller.note = (string)dr["note"];

            lstData.Add(LandMainFiller);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwLandMainFiller>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandMainFiller WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandMainFiller LandMainFiller = new vwLandMainFiller();

            LandMainFiller.guid = new Guid(dr["guid"].ToString());
            LandMainFiller.code = (int)dr["code"];
            LandMainFiller.number = (int)dr["number"];
            LandMainFiller.blocknumber = (string)dr["blocknumber"];
            LandMainFiller.landtype = (string)dr["landtype"];
            LandMainFiller.area = decimal.Parse(dr["area"].ToString());
            LandMainFiller.deednumber = (string)dr["deednumber"];
            LandMainFiller.amount = decimal.Parse(dr["amount"].ToString());
            LandMainFiller.isworkfee = (bool)dr["isworkfee"];
            LandMainFiller.workfee = decimal.Parse(dr["workfee"].ToString());
            LandMainFiller.issalefee = (bool)dr["issalefee"];
            LandMainFiller.salesfee = decimal.Parse(dr["salesfee"].ToString());
            LandMainFiller.isbuildingfee = (bool)dr["isbuildingfee"];
            LandMainFiller.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            LandMainFiller.isvat = (bool)dr["isvat"];
            LandMainFiller.vat = decimal.Parse(dr["vat"].ToString());
            LandMainFiller.isdiscounttotal = (bool)dr["isdiscounttotal"];
            LandMainFiller.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            LandMainFiller.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            LandMainFiller.isdiscountfee = (bool)dr["isdiscountfee"];
            LandMainFiller.discountfee = decimal.Parse(dr["discountfee"].ToString());
            LandMainFiller.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            LandMainFiller.total = decimal.Parse(dr["total"].ToString());
            LandMainFiller.south = (string)dr["south"];
            LandMainFiller.southdesc = (string)dr["southdesc"];
            LandMainFiller.north = (string)dr["north"];
            LandMainFiller.northdesc = (string)dr["northdesc"];
            LandMainFiller.east = (string)dr["east"];
            LandMainFiller.eastdesc = (string)dr["eastdesc"];
            LandMainFiller.west = (string)dr["west"];
            LandMainFiller.westdesc = (string)dr["westdesc"];
            LandMainFiller.status = (string)dr["status"];
            LandMainFiller.reservereason = (string)dr["reservereason"];
            LandMainFiller.note = (string)dr["note"];

            lstData.Add(LandMainFiller);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLandMainFiller>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandMainFiller WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandMainFiller LandMainFiller = new vwLandMainFiller();

            LandMainFiller.guid = new Guid(dr["guid"].ToString());
            LandMainFiller.code = (int)dr["code"];
            LandMainFiller.number = (int)dr["number"];
            LandMainFiller.blocknumber = (string)dr["blocknumber"];
            LandMainFiller.landtype = (string)dr["landtype"];
            LandMainFiller.area = decimal.Parse(dr["area"].ToString());
            LandMainFiller.deednumber = (string)dr["deednumber"];
            LandMainFiller.amount = decimal.Parse(dr["amount"].ToString());
            LandMainFiller.isworkfee = (bool)dr["isworkfee"];
            LandMainFiller.workfee = decimal.Parse(dr["workfee"].ToString());
            LandMainFiller.issalefee = (bool)dr["issalefee"];
            LandMainFiller.salesfee = decimal.Parse(dr["salesfee"].ToString());
            LandMainFiller.isbuildingfee = (bool)dr["isbuildingfee"];
            LandMainFiller.buildingfee = decimal.Parse(dr["buildingfee"].ToString());
            LandMainFiller.isvat = (bool)dr["isvat"];
            LandMainFiller.vat = decimal.Parse(dr["vat"].ToString());
            LandMainFiller.isdiscounttotal = (bool)dr["isdiscounttotal"];
            LandMainFiller.discounttotal = decimal.Parse(dr["discounttotal"].ToString());
            LandMainFiller.discounttotalvalue = decimal.Parse(dr["discounttotalvalue"].ToString());
            LandMainFiller.isdiscountfee = (bool)dr["isdiscountfee"];
            LandMainFiller.discountfee = decimal.Parse(dr["discountfee"].ToString());
            LandMainFiller.discountfeevalue = decimal.Parse(dr["discountfeevalue"].ToString());
            LandMainFiller.total = decimal.Parse(dr["total"].ToString());
            LandMainFiller.south = (string)dr["south"];
            LandMainFiller.southdesc = (string)dr["southdesc"];
            LandMainFiller.north = (string)dr["north"];
            LandMainFiller.northdesc = (string)dr["northdesc"];
            LandMainFiller.east = (string)dr["east"];
            LandMainFiller.eastdesc = (string)dr["eastdesc"];
            LandMainFiller.west = (string)dr["west"];
            LandMainFiller.westdesc = (string)dr["westdesc"];
            LandMainFiller.status = (string)dr["status"];
            LandMainFiller.reservereason = (string)dr["reservereason"];
            LandMainFiller.note = (string)dr["note"];

            lstData.Add(LandMainFiller);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwLandMainFiller FindBy(string dbcolumn, object val)
    {
        vwLandMainFiller LandMainFiller = new vwLandMainFiller();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandMainFiller WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandMainFiller.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandMainFiller.code = (int)DBConnect.DBReader["code"];
            LandMainFiller.number = (int)DBConnect.DBReader["number"];
            LandMainFiller.blocknumber = (string)DBConnect.DBReader["blocknumber"];
            LandMainFiller.landtype = (string)DBConnect.DBReader["landtype"];
            LandMainFiller.area = decimal.Parse(DBConnect.DBReader["area"].ToString());
            LandMainFiller.deednumber = (string)DBConnect.DBReader["deednumber"];
            LandMainFiller.amount = decimal.Parse(DBConnect.DBReader["amount"].ToString());
            LandMainFiller.isworkfee = (bool)DBConnect.DBReader["isworkfee"];
            LandMainFiller.workfee = decimal.Parse(DBConnect.DBReader["workfee"].ToString());
            LandMainFiller.issalefee = (bool)DBConnect.DBReader["issalefee"];
            LandMainFiller.salesfee = decimal.Parse(DBConnect.DBReader["salesfee"].ToString());
            LandMainFiller.isbuildingfee = (bool)DBConnect.DBReader["isbuildingfee"];
            LandMainFiller.buildingfee = decimal.Parse(DBConnect.DBReader["buildingfee"].ToString());
            LandMainFiller.isvat = (bool)DBConnect.DBReader["isvat"];
            LandMainFiller.vat = decimal.Parse(DBConnect.DBReader["vat"].ToString());
            LandMainFiller.isdiscounttotal = (bool)DBConnect.DBReader["isdiscounttotal"];
            LandMainFiller.discounttotal = decimal.Parse(DBConnect.DBReader["discounttotal"].ToString());
            LandMainFiller.discounttotalvalue = decimal.Parse(DBConnect.DBReader["discounttotalvalue"].ToString());
            LandMainFiller.isdiscountfee = (bool)DBConnect.DBReader["isdiscountfee"];
            LandMainFiller.discountfee = decimal.Parse(DBConnect.DBReader["discountfee"].ToString());
            LandMainFiller.discountfeevalue = decimal.Parse(DBConnect.DBReader["discountfeevalue"].ToString());
            LandMainFiller.total = decimal.Parse(DBConnect.DBReader["total"].ToString());
            LandMainFiller.south = (string)DBConnect.DBReader["south"];
            LandMainFiller.southdesc = (string)DBConnect.DBReader["southdesc"];
            LandMainFiller.north = (string)DBConnect.DBReader["north"];
            LandMainFiller.northdesc = (string)DBConnect.DBReader["northdesc"];
            LandMainFiller.east = (string)DBConnect.DBReader["east"];
            LandMainFiller.eastdesc = (string)DBConnect.DBReader["eastdesc"];
            LandMainFiller.west = (string)DBConnect.DBReader["west"];
            LandMainFiller.westdesc = (string)DBConnect.DBReader["westdesc"];
            LandMainFiller.status = (string)DBConnect.DBReader["status"];
            LandMainFiller.reservereason = (string)DBConnect.DBReader["reservereason"];
            LandMainFiller.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandMainFiller;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwLandMainFiller WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwLandMainFiller", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandMainFiller", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwLandMainFiller", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwLandMainFiller WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandMainFiller", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtcode
Txtnumber
Txtblocknumber
Txtlandtype
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
Txtreservereason
Txtnote


*/