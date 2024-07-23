using System;
using System.Globalization;


public class DateTimeHelper
{
    public static DateTime GetLastDayOfMonth(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
    }

    public static int CountDay(DayOfWeek day, DateTime start, DateTime end)
    {
        TimeSpan ts = end - start;
        int count = (int)Math.Floor(ts.TotalDays / 7);
        int remainder = (int)(ts.TotalDays % 7);
        int sinceLastDay = end.DayOfWeek - day;
        if (sinceLastDay < 0) sinceLastDay += 7;

        if (remainder >= sinceLastDay) count++;

        return count;
    }

    public static int GetDaysCount(DateTime startDate, DateTime endDate)
    {
        return (int)endDate.Subtract(startDate).TotalDays + 1;
    }

    public static DateTime GetPureTime(DateTime datetime)
    {
        return new DateTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, 0);
    }

    public static DateTime GetPureDate(DateTime datetime)
    {
        return new DateTime(datetime.Year, datetime.Month, datetime.Day, 0, 0, 0);
    }

    public static DateTime GetFirstTimeOfDay()
    {
        return new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
    }

    public static DateTime GetEndTimeOfDay()
    {
        return new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 23, 59, 59);
    }

    public static DateTime GetFirstTimeOfDate(DateTime datetime)
    {
        return new DateTime(datetime.Year, datetime.Month, datetime.Date.Day, 0, 0, 0);
    }

    public static DateTime GetEndTimeOfDate(DateTime datetime)
    {
        return new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59);
    }

    public static string ConvertDateCalendar(DateTime DateConv, string Calendar, string DateLangCulture)
    {
        DateTimeFormatInfo DTFormat;
        DateLangCulture = DateLangCulture.ToLower();
        /// We can't have the hijri date writen in English. We will get a runtime error

        if (Calendar == "Hijri" && DateLangCulture.StartsWith("en-"))
        {
            DateLangCulture = "ar-sa";
        }

        /// Set the date time format to the given culture
        DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;

        /// Set the calendar property of the date time format to the given calendar
        switch (Calendar)
        {
            case "Hijri":
                DTFormat.Calendar = new System.Globalization.HijriCalendar();
                break;

            case "Gregorian":
                DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                break;

            default:
                return "";
        }

        /// We format the date structure to whatever we want
        DTFormat.ShortDatePattern = "yyyy/MM/dd";
        return (DateConv.Date.ToString("yyyy/MM/dd", DTFormat));
    }

}

