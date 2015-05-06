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
        public Stregsystem stregsystem;
        public Transaction transaction;
        public BuyTransaction buyTransaction;
        public InsertCashTransaction insertCashTransaction;

        static void Main(string[] args)
        {



            User u = new User("Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            User uu = new User("Jens", "Jensen", "Jensie", "jens@jensen.dk", 15);
            List<User> uList = new List<User>();
            uList.Add(u);
            uList.Add(uu);
            uList.Sort();

            var p = new Product(1, "Øl", 15.50, true, false);

            foreach (User user in uList)
            {
                Console.WriteLine(user.ToString());
                Console.WriteLine(string.Format("ID: {0}, Balance: {1}",user.UserId, user.Balance));
            }

            List<Product> pList = new List<Product>();
           // pList = ReadFromFile();

            Console.ReadKey();
        }

        public List<Product> ReadFromFile()
        {
            List<Product> product = new List<Product>();
            string currentPath = AppDomain.CurrentDomain.BaseDirectory + "products.csv";

            var reader = new StreamReader(File.OpenRead(currentPath));

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                Product p = new Product(Convert.ToInt32(values[0]), values[1], Convert.ToDouble(values[2]) / 10,
                    Convert.ToBoolean(values[3]), false);
                product.Add(p);

                if(values[4] != string.Empty)
                {
                    SeasonalProduct sp = new SeasonalProduct(p.ProductId, p.Name, p.Price, p.Active,
                        p.CanBeBoughtOnCredit, DateTime.Now, Convert.ToDateTime(values[4]));
                }
            }

            return product;


        }
    }
}
