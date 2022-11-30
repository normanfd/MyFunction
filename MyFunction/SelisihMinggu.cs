using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFunction
{
    public class SelisihMinggu
    {
        /// <summary>
        /// fungsi utk hitung jumlah minggu diantara 2 tanggal 
        /// lebih hari dianggap 1 minggu, cth 1 week 1 day, maka dianggap 2 minggu
        /// </summary>
        /// <param name="date1"> tanggal mulai </param>
        /// <param name="date2"> tanggal akhir </param>
        /// <returns> int sebagai representasi jumlah minggu diantara 2 tanggal</returns>

        public static int WeekBetweenTwoDates(DateTime? date1, DateTime? date2, FirstDayOfWeek DayOfWeek = FirstDayOfWeek.Sunday)
        {
            date1 = date1.Value.AddDays(-GetDayOfWeek(date1.Value, DayOfWeek));
            date2 = date2.Value.AddDays(-GetDayOfWeek(date2.Value, DayOfWeek));

            double weeks = Math.Abs(((DateTime)date1 - (DateTime)date2).TotalDays / 7);
            return (int)Math.Ceiling(weeks);
        }

        private static int GetDayOfWeek(DateTime dt, FirstDayOfWeek weekdayFirst)
        {
            switch (weekdayFirst)
            {
                default:
                //throw ExceptionUtils.VbMakeException(5);
                case FirstDayOfWeek.System:
                    weekdayFirst = (FirstDayOfWeek)checked(GetDateTimeFormatInfo().FirstDayOfWeek + 1);
                    break;
                case FirstDayOfWeek.Sunday:
                case FirstDayOfWeek.Monday:
                case FirstDayOfWeek.Tuesday:
                case FirstDayOfWeek.Wednesday:
                case FirstDayOfWeek.Thursday:
                case FirstDayOfWeek.Friday:
                case FirstDayOfWeek.Saturday:
                    break;
            }

            checked
            {
                return unchecked(checked(unchecked((int)dt.DayOfWeek) - unchecked((int)weekdayFirst) + 8) % 7) + 1;
            }
        }

        internal static DateTimeFormatInfo GetDateTimeFormatInfo()
        {
            return Thread.CurrentThread.CurrentCulture.DateTimeFormat;
        }
    }
}
