using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
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
                    else cli.DisplayUserNotFound(stringParts[0]);
                }
            }
            else  if (stringParts.Count == 2)
            {
                int id = Convert.ToInt32(stringParts[1]);
                foreach (var product in stregsystem.Products)
                {
                    if (id == product.ProductId && product.Active == true)
                    {
                        foreach (var user in stregsystem.Users)
                        {
                            if (stringParts[0] == user.UserName)
                            {   
                                
                                if (user.Balance >= product.Price)
                                {
                                    stregsystem.ExecuteTransaction(stregsystem.BuyProduct(user, product));
                                    cli.DisplayUserBuysProduct(new BuyTransaction(user, DateTime.Now, product.Price, product));
                                }
                            }
                            else cli.DisplayUserNotFound(stringParts[0]);
                        }
                    }
                    // Product not found?
                }
            }
        }
    }
}
