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

        static void Main(string[] args)
        {
            var stregsystem = new Stregsystem();
            var cli = new StregsystemCLI(stregsystem); 
            var parser = new StregsystemCommandParser(stregsystem, cli);
            cli.Start(parser);

            Console.ReadKey();
        }
    }
}
