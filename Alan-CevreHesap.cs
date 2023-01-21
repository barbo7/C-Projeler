using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp79
{
    class Program
    {
        static void Main(string[] args)
        {
            Hesap hsp = new Hesap();

            Dictionary<string, string> sekil = new Dictionary<string, string>();
            sekil.Add("daire", "da");
            sekil.Add("ucgen", "u");
            sekil.Add("dikdortgen", "di");

            string sek = "", h = "";

        sekil:
            Console.WriteLine("Hangi geometrik şekli istiyorsunuz");
            Console.WriteLine("Daire = Da, Ucgen = U, Dikdortgen = Di");
            string a = Console.ReadLine().ToLower();

            foreach (string i in sekil.Keys)
                foreach (string k in sekil.Values)
                    if (a == i || a == k)
                        sek = k;
            if (sek == "")
            {
                Console.WriteLine("*************************************************");
                Console.WriteLine("Doğru Geometrik şekli seçtiğinizden emin olunuz!!");
                Console.WriteLine("-------------------------------------------------");

                goto sekil;
            }

        hesap:
            Console.WriteLine("Alan hesabı için A, Çevre hesabı için C yazınız");
            string b = Console.ReadLine().ToLower();

            if (b == "a" || b == "alan")
                h = "a";

            else if (b == "c" || b == "cevre" || b == "çevre")
                h = "c";

            else
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("Lütfen istediğiniz işlemi tekrar giriniz.");
                Console.WriteLine("---------------------------------------------");
                goto hesap;
            }

            Console.WriteLine(hsp.hesabim(sek, h));
            Console.ReadKey();
        }
    }
    class Hesap
    {
        public string hesabim(string s, string h)
        {
            string pozsay = "****************************************\n Lütfen pozitif sayısal bir değer giriniz\n----------------------------------------";
            string kenaar = "Kenar uzunluklarını giriniz (virgülle ayırarak): ";
            string tekrar = "****************\nTekrar deneyiniz\n----------------";

            string sonuc = "";
            switch (s)
            {
                case "da":
                geri1:
                    Console.WriteLine("Yarı çap giriniz r");
                    if (double.TryParse(Console.ReadLine(), out double r))
                    {
                        if (r < 0)
                        {
                            Console.WriteLine(pozsay);
                            goto geri1;
                        }
                    }
                    else
                    {
                        Console.WriteLine(pozsay);
                        goto geri1;
                    }

                    if (h == "c")
                        sonuc = (2 * Math.PI * r).ToString();
                    else
                        sonuc = (Math.PI * Math.Abs(r)).ToString();
                    break;

                case "u":
                geri2:
                    Console.WriteLine(kenaar);
                    string[] kenar = Console.ReadLine().Split(',');
                    double[] ken = new double[3];
                    if (kenar.Length == 3)
                        for (int i = 0; i < kenar.Length; i++)
                        {
                            if (double.TryParse(kenar[i], out ken[i])) ;
                            else
                            {
                                Console.WriteLine(tekrar);
                                goto geri2;
                            }
                        }
                    else
                    {
                        Console.WriteLine(tekrar);
                        goto geri2;
                    }

                    double top = 0;
                    if (ken[0] > 0 && ken[1] > 0 && ken[2] > 0)//Burada üçgen olma şartlarını da ekleyebiliriz ama kod uzar.
                        top = ken[0] + ken[1] + ken[2];
                    else goto geri2;

                    if (h == "c")
                        sonuc = top.ToString();
                    else if(h=="a")
                    {
                        top /= 2;
                        if (top > ken.Max())
                            sonuc = Math.Sqrt(top * (top - ken[0]) * (top - ken[1]) * (top - ken[2])).ToString();
                        else Console.WriteLine("Alan hesabı yapılamaz.");
                    }
                    break;

                case "di":
                    geri3:
                    Console.WriteLine(kenaar);
                    string[] kenar2 = Console.ReadLine().Split(',');
                    double[] ken2 = new double[2];
                    if (kenar2.Length == 2)
                        for (int i = 0; i < kenar2.Length; i++)
                        {
                            if (double.TryParse(kenar2[i], out ken2[i])) ;
                            else
                            {
                                Console.WriteLine(tekrar);
                                goto geri3;
                            }
                        }
                    else
                    {
                        Console.WriteLine(tekrar);
                        goto geri2;
                    }
                    if (ken2[0] > 0 && ken2[1] > 0)
                    {
                        if (h == "c")
                            sonuc = (2 * (ken2[0] + ken2[1])).ToString();
                        else if(h=="a") sonuc = (ken2[0] * ken2[1]).ToString();
                    }
                    break;
            }
            return sonuc;
        }
    }
}
