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

        public static Date? TryParse(string input)
        {
            Date result = new Date();
            string[] temp = input.Split('.');
            int.TryParse(temp[0], out result.day);
            int.TryParse(temp[1], out result.month);
            int.TryParse(temp[2], out result.year);
            if (result.day < 1 || result.month < 1 || result.month > 12)
                return null;
            switch (result.month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (result.day > 31) return null;
                    break;
                case 2:
                    if (result.year % 4 == 0 && result.year % 100 != 0 && result.day > 29 || result.day > 28) return null;
                    break;
                default:
                    if (result.day > 30) return null;
                    break;
            }
            return result;
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