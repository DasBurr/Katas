using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata.Interfaces
{
    public interface ICoinBank
    {
        decimal Balance { get; set; }

        void DecreaseBalance(decimal input);

        void IncreaseBalance(decimal input);

        bool HasChange();
    }
}
