using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Name} Cost - ${Price} Code - {Code} Stock - {Stock}";
        }
    }
}
