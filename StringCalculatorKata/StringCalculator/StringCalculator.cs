using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private List<string> seperators = new List<string>() { ",", "\n" };
        private string customSeperator = "//";

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (numbers.EndsWith(","))
            {
                throw new ApplicationException("Number expected but EOF found");
            }
            else if(numbers.StartsWith(this.customSeperator))
            {
                numbers = AddCustomSeperators(numbers);
            }

            return SplitNumbers(numbers).Sum();
        }

        private string AddCustomSeperators(string numbers)
        {
            var tempCustomSplitter = numbers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            numbers = numbers.Substring(tempCustomSplitter.Length);

            var customSplitter = tempCustomSplitter.Replace(this.customSeperator, "");

            this.seperators.Add(customSplitter);

            return numbers;

        }

        public List<int> SplitNumbers(string numbers)
        {
            var stringSplit = numbers.Split(seperators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var cleanedNumbers = new List<int>();

            foreach (var number in stringSplit)
            {
                var convertedStringToInt = int.Parse(number);

                cleanedNumbers.Add(convertedStringToInt);

            }

            return cleanedNumbers;
        }
    }
}
