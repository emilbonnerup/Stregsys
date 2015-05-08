using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class StregsystemCommandParser
    {
        public Stregsystem stregsystem;
        public StregsystemCLI cli;


        public StregsystemCommandParser(Stregsystem stregsystem, StregsystemCLI cli)
        {
            this.stregsystem = stregsystem;
            this.cli = cli;
        }

        public void ParseCommand(string command)
        {

            List<string> stringParts = new List<string>(command.Split(' '));
            
            if (stringParts.Count == 1)
            {
                foreach (var user in stregsystem.Users)
                {
                    if (string.Equals(stringParts[0], user.UserName))
                    {
                        cli.DisplayUserInfo(user);
                    }
                    else Console.WriteLine("You have not entered a correct username.");
                }
            }
            if (stringParts.Count == 2)
            {
                foreach (var product in stregsystem.Products)
                {
                    if (Convert.ToInt32(stringParts[1]) == product.ProductId)
                    {
                        foreach (var user in stregsystem.Users)
                        {
                            if (stringParts[0] == user.UserName)
                            {
                                stregsystem.Transactions.Add(stregsystem.BuyProduct(user, product));
                            } 
                        }
                    }
                }
            }
        }
    }
}
