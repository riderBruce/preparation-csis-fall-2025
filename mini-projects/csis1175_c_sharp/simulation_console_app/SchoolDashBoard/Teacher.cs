namespace SchoolDashboard
{
    public class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher() { }

        public Teacher(string name, int age, string subject)
            : base(name, age)
        {
            Subject = subject;
        }

        public override string GetDetails() =>
            $"[Teacher] {Name}, Age {Age}, Subject: {Subject}";
    }
}
