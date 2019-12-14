using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine_Kata.Models;

namespace Vending_Machine_Kata.Interfaces
{
    public interface IProductFactoryBasic
    {
        Dictionary<string, Product> Products { get; set; }
        Product GetBasicProduct(string code);
    }
}
