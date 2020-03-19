using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Module_Gaziview.Entities;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Module_Gaziview
{
    public static class Helper
    {
        private static DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        private static Calendar cal = dfi.Calendar;
        private static int _WeekStartDayInt = 1;
        private static double _ToleranceWarning = 0.3;
        private static DayOfWeek _WeekStartDay = DayOfWeek.Monday;
        public static Color[] colors = new Color[] { Color.Red, Color.Green, Color.Orange, Color.Blue, Color.Chocolate, Color.DeepPink, Color.Indigo, Color.Bisque, Color.Coral, Color.Goldenrod, Color.MistyRose };
        public static ZedGraph.SymbolType[] symbols = new ZedGraph.SymbolType[] {ZedGraph.SymbolType.Circle, ZedGraph.SymbolType.Triangle, ZedGraph.SymbolType.Square, ZedGraph.SymbolType.Star, ZedGraph.SymbolType.Plus, ZedGraph.SymbolType.Diamond,
                                                                                ZedGraph.SymbolType.TriangleDown,ZedGraph.SymbolType.HDash, ZedGraph.SymbolType.XCross,ZedGraph.SymbolType.VDash,ZedGraph.SymbolType.Circle};
        private static IList<o_Constant> _AllConstants = o_Constant.Load();

        public static int GetWeekNr(DateTime date)
        {
            //// Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            //// be the same week# as whatever Thursday, Friday or Saturday are,
            //// and we always get those right
            //DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            //if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            //{
            //    date = date.AddDays(3);
            //}

            //// Return the week of our adjusted day

            //return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek , _WeekStartDay);

            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
        public static int GetNumbersOfWeek(int Year)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            DateTime dt = new DateTime(Year, 12, 31);
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            // cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, _WeekStartDay);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3).AddDays(_WeekStartDayInt-1);
        }
        public static DateTime GetLastDate(Int64 ChainID)
        {
            try
            {
                return (DateTime)SynapseCore.Database.DBFunction.ExecuteScalarQuery("SELECT MAX(Date) FROM Gaziview_GasEmission WHERE ChainID=" + ChainID);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static IList<o_Constant> AllConstants { get { return _AllConstants; } }
        public static void LoadConstants()
        {
            _AllConstants = o_Constant.Load();
        }
        public static DayOfWeek WeekStartDay
        {get{return _WeekStartDay;}}
        public static double ToleranceWarning
        { get { return _ToleranceWarning; } set { _ToleranceWarning = value; } }
        public static string ImageToBase64(Image image,System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public static double AsScientific(this object x)
        {

          double z;
          if (double.TryParse(x.ToString(), out z))
                return z;
            else
                throw new InvalidScienitficException();
        }
        public static double LastDaysEmissionAvg(DateTime date, Int64 ChainID)
        {
            return (double)SynapseCore.Database.DBFunction.ExecuteScalarQuery("SELECT avg([GasEmission]) FROM [SYNAPSE].[dbo].[Gaziview_GasEmission] WHERE Date BETWEEN '" + date.AddDays(-7).ToString("yyyy-MM-dd") + "' AND '" + date.ToString("yyyy-MM-dd") + "' AND ChainID=" + ChainID);
        }
        public static double LastDaysVolumeAvg(DateTime date, Int64 ChainID)
        {
            return (double)SynapseCore.Database.DBFunction.ExecuteScalarQuery("SELECT avg([GasVolume]) FROM [SYNAPSE].[dbo].[Gaziview_GasEmission] WHERE Date BETWEEN '" + date.AddDays(-7).ToString("yyyy-MM-dd") + "' AND '" + date.ToString("yyyy-MM-dd") + "' AND ChainID=" + ChainID);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }


    }
    public class InvalidScienitficException : Exception
    {
        public InvalidScienitficException()
        {
        }

        public InvalidScienitficException(string message)
            : base(message)
        {
        }

        public InvalidScienitficException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
