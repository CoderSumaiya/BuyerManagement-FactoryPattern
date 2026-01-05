using Buyer_Management.Entities;
using Buyer_Management.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Manager
{
 public class BuyerManagerFactory
    {
        public BaseBuyerFactory CreateFactory(Buyer byr)
        {
            BaseBuyerFactory returnValue = null;
            if (byr.ByrType == Enums.BuyerType.New)
            {
                returnValue = new Factory.NewBuyerFactory(byr);
            }
            else if (byr.ByrType == Enums.BuyerType.Regular)
            {
                returnValue = new Factory.RegularBuyerFactory(byr);
            }
            return returnValue;
        }
    }
}
