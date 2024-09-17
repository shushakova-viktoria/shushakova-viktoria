using System;
using System.ComponentModel.Design;
using System.Data;
using System.Net.Quic;
internal class Program
{
    static void Main(string[] args)
    {
        /*Дана последовательность элементов в кол-ве n(не менее трехэлементов)
         * 1 з. Определить кол-во элементов меньших 0
         * 2 з. Определить среди элементов 2 максимальный элемент 
         * 3 з. Определить кол-во элементов, являющихся локальными минимумами(эл, зн-ия которых меньше соседей)*/

        //1 задача

        /*int n;
        Console.WriteLine("Введите количество элементов");
        n = Convert.ToInt32(Console.ReadLine());
        int schet = 0;
        Console.WriteLine("Введите элементы");
        for (int i = 0; i < n; i++)
        {
            int per = Convert.ToInt32(Console.ReadLine());
            if (per < 0)
            {
                schet++;
            }
        }
        Console.WriteLine($"Количество отрицательных элементов = {schet}");*/


        //2 задача

        /*int n;
        Console.WriteLine("Введите количество элементов");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите элементы");
        int maxvt = 0;
        int maxvt2 = 0;
        for (int i = 0; i < n; i++)
        {
            int per = Convert.ToInt32(Console.ReadLine());
            if (per >= maxvt)
            {
                maxvt2 = maxvt;
                maxvt = per;
            }    
            else if (per >= maxvt2)
            {
                maxvt2 = per;
            }
        }
        Console.WriteLine($"Второй максимальный элемент = {maxvt2}");*/

        //3 задача 

        /*int n;
        int schet = 0;
        int prevper;
        int nextper;
        int techper;
        Console.WriteLine("Введите количество элементов");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите элементы");
        prevper = Convert.ToInt32(Console.ReadLine());
        techper = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i < n-1; i++)
        {
            nextper = Convert.ToInt32(Console.ReadLine());
            if ((techper < prevper) && (techper < nextper))
            {
                schet++;
            }
            prevper = techper;
            techper = nextper;
        }
        Console.WriteLine($"Количество локальных минимумов = {schet}");*/

    }
}




