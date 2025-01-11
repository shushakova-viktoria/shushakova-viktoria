/*
 Описать класс с именем «Поезд», содержащий поля:
-название пункта назначения;
-номер поезда;
-время отправления.
Описать класс с именем «Станция», содержащий поля:
-название станции;
-список поездов, проходящих через станцию (список объектов класса «Поезд»).
Написать программу, выполняющую следующие действия:
-ввод с клавиатуры данных класса типа «Поезд»;
-вывод на экран информации о поездах, отправляющихся после введенного с клавиатуры времени, если таких поездов нет, вывести соответствующее сообщение;
(Реализовать меню, как в первом задание)
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Train
{
    public string Destination { get; set; }
    public int TrainNumber { get; set; }
    public TimeSpan DepartureTime { get; set; }

    public Train(string destination, int trainNumber, TimeSpan departureTime)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
    }

    public override string ToString()
    {
        return $"Поезд {TrainNumber} до {Destination} отправляется в {DepartureTime}";
    }
}

class Station
{
    public string StationName { get; set; }
    public List<Train> Trains { get; set; }

    public Station(string stationName)
    {
        StationName = stationName;
        Trains = new List<Train>();
    }

    public void AddTrain(Train train)
    {
        Trains.Add(train);
    }

    public void DisplayTrainsAfter(TimeSpan time)
    {
        var trainsAfter = Trains.Where(t => t.DepartureTime > time).OrderBy(t => t.DepartureTime);

        if (trainsAfter.Any())
        {
            Console.WriteLine($"Поезда, отправляющиеся после {time}:");
            foreach (var train in trainsAfter)
            {
                Console.WriteLine(train);
            }
        }
        else
        {
            Console.WriteLine($"Нет поездов, отправляющихся после {time}.");
        }
    }
}

class Program
{
    static List<Train> students = new List<Train>();
    static Station station = new Station("First Station");
    static void Main()
    {

        while (true)
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Заполнение информации о поездах");
            Console.WriteLine("2. Вывод на экран информации о поездах, отправляющихся после введенного с клавиатуры времени");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FillTrains();
                    break;
                case "2":
                    TimebasedTrainSearch();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
    static void FillTrains()
    {
        Console.Write("Введите количество поездов: ");
        int trainCount;
        if (int.TryParse(Console.ReadLine(), out trainCount) && trainCount > 0)
        {

            for (int i = 0; i < trainCount; i++)
            {

                Console.WriteLine($"Введите данные для поезда {i + 1}:");

                Console.Write("Место назначения: ");
                string destination = Console.ReadLine();

                Console.Write("Номер поезда: ");
                int trainNumber = int.Parse(Console.ReadLine());

                Console.Write("Время отправления (HH:mm): ");
                TimeSpan departureTime = TimeSpan.Parse(Console.ReadLine());

                station.AddTrain(new Train(destination, trainNumber, departureTime));
            }
        }
        else
        {
            Console.WriteLine("Ошибка! Введите положительное целое число.");
        }
    }
    static void TimebasedTrainSearch()
    {
        Console.Write("Введите время для проверки движения поездов после (HH:mm): ");
        TimeSpan timeToCheck = TimeSpan.Parse(Console.ReadLine());

        station.DisplayTrainsAfter(timeToCheck);
    }
}



