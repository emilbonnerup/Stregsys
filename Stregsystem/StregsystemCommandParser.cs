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
                if (stregsystem.GetUser(stregsystem.Users, stringParts[0]) == null)
                {
                    cli.DisplayUserNotFound(stringParts[0]);
                }
                else cli.DisplayUserInfo(stregsystem.GetUser(stregsystem.Users, stringParts[0]));
            }

            else  if (stringParts.Count == 2)
            {
                BuyProductCommand(stringParts);  
            }

            else if (stringParts.Count == 3)
            {

                int count = Convert.ToInt32(stringParts[2]);
                for (int i = 0; i < count; i++)
                {
                    BuyProductCommand(stringParts);  
                }
            }
        }

        public void BuyProductCommand(List<string> stringParts)
        {
            var id = Convert.ToInt32(stringParts[1]);
            var products = stregsystem.GetActiveProducts(stregsystem.Products);
            var product = stregsystem.GetProduct(products, id);
            var user = stregsystem.GetUser(stregsystem.Users, stringParts[0]);

            if (product == null)
            {
                cli.DisplayProductNotFound(id);
            }

            if (user == null)
            {
                cli.DisplayUserNotFound(stringParts[0]);
            }

            if (user != null && product != null)
            {
                if(user.Balance >= product.Price)
                {
                    stregsystem.ExecuteTransaction(stregsystem.BuyProduct(user, product));
                    cli.DisplayUserBuysProduct(new BuyTransaction(user, DateTime.Now, product.Price, product));
                }
                else cli.DisplayInsufficientCash(new BuyTransaction(user, DateTime.Now, product.Price, product));     
            }
        }

        public bool IsOnlyDigits(string part)
        {
            foreach (var c in part)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
