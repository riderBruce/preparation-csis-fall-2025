namespace StudentPortal.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Major { get; set; }
        public int Age { get; set; }

        public Student() { }

        public Student(string name, string major, int age)
        {
            Name = name;
            Major = major;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Major: {Major} | Age: {Age}";
        }

        public string ToCsv(char delimiter = ',')
        {
            return $"{Name}{delimiter}{Major}{delimiter}{Age}";
        }

        public static Student FromCsv(string line, char delimiter = ',')
        {
            var parts = line.Split(delimiter);
            return new Student(parts[0], parts[1], int.Parse(parts[2]));
        }
    }
}
