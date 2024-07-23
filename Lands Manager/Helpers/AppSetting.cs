using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class AppSetting
{
    public static int SqlType;
    public static string ServerName;
    public static string UserName;
    public static string Password;
    public static bool SqlAuth;
    public static string DataBase;
    public static string DataBasePath;

    public static string ConfigFile
    {
        get
        {
            return GetAppPath() + "Config.cfg";
        }
    }


    public static void SaveSetting()
    {
        if (File.Exists(ConfigFile))
            File.Delete(ConfigFile);

        using (Stream StreamFile = File.Open(ConfigFile, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            BinaryFormatter binformat = new BinaryFormatter();
            binformat.Serialize(StreamFile, SqlType);
            binformat.Serialize(StreamFile, ServerName);
            binformat.Serialize(StreamFile, SqlAuth);
            binformat.Serialize(StreamFile, UserName);
            binformat.Serialize(StreamFile, Password);
            binformat.Serialize(StreamFile, DataBase);
            binformat.Serialize(StreamFile, DataBasePath);

            StreamFile.Close();
        }
    }

    public static bool ReadSetting()
    {
        if (!File.Exists(ConfigFile))
        {
            SqlType = 0;
            ServerName = "(LocalDb)\\AccountDB";
            SqlAuth = false;
            UserName = "sa";
            Password = string.Empty;
            DataBase = "Data" + DateTime.Now.ToString("yyyy");
            DataBasePath = @"D:\SQL Data\";

            return false;
        }

        using (Stream StreamFile = File.Open(ConfigFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            BinaryFormatter binformat = new BinaryFormatter();
            SqlType = (int)binformat.Deserialize(StreamFile);
            ServerName = (string)binformat.Deserialize(StreamFile);
            SqlAuth = (bool)binformat.Deserialize(StreamFile);
            UserName = (string)binformat.Deserialize(StreamFile);
            Password = (string)binformat.Deserialize(StreamFile);
            DataBase = (string)binformat.Deserialize(StreamFile);
            DataBasePath = (string)binformat.Deserialize(StreamFile);


            StreamFile.Close();
        }
        return true;
    }



    public static string GetAppPath()
    {
        string ExePath = System.Windows.Forms.Application.ExecutablePath;
        if (Path.GetDirectoryName(ExePath).EndsWith("\\"))
        {
            return Path.GetDirectoryName(ExePath);
        }
        else
        {
            return Path.GetDirectoryName(ExePath) + "\\";
        }
    }
}

