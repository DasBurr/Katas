using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata.Classes
{
    public class CoinReturns : IReturnCoinFromSale
    {
        public decimal ReturnChangeFromPurchase(decimal purchaseTotal, decimal balance) => balance - purchaseTotal;
    }
}
