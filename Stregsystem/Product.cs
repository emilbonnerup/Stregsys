#region Using

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace Stregsystem
{
    internal class Product
    {
        public Product(int productId, string name, double price, bool active, bool canBeBoughtOnCredit)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public Product()
        {
        }

        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public static List<Product> ReadFromFile()
        {
            var products = new List<Product>();
            var seasonProducts = new List<SeasonalProduct>();
            var currentPath = AppDomain.CurrentDomain.BaseDirectory + "products.csv";

            var reader = new StreamReader(File.OpenRead(currentPath));

            while (!reader.EndOfStream)
            {
                if (!reader.EndOfStream)
                {
                    reader.ReadLine();
                }

                var lineHTML = reader.ReadLine();
                var line = RemoveHTML(lineHTML);
                var values = line.Split(';');

                var id = Convert.ToInt32(values[0]);
                var name = values[1];
                var price = Convert.ToDouble(values[2])/100;
                var temp = Convert.ToInt32(values[3]);
                var active = Convert.ToBoolean(temp);

                var p = new Product(id, name, price,
                    active, false);
                products.Add(p);
            }
            return products;
        }

        private static string RemoveHTML(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        public override string ToString()
        {
            return string.Format("|{0,5}|{1,40}|{2,5}|", ProductId, Name, Price);
        }
    }
}