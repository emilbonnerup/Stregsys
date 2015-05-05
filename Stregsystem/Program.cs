using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User(1, "Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            List<User> uList = new List<User>();
            uList.Add(u);

            string str = u.UserToString();
            Console.WriteLine(str);
            Console.ReadKey();

            var p = new Product(1, "Øl", 15.50, true, false);
            List<Product> pList = new List<Product>();
            pList.Add(p);


        }
    }
}
