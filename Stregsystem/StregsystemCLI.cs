using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class StregsystemCLI : IStregsystemUi
    {
        public Stregsystem stregsystem;
        
        public StregsystemCLI(Stregsystem stregsystem)
        {
            this.stregsystem = stregsystem;
        }

        public void Start(StregsystemCommandParser parser)
        {
            User u = new User("Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
            stregsystem.Users.Add(u);

            stregsystem.Products = stregsystem.FillProductList();
            PrintStartMenu();
            while (true)
            {
                
                parser.ParseCommand(PromptForCommand());
            }      
        }

        public void PrintStartMenu()
        {
            Console.WriteLine("   -Emils stregsystem-   \n\n");
            Console.WriteLine("| Id |      Product     |    Price    |");
            foreach (var product in stregsystem.Products)
            {
                if (product.Active == true)
                {
                    Console.WriteLine(product.ToString());   
                }
               
            }
        }

        public string PromptForCommand()
        {
            Console.WriteLine("Enter your command (format: username id amount): ");
            string input = Console.ReadLine();
            return input;
        }



        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User with username: {0} not found. Try again", username);
        }

        public void DisplayProductNotFound(Product product)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo(User user)
        {
            foreach (var u in stregsystem.Users)
            {
                if (string.Equals(u.UserName, user.UserName))
                {
                    List<Transaction> userTransactions = new List<Transaction>();
                    userTransactions = stregsystem.GetTransactions(stregsystem.Transactions, user, 10);
                    Console.WriteLine("Username: {0}, full name: {1} {2}, balance: {3}", user.UserName, user.FirstName,
                        user.LastName, user.Balance);
                    Console.WriteLine("{0}'s transactions:", user.UserName);
                    if (userTransactions.Count == 0)
                    {
                        Console.WriteLine("User {0} has not made any transactions yet. ", user.UserName);
                    }

                    else foreach (var transaction in userTransactions)
                    {
                        Console.WriteLine(transaction.ToString());
                    }
                    user.LowBalance();
                }
                else
                {
                    DisplayUserNotFound(user.UserName);

                }
            }
        }

        public void DisplayTooManyArgumentsError()
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminCommandNotFoundMessage()
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine("User: {0} has bought {1} for {2} kr.", transaction.User.UserName, transaction.Product.Name, transaction.Product.Price);
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash(BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }
    }
}
