using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class BuyTransaction : Transaction
    {
        public Product Product { get; private set; }

        public BuyTransaction(User user, DateTime date, double amount, Product product) : base(user, date, amount)
        {
            Product = product;
        }

        public BuyTransaction()
        {
            
        }

        public override string ToString()
        {
            return string.Format("Bruger {0} har købt {1} d. {2} for {3} kr. Transaktions Id: {4}", User.UserName,
                Product.Name, Date, Amount, TransactionId);
        }

        public Transaction Execute(User user, Product product)
        {
            Product = product;
            var transaction = new BuyTransaction(user, DateTime.Now, product.Price, product);
            if (Product.CanBeBoughtOnCredit)
            {
                user.Balance -= product.Price;  
            }
            else if (Product.CanBeBoughtOnCredit == false && user.Balance >= product.Price)
            {
                user.Balance -= product.Price;
            }
            else throw new InsufficientCreditsException(user, product);

            return transaction;
        }

   
    }
}
