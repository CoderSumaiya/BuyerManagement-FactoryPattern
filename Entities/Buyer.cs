using Buyer_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Entities
{
  public  class Buyer
    {
        int buyerId;
        string buyerName;
        string buyerEmail;
        BuyerType byrType;
      

       
        double totalAmount;
        double discountPcnt;
        double payAmount;

        public Buyer()
        {

        }
        public Buyer(int buyerId, string buyerName, string buyerEmail, BuyerType byrType,  double totalAmount, double discountPcnt, double payAmount)
        {
            this.BuyerId = buyerId;
            this.BuyerName = buyerName;
            this.BuyerEmail = buyerEmail;
            this.ByrType = byrType;
           
            this.TotalAmount = totalAmount;
            this.DiscountPcnt = discountPcnt;
            this.PayAmount = payAmount;
        }

        public int BuyerId { get => buyerId; set => buyerId = value; }
        public string BuyerName { get => buyerName; set => buyerName = value; }
        public string BuyerEmail { get => buyerEmail; set => buyerEmail = value; }
        public BuyerType ByrType { get => byrType; set => byrType = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public double DiscountPcnt { get => discountPcnt; set => discountPcnt = value; }
        public double PayAmount { get => payAmount; set => payAmount = value; }
       
    }
}
