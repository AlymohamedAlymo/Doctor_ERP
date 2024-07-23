using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbReportCustomView
{

    public static List<tbReportCustomView> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "name", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "ColumnView", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtColumnView")]
    public string ColumnView { get; set; }
    [DataGUIAttribute(GUIName = "AutoFillColumn", Formatting = "", Visibility = true, Width = 100, ControlName = "ChkAutoFillColumn")]
    public bool AutoFillColumn { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbReportCustomView VALUES (@guid, @name, @ColumnView, @AutoFillColumn)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@ColumnView", ColumnView);
        DBConnect.DBCommand.Parameters.AddWithValue("@AutoFillColumn", AutoFillColumn);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbReportCustomView SET name = @name, ColumnView = @ColumnView, AutoFillColumn = @AutoFillColumn WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@ColumnView", ColumnView);
        DBConnect.DBCommand.Parameters.AddWithValue("@AutoFillColumn", AutoFillColumn);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbReportCustomView WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbReportCustomView  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbReportCustomView";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbReportCustomView>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbReportCustomView", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbReportCustomView reportcustomview = new tbReportCustomView();

            reportcustomview.guid = new Guid(dr["guid"].ToString());
            reportcustomview.name = (string)dr["name"];
            reportcustomview.ColumnView = (string)dr["ColumnView"];
            reportcustomview.AutoFillColumn = (bool)dr["AutoFillColumn"];

            lstData.Add(reportcustomview);
        }
    }

    public static void Fill(Guid guid)
    {
        lstData = new List<tbReportCustomView>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbReportCustomView WHERE guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbReportCustomView reportcustomview = new tbReportCustomView();

            reportcustomview.guid = new Guid(dr["guid"].ToString());
            reportcustomview.name = (string)dr["name"];
            reportcustomview.ColumnView = (string)dr["ColumnView"];
            reportcustomview.AutoFillColumn = (bool)dr["AutoFillColumn"];

            lstData.Add(reportcustomview);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbReportCustomView>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbReportCustomView WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbReportCustomView reportcustomview = new tbReportCustomView();

            reportcustomview.guid = new Guid(dr["guid"].ToString());
            reportcustomview.name = (string)dr["name"];
            reportcustomview.ColumnView = (string)dr["ColumnView"];
            reportcustomview.AutoFillColumn = (bool)dr["AutoFillColumn"];

            lstData.Add(reportcustomview);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbReportCustomView>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbReportCustomView WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbReportCustomView reportcustomview = new tbReportCustomView();

            reportcustomview.guid = new Guid(dr["guid"].ToString());
            reportcustomview.name = (string)dr["name"];
            reportcustomview.ColumnView = (string)dr["ColumnView"];
            reportcustomview.AutoFillColumn = (bool)dr["AutoFillColumn"];

            lstData.Add(reportcustomview);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbReportCustomView FindBy(string dbcolumn, object val)
    {
        tbReportCustomView reportcustomview = new tbReportCustomView();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbReportCustomView WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            reportcustomview.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            reportcustomview.name = (string)DBConnect.DBReader["name"];
            reportcustomview.ColumnView = (string)DBConnect.DBReader["ColumnView"];
            reportcustomview.AutoFillColumn = (bool)DBConnect.DBReader["AutoFillColumn"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return reportcustomview;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbReportCustomView WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbReportCustomView", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbReportCustomView", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbReportCustomView", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbReportCustomView WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbReportCustomView", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtname
TxtColumnView
ChkAutoFillColumn


*/
