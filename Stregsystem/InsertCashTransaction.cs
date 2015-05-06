using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class InsertCashTransaction : Transaction
    {
        public override string ToString()
        {
            return string.Format("User {0} has added {1} kr. to his/her account at {2}. Transaction ID: {3}", User,
                Amount, Date, TransactionId);
        }

        public InsertCashTransaction(int transactionId, User user, DateTime date, double amount) : base(transactionId, user, date, amount)
        { 

        }
    }
}
