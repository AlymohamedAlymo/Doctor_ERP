using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatora
{
    public class QRCode
    {
        public static string GenertareCode(string companyname, string vatno, string billdate, string totalnet, string vat)
        {

            List<byte> lstb = new List<byte>();
            lstb.Add(1);
            lstb.Add((byte)System.Text.ASCIIEncoding.UTF8.GetByteCount(companyname));
            lstb.AddRange(Encoding.UTF8.GetBytes(companyname));

            lstb.Add(2);
            lstb.Add((byte)System.Text.ASCIIEncoding.UTF8.GetByteCount(vatno));
            lstb.AddRange(Encoding.UTF8.GetBytes(vatno));
            lstb.Add(3);
            lstb.Add((byte)System.Text.ASCIIEncoding.UTF8.GetByteCount(billdate));
            lstb.AddRange(Encoding.UTF8.GetBytes(billdate));

            lstb.Add(4);
            lstb.Add((byte)System.Text.ASCIIEncoding.UTF8.GetByteCount(totalnet));
            lstb.AddRange(Encoding.UTF8.GetBytes(totalnet));

            lstb.Add(5);
            lstb.Add((byte)System.Text.ASCIIEncoding.UTF8.GetByteCount(vat));
            lstb.AddRange(Encoding.UTF8.GetBytes(vat));

            return Convert.ToBase64String(lstb.ToArray());

        }

         
    }
}
