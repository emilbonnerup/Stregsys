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
            // Debugging
            User u = new User("Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            User uu = new User("Jens", "Jensen", "Jensie", "jens@jensen.dk", 15);
            List<User> uList = new List<User>();
            uList.Add(u);
            uList.Add(uu);
            uList.Sort();

            var p = new Product(1, "Øl", 15.50, true, false);

            // -------------

            foreach (User user in uList)
            {
                Console.WriteLine(user.ToString());
                Console.WriteLine("ID: {0}, Balance: {1}",user.UserId, user.Balance);
            }

            List<Product> pList = ReadFromFile();

            Console.ReadKey();
        }

        public static List<Product> ReadFromFile()
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

                if(values[4] != string.Empty)
                {
                    SeasonalProduct sp = new SeasonalProduct(id, name, price, active,
                        false, DateTime.Now, Convert.ToDateTime(values[4]));
                    seasonProducts.Add(sp);
                }
            }
            return products;
        }
    }
}
