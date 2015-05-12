using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Transaction
    {
        private static int currentId;

        public int TransactionId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public Transaction(User user, DateTime date, double amount)
        {
            TransactionId = GetNextId();
            User = user;
            Date = date;
            Amount = amount;
        }

        public Transaction() 
        {
            
        }

        static Transaction()
        {
            currentId = 0;
        }

        protected int GetNextId()
        {
            return ++currentId;
        }
        
        public override string ToString()
        {
            return string.Format("Id: {0}, Kr.: {1}, Tidspunkt: {2}", TransactionId, Amount, Date);
        }

        public void Execute()
        {
            
        }
    }
}
