using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    internal class User
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string userName;
        private string email;
        private double balance;

        public User(int userId, string firstName, string lastName, string userName, string email, double balance)
        {
            userId = UserId;
            firstName = FirstName;
            lastName = LastName;
            userName = UserName;
            email = Email;
            balance = Balance;
        }

        public int UserId
        {
            get { return userId; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}
