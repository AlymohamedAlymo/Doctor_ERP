using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbSMSsettings
{

    public static List<tbSMSsettings> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid guid { get; set; }
    [DataGUIAttribute(GUIName = "Username", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtUsername")]
    public string Username { get; set; }
    [DataGUIAttribute(GUIName = "password", Formatting = "", Visibility = true, Width = 100, ControlName = "Txtpassword")]
    public string password { get; set; }
    [DataGUIAttribute(GUIName = "Sender", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtSender")]
    public string Sender { get; set; }
    [DataGUIAttribute(GUIName = "MessageBody", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtMessageBody")]
    public string MessageBody { get; set; }
    [DataGUIAttribute(GUIName = "Mobile", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtMobile")]
    public string Mobile { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbSMSsettings VALUES (@guid, @Username, @password, @Sender, @MessageBody, @Mobile)";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@Username", Username);
        DBConnect.DBCommand.Parameters.AddWithValue("@password", password);
        DBConnect.DBCommand.Parameters.AddWithValue("@Sender", Sender);
        DBConnect.DBCommand.Parameters.AddWithValue("@MessageBody", MessageBody);
        DBConnect.DBCommand.Parameters.AddWithValue("@Mobile", Mobile);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbSMSsettings SET Username = @Username, password = @password, Sender = @Sender, MessageBody = @MessageBody, Mobile = @Mobile WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Username", Username);
        DBConnect.DBCommand.Parameters.AddWithValue("@password", password);
        DBConnect.DBCommand.Parameters.AddWithValue("@Sender", Sender);
        DBConnect.DBCommand.Parameters.AddWithValue("@MessageBody", MessageBody);
        DBConnect.DBCommand.Parameters.AddWithValue("@Mobile", Mobile);
        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbSMSsettings WHERE guid = @guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@guid", guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbSMSsettings  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbSMSsettings";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbSMSsettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbSMSsettings", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSMSsettings SMSsettings = new tbSMSsettings();

            SMSsettings.guid = new Guid(dr["guid"].ToString());
            SMSsettings.Username = (string)dr["Username"];
            SMSsettings.password = (string)dr["password"];
            SMSsettings.Sender = (string)dr["Sender"];
            SMSsettings.MessageBody = (string)dr["MessageBody"];
            SMSsettings.Mobile = (string)dr["Mobile"];

            lstData.Add(SMSsettings);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbSMSsettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbSMSsettings WHERE guid = @guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSMSsettings SMSsettings = new tbSMSsettings();

            SMSsettings.guid = new Guid(dr["guid"].ToString());
            SMSsettings.Username = (string)dr["Username"];
            SMSsettings.password = (string)dr["password"];
            SMSsettings.Sender = (string)dr["Sender"];
            SMSsettings.MessageBody = (string)dr["MessageBody"];
            SMSsettings.Mobile = (string)dr["Mobile"];

            lstData.Add(SMSsettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbSMSsettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSMSsettings WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSMSsettings SMSsettings = new tbSMSsettings();

            SMSsettings.guid = new Guid(dr["guid"].ToString());
            SMSsettings.Username = (string)dr["Username"];
            SMSsettings.password = (string)dr["password"];
            SMSsettings.Sender = (string)dr["Sender"];
            SMSsettings.MessageBody = (string)dr["MessageBody"];
            SMSsettings.Mobile = (string)dr["Mobile"];

            lstData.Add(SMSsettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbSMSsettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSMSsettings WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbSMSsettings SMSsettings = new tbSMSsettings();

            SMSsettings.guid = new Guid(dr["guid"].ToString());
            SMSsettings.Username = (string)dr["Username"];
            SMSsettings.password = (string)dr["password"];
            SMSsettings.Sender = (string)dr["Sender"];
            SMSsettings.MessageBody = (string)dr["MessageBody"];
            SMSsettings.Mobile = (string)dr["Mobile"];

            lstData.Add(SMSsettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbSMSsettings FindBy(string dbcolumn, object val)
    {
        tbSMSsettings SMSsettings = new tbSMSsettings();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbSMSsettings WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            SMSsettings.guid = new Guid(DBConnect.DBReader["guid"].ToString());
            SMSsettings.Username = (string)DBConnect.DBReader["Username"];
            SMSsettings.password = (string)DBConnect.DBReader["password"];
            SMSsettings.Sender = (string)DBConnect.DBReader["Sender"];
            SMSsettings.MessageBody = (string)DBConnect.DBReader["MessageBody"];
            SMSsettings.Mobile = (string)DBConnect.DBReader["Mobile"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return SMSsettings;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbSMSsettings WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbSMSsettings", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbSMSsettings", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbSMSsettings", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbSMSsettings WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbSMSsettings", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtUsername
Txtpassword
TxtSender
TxtMessageBody
TxtMobile


*/
