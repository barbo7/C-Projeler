//SON DERECE APTALCA
using System;

namespace ConsoleApp77
{
    class Program
    {
        static void Main(string[] args)
        {
            daire d = new daire();
            Console.WriteLine("Yarı çap giriniz");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine(d.dairecik(r));
            Console.ReadKey();
            }
        }
        class daire
        {
            public string dairecik(int r)
            {
                string seks = "";
                for (int y = -r; y <= r; y++)
                {
                    for (int x = -r; x <= r; x++)
                    {
                        if (x * x + y * y <= r * r)
                            seks += "*";
                        else seks += " ";
                    }
                    seks += "\n";
                }
                return seks;
            }
        }
    }

