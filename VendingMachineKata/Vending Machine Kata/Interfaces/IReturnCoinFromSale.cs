using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata.Interfaces
{
    public interface IReturnCoinFromSale
    {
        decimal ReturnChangeFromPurchase(decimal purchaseTotal, decimal balance);
    }
}
