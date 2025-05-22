/* Имеется база данных движения товрао на скалде, которая зранит следующую информациб: сведение о товарах, сведение о поставщиках,
 * отображние движения товаров на складе. 
 * связь между таблицу по номеру поставщика и номеру товара. движение товара отображает поступил товар или товар выдан. Если товар выдется, то поставщика нет.
 * Кол-во почтупившего или выданного товара, цена поступления и цена выдачи за 1 единицу. Выдать поступление товаров, сгруппированные по дате. Поступление
 * товаров, сгруппированные по поставщику и отсортированные по дате. Выдать список товаров, котооые имеются на складе. Выдать списоак товаров сгруппипрованных по 
 * выдаче, внутри тоде сортировка по дате. Выдать на каккую сумму был выдан товар (общая сумма). 
 * Прибыль которую полуыили на складе, тоже выдать */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }

    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
    }

    public class ProductMovement
    {
        public int MovementId { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime Date { get; set; }
        public string MovementType { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Supplier> suppliers = new List<Supplier>();
            List<ProductMovement> movements = new List<ProductMovement>();

            products.Add(new Product { ProductId = 1, Name = "Творог" });
            products.Add(new Product { ProductId = 2, Name = "Хлеб" });
            products.Add(new Product { ProductId = 3, Name = "Молоко" });

            suppliers.Add(new Supplier { SupplierId = 1, Name = "Тюкалиночка" });
            suppliers.Add(new Supplier { SupplierId = 2, Name = "Хлебодар" });
            suppliers.Add(new Supplier { SupplierId = 3, Name = "Сибмилк" });

            movements.Add(new ProductMovement
            {
                MovementId = 1,
                ProductId = 1,
                SupplierId = 1,
                Date = new DateTime(2023, 1, 10),
                MovementType = "Поступление",
                Quantity = 100,
                UnitPrice = 50
            });

            movements.Add(new ProductMovement
            {
                MovementId = 2,
                ProductId = 2,
                SupplierId = 2,
                Date = new DateTime(2023, 1, 11),
                MovementType = "Поступление",
                Quantity = 200,
                UnitPrice = 30
            });

            movements.Add(new ProductMovement
            {
                MovementId = 3,
                ProductId = 1,
                SupplierId = null,
                Date = new DateTime(2023, 1, 12),
                MovementType = "Выдача",
                Quantity = 50,
                UnitPrice = 70
            });

            movements.Add(new ProductMovement
            {
                MovementId = 4,
                ProductId = 3,
                SupplierId = 3,
                Date = new DateTime(2023, 1, 13),
                MovementType = "Поступление",
                Quantity = 150,
                UnitPrice = 40
            });

            movements.Add(new ProductMovement
            {
                MovementId = 5,
                ProductId = 2,
                SupplierId = null,
                Date = new DateTime(2023, 1, 14),
                MovementType = "Выдача",
                Quantity = 100,
                UnitPrice = 45
            });


            Console.WriteLine("Поступление товаров по датам:");
            var arrivalsDate = movements
                .Where(m => m.MovementType == "Поступление")
                .GroupBy(m => m.Date.Date)
                .OrderBy(g => g.Key);

            foreach (var group in arrivalsDate)
            {
                Console.WriteLine($"Дата: {group.Key.ToShortDateString()}");
                foreach (var movement in group)
                {
                    var product = products.First(p => p.ProductId == movement.ProductId);
                    var supplier = suppliers.First(s => s.SupplierId == movement.SupplierId);
                    Console.WriteLine($"  Товар: {product.Name}, Поставщик: {supplier.Name}, Количество: {movement.Quantity}, Цена: {movement.UnitPrice}");
                }
            }

            Console.WriteLine("\nПоступление товаров по поставщикам:");
            var arrivalsBySupplier = movements
                .Where(m => m.MovementType == "Поступление")
                .GroupBy(m => m.SupplierId)
                .OrderBy(g => g.Key);

            foreach (var group in arrivalsBySupplier)
            {
                var supplier = suppliers.First(s => s.SupplierId == group.Key);
                Console.WriteLine($"Поставщик: {supplier.Name}");

                foreach (var movement in group.OrderBy(m => m.Date))
                {
                    var product = products.First(p => p.ProductId == movement.ProductId);
                    Console.WriteLine($"  Дата: {movement.Date.ToShortDateString()}, Товар: {product.Name}, Количество: {movement.Quantity}, Цена: {movement.UnitPrice}");
                }
            }

            Console.WriteLine("\nТовары на складе:");
            var stock = new Dictionary<int, int>();

            foreach (var movement in movements)
            {
                if (movement.ProductId.HasValue)
                {
                    if (!stock.ContainsKey(movement.ProductId.Value))
                    {
                        stock[movement.ProductId.Value] = 0;
                    }

                    if (movement.MovementType == "Поступление")
                    {
                        stock[movement.ProductId.Value] += movement.Quantity;
                    }
                    else
                    {
                        stock[movement.ProductId.Value] -= movement.Quantity;
                    }
                }
            }

            foreach (var item in stock)
            {
                if (item.Value > 0)
                {
                    var product = products.First(p => p.ProductId == item.Key);
                    Console.WriteLine($"Товар: {product.Name}, Количество: {item.Value}");
                }
            }

            Console.WriteLine("\nВыдача товаров:");
            var issuesByProduct = movements
                .Where(m => m.MovementType == "Выдача")
                .GroupBy(m => m.ProductId)
                .OrderBy(g => g.Key);

            foreach (var group in issuesByProduct)
            {
                var product = products.First(p => p.ProductId == group.Key);
                Console.WriteLine($"Товар: {product.Name}");

                foreach (var movement in group.OrderBy(m => m.Date))
                {
                    Console.WriteLine($"  Дата: {movement.Date.ToShortDateString()}, Количество: {movement.Quantity}, Цена: {movement.UnitPrice}");
                }
            }

            Console.WriteLine("\nОбщая сумма выданного товара:");
            decimal totalIssuedAmount = movements
                .Where(m => m.MovementType == "Выдача")
                .Sum(m => m.Quantity * m.UnitPrice);
            Console.WriteLine($"Сумма: {totalIssuedAmount}");
            Console.WriteLine("\nПрибыль на складе:");
            decimal profit = 0;

            foreach (var movement in movements)
            {
                if (movement.MovementType == "Выдача")
                {
                    var arrival = movements
                        .Where(m => m.MovementType == "Поступление" && m.ProductId == movement.ProductId)
                        .OrderBy(m => m.Date)
                        .FirstOrDefault();

                    if (arrival != null)
                    {
                        profit += movement.Quantity * (movement.UnitPrice - arrival.UnitPrice);
                    }
                }
            }

            Console.WriteLine($"Прибыль: {profit}");
        }
    }
}