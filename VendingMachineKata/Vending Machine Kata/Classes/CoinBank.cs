using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata.Classes
{
    public class CoinBank : ICoinBank
    {
        public decimal Balance { get; set; } = 3.0M;

        public void DecreaseBalance(decimal input)
        {
            Balance -= input;
        }

        public void IncreaseBalance(decimal input)
        {
            Balance += input;
        }

        public bool HasChange() => Balance >= 1.0M;
        
    }
}
