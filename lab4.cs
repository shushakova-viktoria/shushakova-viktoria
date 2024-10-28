using System;
class Programm1
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int m = 0;
        int p = 0;
        do
        {
            p = 0;
            while (n != 0)
            {
                if ((n % 10) % 2 == 0)
                {
                    m = m * 10 + (n % 10);
                    p = 1;
                }
                n = n / 10;
            }
            if ((m == 0) && (p == 0))
            {
                Console.WriteLine("Нет четных");
            }
            else if ((m == 0) && (p == 1))
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(m);
            }
            n = Convert.ToInt32(Console.ReadLine());
            m = 0;
        }
        while (n > 0);
    }
}

