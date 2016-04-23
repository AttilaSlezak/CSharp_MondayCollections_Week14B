using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Person
    {
        string name;
        int age;
        double height;

        public Person(string name, int age, double height)
        {
            this.name = name;
            this.age = age;
            this.height = height;
        }

        public override string ToString()
        {
            return "Name: " + name + "; Age: "+ age.ToString() + "; Height: " + height.ToString();
        }

    }
}
