using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorERP.Helpers
{
    public class ArabicNumber
    {
        public static string ToArabicNumber( string inputString)
        {

            try
            {
                string[] arabicDigits = CultureInfo.GetCultureInfo("ar-EG").NumberFormat.NativeDigits;
                StringBuilder arabicNumberBuilder = new StringBuilder();

                string outputString = "";

                foreach (char c in inputString)
                {

                    if (char.IsDigit(c))
                    {
                        outputString += arabicDigits[int.Parse(c.ToString())];
                    }
                    else
                    {
                        outputString += c.ToString();
                    }
                }

                return outputString;
            }
            catch { return inputString; }

        }

    }
}
