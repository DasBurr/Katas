using Vending_Machine_Kata.Interfaces;
using Vending_Machine_Kata.Models;

namespace Vending_Machine_Kata.Classes
{
    public class ProductDispenser : IProductDispenser
    {
        private readonly IProductFactoryBasic _productFactoryBasic;
        private readonly IProductValidate _productValidate;

        public ProductDispenser(IProductFactoryBasic prodcutFactoryBasic, IProductValidate productValidate)
        {
            _productFactoryBasic = prodcutFactoryBasic;
            _productValidate = productValidate;
        }


        public (Product, bool) DispenseBasicProduct(string code, decimal balance)
        {
            var product = _productFactoryBasic.GetBasicProduct(code);

            return _productValidate.ValidAmount(product.Price, balance) ? (product, true) : (null, false);
        }
    }
}
