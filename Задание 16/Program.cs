using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Задание_16
{
    /*Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
    Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
    Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
    Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
    Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
    class Program
    {
        static void Main(string[] args)
        {
            // Сначала создадим массив товаров и сериализуем его в json-строку:
            Console.WriteLine("Последовательно введите код первого товара, название товара и его цену:");
            Product product1 = new Product()
            {
                productCode = Convert.ToInt32(Console.ReadLine()),
                productName = Console.ReadLine(),
                productCost = Convert.ToDouble(Console.ReadLine())
            };
            Console.WriteLine("Последовательно введите код второго товара, название товара и его цену:");
            Product product2 = new Product()
            {
                productCode = Convert.ToInt32(Console.ReadLine()),
                productName = Console.ReadLine(),
                productCost = Convert.ToDouble(Console.ReadLine())
            };
            Console.WriteLine("Последовательно введите код третьего товара, название товара и его цену:");
            Product product3 = new Product()
            {
                productCode = Convert.ToInt32(Console.ReadLine()),
                productName = Console.ReadLine(),
                productCost = Convert.ToDouble(Console.ReadLine())
            };
            Console.WriteLine("Последовательно введите код четвёртого товара, название товара и его цену:");
            Product product4 = new Product()
            {
                productCode = Convert.ToInt32(Console.ReadLine()),
                productName = Console.ReadLine(),
                productCost = Convert.ToDouble(Console.ReadLine())
            };
            Console.WriteLine("Последовательно введите код пятого товара, название товара и его цену:");
            Product product5 = new Product()
            {
                productCode = Convert.ToInt32(Console.ReadLine()),
                productName = Console.ReadLine(),
                productCost = Convert.ToDouble(Console.ReadLine())
            };
            Product[] products = {product1, product2, product3, product4, product5};
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);

            //Теперь создадим файл "Produсts.json" и запишем туда json-строку:
            string path = "Products.json";
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(jsonString);
            }
            //Прочитаем созданный файл "Products.json":
            string jsonBackString = "";
            using (StreamReader sr = new StreamReader(path))
            {
                jsonBackString = sr.ReadToEnd();
            }
            //Десериализуем данный из файла:
            Product[] productList = JsonSerializer.Deserialize<Product[]>(jsonBackString);
            //Найдём самый дорогой товар:
            Product maxProduct = productList[0];
            foreach(Product i in productList)
            {
                if (i.productCost > maxProduct.productCost)
                {
                    maxProduct = i;
                }
            }
            Console.WriteLine("Самый дорогой товар: {0}", maxProduct.productName);
            Console.ReadKey();
        }
    }
    class Product
    {
        public int productCode { get; set; }
        public string productName { get; set; }
        public double productCost { get; set; }
    }
}
