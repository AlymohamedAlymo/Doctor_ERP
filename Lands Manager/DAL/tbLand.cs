using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlTypes;
using DevExpress.Utils.Filtering;

public class tbLand
{

    public static List<tbLand> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "PlanGuid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid planguid { get; set; }

    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "الكود", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtcode")]
    public int code { get; set; }
    [DataGUIAttribute(GUIName = "رقم البلوك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtblocknumber")]
    public int blocknumber { get; set; }
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
    [DataGUIAttribute(GUIName = "عمولة سعي", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtworkfee")]
    public decimal workfee { get; set; }
    [DataGUIAttribute(GUIName = "issalefee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkissalefee")]
    public bool issalefee { get; set; }
    [DataGUIAttribute(GUIName = "نسبة ضريبة المبيعات", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtsalesfee")]
    public decimal salesfee { get; set; }
    [DataGUIAttribute(GUIName = "isbuildingfee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisbuildingfee")]
    public bool isbuildingfee { get; set; }
    [DataGUIAttribute(GUIName = "نسبة ضريبة التصرفات العقارية", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtbuildingfee")]
    public decimal buildingfee { get; set; }
    [DataGUIAttribute(GUIName = "isvat", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisvat")]
    public bool isvat { get; set; }
    [DataGUIAttribute(GUIName = "نسبة الضريبة المضافة", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtvat")]
    public decimal vat { get; set; }
    [DataGUIAttribute(GUIName = "isdiscounttotal", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisdiscounttotal")]
    public bool isdiscounttotal { get; set; }
    [DataGUIAttribute(GUIName = "discounttotal", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtdiscounttotal")]
    public decimal discounttotal { get; set; }
    [DataGUIAttribute(GUIName = "discounttotalvalue", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtdiscounttotalvalue")]
    public decimal discounttotalvalue { get; set; }
    [DataGUIAttribute(GUIName = "isdiscountfee", Formatting = "", Visibility = false, Width = 100, ControlName = "Chkisdiscountfee")]
    public bool isdiscountfee { get; set; }
    [DataGUIAttribute(GUIName = "discountfee", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtdiscountfee")]
    public decimal discountfee { get; set; }
    [DataGUIAttribute(GUIName = "discountfeevalue", Formatting = "N2", Visibility = false, Width = 100, ControlName = "Txtdiscountfeevalue")]
    public decimal discountfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "الإجمالي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txttotal")]
    public decimal total { get; set; }
    [DataGUIAttribute(GUIName = "جنوب", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtsouth")]
    public string south { get; set; }
    [DataGUIAttribute(GUIName = "جنوب وصف", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtsouthdesc")]
    public string southdesc { get; set; }
    [DataGUIAttribute(GUIName = "شمال", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtnorth")]
    public string north { get; set; }
    [DataGUIAttribute(GUIName = "شمال وصف", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtnorthdesc")]
    public string northdesc { get; set; }
    [DataGUIAttribute(GUIName = "شرق", Formatting = "", Visibility = false, Width = 100, ControlName = "Txteast")]
    public string east { get; set; }
    [DataGUIAttribute(GUIName = "شرق وصف", Formatting = "", Visibility = false, Width = 100, ControlName = "Txteastdesc")]
    public string eastdesc { get; set; }
    [DataGUIAttribute(GUIName = "غرب", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtwest")]
    public string west { get; set; }
    [DataGUIAttribute(GUIName = "غرب وصف", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtwestdesc")]
    public string westdesc { get; set; }
    [DataGUIAttribute(GUIName = "الحالة", Formatting = "", Visibility = false, Width = 100, ControlName = "Txtstatus")]
    public string status { get; set; }
    [DataGUIAttribute(GUIName = "سبب الحجز", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtreservereason")]
    public string reservereason { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }
    [DataGUIAttribute(GUIName = "أخر عملية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlastaction")]
    public string lastaction { get; set; }
    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbLand VALUES (@PlanGuid, @guid, @number , @code, @blocknumber, @landtype , @area, @deednumber, @amount, @isworkfee, @workfee, @issalefee, @salesfee, @isbuildingfee, @buildingfee, @isvat, @vat, @isdiscounttotal, @discounttotal, @discounttotalvalue, @isdiscountfee, @discountfee, @discountfeevalue, @total, @south, @southdesc, @north, @northdesc, @east, @eastdesc, @west, @westdesc, @status, @reservereason , @note , @lastaction)";

        DBConnect.DBCommand.Parameters.AddWithValue("@PlanGuid", planguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
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
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbLand SET number = @number , code = @code,  blocknumber = @blocknumber, landtype = @landtype,  area = @area, deednumber = @deednumber, amount = @amount, isworkfee = @isworkfee, workfee = @workfee, issalefee = @issalefee, salesfee = @salesfee, isbuildingfee = @isbuildingfee, buildingfee = @buildingfee, isvat = @isvat, vat = @vat, isdiscounttotal = @isdiscounttotal, discounttotal = @discounttotal, discounttotalvalue = @discounttotalvalue, isdiscountfee = @isdiscountfee, discountfee = @discountfee, discountfeevalue = @discountfeevalue, total = @total, south = @south, southdesc = @southdesc, north = @north, northdesc = @northdesc, east = @east, eastdesc = @eastdesc, west = @west, westdesc = @westdesc, status = @status, reservereason = @reservereason , note = @note , lastaction = @lastaction WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@code", code);
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
        DBConnect.DBCommand.Parameters.AddWithValue("@lastaction", lastaction);

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLand WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbLand  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLand";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLand order by number", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
    }


    public static int GetMaxColumns()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT TOP 1 (Count(*)) as maxColumns FROM tbLand  GROUP BY BlockNumber ORDER BY Count(*) DESC ", DBConnect.DBConnection);
        int icount = 0;

        try
        {
            icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        }
        catch
        {
            icount = 0;
        }

        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static DataTable FillRoomsTable(string blokcnumber)
    {
        string query = "DECLARE @cols AS NVARCHAR(MAX), @query  AS NVARCHAR(MAX); " +
            " SET @cols = STUFF((SELECT distinct ',' + QUOTENAME(c.code)  FROM tbLand c where c.blocknumber = @blocknumber   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') " +
            " set @query = 'SELECT blocknumber, ' + @cols + '   from  ( select blocknumber ,  code from tbLand where blocknumber = @blocknumber ) x  pivot  (  max(code) for code in (' + @cols + ') ) p ' " +
            " execute(@query)";

        query = query.Replace("@blocknumber", blokcnumber);

        DataTable dtRooms = new DataTable();
        DBConnect.DBCommand = new SqlCommand(query, DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtRooms);

        DBConnect.DBCommand.Parameters.Clear();

        return dtRooms;
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLand WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void Fill(string dbcolumn, string keyword, string status)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0} LIKE '%{1}%' AND status = @status", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }


    public static void FillByBlockState(string dbcolumn, string keyword, string status)
    {
       
        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0}= '{1}' AND status = @status", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void FillByBlockNotState(string dbcolumn, string keyword, string status)
    {

        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0}= '{1}' AND status <> @status", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@status", status);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();

            Land.guid = new Guid(dr["guid"].ToString());
            Land.number = (int)dr["number"];
            Land.code = (int)dr["code"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbLand FindBy(string dbcolumn, object val)
    {
        tbLand Land = new tbLand();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Land.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Land.number = (int)DBConnect.DBReader["number"];
            Land.code = (int)DBConnect.DBReader["code"];
            Land.blocknumber = int.Parse(DBConnect.DBReader["blocknumber"].ToString());
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
            Land.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Land;
    }

    public static tbLand FindByTrans(string dbcolumn, object val)
    {
        tbLand Land = new tbLand();
        DBConnect.DBCommand.CommandText = string.Format("SELECT * FROM tbLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            Land.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            Land.number = (int)DBConnect.DBReader["number"];
            Land.code = (int)DBConnect.DBReader["code"];
            Land.blocknumber = int.Parse(DBConnect.DBReader["blocknumber"].ToString());
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
            Land.lastaction = (string)DBConnect.DBReader["lastaction"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return Land;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }


    public static bool IsExistTrans(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand.CommandText = string.Format("SELECT count(*) FROM tbLand WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static bool IsAgentDiffTrans(Guid parentguid)
    {
        return true;
        //bool Result = false;
        //DBConnect.DBCommand.CommandText = "SELECT count(*) as c FROM tbBillBody JOIN tbBillheader ON tbBillBody.parentguid = tbBillheader.guid WHERE tbBillBody.parentguid = @parentguid  GROUP BY tbBillheader.buyerguid";
        //DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        //int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());

        //if(iResult > 1)
        //{
        //    Result = true;
        //}


        //DBConnect.DBCommand.Parameters.Clear();
        //return Result;
    }

    //public static void updatelandstate(Guid parentguid)
    //{
    //    DBConnect.DBCommand.CommandText = "update tbLand set tbLand.status = 'متاح' WHERE  tbLand.status <> 'محجوز' AND guid not in (SELECT landguid from tbBillBody WHERE parentguid = @parentguid) ";
    //    DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
    //    DBConnect.DBCommand.ExecuteNonQuery();

    //    DBConnect.DBCommand.Parameters.Clear();

    //}

    public static void updatelandstatus(Guid landguid)
    {

        DBConnect.DBCommand.CommandText = "prcupdatelandstatus";
        DBConnect.DBCommand.CommandType = CommandType.StoredProcedure;
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();

    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbLand", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLand", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbLand", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetMaxNumberTrans(string dbcolumn)
    {
        DBConnect.DBCommand.CommandText = "SELECT COUNT(*) FROM tbLand";
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand.CommandText = string.Format("SELECT MAX({0}) FROM tbLand WHERE  IsNumeric(code) = 1", dbcolumn);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }

    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbLand WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLand", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }


    public static void Fill(string dbcolumn, object val, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLand>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLand WHERE {0} = @val AND   (code LIKE '%{1}%')", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLand Land = new tbLand();


            Land.guid = new Guid(dr["guid"].ToString());
            Land.code = (int)dr["code"];
            Land.number = (int)dr["number"];
            Land.blocknumber = int.Parse(dr["blocknumber"].ToString());
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
            Land.lastaction = (string)dr["lastaction"];

            lstData.Add(Land);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }





    public static int GetMaxNumber(string dbcolumn, string blocknumber)
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLand WHERE blocknumber = @blocknumber", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@blocknumber", blocknumber);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbLand WHERE blocknumber = @blocknumber AND IsNumeric(code) = 1", dbcolumn), DBConnect.DBConnection);
            DBConnect.DBCommand.Parameters.AddWithValue("@blocknumber", blocknumber);
            int iResult;
            int.TryParse(DBConnect.DBCommand.ExecuteScalar().ToString(), out iResult);
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }



}

/*

Txtcode
Txtnumber
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








