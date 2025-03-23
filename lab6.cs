/* Имеется класс машины, характеристика каждой машины: год выпуска, марка, и булевская переменная, которая говорит о том, чистая машина
 * или нет. Будет класс гараж, который будет содержать все машины (то есть список всех машин). Будет класс мойка, в котором реализован
 * один метод: помывка  машины. С помощью делегата необходимо реализваоть помывку каждой машины, если она грязная. Если чистая: выдать сообщение, 
 * что машину мыть не надо. На выходе будут сообщение, такая-то машина чистая и тд.*/

using System;
using System.Collections.Generic;

namespace WashingCar
{
    public delegate void CarWashedDelegate(Car car);

    public class Car
    {
        public int Year { get; set; }
        public string Brand { get; set; }
        public bool DirtyOrNot { get; set; }

        public Car(int year, string brand, bool dirtyOrNot)
        {
            Year = year;
            Brand = brand;
            DirtyOrNot = dirtyOrNot;
        }
    }

    public class Garage
    {
        public List<Car> Cars { get; set; } = new List<Car>();
    }

    public class CarWash
    {
        public void WashCar(Car car, CarWashedDelegate carWashedDelegate) // принимаем делегат
        {
            if (car.DirtyOrNot)
            {
                car.DirtyOrNot = false;
                Console.WriteLine($"Машинка {car.Brand} {car.Year} помыта");
            }
            else
            {
                Console.WriteLine($"Машина {car.Brand} {car.Year} чистая, мыть не надо.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            CarWash carWash = new CarWash();

            Console.WriteLine("Введите количество машин:");
            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                Console.WriteLine($"Введите данные для машины {i + 1}:");
                Console.Write("Год: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Марка: ");
                string brand = Console.ReadLine();
                Console.Write("Грязная (true - грязная / false - чистая): ");
                bool dirtyOrNot = bool.Parse(Console.ReadLine());
                garage.Cars.Add(new Car(year, brand, dirtyOrNot)); // добавляем машинку в гараж
            }

            
            CarWashedDelegate carWashedDelegate = CarWashedHandler; // создаем экземпляр делегата

            
            foreach (var car in garage.Cars) // используем делегат для мойки машинок
            {
                carWash.WashCar(car, carWashedDelegate); // передаем делегат в метод
            }
        }
        static void CarWashedHandler(Car car)
        {
            Console.WriteLine($"Обработчик: Машина {car.Brand} {car.Year} теперь чистая.");
        }
    }
}