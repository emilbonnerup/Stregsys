using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Transaction
    {
        public int TransactionId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        private static int tIdCounter = 0;

        public Transaction(User user, DateTime date, double amount)
        {
            this.TransactionId = System.Threading.Interlocked.Increment(ref tIdCounter);
            User = user;
            Date = date;
            Amount = amount;
        }

        public Transaction() 
        {
            
        }
        
        public override string ToString()
        {
            return string.Format("Id: {0}, Amount: {1}, Time: {2}", TransactionId, Amount, Date);
        }

        public void execute()
        {
            
        }
    }
}
