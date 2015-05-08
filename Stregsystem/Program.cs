using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Stregsystem
{
    class Program
    {

        public Product product;
        private BuyTransaction buyTransaction;
        private Stregsystem stregsystem;
        public Transaction transaction;
        public InsertCashTransaction insertCashTransaction;

        static void Main(string[] args)
        {
            Program program = new Program();
            BuyTransaction buyTransaction = new BuyTransaction();
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction();
            Stregsystem stregsystem = new Stregsystem(buyTransaction, insertCashTransaction);

            List<Transaction> transactions = new List<Transaction>();

            // Debugging
            User u = new User("Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            User uu = new User("Jens", "Jensen", "Jensie", "jens@jensen.dk", 15);
            List<User> uList = new List<User>();
            uList.Add(u);
            uList.Add(uu);
            uList.Sort();

            foreach (User user in uList)
            {
                Console.WriteLine(user.ToString());
                Console.WriteLine("ID: {0}, Balance: {1}",user.UserId, user.Balance);
            }

            List<Product> pList = program.ReadFromFile();

            Console.ReadKey();
        }

        public List<Product> ReadFromFile()
        {
            List<Product> products = new List<Product>();
            List<SeasonalProduct> seasonProducts = new List<SeasonalProduct>();
            string currentPath = AppDomain.CurrentDomain.BaseDirectory + "products.csv";

            var reader = new StreamReader(File.OpenRead(currentPath));

            while(!reader.EndOfStream)
            {
                if(!reader.EndOfStream) { reader.ReadLine(); }
                
                var line = reader.ReadLine();
                var values = line.Split(';');
                  
                int id = Convert.ToInt32(values[0]);
                string name = values[1];
                double price = Convert.ToDouble(values[2]) / 10;
                int temp = Convert.ToInt32(values[3]);
                bool active = Convert.ToBoolean(temp);

                Product p = new Product(id, name, price,
                    active, false);
                products.Add(p);
                
               
           //     else if( string.IsNullOrEmpty(values[4]) != true)
           //     {
           //         
           //         DateTime dt = DateTime.ParseExact(values[4], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
           //         SeasonalProduct sp = new SeasonalProduct(id, name, price, active,
           //             false, DateTime.Now, dt);
           //         seasonProducts.Add(sp);
           //     }
            }
            return products;
        }
    }
}
