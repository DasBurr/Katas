using Vending_Machine_Kata.Models;

namespace Vending_Machine_Kata.Interfaces
{
    public interface IProductDispenser
    {
        (Product, bool) DispenseBasicProduct(string code, decimal balance);
    }
}
