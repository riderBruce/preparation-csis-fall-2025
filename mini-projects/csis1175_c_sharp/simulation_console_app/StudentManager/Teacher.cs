using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    public class Teacher : Person
    {
        public string Subject { get; set; }
        public Teacher() { }
        public Teacher(string name, int age, string subject)
        {
            Name = name;
            Age = age;
            Subject = subject;
        }
        public override string GetDetails() => base.GetDetails() + $" | Subject: {Subject}";
        
        public override string GetDetails(char divider) => base.GetDetails(divider) + $"{divider}{Subject}";
        
    }
}
