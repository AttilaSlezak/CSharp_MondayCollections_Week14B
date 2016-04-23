using System;
using System.Collections.Generic;
using LinkedList;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTask
{
    class LinkedListTask
    {
        private static LinkedList<int> intLinkedList = new LinkedList<int>();
        private static LinkedList<string> strLinkedList = new LinkedList<string>();
        private static LinkedList<Person> perLinkedList = new LinkedList<Person>();
        private static LinkedListNode<Person> perLinkedListNode = perLinkedList.First;
        private static string dataFromUser;

        private static void AskIntegersFromUser()
        {
            LinkedListNode<int> intLinkedListNode = intLinkedList.First;
            bool isInt;

            int i = 1;

            do
            {
                Console.Write("Please write the {0}. integer (or press Enter if you finished): ", i);
                dataFromUser = Console.ReadLine();
                int number = 0;
                isInt = Int32.TryParse(dataFromUser, out number);
                if (isInt && i == 1)
                {
                    intLinkedList.AddFirst(number);
                    intLinkedListNode = intLinkedList.First;
                    i++;
                }
                else if (isInt)
                {
                    intLinkedList.AddAfter(intLinkedListNode, number);
                    intLinkedListNode = intLinkedListNode.Next;
                    i++;
                }
            } while (dataFromUser != "");
        }

        private static void AskStringsFromUser()
        {
            LinkedListNode<string> strLinkedListNode = strLinkedList.First;

            int i = 1;

            do
            {
                Console.Write("{0}Please write the {1}. text (or press Enter if you finished): ", i == 1 ? "\n" : "", i);
                dataFromUser = Console.ReadLine();
                if (i == 1)
                {
                    strLinkedList.AddFirst(dataFromUser);
                    strLinkedListNode = strLinkedList.First;
                    i++;
                }
                else if (dataFromUser != "")
                {
                    strLinkedList.AddAfter(strLinkedListNode, dataFromUser);
                    strLinkedListNode = strLinkedListNode.Next;
                    i++;
                }
            } while (dataFromUser != "");
        }

        private static void AskPeopleFromUser()
        {
            string nameFromUser;
            int ageFromUser;
            double heightFromUser;
            bool isInt;
            bool isDouble;

            int i = 1;

            while (true)
            {
                Console.Write("\nPlease write the {0}. person's name (or press Enter if you finished): ", i);
                if ((nameFromUser = Console.ReadLine()) == "") break;
                do
                {
                    Console.Write("Please write the {0}. person's age: ", i);
                    isInt = Int32.TryParse(Console.ReadLine(), out ageFromUser);
                } while (!isInt);
                do
                {
                    Console.Write("Please write the {0}. person's height: ", i);
                    isDouble = Double.TryParse(Console.ReadLine(), out heightFromUser);
                } while (!isDouble);
                if (i == 1)
                {
                    perLinkedList.AddFirst(new Person(nameFromUser, ageFromUser, heightFromUser));
                    perLinkedListNode = perLinkedList.First;
                    i++;
                }
                else
                {
                    perLinkedList.AddAfter(perLinkedListNode, new Person(nameFromUser, ageFromUser, heightFromUser));
                    perLinkedListNode = perLinkedListNode.Next;
                    i++;
                }
            }
        }

        private static void AddDefaultPeople()
        {
            Person george = new Person("George", 25, 1.85);
            Person kate = new Person("Kate", 21, 1.65);
            Person winstone = new Person("Winstone", 32, 1.75);
            Person bjorn = new Person("Björn", 28, 1.78);
            List<Person> defaultPersons = new List<Person> { george, kate, winstone, bjorn };

            do
            {
                Console.Write("\nWould you like to add default people to the list? (Yes or No?): ");
                dataFromUser = Console.ReadLine();
            } while (dataFromUser.ToLower() != "yes" && dataFromUser.ToLower() != "no");

            if (dataFromUser.ToLower() == "yes")
            {
                for (int j = 0; j < defaultPersons.Count; j++)
                {
                    if (perLinkedList.Count < 1)
                    {
                        perLinkedList.AddFirst(defaultPersons[j]);
                        perLinkedListNode = perLinkedList.First;
                    }
                    else
                    {
                        perLinkedList.AddAfter(perLinkedListNode, defaultPersons[j]);
                        perLinkedListNode = perLinkedListNode.Next;
                    }
                }
            }
        }

        private static void WriteToScreenTheResults()
        {
            Console.WriteLine("\nThe numbers from the LinkedList:");

            for (LinkedListNode<int> it = intLinkedList.First; it != null; it = it.Next)
            {
                Console.WriteLine(it.Value);
            }

            Console.WriteLine("\nThe strings from the LinkedList:");

            for (LinkedListNode<string> it = strLinkedList.First; it != null; it = it.Next)
            {
                Console.WriteLine(it.Value);
            }

            Console.WriteLine("\nThe persons from the LinkedList:");

            for (LinkedListNode<Person> it = perLinkedList.First; it != null; it = it.Next)
            {
                Console.WriteLine(it.Value);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! This program uses LinkedLists.\nFirst it asks for some integer from the user, " 
                + "then it asks for some string, and finally it asks for some person's data." 
                + "(In case of persons, user also can choose a default set of persons.)\n");

            AskIntegersFromUser();
            AskStringsFromUser();
            AskPeopleFromUser();
            AddDefaultPeople();
            WriteToScreenTheResults();
        }
    }
}
