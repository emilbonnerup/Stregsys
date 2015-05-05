using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Transaction
    {
        private int transactionId;
        private User user;
        private DateTime date;
        private double amount;
        public override string ToString()
        {
            return string.Format("Id: {0}, Amount: {1}, Time: {2}", transactionId, amount, date);
        }

        public void execute()
        {
            
        }
    }
}
