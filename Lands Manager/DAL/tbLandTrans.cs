using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbLandTrans
{

    public static List<tbLandTrans> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "landguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid landguid { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "deednumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdeednumber")]
    public string deednumber { get; set; }
    [DataGUIAttribute(GUIName = "buildingnumber", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtbuildingnumber")]
    public string buildingnumber { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbLandTrans VALUES (@guid, @number, @landguid, @regdate, @deednumber, @buildingnumber, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@buildingnumber", buildingnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbLandTrans SET number = @number, landguid = @landguid, regdate = @regdate, deednumber = @deednumber, buildingnumber = @buildingnumber, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@landguid", landguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@deednumber", deednumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@buildingnumber", buildingnumber);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTrans WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbLandTrans  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTrans";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }


    public void DeleteALLNoTrans()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTrans  WHERE deednumber = ''";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLandTrans", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTrans LandTrans = new tbLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLandTrans WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTrans LandTrans = new tbLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTrans LandTrans = new tbLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLandTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTrans WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTrans LandTrans = new tbLandTrans();

            LandTrans.guid = new Guid(dr["guid"].ToString());
            LandTrans.number = (int)dr["number"];
            LandTrans.landguid = new Guid(dr["landguid"].ToString());
            LandTrans.regdate = (DateTime)dr["regdate"];
            LandTrans.deednumber = (string)dr["deednumber"];
            LandTrans.buildingnumber = (string)dr["buildingnumber"];
            LandTrans.note = (string)dr["note"];

            lstData.Add(LandTrans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbLandTrans FindBy(string dbcolumn, object val)
    {
        tbLandTrans LandTrans = new tbLandTrans();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTrans WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandTrans.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandTrans.number = (int)DBConnect.DBReader["number"];
            LandTrans.landguid = new Guid(DBConnect.DBReader["landguid"].ToString());
            LandTrans.regdate = (DateTime)DBConnect.DBReader["regdate"];
            LandTrans.deednumber = (string)DBConnect.DBReader["deednumber"];
            LandTrans.buildingnumber = (string)DBConnect.DBReader["buildingnumber"];
            LandTrans.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandTrans;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbLandTrans WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbLandTrans", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLandTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbLandTrans", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbLandTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLandTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
dtregdate
Txtdeednumber
Txtbuildingnumber
Txtnote


*/