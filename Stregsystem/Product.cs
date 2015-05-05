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
        private int productId;
        private string name;
        private double price;
        private bool active;
        private bool canBeBoughtOnCredit;

        public Product(int productId, string name, double price, bool active, bool canBeBoughtOnCredit)
        {
            productId = ProductId;
            name = Name;
            price = Price;
            active = Active;
            canBeBoughtOnCredit = CanBeBoughtOnCredit;
        }

        public int ProductId 
        {
            get { return productId; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool CanBeBoughtOnCredit
        {
            get { return active; }
            set { active = value; }
        }
    }
}
