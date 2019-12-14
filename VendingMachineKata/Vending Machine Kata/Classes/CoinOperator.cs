using System.Collections.Generic;
using Vending_Machine_Kata.Enums;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata.Classes
{
    public class CoinOperator : ICoinOperator
    {
        public int ReturnedCoins { get; set; }
        public decimal Balance { get; set; }

        private readonly List<Coin> _insertedCoins;
        private readonly ICoinCalculator _coinCalculator;

        public CoinOperator(ICoinCalculator coinCalculator)
        {
            this._coinCalculator = coinCalculator;
            _insertedCoins = new List<Coin>();
        }

        public bool TakeCoin(string weight, string size)
        {
            var coin = this.SortCoin(weight, size);

            if (coin == Coin.penny)
            {
                this.ReturnedCoins++;
                return false;
            }
            else
            {
                _insertedCoins.Add(coin);
                this.Balance = _coinCalculator.CalculateTotalValue(_insertedCoins);
                return true;
            }

        }

        public void ResetCoins()
        {
            _insertedCoins.Clear();
        }

        public Coin SortCoin(string weight, string size) => (weight, size) switch
        {
            ("5", "2") => Coin.nickel,
            ("2", "17") => Coin.dime,
            ("5", "24") => Coin.quater,
            _ => Coin.penny
        };
    }
}
