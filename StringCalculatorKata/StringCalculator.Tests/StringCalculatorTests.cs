using NUnit.Framework;
using System;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private readonly StringCalculator calculator;

        public StringCalculatorTests()
        {
            this.calculator = new StringCalculator();
        }

        [Test]
        public void AddReturnZero()
        {
            var sum = this.calculator.Add("0");

            Assert.AreEqual(0, sum);
        }

        [TestCase("3,2", 5)]
        [TestCase("99, 101", 200)]
        public void AddTwoNumbers(string numbers, int expectedValue)
        {
            var sum = this.calculator.Add(numbers);

            Assert.AreEqual(expectedValue, sum);
        }

        [TestCase("3,2\n5", 10)]
        [TestCase("99\n101", 200)]
        public void AddTwoNumbersNewLine(string numbers, int expectedValue)
        {
            var sum = this.calculator.Add(numbers);

            Assert.AreEqual(expectedValue, sum);
        }

        [TestCase("99,101,")]
        [TestCase("123\n99,101,")]
        public void ThrowErrorWhenThereIsNoNumberAtEnd(string numbers)
        {
            Assert.Throws<ApplicationException>(() => this.calculator.Add(numbers));

        }

        [TestCase("//;\n1;2;3",6)]
        [TestCase("//'\n2'2'4",8)]
        public void AddWithCustomDelimeter(string numbers, int expectedResult)
        {
            var sum = this.calculator.Add(numbers);

            Assert.AreEqual(expectedResult, sum);
        }
    }
}
