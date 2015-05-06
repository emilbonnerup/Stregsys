using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
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

        public User(int userId, string firstName, string lastName, string userName, string email, double balance)
        {
            this.UserId = System.Threading.Interlocked.Increment(ref idCounter);
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Balance = balance;
        }

        public override string ToString()
        {
            return string.Format("Navn: {0} {1}, brugernavn: {2}, email: {3}", FirstName, LastName, UserName, Email);
        }

        public string UserToString()
        {
            return string.Format("Navn: {0} {1}, brugernavn: {2}, email: {3}", FirstName, LastName, UserName, Email);
        }


        int IComparable<User>.CompareTo(User other)
        {
            return this.UserId.CompareTo(other.UserId);
        }
    }
}
