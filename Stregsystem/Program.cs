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
            Stregsystem stregsystem = new Stregsystem();
            StregsystemCLI cli = new StregsystemCLI(stregsystem); 
            StregsystemCommandParser parser = new StregsystemCommandParser(stregsystem, cli);
            cli.Start(parser);

            Console.ReadKey();
        }
    }
}
