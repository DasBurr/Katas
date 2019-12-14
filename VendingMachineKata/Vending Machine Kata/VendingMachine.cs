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
                    InsertCoin(coinInput[0], coinInput[1]);
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
                    ReturnCoins();
                }
                else
                {
                    SelectProduct(val);
                }
            }

        }

        public void InsertCoin(string weight, string size)
        {
            var coinTaken = _coinOperator.TakeCoin(weight, size);

            if (coinTaken)
            {
                
                Console.WriteLine($"Balance ${_coinOperator.Balance}");
            }
            else
            {
                Console.WriteLine($"Coin returned");
            }
        }

        public void SelectProduct(string code)
        {
            var (product, canAfford) = _productDispenser.DispenseBasicProduct(code, _coinOperator.Balance);

            if (canAfford && product.Stock != 0)
            {
                _productStock.DecreaseStock(product);

                Console.WriteLine($"{product.Name} dispensed. Thank you!");

                var change = _returnCoinFromSale.ReturnChangeFromPurchase(product.Price, _coinOperator.Balance);

                Console.WriteLine($"${change} returned.");

                _coinOperator.ResetCoins();

            }
            else if(product.Stock ==0)
            {
                Console.WriteLine("SOLD OUT");
            }
            else
            {
                Console.WriteLine($"INSERT COIN");
                Console.WriteLine($"CURRENT BALANCE {_coinOperator.Balance}");
            }
        }

        public void ReturnCoins()
        {
            Console.WriteLine($"{_coinOperator.Balance} returned");
            Console.WriteLine($"INSERT COIN");

            _coinOperator.Balance = 0;
            _coinOperator.ResetCoins();
        }

    }
}
