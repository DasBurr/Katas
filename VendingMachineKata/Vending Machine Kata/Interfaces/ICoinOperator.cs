using Vending_Machine_Kata.Enums;

namespace Vending_Machine_Kata.Interfaces
{
    public interface ICoinOperator
    {
        int ReturnedCoins { get; set; }
        decimal Balance { get; set; }
        bool TakeCoin(string weight, string size);
        Coin SortCoin(string weight, string size);
        void ResetCoins();
    }
}
