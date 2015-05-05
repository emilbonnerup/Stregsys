using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class SeasonalProduct : Product
    {
        private DateTime seasonStartDate;
        private DateTime seasonEndDate;

        public SeasonalProduct(int productId, string name, double price, bool active, bool canBeBoughtOnCredit) : base(productId, name, price, active, canBeBoughtOnCredit)
        {
        }
    }
}
