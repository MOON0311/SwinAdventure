using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Student : Person
    {
        private string _course;

        public Student(string firstName, string lastName, string Course): base(firstName, lastName)
        {
            _course = Course;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Name: {_firstName} {_lastName}");
            Console.WriteLine($"Course: {_course}");
        }
    }
}
