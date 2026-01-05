using Buyer_Management.Entities;
using Buyer_Management.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Factory
{
public abstract class BaseBuyerFactory
    {
        public abstract IBuyerManager Create();
        protected Buyer _byr;
        protected BaseBuyerFactory(Buyer byr)
        {
            _byr = byr;
        }
        public Buyer ApplyDisCount()
        {
            IBuyerManager manager = this.Create();
            _byr.DiscountPcnt = manager.GetDiscount();
            _byr.PayAmount = _byr.TotalAmount - (_byr.TotalAmount * _byr.DiscountPcnt / 100);
            return _byr;

        }
    }
}
