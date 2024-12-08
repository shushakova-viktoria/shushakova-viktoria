/* 1з дан двумерный массив м на н. Неободимо поменять строку с минимальым элеметом на строку с максимальным эл. Минимум и максимум только один.
 * 2з необходимо определить  массиве точки минимакса (минимальное в строке максимальное в столбце
или наоборот максимальное в строке и минимальное в столбце)
 * 3з необходимо выдать пары номеров строк состоящих из одинаковых элементов (сортировать элементы в строках 
 * нельзя)*/
using System;

class Program
{
    static void Main()
    {
        //1 задача
        /*Console.Write("Введите количество строк: ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[m, n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine($"Введите элементы {i+1} строки");
            for (int j = 0; j < n; j++)
            {
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        

        int minStr = 0;
        int maxStr = 0;
        int minEl = array[0, 0]; 
        int maxEl = array[0, 0];

        for (int i = 0; i < m; i++)
        {
            int rowMin = int.MaxValue;
            int rowMax = int.MinValue;

            for (int j = 0; j < n; j++)
            {
                if (array[i, j] < rowMin)
                {
                    rowMin = array[i, j];
                }
                if (array[i, j] > rowMax)
                {
                    rowMax = array[i, j];
                }
            }

            if (rowMin < minEl)
            {
                minEl = rowMin;
                minStr = i;
            }

            if (rowMax > maxEl)
            {
                maxEl = rowMax;
                maxStr = i;
            }
        }

        for (int j = 0; j < n; j++)
        {
            int ispr = array[minStr, j];
            array[minStr, j] = array[maxStr, j];
            array[maxStr, j] = ispr;
        }

        Console.WriteLine("Теперь массив имеет вид:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }*/


        //2 задача
        //необходимо определить  массиве точки минимакса (минимальное в строке максимальное в столбце
        //или наоборот максимальное в строке и минимальное в столбце)

        /*Console.WriteLine("Введите количество строк ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов ");
        int m = Convert.ToInt32(Console.ReadLine());
        int[,] A = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("Введите {0},{1} элемент  массива ", i + 1, j + 1);
                A[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int min = 100000;
        int max = -1;
        int[] Mini = new int[n], Maxi = new int[n];

        for (int i = 0; i < n; i++)
        {
            min = 100000;
            max = -1;

            for (int j = 0; j < m; j++)
            {
                if (A[i, j] <= min)
                {
                    min = A[i, j];
                }
                if (A[i, j] >= max)
                {
                    max = A[i, j];
                }

            }
            Mini[i] = min;
            Maxi[i] = max;
            Console.WriteLine();
        }
        Console.WriteLine(" n:   min:  max:");
        for (int k = 0; k < n; k++)
        {
            Console.WriteLine("{0,2}){1,6}{2,6}", k + 1, Mini[k], Maxi[k]);
        }


        int minc = 100000;
        int maxc = -1;
        int[] Minic = new int[m], Maxic = new int[m];
        for (int i = 0; i < m; i++)
        {
            minc = 100000;
            maxc = -1;

            for (int j = 0; j < n; j++)
            {
                if (A[j, i] <= minc)
                {
                    minc = A[j, i];
                }
                if (A[j, i] >= maxc)
                {
                    maxc = A[j, i];
                }

            }
            Minic[i] = minc;
            Maxic[i] = maxc;
            Console.WriteLine();
        }
        Console.WriteLine(" m:   min:  max:");
        for (int k = 0; k < m; k++)
        {
            Console.WriteLine("{0,2}){1,6}{2,6}", k + 1, Minic[k], Maxic[k]);
        }*/


        //3 задача
        /*static int Maxi(int[,] array, int n, int m)
        {
            int max = array[1, 1];
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }
            return max;

        }
        static bool AreRowsEqual(int[,] array, int row1, int row2)
        {
            int numColumns = array.GetLength(1);

            int maxValue = Maxi(array, array.GetLength(0), array.GetLength(1));


            int[] count1 = new int[maxValue + 1];
            int[] count2 = new int[maxValue + 1];

            for (int col = 0; col < numColumns; col++)
            {
                count1[array[row1, col]]++;
                count2[array[row2, col]]++;
            }

            for (int i = 0; i <= maxValue; i++)
            {
                if (count1[i] != count2[i])
                    return false;
            }

            return true;
        }

        static void Main()
        {
            Console.WriteLine("Введите количество строк ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] A = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Введите {0},{1} элемент  массива ", i + 1, j + 1);
                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (AreRowsEqual(A, i, j))
                    {
                        Console.WriteLine($"Строки {i} и {j} одинаковы.");
                    }
                }
            }



        }
    }
}*/
       