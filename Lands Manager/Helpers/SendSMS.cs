using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


class SendSMS
{
    public static string SendMessage(string numbers, string msg)
    {
        tbSMSsettings.Fill();

        tbSMSsettings smssettings = tbSMSsettings.lstData[0];
        string strResponse = string.Empty;

        try
        {
            string postData = "username=" + smssettings.Username + "&password=" + smssettings.password + "&numbers=" + numbers + "&sender=" + smssettings.Sender + "&message=" + msg;

            WebRequest request = WebRequest.Create(string.Format("http://www.hisms.ws/api.php?send_sms&{0}", postData));
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader strr = new StreamReader(stream);
                    strResponse = strr.ReadToEnd();
                    strr.Close();
                }
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        return strResponse;
    }

    public static string GetBalance(string numbers, string msg)
    {
        tbSMSsettings.Fill();

        tbSMSsettings smssettings = tbSMSsettings.lstData[0];
        string strResponse = string.Empty;

        try
        {

            WebRequest request = WebRequest.Create(string.Format("http://www.hisms.ws/api.php?get_balance&username={0}&password={1}", smssettings.Username, smssettings.password));

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader strr = new StreamReader(stream);
                    strResponse = strr.ReadToEnd();
                    strr.Close();
                }
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        return strResponse;
    }

    public static string TestResult(string res)
    {
        string Error = string.Empty;
        switch (res)
        {
            case "1": Error = "اسم المستخدم غير صحيح"; break;
            case "2": Error = "كلمة المرور غير صحيحة"; break;
            case "404": Error = "لم يتم إدخال جميع البرامترات المطلوبة"; break;
            case "403": Error = "تم تجاوز عدد المحاولات المسموحة"; break;
            case "504": Error = "الحساب معطل"; break;
            case "3": Error = "تم الإرسال"; break;

            case "4": Error = "لا يوجد أرقام"; break;
            case "5": Error = "لا يوجد رسالة"; break;
            case "6": Error = "المرسل خاطئ"; break;
            case "7": Error = "المرسل غير مفعل"; break;
            case "8": Error = "الرسالة تحتوي على كلمة ممنوعة"; break;
            case "9": Error = "الرصيد غير كافي"; break;
            default:
                Error = res.ToString();
                break;
        }
        return Error;
    }



}

