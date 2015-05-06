using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class BuyTransaction : Transaction
    {
        public Product Product { get; set; }

        public BuyTransaction(int transactionId, User user, DateTime date, double amount, Product product) : base(transactionId, user, date, amount)
        {
            Product = product;
        }

        public override string ToString()
        {
            return string.Format("User {0} has bought {1} at {2} for {3} kr. Transaction Id: {4}", User.UserName,
                Product.Name, Date, Amount, TransactionId);
        }

        public void Execute(User user, Product product, double amount, int transactionId)
        {
            if (Product.CanBeBoughtOnCredit == true)
            {
                user.Balance -= amount;  
            }
            else if (Product.CanBeBoughtOnCredit == false && user.Balance > amount)
            {
                user.Balance -= amount;
            }
            else throw new InsufficientCreditsException(user, product);
            
        }

   
    }
}
