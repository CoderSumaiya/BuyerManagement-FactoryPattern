using Buyer_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management.Interfaces
{
public interface IBuyerRepo
    {
        IEnumerable<Buyer> GetAllBuyer();
        Buyer GetBuyerById(int id);
        Buyer SaveBuyer(Buyer Buyer);
        Buyer UpdateBuyer(Buyer upBuyer);
        Buyer DeleteBuyer(int id);
    }
}
