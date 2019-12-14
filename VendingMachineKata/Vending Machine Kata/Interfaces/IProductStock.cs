using System.Collections.Generic;
using Vending_Machine_Kata.Models;

namespace Vending_Machine_Kata.Interfaces
{
    public interface IProductStock
    {
        Product DecreaseStock(Product product);

        List<Product> GetProducts();
    }
}
