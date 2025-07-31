namespace SchoolDashboard
{
    public class Student : Person
    {
        public string Major { get; set; }

        public Student() { }

        public Student(string name, int age, string major)
            : base(name, age)
        {
            Major = major;
        }

        public override string GetDetails() =>
            $"[Student] {Name}, Age {Age}, Major: {Major}";
    }
}
