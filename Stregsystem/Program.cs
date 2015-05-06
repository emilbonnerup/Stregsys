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
            User u = new User(0, "Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            User uu = new User(0, "Jens", "Jensen", "Jensie", "jens@jensen.dk", 15);
            List<User> uList = new List<User>();
            uList.Add(u);
            uList.Add(uu);
            uList.Sort();


            foreach (User user in uList)
            {
                Console.WriteLine(user.ToString());
                Console.WriteLine(string.Format("ID: {0}",user.UserId));
            }

            Console.ReadKey();

            var p = new Product(1, "Øl", 15.50, true, false);
            List<Product> pList = new List<Product>();
            pList.Add(p);


        }
    }
}
