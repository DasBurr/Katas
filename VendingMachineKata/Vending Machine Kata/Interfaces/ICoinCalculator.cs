using System.Collections.Generic;
using Vending_Machine_Kata.Enums;

namespace Vending_Machine_Kata.Interfaces
{
    public interface ICoinCalculator
    {
        decimal CalculateCoinValue(Coin coin);
        decimal CalculateTotalValue(List<Coin> coins);
    }
}
