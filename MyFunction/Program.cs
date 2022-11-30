using System;

namespace MyFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var date1 = DateTime.Now;
            var date2 = DateTime.Now.AddDays(1);

            var selisihminggu = SelisihMinggu.WeekBetweenTwoDates(date1, date2);
            Console.WriteLine(selisihminggu);
        }
    }
}
