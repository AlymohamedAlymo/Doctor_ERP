using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbPlanInfo
{

    public static List<tbPlanInfo> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "name", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtname")]
    public string name { get; set; }
    [DataGUIAttribute(GUIName = "ownerguid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid ownerguid { get; set; }
    [DataGUIAttribute(GUIName = "city", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtcity")]
    public string city { get; set; }
    [DataGUIAttribute(GUIName = "location", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtlocation")]
    public string location { get; set; }
    [DataGUIAttribute(GUIName = "number", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnumber")]
    public string number { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbPlanInfo VALUES (@guid, @name, @ownerguid, @city, @location, @number  )";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@ownerguid", ownerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@city", city);
        DBConnect.DBCommand.Parameters.AddWithValue("@location", location);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbPlanInfo SET name = @name, ownerguid = @ownerguid, city = @city, location = @location, number = @number WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);
        DBConnect.DBCommand.Parameters.AddWithValue("@ownerguid", ownerguid);
        DBConnect.DBCommand.Parameters.AddWithValue("@city", city);
        DBConnect.DBCommand.Parameters.AddWithValue("@location", location);
        DBConnect.DBCommand.Parameters.AddWithValue("@number", number);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPlanInfo WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbPlanInfo  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbPlanInfo";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbPlanInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPlanInfo", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPlanInfo PlanInfo = new tbPlanInfo();

            PlanInfo.guid = new Guid(dr["guid"].ToString());
            PlanInfo.name = (string)dr["name"];
            PlanInfo.ownerguid = new Guid(dr["ownerguid"].ToString());
            PlanInfo.city = (string)dr["city"];
            PlanInfo.location = (string)dr["location"];
            PlanInfo.number = (string)dr["number"];

            lstData.Add(PlanInfo);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbPlanInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbPlanInfo WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPlanInfo PlanInfo = new tbPlanInfo();

            PlanInfo.guid = new Guid(dr["guid"].ToString());
            PlanInfo.name = (string)dr["name"];
            PlanInfo.ownerguid = new Guid(dr["ownerguid"].ToString());
            PlanInfo.city = (string)dr["city"];
            PlanInfo.location = (string)dr["location"];
            PlanInfo.number = (string)dr["number"];

            lstData.Add(PlanInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbPlanInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPlanInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPlanInfo PlanInfo = new tbPlanInfo();

            PlanInfo.guid = new Guid(dr["guid"].ToString());
            PlanInfo.name = (string)dr["name"];
            PlanInfo.ownerguid = new Guid(dr["ownerguid"].ToString());
            PlanInfo.city = (string)dr["city"];
            PlanInfo.location = (string)dr["location"];
            PlanInfo.number = (string)dr["number"];

            lstData.Add(PlanInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbPlanInfo>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPlanInfo WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbPlanInfo PlanInfo = new tbPlanInfo();

            PlanInfo.guid = new Guid(dr["guid"].ToString());
            PlanInfo.name = (string)dr["name"];
            PlanInfo.ownerguid = new Guid(dr["ownerguid"].ToString());
            PlanInfo.city = (string)dr["city"];
            PlanInfo.location = (string)dr["location"];
            PlanInfo.number = (string)dr["number"];

            lstData.Add(PlanInfo);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbPlanInfo FindBy(string dbcolumn, object val)
    {
        tbPlanInfo PlanInfo = new tbPlanInfo();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbPlanInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            PlanInfo.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            PlanInfo.name = (string)DBConnect.DBReader["name"];
            PlanInfo.ownerguid = new Guid(DBConnect.DBReader["ownerguid"].ToString());
            PlanInfo.city = (string)DBConnect.DBReader["city"];
            PlanInfo.location = (string)DBConnect.DBReader["location"];
            PlanInfo.number = (string)DBConnect.DBReader["number"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return PlanInfo;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbPlanInfo WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbPlanInfo", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPlanInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbPlanInfo", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbPlanInfo WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbPlanInfo", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

Txtname
Txtowner
Txtcity
Txtlocation
Txtnumber
Txtlandcount
Txtmosquecount
Txtgardencount
Txtschoolboyscount
Txtschoolgrilscount
Txtmarketcount
Txthealthcount
Txtmunicipality


*/