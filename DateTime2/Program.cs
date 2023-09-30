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

        public static string[] DaysOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", 
            "Friday", "Saturday", "Sunday"};
        
        struct Date
        {
            public int Day;
            public int Month;
            public int Year;

            public Date(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public string GetDayOfWeek()
            {
                int leapDays = 0;
                for (int i = 1900; i <= Year; i++)
                {
                    if (Year % 100 != 0 && Year % 4 == 0 || Year % 400 == 0)
                        leapDays++;
                }
                int days = Day;
                switch (Month)
                {
                    case 1:
                        break;
                    case 2:
                        days += 31;
                        break;
                    default:
                        days += 28 + 30 * (Month / 2) + 31 * (Month / 2) + leapDays;
                        break;
                }
                days += 365 * (Year - 1900 + 1);
                
                return DaysOfWeek[days % 7];
            }
        }
    }
}
