using System.Collections.Generic;
using System.Linq;
using Vending_Machine_Kata.Interfaces;
using Vending_Machine_Kata.Models;

namespace Vending_Machine_Kata.Classes
{
    public class ProductStock : IProductStock
    {
        private readonly IProductFactoryBasic _productFactory;

        public ProductStock(IProductFactoryBasic productFactory)
        {
            _productFactory = productFactory;
        }

        public Product DecreaseStock(Product product)
        {
            if (product.Stock != 0)
            {
                product.Stock--;
            }
            return product;
        }

        public List<Product> GetProducts()
        {
            Product[] products = new Product[_productFactory.Products.Count];
            _productFactory.Products.Values.CopyTo(products, 0);

            return products.ToList();
        }
    }
}
