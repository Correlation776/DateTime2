using System;

namespace DateTime2
{
    internal class Program
    {
        static void Main()
        {
            Date firstDate = new Date(15, 5, 2005);
            Console.WriteLine(firstDate.GetDayOfWeek());
        }

        public static int[] DaysOfWeek = {1, 2, 3, 4, 5, 6, 7};

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
                    if (i % 100 != 0 && i % 4 == 0 || i % 400 == 0)
                        leapDays++;
                }

                for (int i = 0; i < month; i++)
                {
                    days += DaysInMonths[i];
                }
                
                days += 365 * (year - 1900) + leapDays;
                
                return DaysOfWeek[days % 7 - 1];
            }
        }
    }
}
