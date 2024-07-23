using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbLandTransHeader
{

    public static List<tbLandTransHeader> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "N0", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public int number { get; set; }
    [DataGUIAttribute(GUIName = "regdate", Formatting = "dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtregdate")]
    public DateTime regdate { get; set; }
    [DataGUIAttribute(GUIName = "note", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbLandTransHeader VALUES (@guid, @number, @regdate, @note)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbLandTransHeader SET number = @number, regdate = @regdate, note = @note WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@regdate", regdate);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTransHeader WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbLandTransHeader  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbLandTransHeader";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbLandTransHeader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLandTransHeader", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransHeader LandTransHeader = new tbLandTransHeader();

            LandTransHeader.guid = new Guid(dr["guid"].ToString());
            LandTransHeader.number = (int)dr["number"];
            LandTransHeader.regdate = (DateTime)dr["regdate"];
            LandTransHeader.note = (string)dr["note"];

            lstData.Add(LandTransHeader);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbLandTransHeader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbLandTransHeader WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransHeader LandTransHeader = new tbLandTransHeader();

            LandTransHeader.guid = new Guid(dr["guid"].ToString());
            LandTransHeader.number = (int)dr["number"];
            LandTransHeader.regdate = (DateTime)dr["regdate"];
            LandTransHeader.note = (string)dr["note"];

            lstData.Add(LandTransHeader);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbLandTransHeader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTransHeader WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransHeader LandTransHeader = new tbLandTransHeader();

            LandTransHeader.guid = new Guid(dr["guid"].ToString());
            LandTransHeader.number = (int)dr["number"];
            LandTransHeader.regdate = (DateTime)dr["regdate"];
            LandTransHeader.note = (string)dr["note"];

            lstData.Add(LandTransHeader);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbLandTransHeader>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTransHeader WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbLandTransHeader LandTransHeader = new tbLandTransHeader();

            LandTransHeader.guid = new Guid(dr["guid"].ToString());
            LandTransHeader.number = (int)dr["number"];
            LandTransHeader.regdate = (DateTime)dr["regdate"];
            LandTransHeader.note = (string)dr["note"];

            lstData.Add(LandTransHeader);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbLandTransHeader FindBy(string dbcolumn, object val)
    {
        tbLandTransHeader LandTransHeader = new tbLandTransHeader();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbLandTransHeader WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            LandTransHeader.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            LandTransHeader.number = (int)DBConnect.DBReader["number"];
            LandTransHeader.regdate = (DateTime)DBConnect.DBReader["regdate"];
            LandTransHeader.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return LandTransHeader;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbLandTransHeader WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbLandTransHeader", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLandTransHeader", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbLandTransHeader", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbLandTransHeader WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbLandTransHeader", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtnumber
dtregdate
Txtnote


*/