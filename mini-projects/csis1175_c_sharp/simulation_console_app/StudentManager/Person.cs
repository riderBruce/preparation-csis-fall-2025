using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public virtual string GetDetails() => $"Name: {Name} | Age: {Age}";
        
        public virtual string GetDetails(char divider) => $"{Name}{divider}{Age}";
        
    }
}
