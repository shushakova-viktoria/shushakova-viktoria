using System;
using System.Collections.Generic;
using System.Linq;
namespace Program
{
    public class Computer(int id, string name, string date, string operationSystem)
    {
        public int Id { get; set; } = id;
        public string Brand { get; set; } = name;
        public string Date { get; set; } = date;
        public string OperationSystem { get; set; } = operationSystem;
    }
    public class User(int id, string name, string date, bool hasComputer, int computerId)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Date { get; set; } = date;
        public bool HasComputer { get; set; } = hasComputer;
        public int ComputerId { get; set; } = computerId;
    }
    public class UsersComputers
    {
        public static List<User> Users = new List<User>
    {
        new User(1, "Иванов Иван", "1990", true, 1),
        new User(2, "Петров Петр", "1985", false, 0),
        new User(3, "Сидорова Анна", "1992", true, 2),
        new User(4, "Кузнецов Алексей", "2000", true, 3),
        new User(5, "Маркова Елена", "1995", false, 0),
        new User(6, "Смирнов Дмитрий", "1988", true, 4),
        new User(7, "Николаева Юлия", "1991", false, 0)
    };

        public static List<Computer> Computers = new List<Computer>
    {
        new Computer(1, "Asus", "2025", "Windows 11"),
        new Computer(2, "Chuwi", "2015", "Windows 7"),
        new Computer(3, "Apple", "2024", "MacOS"),
        new Computer(4, "Acer", "2021", "LinuxOS")
    };

        public static void Main(string[] args)
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\n0 - Выход\n1 - все пользователи без компьютера\n2 - получить по ОС компьютера\n3 - получить по марке компьютера\n4 - каких пользователей больше по наличию компьютера");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("");
                        break;
                    case 1:
                        GetUsersWithoutComputer();
                        break;
                    case 2:
                        GetUsersByOS();
                        break;
                    case 3:
                        GetUsersByBrand();
                        break;
                    case 4:
                        GetUsersWithMoreComputers();
                        break;
                }
            }
        }

        private static void GetUsersWithoutComputer()
        {
            var usersWithout = Users.Where(u => !u.HasComputer);

            Console.WriteLine("Пользователи без компьютера:");
            foreach (var user in usersWithout)
            {
                Console.WriteLine($"{user.Name} (Год рождения: {user.Date})");
            }
        }

        private static void GetUsersByOS()
        {
            Console.Write("Введите название операционной системы: ");
            string os = Console.ReadLine();

            var usersWithOS = Users
                .Where(u => u.HasComputer)
                .Where(u =>
                {
                    var comp = Computers.FirstOrDefault(c => c.Id == u.ComputerId);
                    return comp != null && comp.OperationSystem.Equals(os, StringComparison.OrdinalIgnoreCase);
                });

            Console.WriteLine($"\nПользователи с ОС {os}:");
            foreach (var user in usersWithOS)
            {
                Console.WriteLine(user.Name);
            }
        }

        private static void GetUsersByBrand()
        {
            Console.Write("Введите марку компьютера: ");
            string brand = Console.ReadLine();

            var usersWithBrand = Users
                .Where(u => u.HasComputer)
                .Where(u =>
                {
                    var comp = Computers.FirstOrDefault(c => c.Id == u.ComputerId);
                    return comp != null && comp.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase);
                });

            Console.WriteLine($"\nПользователи с компьютерами {brand}:");
            foreach (var user in usersWithBrand)
            {
                Console.WriteLine(user.Name);
            }
        }

        private static void GetUsersWithMoreComputers()
        {
            int withComp = Users.Count(u => u.HasComputer);
            int withoutComp = Users.Count - withComp;

            Console.WriteLine($"\nПользователей с компьютером: {withComp}");
            Console.WriteLine($"Пользователей без компьютера: {withoutComp}");

            if (withComp > withoutComp)
                Console.WriteLine("Больше пользователей с компьютерами.");
            else if (withComp < withoutComp)
                Console.WriteLine("Больше пользователей без компьютеров.");
            else
                Console.WriteLine("Количество пользователей с и без компьютеров одинаково.");
        }
    }
}
