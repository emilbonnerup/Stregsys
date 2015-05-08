using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Stregsystem
    {
        public BuyTransaction buyTransaction;
        public InsertCashTransaction insertCashTransaction;

        public Stregsystem(BuyTransaction buyTransaction, InsertCashTransaction insertCashTransaction)
        {
            this.buyTransaction = buyTransaction;
            this.insertCashTransaction = insertCashTransaction;
        }

        public Transaction BuyProduct(User user, Product product)
        {
            return buyTransaction.Execute(user, product);
        }

        public void AddCreditsToAccount(User user, double amount)
        {
            insertCashTransaction.Execute(user, amount);
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            
        }

        public Product GetProduct(List<Product> products, int id)
        {
            return products[id + 1];
        }

        public User GetUser(List<User> users, string username)
        {
            foreach (User user in users)
            {
                while (string.Equals(user.UserName, username))
                {
                    return user;
                }
            }
            return null;
        }

        public List<Transaction> GetTransactions(List<Transaction> transactions, User user, int number)
        {
            List<Transaction> uTransactions = new List<Transaction>();
            foreach (var transaction in transactions)
            {
                if (string.Equals(transaction.User.UserName, user.UserName))
                {
                    
                } 
            }
            return uTransactions;
        } 

    }
}
