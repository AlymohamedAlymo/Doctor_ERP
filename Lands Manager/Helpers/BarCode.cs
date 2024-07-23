using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BarCode
{
    public static string GetBarCode(Guid guid)
    {
        return MD5(guid.ToString()).Substring(0, 10);
    }

    private static string MD5(string value)
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

}

