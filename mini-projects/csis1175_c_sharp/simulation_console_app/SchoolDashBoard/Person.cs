﻿namespace SchoolDashboard
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual string GetDetails() => $"[Person] {Name}, Age {Age}";
    }
}
