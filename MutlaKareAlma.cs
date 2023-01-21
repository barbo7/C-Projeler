using System;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
        top:
            Console.WriteLine("Kaç sayı gireceksiniz");
            if (int.TryParse(Console.ReadLine(), out int n)) ;
            else goto top;
            int k = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                int sayi = int.Parse(Console.ReadLine());

                if (sayi < 67) k += 67 - sayi;
                else if (sayi > 67) b += (int)Math.Pow(sayi-67, 2);
            }
            Console.Write(k + " " + b);

            Console.ReadKey();

        }
    }
}
