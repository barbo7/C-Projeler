using System;

namespace ConsoleApp77
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Üçgenin boyutu ne kadardır?");
            int boyut = int.Parse(Console.ReadLine());

            for (int i = 1; i <= boyut; i++)
            {
                for (int a = 1; a <= i; a++)
                    Console.Write("*");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
