using Buyer_Management.Entities;
using Buyer_Management.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Factory
{
    public class RegularBuyerFactory : BaseBuyerFactory
    {
        public RegularBuyerFactory(Buyer byr) : base(byr)
        {
        }

        public override IBuyerManager Create()
        {
            RegularBuyerManager manager = new RegularBuyerManager();
            return manager;
        }
    }
}
