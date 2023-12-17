using System.Globalization;

namespace Shopping.Database.Classes;

public class DateAndTime
{
    public async Task<string> GetPersianDate()
    {
        var dateTime = DateTime.Now;
        var persian = new PersianCalendar();
        var date = persian.GetYear(dateTime).ToString("0000") + "/" + persian.GetMonth(dateTime).ToString("00") + "/" + persian.GetDayOfMonth(dateTime).ToString("00");

        var time = dateTime.Hour.ToString("00") + ":" + dateTime.Minute.ToString("00") + ":" + dateTime.Second.ToString("00");

        //return date+" "+time;
        return String.Format("{0} {1}", date, time);
    }
}
