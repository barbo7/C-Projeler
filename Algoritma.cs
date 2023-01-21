using System;

namespace ConsoleApp78
{
    class Program
    {
    //https://app.patika.dev/courses/c-projeleri/string-ve-sayi-alan
        static void Main(string[] args)
        {
            Console.WriteLine("Ekrandan bir string bir de sayı alan (aralarında virgül ile) yazınız");
            //ilgili string ifade içerisinden verilen indexteki karakteri çıkartıp ekrana yazdıran console uygulasını yazınız.
            string sonuc = Console.ReadLine();
            string[] al = sonuc.Split(',');

            string kelime = al[0].ToString();
            int sayi = int.Parse(al[1].ToString());

            Console.WriteLine(kelime.Remove(sayi,1));
            Console.ReadKey();
        }
    }
}
