using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Product
    {
        public string Name { get; set; }

        public string Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var shops = new Dictionary<string, List<Product>>();

            while (input != "Revision")
            {
                string[] data = input.Split(", ");
                string shopName = data[0];
                string productName = data[1];
                string price = data[2];

                var product = new Product
                {
                    Name = productName,
                    Price = price
                };

                if (!shops.ContainsKey(shopName))
                {
                    shops[shopName] = new List<Product>();
                }

                shops[shopName].Add(product);

                input = Console.ReadLine();
            }

            var sortedShops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in sortedShops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    if (product.Price.EndsWith('0'))
                    {
                        double correctedPrice = double.Parse(product.Price);
                        Console.WriteLine($"Product: {product.Name}, Price: {correctedPrice:f1}");
                    }
                    else
                    {
                        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                    }
                }
            }
        }
    }
}
