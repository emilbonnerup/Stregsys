﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class BuyTransaction : Transaction
    {
        public Product Product { get; set; }

        public BuyTransaction(User user, DateTime date, double amount, Product product) : base(user, date, amount)
        {
            Product = product;
        }

        public BuyTransaction()
        {
            
        }

        public override string ToString()
        {
            return string.Format("User {0} has bought {1} at {2} for {3} kr. Transaction Id: {4}", User.UserName,
                Product.Name, Date, Amount, TransactionId);
        }

        public Transaction Execute(User user, Product product)
        {
            this.Product = product;
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
