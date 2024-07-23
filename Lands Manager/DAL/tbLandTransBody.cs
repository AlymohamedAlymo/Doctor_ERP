using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbLandTransBody
{

    public static List<tbLandTransBody> lstData;
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
        DBConnect.DBCommand.CommandText = "INSERT INTO tbLandTransBody VALUES (@guid, @parentguid, @number, @landguid, @hijridate, @deednumber, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@hijridate", hijridate);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbLandTransBody SET parentguid = @parentguid, number = @number, landguid = @landguid, hijridate = @hijridate, deednumber = @deednumber, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@hijridate", hijridate);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTransBody WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbLandTransBody  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTransBody";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbLandTransBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLandTransBody", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransBody LandTransBody = new tbLandTransBody();

            LandTransBody.guid = new Guid(dr["guid"].ToString());
            LandTransBody.parentguid = new Guid(dr["parentguid"].ToString());
            LandTransBody.number = (int)dr["number"];
            LandTransBody.landguid = new Guid(dr["landguid"].ToString());
            LandTransBody.hijridate = (string)dr["hijridate"];
            LandTransBody.deednumber = (string)dr["deednumber"];
            LandTransBody.note = (string)dr["note"];

            lstData.Add(LandTransBody);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbLandTransBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLandTransBody WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransBody LandTransBody = new tbLandTransBody();

            LandTransBody.guid = new Guid(dr["guid"].ToString());
            LandTransBody.parentguid = new Guid(dr["parentguid"].ToString());
            LandTransBody.number = (int)dr["number"];
            LandTransBody.landguid = new Guid(dr["landguid"].ToString());
            LandTransBody.hijridate = (string)dr["hijridate"];
            LandTransBody.deednumber = (string)dr["deednumber"];
            LandTransBody.note = (string)dr["note"];

            lstData.Add(LandTransBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbLandTransBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTransBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransBody LandTransBody = new tbLandTransBody();

            LandTransBody.guid = new Guid(dr["guid"].ToString());
            LandTransBody.parentguid = new Guid(dr["parentguid"].ToString());
            LandTransBody.number = (int)dr["number"];
            LandTransBody.landguid = new Guid(dr["landguid"].ToString());
            LandTransBody.hijridate = (string)dr["hijridate"];
            LandTransBody.deednumber = (string)dr["deednumber"];
            LandTransBody.note = (string)dr["note"];

            lstData.Add(LandTransBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLandTransBody>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTransBody WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransBody LandTransBody = new tbLandTransBody();

            LandTransBody.guid = new Guid(dr["guid"].ToString());
            LandTransBody.parentguid = new Guid(dr["parentguid"].ToString());
            LandTransBody.number = (int)dr["number"];
            LandTransBody.landguid = new Guid(dr["landguid"].ToString());
            LandTransBody.hijridate = (string)dr["hijridate"];
            LandTransBody.deednumber = (string)dr["deednumber"];
            LandTransBody.note = (string)dr["note"];

            lstData.Add(LandTransBody);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbLandTransBody FindBy(string dbcolumn, object val)
    {
        tbLandTransBody LandTransBody = new tbLandTransBody();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTransBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandTransBody.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandTransBody.parentguid = new Guid(DBConnect.DBReader["parentguid"].ToString());
            LandTransBody.number = (int)DBConnect.DBReader["number"];
            LandTransBody.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            LandTransBody.hijridate = (string)DBConnect.DBReader["hijridate"];
            LandTransBody.deednumber = (string)DBConnect.DBReader["deednumber"];
            LandTransBody.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandTransBody;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbLandTransBody WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbLandTransBody", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLandTransBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbLandTransBody", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbLandTransBody WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLandTransBody", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
Txthijridate
Txtdeednumber
Txtnote


*/