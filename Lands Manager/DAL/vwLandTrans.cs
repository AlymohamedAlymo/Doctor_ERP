using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwLandTrans
{

    public static List<vwLandTrans> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "الرقم", Formatting = "N0", Visibility = false, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "رقم الأرض", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "المشتري", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "Txtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "رقم الصك", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdeednumber")]
    public string deednumber { get; set; }
    [DataGUIAttribute(GUIName = "رقم التصرفات العقارية", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtbuildingnumber")]
    public string buildingnumber { get; set; }
    [DataGUIAttribute(GUIName = "قيمة ضريبة التصرفات العقارية", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtbuildingfeevalue")]
    public decimal buildingfeevalue { get; set; }
    [DataGUIAttribute(GUIName = "المتبقي", Formatting = "N2", Visibility = true, Width = 100, ControlName = "Txtremain")]
    public decimal remain { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion


    public static void Fill()
    {
        lstData = new List<vwLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandTrans", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        //foreach (DataRow dr in dtData.Rows)
        //{
        //    vwLandTrans LandTrans = new vwLandTrans();

        //    LandTrans.guid = new Guid(dr["guid"].ToString());
        //    LandTrans.landguid = new Guid(dr["landguid"].ToString());
        //    LandTrans.number = (int)dr["number"];
        //    LandTrans.land = (string)dr["land"];
        //    LandTrans.agent = (string)dr["agent"];

        //    LandTrans.regdate = (DateTime)dr["regdate"];

        //    LandTrans.deednumber = (string)dr["deednumber"];
        //    LandTrans.buildingnumber = (string)dr["buildingnumber"];
        //    LandTrans.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
        //    LandTrans.remain = decimal.Parse(dr["remain"].ToString());
        //    LandTrans.note = (string)dr["note"];

        //    lstData.Add(LandTrans);
        //}
    }

    public static void FillTrans()
    {
        lstData = new List<vwLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandTrans WHERE deednumber <> ''", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        //foreach (DataRow dr in dtData.Rows)
        //{
        //    vwLandTrans LandTrans = new vwLandTrans();

        //    LandTrans.guid = new Guid(dr["guid"].ToString());
        //    LandTrans.landguid = new Guid(dr["landguid"].ToString());
        //    LandTrans.number = (int)dr["number"];
        //    LandTrans.land = (string)dr["land"];
        //    LandTrans.agent = (string)dr["agent"];

        //    LandTrans.regdate = (DateTime)dr["regdate"];

        //    LandTrans.deednumber = (string)dr["deednumber"];
        //    LandTrans.buildingnumber = (string)dr["buildingnumber"];
        //    LandTrans.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
        //    LandTrans.remain = decimal.Parse(dr["remain"].ToString());
        //    LandTrans.note = (string)dr["note"];

        //    lstData.Add(LandTrans);
        //}
    }


    public static void FillNotTrans()
    {
        lstData = new List<vwLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandTrans  WHERE deednumber = '' ", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        //foreach (DataRow dr in dtData.Rows)
        //{
        //    vwLandTrans LandTrans = new vwLandTrans();

        //    LandTrans.guid = new Guid(dr["guid"].ToString());
        //    LandTrans.landguid = new Guid(dr["landguid"].ToString());
        //    LandTrans.number = (int)dr["number"];
        //    LandTrans.land = (string)dr["land"];
        //    LandTrans.agent = (string)dr["agent"];

        //    LandTrans.regdate = (DateTime)dr["regdate"];

        //    LandTrans.deednumber = (string)dr["deednumber"];
        //    LandTrans.buildingnumber = (string)dr["buildingnumber"];
        //    LandTrans.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
        //    LandTrans.remain = decimal.Parse(dr["remain"].ToString());
        //    LandTrans.note = (string)dr["note"];

        //    lstData.Add(LandTrans);
        //}
    }

    public static void Fill(Guid guid)
    {
        lstData = new List<vwLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandTrans WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandTrans LandTrans = new vwLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.land = (string)dr["land"];
            LandTrans.agent = (string)dr["agent"];
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            LandTrans.remain = decimal.Parse(dr["remain"].ToString());
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandTrans LandTrans = new vwLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.land = (string)dr["land"];
            LandTrans.agent = (string)dr["agent"];
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            LandTrans.remain = decimal.Parse(dr["remain"].ToString());
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandTrans WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandTrans LandTrans = new vwLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.land = (string)dr["land"];
            LandTrans.agent = (string)dr["agent"];
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.buildingfeevalue = decimal.Parse(dr["buildingfeevalue"].ToString());
            LandTrans.remain = decimal.Parse(dr["remain"].ToString());
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwLandTrans FindBy(string dbcolumn, object val)
    {
        vwLandTrans LandTrans = new vwLandTrans();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandTrans WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandTrans.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandTrans.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            LandTrans.number = (int)DBConnect.DBReader["number"];
            LandTrans.land = (string)DBConnect.DBReader["land"];
            LandTrans.agent = (string)DBConnect.DBReader["agent"];
            LandTrans.regdate = (DateTime)DBConnect.DBReader["regdate"];
            LandTrans.deednumber = (string)DBConnect.DBReader["deednumber"];
            LandTrans.buildingnumber = (string)DBConnect.DBReader["buildingnumber"];
            LandTrans.buildingfeevalue = decimal.Parse(DBConnect.DBReader["buildingfeevalue"].ToString());
            LandTrans.remain = decimal.Parse(DBConnect.DBReader["remain"].ToString());
            LandTrans.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandTrans;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwLandTrans WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwLandTrans", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwLandTrans", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwLandTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtland
Txtagent
Txtregdate
Txtdeednumber
Txtbuildingnumber
Txtbuildingfeevalue
Txtremain
Txtnote


*/