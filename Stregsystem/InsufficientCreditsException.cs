using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem
{
    class InsufficientCreditsException : System.Exception
    {
        public InsufficientCreditsException(User user, Product product)
            : base(string.Format(
                "User {0} does not have the required credits ({1}) to purchase {2}. {0} has {3} credits left.",
                user.UserName, product.Price, product.Name, user.Balance)) { }
    }
}
