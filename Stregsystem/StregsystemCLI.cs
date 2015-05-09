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

            stregsystem.FillProductList();
            
            PrintStartMenu();

            parser.ParseCommand(PromptForCommand());

        }

        public void PrintStartMenu()
        {
            Console.WriteLine("   -Emils stregsystem-   \n\n");
            Console.WriteLine("| Id |      Product     |    Price    |");
            foreach (var product in stregsystem.Products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public string PromptForCommand()
        {
            Console.WriteLine("Indtast nu din kommando til stregsystemet: ");
            string input = Console.ReadLine();
            return input;
        }



        public void DisplayUserNotFound(User user)
        {
            Console.WriteLine("User with username: {0} not found. Try again", user.UserName);
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

                    foreach (var transaction in userTransactions)
                    {
                        Console.WriteLine(transaction.ToString());
                    }
                    user.LowBalance();
                }
                else
                {
                    DisplayUserNotFound(user);

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
            Console.WriteLine("User: {0} has bought {1} for {2}", transaction.User.UserName, transaction.Product.Name, transaction.Product.Price);
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
