/*
Algoritma
Verilen string ifade içerisindeki ilk ve son karakterin yerini değiştirip tekrar ekrana yazdıran console uygulamasını yazınız.

Örnek: Input: Merhaba Hello Algoritma x

Output: aerhabM oellH algoritmA x
*/

Console.WriteLine("İlk ve son harfi yer değiştirilecek kelimeyi yazınız");
string kelime = Console.ReadLine();
int SonHarfIndex = kelime.Length-1;
string YeniKelime = "";
string sonH = kelime[SonHarfIndex].ToString(), ilkH= kelime[0].ToString();
YeniKelime = sonH + kelime.Substring(1, SonHarfIndex - 1) + ilkH;
Console.WriteLine();
Console.WriteLine(YeniKelime);
