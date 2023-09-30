using System;

namespace DateTime2
{
    internal class Program
    {
        static void Main()
        {
            Date firstDate = new Date(12, 02, 2004);
            Console.WriteLine(firstDate.GetDayOfWeek());
        }

       

        public static int[] DaysInMonths = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        
        struct Date
        {
            private readonly int day;
            private readonly int month;
            private readonly int year;
            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public int GetDayOfWeek()
            {
                int days = day;
                int leapDays = 0;
                for (int i = 1900; i <= year; i++)
                {
                    if ((i % 100 != 0 && i % 4 == 0 || i % 400 == 0) && (i != year || month > 2))
                        leapDays++;
                }

                for (int i = 0; i < month - 1; i++)
                {
                    days += DaysInMonths[i];
                }
                
                days += 365 * (year - 1900) + leapDays;
                
                return days % 7;
            }
        }
    }
}
