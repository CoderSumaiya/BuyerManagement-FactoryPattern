using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Manager
{
   public class RegularBuyerManager : IBuyerManager
    {
        public double GetDiscount()
        {
            return 40.00;
        }
    }
}
