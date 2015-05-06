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
            List<Product> product = new List<Product>();
            string currentPath = AppDomain.CurrentDomain.BaseDirectory + "products.csv";

            var reader = new StreamReader(File.OpenRead(currentPath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                Product p = new Product(Convert.ToInt32(values[0]), values[1], Convert.ToDouble(values[2])/10,
                    Convert.ToBoolean(values[3]), false);
                product.Add(p);

                if (values[4] != string.Empty)
                {
                    SeasonalProduct ps = new SeasonalProduct();
                }
            }
            return product;
        }

       
    }
}
