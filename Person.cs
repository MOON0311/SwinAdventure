using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class Person
    {
        protected string _firstName;
        protected string _lastName;

        public Person(string firstName, string lastName) 
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public abstract void PrintDetails();
    }
}
