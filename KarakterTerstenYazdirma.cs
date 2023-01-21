using System;

namespace ConsoleApp78
{
    class Program
    {
        static void Main(string[] args)
        {
        //https://app.patika.dev/courses/c-projeleri/karakter
        
            Console.WriteLine("ters yazılması istenen cümle:");
            string sentence = Console.ReadLine();
            string[] word = sentence.Split(' ');
            for (int i = 0; i < word.Length; i++)
            {
                string m = word[i];
                word[i] = "";

                for (int a = m.Length-1; a >= 0; a--)
                    word[i] += m[a];
            }
            string result = "";

            foreach (var i in word)
                result += i + " ";
            Console.WriteLine(result.Trim());
                
            Console.ReadKey();
        }
    }
}
