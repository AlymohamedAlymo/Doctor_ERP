using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbAttachment
{

    public static List<tbAttachment> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "ParentGuid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid ParentGuid { get; set; }
    [DataGUIAttribute(GUIName = "Name", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtName")]
    public string Name { get; set; }
    [DataGUIAttribute(GUIName = "FileName", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtFileName")]
    public string FileName { get; set; }
    [DataGUIAttribute(GUIName = "FileSize", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtFileSize")]
    public string FileSize { get; set; }
    [DataGUIAttribute(GUIName = "FileData", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtFileData")]
    public Byte[] FileData { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbAttachment VALUES (@Guid, @ParentGuid, @Name, @FileName, @FileSize, @FileData)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@ParentGuid", ParentGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@Name", Name);
        DBConnect.DBCommand.Parameters.AddWithValue("@FileName", FileName);
        DBConnect.DBCommand.Parameters.AddWithValue("@FileSize", FileSize);
        DBConnect.DBCommand.Parameters.AddWithValue("@FileData", FileData);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbAttachment SET ParentGuid = @ParentGuid, Name = @Name, FileName = @FileName, FileSize = @FileSize, FileData = @FileData WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@ParentGuid", ParentGuid);
        DBConnect.DBCommand.Parameters.AddWithValue("@Name", Name);
        DBConnect.DBCommand.Parameters.AddWithValue("@FileName", FileName);
        DBConnect.DBCommand.Parameters.AddWithValue("@FileSize", FileSize);
        DBConnect.DBCommand.Parameters.AddWithValue("@FileData", FileData);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAttachment WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbAttachment  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbAttachment";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbAttachment>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAttachment", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAttachment attachment = new tbAttachment();

            attachment.Guid = new Guid(dr["Guid"].ToString());
            attachment.ParentGuid = new Guid(dr["ParentGuid"].ToString());
            attachment.Name = (string)dr["Name"];
            attachment.FileName = (string)dr["FileName"];
            attachment.FileSize = (string)dr["FileSize"];
            attachment.FileData = new byte[0x0];

            lstData.Add(attachment);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbAttachment>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbAttachment WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAttachment attachment = new tbAttachment();

            attachment.Guid = new Guid(dr["Guid"].ToString());
            attachment.ParentGuid = new Guid(dr["ParentGuid"].ToString());
            attachment.Name = (string)dr["Name"];
            attachment.FileName = (string)dr["FileName"];
            attachment.FileSize = (string)dr["FileSize"];
            attachment.FileData = new byte[0x0];

            lstData.Add(attachment);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void FillTrans(Guid ParentGuid)
    {
        lstData = new List<tbAttachment>();
        dtData = new DataTable();
        DBConnect.DBCommand.CommandText = "SELECT guid , parentguid , name , filename , filesize, 0x0 as filedata FROM tbattachment WHERE ParentGuid = @ParentGuid";
        DBConnect.DBCommand.Parameters.AddWithValue("@ParentGuid", ParentGuid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAttachment attachment = new tbAttachment();

            attachment.Guid = new Guid(dr["Guid"].ToString());
            attachment.ParentGuid = new Guid(dr["ParentGuid"].ToString());
            attachment.Name = (string)dr["Name"];
            attachment.FileName = (string)dr["FileName"];
            attachment.FileSize = (string)dr["FileSize"];
            attachment.FileData = new byte[0x0];// (Byte[])dr["FileData"];

            lstData.Add(attachment);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbAttachment>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAttachment WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAttachment attachment = new tbAttachment();

            attachment.Guid = new Guid(dr["Guid"].ToString());
            attachment.ParentGuid = new Guid(dr["ParentGuid"].ToString());
            attachment.Name = (string)dr["Name"];
            attachment.FileName = (string)dr["FileName"];
            attachment.FileSize = (string)dr["FileSize"];
            attachment.FileData = new byte[0x0];

            lstData.Add(attachment);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbAttachment>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAttachment WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbAttachment attachment = new tbAttachment();

            attachment.Guid = new Guid(dr["Guid"].ToString());
            attachment.ParentGuid = new Guid(dr["ParentGuid"].ToString());
            attachment.Name = (string)dr["Name"];
            attachment.FileName = (string)dr["FileName"];
            attachment.FileSize = (string)dr["FileSize"];
            attachment.FileData = new byte[0x0];

            lstData.Add(attachment);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbAttachment FindBy(string dbcolumn, object val)
    {
        tbAttachment attachment = new tbAttachment();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbAttachment WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            attachment.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            attachment.ParentGuid = new Guid(DBConnect.DBReader["ParentGuid"].ToString());
            attachment.Name = (string)DBConnect.DBReader["Name"];
            attachment.FileName = (string)DBConnect.DBReader["FileName"];
            attachment.FileSize = (string)DBConnect.DBReader["FileSize"];
            attachment.FileData = new byte[0x0];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return attachment;
    }

    public static tbAttachment FindByFull(string dbcolumn, object val)
    {
        tbAttachment attachment = new tbAttachment();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbattachment WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            attachment.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            attachment.ParentGuid = new Guid(DBConnect.DBReader["ParentGuid"].ToString());
            attachment.Name = (string)DBConnect.DBReader["Name"];
            attachment.FileName = (string)DBConnect.DBReader["FileName"];
            attachment.FileSize = (string)DBConnect.DBReader["FileSize"];
            attachment.FileData = (Byte[])DBConnect.DBReader["FileData"];


        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return attachment;
    }

    public static tbAttachment FindByFull(string dbcolumn, object val, string name)
    {
        tbAttachment attachment = new tbAttachment();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbattachment WHERE {0} = {1} AND name = @name", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.Parameters.AddWithValue("@name", name);

        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            attachment.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            attachment.ParentGuid = new Guid(DBConnect.DBReader["ParentGuid"].ToString());
            attachment.Name = (string)DBConnect.DBReader["Name"];
            attachment.FileName = (string)DBConnect.DBReader["FileName"];
            attachment.FileSize = (string)DBConnect.DBReader["FileSize"];
            attachment.FileData = (Byte[])DBConnect.DBReader["FileData"];


        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return attachment;
    }


    public static bool IsExistTrans(Guid guid, Guid parentguid)
    {
        bool Result = false;
        DBConnect.DBCommand.CommandText = "SELECT count(guid) FROM tbattachment WHERE guid = @guid AND parentguid = @parentguid";
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@parentguid", parentguid);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbAttachment WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbAttachment", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAttachment", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbAttachment", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbAttachment WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbAttachment", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtName
TxtFileName
TxtFileSize
TxtFileData


*/
