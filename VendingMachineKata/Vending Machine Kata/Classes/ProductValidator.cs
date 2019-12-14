using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata.Classes
{
    public class ProductValidator : IProductValidate
    {
        public bool ValidAmount(decimal cost, decimal balance) => cost <= balance;
        
    }
}
