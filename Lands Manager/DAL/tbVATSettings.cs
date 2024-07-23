using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbVATSettings
{

    public static List<tbVATSettings> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "CompanyName", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtCompanyName")]
    public string CompanyName { get; set; }
    [DataGUIAttribute(GUIName = "VATID", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtVATID")]
    public string VATID { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbVATSettings VALUES (@Guid, @CompanyName, @VATID)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
        DBConnect.DBCommand.Parameters.AddWithValue("@VATID", VATID);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbVATSettings SET CompanyName = @CompanyName, VATID = @VATID WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
        DBConnect.DBCommand.Parameters.AddWithValue("@VATID", VATID);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbVATSettings WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbVATSettings  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbVATSettings";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbVATSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbVATSettings", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbVATSettings VATSettings = new tbVATSettings();

            VATSettings.Guid = new Guid(dr["Guid"].ToString());
            VATSettings.CompanyName = (string)dr["CompanyName"];
            VATSettings.VATID = (string)dr["VATID"];

            lstData.Add(VATSettings);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbVATSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbVATSettings WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbVATSettings VATSettings = new tbVATSettings();

            VATSettings.Guid = new Guid(dr["Guid"].ToString());
            VATSettings.CompanyName = (string)dr["CompanyName"];
            VATSettings.VATID = (string)dr["VATID"];

            lstData.Add(VATSettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbVATSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbVATSettings WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbVATSettings VATSettings = new tbVATSettings();

            VATSettings.Guid = new Guid(dr["Guid"].ToString());
            VATSettings.CompanyName = (string)dr["CompanyName"];
            VATSettings.VATID = (string)dr["VATID"];

            lstData.Add(VATSettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbVATSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbVATSettings WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbVATSettings VATSettings = new tbVATSettings();

            VATSettings.Guid = new Guid(dr["Guid"].ToString());
            VATSettings.CompanyName = (string)dr["CompanyName"];
            VATSettings.VATID = (string)dr["VATID"];

            lstData.Add(VATSettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbVATSettings FindBy(string dbcolumn, object val)
    {
        tbVATSettings VATSettings = new tbVATSettings();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbVATSettings WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            VATSettings.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            VATSettings.CompanyName = (string)DBConnect.DBReader["CompanyName"];
            VATSettings.VATID = (string)DBConnect.DBReader["VATID"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return VATSettings;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbVATSettings WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbVATSettings", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbVATSettings", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbVATSettings", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbVATSettings WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbVATSettings", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtCompanyName
TxtVATID


*/