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
            List<Product> menuList = new List<Product>();
            Console.WriteLine("   -Emils stregsystem-   \n\n");
            Console.WriteLine("| Id |      Produkt     |    Pris   |");
            menuList = stregsystem.GetActiveProducts(stregsystem.Products);
            foreach (var product in menuList)
            {
                Console.WriteLine(product.ToString()); 
            }
        }

        public string PromptForCommand()
        {
            Console.WriteLine("Indtast din kommando (format: username id amount): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("Bruger med brugernavn: {0} blev ikke fundet. Prøv igen", username);
        }

        public void DisplayProductNotFound(int id)
        {
            Console.WriteLine("Der blev ikke fundet et produkt med id {0}", id);
        }

        public void DisplayUserInfo(User user)
        {
            foreach (var u in stregsystem.Users)
            {
                if (string.Equals(u.UserName, user.UserName))
                {
                    List<Transaction> userTransactions = new List<Transaction>();
                    userTransactions = stregsystem.GetTransactions(stregsystem.Transactions, user, 10);
                    Console.WriteLine("Brugernavn: {0}, fuldt navn: {1} {2}, balance: {3}", user.UserName, user.FirstName,
                        user.LastName, user.Balance);
                    Console.WriteLine("{0}'s transaktioner:", user.UserName);
                    if (userTransactions.Count == 0)
                    {
                        Console.WriteLine("Brugeren {0} har ikke lavet nogle transaktioner endnu. ", user.UserName);
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
            Console.WriteLine("Du har indtastet mere end tre argumenter (brugernavn id antal). Prøv igen.");
        }

        public void DisplayAdminCommandNotFoundMessage()
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine("Bruger: {0} har købt {1} for {2} kr.", transaction.User.UserName, transaction.Product.Name, transaction.Product.Price);
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

        public void DisplayIdNotCorrect(string argument)
        {
            Console.WriteLine("Argumentet du har indtast: '{0}' er ikke et korrekt Id. Prøv igen.", argument);
        }
    }
}
