using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

public class Settings
{
    /// <summary>
    /// Read Settings
    /// </summary>
    /// <param name="ConfigFile">Filename and path to create open Config File and restore Settings</param>
    /// <param name="Class">Instance of the Class to Save</param>
    /// <returns></returns>
    public static bool ReadSettings(string ConfigFile, object Class)
    {
        if (!File.Exists(ConfigFile))
            return false;
        using (Stream StreamFile = File.Open(ConfigFile, FileMode.Open))
        {
            BinaryFormatter binformat = new BinaryFormatter();
            foreach (PropertyInfo prop in Class.GetType().GetProperties())
            {
                object objValue = binformat.Deserialize(StreamFile);
                prop.SetValue(Class, objValue, null);
            }

            StreamFile.Close();
        }
        return true;
    }

    /// <summary>
    /// Save Settings
    /// </summary>
    /// <param name="ConfigFile">Filename and path to create new Config File and store Settings</param>
    /// <param name="Class">Instance of the Class to Save</param>
    /// <returns></returns>
    public static void SaveSettings(string ConfigFile, object Class)
    {
        if (File.Exists(ConfigFile))
            File.Delete(ConfigFile);

        using (Stream StreamFile = File.Open(ConfigFile, FileMode.CreateNew))
        {
            BinaryFormatter binformat = new BinaryFormatter();

            foreach (PropertyInfo prop in Class.GetType().GetProperties())
            {
                binformat.Serialize(StreamFile, prop.GetValue(Class, null));
            }
            StreamFile.Close();
        }
    }

    public static string GetAppPath()
    {
        string ExePath = System.Windows.Forms.Application.ExecutablePath;
        if (Path.GetDirectoryName(ExePath).EndsWith("\\"))
            return Path.GetDirectoryName(ExePath);
        else
            return Path.GetDirectoryName(ExePath) + "\\";
    }
}

