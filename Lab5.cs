using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        bool isStrictlyIncreasing = true;
        for (int i = 1; i < n; i++)
        {
            if (arr[i] <= arr[i - 1])
            {
                isStrictlyIncreasing = false;
                break;
            }
        }
        Console.WriteLine("Массив в строгом порядке возрастания: " + (isStrictlyIncreasing ? "Да" : "Нет"));

        int colvo = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 10 == 3)
            {
                colvo++;
            }
        }
        Console.WriteLine($"Количество элементов, заканчивающихся на 3: {colvo}");

        Console.WriteLine("Суммы цифр каждого элемента:");
        for (int i = 0; i < n; i++)
        {
            int summa = 0;
            int num = arr[i];
            while (num != 0)
            {
                summa += num % 10;
                num /= 10;
            }
            Console.WriteLine($"Число {arr[i]}, а его сумма {summa}");
        }


        int sumChet = 0;
        int countChet = 0;
        int srednee;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 2 == 0)
            {
                sumChet += arr[i];
                countChet++;
                
            }
        }
        srednee = sumChet / countChet;
        Console.WriteLine($"Среднее арифметическое = {srednee}");
        
    }
}