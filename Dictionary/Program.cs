using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> numbers = new Dictionary<string, int>
            {
                {"zero", 0},
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };
            Console.WriteLine("This application gives a text and change the written numbers in it to numerals.");
            Console.Write("Please write the text here: ");
            int positionInStr = 0; 
            string text = Console.ReadLine();
            string result = text;

            foreach (KeyValuePair<string, int> oneNum in numbers)
            {
                while ((positionInStr = result.ToLower().IndexOf(oneNum.Key)) > -1)
                {
                    result = result.Substring(0, positionInStr) + oneNum.Value.ToString() 
                        + result.Substring(positionInStr + oneNum.Key.Length);
                }
            }
            Console.WriteLine(result);
        }
    }
}
