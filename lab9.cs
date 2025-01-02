/* (после а только б, после б, только с, после с, только а; можно вайл) На вход подается одна стркоа и неьходимо опрещделить симовл, 
 * котрый чаще всго встечается 
 * в образце a*b, где звезда - один символ, при этом в первой строке регистр не учитыывем.
 * Во второй задаче только маленькие, необходимо поределить наибольшую
 * длину подпоследовательности, состоящей из троек abc.*/

//1 задача
/*using System;
class Programm
{
    static void Main()
    {
        string tex = Console.ReadLine();
        string text = tex.ToLower();
        Console.WriteLine(text);
        char[] ch = text.ToCharArray();
        int maxCount = -1;
        char character = ' ';
        int[] charCount = new int[256];
        int length = text.Length;
        Console.WriteLine(length);
        for (int i = 1; i < length - 1; i++)
        {
            if ((text[i - 1] == 'a') && (text[i + 1] == 'b'))
            {
                charCount[text[i]]++;
            }

        }
        for (int i = 1; i < ch.Length - 1; i++)
        {
            if ((ch[i - 1] == 'a') && (ch[i + 1] == 'b'))
            {
                if (maxCount < charCount[text[i]])
                {
                    maxCount = charCount[text[i]];
                    character = text[i];
                }
            }
        }
        Console.WriteLine($"Самый частый символ: {character} - {maxCount}");
    }
}*/


//2 задача
/*using System;
using static System.Net.Mime.MediaTypeNames;
class Programm
{
    static void Main()
    {
        string tex = Console.ReadLine();
        string text = tex.ToLower();
        int maximum = 0;
        string alf = "qwertyuiopasdfghjklzxcvbnm";
        text = text.Replace("abc", "1");
        foreach (char c in alf)
        {
            text = text.Replace(c, ' ');
        }
        Console.WriteLine(text);

        string[] newtext = text.Split(' ');
        for (int i = 0; i < newtext.Length; i++)
        {
            if (newtext[i].Length > maximum)
            {
                maximum = newtext[i].Length * 3;
            }
        }
        Console.WriteLine(maximum);

    }
}*/

