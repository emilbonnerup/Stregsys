using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class Stregsystem
    {
        public BuyTransaction buyTransaction;

        public Stregsystem(BuyTransaction buyTransaction)
        {
            this.buyTransaction = buyTransaction;
        }

        public void BuyProduct(User user, Product product)
        {
            buyTransaction.Execute(user, product);
        }

        public void AddCreditsToAccount(User user, double amount)
        {
            
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            
        }
    }
}
