using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
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


       
    }
}
