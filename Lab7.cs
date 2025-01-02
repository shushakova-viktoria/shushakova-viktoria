/*1з. На вход подается зубчатый массив (кол-во элементов в каждой строке может быть различно. Необходимо с помощью функции орагнизовать вход 
 * элементов в строку (размерность строк может быть различно). Определить номера строк, элементы в которрых образуют равномерно
 * убывающую последовательность.*/
using System;
class Program
{
    static int[][] DlyaMassiva()
    {
        Console.Write("Введите размер массива: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[][] arr = new int[size][];
        for (int i = 0; i < size; i++)
        {
            int n0 = 0;
            Console.WriteLine($"Введите длину {i}-й строки");
            n0 = Convert.ToInt32(Console.ReadLine());
            arr[i] = new int[n0];
            Console.WriteLine("Введите элементы массива");
            for (int j = 0; j < n0; j++)
            {
                arr[i][j] = Convert.ToInt32(Console.ReadLine());
            }

        }
        return arr; 
    }
    static bool UbyvaetLi(int[] row)
    {
        int razn = row[0] - row[1];
        for (int i = 1; i < row.Length; i++)
        {
            if ((row[i] >= row[i - 1]) || (row[i-1] - row[i]!= razn))
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        int[][] a = DlyaMassiva();
        for (int i = 0; i < a.Length; i++)
        {
            if (UbyvaetLi(a[i]))
            {
                Console.WriteLine($"Строка {i} убывающая");
            }
        }
    }


}
      
        
   

