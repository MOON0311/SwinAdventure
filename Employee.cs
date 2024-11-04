using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Employee : Person
    {
        private double _salary;

        public Employee(string firstName, string lastName, double salary): base(firstName, lastName)
        {
            _salary = salary;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Name: {_firstName} {_lastName}");
            Console.WriteLine($"Salary: {_salary}");
        }
    }
}
