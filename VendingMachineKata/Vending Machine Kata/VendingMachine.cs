using System;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata
{
    public class VendingMachine
    {
        private readonly ICoinOperator _coinOperator;
        private readonly IProductDispenser _productDispenser;
        private readonly IReturnCoinFromSale _returnCoinFromSale;
        private readonly IProductStock _productStock;
        private readonly ICoinBank _coinBank;

        public VendingMachine(ICoinOperator coinOperator, IProductDispenser productDispenser,
            IReturnCoinFromSale returnCoinFromSale, IProductStock productStock, ICoinBank coinBank)
        {
            _coinOperator = coinOperator;
            _productDispenser = productDispenser;
            _returnCoinFromSale = returnCoinFromSale;
            _productStock = productStock;
            _coinBank = coinBank;
        }

        public void Run()
        {

            while (true)
            {
                var val = Console.ReadLine();

                if (val.Contains("|"))
                {
                    var coinInput = val.Split('|');
                    Console.WriteLine(InsertCoin(coinInput[0], coinInput[1]));
                }
                else if(val == "p")
                {
                    foreach (var product in _productStock.GetProducts())
                    {
                        Console.WriteLine(product.ToString());
                    }
                }
                else if(val == "r")
                {
                    Console.WriteLine(ReturnCoins());
                }
                else
                {
                    Console.WriteLine(SelectProduct(val));
                }
            }

        }

        public string InsertCoin(string weight, string size)
        {
            var coinTaken = _coinOperator.TakeCoin(weight, size);

            if (coinTaken)
            {
                
                return $"${_coinOperator.Balance}";
            }
            else
            {
               return"Coin returned";
            }
        }

        public string SelectProduct(string code)
        {
            var (product, canAfford) = _productDispenser.DispenseBasicProduct(code, _coinOperator.Balance);

            if (canAfford && product.Stock != 0)
            {
                _productStock.DecreaseStock(product);

                var change = _returnCoinFromSale.ReturnChangeFromPurchase(product.Price, _coinOperator.Balance);

                _coinOperator.ResetCoins();

                return $"Thank you. ${change} returned.";

            }
            else if(!canAfford)
            {
                return $"INSERT COIN. ${_coinOperator.Balance}";
            }
            else
            {
                return "SOLD OUT";
            }
        }

        public string ReturnCoins()
        {
            var oldBalance = _coinOperator.Balance;
            _coinOperator.Balance = 0;
            _coinOperator.ResetCoins();

           return $"${oldBalance} returned. INSERT COIN";

        }

    }
}
