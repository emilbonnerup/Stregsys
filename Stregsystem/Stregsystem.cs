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
        public Product product;

        List<Transaction> transactions = new List<Transaction>(); 
        List<Product> products = new List<Product>(); 
        List<User> users = new List<User>(); 

        public Stregsystem(BuyTransaction buyTransaction, InsertCashTransaction insertCashTransaction, Product product)
        {
            this.buyTransaction = buyTransaction;
            this.insertCashTransaction = insertCashTransaction;
            this.product = product;
        }

        public Stregsystem()
        {
            
        }

        public List<Transaction> Transactions
        {
            get { return transactions; }
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public List<User> Users
        {
            get { return users; }
        } 

        public List<Product> FillProductList(List<Product> products)
        {
            return products = product.ReadFromFile();
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
            if (transaction.User.Balance >= transaction.Amount)
            {
                transactions.Add(transaction); 
            }
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
                    uTransactions.Add(transaction);  
                } 
            }

            uTransactions.Reverse();
            if (uTransactions.Count > 10)
            {
                uTransactions.RemoveRange(number, uTransactions.Count - 1);
            }
            return uTransactions;
        }

        public List<Product> GetActiveProducts(List<Product> products)
        {
            List<Product> activeProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.Active)
                {
                    activeProducts.Add(product);
                } 
            }
            return activeProducts;
        } 

    }
}
