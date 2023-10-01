using System;

namespace DateTime2
{
    // Подсчитать количество полных недель между двумя
    // датами. Неделя начинается с понедельника; проверку на корректность ввода делать 
    // обязательно; стандартными функциями не пользоваться.

    internal class Program
    {
        static void Main()
        {
            Date firstDate = new Date(10, 9, 2023);
            Date secondDate = new Date(22, 9, 2023);
            Console.WriteLine((secondDate.GetClosestMonday(false) - firstDate.GetClosestMonday(true)) / 7);
        }
    }
}