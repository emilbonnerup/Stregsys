using System;
using System.Collections.Generic;
using System.IO;
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
        List<User> users = new List<User>();
        List<Product> products = new List<Product>();

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

        public List<User> Users
        {
            get { return users; }
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }

        } 

        public List<Product> FillProductList()
        {
            product = new Product();
            return products = product.ReadFromFile();
        }

        public Transaction BuyProduct(User user, Product product)
        {   
            buyTransaction = new BuyTransaction();
                                    
            return buyTransaction.Execute(user, product);
        }

        public void AddCreditsToAccount(User user, double amount)
        {
            insertCashTransaction = new InsertCashTransaction();
            insertCashTransaction.Execute(user, amount);
            ExecuteTransaction(new Transaction(user, DateTime.Now, amount));
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            TransactionLog();
            WriteTransaction(transaction);
        }

        public void TransactionLog()
        {
            const string filePath = @".\log.txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        private void WriteTransaction(Transaction transaction)
        {
            const string filePath = @".\log.txt";
            var write = File.AppendText(filePath);
            write.WriteLine(transaction.ToString());
            write.Close();  
        }

        public Product GetProduct(List<Product> products, int id)
        {
            return products.FirstOrDefault(product => product.ProductId == id);
        }

        public User GetUser(List<User> users, string username)
        {
            return users.FirstOrDefault(user => string.Equals(user.UserName, username));
        }

        public List<Transaction> GetTransactions(List<Transaction> transactions, User user, int number)
        {
            var uTransactions = transactions.Where(transaction => string.Equals(transaction.User.UserName, user.UserName)).ToList();

            uTransactions.Reverse();
            if (uTransactions.Count > 10)
            {
                uTransactions.RemoveRange(number, uTransactions.Count - 1);
            }
            return uTransactions;
        }

        public List<Product> GetActiveProducts(List<Product> products)
        {
            return products.Where(product => product.Active).ToList();
        }

        public void ActivateProduct(int id)
        {
            var product = GetProduct(products, id);
            product.Active = true;
        }

        public void DeactivateProduct(int id)
        {
            var product = GetProduct(products, id);
            product.Active = false;
        }

        public void ProductActivateBuyOnCredit(int id)
        {
            var product = GetProduct(products, id);
            product.CanBeBoughtOnCredit = true;
        }

        public void ProductDeactivateBuyOnCredit(int id)
        {
            var product = GetProduct(products, id);
            product.CanBeBoughtOnCredit = false;
        }

    }
}
