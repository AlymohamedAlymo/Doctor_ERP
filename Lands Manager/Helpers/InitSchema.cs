using System;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;

class InitSchema
{
    private static string strScript = global::DoctorERP.Properties.Resources.db;
    private static string strJobScript = string.Empty;// global::DoctorERP.Properties.Resources.backjob;

    public static void InitSchemaScript(string DataBase, string Description)
    {
        DBConnect.DBCommand = new SqlCommand("USE " + DataBase, DBConnect.DBConnection);
        DBConnect.DBCommand.ExecuteNonQuery();

        strScript = strScript.Replace("%DatabaseDescription%", Description);
        IEnumerable<string> commandStrings = Regex.Split(strScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        foreach (string strQuery in commandStrings)
        {
            if (strQuery.Trim().Length > 0)
            {

                try
                {
                    DBConnect.DBCommand = new SqlCommand(strQuery, DBConnect.DBConnection);
                    DBConnect.DBCommand.ExecuteNonQuery();
                }
                catch
                {
                }
            }
        }
    }

    public static void InitUpdateScript(string DataBase, string scriptfilename)
    {
        DBConnect.DBCommand = new SqlCommand("USE " + DataBase, DBConnect.DBConnection);
        DBConnect.DBCommand.ExecuteNonQuery();

        string strUpdateScript = string.Empty;

        strUpdateScript += "GO" + Environment.NewLine + File.ReadAllText(AppSetting.GetAppPath() + string.Format("updates\\{0}.sql", scriptfilename)) + Environment.NewLine + "GO";

        string[] commandStrings = Regex.Split(strUpdateScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        StreamWriter fswriter = new StreamWriter(AppSetting.GetAppPath() + "log.txt", false, System.Text.Encoding.UTF8);

        for (int i = 0; i < commandStrings.Length; i++)
        {
            string strQuery = commandStrings[i];

            if (strQuery.Trim().Length > 0)
            {
                try
                {
                    DBConnect.DBCommand = new SqlCommand(strQuery, DBConnect.DBConnection);
                    DBConnect.DBCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    fswriter.WriteLine("{0} {1}", strQuery, ex.Message);

                }
            }
        }
        fswriter.Flush();
        fswriter.Close();
    }

    public static void ExecuteProcScript(string DataBase, string scriptfilename)
    {
        DBConnect.DBCommand = new SqlCommand("USE " + DataBase, DBConnect.DBConnection);
        DBConnect.DBCommand.ExecuteNonQuery();
        int timeout = DBConnect.DBCommand.CommandTimeout;
        string strUpdateScript = string.Empty;

        strUpdateScript += "GO" + Environment.NewLine + File.ReadAllText(AppSetting.GetAppPath() + string.Format("updates\\{0}.sql", scriptfilename)) + Environment.NewLine + "GO";

        string[] commandStrings = Regex.Split(strUpdateScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        for (int i = 0; i < commandStrings.Length; i++)
        {
            string strQuery = commandStrings[i];

            if (strQuery.Trim().Length > 0)
            {
                try
                {
                    DBConnect.DBCommand = new SqlCommand(strQuery.Trim(), DBConnect.DBConnection);
                    DBConnect.DBCommand.CommandType = CommandType.StoredProcedure;
                    DBConnect.DBCommand.CommandTimeout = 0;
                    DBConnect.DBCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("{0} {1}", strQuery, ex.Message);
                    //Console.WriteLine("-----");
                }
            }
        }

        DBConnect.DBCommand.CommandTimeout = timeout;
    }

    public static void InitJobScript(string DataBase, DateTime dtTime, string path)
    {
        strJobScript = strJobScript.Replace("GO", "~").Replace("%DATABASENAME%", DataBase).Replace("%DATE%", DateTime.Now.ToString("yyyyMMdd")).Replace("%TIME%", dtTime.ToString("HH0000")).Replace("%PATH%", path);

        foreach (string strQuery in strJobScript.Split('~'))
        {
            try
            {
                DBConnect.DBCommand = new SqlCommand(strQuery, DBConnect.DBConnection);
                DBConnect.DBCommand.ExecuteNonQuery();
            }
            catch
            {

            }
        }
    }


    public static void CreateDataBase(string DataBase, string DataBasePath)
    {
        string DbScript = string.Empty;
        if (DataBasePath.Length > 0)
        {
            if (!Directory.Exists(AppSetting.DataBasePath))
            {
                try
                {
                    Directory.CreateDirectory(AppSetting.DataBasePath);
                }
                catch
                {

                }
            }
            DbScript = string.Format(@"CREATE DATABASE {0} ON PRIMARY (NAME={1},FILENAME = '{2}') COLLATE Arabic_CI_AS", DataBase, DataBase, DataBasePath);
        }
        else
        {
            DbScript = string.Format(@"CREATE DATABASE {0} COLLATE Arabic_CI_AS", DataBase);
        }
        DBConnect.DBCommand = new SqlCommand(DbScript, DBConnect.DBConnection);
        DBConnect.DBCommand.ExecuteNonQuery();
    }
}

