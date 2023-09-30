namespace DateTime2
{
    readonly struct Date
    {
        private static readonly int[] DaysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private readonly int day;
        private readonly int month;
        private readonly int year;

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int GetClosestMonday(bool next)
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
            int weekDay = days % 7 == 0 ? 7 : days % 7;
            if (weekDay == 1) return days;
            if (next) return days + 8 - weekDay;
            return days - (weekDay - 1);
        }
    }
}