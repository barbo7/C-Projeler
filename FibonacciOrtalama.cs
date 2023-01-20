using System;

namespace ConsoleApp77
{
    class Program
    {
    //Kulanıcıdan alınan derinliğe göre fibonacci serisindeki rakamların ortalamasını alıp ekrana yazdıran uygulamayı yazınız.
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci derinliği kaçtır(sayı olarak)");
            int fibo = int.Parse(Console.ReadLine());
            Console.Clear();

            Program pro = new Program();
            double ortalamacik = pro.ortalama(pro.fibonacci(fibo), fibo);

            Console.WriteLine("Fibonacci serisindeki sayıların ortalaması= "+ortalamacik);
            Console.ReadKey();
        }

        public int[] fibonacci(int n)
        {
            int[] fib = new int[n];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i < n; i++)
                fib[i] = fib[i - 1] + fib[i - 2];

            return fib;
        }

        public double ortalama(int[] ort, int n)
        {
            double top = 0;
            foreach (int i in ort)
                top += i;

            return top / n;
        }
    }
}
