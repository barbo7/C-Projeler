using System;
using System.Collections.Generic;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
        ikili:
            Console.WriteLine("Kaç ikili gireceksiniz? ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0) ;
            else goto ikili;
            List<int> tek = new List<int>();
            List<int> cift = new List<int>();

            for (int i = 0; i < 2 * n; i++)
            {
                if (i % 2 == 0)
                    tek.Add(int.Parse(Console.ReadLine()));
                else cift.Add(int.Parse(Console.ReadLine()));
            }
            
            Console.WriteLine("********");

            for(int i=0;i<n;i++)
            {
                double top = tek[i] + cift[i];
                if (tek[i] == cift[i]) Console.WriteLine(Math.Pow(top,2));
                else Console.WriteLine(tek[i] + cift[i]);
            }
            Console.ReadKey();
        }
    }
}
