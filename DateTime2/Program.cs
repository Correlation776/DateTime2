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
            
            try
            {
                Date firstDate = Date.TryParse(Console.ReadLine());
                Date secondDate = Date.TryParse(Console.ReadLine());
                Date.CheckIfSecondLater(firstDate, secondDate);
                if (firstDate.GetClosestMonday(true) > secondDate.GetClosestMonday(false)) Console.WriteLine(0);
                else Console.WriteLine(Math.Abs(secondDate.GetClosestMonday(false) - firstDate.GetClosestMonday(true)) / 7);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}