using System;
using System.Text;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.IO;


public class Dongle
{
    public Dongle()
    {
        LstDongles = new List<string>();
        BuildDongelsList();
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public List<string> LstDongles;
    private void BuildDongelsList()
    {
        ObjectQuery oQuery = new ObjectQuery("SELECT * FROM Win32_PhysicalMedia");
        ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
        ManagementObjectCollection oReturnCollection = oSearcher.Get();
        foreach (ManagementObject oReturn in oReturnCollection)
        {
            if (oReturn["SerialNumber"] != null)
            {
                string info = oReturn["SerialNumber"].ToString().Trim();
                LstDongles.Add(EncryptInformation(info.ToUpper()));
                return;
            }
        }
    }

    #region Encrytion Process
    public string EncryptInformation(string information)
    {
        string Encinformation = information;

        Encinformation = MD5(Encinformation);
        Encinformation = MD5(Encinformation);
        Encinformation = MD5(Encinformation);
        Encinformation = Reverse(Encinformation);
        Encinformation = MD5(Encinformation + "clikcondata");
        Encinformation = Reverse(Encinformation);
        Encinformation = MD5(Encinformation);

        Encinformation = Encinformation.Substring(0, 7);

        return Encinformation.ToUpper();
    }
    #endregion

    #region Encrytion algorithms
    public static string MD5(string value)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider CProvide;
        CProvide = new System.Security.Cryptography.MD5CryptoServiceProvider();

        byte[] PwBytes = System.Text.Encoding.Default.GetBytes(value);
        PwBytes = CProvide.ComputeHash(PwBytes);

        StringBuilder TempStr = new StringBuilder();
        foreach (byte GByte in PwBytes)
        {
            TempStr.Append(GByte.ToString("x2").ToLower());
        }
        return TempStr.ToString();
    }


    private static string Encrypt(string strEncrypted)
    {
        try
        {
            byte[] b = System.Text.UTF8Encoding.UTF8.GetBytes(strEncrypted);
            string encryptedConnectionString = Convert.ToBase64String(b);
            return encryptedConnectionString;
        }
        catch
        {
            throw;
        }
    }
    #endregion

    public bool IsDongleExist(List<string> activatecodes)
    {
        foreach (string fingerCode in LstDongles)
        {
            string encinfo = EncryptInformation(EncryptInformation(fingerCode));
            foreach (string actcode in activatecodes)
            {
                if (encinfo.Equals(actcode.Trim().ToUpper()))
                    return true;
            }
           
        }
     
        return true;
    }

    public void CreateLicFile(string code)
    {
        System.IO.StreamWriter strw = new System.IO.StreamWriter(Settings.GetAppPath() + "activate.lic", true);
        strw.WriteLine(code);
        strw.Flush();
        strw.Close();
    }

    public List<string> ReadLicFile()
    {
        List<string> lstCodes;
        try
        {
            lstCodes = new List<string>();
            System.IO.StreamReader strr = new System.IO.StreamReader(Settings.GetAppPath() + "activate.lic");
            string[] strcode = strr.ReadToEnd().Split('\r');
            foreach (string code in strcode)
            {
                lstCodes.Add(code.Replace("\r", "").Replace("\n", ""));
            }
            strr.Close();
        }
        catch
        {
            lstCodes = new List<string>();
        }
        return lstCodes;
    }
}

