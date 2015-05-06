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
        public BuyTransaction BuyTransaction;

        public void BuyProduct(User user, Product product)
        {
            BuyTransaction.Execute(user, product);
        }

        public void AddCreditsToAccount(User user, double amount)
        {
            
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            
        }
    }
}
