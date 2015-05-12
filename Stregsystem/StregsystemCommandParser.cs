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
        private Dictionary<string, Delegate> adminCommands;  


        public StregsystemCommandParser(Stregsystem stregsystem, StregsystemCLI cli)
        {
            this.stregsystem = stregsystem;
            this.cli = cli;
            adminCommands = new Dictionary<string, Delegate>();
            AddAdminCommands();
        }

        public void ParseCommand(string command)
        {
            List<string> stringParts = new List<string>(command.Split(' '));

            if (stringParts[0].Contains(':'))
            {
                AdminCommands(stringParts);
                return;
            }

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

            if (!IsOnlyDigits(stringParts[1]))
            {
                cli.DisplayIdNotCorrect(stringParts[1]);
                return;
            }

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
                if(user.Balance >= product.Price || product.CanBeBoughtOnCredit )
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

        public void AdminCommands(List<string> stringParts)
        {
            if (!adminCommands.ContainsKey(stringParts[0]))
            {
                cli.DisplayAdminCommandNotFoundMessage();
                return;
            }

            switch (stringParts.Count())
            {
                case 1:
                    adminCommands[stringParts[0]].DynamicInvoke();
                    break;
                case 2:
                    var id = 0;
                    int.TryParse(stringParts[1], out id);

                    if (stregsystem.GetProduct(stregsystem.Products, id) != null)
                    {
                        adminCommands[stringParts[0]].DynamicInvoke(id);
                    }
                    else cli.DisplayProductNotFound(id);
                    break;
                case 3:
                    var amount = 0;
                    var user = stregsystem.GetUser(stregsystem.Users, stringParts[1]);
                    int.TryParse(stringParts[2], out amount);

                    if (amount >= 1)
                    {
                        adminCommands[stringParts[0]].DynamicInvoke(user, amount);
                    }
                    else cli.DisplayIncorrectAmountAdded();
                    break;
                default:
                    cli.DisplayAdminCommandNotFoundMessage();
                    break;
            }
        }

        private void AddAdminCommands()
        {
            adminCommands.Add(":quit", new Action(cli.Close));
            adminCommands.Add(":q", new Action(cli.Close));
            adminCommands.Add(":Activate", new Action<int>(stregsystem.ActivateProduct));
            adminCommands.Add(":Deactivate", new Action<int>(stregsystem.DeactivateProduct));
            adminCommands.Add(":crediton", new Action<int>(stregsystem.ProductActivateBuyOnCredit));
            adminCommands.Add(":creditoff", new Action<int>(stregsystem.ProductDeactivateBuyOnCredit));
            adminCommands.Add(":addcredits", new Action<User, double>(stregsystem.AddCreditsToAccount));
        }

    }
}
