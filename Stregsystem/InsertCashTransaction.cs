using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class InsertCashTransaction : Transaction
    {

        public InsertCashTransaction(User user, DateTime date, double amount) : base(user, date, amount)
        { 
        }

        public InsertCashTransaction()
        {
            
        }

        public override string ToString()
        {
            return string.Format("User {0} has added {1} kr. to his/her account at {2}. Transaction ID: {3}", User,
                Amount, Date, TransactionId);
        }

        public void Execute(User user, double amount)
        {
            user.Balance += amount;
        }
    }
}
