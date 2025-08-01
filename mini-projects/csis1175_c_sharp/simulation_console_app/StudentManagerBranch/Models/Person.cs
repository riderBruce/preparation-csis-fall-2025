namespace StudentManagerBranch.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string GetDetails() => $"Name: {Name}, Age: {Age}";
    }
}
