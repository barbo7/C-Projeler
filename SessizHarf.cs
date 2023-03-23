/*
 * Verilen string ifade içerisinde yanyana 2 tane sessiz varsa ekrana true, yoksa false yazdıran console uygulamasını yazınız.

Örnek: Input: Merhaba Umut Arya
Output: True False True
*/

Console.WriteLine("İçerisinde 2'den fazla sesli harfleri bulmamı istediğiniz kelimeleri sıralayınız");
string KelimeYigini = Console.ReadLine();

char[] SesliHarfler = new char[] { 'a', 'e', 'i', 'ı', 'o', 'ö', 'u', 'ü', 'A', 'E', 'I', 'İ', 'O', 'Ö', 'U', 'Ü' };
string[] Kelimeler = KelimeYigini.Split(" ");
string sonuc = "";

for(int i=0;i<Kelimeler.Length;i++)
{
    int SesliS = 0;
    bool varMi = false;
    for(int a = 0; a < Kelimeler[i].Length;a++)
    {
        foreach(char s in SesliHarfler)
            if (Kelimeler[i][a] == s)
                SesliS++;
        if (SesliS >= 2)
        {
            varMi = true;
            sonuc += varMi.ToString() + " ";
            break;
        }
    }
    if (SesliS < 2)
        sonuc += varMi.ToString() + " ";
}
Console.WriteLine();
Console.WriteLine("Sonuçlar = " + sonuc.Trim());
Console.ReadKey();
