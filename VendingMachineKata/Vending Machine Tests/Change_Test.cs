using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Vending_Machine_Kata.Classes;

namespace Vending_Machine_Tests
{
    [TestFixture]
    public class Change_Test
    {
        [Test]
        public void GivenIPayTwoDollarsWithABankTotalOfThree()
        {
            var bank = new CoinBank();

            bank.DecreaseBalance(2.1M);

            Assert.AreEqual(bank.HasChange(), false);
        }

        [Test]
        public void GivenIPayOneDollarsWithABankTotalOfThree()
        {
            var bank = new CoinBank();

            bank.DecreaseBalance(1.0M);

            Assert.AreEqual(bank.HasChange(), true);
        }

        [Test]
        public void GivenIPayOneDollar()
        {
            var bank = new CoinBank();

            bank.IncreaseBalance(1.0M);

            Assert.AreEqual(bank.Balance, 4.0M);
        }

        [Test]
        public void GivenIReceiveChange()
        {
            var bank = new CoinBank();

            bank.DecreaseBalance(1.0M);

            Assert.AreEqual(bank.Balance,2.0M);
        }
    }
}
