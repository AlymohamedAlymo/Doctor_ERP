using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class tbEmailSettings
{

    public static List<tbEmailSettings> lstData;
    public static DataTable dtData;

    #region Fields
    [DataGUIAttribute(GUIName = "Guid", Formatting = "", Visibility = true, Width = 100, ControlName = "")]
    public Guid Guid { get; set; }
    [DataGUIAttribute(GUIName = "SenderName", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtSenderName")]
    public string SenderName { get; set; }
    [DataGUIAttribute(GUIName = "SenderEmail", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtSenderEmail")]
    public string SenderEmail { get; set; }
    [DataGUIAttribute(GUIName = "Password", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtPassword")]
    public string Password { get; set; }
    [DataGUIAttribute(GUIName = "Subject", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtSubject")]
    public string Subject { get; set; }
    [DataGUIAttribute(GUIName = "MessageBody", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtMessageBody")]
    public string MessageBody { get; set; }
    [DataGUIAttribute(GUIName = "SMTPServer", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtSMTPServer")]
    public string SMTPServer { get; set; }
    [DataGUIAttribute(GUIName = "Port", Formatting = "N0", Visibility = true, Width = 100, ControlName = "udPort")]
    public int Port { get; set; }
    [DataGUIAttribute(GUIName = "UseSSL", Formatting = "", Visibility = true, Width = 100, ControlName = "ChkUseSSL")]
    public bool UseSSL { get; set; }
    [DataGUIAttribute(GUIName = "CCEmail", Formatting = "", Visibility = true, Width = 100, ControlName = "TxtCCEmail")]
    public string CCEmail { get; set; }

    #endregion

    #region Database
    public void Insert()
    {
        DBConnect.DBCommand.CommandText = "INSERT INTO tbEmailSettings VALUES (@Guid, @SenderName, @SenderEmail, @Password, @Subject, @MessageBody, @SMTPServer, @Port, @UseSSL, @CCEmail)";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);
        DBConnect.DBCommand.Parameters.AddWithValue("@SenderName", SenderName);
        DBConnect.DBCommand.Parameters.AddWithValue("@SenderEmail", SenderEmail);
        DBConnect.DBCommand.Parameters.AddWithValue("@Password", Password);
        DBConnect.DBCommand.Parameters.AddWithValue("@Subject", Subject);
        DBConnect.DBCommand.Parameters.AddWithValue("@MessageBody", MessageBody);
        DBConnect.DBCommand.Parameters.AddWithValue("@SMTPServer", SMTPServer);
        DBConnect.DBCommand.Parameters.AddWithValue("@Port", Port);
        DBConnect.DBCommand.Parameters.AddWithValue("@UseSSL", UseSSL);
        DBConnect.DBCommand.Parameters.AddWithValue("@CCEmail", CCEmail);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Update()
    {
        DBConnect.DBCommand.CommandText = "UPDATE tbEmailSettings SET SenderName = @SenderName, SenderEmail = @SenderEmail, Password = @Password, Subject = @Subject, MessageBody = @MessageBody, SMTPServer = @SMTPServer, Port = @Port, UseSSL = @UseSSL, CCEmail = @CCEmail WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@SenderName", SenderName);
        DBConnect.DBCommand.Parameters.AddWithValue("@SenderEmail", SenderEmail);
        DBConnect.DBCommand.Parameters.AddWithValue("@Password", Password);
        DBConnect.DBCommand.Parameters.AddWithValue("@Subject", Subject);
        DBConnect.DBCommand.Parameters.AddWithValue("@MessageBody", MessageBody);
        DBConnect.DBCommand.Parameters.AddWithValue("@SMTPServer", SMTPServer);
        DBConnect.DBCommand.Parameters.AddWithValue("@Port", Port);
        DBConnect.DBCommand.Parameters.AddWithValue("@UseSSL", UseSSL);
        DBConnect.DBCommand.Parameters.AddWithValue("@CCEmail", CCEmail);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void Delete()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbEmailSettings WHERE Guid = @Guid";

        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", Guid);

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteBy(string dbcolumn, object val)
    {
        DBConnect.DBCommand.CommandText = string.Format("DELETE FROM tbEmailSettings  WHERE {0} = {1}", dbcolumn, "@" + dbcolumn);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }

    public void DeleteALL()
    {
        DBConnect.DBCommand.CommandText = "DELETE FROM tbEmailSettings";

        DBConnect.DBCommand.ExecuteNonQuery();
        DBConnect.DBCommand.Parameters.Clear();
    }
    #endregion

    public static void Fill()
    {
        lstData = new List<tbEmailSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbEmailSettings", DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbEmailSettings EmailSettings = new tbEmailSettings();

            EmailSettings.Guid = new Guid(dr["Guid"].ToString());
            EmailSettings.SenderName = (string)dr["SenderName"];
            EmailSettings.SenderEmail = (string)dr["SenderEmail"];
            EmailSettings.Password = (string)dr["Password"];
            EmailSettings.Subject = (string)dr["Subject"];
            EmailSettings.MessageBody = (string)dr["MessageBody"];
            EmailSettings.SMTPServer = (string)dr["SMTPServer"];
            EmailSettings.Port = (int)dr["Port"];
            EmailSettings.UseSSL = (bool)dr["UseSSL"];
            EmailSettings.CCEmail = (string)dr["CCEmail"];

            lstData.Add(EmailSettings);
        }
    }


    public static void Fill(Guid guid)
    {
        lstData = new List<tbEmailSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand("SELECT * FROM tbEmailSettings WHERE Guid = @Guid", DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@Guid", guid);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbEmailSettings EmailSettings = new tbEmailSettings();

            EmailSettings.Guid = new Guid(dr["Guid"].ToString());
            EmailSettings.SenderName = (string)dr["SenderName"];
            EmailSettings.SenderEmail = (string)dr["SenderEmail"];
            EmailSettings.Password = (string)dr["Password"];
            EmailSettings.Subject = (string)dr["Subject"];
            EmailSettings.MessageBody = (string)dr["MessageBody"];
            EmailSettings.SMTPServer = (string)dr["SMTPServer"];
            EmailSettings.Port = (int)dr["Port"];
            EmailSettings.UseSSL = (bool)dr["UseSSL"];
            EmailSettings.CCEmail = (string)dr["CCEmail"];

            lstData.Add(EmailSettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, object val)
    {
        lstData = new List<tbEmailSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbEmailSettings WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbEmailSettings EmailSettings = new tbEmailSettings();

            EmailSettings.Guid = new Guid(dr["Guid"].ToString());
            EmailSettings.SenderName = (string)dr["SenderName"];
            EmailSettings.SenderEmail = (string)dr["SenderEmail"];
            EmailSettings.Password = (string)dr["Password"];
            EmailSettings.Subject = (string)dr["Subject"];
            EmailSettings.MessageBody = (string)dr["MessageBody"];
            EmailSettings.SMTPServer = (string)dr["SMTPServer"];
            EmailSettings.Port = (int)dr["Port"];
            EmailSettings.UseSSL = (bool)dr["UseSSL"];
            EmailSettings.CCEmail = (string)dr["CCEmail"];

            lstData.Add(EmailSettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static void Fill(string dbcolumn, string keyword)
    {
        keyword = keyword.Replace("\'", "");
        keyword = keyword.Replace(" ", "%");

        lstData = new List<tbEmailSettings>();
        dtData = new DataTable();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbEmailSettings WHERE {0} LIKE '%{1}%'", dbcolumn, keyword), DBConnect.DBConnection);
        DBConnect.DBAdapter = new SqlDataAdapter(DBConnect.DBCommand);
        DBConnect.DBAdapter.Fill(dtData);
        foreach (DataRow dr in dtData.Rows)
        {
            tbEmailSettings EmailSettings = new tbEmailSettings();

            EmailSettings.Guid = new Guid(dr["Guid"].ToString());
            EmailSettings.SenderName = (string)dr["SenderName"];
            EmailSettings.SenderEmail = (string)dr["SenderEmail"];
            EmailSettings.Password = (string)dr["Password"];
            EmailSettings.Subject = (string)dr["Subject"];
            EmailSettings.MessageBody = (string)dr["MessageBody"];
            EmailSettings.SMTPServer = (string)dr["SMTPServer"];
            EmailSettings.Port = (int)dr["Port"];
            EmailSettings.UseSSL = (bool)dr["UseSSL"];
            EmailSettings.CCEmail = (string)dr["CCEmail"];

            lstData.Add(EmailSettings);
        }
        DBConnect.DBCommand.Parameters.Clear();
    }

    public static tbEmailSettings FindBy(string dbcolumn, object val)
    {
        tbEmailSettings EmailSettings = new tbEmailSettings();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT * FROM tbEmailSettings WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        DBConnect.DBReader = DBConnect.DBCommand.ExecuteReader();
        while (DBConnect.DBReader.Read())
        {
            EmailSettings.Guid = new Guid(DBConnect.DBReader["Guid"].ToString());
            EmailSettings.SenderName = (string)DBConnect.DBReader["SenderName"];
            EmailSettings.SenderEmail = (string)DBConnect.DBReader["SenderEmail"];
            EmailSettings.Password = (string)DBConnect.DBReader["Password"];
            EmailSettings.Subject = (string)DBConnect.DBReader["Subject"];
            EmailSettings.MessageBody = (string)DBConnect.DBReader["MessageBody"];
            EmailSettings.SMTPServer = (string)DBConnect.DBReader["SMTPServer"];
            EmailSettings.Port = (int)DBConnect.DBReader["Port"];
            EmailSettings.UseSSL = (bool)DBConnect.DBReader["UseSSL"];
            EmailSettings.CCEmail = (string)DBConnect.DBReader["CCEmail"];

        }
        DBConnect.DBReader.Close();
        DBConnect.DBCommand.Parameters.Clear();
        return EmailSettings;
    }

    public static bool IsExist(string dbcolumn, object val)
    {
        bool Result = false;
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT count(*) FROM tbEmailSettings WHERE {0} = {1}", dbcolumn, "@" + dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue(string.Format("@{0}", dbcolumn), val);
        int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        Result = iResult > 0 ? true : false;
        DBConnect.DBCommand.Parameters.Clear();
        return Result;
    }

    public static List<string> GetUniqueList(string dbcolumn)
    {
        List<string> lstUnique = new List<string>();
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT DISTINCT {0} FROM tbEmailSettings", dbcolumn), DBConnect.DBConnection);
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
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbEmailSettings", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        if (icount >= 1)
        {
            DBConnect.DBCommand = new SqlCommand(string.Format("SELECT MAX({0}) FROM tbEmailSettings", dbcolumn), DBConnect.DBConnection);
            int iResult = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
            DBConnect.DBCommand.Parameters.Clear();
            return iResult;
        }
        return icount;
    }


    public static int GetCount(string dbcolumn, object val)
    {
        DBConnect.DBCommand = new SqlCommand(string.Format("SELECT COUNT(*) FROM tbEmailSettings WHERE {0} = @val", dbcolumn), DBConnect.DBConnection);
        DBConnect.DBCommand.Parameters.AddWithValue("@val", val);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        DBConnect.DBCommand.Parameters.Clear();
        return icount;
    }

    public static int GetCount()
    {
        DBConnect.DBCommand = new SqlCommand("SELECT COUNT(*) FROM tbEmailSettings", DBConnect.DBConnection);
        int icount = int.Parse(DBConnect.DBCommand.ExecuteScalar().ToString());
        return icount;
    }
}

/*

TxtSenderName
TxtSenderEmail
TxtPassword
TxtSubject
TxtMessageBody
TxtSMTPServer
TxtPort
ChkUseSSL
TxtCCEmail


*/
