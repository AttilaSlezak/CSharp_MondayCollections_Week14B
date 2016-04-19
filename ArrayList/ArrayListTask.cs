using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTask
{
    class ArrayListTask
    {
        static void Main(string[] args)
        {
            ArrayList texts = new ArrayList();
            string newText = "";
            int numberOfTexts = 0;

            Console.WriteLine("This application gives texts from the user, sorts them and finally prints the result to the screen.");
            
            do
            {
                numberOfTexts++;
                Console.Write("Please write the {0}. text here (or press Enter to finish): ", numberOfTexts);
                if ((newText = Console.ReadLine()) != "")
                    texts.Add(newText);
            } while (newText != "");

            texts.Sort();

            for (int i = 0; i < texts.Count; i++)
            {
                Console.WriteLine(texts[i]);
            }
        }
    }
}
