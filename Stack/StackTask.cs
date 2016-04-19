using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTask
{
    class StackTask
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            string inputFromUser = "";
            bool isNumber = false;
            int oneNum = 0;
            int indexNum = 1;

            Console.WriteLine("This application gives numbers from the user and then prints them to the screen in reverse sequence.");

            do
            {
                Console.Write("Please write the {0}. number here (or press Enter to finish): ", indexNum);
                isNumber = Int32.TryParse((inputFromUser = Console.ReadLine()), out oneNum);
                if (isNumber)
                {
                    numbers.Push(oneNum);
                    isNumber = false;
                    indexNum++;
                }
            } while (inputFromUser != "");

            Console.WriteLine("\nThe numbers in reverse sequence:");

            while (0 < numbers.Count)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
