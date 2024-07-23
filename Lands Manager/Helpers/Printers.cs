using System;
using System.Management.Instrumentation;
using System.Management;
using System.Collections.Generic;


class Printers
{
    public static List<string> EnumPrinters()
    {
        List<string> lstPrinters = new List<string>();
        ObjectQuery oQuery = new ObjectQuery("SELECT Name FROM Win32_Printer");
        ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
        ManagementObjectCollection oReturnCollection = oSearcher.Get();
        foreach (ManagementObject oReturn in oReturnCollection)
        {
            if (oReturn["Name"] != null)
            {
                lstPrinters.Add(oReturn["Name"].ToString().Trim());
            }
        }
        return lstPrinters;
    }
}