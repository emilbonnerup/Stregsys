using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Product
    {
		public int ProductId { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public bool Active { get; set; }
		public bool CanBeBoughtOnCredit { get; set; }

        public Product(int productId, string name, double price, bool active, bool canBeBoughtOnCredit)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        
        public List<Product> ReadFromFile()
        {
            List<Product> products = new List<Product>();
            List<SeasonalProduct> seasonProducts = new List<SeasonalProduct>();
            string currentPath = AppDomain.CurrentDomain.BaseDirectory + "products.csv";

            var reader = new StreamReader(File.OpenRead(currentPath));

            while(!reader.EndOfStream)
            {
                if(!reader.EndOfStream)
                {
                    reader.ReadLine();
                }

                var line = reader.ReadLine();
                var values = line.Split(';');

                int id = Convert.ToInt32(values[0]);
                string name = values[1];
                double price = Convert.ToDouble(values[2]) / 100;
                int temp = Convert.ToInt32(values[3]);
                bool active = Convert.ToBoolean(temp);

                Product p = new Product(id, name, price,
                    active, false);
                products.Add(p);

            }
            return products;
        }
    }
}
