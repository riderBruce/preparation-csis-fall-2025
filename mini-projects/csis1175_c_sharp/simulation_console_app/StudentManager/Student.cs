using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    public class Student : Person
    {
        public string Major { get; set; }

        public Student() { }
        public Student(string name) => Name = name;
        public Student(string name, int age, string major)
        {
            Name = name;
            Age = age;
            Major = major;
        }
        
        public override string GetDetails()
        {
            return base.GetDetails() + $" | Major: {Major}";
        }
        public override string GetDetails(char divider)
        {
            return base.GetDetails(divider) + $"{divider}{Major}";
        }
    }
}
