using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stregsystem
{
    class User : IComparable<User>
    {
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
        public double Balance { get; set; }

        private static int idCounter = 0;

        public User(string firstName, string lastName, string userName, string email, double balance)
        {
            UserId = System.Threading.Interlocked.Increment(ref idCounter);
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Balance = balance;
            IsUserInputValid();
        }

        public override string ToString()
        {
            return string.Format("Navn: {0} {1}, brugernavn: {2}, email: {3}", FirstName, LastName, UserName, Email);
        }

        public void LowBalance()
        {
            if (Balance <= 50)
            {
                Console.WriteLine("Du har under 50 kr. tilbage på din konto. Overvej at tilføje flere.\n"); 
            }
        }

        public void IsUserInputValid()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                throw new Exception("That is not a valid first name. Try again.");
            }

            if (string.IsNullOrEmpty(LastName))
            {
                 throw new Exception("That is not a valid last name. Try again.");
            }

            if (string.IsNullOrEmpty(UserName))
            {
                throw new Exception("That is not a valid username. Your username cannot be a blank space.");
            }

            if (!Regex.IsMatch(UserName, @"^[0-9a-z_]+$"))
            {
                throw new Exception("That is not a valid username. It may only contain lowercase letters, numbers 0-9 and underscore."); 
            }

            //This Regex expressions is taken from https://msdn.microsoft.com/en-us/library/ff650303.aspx
            if (
                !Regex.IsMatch(Email,
                    @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                throw new Exception("You have not entered a valid email adress. Try Again.");
            }           

        }

        int IComparable<User>.CompareTo(User other)
        {
            return UserId.CompareTo(other.UserId);
        }
    }
}
