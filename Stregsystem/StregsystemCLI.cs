using System;
using System.Collections.Generic;

namespace Stregsystem
{
    internal class StregsystemCLI : IStregsystemUi
    {
        public Stregsystem stregsystem;

        public StregsystemCLI(Stregsystem stregsystem)
        {
            this.stregsystem = stregsystem;
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
                    var userTransactions = new List<Transaction>();
                    userTransactions = stregsystem.GetTransactions(stregsystem.Transactions, user, 10);
                    Console.WriteLine("Brugernavn: {0}, fuldt navn: {1} {2}, balance: {3}", user.UserName,
                        user.FirstName,
                        user.LastName, user.Balance);
                    Console.WriteLine("{0}'s transaktioner:", user.UserName);
                    if (userTransactions.Count == 0)
                    {
                        Console.WriteLine("Brugeren {0} har ikke lavet nogle transaktioner endnu. ", user.UserName);
                    }

                    else
                        foreach (var transaction in userTransactions)
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
            Console.WriteLine("Den indtastede admin kommando eksisterer ikke. Prøv igen.");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine("Bruger: {0} har købt {1} for {2} kr.", transaction.User.UserName,
                transaction.Product.Name, transaction.Product.Price);
        }

        public void Close()
        {
            Console.WriteLine("Programmet lukkes");
            Environment.Exit(0);
        }

        public void DisplayInsufficientCash(BuyTransaction transaction)
        {
            Console.WriteLine("Du har ikke nok penge på din konto til at foretage dette køb.");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Der er opstået en fejl: {0}", errorString);
        }

        public void Start(StregsystemCommandParser parser)
        {
            var u = new User("Emil", "Bønnerup", "emilbonnerup", "emilbonnerup@me.com", 100);
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
            var menuList = new List<Product>();
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
            var input = Console.ReadLine();
            return input;
        }

        public void DisplayIdNotCorrect(string argument)
        {
            Console.WriteLine("Argumentet du har indtast: '{0}' er ikke et korrekt Id. Prøv igen.", argument);
        }

        public void DisplayIncorrectAmountAdded()
        {
            Console.WriteLine("Du kan ikke indsætte mindre end 1 krone på en konto.");
        }
    }
}