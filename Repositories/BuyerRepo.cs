using Buyer_Management.Entities;
using Buyer_Management.Enums;
using Buyer_Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Repositories
{
    public class BuyerRepo : IBuyerRepo
    {


        private List<Buyer> buyerList;
        public BuyerRepo()
        {
            buyerList = new List<Buyer>()
            {
                new Buyer(){BuyerId=1,BuyerName="Aysha Akter",BuyerEmail="aysha@gmail.com",ByrType=BuyerType.Regular,TotalAmount=10000,PayAmount=6000,DiscountPcnt=40},
                new Buyer(){BuyerId=2,BuyerName="Siam Hasan",BuyerEmail="siam@gmail1.com",ByrType= BuyerType.New,TotalAmount=3000,PayAmount=3000,DiscountPcnt=0}
            };
        }
        public Buyer DeleteBuyer(int id)
        {
            var deleteByr = GetBuyerById(id);
            if (deleteByr != null)
            {
                buyerList.Remove(deleteByr);
            }
            return deleteByr;
        }
     

        public IEnumerable<Buyer> GetAllBuyer()
        {
            return from byrs in buyerList select byrs;
        }

        public Buyer GetBuyerById(int id)
        {
            var byr = (from b in buyerList where b.BuyerId == id select b).FirstOrDefault();
            return byr;
        }

        public Buyer SaveBuyer(Buyer buyer)
        {
         Buyer byr = (from b in buyerList orderby b.BuyerId descending select b).FirstOrDefault();
           buyer.BuyerId = byr.BuyerId + 1;
            buyerList.Add(buyer);
            return buyer;
        }

        public Buyer UpdateBuyer(Buyer upBuyer)
        {
            Buyer byr = GetBuyerById(upBuyer.BuyerId);
            byr.BuyerName = upBuyer.BuyerName;
            byr.BuyerEmail = upBuyer.BuyerEmail;
            byr.ByrType = upBuyer.ByrType;
            byr.TotalAmount = upBuyer.TotalAmount;
            byr.DiscountPcnt = upBuyer.DiscountPcnt;
            byr.PayAmount = upBuyer.PayAmount;
            byr.BuyerId = upBuyer.BuyerId;
            return upBuyer;
        }
    }
}
