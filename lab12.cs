/* Класс люди, которые харакетризуются полями ФИО, год рождения. 2 наследника: 1) класс студенты, они характеризуются одномерным массивом оценок
 * 2) прподаватели - массив наименований предметов, которые они ведут. Программа котора реализована в меню: заполнение, печать данных, выборка студентов
 * по году рождения, выборка преподователей по наименованию дисциплины. Выход. Нельзя делать выборку если данные не занесены. дАнные подаются
 * корректно*/

using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }

    public Person(string fullName, int birthYear)
    {
        FullName = fullName;
        BirthYear = birthYear;
    }

    public override string ToString()
    {
        return $"Фио: {FullName}, Год рождения: {BirthYear}";
    }
}

class Student : Person
{
    public int[] Grades { get; set; }

    public Student(string fullName, int birthYear, int[] grades) : base(fullName, birthYear)
    {
        Grades = grades;
    }

    public override string ToString()
    {
        return base.ToString() + ", Оценки: [" + string.Join(", ", Grades) + "]";
    }
}

class Teacher : Person
{
    public string[] Subjects { get; set; }

    public Teacher(string fullName, int birthYear, string[] subjects) : base(fullName, birthYear)
    {
        Subjects = subjects;
    }

    public override string ToString()
    {
        return base.ToString() + ", Предметы: [" + string.Join(", ", Subjects) + "]";
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    static List<Teacher> teachers = new List<Teacher>();

    static void Main(string[] args)
    {
        bool dataEntered = false;
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1) Заполнить данные:");
            Console.WriteLine("2) Печать данных:");
            Console.WriteLine("3) Выборка студентов по году рождения:");
            Console.WriteLine("4) Выборка преподавателей по наименованию дисциплины:");
            Console.WriteLine("5) Выход.");
            Console.Write("Выберите действие: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterData();
                    dataEntered = true;
                    break;
                case 2:
                    if (!dataEntered)
                    {
                        Console.WriteLine("Данные не внесены.");
                    }
                    else
                    {
                        PrintData();
                    }
                    break;
                case 3:
                    if (!dataEntered)
                    {
                        Console.WriteLine("Данные не внесены.");
                    }
                    else
                    {
                        SelectStudentsByYear();
                    }
                    break;
                case 4:
                    if (!dataEntered)
                    {
                        Console.WriteLine("Данные не внесены.");
                    }
                    else
                    {
                        SelectTeachersBySubject();
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void EnterData()
    {
        Console.Write("Введите количество студентов для добавления: ");
        int studentCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine($"Введите данные для студента {i + 1}:");
            Console.Write("ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Год рождения: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Оценки (через запятую): ");
            int[] grades = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            students.Add(new Student(name, year, grades));
        }

        Console.Write("Введите количество учителей для добавления: ");
        int teacherCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < teacherCount; i++)
        {
            Console.WriteLine($"Введите данные для преподавателя {i + 1}:");
            Console.Write("ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Год рождения: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Предметы (через запятую): ");
            string[] subjects = Console.ReadLine().Split(',').ToArray();
            teachers.Add(new Teacher(name, year, subjects));
        }
    }

    static void PrintData()
    {
        Console.WriteLine("\nСтуденты:");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nПреподаватели:");
        foreach (var teacher in teachers)
        {
            Console.WriteLine(teacher);
        }
    }

    static void SelectStudentsByYear()
    {
        Console.Write("Введите год рождения, чтобы отфильтровать учащихся: ");
        int year = int.Parse(Console.ReadLine());
        var filteredStudents = students.Where(s => s.BirthYear == year);

        if (filteredStudents.Any())
        {
            Console.WriteLine($"\nСтуденты, родившиеся в {year}:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine($"Не найдено ни одного студента, родившегося в {year}.");
        }
    }

    static void SelectTeachersBySubject()
    {
        Console.Write("Введите предмет, чтобы отфильтровать преподавателей: ");
        string subject = Console.ReadLine();
        var filteredTeachers = teachers.Where(t => t.Subjects.Contains(subject));

        if (filteredTeachers.Any())
        {
            Console.WriteLine($"\nУчителя, которые преподают {subject}:");
            foreach (var teacher in filteredTeachers)
            {
                Console.WriteLine(teacher);
            }
        }
        else
        {
            Console.WriteLine($"Не найдено ни одного преподавателя, ведущего {subject}.");
        }
    }
}
