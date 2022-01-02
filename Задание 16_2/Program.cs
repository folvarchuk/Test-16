using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Задание_16_2
{
    /*Необходимо разработать программу для получения информации о товаре из json-файла.
    Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Products.json";
            using(StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
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
