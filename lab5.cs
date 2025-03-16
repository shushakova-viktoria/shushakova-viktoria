/*1з. класс телефон с номером и оператором. Необходимо с использованием словаря определить, какой оператор наидолее востребованныйю Ключ - оператор,
 * значение количество телефонов.
 2з. Класс, в котором будет 2 перемеенных: реализованы методы сложения вычитания умножения деления. Необходимо создать 2 групповых делегата. 1-ый:
состоит из опреаций сложения двух переменных, вычитания из полученной суммы второй переменной, произведение разности на 2-ой элемент.
2-ой делеагт: содержит произведение двух элементов, суммирование полученного произведения со вторым элементом, полученная сумма делится на вторйо элемент.*/



/*class Telephone
{
    public string Phone { get; set; }
    public string Svyaz { get; set; }

    public Telephone(string phone, string svyaz)
    {
        Phone = phone;
        Svyaz = svyaz;
    }
}
class Program1
{
    static void Main(string[] args)
    {
        List<Telephone> telephones = new List<Telephone>();
        Dictionary <string, int> svyaz = new Dictionary<string, int>();
        Console.WriteLine("Введите количество телефонов:");
        int countOfNumbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfNumbers; i++)
        {
            Console.WriteLine($"Введите номер телефона {i + 1}:");
            string phone = Console.ReadLine();

            Console.WriteLine($"Введите оператора для номера {phone}:");
            string op = Console.ReadLine();

            telephones.Add(new Telephone(phone, op));

            if (svyaz.ContainsKey(op))
            {
                svyaz[op]++;
            }
            else
            {
                svyaz[op] = 1;
            }
        }

        var theBestOperator = svyaz.OrderByDescending(o => o.Value).First();
        Console.WriteLine($"Наиболее востребованный оператор: {theBestOperator.Key} с количеством телефонов: {theBestOperator.Value}");
    }
}*/

//2 задание


using System;

namespace DelegateExample
{

    public delegate double OperationDelegate(double a, double b);

    public class Calculator
    {
        private double FirstValue;
        private double SecondValue;

        public Calculator(double firstValue, double secondValue)
        {
           FirstValue = firstValue;
           SecondValue = secondValue;
        }


        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");
            return a / b;
        }


        public double FirstDelegate()
        {
            OperationDelegate operations = Add;
            double sum = operations(FirstValue, SecondValue);
            double difference = Subtract(sum, SecondValue);
            return Multiply(difference, SecondValue);
        }


        public double SecondDelegate()
        {
            OperationDelegate operations = Multiply;
            double product = operations(FirstValue, SecondValue);
            double sum = Add(product, SecondValue);
            return Divide(sum, SecondValue);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator(10, 5);

            double result1 = calculator.FirstDelegate();
            Console.WriteLine($"Результат первого делегата: {result1}");

            double result2 = calculator.SecondDelegate();
            Console.WriteLine($"Результат второго делегата: {result2}");
        }
    }
}







