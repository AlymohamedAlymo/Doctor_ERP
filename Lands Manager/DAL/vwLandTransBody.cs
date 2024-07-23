using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwLandBodyTrans
{

    public static List<vwLandBodyTrans> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "parentguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid parentguid { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "land", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtland")]
    public string land { get; set; }
    [DataGUIAttribute(GUIName = "agent", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtagent")]
    public string agent { get; set; }
    [DataGUIAttribute(GUIName = "hijridate", Formatting = "", Visibility = true, Width = 100, ControlName = "Txthijridate")]
    public string hijridate { get; set; }
    [DataGUIAttribute(GUIName = "deednumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdeednumber")]
    public string deednumber { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO vwLandBodyTrans VALUES (@guid, @parentguid, @landguid, @number, @land, @agent, @hijridate, @deednumber, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@land", land);
        DBConnect.DBCommand.Parameters.AddWithValue("@agent", agent);
        DBConnect.DBCommand.Parameters.AddWithValue("@hijridate", hijridate);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE vwLandBodyTrans SET parentguid = @parentguid, landguid = @landguid, number = @number, land = @land, agent = @agent, hijridate = @hijridate, deednumber = @deednumber, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@land", land);
        DBConnect.DBCommand.Parameters.AddWithValue("@agent", agent);
        DBConnect.DBCommand.Parameters.AddWithValue("@hijridate", hijridate);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwLandBodyTrans WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM vwLandBodyTrans  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwLandBodyTrans";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<vwLandBodyTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandBodyTrans", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandBodyTrans LandBodyTrans = new vwLandBodyTrans();

            LandBodyTrans.guid = new Guid(dr["guid"].ToString());
            LandBodyTrans.parentguid = new Guid(dr["parentguid"].ToString());
            LandBodyTrans.landguid = new Guid(dr["landguid"].ToString());
            LandBodyTrans.number = (int)dr["number"];
            LandBodyTrans.land = (string)dr["land"];
            LandBodyTrans.agent = (string)dr["agent"];
            LandBodyTrans.hijridate = (string)dr["hijridate"];
            LandBodyTrans.deednumber = (string)dr["deednumber"];
            LandBodyTrans.note = (string)dr["note"];

            lstData.Add(LandBodyTrans);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwLandBodyTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwLandBodyTrans WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandBodyTrans LandBodyTrans = new vwLandBodyTrans();

            LandBodyTrans.guid = new Guid(dr["guid"].ToString());
            LandBodyTrans.parentguid = new Guid(dr["parentguid"].ToString());
            LandBodyTrans.landguid = new Guid(dr["landguid"].ToString());
            LandBodyTrans.number = (int)dr["number"];
            LandBodyTrans.land = (string)dr["land"];
            LandBodyTrans.agent = (string)dr["agent"];
            LandBodyTrans.hijridate = (string)dr["hijridate"];
            LandBodyTrans.deednumber = (string)dr["deednumber"];
            LandBodyTrans.note = (string)dr["note"];

            lstData.Add(LandBodyTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwLandBodyTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandBodyTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandBodyTrans LandBodyTrans = new vwLandBodyTrans();

            LandBodyTrans.guid = new Guid(dr["guid"].ToString());
            LandBodyTrans.parentguid = new Guid(dr["parentguid"].ToString());
            LandBodyTrans.landguid = new Guid(dr["landguid"].ToString());
            LandBodyTrans.number = (int)dr["number"];
            LandBodyTrans.land = (string)dr["land"];
            LandBodyTrans.agent = (string)dr["agent"];
            LandBodyTrans.hijridate = (string)dr["hijridate"];
            LandBodyTrans.deednumber = (string)dr["deednumber"];
            LandBodyTrans.note = (string)dr["note"];

            lstData.Add(LandBodyTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwLandBodyTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandBodyTrans WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwLandBodyTrans LandBodyTrans = new vwLandBodyTrans();

            LandBodyTrans.guid = new Guid(dr["guid"].ToString());
            LandBodyTrans.parentguid = new Guid(dr["parentguid"].ToString());
            LandBodyTrans.landguid = new Guid(dr["landguid"].ToString());
            LandBodyTrans.number = (int)dr["number"];
            LandBodyTrans.land = (string)dr["land"];
            LandBodyTrans.agent = (string)dr["agent"];
            LandBodyTrans.hijridate = (string)dr["hijridate"];
            LandBodyTrans.deednumber = (string)dr["deednumber"];
            LandBodyTrans.note = (string)dr["note"];

            lstData.Add(LandBodyTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwLandBodyTrans FindBy(string dbcolumn, object val)
    {
        vwLandBodyTrans LandBodyTrans = new vwLandBodyTrans();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwLandBodyTrans WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandBodyTrans.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandBodyTrans.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            LandBodyTrans.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            LandBodyTrans.number = (int)DBConnect.DBReader["number"];
            LandBodyTrans.land = (string)DBConnect.DBReader["land"];
            LandBodyTrans.agent = (string)DBConnect.DBReader["agent"];
            LandBodyTrans.hijridate = (string)DBConnect.DBReader["hijridate"];
            LandBodyTrans.deednumber = (string)DBConnect.DBReader["deednumber"];
            LandBodyTrans.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandBodyTrans;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwLandBodyTrans WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwLandBodyTrans", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandBodyTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwLandBodyTrans", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwLandBodyTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwLandBodyTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txtland
Txtagent
Txthijridate
Txtdeednumber
Txtnote


*/