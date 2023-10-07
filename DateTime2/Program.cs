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
            Console.WriteLine("Enter two dates (DD.MM.YYYY):");
            Date firstDate = (Date)Date.TryParse(Console.ReadLine());
            Date secondDate = (Date)Date.TryParse(Console.ReadLine());
            Console.WriteLine((secondDate.GetClosestMonday(false) - firstDate.GetClosestMonday(true)) / 7);
        }
    }
}