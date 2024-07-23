using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbPaymentsNotes
{

    public static List<tbPaymentsNotes> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "landpricenotes", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlandpricenotes")]
    public string landpricenotes { get; set; }
    [DataGUIAttribute(GUIName = "workfeenotes", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtworkfeenotes")]
    public string workfeenotes { get; set; }
    [DataGUIAttribute(GUIName = "vatnotes", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtvatnotes")]
    public string vatnotes { get; set; }
    [DataGUIAttribute(GUIName = "discountnotes", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtdiscountnotes")]
    public string discountnotes { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbPaymentsNotes VALUES (@guid, @landpricenotes, @workfeenotes, @vatnotes, @discountnotes)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@landpricenotes", landpricenotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@workfeenotes", workfeenotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@vatnotes", vatnotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountnotes", discountnotes);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbPaymentsNotes SET landpricenotes = @landpricenotes, workfeenotes = @workfeenotes, vatnotes = @vatnotes, discountnotes = @discountnotes WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@landpricenotes", landpricenotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@workfeenotes", workfeenotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@vatnotes", vatnotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@discountnotes", discountnotes);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPaymentsNotes WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbPaymentsNotes  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPaymentsNotes";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbPaymentsNotes>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPaymentsNotes", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPaymentsNotes PaymentsNotes = new tbPaymentsNotes();

            PaymentsNotes.guid = new Guid(dr["guid"].ToString());
            PaymentsNotes.landpricenotes = (string)dr["landpricenotes"];
            PaymentsNotes.workfeenotes = (string)dr["workfeenotes"];
            PaymentsNotes.vatnotes = (string)dr["vatnotes"];
            PaymentsNotes.discountnotes = (string)dr["discountnotes"];

            lstData.Add(PaymentsNotes);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbPaymentsNotes>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPaymentsNotes WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPaymentsNotes PaymentsNotes = new tbPaymentsNotes();

            PaymentsNotes.guid = new Guid(dr["guid"].ToString());
            PaymentsNotes.landpricenotes = (string)dr["landpricenotes"];
            PaymentsNotes.workfeenotes = (string)dr["workfeenotes"];
            PaymentsNotes.vatnotes = (string)dr["vatnotes"];
            PaymentsNotes.discountnotes = (string)dr["discountnotes"];

            lstData.Add(PaymentsNotes);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbPaymentsNotes>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPaymentsNotes WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPaymentsNotes PaymentsNotes = new tbPaymentsNotes();

            PaymentsNotes.guid = new Guid(dr["guid"].ToString());
            PaymentsNotes.landpricenotes = (string)dr["landpricenotes"];
            PaymentsNotes.workfeenotes = (string)dr["workfeenotes"];
            PaymentsNotes.vatnotes = (string)dr["vatnotes"];
            PaymentsNotes.discountnotes = (string)dr["discountnotes"];

            lstData.Add(PaymentsNotes);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbPaymentsNotes>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPaymentsNotes WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPaymentsNotes PaymentsNotes = new tbPaymentsNotes();

            PaymentsNotes.guid = new Guid(dr["guid"].ToString());
            PaymentsNotes.landpricenotes = (string)dr["landpricenotes"];
            PaymentsNotes.workfeenotes = (string)dr["workfeenotes"];
            PaymentsNotes.vatnotes = (string)dr["vatnotes"];
            PaymentsNotes.discountnotes = (string)dr["discountnotes"];

            lstData.Add(PaymentsNotes);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbPaymentsNotes FindBy(string dbcolumn, object val)
    {
        tbPaymentsNotes PaymentsNotes = new tbPaymentsNotes();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPaymentsNotes WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PaymentsNotes.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            PaymentsNotes.landpricenotes = (string)DBConnect.DBReader["landpricenotes"];
            PaymentsNotes.workfeenotes = (string)DBConnect.DBReader["workfeenotes"];
            PaymentsNotes.vatnotes = (string)DBConnect.DBReader["vatnotes"];
            PaymentsNotes.discountnotes = (string)DBConnect.DBReader["discountnotes"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PaymentsNotes;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbPaymentsNotes WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbPaymentsNotes", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPaymentsNotes", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPaymentsNotes", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbPaymentsNotes WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPaymentsNotes", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtlandpricenotes
Txtworkfeenotes
Txtvatnotes
Txtdiscountnotes


*/