/* 1 з. Определить максимальный размер подпоследовательности (рядом стоящие одинаковые) состоящей из одинаковых элементов
 * 2 з. Определить минимальный размер подпоследовательности состоящей из 0
 * 3 з. Определить максимальную сумму подпоследовательности из четных чисел */

//1 задача
using System.ComponentModel.Design;
using System.Data;

//1 задача
/*Console.WriteLine("Введите количество элементов последовательности");
int n = Convert.ToInt32(Console.ReadLine());
int maxr = 0;
int prevel = 0;
int curr = 1;
for (int i = 0; i < n; i++)
{
    int el = Convert.ToInt32(Console.ReadLine());
    if (i > 0)
    {
        if (el == prevel)
        {
            curr += 1;
        }
        else
        {
            maxr = Math.Max(maxr, curr);
            curr = 1;
        }
    }
    prevel = el;
}
maxr = Math.Max(maxr, curr);
Console.WriteLine($"Максимальный размер подпоследовательности, состоящей из одинаковых элементов: {maxr}");*/

//2 задача
/*Console.WriteLine("Введите количество переменных");
int n = Convert.ToInt32(Console.ReadLine());
int mincol = n;
int curr = 0;

for (int i = 0; i < n; i++)
{
    int el = Convert.ToInt32(Console.ReadLine());

    if (el == 0)
    {
        curr++;
    }
    else
    {
        if (curr > 0)
        {
            mincol = Math.Min(curr, mincol);
            curr = 0; 
        }
    }
}

if (mincol == n)
{
    mincol = 0;
}

Console.WriteLine($"Минимальный размер подпоследовательности, состоящей из 0: {mincol}");*/

//3 задача
/*Console.WriteLine("Введите количество переменных");
int n = Convert.ToInt32(Console.ReadLine());
int maxSum = 0;
int currentSum = 0;

for (int i = 0; i < n; i++)
{
    int el = Convert.ToInt32(Console.ReadLine());

    if (el % 2 == 0)
    {
        currentSum += el;
    }
    else
    {
        maxSum = Math.Max(maxSum, currentSum);
        currentSum = 0; 
    }

}

maxSum = Math.Max(maxSum, currentSum);
if (maxSum == 0)
{
    Console.WriteLine("Нет чётных");
}
else
{
    Console.WriteLine($"Максимальная сумма подпоследовательности из четных чисел {maxSum}");
}*/


