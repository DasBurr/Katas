namespace Vending_Machine_Kata.Interfaces
{
    public interface IProductValidate
    {
        bool ValidAmount(decimal cost, decimal balance);
    }
}
