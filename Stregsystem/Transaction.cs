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

        protected int TransactionId { get; private set; }
        public User User { get; private set; }
        protected DateTime Date { get; private set; }
        protected double Amount { get; private set; }

        public Transaction(User user, DateTime date, double amount)
        {
            TransactionId = GetNextId();
            User = user;
            Date = date;
            Amount = amount;
        }

        protected Transaction() 
        {
            
        }

        static Transaction()
        {
            currentId = 0;
        }

        private int GetNextId()
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
