using Buyer_Management.Entities;
using Buyer_Management.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Factory
{
    public class NewBuyerFactory : BaseBuyerFactory
    {
        public NewBuyerFactory(Buyer byr) : base(byr)
        {
        }

        public override IBuyerManager Create()
        {
            NewBuyerManager manager = new NewBuyerManager();
            return manager;
        }
    }
}
