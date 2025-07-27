using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public Student(string name)
        {
            Name = name;
        }
        public Student(string name, int age, string major)
        {
            Name = name;
            Age = age;
            Major = major;
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Major: {Major}");
        }
        public string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}, Major: {Major}";
        }
    }
}
