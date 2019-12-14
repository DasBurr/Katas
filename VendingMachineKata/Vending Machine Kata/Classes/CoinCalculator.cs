using System.Collections.Generic;
using Vending_Machine_Kata.Enums;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata.Classes
{
    public class CoinCalculator : ICoinCalculator
    {
        public decimal CalculateCoinValue(Coin coin) =>
            coin switch
            {
                Coin.nickel => 0.05M,
                Coin.dime => 0.10M,
                Coin.quater => 0.25M
            };

        public decimal CalculateTotalValue(List<Coin> coins)
        {
            decimal total = 0;

            foreach (var coin in coins)
            {
                total += CalculateCoinValue(coin);
            }

            return total;
        }
    }
}
