using System.Collections.Generic;
using System.Linq;
using Vending_Machine_Kata.Interfaces;
using Vending_Machine_Kata.Models;

namespace Vending_Machine_Kata.Classes
{
    public class ProductFactory : IProductFactoryBasic
    {
        public Dictionary<string, Product> Products { get; set; }

        public ProductFactory()
        {
            SetUpProducts();
        }


        public Product GetBasicProduct(string code) => Products.First(k => k.Key == code).Value;

        private void SetUpProducts()
        {
            Products = new Dictionary<string, Product>
            {
                {"A03",   new Product {Code = "A03", Name = "cola", Price = 1.00M, Stock = 5}},
                {"B13", new Product {Code = "B13", Name = "chips", Price = 0.5M, Stock = 10} },
                {"E07",  new Product {Code = "E07", Name = "candy", Price = 0.65M, Stock = 20}}
            };
        }

    }
}
