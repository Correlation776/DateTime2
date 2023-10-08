using System;

namespace DateTime2
{
    public struct Date
    {
        private static readonly int[] DaysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private int day;
        private int month;
        private int year;

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public static Date TryParse(string input)
        {
            Date result = new Date();
            string[] temp = input.Split('.');
            try
            {
                int.TryParse(temp[0], out result.day);
                int.TryParse(temp[1], out result.month);
                int.TryParse(temp[2], out result.year);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidDateException("enter a valid date please");
            }
            
            if (result.day < 1 || result.month < 1 || result.month > 12)
                throw new InvalidDateException(result.day < 1 ? "day must be 1 or higher" : "month must be between 1 and 12");
            if (result.day > DaysInMonths[result.month - 1] && !(result.year % 4 == 0 && result.year % 100 != 0 || result.year % 400 == 0))
                throw new InvalidDateException("there aren't that many days in this month");
            if (result.month == 2 && (result.year % 4 == 0 && result.year % 100 != 0 || result.year % 400 == 0) && result.day > 29)
                throw new InvalidDateException("even in a leap year there's only 29 days in february");
            if (result.year < 1900)
                throw new InvalidDateException("it only works with 01.01.1900 onward");
            
            return result;
        }

        public static void CheckIfSecondLater(Date first, Date second)
        {
            if (first.GetNumberOfDays() > second.GetNumberOfDays())
                throw new InvalidDateException("the second date must be later than the first");
        }

        int GetNumberOfDays()
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
            return days;
        }

        public int GetClosestMonday(bool next)
        {
            int days = GetNumberOfDays();
            int weekDay = days % 7 == 0 ? 7 : days % 7;
            if (weekDay == 1) return days;
            if (next) return days + 8 - weekDay;
            return days - (weekDay - 1);
        }
    }
}