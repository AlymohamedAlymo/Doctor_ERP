using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class vwTrans
{

    public static List<vwTrans> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "ArchiveGuid", Formatting = "", Visibility = false, Width = 100, ControlName = "")]
    public Guid ArchiveGuid { get; set; }
    [DataGUIAttribute(GUIName = "المستند", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtArc")]
    public string Arc { get; set; }
    [DataGUIAttribute(GUIName = "التاريخ و الوقت", Formatting = "HH:mm dd/MM/yyyy", Visibility = true, Width = 100, ControlName = "dtTransDate")]
    public DateTime TransDate { get; set; }
    [DataGUIAttribute(GUIName = "من القسم", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtTodepartname")]
    public string Todepartname { get; set; }
    [DataGUIAttribute(GUIName = "إلى القسم", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtFromdepartname")]
    public string Fromdepartname { get; set; }
    [DataGUIAttribute(GUIName = "المستخدم", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtusername")]
    public string username { get; set; }
    [DataGUIAttribute(GUIName = "ملاحظات", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtnote")]
    public string note { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO vwTrans VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@ArchiveGuid", ArchiveGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@Arc", Arc);
        DBConnect.DBCommand.Parameters.AddWithValue("@TransDate", TransDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@Todepartname", Todepartname);
        DBConnect.DBCommand.Parameters.AddWithValue("@Fromdepartname", Fromdepartname);
        DBConnect.DBCommand.Parameters.AddWithValue("@username", username);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE vwTrans SET ArchiveGuid = ?, Arc = ?, TransDate = ?, Todepartname = ?, Fromdepartname = ?, username = ?, note = ? WHERE Guid = ?";

        DBConnect.DBCommand.Parameters.AddWithValue("@ArchiveGuid", ArchiveGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@Arc", Arc);
        DBConnect.DBCommand.Parameters.AddWithValue("@TransDate", TransDate);
        DBConnect.DBCommand.Parameters.AddWithValue("@Todepartname", Todepartname);
        DBConnect.DBCommand.Parameters.AddWithValue("@Fromdepartname", Fromdepartname);
        DBConnect.DBCommand.Parameters.AddWithValue("@username", username);
        DBConnect.DBCommand.Parameters.AddWithValue("@note", note);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwTrans WHERE Guid = ?";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM vwTrans  WHERE {0} = {1}", dbcolumn, "?");
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM vwTrans";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<vwTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwTrans", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwTrans trans = new vwTrans();

            trans.Guid = new Guid(dr["Guid"].ToString());
            trans.ArchiveGuid = new Guid(dr["ArchiveGuid"].ToString());
            trans.Arc = (string)dr["Arc"];
            trans.TransDate = (DateTime)dr["TransDate"];
            trans.Todepartname = (string)dr["Todepartname"];
            trans.Fromdepartname = (string)dr["Fromdepartname"];
            trans.username = (string)dr["username"];
            trans.note = (string)dr["note"];

            lstData.Add(trans);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<vwTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM vwTrans WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwTrans trans = new vwTrans();

            trans.Guid = new Guid(dr["Guid"].ToString());
            trans.ArchiveGuid = new Guid(dr["ArchiveGuid"].ToString());
            trans.Arc = (string)dr["Arc"];
            trans.TransDate = (DateTime)dr["TransDate"];
            trans.Todepartname = (string)dr["Todepartname"];
            trans.Fromdepartname = (string)dr["Fromdepartname"];
            trans.username = (string)dr["username"];
            trans.note = (string)dr["note"];

            lstData.Add(trans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<vwTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwTrans WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwTrans trans = new vwTrans();

            trans.Guid = new Guid(dr["Guid"].ToString());
            trans.ArchiveGuid = new Guid(dr["ArchiveGuid"].ToString());
            trans.Arc = (string)dr["Arc"];
            trans.TransDate = (DateTime)dr["TransDate"];
            trans.Todepartname = (string)dr["Todepartname"];
            trans.Fromdepartname = (string)dr["Fromdepartname"];
            trans.username = (string)dr["username"];
            trans.note = (string)dr["note"];

            lstData.Add(trans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<vwTrans>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwTrans WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            vwTrans trans = new vwTrans();

            trans.Guid = new Guid(dr["Guid"].ToString());
            trans.ArchiveGuid = new Guid(dr["ArchiveGuid"].ToString());
            trans.Arc = (string)dr["Arc"];
            trans.TransDate = (DateTime)dr["TransDate"];
            trans.Todepartname = (string)dr["Todepartname"];
            trans.Fromdepartname = (string)dr["Fromdepartname"];
            trans.username = (string)dr["username"];
            trans.note = (string)dr["note"];

            lstData.Add(trans);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static vwTrans FindBy(string dbcolumn, object val)
    {
        vwTrans trans = new vwTrans();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM vwTrans WHERE {0} = {1}", dbcolumn, "?"), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            trans.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            trans.ArchiveGuid = new Guid(DBConnect.DBReader["ArchiveGuid"].ToString());
            trans.Arc = (string)DBConnect.DBReader["Arc"];
            trans.TransDate = (DateTime)DBConnect.DBReader["TransDate"];
            trans.Todepartname = (string)DBConnect.DBReader["Todepartname"];
            trans.Fromdepartname = (string)DBConnect.DBReader["Fromdepartname"];
            trans.username = (string)DBConnect.DBReader["username"];
            trans.note = (string)DBConnect.DBReader["note"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return trans;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM vwTrans WHERE {0} = {1}", dbcolumn, "?"), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM vwTrans", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM vwTrans", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM vwTrans WHERE {0} = ?", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM vwTrans", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtArc
dtTransDate
TxtTodepartname
TxtFromdepartname
Txtusername
Txtnote


*/
